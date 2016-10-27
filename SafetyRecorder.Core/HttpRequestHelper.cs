using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;

namespace SafetyRecorder.Core
{
    public static class HttpRequestHelper
    {
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Get", Justification = "Want to call Get to fit in with the HTTP verb")]
        public static HttpResponseMessage Get(string url)
        {
            Uri absoluteUri = new Uri(url);

            using (HttpClient httpClient = GetHttpClient(absoluteUri))
            {
                return Get(httpClient, absoluteUri);
            }
        }

        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Get", Justification = "Want to call Get to fit in with the HTTP verb")]
        private static HttpResponseMessage Get(HttpClient httpClient, Uri absoluteUri)
        {
            // Create the request
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, absoluteUri);
            request.Headers.Add("Accept", "application/json");

            // Make the request  - HttpCompletionOption.ResponseHeadersRead is used to avoid memory leak
            HttpResponseMessage response = httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).Result;
            
            return response;
        }

        public static T Get<T>(string url)
        {
            // Get the absolute endpoint, adding any required oData parameters to query string
            Uri absoluteUri = new Uri(url);

            using (HttpClient httpClient = GetHttpClient(absoluteUri))
            {
                T result = default(T);

                // Make the call and get the response
                HttpResponseMessage response = Get(httpClient, absoluteUri);

                // Read the result. This will deserialise the incoming response content
                if (response.IsSuccessStatusCode && response.Content != null &&
                    response.Content.Headers.ContentType != null)
                {
                    // Get the type of media and use the formatter to get the content out of response
                    MediaTypeFormatter formatter = new JsonMediaTypeFormatter();

                    var task = response?.Content?.ReadAsAsync<T>(new List<MediaTypeFormatter> { formatter }).ContinueWith(t =>
                    {
                        result = t.Result;
                    });

                    task?.Wait();
                }

                // Return the response containing the de-serialised result
                return result;
            }
        }

        public static HttpResponseMessage Post<T>(string uri, T content) where T : class
        {
            return PostRequest(uri, content);
        }

        private static HttpResponseMessage PostRequest<T>(
            string uri,
            T content) where T : class
        {
            HttpResponseMessage response = null;

            using (HttpClient httpClient = GetHttpClient(new Uri(uri)))
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uri);

                if (content == null)
                {
                    request.Content = new StringContent(string.Empty);
                }
                else
                {
                    //string mediaType = string.Empty;
                    //if (request.Headers.Accept != null && request.Headers.Accept.Count > 0)
                    //{
                    //    mediaType = request.Headers.Accept.FirstOrDefault().MediaType;
                    //}

                    request.Content = new ObjectContent<T>(content, new JsonMediaTypeFormatter());
                }
                
                response = httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).Result;
            }

            return response;
        }   

        private static HttpClient GetHttpClient(Uri absoluteUri)
        {
            return new HttpClient(new HttpClientHandler { AllowAutoRedirect = false });
        }
    }
}

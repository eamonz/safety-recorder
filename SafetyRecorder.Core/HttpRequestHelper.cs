using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace SafetyRecorder.Core
{
    public static class HttpRequestHelper
    {
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
                    string mediaType = string.Empty;

                    if (request.Headers.Accept != null && request.Headers.Accept.Count > 0)
                    {
                        mediaType = request.Headers.Accept.FirstOrDefault().MediaType;
                    }

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

using SafetyRecorder.Core;
using SafetyRecorder.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SafetyRecorder.Web.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Index()
        //{
        //    ViewBag.Title = "Safety Recorder";

        //    return View();
        //}
        public ViewResult Index()
        {
            //HttpRequestHelper.Get<>

            List<SafetyObservationViewModel> models = new List<SafetyObservationViewModel>();

            return View(models);
        }
    }
}

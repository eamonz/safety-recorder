using System.Web.Mvc;

namespace SafetyRecorder.Web.Controllers
{
    public class ObservationController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Safety Recorder";

            return View();
        }
    }
}

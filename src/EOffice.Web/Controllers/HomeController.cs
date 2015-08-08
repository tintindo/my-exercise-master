using System.Web.Mvc;

namespace EOffice.Web.Controllers
{
    public class HomeController : EOfficeControllerBase
    {
        public ActionResult Index()
        { 
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Services;

namespace ActionResultsDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Alternate()
        {
            return View("Other");
        }

        public ActionResult Multiple()
        {
            if(DateTime.Now.Day % 2 == 0)
            {
                return View("Multiple");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public FileResult ViewFile()
        {
            return File(Url.Content("~/Files/testfile.txt"), "text/plain");
        }

        public FileResult DownloadFile()
        {
            return File(Url.Content("~/Files/testfile.txt"), "text/plain", "testFile.txt");
        }

        public FileResult FileBytes()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(Server.MapPath("~/Files/testfile.txt"));
            return File(fileBytes, "text/plain");
        }

        public RedirectToRouteResult RedirectToAction()
        {
            return RedirectToAction("Action");
        }

        public RedirectToRouteResult RedirectToRoute()
        {
            return RedirectToRoute(new { controller = "Home", action = "Route" });
        }

        public ActionResult Action()
        {
            return View();
        }

        public ActionResult Route()
        {
            return View();
        }

        public RedirectResult RedirectToOtherSite()
        {
            return Redirect("http://www.exceptionnotfound.net");
        }

        public PartialViewResult Partial()
        {
            return PartialView("CustomPartial");
        }

        public ContentResult Content()
        {
            return Content("<h3>Here's a custom content header</h3>", "text/html");
        }

        public JsonResult Json()
        {
            return Json(new { Name = "John Smith", ID = 4, DateOfBirth = new DateTime(1999, 12, 31) }, JsonRequestBehavior.AllowGet);
        }

        public JavaScriptResult LoadScript()
        {
            return JavaScript("alert('Hello!  This popup shows that we can return JavaScript from controller actions.')");
        }

        public ActionResult JavaScript()
        {
            return View("JavaScript");
        }

        public HttpStatusCodeResult UnauthorizedResult()
        {
            return new HttpUnauthorizedResult("You are not authorized to access this controller action.");
        }

        public HttpStatusCodeResult UnauthorizedStatusCode()
        {
            return new HttpStatusCodeResult(HttpStatusCode.Unauthorized, "You are not authorized to access this controller action.");
        }

        public HttpStatusCodeResult BadGateway()
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadGateway, "I have no idea what this error means.");
        }

        public HttpNotFoundResult NotFound()
        {
            return HttpNotFound("We didn't find that action, sorry!");
        }

        public EmptyResult Empty()
        {
            return new EmptyResult();
        }
    }
}
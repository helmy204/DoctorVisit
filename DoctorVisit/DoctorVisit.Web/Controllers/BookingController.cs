using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorVisit.Web.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(string start,string end)
        {


            return Json("success");
        }
    }
}
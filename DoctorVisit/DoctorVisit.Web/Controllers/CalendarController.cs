using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoctorVisit.Web.Controllers
{
    public class CalendarController : Controller
    {
        // GET: Calendar
        public ActionResult Index()
        {
            return View();
        }

        // GET: /Calendar/Calendar
        [ChildActionOnly]
        public ActionResult Calendar()
        {
            return View();
        }
    }
}
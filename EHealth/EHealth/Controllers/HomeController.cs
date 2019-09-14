using EHealth.BusinessLogic.Models;
using EHealth.BusinessLogic.Models.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EHealth.Controllers
{
    public class HomeController : GenericBaseController
    {
        public ActionResult Index()
        {
            var identiry = GetIdentity();

            ViewBag.ProfilePicture = identiry.ProfilePictureUrl;
            ViewBag.Name = identiry.FullName;
            ViewBag.BirthDay = identiry.BirthDay;


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}
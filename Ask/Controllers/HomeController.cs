using Ask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace Ask.Controllers
{
    public class HomeController : Controller
    {
        readonly ApplicationDbContext _db = new ApplicationDbContext();
        public ActionResult Index()
        {
            if (Session["approve"] != null)
            {
                ViewBag.x = Session["approve"];
                Session["approve"] = null;
            }
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
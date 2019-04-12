using Ask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ask.Areas.Admin.Controllers
{
    [AccessDeniedAuthorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            var roleId = _db.Roles.FirstOrDefault(r => r.Name == "Admin").Id;
            var users = _db.Users.Where(x=>x.Roles.All(r=>r.RoleId!=roleId));

            ViewBag.allUsers = users.Count();
            ViewBag.pendingUsers = users.Where(x=>x.Approval==false).Count();

            return View();
        }
    }
}
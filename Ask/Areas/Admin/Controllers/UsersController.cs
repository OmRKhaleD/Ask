using Ask.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ask.Areas.Admin.Controllers
{
    [AccessDeniedAuthorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Admin/Users
        public ActionResult Index()
        {

            var roleId = _db.Roles.FirstOrDefault(r => r.Name == "Admin").Id;
            var users = _db.Users.Where(x => x.Roles.All(r => r.RoleId != roleId));
            return View(users);
        }

        public JsonResult EditApproval(string id)
        {
            var user = _db.Users.Find(id);
            if (user != null)
            {
                user.Approval = !user.Approval;
                _db.Entry(user).State = EntityState.Modified;
            }
            _db.SaveChanges();
            return Json("Index", JsonRequestBehavior.AllowGet);
        }
    }
}
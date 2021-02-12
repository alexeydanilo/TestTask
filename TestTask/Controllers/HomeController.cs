using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTask.Models;

namespace TestTask.Controllers
{
    public class HomeController : Controller
    {

        UserContext db = new UserContext();
        public ActionResult Index()

        {
            ViewBag.Active = db.Users.Where(i => i.Active == true).Count();
            ViewBag.AllActive = db.Users.Count();

            var model = db.Users;
            return View(model.ToList());
        }

        [HttpPost]
        public ActionResult ChangeUserState(int? id)
        {
            if (id.HasValue)
            {
                User user = db.Users.FirstOrDefault(x => x.Id == id);
                if (user != null)
                {
                    user.Active = !user.Active;
                    db.SaveChanges();

                    return Json(new { result = "OK" });
                }
                else
                {
                    return Json(new { result = "User not found" });
                }
            }
            else
            {
                return Json(new { result = "Missing id" });
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
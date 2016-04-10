using System.Linq;
using System.Web.Mvc;
using MVC_Proekt.Models;

namespace MVC_Proekt.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using (DataBase db = new DataBase()) {
                return View(db.useraccount.ToList());
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount user)
        {
            if (ModelState.IsValid)
            {
                using (DataBase db = new DataBase()) {
                    db.useraccount.Add(user);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = user.Name + " успешно се регистриравте";
            }
            return View();
        }
        //Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using (DataBase db = new DataBase()) {
                var usr = db.useraccount.Single(u => u.Username == user.Username && u.Password == user.Password);
                if (usr != null)
                {
                    Session["UserID"] = usr.UserId.ToString();
                    Session["UserName"] = usr.Username.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Погрешно корисничко име или лозинка");
                }
            }
            return View();
        }
        public ActionResult LoggedIn()
        {
            if (Session["UserID"] != null) {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}
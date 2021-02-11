using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dash.Models;

namespace Dash.Controllers
{
    public class UserController : Controller
    {
        IUserDAO repo = new UserAdoRepository();
        // GET: User
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(RegisterUserViewModel R_user)
        {
            if (ModelState.IsValid)
            {
                   
                String UserID = repo.insert(R_user).ToString();
                ViewBag.UserId = string.Format(" Register Sucessully!!     Your UserID is - {0}", UserID);
                
                return View("Login");//saved
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel L_user)
        {
            Boolean IsAuthenticated = repo.Authenticate(L_user);
            if (IsAuthenticated)
            {
                Session["User"] = L_user.UserID;
                Session.Timeout = 1;
                return RedirectToAction("Welcome");
            }
            else
            {
                return View("Login");
            }
        }
        [HttpGet]
        [CheckLoginSessionFilter]
        public ActionResult Welcome()
        {
            return View();
        }
        [HttpGet]
        [CheckLoginSessionFilter]
        public ActionResult Logoff()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

    }
}
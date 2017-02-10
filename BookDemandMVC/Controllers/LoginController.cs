using BookDemandMVC.Utilities;
using BookWebApplication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BookDemandMVC.Controllers
{
    /// <summary>
    /// Login Manipulation Controller
    /// </summary>
    public class LoginController : Controller
    {
        static bool error = false;

        /// <summary>
        /// Register Empty Action
        /// </summary>
        /// <returns>Register View</returns>
        [HttpGet]
        public ActionResult Register()
        {
            var model = new UserModel();
            if (error)
                model.error = true;
            return View(model);
        }

        /// <summary>
        /// Register Page Submit Action
        /// </summary>
        /// <param name="model">User model to register</param>
        /// <returns>Index View</returns>
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Register(UserModel model)
        {
            string link = "User/Register?" + "Username=" + model.Username + "&Password=" + model.Password + "&Library=" + model.Library;
            var check = await Utility.GetApi<bool>(link);
            if (check)
            {
                error = false;
                var cookie = new HttpCookie("username", model.Username);
                Response.Cookies.Add(cookie);
                return RedirectToAction("Index", "Home", new { model.Username });
            }
            else
            {
                error = true;
                return RedirectToAction("Register");
            }
        }

        /// <summary>
        /// Sign in Page
        /// </summary>
        /// <param name="LoggedIn">Logged in or not</param>
        /// <returns>SignIn View</returns>
        [HttpGet]
        public ActionResult SignIn(string LoggedIn)
        {
            if (LoggedIn == "Yes")
                Response.Cookies.Remove("username");
            var model = new UserModel();
            return View(model);
        }

        /// <summary>
        /// Sign In Submit Action
        /// </summary>
        /// <param name="model">User model to sign in</param>
        /// <returns>Index Page View</returns>
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> SignIn(UserModel model)
        {
            var link = "User/Login?" + "Username=" + model.Username + "&Password=" + model.Password;        
            var check = await Utility.GetApi<bool>(link);
            if (check)
            {
                var cookie = new HttpCookie("username", model.Username);
                Response.Cookies.Add(cookie);
                return RedirectToAction("Index", "Home", new { model.Username });
            }
            else
            {
                return RedirectToAction("SignIn");
            }
        }
    }
}
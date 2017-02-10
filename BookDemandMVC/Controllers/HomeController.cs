using BookDemandMVC.Models;
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

namespace BookDemandMVC.Controllers
{
    /// <summary>
    /// Controller for Pages Manipulation
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Book Index Action
        /// </summary>
        /// <returns>Index View</returns>
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            var link = "Book/Get";
            var list = await Utility.GetApi<List<BookModel>>(link);
            return View(list);

        }

        /// <summary>
        /// About Page Action
        /// </summary>
        /// <returns>Index View</returns>
        public ActionResult About()
        {
            return View();
        }

        /// <summary>
        /// Contact Page Action
        /// </summary>
        /// <returns>Contact View</returns>
        public ActionResult Contact()
        {
            return View();
        }

        /// <summary>
        /// Book Details
        /// </summary>
        /// <param name="BookID">Book ID to View</param>
        /// <returns>Book Details View</returns>
        public async System.Threading.Tasks.Task<ActionResult> Details(string BookID)
        {
            var link = "Book/Search?Field=2&Search=" + BookID;
            var list = await Utility.GetApi<List<BookModel>>(link);
            return View(list[0]);
        }

        /// <summary>
        /// Search Page
        /// </summary>
        /// <returns>Search View</returns>
        public ActionResult Search()
        {
            return View();
        }

        /// <summary>
        /// Search Results Submit Action
        /// </summary>
        /// <param name="Value">Search Value</param>
        /// <param name="Field">Search Field</param>
        /// <returns>Search Results View</returns>
        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult> SearchResults(string Value, int Field)
        {
            var link = "Book/Search?Field=" + Field.ToString() + "&Search=" + Value;
            var list = await Utility.GetApi<List<BookModel>>(link);
            return View(list);
        }

        /// <summary>
        /// Demand Accepted View Action
        /// </summary>
        /// <param name="ID">Book ID</param>
        /// <param name="Username">Username that Demanded the book</param>
        /// <returns>Demand View</returns>
        public async System.Threading.Tasks.Task<ActionResult> Demand(string ID, string Username)
        {
            var link = "Demands/Create?ID=" + ID + "&Username=" + Username;
            var check = await Utility.GetApi<bool>(link);
            link = "Book/Search?Field=2&Search=" + ID;
            var list = await Utility.GetApi<List<BookModel>>(link);
            return View(list[0]);
        }

        /// <summary>
        /// User Details
        /// </summary>
        /// <returns>User View</returns>
        public new async System.Threading.Tasks.Task<ActionResult> User()
        {
            var link = "User/Demands?&Username=" + @Request.Cookies["username"].Value;
            var list = await Utility.GetApi<List<DemandModel>>(link);
            return View(list);
        }
    }
}
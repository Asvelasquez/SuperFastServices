using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApiApplication.Controllers{
    /// <summary>
    /// Este metodo nos permite acceder a HomeController
    /// </summary>
    public class HomeController : Controller{
        /// <summary>
        /// Este metodo nos permite acceder a Index
        /// </summary>
        public ActionResult Index(){

            ViewBag.Title = "Home Page";
            return View();
        }
    }
}

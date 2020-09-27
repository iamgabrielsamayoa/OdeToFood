using OdeToFoo.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFoo.Web.Controllers
{
    public class GreetingController : Controller
    {
        // GET: Greeting
        public ActionResult Index(string name)
        {
            var model = new GreetingViewModel();
            model.Name = name ?? "no name";
            model.Message = ConfigurationManager.AppSettings["message"];
            return View(model);
        }
    }
}

//There are 2 types of controllers, Controller, which is optimized to build web applications using HTTP Requests
//The other type is web API Controller, is to build API's instead of using a browser its for customers
//working with c# etc it uses  JSON, XML to respond requests
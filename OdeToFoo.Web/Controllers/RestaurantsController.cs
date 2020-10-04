using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFoo.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData db;

        public RestaurantsController(IRestaurantData db)
        {
            this.db = db;
        }

        // GET: Restaurants
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = db.Get(id);

            if (model == null)
            {
                return View("NotFound");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //We validate the information and send it using model binding 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            
           

           if (ModelState.IsValid)
            {
                db.Add(restaurant);
                //We redirect to the details of the restaurant created
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            
            
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var model = db.Get(Id);
            if(model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if(ModelState.IsValid)
            {
                db.Update(restaurant);
                TempData["Message"] = "You have updated the restaurant Successfully!";
                return RedirectToAction("Details", new { id = restaurant.Id });
            }

            return View(restaurant);
        }

        //Delete Starts here
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);

            if(model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //FormCollection its there just to have overload
        public ActionResult Delete(int id, FormCollection form)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }

    }
}

//LOW LEVEL VALIDATION FIELDS FOR TEXT
//if(string.IsNullOrEmpty(restaurant.Name))
//            {
//                ModelState.AddModelError(nameof(restaurant.Name), "The name is required");
//            }
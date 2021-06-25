using RestaurantRaterMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantRaterMVC.Controllers
{
    public class RestaurantController : Controller
    {

        private RestaurantDbContext _db = new RestaurantDbContext();


        // GET: Restaurant
        public ActionResult Index()
        {
            return View(_db.Restaurants.ToList());
        }//end of method Index

        //Get: Restaurant/Create
        public ActionResult Create()
        {
            return View();
        }//end of method Create


        //POST: Restaurant/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            if(ModelState.IsValid)
            {
                _db.Restaurants.Add(restaurant);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            //only get here is modelState is invalid
            return View(restaurant);

        }//end of method Create

        //GET: Restaurant/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }//end of if id is null
            Restaurant restaurant = _db.Restaurants.Find(id);
            if(restaurant==null)
            {
                return HttpNotFound();
            }//end of if restaurant is null
            
            //only gets here if id is not null and restaurant is returned.
            return View(restaurant);


        }//end of method Delete

        //POST: Restaurant/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Restaurant restaurant = _db.Restaurants.Find(id);
            _db.Restaurants.Remove(restaurant);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }//end of method Delete

        //GET: Restaurant/Edit/{id}
        public ActionResult Edit(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }//end of if id is null
            Restaurant restaurant = _db.Restaurants.Find(id);
            if(restaurant ==null)
            {
                return HttpNotFound();
            }

            return View(restaurant);

        }//end of method Edit

        //POST: Restaurant/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if(ModelState.IsValid)
            {
                _db.Entry(restaurant).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }//end of if model is valid

            return View(restaurant);

        }//end of method edit

        //GET: Restaurant/Details/{id}
        public ActionResult Details(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }//end of if null
            Restaurant restaurant = _db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);

        }//end of method Details

    }//end of class RestaurantController
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Product.Models;

namespace Product.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Product
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var products = from p in db.Products
                               orderby p.Id
                               select p;
                return View(products);
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
        }
    

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var products = db.Products.Single(p => p.Id == id);
            return View(products);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Products prod)
        {
            try
            {
                // TODO: Add insert logic here
                db.Products.Add(prod);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var products = db.Products.Single(p => p.Id == id);
            return View(products);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var products = db.Products.Single(p => p.Id == id);
                if(TryUpdateModel(products))
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(products);
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var products = db.Products.Single(p => p.Id == id);
            return View(products);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Products prod)
        {
            try
            {
                // TODO: Add delete logic here
                var products = db.Products.Single(p => p.Id == id);
                if (products != null)
                {
                    db.Products.Remove(products);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(products);
               
            }
            catch
            {
                return View();
            }
        }
    }
}

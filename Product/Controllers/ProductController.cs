// <copyright file="ProductController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Product.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using Product.Models;
    using Product.ViewModels;

    /// <summary>
    /// Products.
    /// </summary>
    [Authorize]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// Get products.
        /// </summary>
        /// <returns>return all products.</returns>
        //[AcceptVerbs(HttpVerbs.Get)]
        //public ActionResult Index()
        //{
        //    ApplicationDbContext db = new ApplicationDbContext();
        //    List<ProductViewModel> productList = new List<ProductViewModel>();
        //    var prodList = (from cust in db.Customers
        //                    join prod in db.Products on cust.CustomerID equals prod.CustomerID
        //                    select new
        //                    {
        //                        prod.Id,
        //                        cust.CompanyName,
        //                        prod.Name,
        //                        prod.Price,
        //                        prod.AddedDate
        //                    }).ToList();
        //    foreach (var item in prodList)
        //    {
        //        ProductViewModel prod = new ProductViewModel
        //        {
        //            Id = item.Id,
        //            CompanyName = item.CompanyName,
        //            Name = item.Name,
        //            Price = item.Price,
        //            AddedDate = item.AddedDate
        //        };
        //        productList.Add(prod);
        //    }
        //    Console.WriteLine(productList);
        //    return View(productList);
        //}
        public ActionResult Index()
        {
            var products = db.Products.Include(c => c.Customers).ToList();
            return View(products);
        }

        public ActionResult Details(int id)
        {
            var products = db.Products.Include(c => c.Customers).SingleOrDefault(c => c.Id == id);
            return View(products);
        }

        /// <summary>
        /// GET: Product/Create.
        /// </summary>
        /// <returns>create view.</returns>
        public ActionResult Create()
        {
            return this.View();
        }

        /// <summary>
        /// POST: Product/Create.
        /// </summary>
        /// <param name="prod">create id.</param>
        /// <returns>return create view.</returns>
        [HttpPost]
        public ActionResult Create(Products prod)
        {
            db.Products.Add(prod);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        ///  Post Product/EditProduct.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>return editproduct.</returns>
        [HttpPost]
        public ActionResult EditProduct(int id)
        {
            var products = this.db.Products.Include(c => c.Customers).FirstOrDefault(p => p.Id == id);
            if (this.TryUpdateModel(products))
            {
                this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.HttpNotFound();
        }

        /// <summary>
        /// GET: Product/Edit/5.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>return edit post view.</returns>
        public ActionResult Edit(int id)
        {
            var products = db.Products.Include(c => c.Customers).FirstOrDefault(p => p.Id == id);
            return this.View(products);
        }

        /// <summary>
        ///  POST: Product/Edit/5.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="collection">products.</param>
        /// <returns> edit view for post method.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var products = db.Products.Include(c => c.Customers).FirstOrDefault(p => p.Id == id);
                if (this.TryUpdateModel(products))
                {
                    this.db.SaveChanges();
                    return this.RedirectToAction("Index");
                }

                return this.View(products);
            }
            catch
            {
                return this.View();
            }
        }

        /// <summary>
        /// DeleteByPost delete function for directly delete.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Index View.</returns>
        [HttpPost]
        public ActionResult DeleteByPost(int id)
        {
            Products prod = this.db.Products.Find(id);
            this.db.Products.Remove(prod);
            this.db.SaveChanges();
            return this.RedirectToAction("Index");
        }

        /// <summary>
        /// Delete get method.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Index View.</returns>
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Products prod = this.db.Products.Find(id);
            if (prod == null)
            {
                return this.HttpNotFound();
            }

            return this.View(prod);
        }

        /// <summary>
        /// Delete Post Method.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="prod">Products.</param>
        /// <returns>Index View.</returns>
        [HttpPost]
        public ActionResult Delete(int id, Products prod)
        {
            try
            {
                // TODO: Add update logic here
                this.db.Products.Remove(prod);
                this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }
            catch
            {
                return this.View();
            }
        }
    }
}

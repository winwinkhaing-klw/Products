using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;
using Product.Models;

namespace Product.Controllers
{
    public class DemoController : Controller
    {
        // Creating instance of DatabaseContext class
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            Response.AddHeader("Refresh", "5");
            return RedirectToAction("ShowGrid", "Demo");
        }

        // GET: Demo
        public ActionResult ShowGrid()
        {
            return View();
        }

        // Edit View for customers
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            try
            {
                var customers = (from customer in db.Customers
                                 where customer.CustomerID == id
                                 select customer).FirstOrDefault();

                return View(customers);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, Customers customer)
        {
            var customers = db.Customers.Find(id);
            if (TryUpdateModel(customers))
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customers);
        }

        public JsonResult DeleteCustomer(int id)
        {
            var customers = db.Customers.Find(id);
            if (id == 0)
                return Json(data: "Not Delete", behavior: JsonRequestBehavior.AllowGet);
            db.Customers.Remove(customers);
            db.SaveChanges();
            return Json(data: "Deleted", behavior: JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateCustomer(Customers customers)
        {
            db.Customers.Add(customers);
            db.SaveChanges();
            Console.WriteLine(customers);
            Response.AddHeader("Refresh", "5");
            return Json(data: "Success", behavior: JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id)
        {
            var customers = db.Customers.Find(id);
            return View(customers);
        }

        [HttpPost]
        public ActionResult EditCustomer(int id)
        {
            var customers = db.Customers.Find(id);
            if (TryUpdateModel(customers))
            {
                db.SaveChanges();
                return Json(data: "Success", behavior: JsonRequestBehavior.AllowGet);
            }

            return RedirectToAction("Index");
        }

        public ActionResult LoadData()
        {
            try
            {
                var draw = Request.Form.GetValues("draw").FirstOrDefault();
                var start = Request.Form.GetValues("start").FirstOrDefault();
                var length = Request.Form.GetValues("length").FirstOrDefault();
                var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
                var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
                var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();

                // Paging Size (10,20,50,100)
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                // Getting all Customer data
                var customerData = from tempcustomer in db.Customers
                                   select tempcustomer;

                // Sorting
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDir);
                }

                // Search
                if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.CompanyName == searchValue || m.Country == searchValue);
                }

                // total number of rows count
                recordsTotal = customerData.Count();

                // Paging
                var data = customerData.Skip(skip).Take(pageSize).ToList();

                // Returning Json Data
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
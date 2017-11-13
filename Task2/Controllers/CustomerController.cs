using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Task2.Models;

namespace Task2.Controllers
{

    public class CustomerController : Controller
    {
        private CContext db = new CContext();

        // GET: Customer
        public ActionResult Index()
        {
            ViewData["user"] = db.Customers.ToList();
            return View();
        }


        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer cust = db.Customers.Find(id);
            if (cust == null)
            {
                return HttpNotFound();
            }
            return View(cust);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            CContext db = new CContext();
            ViewData["users"] = db.Customers.ToList();
            ViewBag.CountryList = db.CCountries;

            var model = new Customer();
            return View(model);
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public ActionResult Create(Customer custmr)
        {
            var act = from p in db.Customers
                      where
                 p.Email == custmr.Email
                      select p;


            if (string.IsNullOrEmpty(custmr.Firstname))
            {
                ModelState.AddModelError("first name", "First name is required");
            }
            if (string.IsNullOrEmpty(custmr.Lastname))
            {
                ModelState.AddModelError("Lastname ", "Lastname  is required");
            }
            if (string.IsNullOrEmpty(custmr.Pincode))
            {
                ModelState.AddModelError("Pincode ", "Pincode  is required");
            }
            if (string.IsNullOrEmpty(custmr.Contact))
            {
                ModelState.AddModelError("Contact ", "Contact  is required");
            }
            if (string.IsNullOrEmpty(custmr.Address))
            {
                ModelState.AddModelError("Address ", "Address  is required");
            }
            if (string.IsNullOrEmpty(custmr.Country))
            {
                ModelState.AddModelError("Country ", "Country  is required");
            }
            if (string.IsNullOrEmpty(custmr.State))
            {
                ModelState.AddModelError("State ", "State  is required");
            }
            if (string.IsNullOrEmpty(custmr.City))
            {
                ModelState.AddModelError("City ", "City  is required");
            }
            if (string.IsNullOrEmpty(custmr.Email))
            {
                ModelState.AddModelError("Email ", "Email  is required");
            }


            if (act.FirstOrDefault() != null)
            {
                ModelState.AddModelError("Email", "Email already exist");
            }
            if (ModelState.IsValid)

            {
                try
                {
                    db.Customers.Add(custmr);
                    db.SaveChanges();
                    return RedirectToAction("Create");
                }
                catch
                {
                    return View();
                }


            }


            ViewBag.CountryList = db.CCountries;
            ViewData["users"] = db.Customers.ToList();
            return View(custmr);

        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer cust = db.Customers.Find(id);
            if (cust == null)
            {
                return HttpNotFound();
            }
            return View(cust);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Firstname,Lastname,Email,Contact,Address,Country,State,City,Pincode")] Customer custmr)
        {
            if (ModelState.IsValid)
            {
                db.Entry(custmr).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            return View(custmr);
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer cust = db.Customers.Find(id);
            if (cust == null)
            {
                return HttpNotFound();
            }
            return View(cust);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer cust = db.Customers.Find(id);
            db.Customers.Remove(cust);
            db.SaveChanges();
            return RedirectToAction("Create");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult FillCity(int state)
        {
            CContext db = new CContext();

            var cities = db.CStates.Where(c => c.CountryId == state);
            return Json(cities, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DoesUserEmailExist(string email)
        {

            var user = Membership.GetUserNameByEmail(email);

            return Json(user == null);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Customer custmr, Customer upload, HttpPostedFileBase file)
        //{
        //    if (ModelState.IsValid)
        //    {


        //        if (file.ContentLength > 0)
        //        {
        //            var fileName = Path.GetFileName(file.FileName);
        //            var guid = Guid.NewGuid().ToString();
        //            var path = Path.Combine(Server.MapPath("~/images"), guid + fileName);
        //            file.SaveAs(path);
        //            string fl = path.Substring(path.LastIndexOf("\\"));
        //            string[] split = fl.Split('\\');
        //            string newpath = split[1];
        //            string imagepath = "~/images/" + newpath;
        //            upload.length = imagepath;
        //            db.Customers.Add(upload);
        //            db.SaveChanges();
        //        }
        //        TempData["Success"] = "Upload successful";


        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.Countries = db.CCountries;

        //    return View(custmr);
        //}

    }
}
﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShoppingMobile.Models.ModelDB;

namespace ShoppingMobile.Controllers
{
    [Authorize]
    public class HangSanXuatsController : Controller
    {
        private DienThoaiDBEntities db = new DienThoaiDBEntities();

        // GET: HangSanXuats
        public ActionResult Index()
        {
            return View(db.HangSanXuats.ToList());
        }

        // GET: HangSanXuats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangSanXuat hangSanXuat = db.HangSanXuats.Find(id);
            if (hangSanXuat == null)
            {
                return HttpNotFound();
            }
            return View(hangSanXuat);
        }

        // GET: HangSanXuats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HangSanXuats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHSX,TenHSX")] HangSanXuat hangSanXuat)
        {
            if (ModelState.IsValid)
            {
                db.HangSanXuats.Add(hangSanXuat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hangSanXuat);
        }

        // GET: HangSanXuats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangSanXuat hangSanXuat = db.HangSanXuats.Find(id);
            if (hangSanXuat == null)
            {
                return HttpNotFound();
            }
            return View(hangSanXuat);
        }

        // POST: HangSanXuats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHSX,TenHSX")] HangSanXuat hangSanXuat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hangSanXuat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hangSanXuat);
        }

        // GET: HangSanXuats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangSanXuat hangSanXuat = db.HangSanXuats.Find(id);
            if (hangSanXuat == null)
            {
                return HttpNotFound();
            }
            return View(hangSanXuat);
        }

        // POST: HangSanXuats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HangSanXuat hangSanXuat = db.HangSanXuats.Find(id);
            db.HangSanXuats.Remove(hangSanXuat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

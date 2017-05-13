using System;
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
    public class DDHsController : Controller
    {
        private DienThoaiDBEntities db = new DienThoaiDBEntities();

        // GET: DDHs
        public ActionResult Index()
        {
            var dDHs = db.DDHs.Include(d => d.KhachHang);
            return View(dDHs.ToList());
        }

        // GET: DDHs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DDH dDH = db.DDHs.Find(id);
            if (dDH == null)
            {
                return HttpNotFound();
            }
            return View(dDH);
        }

        // GET: DDHs/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH");
            return View();
        }

        // POST: DDHs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDDH,MaKH,TongTien,GhiChu,DiaChiNhan,NgayDH")] DDH dDH)
        {
            if (ModelState.IsValid)
            {
                db.DDHs.Add(dDH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH", dDH.MaKH);
            return View(dDH);
        }

        // GET: DDHs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DDH dDH = db.DDHs.Find(id);
            if (dDH == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH", dDH.MaKH);
            return View(dDH);
        }

        // POST: DDHs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDDH,MaKH,TongTien,GhiChu,DiaChiNhan,NgayDH")] DDH dDH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dDH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH", dDH.MaKH);
            return View(dDH);
        }

        // GET: DDHs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DDH dDH = db.DDHs.Find(id);
            if (dDH == null)
            {
                return HttpNotFound();
            }
            return View(dDH);
        }

        // POST: DDHs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DDH dDH = db.DDHs.Find(id);
            db.DDHs.Remove(dDH);
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

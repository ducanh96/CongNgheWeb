using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShoppingMobile.Models.ModelDB;

namespace ShoppingMobile.Areas.Admin.Controllers
{
    public class DDHsController : Controller
    {
        private DienThoaiDBEntities db = new DienThoaiDBEntities();

        // GET: Admin/DDHs
        public ActionResult Index()
        {
            var dDHs = db.DDHs.Include(d => d.KhachHang);
            return View(dDHs.ToList());
        }

        // GET: Admin/DDHs/Details/5
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
            var listDienThoai = db.DDHCTs.Where(x => x.MaDDH == id).Include(X => X.DienThoai).ToList();
            ViewBag.DDHCT = listDienThoai;
            return View(dDH);
        }

        // GET: Admin/DDHs/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "TenKH");
            return View();
        }

        // POST: Admin/DDHs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDDH,MaKH,TenNguoiNhan,DiaChiNhan,NgayDH,TrangThai,SDT")] DDH dDH)
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

        // GET: Admin/DDHs/Edit/5
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

        // POST: Admin/DDHs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDDH,MaKH,TenNguoiNhan,DiaChiNhan,NgayDH,TrangThai,SDT")] DDH dDH)
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

        // GET: Admin/DDHs/Delete/5
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

        // POST: Admin/DDHs/Delete/5
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

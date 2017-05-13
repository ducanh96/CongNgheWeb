using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShoppingMobile.Models.ModelDB;
using System.IO;

namespace ShoppingMobile.Controllers
{
    [Authorize]
    public class DienThoaisController : Controller
    {
        private DienThoaiDBEntities db = new DienThoaiDBEntities();
       
        // GET: DienThoais
        public ActionResult Index()
        {
           
            return View(db.DienThoais.ToList());
        }

        // GET: DienThoais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DienThoai dienThoai = db.DienThoais.Find(id);
            if (dienThoai == null)
            {
                return HttpNotFound();
            }
            return View(dienThoai);
        }

        // GET: DienThoais/Create
        public ActionResult Create()
        {
            ViewBag.MaHDT = new SelectList(db.HangSanXuats, "MaHSX", "TenHSX");
            ViewBag.MaDT = new SelectList(db.Images, "MaDT", "Image_phu1");
            return View();
        }

        // POST: DienThoais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "MaDT,TenDienThoai,Gia,RAM_ROM,Camera,TrangThai,SoLuong,ManHinh,TSKT,AnhDT,MaHDT")] DienThoai dienThoai,HttpPostedFileBase uploadFile)
        {
            if (ModelState.IsValid)
            {
                if(uploadFile!=null && uploadFile.ContentLength >0)
                {
                    string fileName = Path.GetFileName(uploadFile.FileName);
                    string path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    uploadFile.SaveAs(path);
                    dienThoai.AnhDT = "/Images/" + fileName;
                }
                dienThoai.DateCreate = DateTime.Now;
                dienThoai.DateModified = DateTime.Now;
                db.DienThoais.Add(dienThoai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHDT = new SelectList(db.HangSanXuats, "MaHSX", "TenHSX", dienThoai.MaHDT);
            ViewBag.MaDT = new SelectList(db.Images, "MaDT", "Image_phu1", dienThoai.MaDT);
            return View(dienThoai);
        }

        // GET: DienThoais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DienThoai dienThoai = db.DienThoais.Find(id);
            if (dienThoai == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHDT = new SelectList(db.HangSanXuats, "MaHSX", "TenHSX", dienThoai.MaHDT);
            ViewBag.MaDT = new SelectList(db.Images, "MaDT", "Image_phu1", dienThoai.MaDT);
            return View(dienThoai);
        }

        // POST: DienThoais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "MaDT,TenDienThoai,Gia,RAM_ROM,Camera,TrangThai,SoLuong,ManHinh,TSKT,AnhDT,MaHDT")] DienThoai dienThoai,HttpPostedFileBase uploadFile)
        {
            if (ModelState.IsValid)
            {
                var dt = db.DienThoais.Find(dienThoai.MaDT);
                if (uploadFile!=null && uploadFile.ContentLength >0)
                {
                    string fileName = Path.GetFileName(uploadFile.FileName);
                    string path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    uploadFile.SaveAs(path);
                    dienThoai.AnhDT = "/Images/" + fileName;
                    dt.AnhDT = dienThoai.AnhDT;
                }
                dt.TenDienThoai = dienThoai.TenDienThoai;
                dt.Gia = dienThoai.Gia;
                dt.RAM_ROM = dienThoai.RAM_ROM;
                dt.Camera = dienThoai.Camera;
                dt.TrangThai = dienThoai.TrangThai;
                dt.SoLuong = dienThoai.SoLuong;
                dt.ManHinh = dienThoai.ManHinh;
                dt.TSKT = dienThoai.TSKT;
                dt.MaHDT = dienThoai.MaHDT;
                dt.DateModified = DateTime.Now;
                db.Entry(dt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHDT = new SelectList(db.HangSanXuats, "MaHSX", "TenHSX", dienThoai.MaHDT);
            ViewBag.MaDT = new SelectList(db.Images, "MaDT", "Image_phu1", dienThoai.MaDT);
            return View(dienThoai);
        }

        // GET: DienThoais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DienThoai dienThoai = db.DienThoais.Find(id);
            if (dienThoai == null)
            {
                return HttpNotFound();
            }
            return View(dienThoai);
        }

        // POST: DienThoais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DienThoai dienThoai = db.DienThoais.Find(id);
            db.DienThoais.Remove(dienThoai);
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

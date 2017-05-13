using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingMobile.Models.Manager;
using ShoppingMobile.Models.ModelDB;

namespace ShoppingMobile.Controllers
{
    public class ShoppingController : Controller
    {
        
        public static ManagerEntities manager = new ManagerEntities();
        public DienThoaiDBEntities db = new DienThoaiDBEntities();
        // GET: Shopping
        //Trang danh sach dien thoai (Shop page)
        public ActionResult Index()
        {
            var list = manager.GetListDT();
            return View(list);
        }

        public ActionResult Details(int? id)
        {
            var DT = manager.GetDienThoai(id);
            string tenHang =  manager.GetHangSanXuat(id).TenHSX;
            ViewBag.TenHang = tenHang;
            return View(DT);
        }

        public ActionResult SingleProduct()
        {

            return View();
        }
        //Trang chu
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult HangSanXuat()
        {

            return PartialView();
        }

        public ActionResult Category(int? id)
        {
            ViewBag.listHSX = db.HangSanXuats.ToList();
            IEnumerable<DienThoai> list;
           if(id == null)
            {
                list = db.DienThoais.ToList();
            }
           else
            {
                list = db.DienThoais.Where(p => p.MaHDT == id).ToList();
            }
            return View(list);
        }
        //xuat hien khi goi category luc dau
        public ActionResult ListDT_Partial()
        {
            return View(manager.GetListDT());
        }

        public ActionResult DSDT_Category(int? id)
        {
            ViewBag.listHXS = manager.GetListHangSanXuat();
            var kq = manager.GetListDT_Category(id);
            return View(kq);
        }

       
    }
}
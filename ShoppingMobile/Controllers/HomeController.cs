using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingMobile.Models.ModelDB;
namespace ShoppingMobile.Controllers
{
    public class HomeController : Controller
    {
        DienThoaiDBEntities db = new DienThoaiDBEntities();
        public ActionResult Index()
        {
            return View(db.DienThoais.ToList());
        }

        public ActionResult Login()
        {
            if (Session["TaiKhoan"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Email, string Password)
        {
            var khachhang = db.KhachHangs.Where(c => c.Email == Email).SingleOrDefault();
            if (khachhang != null)
            {
                if (khachhang.Password == Password)
                {
                    //dang nhap thanh cong
                    Session["TaiKhoan"] = khachhang.MaKH;
                    return RedirectToAction("ThanhToan", "GioHang");
                }
            }
            return View();
        }

    }
}
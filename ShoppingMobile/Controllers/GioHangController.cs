using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingMobile.Models.ModelDB;
using ShoppingMobile.Models.Bean;


namespace WebProject.Controllers
{
    public class GioHangController : Controller
    {
        DienThoaiDBEntities db = new DienThoaiDBEntities();
        // giỏ hàng mặc định, nếu session = null thì hiện không có hàng trong giỏ, nếu có thì trả lại list các sản phẩm
        public ActionResult Index()
        {
            ViewBag.Title = "Giỏ hàng";
          ShoppingCart model = new ShoppingCart();
            model = (ShoppingCart)Session["Cart"];
            return View(model);
        }

        // thêm vào giỏ hàng 1 sản phẩm có id = id của sản phẩm
        public ActionResult ThemVaoGioHang(int id)
        {
            var P = db.DienThoais.Single(s => s.MaDT == id);
            if (P != null)
            {
                ShoppingCart objCart = (ShoppingCart)Session["Cart"];
               
                if (objCart == null)
                {
                    objCart = new ShoppingCart();
                }
                ItemCart item = new ItemCart()
                {
                    TenDienThoai = P.TenDienThoai,
                    MaDT = P.MaDT,
                    Gia = P.Gia,
                    SoLuong = 1,
                    TongTien = P.Gia * 1
                    
                   
                };
                objCart.AddItem(item);
                Session["Cart"] = objCart;
                return RedirectToAction("Index", "GioHang");
            }
            return RedirectToAction("Index", "GioHang");
        }

        // cập nhật giỏ hàng theo loại sản phẩm và số lượng
        public ActionResult UpdateQuantity(int proID, int quantity)
        {

            ShoppingCart objCart = (ShoppingCart)Session["Cart"];
            if (objCart != null)
            {
                objCart.UpdateQuantity(proID, quantity);
                Session["Cart"] = objCart;
            }
            return RedirectToAction("Index");
        }

        // xóa sản phẩm có id trong giỏ hàng đã có sẵn
        public ActionResult XoaSanPham(int id)
        {
            ShoppingCart objCart = (ShoppingCart)Session["Cart"];
            if (objCart != null)
            {
                objCart.RemoveFromCart(id);
                Session["Cart"] = objCart;
            }
            return RedirectToAction("Index");
        }

        //Thanh Toan
        public ActionResult ThanhToan()
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("Login", "Home");
            }
            
            ShoppingCart model = (ShoppingCart)Session["Cart"];

            int custId = int.Parse(Session["TaiKhoan"].ToString());
            var customer = db.KhachHangs.Find(custId);
            ViewBag.customer = customer;
            return View(model);
        }

        [HttpPost]
        public ActionResult ThanhToan(string DiaChiNhan, string SDT,string TenNguoiNhan)
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("Login", "Home");
            }
            int custId = int.Parse(Session["TaiKhoan"].ToString());
            var customer = db.KhachHangs.Find(custId);
            DDH order = new DDH();
            order.MaKH = custId;
            order.NgayDH = DateTime.Now;
            order.TrangThai = 0;
            if (TenNguoiNhan == null || TenNguoiNhan == "")
            {
                order.TenNguoiNhan = customer.TenKH;
            }
            else
            {
                order.TenNguoiNhan =TenNguoiNhan;
            }
            if (DiaChiNhan == null || DiaChiNhan == "")
            {
                order.DiaChiNhan = customer.DiaChi;
            }
            else
            {
                order.DiaChiNhan = DiaChiNhan;
            }
            if (SDT == null || SDT == "")
            {
                order.SDT = customer.SDT;
            }
            else
            {
                order.SDT = SDT;
            }

            //luu vao bang order
            db.DDHs.Add(order);


            ShoppingCart model = (ShoppingCart)Session["Cart"];
            foreach (var item in model.ListItem)
            {
                DDHCT orderDetail = new DDHCT();
                orderDetail.MaDDH = order.MaDDH;
                orderDetail.MaDT = item.MaDT;
                orderDetail.SoLuong = item.SoLuong;
                orderDetail.DonGia = item.Gia;
                db.DDHCTs.Add(orderDetail);
            }
            db.SaveChanges();
            Session["Cart"] = null;
            TempData["msg"] = "Thành công";
            return RedirectToAction("Index", "GioHang");
        }

        public ActionResult ThanhToanThanhCong()        {

            return View();
        }
    }
}
using ShoppingMobile.Models.Manager;
using ShoppingMobile.Models.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ShoppingMobile.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
       public static ManagerEntities manager = new ManagerEntities();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Table_User user)
        {
           
                if (manager.IsExitstUserName(user.UserName))
                {
                    if (user.UserPassword == manager.GetPassword(user.UserName))
                    {
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    return RedirectToAction("Index", "Dienthoais");
                }
                    else
                    {
                        ModelState.AddModelError("errorPass", "Nhập sai Password");
                    }
                }
                else
                {
                    ModelState.AddModelError("errorPass", "Không tồn tại tài khoản");
                }

          
           
            return View(user);
        }
        
        public ActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Register(Table_User user)
        {
           if(ModelState.IsValid)
            {
                if(manager.IsExitstUserName(user.UserName))
                {
                    ModelState.AddModelError(user.UserName, "Tên tài khoản đã tồn tại");
                }
                else
                {
                    if (manager.AddUser(user))
                    {
                        FormsAuthentication.SetAuthCookie(user.UserName, false);
                        return RedirectToAction("Index", "Dienthoais");
                    }
                  

                }
            }
            return View(user);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
       
     
       
    }
}
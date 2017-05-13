using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingMobile.Models.ModelDB;

namespace ShoppingMobile.Models.Manager
{
    public class ManagerEntities
    {
        //lay danh sach dien thoai
        public List<DienThoai> GetListDT()
        {
            using (DienThoaiDBEntities db = new DienThoaiDBEntities())
            {
                return db.DienThoais.ToList();
            }
        }
        //lay dien thoai vs ma id
        public DienThoai GetDienThoai(int? id)
        {
            if(id != null)
            {
                using (DienThoaiDBEntities db = new DienThoaiDBEntities())
                {
                    return db.DienThoais.Find(id);
                }
            }
            else
            {
                return null;
            }
           
        }

        //lay hang San Xuat cua  Dien thoai 
        public HangSanXuat GetHangSanXuat(int? id)
        {
            if(id != null)
            {
                using (DienThoaiDBEntities db = new DienThoaiDBEntities())
                {
                    return db.DienThoais.Find(id).HangSanXuat;
                }

            }
            else
            {
                return null;
            }
           
        }

        //lay danh sach hang san xuat
        public List<HangSanXuat> GetListHangSanXuat()
        {
            using (DienThoaiDBEntities db = new DienThoaiDBEntities())
            {
                return db.HangSanXuats.ToList();
            }
        }


        #region Lay danh sach dien thoai theo ma nha san xuat

        public List<DienThoai> GetListDT_Category(int? id) //id la ma nha san xuat
        {
            if (id != null)
            {
                using (DienThoaiDBEntities db = new DienThoaiDBEntities())
                {
                    return db.DienThoais.Where(x => x.MaHDT == id).ToList();
                }
            }
            else
                return null;
        }

        #endregion

        #region kiem tra ton tai cua tai khoan
        public bool IsExitstUserName(string userName)
        {
            using (DienThoaiDBEntities db = new DienThoaiDBEntities())
            {
                return db.Table_User.Where(x => x.UserName == userName).Any();
            }
        }

        #endregion

        #region Lay mat khau cua tai khoan

        public string GetPassword(string userName)
        {
            using (DienThoaiDBEntities db = new DienThoaiDBEntities())
            {
                return db.Table_User.Where(x => x.UserName == userName).FirstOrDefault().UserPassword;
            }
        }
        #endregion

        #region Thêm mới người dùng

        public bool AddUser(Table_User user)
        {
          
                using (DienThoaiDBEntities db = new DienThoaiDBEntities())
            {
               
                    using (var trans = db.Database.BeginTransaction())
                    {
                    try
                    {
                        db.Table_User.Add(user);
                        db.SaveChanges();
                        trans.Commit();
                        return true;
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
              

            }
           
           
        }

        #endregion
    }
}
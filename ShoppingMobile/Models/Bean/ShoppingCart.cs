using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingMobile.Models.Bean
{
    public class ShoppingCart
    {
        public List<ItemCart> ListItem = new List<ItemCart>();

        public void AddItem(ItemCart item) //them san pham vao gio hang
        {
            if ((ListItem.Where(n => n.MaDT == item.MaDT)).Any())
                {
                var myItem = ListItem.SingleOrDefault(n => n.MaDT == item.MaDT);
                myItem.SoLuong += item.SoLuong;
                myItem.TenDienThoai = item.TenDienThoai;
                myItem.MaDT = item.MaDT;
                myItem.TongTien += item.SoLuong * item.Gia;
               
            }
            else
            {
                ListItem.Add(item);
            }

           
        }

        //xoa san pham khoi gio hang

        public void XoaGioHang(ItemCart item)
        {
            var myItem = ListItem.SingleOrDefault(n => n.MaDT == item.MaDT);
            ListItem.Remove(myItem);

            
        }
        //update item trong gio hang
        public void CapNhapGioHang(ItemCart item) //them san pham vao gio hang
        {
            if ((ListItem.Where(n => n.MaDT == item.MaDT)).Any())
            {
                var myItem = ListItem.SingleOrDefault(n => n.MaDT == item.MaDT);
                myItem.SoLuong = item.SoLuong;


            }
            else
            {
                ListItem.Add(item);
            }


        }
        public bool UpdateQuantity(int lngProductSellID, int intQuantity)
        {
            ItemCart existsItem = ListItem.Where(x => x.MaDT == lngProductSellID).SingleOrDefault();
            if (existsItem != null)
            {
                existsItem.SoLuong = intQuantity;
                existsItem.TongTien = existsItem.SoLuong * existsItem.Gia ;
                return true;
            }
            return false;
           
        }
        public bool RemoveFromCart(int lngProductSellID)
        {
            ItemCart existsItem = ListItem.Where(x => x.MaDT == lngProductSellID).SingleOrDefault();
            if (existsItem != null)
            {
                ListItem.Remove(existsItem);
            }
            return true;
        }
    }
}
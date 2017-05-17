using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingMobile.Models.Bean;

namespace WebProject.Models
{
    public class ShoppingCart
    {
        public List<ItemCart> ListItem { get; set; }

        public ShoppingCart()
        {
            ListItem = new List<ItemCart>();
        }
        public void AddToCart(ItemCart item)
        {
            if ((ListItem.Where(s => s.MaDT == item.MaDT)).Any())
            {
                var myItem = ListItem.Single(s => s.MaDT == item.MaDT);
                myItem.SoLuong += item.SoLuong;
                myItem.Gia += item.SoLuong * item.SoLuong;
            }
            else
            {
                ListItem.Add(item);
            }
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
        public bool UpdateQuantity(int lngProductSellID, int intQuantity)
        {
            ItemCart existsItem = ListItem.Where(x => x.MaDT == lngProductSellID).SingleOrDefault();
            if (existsItem != null)
            {
                existsItem.SoLuong = intQuantity;
                existsItem.Gia = existsItem.SoLuong * existsItem.SoLuong;
            }
            return true;
        }
        public bool EmptyCart()
        {
            ListItem.Clear();
            return true;
        }
    }
}
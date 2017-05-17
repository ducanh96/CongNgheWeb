using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingMobile.Models.Bean
{
    public class ItemCart
    {
        public int MaDT { get; set; }
        public string TenDienThoai { get; set; }
        public int SoLuong { get; set; }
        public double Gia { get; set; }
        public string AnhDT { get; set; }
        public double GetTotal()
        {
            return SoLuong * Gia;
        }
    }
}
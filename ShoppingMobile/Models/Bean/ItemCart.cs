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
        public Nullable<decimal> Gia { get; set; }
        public Nullable<int> SoLuong { get; set; }

        public string AnhDT { get; set; }

        public decimal? TongTien { get; set; }
        
    }
}
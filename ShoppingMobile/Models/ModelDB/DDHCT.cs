//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShoppingMobile.Models.ModelDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class DDHCT
    {
        public int MaDDH { get; set; }
        public int MaDT { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<decimal> DonGia { get; set; }
    
        public virtual DDH DDH { get; set; }
        public virtual DienThoai DienThoai { get; set; }
    }
}

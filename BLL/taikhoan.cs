//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BLL
{
    using System;
    using System.Collections.Generic;
    
    public partial class taikhoan
    {
        public string mataikhoan { get; set; }
        public string manguoidung { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public Nullable<bool> role { get; set; }
    
        public virtual nguoidung nguoidung { get; set; }
    }
}
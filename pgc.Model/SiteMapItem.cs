//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mrd.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class SiteMapItem
    {
        public long ID { get; set; }
        public long SiteMapCat_ID { get; set; }
        public string Title { get; set; }
        public int DispOrder { get; set; }
        public string NavigateUrl { get; set; }
        public bool IsBlank { get; set; }
        public bool IsVisible { get; set; }
    
        public virtual SiteMapCat SiteMapCat { get; set; }
    }
}

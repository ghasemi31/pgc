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
    
    public partial class News
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public string KeyWords { get; set; }
        public string NewsPicPath { get; set; }
        public string NewsPersianDate { get; set; }
        public System.DateTime NewsDate { get; set; }
        public int Status { get; set; }
        public long Gallery_ID { get; set; }
        public bool IsDisplayGallery { get; set; }
    }
}

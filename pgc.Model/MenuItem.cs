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
    
    public partial class MenuItem
    {
        public long ID { get; set; }
        public Nullable<long> MenuCategory_ID { get; set; }
        public long Feature_ID { get; set; }
        public string Title { get; set; }
        public string UIClass { get; set; }
        public string NavigateURL { get; set; }
        public string Target { get; set; }
        public float DisplayOrder { get; set; }
        public string RouteName { get; set; }
    
        public virtual Feature Feature { get; set; }
        public virtual MenuCategory MenuCategory { get; set; }
    }
}
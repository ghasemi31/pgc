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
    
    public partial class MenuCategory
    {
        public MenuCategory()
        {
            this.MenuItems = new HashSet<MenuItem>();
        }
    
        public long ID { get; set; }
        public string Title { get; set; }
        public string UIClass { get; set; }
        public float DisplayOrder { get; set; }
    
        public virtual ICollection<MenuItem> MenuItems { get; set; }
    }
}
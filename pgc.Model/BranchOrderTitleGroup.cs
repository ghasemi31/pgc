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
    
    public partial class BranchOrderTitleGroup
    {
        public BranchOrderTitleGroup()
        {
            this.BranchOrderTitles = new HashSet<BranchOrderTitle>();
        }
    
        public long ID { get; set; }
        public string Title { get; set; }
        public int DisplayOrder { get; set; }
    
        public virtual ICollection<BranchOrderTitle> BranchOrderTitles { get; set; }
    }
}
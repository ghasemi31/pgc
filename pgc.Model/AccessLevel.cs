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
    
    public partial class AccessLevel
    {
        public AccessLevel()
        {
            this.Features = new HashSet<Feature>();
            this.Users = new HashSet<User>();
            this.SystemEventActions = new HashSet<SystemEventAction>();
        }
    
        public long ID { get; set; }
        public int Role { get; set; }
        public string Title { get; set; }
    
        public virtual ICollection<Feature> Features { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<SystemEventAction> SystemEventActions { get; set; }
    }
}
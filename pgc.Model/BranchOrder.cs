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
    
    public partial class BranchOrder
    {
        public BranchOrder()
        {
            this.BranchLackOrders = new HashSet<BranchLackOrder>();
            this.BranchOrderDetails = new HashSet<BranchOrderDetail>();
        }
    
        public long ID { get; set; }
        public string BranchDescription { get; set; }
        public System.DateTime RegDate { get; set; }
        public string RegPersianDate { get; set; }
        public int Status { get; set; }
        public long Branch_ID { get; set; }
        public long TotalPrice { get; set; }
        public string OrderedPersianDate { get; set; }
        public string AdminDescription { get; set; }
        public Nullable<long> ShipmentStatus_ID { get; set; }
    
        public virtual ICollection<BranchLackOrder> BranchLackOrders { get; set; }
        public virtual BranchOrderShipmentState BranchOrderShipmentState { get; set; }
        public virtual ICollection<BranchOrderDetail> BranchOrderDetails { get; set; }
        public virtual Branch Branch { get; set; }
    }
}
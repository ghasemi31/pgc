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
    
    public partial class BranchTransaction
    {
        public long ID { get; set; }
        public string Description { get; set; }
        public long Branch_ID { get; set; }
        public long BranchCredit { get; set; }
        public long BranchDebt { get; set; }
        public int TransactionType { get; set; }
        public long TransactionType_ID { get; set; }
        public System.DateTime RegDate { get; set; }
        public string RegPersianDate { get; set; }
    
        public virtual Branch Branch { get; set; }
    }
}

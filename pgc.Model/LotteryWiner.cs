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
    
    public partial class LotteryWiner
    {
        public long ID { get; set; }
        public long LotteryID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public int Rank { get; set; }
        public string Description { get; set; }
    
        public virtual Lottery Lottery { get; set; }
    }
}

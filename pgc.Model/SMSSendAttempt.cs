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
    
    public partial class SMSSendAttempt
    {
        public SMSSendAttempt()
        {
            this.SentSMS = new HashSet<SentSMS>();
        }
    
        public long ID { get; set; }
        public int EventType { get; set; }
        public Nullable<long> OccuredEvent_ID { get; set; }
        public System.DateTime Date { get; set; }
        public string PersianDate { get; set; }
        public int Total_SucceedCount { get; set; }
        public int Total_FailedCount { get; set; }
        public int Total_SumCount { get; set; }
        public int Total_ErrorCount { get; set; }
        public int Total_UnknownCount { get; set; }
        public int MessageType { get; set; }
        public string Body { get; set; }
        public int SMSCount { get; set; }
        public int CharCount { get; set; }
        public string Recipients { get; set; }
    
        public virtual ICollection<SentSMS> SentSMS { get; set; }
    }
}

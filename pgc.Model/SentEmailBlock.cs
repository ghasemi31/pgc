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
    
    public partial class SentEmailBlock
    {
        public long ID { get; set; }
        public long EmailSentAttempt_ID { get; set; }
        public int Size { get; set; }
        public System.DateTime Date { get; set; }
        public string PersianDate { get; set; }
        public bool IsSent { get; set; }
        public string RecipientMailAddress { get; set; }
    
        public virtual EmailSendAttempt EmailSendAttempt { get; set; }
    }
}

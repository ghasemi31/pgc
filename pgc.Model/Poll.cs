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
    
    public partial class Poll
    {
        public Poll()
        {
            this.PollChoises = new HashSet<PollChoise>();
            this.PollResults = new HashSet<PollResult>();
        }
    
        public long ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string PollPersianDate { get; set; }
    
        public virtual ICollection<PollChoise> PollChoises { get; set; }
        public virtual ICollection<PollResult> PollResults { get; set; }
    }
}

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
    
    public partial class PollChoise
    {
        public PollChoise()
        {
            this.PollResults = new HashSet<PollResult>();
        }
    
        public long ID { get; set; }
        public long Poll_ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    
        public virtual Poll Poll { get; set; }
        public virtual ICollection<PollResult> PollResults { get; set; }
    }
}

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
    
    public partial class Option
    {
        public long ID { get; set; }
        public long OptionCategory_ID { get; set; }
        public Nullable<long> OptionLookup_ID { get; set; }
        public string Key { get; set; }
        public string Title { get; set; }
        public int Type { get; set; }
        public string Value { get; set; }
        public float DisplayOrder { get; set; }
    
        public virtual OptionCategory OptionCategory { get; set; }
        public virtual OptionLookup OptionLookup { get; set; }
    }
}

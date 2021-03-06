﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using pgc.Model.Enums;

namespace pgc.Model.Patterns
{
    [Serializable]
    public class OnlinePaymentListPattern : BasePattern
    {
        public OnlinePaymentListPattern()
        {
            PersianDate = new DateRangePattern();
            Amount = new NumericRangePattern();
        }

        public long Branch_ID { get; set; }
        public long Order_ID { get; set; }
        public OnlinePaymentStatus Status { get; set; }
        public DateRangePattern PersianDate { get; set; }
        public NumericRangePattern Amount { get; set; }
    }
}

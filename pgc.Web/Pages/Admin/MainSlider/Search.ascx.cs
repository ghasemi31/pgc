﻿using kFrameWork.UI;
using pgc.Model.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Admin_RandomImage_Search : BaseSearchControl<RandomImagePattern>
{
    public override RandomImagePattern Pattern
    {
        get
        {
            return new RandomImagePattern()
            {
                Title = txtTitle.Text,
            };
        }
        set
        {
            txtTitle.Text = value.Title;
        }
    }
}
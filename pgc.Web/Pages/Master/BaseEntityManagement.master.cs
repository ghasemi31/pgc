﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Master_BaseEntityManagement : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnInit(EventArgs e)
    {
        scmMain.EnablePartialRendering = kFrameWork.Business.OptionBusiness.GetBoolean(pgc.Model.Enums.OptionKey.ActiveAjax);
    }

}

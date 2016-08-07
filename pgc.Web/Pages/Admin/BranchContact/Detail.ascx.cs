﻿using kFrameWork.Enums;
using kFrameWork.UI;
using pgc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Admin_BranchContact_Detail : BaseDetailControl<BranchContact>
{
    public override BranchContact GetEntity(BranchContact Data, ManagementPageMode Mode)
    {
        if (Data == null)
            Data = new BranchContact();

        Data.IsRead = Convert.ToBoolean(chkIsRead.Checked);

        return Data;
    }

    public override void SetEntity(BranchContact Data, ManagementPageMode Mode)
    {
        lblPersianDate.Text = Data.PersianDate;
        lblName.Text = Data.FullName;
        lblEmail.Text = Data.Email;
        lblBody.Text = Data.Body;
        lblBranchName.Text = Data.BranchTitle;
        chkIsRead.Checked = Data.IsRead;
    }
}
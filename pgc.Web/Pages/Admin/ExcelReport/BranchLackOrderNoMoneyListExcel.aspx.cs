﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pgc.Model;
using pgc.Model.Enums;
using kFrameWork.Util;
using pgc.Business;
using pgc.Model.Patterns;
using System.Collections;
using System.Data;
using kFrameWork.UI;

public partial class Pages_Admin_ExcelReport_BranchLackOrderNoMoneyListExcel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //string filePath = HttpContext.Current.Server.MapPath("~/UserFiles/Report.xls");

            //BranchLackOrderPattern pattern = (BranchLackOrderPattern)Session["BranchLackPrintPattern"];
            //BranchLackOrderBusiness business = new BranchLackOrderBusiness();
            //IQueryable<BranchLackOrder> OrdersList = business.Search_SelectPrint(pattern);


            //DataTable table = new DataTable("Orders");

            //table.Columns.Add("ردیف");
            //table.Columns.Add("نام شعبه");
            //table.Columns.Add("کد کسری");
            //table.Columns.Add("کد درخواست");
            //table.Columns.Add("تاریخ درج");
            //table.Columns.Add("وضعیت");
            ////table.Columns.Add("مبلغ کسری");
            ////table.Columns.Add("مبلغ درخواست");
            //table.Columns.Add("توضیحات مدیر");
            //table.Columns.Add("توضیحات شعبه");

            //int i=0;
            //foreach (var order in OrdersList.OrderByDescending(f=>f.ID))
            //{
            //    i++;
            //    table.Rows.Add(
            //        i,
            //        order.BranchOrder.Branch.Title,
            //        order.ID,
            //        order.BranchOrder_ID,
            //        Util.GetPersianDateWithTime(order.RegDate),
            //        EnumUtil.GetEnumElementPersianTitle((BranchOrderStatus)order.Status),
            //        //UIUtil.GetCommaSeparatedOf(order.TotalPrice) + " ریال",
            //        //UIUtil.GetCommaSeparatedOf(order.BranchOrder.TotalPrice) + " ریال",
            //        order.AdminDescription,
            //        order.BranchDescription
            //        );
            //}


            //DataSet dSet = new DataSet("table");
            //dSet.Tables.Add(table);
            
            //GridView gv = new GridView();
            //gv.DataSource = dSet;
            //gv.DataBind();
            
            //ExportUtil.Export(filePath, gv, true);
        }
        catch (Exception ex)
        {
            
        }
    }
}
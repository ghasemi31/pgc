﻿using System;
using kFrameWork.UI;
using pgc.Model;
using kFrameWork.Enums;
using pgc.Model.Enums;
using pgc.Business;
using pgc.Model.Patterns;
using kFrameWork.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using kFrameWork.Util;
using System.Web.UI.HtmlControls;

public partial class Pages_Agent_BranchLackOrderNoMoney_Detail : BaseDetailControl<BranchLackOrder>
{
    public BranchLackOrder LackOrder = new BranchLackOrder();
    public BaseManagementPage<BranchLackOrderBusiness, BranchLackOrder, BranchLackOrderPattern, pgcEntities> _Page = new BaseManagementPage<BranchLackOrderBusiness, BranchLackOrder, BranchLackOrderPattern, pgcEntities>();

    public void Page_Load()
    {
        _Page = this.Page as BaseManagementPage<BranchLackOrderBusiness, BranchLackOrder, BranchLackOrderPattern, pgcEntities>;
    }

    public override BranchLackOrder GetEntity(BranchLackOrder Data, ManagementPageMode Mode)
    {
        if (Data == null)
            Data = new BranchLackOrder();
       
        return Data;
    }

    public override bool Validate(ManagementPageMode Mode)
    {
        return true;
    }

    public override void SetEntity(BranchLackOrder Data, ManagementPageMode Mode)
    {
        LackOrder = Data;

        CreatePreviewTable();

        btnRevise.Visible = _Page.Business.IsOpenForAgentAction(LackOrder.ID);
        btnDelete.Visible = _Page.Business.IsOpenForAgentAction(LackOrder.ID);
    }

    private void CreatePreviewTable()
    {

        for (int i = detailList.Controls.Count; 1 < i; i--)
            detailList.Controls.RemoveAt(i - 1);

        //BranchLackOrder lackOrder = _Page.Business.Retrieve(_Page.SelectedID);

        var LackOrderTitles = LackOrder.BranchLackOrderDetails;

        #region Preview Table


        bool isFirstTbl = true;

        //Header
        HtmlTable table = new HtmlTable();
        HtmlTableRow hrow = new HtmlTableRow();
        hrow.Style.Add("font-weight", "bold");
        hrow.Cells.Add(new HtmlTableCell() { InnerText = "ردیف" });
        hrow.Cells.Add(new HtmlTableCell() { InnerText = "نام کالا" });
        hrow.Cells.Add(new HtmlTableCell() { InnerText = "گروه" });
        //hrow.Cells.Add(new HtmlTableCell() { InnerText = "مبلغ واحد" });
        hrow.Cells.Add(new HtmlTableCell() { InnerText = "تعداد سفارشی" });
        hrow.Cells.Add(new HtmlTableCell() { InnerText = "تعداد کسری" });
        //hrow.Cells.Add(new HtmlTableCell() { InnerText = "مبلغ کل" });

        hrow.Attributes.Add("class", "theader");

        table.Rows.Add(hrow);
        table.Attributes.Add("class", (isFirstTbl) ? "tabBody selectTab" : "tabBody");

        isFirstTbl = false;

        int rowNumber = 1;
        //Add each BranchOrderTitle
        foreach (var orderT in LackOrderTitles.OrderBy(f => f.BranchOrderTitle.BranchOrderTitleGroup.DisplayOrder).ThenBy(g => g.BranchOrderTitle.DisplayOrder))
        {
            HtmlTableRow row = new HtmlTableRow();


            //Cell 1 RowNumber
            row.Cells.Add(new HtmlTableCell() { InnerText = (rowNumber++).ToString() + "-" });


            //Cell 2 Title
            row.Cells.Add(new HtmlTableCell() { InnerText = orderT.BranchOrderTitle_Title });


            //Cell 3 Group Title
            row.Cells.Add(new HtmlTableCell() { InnerText = orderT.BranchOrderTitle.BranchOrderTitleGroup.Title });


            //Cell 4 Single Price
            //row.Cells.Add(new HtmlTableCell() { InnerText = UIUtil.GetCommaSeparatedOf(orderT.SinglePrice) + " ریال" });


            //Cell 4 Single Price
            long orderedQuantity = LackOrder.BranchOrder.BranchOrderDetails.SingleOrDefault(f => f.BranchOrderTitle_ID == orderT.BranchOrderTitle_ID).Quantity;
            row.Cells.Add(new HtmlTableCell() { InnerText = orderedQuantity + " عدد" });


            //Cell 6 OrderedQuantity
            row.Cells.Add(new HtmlTableCell() { InnerText = orderT.Quantity + " عدد" });

            //Cell 7 TotalPrice
            //row.Cells.Add(new HtmlTableCell() { InnerText = UIUtil.GetCommaSeparatedOf(orderT.SinglePrice * orderT.Quantity) + " ریال" });


            table.Rows.Add(row);
        }



        //#region Footer


        //HtmlTableRow fRow = new HtmlTableRow();
        //fRow.Attributes.Add("class", "footerrow");
        //fRow.Cells.Add(new HtmlTableCell() { InnerText = "", ColSpan = 5 });
        //fRow.Cells.Add(new HtmlTableCell() { InnerText = "مجموع کل :" });
        //fRow.Cells.Add(new HtmlTableCell() { InnerText = UIUtil.GetCommaSeparatedOf(LackOrder.TotalPrice) + "ریال" });
        //table.Rows.Add(fRow);

        //#endregion


        detailList.Controls.Add(table);

        #endregion

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect(GetRouteUrl("agent-branchlackordernomoneynew", null) + "?id=" + _Page.SelectedID);
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        OperationResult op = _Page.Business.Delete(_Page.SelectedID);

        foreach (var msg in op.Messages)
            UserSession.AddMessage(msg);

        if (op.Result == ActionResult.Done)
        {
            _Page.Mode = ManagementPageMode.Search;
            _Page.ListControl.Grid.DataBind();
            EndMode(ManagementPageMode.Edit);
        }
    }
}
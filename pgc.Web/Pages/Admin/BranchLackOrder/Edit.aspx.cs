﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using kFrameWork.UI;
using pgc.Model;
using kFrameWork.Model;
using pgc.Business.Core;
using pgc.Model.Enums;
using kFrameWork.Util;
using pgc.Business;
using System.Web.UI.HtmlControls;
using kFrameWork.Business;

public partial class Pages_Admin_BranchLackOrder_Edit : BasePage
{
    ViewStateCollection<BranchOrderTitleSelect> BranchOrderTitleSelectList;
    public BranchLackOrder branchLackOrder = new BranchLackOrder();
    BranchLackOrderBusiness Business = new BranchLackOrderBusiness();

    public Pages_Admin_BranchLackOrder_Edit()
    {
        BranchOrderTitleSelectList = new ViewStateCollection<BranchOrderTitleSelect>(this.ViewState, "BranchOrderTitleSelectList");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.HasValidQueryString<long>(QueryStringKeys.id))
            Response.Redirect(GetRouteUrl("admin-branchorder", null));

        branchLackOrder = Business.Retrieve(this.GetQueryStringValue<long>(QueryStringKeys.id));

        if (IsPostBack)
            UIUtil.AddStartupScript("SetAll()", this.Page);
        else
        {
            if (branchLackOrder != null)
            {
                if (branchLackOrder.Status != (int)BranchReturnOrderStatus.Pending && branchLackOrder.Status != (int)BranchReturnOrderStatus.Canceled)
                    Response.Redirect(GetRouteUrl("admin-branchorder", null));

                foreach (var item in branchLackOrder.BranchLackOrderDetails)
                    BranchOrderTitleSelectList.AddItem(new BranchOrderTitleSelect() { Quantity = item.Quantity, TitleID = item.BranchOrderTitle_ID.Value });

                txtBranchDescription.Text = branchLackOrder.BranchDescription;
                txtAdminDescription.Text = branchLackOrder.AdminDescription;
            }

            CreateTable();
        }
    }

    private void CreateTable()
    {
        var AvailebleOrderTitles = branchLackOrder.BranchOrder.BranchOrderDetails;


        for (int i = detailList.Controls.Count - 1; 0 < i; i--)
            detailList.Controls.RemoveAt(i);


        #region UL Tabs

        HtmlGenericControl ul = new HtmlGenericControl("ul");
        ul.Attributes.Add("class", "dltabs");

        bool isFirstLi = true;
        foreach (var item in AvailebleOrderTitles.Select(f => f.BranchOrderTitle.BranchOrderTitleGroup).Distinct().OrderBy(g => g.DisplayOrder))
        {
            HtmlGenericControl li = new HtmlGenericControl("li");
            if (isFirstLi)
                li.Attributes.Add("class", "selectli");

            li.InnerText = item.Title;

            ul.Controls.Add(li);
            isFirstLi = false;
        }


        detailList.Controls.Add(ul);
        #endregion


        HtmlGenericControl div = new HtmlGenericControl();
        div.Attributes.Add("class", "tabs");

        bool isFirstTbl = true;
        foreach (var orderTitleGroup in AvailebleOrderTitles.Select(f => f.BranchOrderTitle.BranchOrderTitleGroup).Distinct().OrderBy(g => g.DisplayOrder))
        {

            //Header
            HtmlTable table = new HtmlTable();
            HtmlTableRow hrow = new HtmlTableRow();
            hrow.Style.Add("font-weight", "bold");
            hrow.Cells.Add(new HtmlTableCell() { InnerText = "نام کالا" });
            hrow.Cells.Add(new HtmlTableCell() { InnerText = "مبلغ واحد" });
            hrow.Cells.Add(new HtmlTableCell() { InnerText = "تعداد سفارشی" });
            hrow.Cells.Add(new HtmlTableCell() { InnerText = "تعداد کسری" });
            hrow.Cells.Add(new HtmlTableCell() { InnerText = "مبلغ کل" });

            hrow.Attributes.Add("class", "theader");

            table.Rows.Add(hrow);
            table.Attributes.Add("class", (isFirstTbl) ? "tabBody selectTab" : "tabBody");

            isFirstTbl = false;


            //Add each BranchOrderTitle
            foreach (var orderT in AvailebleOrderTitles.Where(f => f.BranchOrderTitle.BranchOrderTitleGroup_ID == orderTitleGroup.ID).OrderBy(f => f.BranchOrderTitle.DisplayOrder))
            {
                HtmlTableRow row = new HtmlTableRow();

                //Cell 1
                HtmlTableCell checkCell = new HtmlTableCell();
                CheckBox box = new CheckBox();
                box.ID = "chk-" + orderT.BranchOrderTitle_ID;
                box.Text = orderT.BranchOrderTitle.Title;

                if (BranchOrderTitleSelectList.List.Any(f => f.TitleID == orderT.BranchOrderTitle_ID))
                    box.Checked = true;

                checkCell.Controls.Add(box);
                row.Cells.Add(checkCell);


                //Cell 2
                row.Cells.Add(new HtmlTableCell() { InnerText = UIUtil.GetCommaSeparatedOf(orderT.SinglePrice) + " ریال" });


                //Cell 3
                row.Cells.Add(new HtmlTableCell() { InnerText = UIUtil.GetCommaSeparatedOf(orderT.Quantity) + " عدد" });


                //Cell 4
                HtmlTableCell quantityCell = new HtmlTableCell();
                TextBox textBox = new TextBox()
                {
                    ID = "txtNum-" + orderT.BranchOrderTitle_ID.ToString()
                };

                if (BranchOrderTitleSelectList.List.Any(f => f.TitleID == orderT.BranchOrderTitle_ID))
                    textBox.Text = BranchOrderTitleSelectList.List.SingleOrDefault(f => f.TitleID == orderT.BranchOrderTitle_ID).Quantity.ToString();

                quantityCell.Controls.Add(textBox);
                row.Cells.Add(quantityCell);


                //Cell 5
                HtmlTableCell totalCell = new HtmlTableCell();
                totalCell.Attributes.Add("class", "totalspan");
                totalCell.Controls.Add(new Label() { ID = "lbl-" + orderT.BranchOrderTitle_ID.ToString() });
                totalCell.Controls.Add(new Label() { Text = " ریال" });
                row.Cells.Add(totalCell);
                table.Rows.Add(row);



                table.Rows.Add(row);
            }

            div.Controls.Add(table);
        }

        detailList.Controls.Add(div);
    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        var AvailebleOrderTitles = branchLackOrder.BranchOrder.BranchOrderDetails;

        branchLackOrder.AdminDescription = txtAdminDescription.Text;
        branchLackOrder.BranchDescription = txtBranchDescription.Text;
        branchLackOrder.Status = (int)BranchLackOrderStatus.Pending;

        OperationResult opSuc = Business.AdminUpdateBeforeEdit(branchLackOrder);



        foreach (var item in BranchOrderTitleSelectList.List)
        {
            var orderTitle = AvailebleOrderTitles.SingleOrDefault(f => f.BranchOrderTitle_ID == item.TitleID);
            branchLackOrder.BranchLackOrderDetails.Add(new BranchLackOrderDetail()
            {
                BranchOrderTitle_ID = orderTitle.BranchOrderTitle_ID,
                BranchOrderTitle_Title = orderTitle.BranchOrderTitle_Title,
                Quantity = item.Quantity,
                SinglePrice = orderTitle.SinglePrice,
                TotalPrice = item.Quantity * orderTitle.SinglePrice
            });
        }

        branchLackOrder.TotalPrice = branchLackOrder.BranchLackOrderDetails.Sum(f => f.TotalPrice);

        opSuc = Business.AdminEdit(branchLackOrder);

        foreach (var item in opSuc.Messages)
            UserSession.AddMessage(item);

        if (opSuc.Result == ActionResult.Done)
        {
            if (branchLackOrder.Status == (int)BranchLackOrderStatus.Canceled)
            {
                opSuc = Business.AdminRollBackCancle(branchLackOrder.ID);

                foreach (var item in opSuc.Messages)
                    UserSession.AddMessage(item);
            }

            if (this.HasValidQueryString<long>(QueryStringKeys.id))
                Response.Redirect(GetRouteUrl("admin-branchlackorder", null) + "?id=" + branchLackOrder.ID);
            else
                Response.Redirect(GetRouteUrl("admin-branchlackorder", null));
        }
    }

    protected void btnCancle_Click(object sender, EventArgs e)
    {
        BranchOrderTitleSelectList.Clear();
        Response.Redirect(GetRouteUrl("admin-branchlackorder", null));
    }

    protected void btnPreview_Click(object sender, EventArgs e)
    {
        var checkBoxList = Request.Form.AllKeys.Where(f => f.Contains("chk-"));

        bool isValid = true;

        BranchOrderTitleSelectList.Clear();

        //var AvailebleOrderTitles = branchLackOrder.BranchLackOrderDetails;


        //Validation Of Credit, Minimum QUantity, Select & Have Quantity
        #region Validating

        if (checkBoxList.Count() == 0)
        {
            if (!UserSession.CurrentMessages.Contains(UserMessageKey.BranchLackOrderNew_NoTitleSelected))
                UserSession.AddMessage(pgc.Model.Enums.UserMessageKey.BranchLackOrderNew_NoTitleSelected);
            isValid = false;
        }

        foreach (var checkBox in checkBoxList)
        {
            var temp = Request.Form.AllKeys.SingleOrDefault(f => f.EndsWith("txtNum-" + checkBox.Split('-')[1]));
            long quantity = 0;
            long OrderTitle_ID = long.Parse(checkBox.Split('-')[1]);

            if (!long.TryParse(Request.Form[temp], out quantity))
            {
                if (!UserSession.CurrentMessages.Contains(UserMessageKey.BranchLackOrderNew_NoQuantitySelected))
                    UserSession.AddMessage(pgc.Model.Enums.UserMessageKey.BranchLackOrderNew_NoQuantitySelected);
                isValid = false;
            }

            if (quantity < 1)
            {
                if (!UserSession.CurrentMessages.Contains(UserMessageKey.BranchLackOrderNew_NoQuantitySelected))
                    UserSession.AddMessage(pgc.Model.Enums.UserMessageKey.BranchLackOrderNew_NoQuantitySelected);
                isValid = false;
            }

            if (quantity > branchLackOrder.BranchOrder.BranchOrderDetails.Single(f => f.BranchOrderTitle_ID == OrderTitle_ID).Quantity)
            {
                if (!UserSession.CurrentMessages.Contains(UserMessageKey.BranchLackOrderNew_MoreThaNOrdered))
                    UserSession.AddMessage(pgc.Model.Enums.UserMessageKey.BranchLackOrderNew_MoreThaNOrdered);
                isValid = false;
            }

            BranchOrderTitleSelectList.AddItem(new BranchOrderTitleSelect()
            {
                Quantity = quantity,
                TitleID = OrderTitle_ID
            });
        }

        long TotalPrice = 0;
        foreach (var item in BranchOrderTitleSelectList.List)
            TotalPrice += (item.Quantity * new BranchOrderTitleBusiness().Retrieve(item.TitleID).Price);

        //OperationResult op = new BranchCreditBusiness().CheckCreditOfBranch(branchLackOrder.Branch_ID, TotalPrice);

        //if (op.Result != ActionResult.Done)
        //{
        //    foreach (var msg in op.Messages)
        //        UserSession.AddMessage(msg);
        //    isValid = false;
        //}

        if (!isValid)
        {
            CreateTable();
            return;
        }
        #endregion



        CreatePreviewTable();


        //State Changing
        btnAdd.Visible = true;
        btnRevise.Visible = true;
        btnPreview.Visible = false;
    }

    private void CreatePreviewTable()
    {
        var AvailebleOrderTitles = branchLackOrder.BranchOrder.BranchOrderDetails;


        #region Preview Table

        if (BranchOrderTitleSelectList.Count > 0)
        {
            bool isFirstTbl = true;

            //Header
            HtmlTable table = new HtmlTable();
            HtmlTableRow hrow = new HtmlTableRow();
            hrow.Style.Add("font-weight", "bold");
            hrow.Cells.Add(new HtmlTableCell() { InnerText = "ردیف" });
            hrow.Cells.Add(new HtmlTableCell() { InnerText = "نام کالا" });
            //hrow.Cells.Add(new HtmlTableCell() { InnerText = "گروه" });
            hrow.Cells.Add(new HtmlTableCell() { InnerText = "مبلغ واحد" });
            hrow.Cells.Add(new HtmlTableCell() { InnerText = "تعداد سفارش شده" });
            hrow.Cells.Add(new HtmlTableCell() { InnerText = "تعداد کسری" });
            hrow.Cells.Add(new HtmlTableCell() { InnerText = "مبلغ کل" });

            hrow.Attributes.Add("class", "theader");

            table.Rows.Add(hrow);
            table.Attributes.Add("class", (isFirstTbl) ? "tabBody selectTab" : "tabBody");

            isFirstTbl = false;

            int rowNumber = 1;
            //Add each BranchOrderTitle
            foreach (var orderT in AvailebleOrderTitles.OrderBy(f => f.BranchOrderTitle.BranchOrderTitleGroup.DisplayOrder).ThenBy(g => g.BranchOrderTitle.DisplayOrder))
            {

                if (BranchOrderTitleSelectList.List.All(f => f.TitleID != orderT.BranchOrderTitle_ID))
                    continue;


                HtmlTableRow row = new HtmlTableRow();


                //Cell 1 RowNumber
                row.Cells.Add(new HtmlTableCell() { InnerText = (rowNumber++).ToString() + "-" });


                //Cell 2 Title
                row.Cells.Add(new HtmlTableCell() { InnerText = orderT.BranchOrderTitle.Title });


                ////Cell 3 Group Title
                //row.Cells.Add(new HtmlTableCell() { InnerText = orderT.BranchOrderTitle.BranchOrderTitleGroup.Title });


                //Cell 4 Single Price
                row.Cells.Add(new HtmlTableCell() { InnerText = UIUtil.GetCommaSeparatedOf(orderT.SinglePrice) + " ریال" });


                //Cell 5 OrderedQuantity
                row.Cells.Add(new HtmlTableCell() { InnerText = orderT.Quantity + " عدد" });


                //Cell 6 OrderedQuantity
                long LackQuantity = BranchOrderTitleSelectList.List.SingleOrDefault(f => f.TitleID == orderT.BranchOrderTitle_ID).Quantity;
                row.Cells.Add(new HtmlTableCell() { InnerText = LackQuantity + " عدد" });


                //Cell 7 TotalPrice
                row.Cells.Add(new HtmlTableCell() { InnerText = UIUtil.GetCommaSeparatedOf(orderT.BranchOrderTitle.Price * LackQuantity) + " ریال" });


                table.Rows.Add(row);
            }



            #region Footer

            long TotalPrice = 0;
            foreach (var item in BranchOrderTitleSelectList.List)
                TotalPrice += (item.Quantity * new BranchOrderTitleBusiness().Retrieve(item.TitleID).Price);


            HtmlTableRow fRow = new HtmlTableRow();
            fRow.Attributes.Add("class", "footerrow");
            fRow.Cells.Add(new HtmlTableCell() { InnerText = "مجموع کل :", ColSpan = 5 });
            fRow.Cells.Add(new HtmlTableCell() { InnerText = UIUtil.GetCommaSeparatedOf(TotalPrice) + "ریال" });
            table.Rows.Add(fRow);

            #endregion


            detailList.Controls.Add(table);
        }
        else
        {
            HtmlGenericControl table = new HtmlGenericControl();
            table.InnerText = "هیچ کالایی برای کسری انتخاب نشده است";

            detailList.Controls.Add(table);
        }
        #endregion

    }
  
    protected void btnRevise_Click(object sender, EventArgs e)
    {
        btnAdd.Visible = false;
        btnRevise.Visible = false;
        btnPreview.Visible = true;

        CreateTable();
    }



    [Serializable]
    public class BranchOrderTitleSelect
    {
        public long TitleID { get; set; }
        public long Quantity { get; set; }
    }
}
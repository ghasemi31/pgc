﻿using System;
using kFrameWork.UI;
using pgc.Model;
using pgc.Business;
using System.Web.UI.WebControls;
using pgc.Model.Enums;
using kFrameWork.Util;
using pgc.Model.Patterns;
using kFrameWork.Enums;
using System.Web.UI.HtmlControls;

public partial class Pages_Admin_BranchPayment_List : BaseListControl
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        base.Grid = this.grdList;
        base.DataSource = this.obdSource;
    }

    protected void grdList_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        int cellBranchName = 3;
        int cellPayStatus = 6;
        int cellPayDate = 5;
        int cellConfirm = 8;
        int cellUnconfirm = 9;
        int cellDelete = 11;

        if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
        {
            BranchPayment pay = (BranchPayment)e.Row.DataItem;


            #region inf Of Cost

            e.Row.Cells[cellBranchName].Text = pay.Branch.Title;

            e.Row.Cells[cellBranchName].CssClass += " tooltip";

            string tooltipCost = "";
            tooltipCost += "<div>تلفن : " + pay.Branch.PhoneNumbers.Replace("\n","-") + "</div>";
            tooltipCost += "<div>اعتبار : " + BranchCreditBusiness.GetBranchCredit(pay.Branch_ID) + "</div>";

            e.Row.Cells[cellBranchName].ToolTip = tooltipCost;

            #endregion


            #region Date

            if (pay.Type == (int)BranchPaymentType.Online)
                e.Row.Cells[cellPayDate].Text = DateUtil.GetPersianDateWithTime(pay.Date);
            else
                e.Row.Cells[cellPayDate].Text = DateUtil.GetPersianDateWithTime(DateUtil.GetEnglishDateTime(pay.OfflineReceiptPersianDate));
            #endregion


            #region PayStatus
            string transactionState = "";

            if (pay.Type == (int)BranchPaymentType.Online)
            {
                if (pay.OnlineTransactionState == "OK")
                {
                    if (pay.OnlineResultTransaction <= 0)
                        transactionState = (UserMessageKeyBusiness.GetUserMessageDescription((UserMessageKey)Enum.Parse(typeof(UserMessageKey), "Err_" + Math.Abs(pay.OnlineResultTransaction).ToString())));
                    else
                        transactionState = UserMessageKeyBusiness.GetUserMessageDescription(UserMessageKey.OK);
                }
                else
                    transactionState = (EnumUtil.GetEnumElementPersianTitle((OnlineTransactionStatus)Enum.Parse(typeof(OnlineTransactionStatus), (pay.OnlineTransactionState))));
            }

            Image image = new Image();
            image.CssClass += " tooltip";
            string tooltipPay = "";            
            if ((pay.Type==(int)BranchPaymentType.Offline && pay.OfflinePaymentStatus==(int)BranchOfflinePaymentStatus.Paid)||
                (pay.Type == (int)BranchPaymentType.Online && pay.OnlineTransactionState == "OK" && pay.OnlineResultTransaction == pay.Amount && pay.OnlineRefNum != ""))
            {
                image.AlternateText = "پرداخت شده";
                image.ImageUrl = "~/styles/images/enabled.png";
                if (pay.Type == (int)BranchPaymentType.Online)
                {
                    tooltipPay = "<div>نحوه پرداخت: آنلاین (پرداخت شده)</div>";
                    tooltipPay += "<div>وضعیت تراکنش: " + transactionState + "</div>";

                    if (!string.IsNullOrEmpty(pay.OnlineRefNum))
                        tooltipPay += "<div>رسید دیجیتالی: " + pay.OnlineRefNum + "</div>";

                    tooltipPay += "<div>تاریخ تراکنش: " + pay.PersianDate + "</div>";
                }
                else
                {
                    tooltipPay = "<div>نحوه پرداخت: آفلاین (پرداخت شده)</div>";
                    tooltipPay += "<div>واریز به حساب:  " + pay.OfflineBankAccountTitle + "</div>";
                    tooltipPay += "<div>واریز کننده:  " + pay.OfflineReceiptLiquidator + "</div>";
                    tooltipPay += "<div>شماره فیش: " + pay.OfflineReceiptNumber + "</div>";
                    tooltipPay += "<div>تاریخ واریز: " + pay.OfflineReceiptPersianDate + "</div>";
                    tooltipPay += "<div>نحوه واریز: " + EnumUtil.GetEnumElementPersianTitle((BranchOfflineReceiptType)pay.OfflineReceiptType) + "</div>";
                }
            }
            else
            {
                image.AlternateText = "پرداخت نشده";
                image.ImageUrl = "~/styles/images/disabled.png";

                if (pay.Type == (int)BranchPaymentType.Online)
                    {
                        tooltipPay = "<div>نحوه پرداخت: آنلاین (پرداخت نشده)</div>";
                        tooltipPay += "<div>وضعیت تراکنش: " + transactionState + "</div>";
                        if (!string.IsNullOrEmpty(pay.OnlineRefNum))
                            tooltipPay += "<div>رسید دیجیتالی: " + pay.OnlineRefNum + "</div>";

                        tooltipPay += "<div>تاریخ تراکنش: " + pay.PersianDate + "</div>";
                    }
                else if (pay.Type == (int)BranchPaymentType.Offline && pay.OfflinePaymentStatus == (int)BranchOfflinePaymentStatus.NotPaid)
                    {
                        tooltipPay = "<div>نحوه پرداخت: آفلاین (پرداخت نشده)</div>";
                        tooltipPay += "<div>واریز به حساب: " + pay.OfflineBankAccountTitle + "</div>";
                        tooltipPay += "<div>واریز کننده:  " + pay.OfflineReceiptLiquidator + "</div>";
                        tooltipPay += "<div>شماره فیش: " + pay.OfflineReceiptNumber + "</div>";
                        tooltipPay += "<div>تاریخ واریز: " + pay.OfflineReceiptPersianDate + "</div>";
                        tooltipPay += "<div>نحوه واریز: " + EnumUtil.GetEnumElementPersianTitle((BranchOfflineReceiptType)pay.OfflineReceiptType) + "</div>";
                    }
                else if (pay.Type == (int)BranchPaymentType.Offline && pay.OfflinePaymentStatus == (int)BranchOfflinePaymentStatus.Pending)
                    {
                        image.AlternateText = "در حال بررسی";
                        image.ImageUrl = "~/styles/images/pending.png";

                        tooltipPay = "<div>نحوه پرداخت: آفلاین (در حال بررسی)</div>";
                        tooltipPay += "<div>واریز به حساب: " + pay.OfflineBankAccountTitle + "</div>";
                        tooltipPay += "<div>واریز کننده:  " + pay.OfflineReceiptLiquidator + "</div>";
                        tooltipPay += "<div>شماره فیش: " + pay.OfflineReceiptNumber + "</div>";
                        tooltipPay += "<div>تاریخ واریز: " + pay.OfflineReceiptPersianDate + "</div>";
                        tooltipPay += "<div>نحوه واریز: " + EnumUtil.GetEnumElementPersianTitle((BranchOfflineReceiptType)pay.OfflineReceiptType) + "</div>";
                    }
            }
            image.ToolTip = tooltipPay;
            e.Row.Cells[cellPayStatus].Controls.Add(image);
            e.Row.Cells[cellPayStatus].Style.Add("text-align", "center");


            #endregion  


            #region Command Btns
            if (pay.Type == (int)BranchPaymentType.Online)
            {
                e.Row.Cells[cellUnconfirm].Controls.RemoveAt(0);
                e.Row.Cells[cellConfirm].Controls.RemoveAt(0);
                e.Row.Cells[cellDelete].Controls[0].Visible = false;
            }
            else
            {
                switch ((BranchOfflinePaymentStatus)pay.OfflinePaymentStatus)
                {
                    case BranchOfflinePaymentStatus.NotPaid:
                        e.Row.Cells[cellUnconfirm].Controls.RemoveAt(0);
                        break;
                    case BranchOfflinePaymentStatus.Paid:
                        e.Row.Cells[cellConfirm].Controls.RemoveAt(0);
                        break;
                    case BranchOfflinePaymentStatus.Pending:
                        break;
                    default:
                        break;
                }
            }
     
            #endregion

        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            var _Page = this.Page as BaseManagementPage<BranchPaymentBusiness, BranchPayment, BranchPaymentPattern, pgcEntities>;

            e.Row.Cells[3].Text = "جمع کل";
            long total=0;
            if ((_Page.SearchControl.FindControl("IsFirstTime") as HtmlInputHidden).Value=="true")
                total = _Page.Business.TotalAmount(_Page.SearchControl.DefaultPattern);
            else
                total = _Page.Business.TotalAmount(_Page.SearchControl.Pattern);

            e.Row.Cells[4].Text = UIUtil.GetCommaSeparatedOf(total) + " ریال";
            e.Row.Cells[4].ColumnSpan = 3;
            e.Row.Cells[4].Style.Add("padding-top", "10px");
            e.Row.Font.Bold = true;
            e.Row.Font.Size = 8;
        }
    }
    protected void Grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var _Page = this.Page as BaseManagementPage<BranchPaymentBusiness, BranchPayment, BranchPaymentPattern, pgcEntities>;

        if (e.CommandName == "ConfirmRow")
        {            
            var msgs = _Page.Business.ConfirmPayment(long.Parse(Grid.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString())).Messages;
            foreach (var item in msgs)
            {
                UserSession.AddMessage(item);
            }
        }
        else if (e.CommandName == "UnconfirmRow")
        {
            var msgs = _Page.Business.UnConfirmPayment(long.Parse(Grid.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString())).Messages;
            foreach (var item in msgs)
            {
                UserSession.AddMessage(item);
            }
        }
        else
            base.Grid_RowCommand(sender, e);

        _Page.ListControl.Grid.DataBind();

    }
}
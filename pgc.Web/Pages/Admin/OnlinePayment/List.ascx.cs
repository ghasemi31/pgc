﻿using System;
using kFrameWork.UI;
using System.Web.UI;
using kFrameWork.Util;
using pgc.Model.Enums;
using pgc.Business;
using System.Web.UI.WebControls;
using pgc.Business.Core;
using pgc.Model;
using kFrameWork.Model;
using kFrameWork.Business;
using pgc.Business.Payment.OnlinePay;

public partial class Pages_Admin_Payment_List : BaseListControl
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        base.Grid = this.grdList;
        base.DataSource = this.obdSource;
    }



    protected void grdList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int cellAMount = 3;
        int cellOrderID = 4;
        int cellGetway = 5;
        int cellRefNum = 6;
        int cellDate = 7;
        int cellStatus = 8;
        //int cellResult = 8;
        int cellverify = 9;
        int cellReverse = 10;
        int maxChar = 45;

        if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
        {
            e.Row.Cells[cellDate].Text = DateUtil.GetPersianDateWithTime((DateTime)DataBinder.Eval(e.Row.DataItem, "Date"));
            e.Row.Cells[cellAMount].Text = UIUtil.GetCommaSeparatedOf(DataBinder.Eval(e.Row.DataItem, "Amount").ToString()) + " ریال";

            //ORDER_ID
            HyperLink hp = new HyperLink()
            {
                NavigateUrl = GetRouteUrl("admin-orders", null) + "?id=" + DataBinder.Eval(e.Row.DataItem, "Order_ID").ToString(),
                Text = DataBinder.Eval(e.Row.DataItem, "Order_ID").ToString(),
                CssClass = "hbtn"
            };
            e.Row.Cells[cellOrderID].Controls.Add(hp);

            //STATE AND GETWAY

            OnlineGetway getway = (OnlineGetway)Enum.Parse(typeof(OnlineGetway), DataBinder.Eval(e.Row.DataItem, "BankGeway_Enum").ToString());
            bool isOK = false;
            string statusStr = "";
            switch (getway)
            {
                case OnlineGetway.MellatBankGateWay:
                    MellatOnlinePaymentState status = (MellatOnlinePaymentState)Enum.Parse(typeof(MellatOnlinePaymentState), DataBinder.Eval(e.Row.DataItem, "State").ToString());
                    statusStr = EnumUtil.GetEnumElementPersianTitle(status);
                    if (status != MellatOnlinePaymentState.OK)
                    {
                        isOK = false;
                        e.Row.Cells[cellGetway].Text = "<img src=\"/assets/Guest/Image/MellatBankGateWay.png\" style=\" height:40px; \" alt=\"img2\">";
                    }
                    else
                        isOK = false;
                    break;
                case OnlineGetway.AsanPardakhtGateWay:
                    //asan pardakht here

                    break;
                default:
                    break;
            }

            //status
            if (isOK)
            {
                e.Row.Cells[cellStatus].Text = "پرداخت شده";
            }
            else
            {
                e.Row.Cells[cellStatus].Text = statusStr;
            }



            if (e.Row.Cells[cellStatus].Text.Length > maxChar)
            {
                e.Row.Cells[cellStatus].ToolTip = e.Row.Cells[cellStatus].Text;
                e.Row.Cells[cellStatus].Text = e.Row.Cells[cellStatus].Text.Substring(0, maxChar);
            }

            //REFNUM            
            string refnum = DataBinder.Eval(e.Row.DataItem, "RefNum").ToString();
            e.Row.Cells[cellRefNum].Text = string.IsNullOrEmpty(refnum) ? "-------" : refnum;

            if (string.IsNullOrEmpty(refnum) || !isOK)
            {
                e.Row.Cells[cellReverse].Controls.RemoveAt(0);
                e.Row.Cells[cellverify].Controls.RemoveAt(0);
            }

            ////RESULT
            //long result = long.Parse(DataBinder.Eval(e.Row.DataItem, "ResultTransaction").ToString());
            //if (result > 0)
            //    e.Row.Cells[cellResult].Text = "پرداخت شده";
            //else
            //    e.Row.Cells[cellResult].Text = UserMessageKeyBusiness.GetUserMessageKey((UserMessageKey)Enum.Parse(typeof(UserMessageKey), "Err_" + result.ToString()));

            //if (e.Row.Cells[cellResult].Text.Length > maxChar)
            //{
            //    e.Row.Cells[cellResult].ToolTip = e.Row.Cells[cellResult].Text;
            //    e.Row.Cells[cellResult].Text = e.Row.Cells[cellResult].Text.Substring(0, maxChar);
            //}
        }
    }

    protected override void Grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        long id = (long)Grid.DataKeys[int.Parse(e.CommandArgument.ToString())].Value;
        Payment online = new pgc.Business.PaymentBusiness().Retrieve(id);
        OperationResult op = new OperationResult();

        OnlineGetway getway = (OnlineGetway)online.GameOrder.Getway_Enum;

        if (e.CommandName == "VerifyRow")
        {

            switch (getway)
            {
                case OnlineGetway.MellatBankGateWay:
                    MellatOnlinePaymentBusiness mellat_business = new MellatOnlinePaymentBusiness();
                    op = mellat_business.Verify(online.ID, online.RefNum, false);
                    break;
                case OnlineGetway.AsanPardakhtGateWay:

                    // asan pardakht here
                    break;
                default:
                    break;
            }


        }
        else if (e.CommandName == "ReverseRow")
        {
            switch (getway)
            {
                case OnlineGetway.MellatBankGateWay:
                    MellatOnlinePaymentBusiness mellat_business = new MellatOnlinePaymentBusiness();
                    op = mellat_business.Reverse(online.ID, online.RefNum);
                    break;
                case OnlineGetway.AsanPardakhtGateWay:

                    // asan pardakht here
                    break;
                default:
                    break;
            }


        }

        foreach (var item in op.Messages)
        {
            UserSession.AddMessage(item);
        }
        foreach (var item in op.CompleteMessages)
        {
            UserSession.AddCompeleteMessage(item);
        }


        base.Grid_RowCommand(sender, e);
        base.Grid.DataBind();
    }

    protected void btnEvent_Click(object sender, EventArgs e)
    {
        if ((this.Page as BasePage).HasValidQueryString<long>(QueryStringKeys.fid))
        {
            Response.Redirect(GetRouteUrl("admin-orders", null));
        }
    }

    protected override void OnPreRender(EventArgs e)
    {
        int second = OptionBusiness.GetInt(OptionKey.SecondOfRefreshOrderPage);

        if (second > 0)
            Timer.Interval = second * 1000;

        base.OnPreRender(e);

    }

    protected void Timer_Tick(object sender, EventArgs e)
    {
        grdList.DataBind();
    }

}
﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Guest.master" AutoEventWireup="true" CodeFile="GameList.aspx.cs" Inherits="Pages_User_GameList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <%this.Title = (!string.IsNullOrEmpty(kFrameWork.UI.UserSession.User.FullName)) ? "لیست بازیهای من-" + kFrameWork.UI.UserSession.User.FullName : ""; %>
    <link href="/assets/User/UserProfile.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphbdy" Runat="Server">
    <section class="main-body">
        <div class="container">
            <div class="row">
                
                    <input type="hidden" id="SelectedOrder" runat="server" clientidmode="Static" />
                    <div class="col-lg-offset-1 col-md-offset-1 col-sm-offset-0 col-xs-offset-0 col-lg-10 col-md-10 col-sm-12 col-xs-12">
                        <div class="order-code">
                            <ul class="list-inline">
                                <li><a href="/userprofile">
                                    
                                    حساب کاربری من  <i class="fa fa-angle-left" aria-hidden="true"></i></a></li>
                                <li>بازیهای من</li>
                            </ul>
                        </div>
                        <div class="user-info">
                            <header>
                                <i class="fa fa-list" aria-hidden="true"></i>
                                <span>بازیهای من</span>
                                <hr />
                            </header>
                            <div class="row margin0" style="padding: 0 20px;">
                                <table class="table">
                                    <tr class="order-title table-header">
                                        <td>کد</td>
                                        <td>نام بازی</td>
                                        <td class="text-align-center">تاریخ</td>
                                        
                                        <td class="text-align-center">هزینه ثبت نام(ریال)</td>
                                       
                                        <td class="text-align-center">وضعیت پرداخت</td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <asp:ObjectDataSource ID="odsOrder"
                                        runat="server"
                                        EnablePaging="True"
                                        SelectCountMethod="GameOrder_Count"
                                        SelectMethod="GameOrder_List"
                                        TypeName="pgc.Business.General.GameOrderBusiness"
                                        EnableViewState="false"></asp:ObjectDataSource>
                                    <asp:ListView ID="lsvOrder" runat="server" DataSourceID="odsOrder" EnableViewState="false">
                                        <ItemTemplate>
                                            <tr class="order-tb-row">
                                                <td><%#Eval("ID") %></td>
                                                <td><%#Eval("GameTitle") %></td>
                                                <td><%#kFrameWork.Util.DateUtil.GetPersianDateWithTime(Convert.ToDateTime(Eval("OrderDate")))%></td>
                                                <td class="text-align-center"><%#kFrameWork.Util.UIUtil.GetCommaSeparatedOf((Convert.ToInt64(Eval("PayableAmount"))).ToString())%></td>
                                               
                                                <td class="text-align-center" data-tooltip="<%# (bool)Eval("IsPaid")?"پرداخت شده":"پرداخت نشده" %>" data-tooltip-position="top" style="display: block"><i class="fa <%# (bool)Eval("IsPaid")?"fa-check paid":"fa-times unpaid" %>" aria-hidden="true"></i></td>
                                                <td style="<%# (bool)Eval("IsPaid")?"display:none":"" %>">
                                                    <input type="hidden" order="<%# Eval("ID") %>" ispaid="<%# Eval("IsPaid") %>" />
                                                    <asp:Button ID="BtnPay"  runat="server" Text="پرداخت آنلاین" OnClick="Btn_Pay_Click" OnClientClick="javascript:setID(this)" CssClass="btn-table" />
                                                </td>
                                                <td class="tbl-row"><a href="<%#GetRouteUrl("user-gamedetail",new { id = Eval("ID") })%>" class="btn-table">جزئیات</a></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:ListView>
                                </table>
                            </div>
                        </div>
                    </div>
               
                <!-- Pager -->
                <%if (dprOrder.TotalRowCount > dprOrder.MaximumRows)
                  {%>
                <div class="pagination">
                    <span>صفحات دیگر: </span>
                    <asp:DataPager ID="dprOrder" runat="server" PagedControlID="lsvOrder" PageSize="10" QueryStringField="page">
                        <Fields>
                            <asp:NextPreviousPagerField PreviousPageText="قبلی" ButtonCssClass="button prev" ShowNextPageButton="false" />
                            <asp:TemplatePagerField>
                                <PagerTemplate><span class="pages"></PagerTemplate>
                            </asp:TemplatePagerField>
                            <asp:NumericPagerField ButtonCount="6" NumericButtonCssClass="page" NextPreviousButtonCssClass="page" CurrentPageLabelCssClass="current" />
                            <asp:TemplatePagerField>
                                <PagerTemplate></span></PagerTemplate>
                            </asp:TemplatePagerField>
                            <asp:NextPreviousPagerField NextPageText="بعدی" ButtonCssClass="button next" ShowPreviousPageButton="false" />
                        </Fields>
                    </asp:DataPager>
                </div>
                <%} %>
            </div>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphfoot" Runat="Server">
    <script language="javascript" type="text/javascript">
        function setID(e) {
            $('#SelectedOrder').val($(e).prev().attr('order'));
        };

        $(document).ready(function () {
            $('input[IsPaid=True]').each(function () {
                $(this).next().hide();
                //$(this).next().next().hide();
            });
        });
    </script>
</asp:Content>


﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Search.ascx.cs" Inherits="Pages_Admin_Payment_Search" %>
<legend>جستجو</legend>
<table>
    <tr>
        <td class="caption">مبلغ</td>
        <td class="control"><kfk:NumericRange ID="nmrAMount" runat="server" /></td>
    </tr>
    <tr>
        <td class="caption">کد رهگیری</td>
        <td class="control"><kfk:NormalTextBox ID="txtOrderID" Mode="Numeric" runat="server" /></td>
    </tr>
    <tr>
        <td class="caption">وضعیت</td>
        <td class="control"><kfk:LookupCombo AddDefaultItem="true" ID="lkpStatus" EnumParameterType="pgc.Model.Enums.GameOrderPaymentStatus" runat="server" /></td>
    </tr>
    <tr>
        <td class="caption">تاریخ واریز</td>
        <td class="control"><kfk:PersianDateRange ID="pdrDate" runat="server" /></td>
    </tr>
    <tr>
        <td class="caption">بازی</td>
        <td class="control"><kfk:LookupCombo ID="lkcGame" 
                                            runat="server" 
                                            BusinessTypeName="pgc.Business.Lookup.GameLookupBusiness"
                                            AddDefaultItem="true"
                                            CssClass="large"/></td>
    </tr>
</table>
<div class="commands">
    <asp:Button runat="server" ID="btnSearch" Text="جستجو" CssClass="" OnClick="OnSearch" />
    <asp:Button runat="server" ID="btnShowAll" Text="نمایش تمامی تراکنش ها" CssClass="" OnClick="OnSearchAll" />
</div>

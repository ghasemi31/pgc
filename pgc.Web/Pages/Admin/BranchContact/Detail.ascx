﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Detail.ascx.cs" Inherits="Pages_Admin_BranchContact_Detail" %>
<legend><%=(this.Page as kFrameWork.UI.BasePage).Entity.UITitle %></legend>
<table>
 
    <tr>
        <td class="caption">تاریخ</td>
        <td class="control"><asp:Label ID="lblPersianDate" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="caption">شعبه مربوطه</td>
        <td class="control"><asp:Label ID="lblBranchName" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="caption">نام</td>
        <td class="control"><asp:Label ID="lblName" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="caption">ایمیل</td>
        <td class="control"><asp:Label ID="lblEmail" runat="server"></asp:Label></td>
    </tr>
    <tr>
         <td class="caption">متن</td>
        <td class="control"><asp:Label ID="lblBody" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="caption">آیا پیام خوانده شده است؟</td>
        <td class="control"><asp:CheckBox ID="chkIsRead" runat="server" /></td>
    </tr>
</table>
<div class="commands">
   <%-- <asp:Button runat="server" ID="btnSave" Text="ذخیره" CssClass="large" OnClick="OnSave" CausesValidation="true" />--%>
    <asp:Button runat="server" ID="btnCancel" Text="بازگشت" CssClass="large" OnClick="OnCancel" CausesValidation="false" />
</div>


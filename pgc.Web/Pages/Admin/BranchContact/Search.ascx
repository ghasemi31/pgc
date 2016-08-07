﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Search.ascx.cs" Inherits="Pages_Admin_BranchContact_Search" %>
<legend>جستجو</legend>
<table>
    <tr>
        <td class="caption">نام / ایمیل</td>
        <td class="control"><kfk:NormalTextBox ID="txtName" runat="server" /></td>
    </tr>
    <tr>
        <td class="caption">تاریخ</td>
        <td class="control"><kfk:PersianDateRange ID="pdrUCPersianDate" runat="server" /></td>
    </tr>
</table>
<div class="commands">
    <asp:Button runat="server" ID="btnSearch" Text="جستجو" CssClass="" OnClick="OnSearch" />
    <asp:Button runat="server" ID="btnShowAll" Text="نمایش همه" CssClass="" OnClick="OnSearchAll" />
</div>
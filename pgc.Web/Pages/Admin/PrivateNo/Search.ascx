﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Search.ascx.cs" Inherits="Pages_Admin_PrivateNo_Search" %>
<legend>جستجو</legend>
<table>
    <tr>
        <td class="caption">شماره</td>
        <td class="control"><kfk:NormalTextBox ID="txtNumber" runat="server" /></td>
    </tr>
</table>
<div class="commands">
    <asp:Button runat="server" ID="btnSearch" Text="جستجو" CssClass="" OnClick="OnSearch" />
    <asp:Button runat="server" ID="btnShowAll" Text="نمایش همه" CssClass="" OnClick="OnSearchAll" />
</div>

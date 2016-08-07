﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Detail.ascx.cs" Inherits="Pages_Admin_Poll_Detail" %>
<legend><%=(this.Page as kFrameWork.UI.BasePage).Entity.UITitle %></legend>
<table class="Pollform">
    <tr>
        <td class="caption">تاریخ نظرسنجی</td>
        <td class="control"><kfk:PersianDatePicker runat="server" ID="pdpPollPersianDate" Required="true"/></td>
    </tr>
    <tr>
        <td class="caption">عنوان</td>
        <td class="control" ><kfk:NormalTextBox ID="txtTitle" runat="server" Required="true"/></td>
    </tr>
    <tr>
        <td class="caption">توضیحات</td>
        <td class="control"><kfk:HtmlEditor ID="txtDesc" runat="server" /></td>
    </tr>
    <tr>
        <td class="caption">فعال</td>
        <td class="control"><asp:CheckBox runat="server" ID="chkIsActive" Text="" CssClass="checkbox" /></td>
    </tr>
</table>
<div class="commands">
    <asp:Button runat="server" ID="btnSave" Text="ذخیره" CssClass="large" OnClick="OnSave" CausesValidation="true" />
    <asp:Button runat="server" ID="btnCancel" Text="انصراف" CssClass="large" OnClick="OnCancel" CausesValidation="false" />
</div>


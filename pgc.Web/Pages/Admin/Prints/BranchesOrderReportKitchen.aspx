﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BranchesOrderReportKitchen.aspx.cs" Inherits="Pages_Admin_Prints_BranchesOrderReportKitchen" %>

<%@ Import Namespace="pgc.Model" %>
<%@ Import Namespace="pgc.Model.Enums" %>
<%@ Import Namespace="pgc.Model.Patterns" %>
<%@ Import Namespace="pgc.Business" %>
<%@ Import Namespace="kFrameWork.Util" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>گزارش سفارشات شعب</title>
    <link href="<%=ResolveClientUrl("~/Styles/Shared/PrintPage.css")%>" rel="stylesheet" type="text/css" />
    <%--<link href="/assets/css/BranchesOrderReport/Default.css?v=2" rel="stylesheet" />--%>
    <script src="<%=ResolveClientUrl("~/scripts/shared/jquery-1.7.2.min.js")%>" type="text/javascript" language="javascript"></script>
    <script language="javascript" type="text/javascript">
        $(document).ready(new function () {
            self.print();
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
        
    </form>
</body>
</html>

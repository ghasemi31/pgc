﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserList.aspx.cs" Inherits="Pages_Admin_Prints_UserList" %>

<%@ Import Namespace="pgc.Model" %>
<%@ Import Namespace="pgc.Model.Enums" %>
<%@ Import Namespace="pgc.Model.Patterns" %>
<%@ Import Namespace="pgc.Business" %>
<%@ Import Namespace="kFrameWork.Util" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>لیست کاربران</title>
    <link href="<%=ResolveClientUrl("~/Styles/Shared/PrintPage.css")%>" rel="stylesheet" type="text/css" />
    <script src="<%=ResolveClientUrl("~/scripts/shared/jquery-1.7.2.min.js")%>" type="text/javascript" language="javascript"></script>
    <script language="javascript" type="text/javascript">
        $(document).ready(new function () {
            self.print();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>


            <%try
              {
                  UserBusiness business = new UserBusiness();
                  UserPattern pattern = (UserPattern)Session["UserListPattern"];
                  IQueryable<User> userList = business.Search_SelectPrint(pattern);

                  bool isAltRow = true;
                
                  
            if (pattern != null)
              {
                  string accesslevel = new AccessLevelBusiness().Retrieve(pattern.AccessLevel_ID).Title;
                  string province = new ProvinceBusiness().Retrieve(pattern.Province_ID).Title;
                  string city = new CityBusiness().Retrieve(pattern.City_ID).Title;
                  %>
            <table border="0px" class="lsttbl">
                <tr class="thead" style="text-align: center;">
                    <th colspan="4">نتایج جستجو بر روی فیلد های ذیل در لیست کاربران</th>
                </tr>
                <tr>
                    <td class="caption" style="border: none">نام و نام خانوادگی : <%=pattern.Name %></td>
                     <td class="caption" style="border: none">کد ملی : <%=pattern.NationalCode %></td>
                    <td class="caption" style="border: none">نام پدر : <%=pattern.FatherName %></td>
                </tr>
                <tr>
                    <td class="caption" style="border: none">شماره تماس : <%=pattern.Tel %></td>
                    <td class="caption" style="border: none">تلفن همراه : <%=pattern.Mobile %></td>
                    <td class="caption" style="border: none">پست الکترونیک : <%=pattern.Email %></td>
                </tr>
                
                <tr>
                     <td class="caption" style="border: none">جنسیت:<%=EnumUtil.GetEnumElementPersianTitle((Gender)pattern.Gender) %></td>
                    <td class="caption" style="border: none">نقش:<%=EnumUtil.GetEnumElementPersianTitle((Role)pattern.Role) %></td>
                    <td class="caption" style="border: none">سطح دسترسی: <%=accesslevel %></td>
                </tr>
                <tr>
                    <td class="caption" style="border: none">وضعیت:<%=EnumUtil.GetEnumElementPersianTitle((UserActivityStatus)pattern.ActivityStatus) %></td>
                    <td class="caption" style="border: none">استان:<%=province %></td>
                    <td class="caption" style="border: none">شهرستان:<%=city %></td>
                </tr>
                <tr>
                    <td class="caption" style="border: none">کد پستی : <%=pattern.PostalCode %></td>
                   <td class="caption" style="border: none">آدرس : <%=pattern.Address %></td>
                </tr>
                <tr>
                    <%if (pattern.SignUpPersianDate.SearchMode != DateRangePattern.SearchType.Nothing)
                      { %>
                    <td class="caption" style="border: none">تاریخ عضویت : 
                        <%= EnumUtil.GetEnumElementPersianTitle((DateRangePattern.SearchType)pattern.SignUpPersianDate.SearchMode)%>
                        <%= pattern.SignUpPersianDate.HasDate ? pattern.SignUpPersianDate.Date : ""%>
                        <%= pattern.SignUpPersianDate.HasFromDate ? pattern.SignUpPersianDate.FromDate : ""%>
                        <%= pattern.SignUpPersianDate.HasToDate ? "و" + pattern.SignUpPersianDate.ToDate : ""%>
                    </td>
                    <%} %>
                     
                </tr>
            </table>
            <%  }
              else
              { %>
            <table border="0px" class="lsttbl">
                <tr class="thead" style="text-align: center;">
                    <th>لیست کامل کاربران</th>
                </tr>
            </table>
            <%}
            %>


            <table cellpadding="0" cellspacing="0">
                <tr class="thead">
                    <th>نام ونام خانوادگی</th>
                    <th>نام پدر</th>
                    <th>نقش</th>
                    <th>وضعیت</th>
                    <th>پست الکترونیک</th>
                    <th>کد ملی</th>
                    <th>شماره تماس</th>
                    <th>تلفن همراه</th>
                    <th>آدرس</th>
                </tr>
                <%foreach (User item in userList)
                  {
                      isAltRow = !isAltRow;
                %>
                <tr class="<%=(isAltRow)?"altrow":"row" %>">
                    <td><%=item.FullName %></td>
                    <td><%=item.FatherName %></td>
                    <td><%=EnumUtil.GetEnumElementPersianTitle((Role)item.AccessLevel.Role) %></td>
                    <td><%=EnumUtil.GetEnumElementPersianTitle((UserActivityStatus)item.ActivityStatus) %></td>
                    <td><%=item.Email %></td>
                    <td><%=item.NationalCode %></td>
                    <td><%=item.Tel %></td>
                    <td><%=item.Mobile %></td>
                    <td><%=item.Address %></td>
                </tr>
                <%}%>
            </table>


            <%}

              catch (Exception)
              {
                  Response.Redirect(GetRouteUrl("admin-user", null));
              }%>
        </div>
    </form>
</body>
</html>

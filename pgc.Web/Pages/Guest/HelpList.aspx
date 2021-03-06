﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Guest.master" AutoEventWireup="true" CodeFile="HelpList.aspx.cs" Inherits="Pages_Guest_HelpList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="<%#ResolveClientUrl("~/Pages/Guest/pgciziCss/content-common.css")%>" rel="stylesheet" type="text/css" media="screen" />
    <title>لیست راهنما - رستوران مستردیزی</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" Runat="Server">
    
    <div class="list-container">
        <asp:ObjectDataSource   ID="odsHelp" 
                                runat="server" 
                                EnablePaging="True"
                                SelectCountMethod="Help_Count" 
                                SelectMethod="Help_List"
                                TypeName="pgc.Business.General.HelpBusiness"
                                EnableViewState="false">
        </asp:ObjectDataSource>

        <asp:ListView ID="lsvHelp" runat="server" DataSourceID="odsHelp" EnableViewState="false">
              <ItemTemplate>
                  <div class="listItemHolder-singlerow">
                     <div class="listItemHolderTitleHolder">
                        <div class="BMitra listItemHolderTitle">
                            <a href="<%#GetRouteUrl("guest-helpdetail",new{id=Eval("ID")})%>"><%#Eval("Title") %></a>
                        </div>
                     </div>  
                  </div>
              </ItemTemplate>
         </asp:ListView>

         <!-- Pager -->
         <%if(dprHelp.TotalRowCount > dprHelp.MaximumRows) {%>
            <div class="fontClass pagination">
                <span class="pages-label">صفحات دیگر: </span> 
               <asp:DataPager ID="dprHelp" runat="server" PagedControlID="lsvHelp" PageSize="7" QueryStringField="page">
                   <Fields>
                      <asp:NextPreviousPagerField PreviousPageText="قبلی" ButtonCssClass="button prev" ShowNextPageButton="false"/>
                      <asp:TemplatePagerField><PagerTemplate><span class="pages"></PagerTemplate></asp:TemplatePagerField>
                          <asp:NumericPagerField ButtonCount="6" NumericButtonCssClass="page" NextPreviousButtonCssClass="page" CurrentPageLabelCssClass="current" />
                      <asp:TemplatePagerField><PagerTemplate></span></PagerTemplate></asp:TemplatePagerField>
                      <asp:NextPreviousPagerField NextPageText="بعدی" ButtonCssClass="button next" ShowPreviousPageButton="false"/>
                   </Fields>
               </asp:DataPager>
           </div>    
          <%} %>
    </div>

</asp:Content>


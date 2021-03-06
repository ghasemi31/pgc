﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Guest.master" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="Pages_User_UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%this.Title = (!string.IsNullOrEmpty(user.FullName)) ? "پروفایل من-" + user.FullName : ""; %>
    <link href="/assets/User/UserProfile.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphbdy" runat="Server">
    <section id="page">
        <section id="main-content">
            <div class="container">
                <div class="row">

                    <div class="col-lg-offset-1 col-md-offset-1 col-sm-offset-0 col-xs-offset-0 col-lg-10 col-md-10 col-sm-12 col-xs-12">
                        <div class="order-code">
                            <ul class="list-inline">
                                <li>حساب کاربری من </li>
                               
                            </ul>
                        </div>
                    </div>

                    <div class="col-lg-offset-1 col-md-offset-0 col-sm-offset-0 col-xs-offset-0 col-lg-10 col-md-12 col-sm-12 col-xs-12">
                        <div class="user-info">
                            <header>
                                <i class="fa fa-user" aria-hidden="true"></i>
                                <span>اطلاعات من</span>
                                <hr />
                            </header>
                            <div class="row">
                                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                    <div>
                                        <div>
                                            <div class="profile-userpic">
                                                <img src="/assets/Guest/Image/default-user-avatar.png" />
                                            </div>
                                            <div class="profile-usertitle">
                                                <div class="profile-usertitle-name"><%=(!string.IsNullOrEmpty(user.FullName))?user.FullName:"" %></div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-8 col-md-8 col-sm-6 col-xs-12" style="margin-top: 2em;">
                                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 profile-item">
                                        <span class="profile-title">نام و نام خانوادگی:  </span>
                                        <span><%=(!string.IsNullOrEmpty(user.FullName))?user.FullName:"" %></span>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 profile-item">
                                        <span class="profile-title">کد ملی:  </span>
                                        <span><%=(!string.IsNullOrEmpty(user.NationalCode))?user.NationalCode:"" %></span>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 profile-item">
                                        <span class="profile-title">نام پدر:  </span>
                                        <span><%=(!string.IsNullOrEmpty(user.FatherName))?user.FatherName:"" %></span>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 profile-item">
                                        <span class="profile-title">پست الکترونیک:  </span>
                                        <span><%=(!string.IsNullOrEmpty(user.Email))?user.Email:"" %></span>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 profile-item">
                                        <span class="profile-title">تلفن:  </span>
                                        <span><%=(!string.IsNullOrEmpty(user.Tel))?user.Tel:"" %></span>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 profile-item">
                                        <span class="profile-title">تلفن همراه:  </span>
                                        <span><%=(!string.IsNullOrEmpty(user.Mobile))?user.Mobile:"" %></span>
                                    </div>
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 profile-item">
                                        <span class="profile-title">آدرس:  </span>
                                        <span><%=(!string.IsNullOrEmpty(user.Address))?user.Address:"" %></span>
                                    </div>

                                </div>
                            </div>
                            <div class="row" id="profile-button">
                                <a class="btn-profile" href="<%=GetRouteUrl("user-gamelist",null) %>"><i class="fa fa-gamepad" aria-hidden="true"></i>بازی های من</a>
                                <a class="btn-profile" href="<%=GetRouteUrl("user-editprofile",null) %>"><i class="fa fa-pencil-square-o" aria-hidden="true"></i>ویرایش اطلاعات</a>
                                <a class="btn-profile" href="<%=GetRouteUrl("user-changepassword",null) %>"><i class="fa fa-key" aria-hidden="true"></i>تغییر کلمه عبور</a>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                </div>

            </div>

        </section>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphfoot" runat="Server">
</asp:Content>


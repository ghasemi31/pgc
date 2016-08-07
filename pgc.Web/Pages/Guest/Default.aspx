﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master/Guest.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Pages_Guest_Default" %>

<%@ Import Namespace="pgc.Model.Enums" %>
<%@ Import Namespace="kFrameWork.Business" %>

<asp:Content ID="c1" ContentPlaceHolderID="head" runat="Server">
    <link href="/assets/Plugin/OwlCarousel2-master/dist/assets/owl.carousel.min.css" rel="stylesheet" />
    <link href="/assets/Plugin/OwlCarousel2-master/dist/assets/owl.theme.default.min.css" rel="stylesheet" />
    <link href="/assets/Plugin/animate.css-master/animate.min.css" rel="stylesheet" />
    <link href="/assets/Guest/css/default.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphbdy" runat="Server">
    <!-- slider -->
    <input type="hidden" id="slider-time" value="<%=OptionBusiness.GetDouble(OptionKey.FullPageSliderTimer)%>" />
    <input type="hidden" id="speed-slider-time" value="<%=OptionBusiness.GetDouble(OptionKey.FullPageSpeedSlider)%>" />
    <input type="hidden" id="slider-transaction" value="<%=OptionBusiness.GetText(OptionKey.Slider_transitionStyle) %>" />
    <section style="direction:ltr">
        <%--<div id="main-slider" class="owl-carousel container-fluid">
            <%foreach (var item in DBusiness.GetMainSlider())
              {
                  var imgPath = ResolveClientUrl(item.ImgPath);
            %>
            <div class="mainSlider-item" style="background-image: url(<%=imgPath%>)"></div>
            <%} %>--%>
            <img class="width100" src="/assets/Guest/Image/FIFA-14.jpg" />
       <%-- </div>--%>
    </section>
    <!-- slider -->
    <section id="content" class="home clearfix">
        <!--begin game logo slider -->
        <section class="topBox">
            <div class="container">
                <div class="row margin-left-right-0">
                    <div id="game-slider" class="owl-carousel">
                        <div class="game-logo-item">
                            <img src="/assets/Guest/Image/fifa16-logo.png" />
                        </div>
                        <div class="game-logo-item">
                            <img src="/assets/Guest/Image/fifa16-logo.png" />
                        </div>
                        <div class="game-logo-item">
                            <img src="/assets/Guest/Image/fifa16-logo.png" />
                        </div>
                        <div class="game-logo-item">
                            <img src="/assets/Guest/Image/fifa16-logo.png" />
                        </div>
                        <div class="game-logo-item">
                            <img src="/assets/Guest/Image/fifa16-logo.png" />
                        </div>
                        <div class="game-logo-item">
                            <img src="/assets/Guest/Image/fifa16-logo.png" />
                        </div>
                        <div class="game-logo-item">
                            <img src="/assets/Guest/Image/fifa16-logo.png" />
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!--end game logo slider -->


        <!-- tabs -->
        <section id="pic-fixed" class="slice color3">
            <div class="container">
                <div class="row">
                    <div class="col-sm-5 col-md-5">
                        <img src="/assets/Guest/Image/IranPGC/Poster%20(1).jpg" />
                    </div>
                    <div class="col-sm-7 col-md-7">
                        <div class="row">
                            <img src="/assets/Guest/Image/IranPGC/05.png" />
                        </div>
                        <div id="" class="row">
                            <p>متن دلخواه متن دلخواه متن دلخواه متن دلخواه متن دلخواه متن دلخواه متن دلخواه متن دلخواه متن دلخواه متن دلخواه متن دلخواه متن دلخواه متن دلخواه متن دلخواه متن دلخواه متن دلخواه متن دلخواه متن دلخواه متن دلخواه متن دلخواه متن دلخواه متن دلخواه متن دلخواه متن دلخواه </p>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!-- tabs -->
        <!--bubbles--->
        <section class="slice color2  roundedShadow">
            <div class="container">
                <div class="row">
                    <div class="col-md-7 pgc-title">
                        <div class="row margin-left-right-0">
                            <h1>حامیان معنوی</h1>
                            <hr />
                            <div id="supporter-slider" class="owl-carousel">
                                <div class="supporter-item">
                                    <img src="/assets/Guest/Image/bonyad.png" />
                                </div>
                                <div class="supporter-item">
                                    <img src="/assets/Guest/Image/bonyad.png" />
                                </div>
                                <div class="supporter-item">
                                    <img src="/assets/Guest/Image/bonyad.png" />
                                </div>
                                <div class="supporter-item">
                                    <img src="/assets/Guest/Image/bonyad.png" />
                                </div>
                                <div class="supporter-item">
                                    <img src="/assets/Guest/Image/bonyad.png" />
                                </div>
                                <div class="supporter-item">
                                    <img src="/assets/Guest/Image/bonyad.png" />
                                </div>
                            </div>
                        </div>
                        <div class="row margin-left-right-0" style="margin-top: 2em;">
                            <h1>اسپانسرها</h1>
                            <hr />
                            <div id="sponsor-slider" class="owl-carousel">
                                <div class="sponsor=item">
                                    <img src="/assets/Guest/Image/samsung-logo.png" />
                                </div>
                                <div class="sponsor=item">
                                    <img src="/assets/Guest/Image/samsung-logo.png" />
                                </div>
                                <div class="sponsor=item">
                                    <img src="/assets/Guest/Image/samsung-logo.png" />
                                </div>
                                <div class="sponsor=item">
                                    <img src="/assets/Guest/Image/samsung-logo.png" />
                                </div>
                                <div class="sponsor=item">
                                    <img src="/assets/Guest/Image/samsung-logo.png" />
                                </div>
                            </div>
                        </div>

                    </div>
                    <div id="news" class="col-md-5 pgc-title">
                        <h1>آخرین اخبار</h1>
                        <hr />
                        <div id="news-slider" class="owl-carousel">
                            <%foreach (var item in DBusiness.GetLastNews())
                              {%>
                                  <div class="news-item">
                                <img alt="<%=item.Title %>" src="<%=(!string.IsNullOrEmpty(item.NewsPicPath))?ResolveClientUrl(item.NewsPicPath):"/assets/global/images/branch-default.jpg" %>?height=410&width=436&mode=cropandscale" />
                                <a href="javascript:;">
                                    <article class="news-detail">
                                        <h4><%=item.Title %></h4>
                                        <p><%=kFrameWork.Util.DateUtil.GetPersianDateWithTime(item.NewsDate) %></p>
                                        <p><%=item.Summary %></p>
                                    </article>
                                </a>
                            </div>
                              <%} %>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!--bubbles--->

    </section>
    <!-- content -->
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphfoot" runat="Server">
    <script src="/assets/Plugin/OwlCarousel2-master/dist/owl.carousel.min.js"></script>
    <script src="/assets/Guest/js/default.js"></script>
</asp:Content>

﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mrd.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class mrdEntities : DbContext
    {
        public mrdEntities()
            : base("name=mrdEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Option> Options { get; set; }
        public DbSet<OptionCategory> OptionCategories { get; set; }
        public DbSet<OptionLookup> OptionLookups { get; set; }
        public DbSet<OptionLookupDetail> OptionLookupDetails { get; set; }
        public DbSet<AccessLevel> AccessLevels { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<PanelPage> PanelPages { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Sample> Samples { get; set; }
        public DbSet<UserMessage> UserMessages { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Help> Helps { get; set; }
        public DbSet<DynPage> DynPages { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<IndexSlide> IndexSlides { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<GalleryPic> GalleryPics { get; set; }
        public DbSet<BranchPic> BranchPics { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<PollChoise> PollChoises { get; set; }
        public DbSet<PollResult> PollResults { get; set; }
        public DbSet<LotteryDetail> LotteryDetails { get; set; }
        public DbSet<Lottery> Lotteries { get; set; }
        public DbSet<LotteryWiner> LotteryWiners { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<SystemEventVariable> SystemEventVariables { get; set; }
        public DbSet<EmailSendAttempt> EmailSendAttempts { get; set; }
        public DbSet<ReceivedMessage> ReceivedMessages { get; set; }
        public DbSet<SentEmailBlock> SentEmailBlocks { get; set; }
        public DbSet<SentSMS> SentSMSList { get; set; }
        public DbSet<SMSSendAttempt> SMSSendAttempts { get; set; }
        public DbSet<SystemEvent> SystemEvents { get; set; }
        public DbSet<ExceptionLog> ExceptionLogs { get; set; }
        public DbSet<UserComment> UserComments { get; set; }
        public DbSet<PrivateNo> PrivateNoes { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<OnlinePayment> OnlinePayments { get; set; }
        public DbSet<BuyBasket> BuyBaskets { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<BranchPayment> BranchPayments { get; set; }
        public DbSet<BranchTransaction> BranchTransactions { get; set; }
        public DbSet<BranchOrderTitleGroup> BranchOrderTitleGroups { get; set; }
        public DbSet<Branch_BranchOrderTitle> Branch_BranchOrderTitle { get; set; }
        public DbSet<BranchLackOrder> BranchLackOrders { get; set; }
        public DbSet<BranchLackOrderDetail> BranchLackOrderDetails { get; set; }
        public DbSet<BranchOrderDetail> BranchOrderDetails { get; set; }
        public DbSet<BranchOrderShipmentState> BranchOrderShipmentStates { get; set; }
        public DbSet<BranchReturnOrder> BranchReturnOrders { get; set; }
        public DbSet<BranchReturnOrderDetail> BranchReturnOrderDetails { get; set; }
        public DbSet<BranchOrder> BranchOrders { get; set; }
        public DbSet<BranchFinanceLog> BranchFinanceLogs { get; set; }
        public DbSet<SiteMapCat> SiteMapCats { get; set; }
        public DbSet<SiteMapItem> SiteMapItems { get; set; }
        public DbSet<SideMenuCat> SideMenuCats { get; set; }
        public DbSet<SideMenuItem> SideMenuItems { get; set; }
        public DbSet<MainMenu> MainMenus { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<RandomImg> RandomImgs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BranchRequest> BranchRequests { get; set; }
        public DbSet<SocialIcon> SocialIcons { get; set; }
        public DbSet<BranchContact> BranchContacts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Circular> Circulars { get; set; }
        public DbSet<BranchOrderTitle> BranchOrderTitles { get; set; }
        public DbSet<OnlinePaymentList> OnlinePaymentLists { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<SystemEventAction> SystemEventActions { get; set; }
        public DbSet<OccuredSystemEvent> OccuredSystemEvents { get; set; }
        public DbSet<AndroidSetting> AndroidSettings { get; set; }
    }
}

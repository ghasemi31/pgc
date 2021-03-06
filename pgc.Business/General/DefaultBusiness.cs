﻿using kFrameWork.UI;
using pgc.Model;
using pgc.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pgc.Business.General
{
    public class DefaultBusiness
    {
        pgcEntities db = new pgcEntities();

       

        public IQueryable<News> GetLastNews()
        {
           return db.News.Where(n => n.Status == (int)NewsStatus.Show).OrderByDescending(n => n.NewsDate).Take(kFrameWork.Business.OptionBusiness.GetInt(OptionKey.NewsNumberInHomePage));
        }

        public string GetRandomImage()
        {
            IQueryable<MainSlider> list = db.MainSliders.Where(f => f.IsVisible);
            int count = list.Count();
            int index = new Random().Next(count);
            return list.OrderBy(r => r.ID).Skip(index).FirstOrDefault().ImgPath;
        }

        

        public List<SocialIcon> GetSocialIcon()
        {
            return db.SocialIcons.Where(s=>s.IsVisible).OrderBy(s => s.DispOrder).ToList();
        }

        public IQueryable<MainSlider> GetMainSlider()
        {
            return db.MainSliders.Where(r => r.IsVisible).OrderBy(o => o.DispOrder);
        }

        public IQueryable<Game> GetGameLogos()
        {
            return db.Games.Where(r => !string.IsNullOrEmpty(r.LogoPath)).OrderBy(o => o.DispOrder);
        }
        public IQueryable<Game> GetGameList()
        {
            return db.Games.OrderBy(o => o.DispOrder);
        }


        public IQueryable<Advertisment> GetAdvertisment()
        {
            return db.Advertisments.OrderBy(f => f.DispOrder);
        }
    }
}

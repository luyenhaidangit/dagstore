using DAGStore.Model.Models;
using DAGStore.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Text;
using System.Web;
using System.Web.Mvc;


namespace DAGStore.Web.Controllers
{
    public class NewsController : Controller
    {
        INewsService _NewsService;
        ITagService _TagService;
        INewsTagService _NewsTagService;

        public NewsController(INewsService NewsService, ITagService TagService, INewsTagService NewsTagService)
        {
            this._NewsService = NewsService;
            this._TagService = TagService;
            this._NewsTagService = NewsTagService;
        }

        // GET: category
        public JsonResult GetAll()
        {
            var listNews = _NewsService.GetAll();

            return Json(listNews, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByID(int id)
        {
            var News = _NewsService.GetByID(id);

            return Json(News, JsonRequestBehavior.AllowGet);
        }

        public string ToUnsignString(string input)
        {
            input = input.Trim();
            for (int i = 0x20; i < 0x30; i++)
            {
                input = input.Replace(((char)i).ToString(), " ");
            }
            input = input.Replace(".", "-");
            input = input.Replace(" ", "-");
            input = input.Replace(",", "-");
            input = input.Replace(";", "-");
            input = input.Replace(":", "-");
            input = input.Replace("  ", "-");
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string str = input.Normalize(NormalizationForm.FormD);
            string str2 = regex.Replace(str, string.Empty).Replace('đ', 'd').Replace('Đ', 'D');
            while (str2.IndexOf("?") >= 0)
            {
                str2 = str2.Remove(str2.IndexOf("?"), 1);
            }
            while (str2.Contains("--"))
            {
                str2 = str2.Replace("--", "-").ToLower();
            }
            return str2;
        }

        [HttpPost]
        public JsonResult Create(News News)
        {
            News.CreateOn = DateTime.Now;
            _NewsService.Add(News);
            _NewsService.SaveChanges();

            if (!string.IsNullOrEmpty(News.Tag))
            {
                string[] tags = News.Tag.Split(',');
                for (var i = 0; i < tags.Length; i++)
                {
                    //var tagId = StringHelper.ToUnsignString(tags[i]);
                    var tagId = ToUnsignString(tags[i]);
                    if (_TagService.GetAll().ToList().Count(x => x.ID == tagId) == 0)
                    {
                        Tag tag = new Tag();
                        tag.ID = tagId;
                        tag.Name = tags[i];
                        tag.Type = "News";
                        _TagService.Add(tag);
                        _TagService.SaveChanges();
                    }

                    NewsTag productTag = new NewsTag();
                    productTag.NewsID = News.ID;
                    productTag.TagID = tagId;
                    _NewsTagService.Add(productTag);
                    _NewsTagService.SaveChanges();
                }
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public JsonResult Update(News News)
        {
            _NewsService.Update(News);
            _NewsService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            bool oldNews = _NewsService.Delete(id);
            _NewsService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        

    }
}
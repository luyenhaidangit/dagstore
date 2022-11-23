using DAGStore.Model.Models;
using DAGStore.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace DAGStore.Web.Controllers
{
    public class NewsController : Controller
    {
        INewsService _NewsService;

        public NewsController(INewsService NewsService)
        {
            this._NewsService = NewsService;
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

        [HttpPost]
        public JsonResult Create(News News)
        {
            _NewsService.Add(News);
            _NewsService.SaveChanges();
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
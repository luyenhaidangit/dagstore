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
    public class NewsTagController : Controller
    {
        INewsTagService _NewsTagService;

        public NewsTagController(INewsTagService NewsTagService)
        {
            this._NewsTagService = NewsTagService;
        }

        // GET: category
        public JsonResult GetAll()
        {
            var listNewsTag = _NewsTagService.GetAll();

            return Json(listNewsTag, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByID(int id)
        {
            var NewsTag = _NewsTagService.GetByID(id);

            return Json(NewsTag, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(NewsTag NewsTag)
        {
            _NewsTagService.Add(NewsTag);
            _NewsTagService.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public JsonResult Update(NewsTag NewsTag)
        {
            _NewsTagService.Update(NewsTag);
            _NewsTagService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            bool oldNewsTag = _NewsTagService.Delete(id);
            _NewsTagService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}
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
    public class TagController : Controller
    {
        ITagService _TagService;

        public TagController(ITagService TagService)
        {
            this._TagService = TagService;
        }

        // GET: category
        public JsonResult GetAll()
        {
            var listTag = _TagService.GetAll();

            return Json(listTag, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByID(int id)
        {
            var Tag = _TagService.GetByID(id);

            return Json(Tag, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(Tag Tag)
        {
            _TagService.Add(Tag);
            _TagService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public JsonResult Update(Tag Tag)
        {
            _TagService.Update(Tag);
            _TagService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            bool oldTag = _TagService.Delete(id);
            _TagService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}
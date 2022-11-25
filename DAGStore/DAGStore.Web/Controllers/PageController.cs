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
    public class PageController : Controller
    {
        IPageService _PageService;

        public PageController(IPageService PageService)
        {
            this._PageService = PageService;
        }

        // GET: category
        public JsonResult GetAll()
        {
            var listPage = _PageService.GetAll();

            return Json(listPage, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByID(int id)
        {
            var Page = _PageService.GetByID(id);

            return Json(Page, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(Page Page)
        {
            _PageService.Add(Page);
            _PageService.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public JsonResult Update(Page Page)
        {
            _PageService.Update(Page);
            _PageService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            bool oldPage = _PageService.Delete(id);
            _PageService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}
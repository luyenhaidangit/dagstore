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
    public class SuggestProductController : Controller
    {
        ISuggestProductService _SuggestProductService;

        public SuggestProductController(ISuggestProductService SuggestProductService)
        {
            this._SuggestProductService = SuggestProductService;
        }

        // GET: category
        public JsonResult GetAll()
        {
            var listSuggestProduct = _SuggestProductService.GetAll();

            return Json(listSuggestProduct, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByID(int id)
        {
            var SuggestProduct = _SuggestProductService.GetByID(id);

            return Json(SuggestProduct, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(SuggestProduct SuggestProduct)
        {
            _SuggestProductService.Add(SuggestProduct);
            _SuggestProductService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public JsonResult Update(SuggestProduct SuggestProduct)
        {
            _SuggestProductService.Update(SuggestProduct);
            _SuggestProductService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            bool oldSuggestProduct = _SuggestProductService.Delete(id);
            _SuggestProductService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}
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
    public class SuggestController : Controller
    {
        ISuggestService _SuggestService;
        ISuggestProductService _SuggestProductService;

        public SuggestController(ISuggestService SuggestService, ISuggestProductService SuggestProductService)
        {
            this._SuggestService = SuggestService;
            this._SuggestProductService = SuggestProductService;
        }

        // GET: category
        public JsonResult GetAll()
        {
            var listSuggest = _SuggestService.GetAll();

            return Json(listSuggest, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByID(int id)
        {
            var Suggest = _SuggestService.GetByID(id);

            return Json(Suggest, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(Suggest Suggest)
        {
            _SuggestService.Add(Suggest);
            _SuggestService.SaveChanges();
            foreach (var SuggestProduct in Suggest.SuggestProducts)
            {
                SuggestProduct.SuggestID = Suggest.ID;
                _SuggestProductService.Add(SuggestProduct);
            }
            _SuggestProductService.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public JsonResult Update(Suggest Suggest)
        {
            _SuggestService.Update(Suggest);
            _SuggestService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            bool oldSuggest = _SuggestService.Delete(id);
            _SuggestService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}
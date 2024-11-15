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
    public class VariationOptionController : Controller
    {
        IVariationOptionService _VariationOptionService;

        public VariationOptionController(IVariationOptionService VariationOptionService)
        {
            this._VariationOptionService = VariationOptionService;
        }

        // GET: category
        public JsonResult GetAll()
        {
            var listVariationOption = _VariationOptionService.GetAll();

            return Json(listVariationOption, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetVariationOptionByVariation(int id)
        {
            var result = _VariationOptionService.GetVariationOptionByVariation(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByID(int id)
        {
            var VariationOption = _VariationOptionService.GetByID(id);

            return Json(VariationOption, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(VariationOption VariationOption)
        {
            _VariationOptionService.Add(VariationOption);
            _VariationOptionService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public JsonResult Update(VariationOption VariationOption)
        {
            _VariationOptionService.Update(VariationOption);
            _VariationOptionService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            bool oldVariationOption = _VariationOptionService.Delete(id);
            _VariationOptionService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}
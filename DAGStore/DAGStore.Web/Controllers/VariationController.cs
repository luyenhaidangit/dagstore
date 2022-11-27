using DAGStore.Model.Models;
using DAGStore.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace DAGStore.Web.Controllers
{
    public class VariationController : Controller
    {
        IVariationService _VariationService;
        IVariationOptionService _VariationOptionService;

        public VariationController(IVariationService VariationService,IVariationOptionService VariationOptionService)
        {
            this._VariationService = VariationService;
            this._VariationOptionService = VariationOptionService;
        }

        // GET: category
        public JsonResult GetAll()
        {
            var listVariation = _VariationService.GetAll();

            var result = from l in listVariation
                         select new
                         {
                             CategoryID = l.CategoryID,
                             ID = l.ID,
                             Name = l.Name,
                             Option = _VariationOptionService.GetVariationOptionByVariation(l.ID),
                         };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByID(int id)
        {
            var Variation = _VariationService.GetByID(id);

            return Json(Variation, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(Variation Variation)
        {
            _VariationService.Add(Variation);
            _VariationService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public JsonResult Update(Variation Variation)
        {
            _VariationService.Update(Variation);
            _VariationService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            bool oldVariation = _VariationService.Delete(id);
            _VariationService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}
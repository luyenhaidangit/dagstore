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
    public class SliderItemController : Controller
    {
        ISliderItemService _SliderItemService;

        public SliderItemController(ISliderItemService SliderItemService)
        {
            this._SliderItemService = SliderItemService;
        }

        // GET: category
        public JsonResult GetAll()
        {
            var listSliderItem = _SliderItemService.GetAll();

            return Json(listSliderItem, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByID(int id)
        {
            var SliderItem = _SliderItemService.GetByID(id);

            return Json(SliderItem, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(SliderItem SliderItem)
        {
            _SliderItemService.Add(SliderItem);
            _SliderItemService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public JsonResult Update(SliderItem SliderItem)
        {
            _SliderItemService.Update(SliderItem);
            _SliderItemService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            bool oldSliderItem = _SliderItemService.Delete(id);
            _SliderItemService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}
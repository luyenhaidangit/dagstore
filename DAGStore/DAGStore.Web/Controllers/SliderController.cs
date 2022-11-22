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
    [Authorize]
    public class SliderController : Controller
    {
        ISliderService _SliderService;
        ISliderItemService _SliderItemService;

        public SliderController(ISliderService SliderService, ISliderItemService sliderItemService)
        {
            this._SliderService = SliderService;
            this._SliderItemService = sliderItemService;
        }

        // GET: category
        public JsonResult GetAll()
        {
            var listSlider = _SliderService.GetAll();

            return Json(listSlider, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByID(int id)
        {
            var Slider = _SliderService.GetByID(id);

            return Json(Slider, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(Slider Slider)
        {
            _SliderService.Add(Slider);
            _SliderService.SaveChanges();
            foreach (var sliderItem in Slider.SliderItems)
            {
                sliderItem.SliderID = Slider.ID;
                _SliderItemService.Add(sliderItem);
            }
            _SliderItemService.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public JsonResult Update(Slider Slider)
        {
            _SliderService.Update(Slider);
            _SliderService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            bool oldSlider = _SliderService.Delete(id);
            _SliderService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}
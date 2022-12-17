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
            var listSlider = _SliderService.GetAll().ToList();
            var result = from s in listSlider
                         select new
                         {
                             ID = s.ID,
                             Title = s.Title,
                             Position = s.Position,
                             TypeSlider = s.TypeSlider,
                             Page = s.Page,
                             BackgroundColor = s.BackgroundColor,
                             DisplayOrder = s.DisplayOrder,
                             Status = s.Status,
                             SliderItems = _SliderItemService.GetAll().ToList().Where(x => x.SliderID == s.ID),
                         };


            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public JsonResult Update(Slider slider)
        {
            _SliderService.Update(slider);
            _SliderService.SaveChanges();

            var sliderItems = _SliderItemService.GetAll().Where(x => x.SliderID == slider.ID);
            foreach (var item in sliderItems)
            {
                _SliderItemService.Delete(item.ID);
            }
            _SliderItemService.SaveChanges();
            foreach (var importBillDetail in slider.SliderItems)
            {
                importBillDetail.SliderID = slider.ID;
                importBillDetail.Slider = null;
                _SliderItemService.Add(importBillDetail);
            }
            _SliderItemService.SaveChanges();
          
            return Json(true, JsonRequestBehavior.AllowGet);
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

        //[HttpPut]
        //public JsonResult Update(Slider Slider)
        //{
        //    _SliderService.Update(Slider);
        //    _SliderService.SaveChanges();

        //    return Json(true, JsonRequestBehavior.AllowGet);
        //}

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            bool oldSlider = _SliderService.Delete(id);
            _SliderService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}
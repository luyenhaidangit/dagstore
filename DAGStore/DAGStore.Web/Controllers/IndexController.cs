using DAGStore.Model.Models;
using DAGStore.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace DAGStore.Web.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

        IProductService _productService;
        ISliderService _sliderService;
        ISliderItemService _sliderItemService;

        public IndexController(IProductService productService,ISliderService sliderService,ISliderItemService sliderItemService)
        {
            _productService = productService;
            _sliderService = sliderService;
            _sliderItemService = sliderItemService;
        }

        public JsonResult GetProductsNewShowHomePage()
        {
            var products = _productService.GetProductsNewShowHomePage().ToList();
            return Json(products,JsonRequestBehavior.AllowGet);
        }

        public JsonResult ShowSlider()
        {
            var slider = _sliderService.GetAll().ToList();
            var sliderItem = _sliderItemService.GetAll().ToList();

            var result = from s in slider
                         where s.Status == true
                         orderby s.DisplayOrder descending
                         select new
                         {
                             ID = s.ID,
                             Title = s.Title,
                             Position = s.Position,
                             TypeSlider = s.TypeSlider,
                             Page = s.Page,
                             BackgroundColor = s.BackgroundColor,
                             SliderItems = sliderItem.Where(x => x.SliderID == s.ID).OrderByDescending(x=>x.DisplayOrder),
                         };
            
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
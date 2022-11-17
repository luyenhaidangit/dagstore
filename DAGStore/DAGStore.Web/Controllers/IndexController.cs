using DAGStore.Model.Models;
using DAGStore.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Xml.Linq;

namespace DAGStore.Web.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

        ICategoryService _categoryService;
        IProductService _productService;
        ISliderService _sliderService;
        ISliderItemService _sliderItemService;
        ISuggestService _suggestService;
        ISuggestProductService _suggestProductService;
        IEventService _eventService;

        public IndexController(IEventService eventService ,IProductService productService,ISliderService sliderService,ISliderItemService sliderItemService,ICategoryService categoryService,ISuggestService suggestService,ISuggestProductService suggestProductService)
        {
            _productService = productService;
            _sliderService = sliderService;
            _sliderItemService = sliderItemService;
            _categoryService = categoryService;
            _suggestService = suggestService;
            _suggestProductService = suggestProductService;
            _eventService = eventService;
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

        public JsonResult ShowCategoryNavigation()
        {
            var categorys = _categoryService.GetAll().ToList();

            var result = from c in categorys
                         where c.Published == true && c.ParentCategoryID == 0
                         orderby c.DisplayOrder descending
                         select new
                         {
                             ID = c.ID,
                             ParentCategoryID = c.ParentCategoryID,
                             Name = c.Name,
                             PicturePath = c.PicturePath,
                             CategoryChild = (from c1 in categorys
                                             where c1.ParentCategoryID == c.ID && c1.Published == true
                                             orderby c1.DisplayOrder descending
                                             select new
                                             {
                                                 ID = c1.ID,
                                                 ParentCategoryID = c1.ParentCategoryID,
                                                 Name = c1.Name,
                                                 PicturePath = c1.PicturePath,
                                             }).Take(10),
                         };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSuggests()
        {
            var suggest = _suggestService.GetAll().ToList();
            var suggestproduct = _suggestProductService.GetAll().ToList();
            var product = _productService.GetAll().ToList();

            var result = from s in suggest
                         where s.Status == true && s.ShowOnHomePage == true
                         orderby s.DisplayOrder descending
                         select new
                         {
                             ID = s.ID,
                             Title = s.Title,
                             ImagePath = s.ImagePath,
                             TextColor = s.TextColor,
                             Type = s.Type,
                             BackgroundColor = s.BackgroundColor,
                             SuggestProducts = _productService.GetSuggestProduct(s.ID),
                         };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEvents()
        {
            var even = _eventService.GetAll().ToList();

            var result = from e in even
                         where e.Status == true && e.ShowOnHomePage == true
                         orderby e.DisplayOrder descending
                         select new
                         {
                             ID = e.ID,
                             Title = e.Title,
                             ImagePath = e.ImagePath,
                         };

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
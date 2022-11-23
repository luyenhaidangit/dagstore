using DAGStore.Model.Models;
using DAGStore.Service;
using Newtonsoft.Json;
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
        IDiscountService _discountService;
        IEventService _eventService;
        IProductDiscountService _productDiscountService;
        INewsService _newsService;

        public IndexController(INewsService newsService,IProductDiscountService productDiscountService,IDiscountService discountService,IEventService eventService ,IProductService productService,ISliderService sliderService,ISliderItemService sliderItemService,ICategoryService categoryService,ISuggestService suggestService,ISuggestProductService suggestProductService)
        {
            _productService = productService;
            _sliderService = sliderService;
            _sliderItemService = sliderItemService;
            _categoryService = categoryService;
            _suggestService = suggestService;
            _suggestProductService = suggestProductService;
            _eventService = eventService;
            _discountService = discountService;
            _productDiscountService = productDiscountService;
            _newsService = newsService;
        }

        public JsonResult GetProductsNewShowHomePage()
        {
            var products = _productService.GetProductsNewShowHomePage().ToList();
            return Json(products,JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProductsDiscountShowHomePage()
        {
            var discounts = _discountService.GetAll();
            var productDiscounts = _productDiscountService.GetAll();
            var products = _productService.GetAll();
            products = products.Reverse();
            var result = (from p in products
                          where p.Published == true
                          select new
                          {
                              IDProduct = p.ID,
                              NameProduct = p.Name,
                              PriceProduct = p.SellPriceActual,
                              ImageProduct = p.PicturePath,
                              DescriptionProduct = p.ShortDescriptionEndow,
                              Discount = _discountService.GetDiscountByProduct(p.ID).Take(2),
                              DiscountRate = ((int)(100 - ((p.SellPriceActual/p.SellPrice)*100))),
                          }).OrderByDescending(p=> p.DiscountRate).Take(20); 
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProductsViewCountShowHomePage()
        {
            var discounts = _discountService.GetAll();
            var productDiscounts = _productDiscountService.GetAll();
            var products = _productService.GetAll();
            products = products.Reverse();
            var result = (from p in products
                          where p.Published == true
                          select new
                          {
                              IDProduct = p.ID,
                              NameProduct = p.Name,
                              PriceProduct = p.SellPriceActual,
                              ImageProduct = p.PicturePath,
                              DescriptionProduct = p.ShortDescriptionEndow,
                              Discount = _discountService.GetDiscountByProduct(p.ID).Take(2),
                              ViewCount = p.ViewCount,
                              DiscountRate = ((int)(100 - ((p.SellPriceActual / p.SellPrice) * 100))),
                          }).OrderByDescending(p => p.ViewCount).Take(20);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProducts()
        {
            var products = _productService.GetAll().Where(x => x.Published == true).ToList();

            var result = from product in products
                         select new
                         {
                             ID = product.ID,
                             Name = product.Name,
                             PicturePath = product.PicturePath,
                             ShortDescription = product.ShortDescription,
                             FullDescription = product.FullDescription,
                             ShortDescriptionEndow = product.ShortDescriptionEndow,
                             CostPrice = product.CostPrice,
                             SellPrice = product.SellPrice,
                             SellPriceActual = product.SellPriceActual,
                             DiscountRate = ((int)(100 - ((product.SellPriceActual / product.SellPrice) * 100))),
                             InventoryQuantity = product.InventoryQuantity,
                             DisplayOrder = product.DisplayOrder,
                         };

            return Json(result, JsonRequestBehavior.AllowGet);
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
                             Description = s.Description,
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

        public JsonResult GetCategories()
        {
            var categories = _categoryService.GetAll().ToList();

            var result = from c in categories
                         where c.Published == true
                         orderby c.DisplayOrder descending
                         select c;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDiscounts()
        {
            var discounts = _discountService.GetAll().ToList();

            var result = from c in discounts
                         select c;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetNews()
        {
            var news = _newsService.GetAll().ToList();

            var result = from c in news
                         select c;

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSearchNavigation(string key)
        {
            var products = _productService.GetAll().ToList();

            var result = from product in products
                         where product.Name.ToLower().Contains(key.ToLower())
                         select new
                         {
                             ID = product.ID,
                             Name = product.Name,
                             PicturePath = product.PicturePath,
                             ShortDescription = product.ShortDescription,
                             FullDescription = product.FullDescription,
                             ShortDescriptionEndow = product.ShortDescriptionEndow,
                             CostPrice = product.CostPrice,
                             SellPrice = product.SellPrice,
                             SellPriceActual = product.SellPriceActual,
                             DiscountRate = ((int)(100 - ((product.SellPriceActual / product.SellPrice) * 100))),
                             InventoryQuantity = product.InventoryQuantity,
                             DisplayOrder = product.DisplayOrder,
                         };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
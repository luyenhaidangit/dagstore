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
    public class ProductController : Controller
    {
        IProductService _productService;
        ICategoryService _categoryService;
        IBrandService _brandService;

        public ProductController(IProductService menuRecordService,ICategoryService categoryService,IBrandService brandService)
        {
            this._productService = menuRecordService;
            this._categoryService = categoryService;
            this._brandService = brandService;
        }
        // GET: MenuRecord
        public JsonResult GetAll()
        {
            var listProduct = _productService.GetAll();

            return Json(listProduct, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetData()
        {
            var listProduct = _productService.GetData();

            return Json(listProduct, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByID(int id)
        {
            var menuRecord = _productService.GetByID(id);

            return Json(menuRecord, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetInfo(int id)
        {
            var menuRecord = _productService.GetInfo(id);

            return Json(menuRecord, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(Product menuRecord)
        {
            _productService.Add(menuRecord);
            _productService.SaveChanges();

            return Json(menuRecord, JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public JsonResult Update(Product product)
        {
            _productService.Update(product);
            _productService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            bool oldProduct = _productService.Delete(id);
            _productService.SaveChanges();

            return Json(oldProduct, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProductDetail(int id)
        {
            var product = _productService.GetAll().ToList();

            var result = (from p in product
                         where p.ID == id
                         select new
                         {
                             ID = p.ID,
                             Name = p.Name,
                             CategoryID = p.CategoryID,
                             CategoryName = _categoryService.GetByID(p.CategoryID).Name,
                             BrandID = p.BrandID,
                             BrandName = _brandService.GetByID(p.BrandID).Name,
                             PicturePath = p.PicturePath,
                             ShortDescription = p.ShortDescription,
                             ShortDescriptionEndow = p.ShortDescriptionEndow,
                             FullDescription = p.FullDescription,
                             CostPrice = p.CostPrice,
                             SellPrice = p.SellPrice,
                             SellPriceActual= p.SellPriceActual,
                             InventoryQuantity = p.InventoryQuantity,
                             MinimumInventoryQuantity = p.MinimumInventoryQuantity,
                             MaximumInventoryQuantity = p.MaximumInventoryQuantity,
                             DisplayOrder = p.DisplayOrder,
                             Published = p.Published,
                             Deleted = p.Deleted,
                         }).FirstOrDefault();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
﻿using DAGStore.Model.Models;
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
        IDiscountService _discountService;
        IProductDiscountService _productDiscountService;
        IImageProductService _imageProductService;

        public ProductController(IImageProductService imageProductService,IProductDiscountService productDiscountService,IDiscountService discountService,IProductService menuRecordService,ICategoryService categoryService,IBrandService brandService)
        {
            this._productService = menuRecordService;
            this._categoryService = categoryService;
            this._brandService = brandService;
            this._discountService = discountService;
            this._productDiscountService = productDiscountService;
            this._imageProductService = imageProductService;
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
        public JsonResult Create(Product product)
        {
            _productService.Add(product);
            _productService.SaveChanges();
            product.ImageProducts = product.ImageProducts ?? new List<ImageProduct>();
            foreach (var imageProduct in product.ImageProducts)
            {
                imageProduct.ProductID = product.ID;
                _imageProductService.Add(imageProduct);
            }
            _imageProductService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public JsonResult Create(Product menuRecord)
        //{ 
        //    _productService.Add(menuRecord);
        //    _productService.SaveChanges();
        //    foreach(var item in menuRecord.ImageProducts)
        //    {
        //        item.ProductID = menuRecord.ID;
        //        _imageProductService.Add(item);
        //    }
        //    _imageProductService.SaveChanges();

        //    return Json(menuRecord, JsonRequestBehavior.AllowGet);
        //}

        [HttpPut]
        public JsonResult Update(Product product)
        {
            _productService.Update(product);
            _productService.SaveChanges();

            var imageProduct = _imageProductService.GetImageProductByProduct(product.ID);
            imageProduct = imageProduct ?? new List<ImageProduct>();
            foreach (var item in imageProduct)
            {
                _imageProductService.Delete(item.ID);
            }
            _imageProductService.SaveChanges();

            product.ImageProducts = product.ImageProducts ?? new List<ImageProduct>();
            foreach (var item in product.ImageProducts)
            {
                item.Product = null;
            }
            foreach (var item in product.ImageProducts)
            {
                item.ProductID = product.ID;
                _imageProductService.Add(item);
            }
            _imageProductService.SaveChanges();


            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public JsonResult IncreaseViewCount(int id)
        {
            var product = _productService.GetByID(id);
            product.ViewCount += 1;
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
                             ViewCount = p.ViewCount,
                             ImageProducts = _imageProductService.GetImageProductByProduct(p.ID),
                         }).FirstOrDefault();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #region Product Category
        public JsonResult GetProductsByCategory(int id)
        {
            var discounts = _discountService.GetAll();
            var productDiscounts = _productDiscountService.GetAll();
            var products = _productService.GetAll();
            products = products.Reverse();
            var result = (from p in products
                          where p.Published == true && p.CategoryID == id
                          select new
                          {
                              IDProduct = p.ID,
                              BrandProduct = _brandService.GetByID(p.BrandID),
                              NameProduct = p.Name,
                              PriceProduct = p.SellPriceActual,
                              ImageProduct = p.PicturePath,
                              DescriptionProduct = p.ShortDescriptionEndow,
                              Discount = _discountService.GetDiscountByProduct(p.ID).Take(2),
                              DiscountRate = ((int)(100 - ((p.SellPriceActual / p.SellPrice) * 100))),
                          }).OrderByDescending(p => p.DiscountRate).Take(20);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
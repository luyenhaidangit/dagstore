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

        public ProductController(IProductService menuRecordService)
        {
            this._productService = menuRecordService;
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

    }
}
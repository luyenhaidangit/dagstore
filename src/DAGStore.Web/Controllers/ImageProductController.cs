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
    public class ImageProductController : Controller
    {
        IImageProductService _ImageProductService;

        public ImageProductController(IImageProductService ImageProductService)
        {
            this._ImageProductService = ImageProductService;
        }

        // GET: category
        public JsonResult GetAll()
        {
            var listImageProduct = _ImageProductService.GetAll();

            return Json(listImageProduct, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByID(int id)
        {
            var ImageProduct = _ImageProductService.GetByID(id);

            return Json(ImageProduct, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(ImageProduct ImageProduct)
        {
            _ImageProductService.Add(ImageProduct);
            _ImageProductService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public JsonResult Update(ImageProduct ImageProduct)
        {
            _ImageProductService.Update(ImageProduct);
            _ImageProductService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            bool oldImageProduct = _ImageProductService.Delete(id);
            _ImageProductService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetImageProductByProduct(int id)
        {
            return Json(_ImageProductService.GetImageProductByProduct(id).ToList(), JsonRequestBehavior.AllowGet);
        }

    }
}
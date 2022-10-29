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
    public class BrandController : Controller
    {
        IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            this._brandService = brandService;
        }

        // GET: category
        public JsonResult GetAll()
        {
            var listBrand = _brandService.GetAll();

            return Json(listBrand, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByID(int id)
        {
            var brand = _brandService.GetByID(id);

            return Json(brand, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(Brand brand)
        {
            _brandService.Add(brand);
            _brandService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public JsonResult Update(Brand brand)
        {
            _brandService.Update(brand);
            _brandService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            bool oldBrand = _brandService.Delete(id);
            _brandService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetData()
        {
            var result = _brandService.GetData();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
using DAGStore.Model.Models;
using DAGStore.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace DAGStore.Web.Controllers
{
    public class ProductDiscontController : Controller
    {
        // GET: ProductDiscont
        public ActionResult Index()
        {
            return View();
        }

        IProductDiscountService _productDiscountService;

        public ProductDiscontController(IProductDiscountService productDiscountService)
        {
            this._productDiscountService = productDiscountService;
        }

        // GET: Discount
        public JsonResult GetAll()
        {
            var listProductDiscount = _productDiscountService.GetAll().ToList();

            return Json(listProductDiscount, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(ProductDiscount productDiscount)
        {
            _productDiscountService.Add(productDiscount);
            _productDiscountService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult DeleteMultiByProductID(int id)
        {
            _productDiscountService.DeleteMultiByProductID(id);
            _productDiscountService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
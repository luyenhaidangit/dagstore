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
    [Authorize]
    public class DiscountController : Controller
    {

        IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            this._discountService = discountService;
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: Discount
        public JsonResult GetAll()
        {
            var listDiscount = _discountService.GetAll();

            return Json(listDiscount, JsonRequestBehavior.AllowGet);
        }

        // GET: Discount
        public JsonResult GetListDiscountProduct()
        {
            var listProductDiscount = _discountService.GetListProductDiscount().ToList();

            return Json(listProductDiscount, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDiscountByProduct(int id)
        {
            var listProductDiscount = _discountService.GetDiscountByProduct(id).ToList();

            return Json(listProductDiscount, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByID(int id)
        {
            var discount = _discountService.GetByID(id);

            return Json(discount, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(Discount discount)
        {
            _discountService.Add(discount);
            _discountService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public JsonResult Update(Discount discount)
        {
            _discountService.Update(discount);
            _discountService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            bool oldDiscount = _discountService.Delete(id);
            _discountService.SaveChanges();

            return Json(oldDiscount, JsonRequestBehavior.AllowGet);
        }

    }
}
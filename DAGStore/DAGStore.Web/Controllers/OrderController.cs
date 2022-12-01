using DAGStore.Model.Models;
using DAGStore.Service;
using DAGStore.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace DAGStore.Web.Controllers
{
    public class OrderController : Controller
    {
        IOrderService _OrderService;

        public OrderController(IOrderService OrderService)
        {
            this._OrderService = OrderService;
        }

        // GET: category
        public JsonResult GetAll()
        {
            var listOrder = _OrderService.GetAll();

            return Json(listOrder, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByID(int id)
        {
            var Order = _OrderService.GetByID(id);

            return Json(Order, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(OrderViewModels orderViewModel)
        {

            _OrderService.Add(orderViewModel.Order);
            _OrderService.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public JsonResult Update(Order Order)
        {
            _OrderService.Update(Order);
            _OrderService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            bool oldOrder = _OrderService.Delete(id);
            _OrderService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}
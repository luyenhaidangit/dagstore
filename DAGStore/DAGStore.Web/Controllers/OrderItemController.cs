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
    public class OrderItemController : Controller
    {
        IOrderItemService _OrderItemService;

        public OrderItemController(IOrderItemService OrderItemService)
        {
            this._OrderItemService = OrderItemService;
        }

        // GET: category
        public JsonResult GetAll()
        {
            var listOrderItem = _OrderItemService.GetAll();

            return Json(listOrderItem, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByID(int id)
        {
            var OrderItem = _OrderItemService.GetByID(id);

            return Json(OrderItem, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(OrderItem OrderItem)
        {
            _OrderItemService.Add(OrderItem);
            _OrderItemService.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public JsonResult Update(OrderItem OrderItem)
        {
            _OrderItemService.Update(OrderItem);
            _OrderItemService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            bool oldOrderItem = _OrderItemService.Delete(id);
            _OrderItemService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}
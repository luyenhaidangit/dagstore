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
        IProductService _ProductService;

        public OrderItemController(IProductService productService,IOrderItemService OrderItemService)
        {
            this._OrderItemService = OrderItemService;
            this._ProductService = productService;
        }

        // GET: category
        public JsonResult GetAll()
        {
            var listOrderItem = _OrderItemService.GetAll();

            return Json(listOrderItem, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetOrderItemsByOrder(int id)
        {
            var listOrderItem = _OrderItemService.GetAll().Where(x=>x.OrderID==id);
            foreach(var item in listOrderItem)
            {
                item.Product = _ProductService.GetByID(item.ProductID);
            }

            return Json(listOrderItem, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByID(int id)
        {
            var OrderItem = _OrderItemService.GetByID(id);
            OrderItem.Product = _ProductService.GetByID(OrderItem.ProductID);

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
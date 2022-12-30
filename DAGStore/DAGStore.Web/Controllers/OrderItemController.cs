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
        IOrderService _OrderService;

        public OrderItemController(IProductService productService,IOrderItemService OrderItemService,IOrderService OrderService)
        {
            this._OrderItemService = OrderItemService;
            this._ProductService = productService;
            this._OrderService = OrderService;
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

        // GET: category
        public JsonResult GetOrderItem()
        {
            var listOrderItem = _OrderItemService.GetAll();

            var result = from x in listOrderItem
                         select new
                         {
                             ID = x.ID,
                             OrderID = x.OrderID,
                             Order = _OrderService.GetAll().ToList().Where(a => a.ID == x.OrderID).FirstOrDefault(),
                             ProductID = x.ProductID,
                             Product = _ProductService.GetAll().Where(a => a.ID == x.ProductID).FirstOrDefault(),
                             Quantity = x.Quantity,
                             TotalMoney = x.TotalMoney,
                             TotalDiscount = x.TotalDiscount,
                         };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
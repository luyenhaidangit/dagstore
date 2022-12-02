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
        ICustomerService _CustomerService;
        IOrderItemService _OrderItemService;

        public OrderController(IOrderItemService orderItemService,IOrderService OrderService,ICustomerService customerService)
        {
            this._OrderService = OrderService;
            this._CustomerService = customerService;
            this._OrderItemService = orderItemService;
        }

        // GET: category
        public JsonResult GetAll()
        {
            var listOrder = _OrderService.GetAll();
            foreach(var item in listOrder)
            {
                item.Customer = _CustomerService.GetByID(item.CustomerID);
            }

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
            var customers = _CustomerService.GetAll().ToList();

            var customer = customers.Any(x => x.NumberPhone == orderViewModel.Customer.NumberPhone);
            var customerID = 0;
            if (customer)
            {
                customerID = (customers.Where(x => x.NumberPhone == orderViewModel.Customer.NumberPhone)).FirstOrDefault().ID;
            }
            else
            {
                _CustomerService.Add(orderViewModel.Customer);
                _CustomerService.SaveChanges();
                customerID = orderViewModel.Customer.ID;
            }

            orderViewModel.Order.CustomerID = customerID;
            _OrderService.Add(orderViewModel.Order);
            _OrderService.SaveChanges();

            foreach (var orderItem in orderViewModel.Order.OrderItems)
            {
                orderItem.OrderID = orderViewModel.Order.ID;
                orderItem.TotalMoney = orderItem.Quantity * orderItem.Product.SellPriceActual;
                orderItem.TotalDiscount = 0;
                orderItem.Product = null;
                _OrderItemService.Add(orderItem);
            }
            _OrderItemService.SaveChanges();
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
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
        IProductService _ProductService;

        public OrderController(IProductService ProductService,IOrderItemService orderItemService,IOrderService OrderService,ICustomerService customerService)
        {
            this._OrderService = OrderService;
            this._CustomerService = customerService;
            this._OrderItemService = orderItemService;
            this._ProductService = ProductService;
        }

        // GET: category
        public JsonResult GetAll()
        {
            var listOrder = _OrderService.GetAll().ToList();
            listOrder = listOrder.OrderByDescending(x => x.ID).ToList();
            //foreach (var item in listOrder)
            //{
            //    item.Customer = _CustomerService.GetByID(item.CustomerID);
            //}
            var result = from x in listOrder
                         select new
                         {
                             ID = x.ID,
                             CustomerID = x.CustomerID,
                             ShippingFormat = x.ShippingFormat,
                             ShippingAddress = x.ShippingAddress,
                             OrderStatus = x.OrderStatus,
                             PaymentFormat = x.PaymentFormat,
                             PaymentStatus = x.PaymentStatus,
                             OrderDiscount = x.OrderDiscount,
                             OrderTotal = x.OrderTotal,
                             CustomerOrderComment = x.CustomerOrderComment,
                             CreateOn = x.CreateOn,
                             Customer = _CustomerService.GetAll().ToList().Where(a => a.ID == x.CustomerID).FirstOrDefault(),
                             OrderItems = from a in _OrderItemService.GetAll().ToList().Where(a => a.OrderID == x.ID)
                                          select new
                                          {
                                              ID = a.ID,
                                              OrderID = a.OrderID,
                                              ProductID = a.ProductID,
                                              Quantity = a.Quantity,
                                              TotalDiscount = a.TotalDiscount,
                                              TotalMoney = a.TotalMoney,
                                              Order = a.Order,
                                              Product = _ProductService.GetAll().ToList().Where(b => b.ID == a.ProductID).FirstOrDefault(),
                                          },
                         };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetOrderPrint(int id)
        {
            var listOrder = _OrderService.GetAll().ToList();
            listOrder = listOrder.OrderByDescending(x => x.ID).ToList();
            //foreach (var item in listOrder)
            //{
            //    item.Customer = _CustomerService.GetByID(item.CustomerID);
            //}
            var result = (from x in listOrder
                         where x.ID == id
                         select new
                         {
                             ID = x.ID,
                             CustomerID = x.CustomerID,
                             ShippingFormat = x.ShippingFormat,
                             ShippingAddress = x.ShippingAddress,
                             OrderStatus = x.OrderStatus,
                             PaymentFormat = x.PaymentFormat,
                             PaymentStatus = x.PaymentStatus,
                             OrderDiscount = x.OrderDiscount,
                             OrderTotal = x.OrderTotal,
                             CustomerOrderComment = x.CustomerOrderComment,
                             CreateOn = x.CreateOn,
                             Customer = _CustomerService.GetAll().ToList().Where(a => a.ID == x.CustomerID).FirstOrDefault(),
                             OrderItems = from a in _OrderItemService.GetAll().ToList().Where(a => a.OrderID == x.ID)
                                          select new
                                          {
                                              ID = a.ID,
                                              OrderID = a.OrderID,
                                              ProductID = a.ProductID,
                                              Quantity = a.Quantity,
                                              TotalDiscount = a.TotalDiscount,
                                              TotalMoney = a.TotalMoney,
                                              Order = a.Order,
                                              Product = _ProductService.GetAll().ToList().Where(b => b.ID == a.ProductID).FirstOrDefault(),
                                          },
                         }).ToList().FirstOrDefault();
            return Json(result, JsonRequestBehavior.AllowGet);
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

        public JsonResult GetRevenue()
        {
            var listOrder = _OrderService.GetAll().ToList();
            listOrder = listOrder.OrderByDescending(x => x.ID).ToList();
            decimal total = 0;
            foreach (var item in listOrder)
            {
                if(item.OrderStatus == 2)
                {
                    total += item.OrderTotal;
                }
            }


            return Json(new
            {
                Total = total,
            }, JsonRequestBehavior.AllowGet);
        }

    }
}
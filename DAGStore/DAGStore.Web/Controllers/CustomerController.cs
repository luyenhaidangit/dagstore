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
    public class CustomerController : Controller
    {
        ICustomerService _CustomerService;

        public CustomerController(ICustomerService CustomerService)
        {
            this._CustomerService = CustomerService;
        }

        // GET: category
        public JsonResult GetAll()
        {
            var listCustomer = _CustomerService.GetAll();

            return Json(listCustomer, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByID(int id)
        {
            var Customer = _CustomerService.GetByID(id);

            return Json(Customer, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(Customer Customer)
        {
            Customer.Deleted = false;
            Customer.Andress = "Yên Mỹ - Hưng Yên";
            _CustomerService.Add(Customer);
            _CustomerService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public JsonResult Update(Customer Customer)
        {
            _CustomerService.Update(Customer);
            _CustomerService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            bool oldCustomer = _CustomerService.Delete(id);
            _CustomerService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult Delete(IEnumerable<Customer> Customers)
        {
            foreach (var item in Customers)
            {
                _CustomerService.Delete(item.ID);
            }
            _CustomerService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(IEnumerable<Customer> Customers)
        {
            foreach (var Customer in Customers)
            {
                _CustomerService.Add(Customer);
            }
            _CustomerService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
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
    public class CustomerAndressController : Controller
    {

        ICustomerAndressService _CustomerAndressService;

        public CustomerAndressController(ICustomerAndressService CustomerAndressService)
        {
            this._CustomerAndressService = CustomerAndressService;
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: CustomerAndress
        public JsonResult GetAll()
        {
            var listCustomerAndress = _CustomerAndressService.GetAll();

            return Json(listCustomerAndress, JsonRequestBehavior.AllowGet);
        }

        // GET: CustomerAndress

        public JsonResult GetByID(int id)
        {
            var CustomerAndress = _CustomerAndressService.GetByID(id);

            return Json(CustomerAndress, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(CustomerAndress CustomerAndress)
        {
            _CustomerAndressService.Add(CustomerAndress);
            _CustomerAndressService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public JsonResult Update(CustomerAndress CustomerAndress)
        {
            _CustomerAndressService.Update(CustomerAndress);
            _CustomerAndressService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            bool oldCustomerAndress = _CustomerAndressService.Delete(id);
            _CustomerAndressService.SaveChanges();

            return Json(oldCustomerAndress, JsonRequestBehavior.AllowGet);
        }

    }
}
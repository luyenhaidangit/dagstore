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
    public class SupplierController : Controller
    {
        ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            this._supplierService = supplierService;
        }

        // GET: category
        public JsonResult GetAll()
        {
            var listSupplier = _supplierService.GetAll();

            return Json(listSupplier, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByID(int id)
        {
            var Supplier = _supplierService.GetByID(id);

            return Json(Supplier, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(Supplier supplier)
        {
            _supplierService.Add(supplier);
            _supplierService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public JsonResult Update(Supplier supplier)
        {
            _supplierService.Update(supplier);
            _supplierService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            bool oldSupplier = _supplierService.Delete(id);
            _supplierService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}
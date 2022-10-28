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
    public class ImportBillController : Controller
    {
        IImportBillService _importBillService;

        public ImportBillController(IImportBillService importBillService)
        {
            this._importBillService = importBillService;
        }

        // GET: category
        public JsonResult GetAll()
        {
            var listImportBill = _importBillService.GetAll();

            return Json(listImportBill, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetData()
        {
            var listImportBill = _importBillService.GetData();

            return Json(listImportBill, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByID(int id)
        {
            var importBill = _importBillService.GetByID(id);

            return Json(importBill, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(ImportBill importBill)
        {
            _importBillService.Add(importBill);
            _importBillService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public JsonResult Update(ImportBill importBill)
        {
            _importBillService.Update(importBill);
            _importBillService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            bool oldImportBill = _importBillService.Delete(id);
            _importBillService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}
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
        IImportBillDetailService _importBillDetailService;

        public ImportBillController(IImportBillService importBillService, IImportBillDetailService importBillDetailService)
        {
            this._importBillService = importBillService;
            this._importBillDetailService = importBillDetailService;
        }

        // GET: category
        public JsonResult GetAll()
        {
            var listImportBill = _importBillService.GetAll();

            return Json(listImportBill, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetList()
        {
            var listImportBill = _importBillService.GetList();

            return Json(listImportBill, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetInfo(int id)
        {
            var listImportBill = _importBillService.GetInfo(id);

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
            foreach (var importBillDetail in importBill.ImportBillDetails)
            {
                importBillDetail.ImportBillID = importBill.ID;
                _importBillDetailService.Add(importBillDetail);
            }
            _importBillDetailService.SaveChanges();

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
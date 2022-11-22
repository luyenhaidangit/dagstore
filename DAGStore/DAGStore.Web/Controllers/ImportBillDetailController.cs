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
    [Authorize]
    public class ImportBillDetailController : Controller
    {
        IImportBillDetailService _importBillDetailService;

        public ImportBillDetailController(IImportBillDetailService importBillDetailService)
        {
            this._importBillDetailService = importBillDetailService;
        }

        // GET: category
        public JsonResult GetAll()
        {
            var listImportBillDetail = _importBillDetailService.GetAll();

            return Json(listImportBillDetail, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByID(int id)
        {
            var importBillDetail = _importBillDetailService.GetByID(id);

            return Json(importBillDetail, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(ImportBillDetail importBillDetail)
        {
            _importBillDetailService.Add(importBillDetail);
            _importBillDetailService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public JsonResult Update(ImportBillDetail importBillDetail)
        {
            _importBillDetailService.Update(importBillDetail);
            _importBillDetailService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            bool oldImportBillDetail = _importBillDetailService.Delete(id);
            _importBillDetailService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult Delete(IEnumerable<ImportBillDetail> importBillDetails)
        {
            foreach (var item in importBillDetails)
            {
                _importBillDetailService.Delete(item.ID);
            }
            _importBillDetailService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(IEnumerable<ImportBillDetail> importBillDetails)
        {
            foreach (var importBillDetail in importBillDetails)
            {
                _importBillDetailService.Add(importBillDetail);
            }
            _importBillDetailService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
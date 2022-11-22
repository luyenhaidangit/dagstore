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
    public class MenuRecordController : Controller
    {
        IMenuRecordService _menuRecordService;

        public MenuRecordController(IMenuRecordService menuRecordService)
        {
            this._menuRecordService = menuRecordService;
        }
        // GET: MenuRecord
        public JsonResult GetAll()
        {
            var listMenuRecord = _menuRecordService.GetAll();

            return Json(listMenuRecord, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByID(int id)
        {
            var menuRecord = _menuRecordService.GetByID(id);

            return Json(menuRecord, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(MenuRecord menuRecord)
        {
            _menuRecordService.Add(menuRecord);
            _menuRecordService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public JsonResult Update(MenuRecord menuRecord)
        {
            
            _menuRecordService.Update(menuRecord);
            _menuRecordService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            bool oldMenuRecord = _menuRecordService.Delete(id);
            _menuRecordService.SaveChanges();

            return Json(oldMenuRecord, JsonRequestBehavior.AllowGet);
        }

    }
}
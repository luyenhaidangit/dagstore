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

        

    }
}
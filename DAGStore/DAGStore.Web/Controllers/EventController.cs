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
    public class EventController : Controller
    {
        IEventService _EventService;

        public EventController(IEventService EventService)
        {
            this._EventService = EventService;
        }

        // GET: category
        public JsonResult GetAll()
        {
            var listEvent = _EventService.GetAll();

            return Json(listEvent, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByID(int id)
        {
            var Event = _EventService.GetByID(id);

            return Json(Event, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(Event Event)
        {
            _EventService.Add(Event);
            _EventService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public JsonResult Update(Event Event)
        {
            _EventService.Update(Event);
            _EventService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            bool oldEvent = _EventService.Delete(id);
            _EventService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

    }
}
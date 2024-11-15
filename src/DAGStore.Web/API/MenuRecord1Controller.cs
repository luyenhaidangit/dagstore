using DAGStore.Model.Models;
using DAGStore.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DAGStore.Web.API
{
    [RoutePrefix("api/menurecord")]
    public class MenuRecord1Controller : ApiController
    {
        IMenuRecordService _menuRecordService;

        public MenuRecord1Controller(IMenuRecordService menuRecordService)
        {
            this._menuRecordService = menuRecordService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            HttpResponseMessage response = null;
            
            var listMenuRecord = _menuRecordService.GetAll();

            response = request.CreateResponse(HttpStatusCode.OK, listMenuRecord);

            return response;
        }

        public HttpResponseMessage Post(HttpRequestMessage request, MenuRecord menuRecord)
        {
            HttpResponseMessage response = null;
            if (!ModelState.IsValid)
            {
                request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                var menuRecords = _menuRecordService.Add(menuRecord);
                _menuRecordService.SaveChanges();

                response = request.CreateResponse(HttpStatusCode.Created, menuRecords);
            }
            return response;
        }

        public HttpResponseMessage Put(HttpRequestMessage request, MenuRecord menuRecord)
        {
            HttpResponseMessage response = null;
            if (!ModelState.IsValid)
            {
                request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                var menuRecords = _menuRecordService.Update(menuRecord);
                _menuRecordService.SaveChanges();

                response = request.CreateResponse(HttpStatusCode.OK);
            }
            return response;
        }

        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            HttpResponseMessage response = null;
            if (!ModelState.IsValid)
            {
                request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                _menuRecordService.Delete(id);
                _menuRecordService.SaveChanges();

                response = request.CreateResponse(HttpStatusCode.OK);
            }
            return response;
        }

    }
}

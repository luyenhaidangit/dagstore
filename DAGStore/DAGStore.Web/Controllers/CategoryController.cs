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
    public class CategoryController : Controller
    {
        

        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: category
        public JsonResult GetAll()
        {
            var listCategory = _categoryService.GetAll();

            return Json(listCategory, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByID(int id)
        {
            var category = _categoryService.GetByID(id);

            return Json(category, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCategoryShowOnHomePage()
        {
            var categorys = _categoryService.GetCategoryShowOnHomePage();

            return Json(categorys, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetListChildCategory(int id)
        {
            var categorys = _categoryService.GetListChildCategory(id);

            return Json(categorys, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(Category category)
        {
            _categoryService.Add(category);
            _categoryService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public JsonResult Update(Category category)
        {
            _categoryService.Update(category);
            _categoryService.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            bool oldCategory = _categoryService.Delete(id);
            _categoryService.SaveChanges();

            return Json(oldCategory, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetData()
        {
            var result = _categoryService.GetData();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
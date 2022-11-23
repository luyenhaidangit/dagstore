using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAGStore.Model.Models;
using DAGStore.Service;

namespace DAGStore.Web.Controllers
{
    public class HomeController : Controller
    {
        ICategoryService _categoryService;

        public HomeController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            var categories = _categoryService.GetAll().ToList();
            
            return PartialView(categories);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string TestMethod()
        {
            return "test";
        }
    }
}
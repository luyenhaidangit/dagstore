using DAGStore.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DAGStore.Web.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }

        IProductService _productService;

        public IndexController(IProductService productService)
        {
            _productService = productService;
        }

        public JsonResult GetProductsNewShowHomePage()
        {
            var products = _productService.GetProductsNewShowHomePage().ToList();
            return Json(products,JsonRequestBehavior.AllowGet);
        }
    }
}
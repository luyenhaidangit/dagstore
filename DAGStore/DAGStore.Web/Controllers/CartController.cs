using DAGStore.Model.Models;
using DAGStore.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace DAGStore.Web.Controllers
{
    public class CartController : Controller
    {
        IProductService _productService;

        public CartController(IProductService productService)
        {
            this._productService = productService;
        }

        // GET: category
        public JsonResult GetAll()
        {
            var cart = (List<Cart>)Session["SessionCart"] ?? new List<Cart>();
            return Json(new {data = cart}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(int id)
        {
            var cart = (List<Cart>)Session["SessionCart"] ?? new List<Cart>();
            if (cart.Any(x => x.ProductID == id))
            {
                foreach (var item in cart)
                {
                    if (item.ProductID == id)
                    {
                        item.Quantity += 1;
                    }
                }
            }
            else
            {
                Cart newItem = new Cart();
                newItem.ProductID = id;
                newItem.Product = _productService.GetByID(id);
                newItem.Quantity = 1;
                cart.Add(newItem);
            }
            
            Session["SessionCart"] = cart;
            return Json("OK",JsonRequestBehavior.AllowGet);
        }
    }
}
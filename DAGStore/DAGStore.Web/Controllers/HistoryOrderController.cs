using DAGStore.Model.Models;
using DAGStore.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using DAGStore.Web.ViewModels;

namespace DAGStore.Web.Controllers
{
    public class HistoryOrderController : Controller
    {
        IProductService _productService;
        ICustomerService _customerService;
        IOrderService _orderService;
        IOrderItemService _orderItemService;


        public HistoryOrderController(IOrderItemService orderItemService,IOrderService orderService,ICustomerService customerService,IProductService productService)
        {
            this._productService = productService;
            this._orderService = orderService;
            this._customerService = customerService;
            this._orderItemService = orderItemService;
        }

        // GET: category
        //public JsonResult GetAll()
        //{
        //    var HistoryOrder = (List<HistoryOrder>)Session["SessionHistoryOrder"] ?? new List<HistoryOrder>();
        //    return Json(new { data = HistoryOrder }, JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //public JsonResult Create(int id)
        //{
        //    var HistoryOrder = (List<HistoryOrder>)Session["SessionHistoryOrder"] ?? new List<HistoryOrder>();
        //    if (HistoryOrder.Any(x => x.ProductID == id))
        //    {
        //        foreach (var item in HistoryOrder)
        //        {
        //            if (item.ProductID == id)
        //            {
        //                item.Quantity += 1;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        HistoryOrder newItem = new HistoryOrder();
        //        newItem.ProductID = id;
        //        newItem.Product = _productService.GetByID(id);
        //        newItem.Quantity = 1;
        //        HistoryOrder.Add(newItem);
        //    }
        //    Session["SessionHistoryOrder"] = HistoryOrder;
        //    return Json("OK", JsonRequestBehavior.AllowGet);
        //}

        //[HttpPut]
        //public JsonResult Update(HistoryOrder HistoryOrderitem)
        //{
        //    var HistoryOrder = (List<HistoryOrder>)Session["SessionHistoryOrder"] ?? new List<HistoryOrder>();

        //    var index = HistoryOrder.FindIndex(x => x.ProductID == HistoryOrderitem.ProductID);

        //    HistoryOrder[index] = HistoryOrderitem;

        //    Session["SessionHistoryOrder"] = HistoryOrder;
        //    return Json("OK", JsonRequestBehavior.AllowGet);
        //}

        //[HttpDelete]
        //public JsonResult Delete(int id)
        //{
        //    var HistoryOrder = (List<HistoryOrder>)Session["SessionHistoryOrder"] ?? new List<HistoryOrder>();
        //    var item = HistoryOrder.FirstOrDefault(x => x.ProductID == id);
        //    HistoryOrder.Remove(item);
        //    Session["SessionHistoryOrder"] = HistoryOrder;
        //    return Json(true, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult GetAll()
        {
            var cart = (List<EmailVerifiViewModels>)Session["SessionEmailVerifi"] ?? new List<EmailVerifiViewModels>();
            return Json(new { data = cart }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateLogin(string email)
        {
            var cart = (EmailVerifiViewModels)Session["SessionHistoryOrder"] ?? new EmailVerifiViewModels();

            EmailVerifiViewModels newItem = new EmailVerifiViewModels();
            newItem.Email = email;
            newItem.Otp = "";
           
            cart = newItem;

            Session["SessionHistoryOrder"] = cart;
            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLogin()
        {
            var cart = (EmailVerifiViewModels)Session["SessionHistoryOrder"] ?? new EmailVerifiViewModels();
            string email = "";
            if (cart.Email != null)
            {
                email = cart.Email;
            }
            
            return Json(new
            {
                email = email,
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SendCode(string email)
        {
            Random r = new Random();
            string otp = r.Next(100001,999999).ToString();
            var emailVerifi = new EmailVerifiViewModels();
            emailVerifi.Email = email;
            emailVerifi.Otp = otp;

            var emailVerifis = (List<EmailVerifiViewModels>)Session["SessionEmailVerifi"] ?? new List<EmailVerifiViewModels>();
            if (emailVerifis.Any(x => x.Email == email))
            {
                foreach (EmailVerifiViewModels item in emailVerifis)
                {
                    if (item.Email == emailVerifi.Email)
                    {
                        item.Otp = emailVerifi.Otp;
                    }
                }
            }
            else
            {
                emailVerifis.Add(emailVerifi);
            }

            Session["SessionEmailVerifi"] = emailVerifis;
           
            using (MailMessage mail = new MailMessage("luyenhaidangit@outlook.com", email))
            {
                mail.Subject = "Xác nhận mã của bạn - Cửa hàng đồ công nghệ DAGStore";
                mail.Body = "Mã xác nhận của bạn là:" + otp;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp-mail.outlook.com";
                smtp.EnableSsl = true;
                NetworkCredential credential = new NetworkCredential("luyenhaidangit@outlook.com","Haidang106");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = credential;
                smtp.Port = 587;
                smtp.Send(mail);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetOrderCustomer(string email)
        {
            //var customer = _customerService.GetAll().Where(x=>x.Equals(email)).FirstOrDefault();

            var customer = _customerService.GetAll();

            var order = _orderService.GetAll();

            var result = from o in order
                         join c in customer on o.CustomerID equals c.ID
                         where c.Email == email
                         select new
                         {
                             ID = o.ID,
                             OrderItems = _orderItemService.GetOrderItemsByOrder(o.ID),
                             Title = _orderItemService.GetOrderItemsByOrder(o.ID).ToList().Count ==1? (_productService.GetByID(_orderItemService.GetOrderItemsByOrder(o.ID).First().ProductID).Name) : (_productService.GetByID(_orderItemService.GetOrderItemsByOrder(o.ID).First().ProductID).Name) + " và " + (_orderItemService.GetOrderItemsByOrder(o.ID).ToList().Count-1)+ " sản phẩm khác",
                             TotalBill = o.OrderTotal,
                             Date = o.CreateOn,
                         };

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
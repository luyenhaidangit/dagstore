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

        public HistoryOrderController(IProductService productService)
        {
            this._productService = productService;
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
    }
}
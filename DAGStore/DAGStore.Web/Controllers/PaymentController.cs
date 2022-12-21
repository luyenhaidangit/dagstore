using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using DAGStore.Model.Models;
using DAGStore.Service;
using DAGStore.Web.ViewModels;

namespace DAGStore.Web.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index()
        {
            return View();
        }

        // GET: Payment
        public ActionResult PaymentStatus()
        {
            return View();
        }

        IOrderService _OrderService;
        ICustomerService _CustomerService;
        IOrderItemService _OrderItemService;

        public PaymentController(IOrderItemService orderItemService, IOrderService OrderService, ICustomerService customerService)
        {
            this._OrderService = OrderService;
            this._CustomerService = customerService;
            this._OrderItemService = orderItemService;
        }

        public JsonResult Payment(OrderViewModels model)
        {
            var customers = _CustomerService.GetAll().ToList();

            var customer = customers.Any(x => x.NumberPhone == model.Customer.NumberPhone);
            var customerID = 0;
            if (customer)
            {
                customerID = (customers.Where(x => x.NumberPhone == model.Customer.NumberPhone)).FirstOrDefault().ID;
            }
            else
            {
                _CustomerService.Add(model.Customer);
                _CustomerService.SaveChanges();
                customerID = model.Customer.ID;
            }

            model.Order.CustomerID = customerID;
            _OrderService.Add(model.Order);
            _OrderService.SaveChanges();

            foreach (var orderItem in model.Order.OrderItems)
            {
                orderItem.OrderID = model.Order.ID;
                orderItem.TotalMoney = orderItem.Quantity * orderItem.Product.SellPriceActual;
                orderItem.TotalDiscount = 0;
                orderItem.Product = null;
                _OrderItemService.Add(orderItem);
            }
            _OrderItemService.SaveChanges();



            string url = ConfigurationManager.AppSettings["Url"];
            string returnUrl = ConfigurationManager.AppSettings["ReturnUrl"];
            string tmnCode = ConfigurationManager.AppSettings["TmnCode"];
            string hashSecret = ConfigurationManager.AppSettings["HashSecret"];

            PayViewModels pay = new PayViewModels();

            pay.AddRequestData("vnp_Version", "2.1.0"); //Phiên bản api mà merchant kết nối. Phiên bản hiện tại là 2.1.0
            pay.AddRequestData("vnp_Command", "pay"); //Mã API sử dụng, mã cho giao dịch thanh toán là 'pay'
            pay.AddRequestData("vnp_TmnCode", tmnCode); //Mã website của merchant trên hệ thống của VNPAY (khi đăng ký tài khoản sẽ có trong mail VNPAY gửi về)
            pay.AddRequestData("vnp_Amount", (model.Order.OrderTotal * 100).ToString()); //số tiền cần thanh toán, công thức: số tiền * 100 - ví dụ 10.000 (mười nghìn đồng) --> 1000000
            pay.AddRequestData("vnp_BankCode", ""); //Mã Ngân hàng thanh toán (tham khảo: https://sandbox.vnpayment.vn/apis/danh-sach-ngan-hang/), có thể để trống, người dùng có thể chọn trên cổng thanh toán VNPAY
            pay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss")); //ngày thanh toán theo định dạng yyyyMMddHHmmss
            pay.AddRequestData("vnp_CurrCode", "VND"); //Đơn vị tiền tệ sử dụng thanh toán. Hiện tại chỉ hỗ trợ VND
            pay.AddRequestData("vnp_IpAddr", Util.GetIpAddress()); //Địa chỉ IP của khách hàng thực hiện giao dịch
            pay.AddRequestData("vnp_Locale", "vn"); //Ngôn ngữ giao diện hiển thị - Tiếng Việt (vn), Tiếng Anh (en)
            pay.AddRequestData("vnp_OrderInfo", model.Order.CustomerOrderComment); //Thông tin mô tả nội dung thanh toá
            //pay.AddRequestData("vnp_OrderNameCustomer", model.Customer.Name); //Thông tin mô tả nội dung thanh toán
            pay.AddRequestData("vnp_OrderType", "other"); //topup: Nạp tiền điện thoại - billpayment: Thanh toán hóa đơn - fashion: Thời trang - other: Thanh toán trực tuyến
            pay.AddRequestData("vnp_ReturnUrl", returnUrl); //URL thông báo kết quả giao dịch khi Khách hàng kết thúc thanh toán
            pay.AddRequestData("vnp_TxnRef", model.Order.ID.ToString()); //mã hóa đơn

            string paymentUrl = pay.CreateRequestUrl(url, hashSecret);

            //return Redirect(paymentUrl);
            return Json(paymentUrl, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PaymentConfirm()
        {
            if (Request.QueryString.Count > 0)
            {
                string hashSecret = ConfigurationManager.AppSettings["HashSecret"]; //Chuỗi bí mật
                var vnpayData = Request.QueryString;
                PayViewModels pay = new PayViewModels();

                //lấy toàn bộ dữ liệu được trả về
                foreach (string s in vnpayData)
                {
                    if (!string.IsNullOrEmpty(s) && s.StartsWith("vnp_"))
                    {
                        pay.AddResponseData(s, vnpayData[s]);
                    }
                }

                long orderId = Convert.ToInt64(pay.GetResponseData("vnp_TxnRef")); //mã hóa đơn
                long amount = Convert.ToInt64(pay.GetResponseData("vnp_Amount")); //mã hóa đơn
                string nameCustomer = pay.GetResponseData("vnp_OrderNameCustomer"); //mã hóa đơn
                string date = DateTime.Now.ToString("yyyyMMddHHmmss");
              
                //pay.AddRequestData("vnp_OrderNameCustomer", model.Customer.Name);
                long vnpayTranId = Convert.ToInt64(pay.GetResponseData("vnp_TransactionNo")); //mã giao dịch tại hệ thống VNPAY
                string vnp_ResponseCode = pay.GetResponseData("vnp_ResponseCode"); //response code: 00 - thành công, khác 00 - xem thêm https://sandbox.vnpayment.vn/apis/docs/bang-ma-loi/
                string vnp_SecureHash = Request.QueryString["vnp_SecureHash"]; //hash của dữ liệu trả về

                bool checkSignature = pay.ValidateSignature(vnp_SecureHash, hashSecret); //check chữ ký đúng hay không?



                var result = new
                {
                    amount = amount,
                    orderId = orderId,
                    vnpayTranId = vnpayTranId,
                    vnp_ResponseCode = vnp_ResponseCode,
                    vnp_SecureHash = vnp_SecureHash,
                    status = "faily",
                };
                if (checkSignature)
                {
                    if (vnp_ResponseCode == "00")
                    {
                        ////Thanh toán thành công
                        Session["SessionCart"] = new List<Cart>();
                        ViewBag.Message = "Thanh toán thành công hóa đơn " + orderId + " | Mã giao dịch: " + vnpayTranId;

                        var order = _OrderService.GetAll().ToList().Where(x=> x.ID==orderId).FirstOrDefault();
                        order.PaymentStatus = 1;
                        _OrderService.Update(order);
                        _OrderService.SaveChanges();

                        result = new
                        {
                            amount = amount,
                            orderId = orderId,
                            vnpayTranId = vnpayTranId,
                            vnp_ResponseCode = vnp_ResponseCode,
                            vnp_SecureHash = vnp_SecureHash,
                            status = "success",
                        };
                        return Json(result, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        result = new
                        {
                            amount = amount,
                            orderId = orderId,
                            vnpayTranId = vnpayTranId,
                            vnp_ResponseCode = vnp_ResponseCode,
                            vnp_SecureHash = vnp_SecureHash,
                            status = "error payment",
                        };
                        //Thanh toán không thành công. Mã lỗi: vnp_ResponseCode
                        //ViewBag.Message = "Thanh toán không thành công";
                        return Json(result, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    //ViewBag.Message = "Có lỗi xảy ra trong quá trình xử lý";
                    result = new
                    {
                        amount = amount,
                        orderId = orderId,
                        vnpayTranId = vnpayTranId,
                        vnp_ResponseCode = vnp_ResponseCode,
                        vnp_SecureHash = vnp_SecureHash,
                        status = "error proccess",
                    };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }


            }

            return Json(new {
                status = "error stop",
            }, JsonRequestBehavior.AllowGet);

            //return View();
        }


        
    }
}
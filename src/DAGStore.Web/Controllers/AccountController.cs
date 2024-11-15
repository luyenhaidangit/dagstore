using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
//using DAGStore.Web.Models;
using DAGStore.Model.Models;
using DAGStore.Web.ViewModels;
using DAGStore.Web.App_Start;
using System.Net.Http;
using System.Net;
using System.Web.Http;
using AllowAnonymousAttribute = System.Web.Http.AllowAnonymousAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using System.Web.Helpers;
//using DAGStore.Web.ViewModels;
//using DAGStore.Web.Models;

namespace DAGStore.Web.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<JsonResult> Login(string userName, string password, bool rememberMe)
        {
            
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(userName, password, rememberMe, shouldLockout: false);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }
}
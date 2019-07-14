using Best.BusinessLayer.Abstract;
using Best.Core.CrossCuttingConcerns.Security.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Best.PresentationLayer.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Account
        public string Login(string userName, string password)
        {
            var user = _userService.GetByUserNameAndPassword(userName, password);//Veritabanında bu kullanıcı adı ve şifresi olan kullanıcıyı alıyoruz
            if (user != null)
            {
                //Kullanıcı giriş yapabiliyorsa kullanıcının bilgilerini cookie'de tutuyoruz.
                AuthenticationHelper.CreateAuthCookie(new Guid(), user.UserName, user.Email, DateTime.Now.AddDays(1), _userService.GetUserRoles(user).Select(u => u.RoleName).ToArray(), false, user.FirstName, user.LastName);

                return "User is Authenticated";
            }
            return "User is Not Authenticated";

        }
        public string LogOut()
        {
            //Cookie'deki bilgileri siliyoruz.
            FormsAuthentication.SignOut();
            return "LogOut";
        }
    }
}
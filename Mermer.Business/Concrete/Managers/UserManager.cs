using System;
using System.Web;
using System.Web.Security;
using Mermer.Business.Abstract;
using Mermer.Core.CrossCuttingConcerns.Security.Web;
using Mermer.DataAccess.Abstract;
using Mermer.Entity.ComplexType;
using Mermer.Entity.Concrete;

namespace Mermer.Business.Concrete.Managers
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public void Login(UserLoginViewModel loginModel)
        {
            User user = GetByUserNameAndPassword(loginModel.UserName, loginModel.Password);
            if (user != null)
                AuthenticationHelper.CreateAuthCookie(loginModel.UserName, "", _userDal.GetUserRoles(user).ToArray(),DateTime.Now.AddDays(1), loginModel.RememberMe);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
            if (HttpContext.Current.Response.Cookies[FormsAuthentication.FormsCookieName] != null)
                HttpContext.Current.Response.Cookies[FormsAuthentication.FormsCookieName].Expires = DateTime.Now.AddDays(-1);
        }

        private User GetByUserNameAndPassword(string userName,string password)
        {
            return _userDal.Get(s => s.UserName == userName & s.Password == password);
        }

    }
}
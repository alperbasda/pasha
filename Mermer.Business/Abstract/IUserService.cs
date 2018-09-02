using Mermer.Entity.ComplexType;

namespace Mermer.Business.Abstract
{
    public interface IUserService
    {
        void Login(UserLoginViewModel loginModel);
        void SignOut();
    }
}
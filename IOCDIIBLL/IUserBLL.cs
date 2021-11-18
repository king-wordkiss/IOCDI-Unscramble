using IOCDIModel;
using System;

namespace IOCDIIBLL
{
    public interface IUserBLL
    {
        UserModel Login(string account);
        void LastLogin(UserModel user);
    }
}

using IOCDIIBLL;
using IOCDIIDAL;
using IOCDIModel;
using System;

namespace IOCDIBLL
{
    public class UserBLL : IUserBLL
    {
        private IUserDAL _iUserDAL = null;

        public UserBLL(IUserDAL userDAL )
        {
            this._iUserDAL = userDAL;
        }
        public void LastLogin(UserModel user)
        {
            user.LoginTime = DateTime.Now;
            this._iUserDAL.Update(user);
        }

        public UserModel Login(string account)
        {
            return this._iUserDAL.Find(u => u.Account.Equals(account));
        }
    }
}

using IOCDIFramework.CustomContainer;
using IOCDIIBLL;
using IOCDIIDAL;
using IOCDIModel;
using System;

namespace IOCDIBLL
{
    public class UserBLL : IUserBLL
    {
        /// <summary>
        /// 希望属性也能初始化--属性注入
        /// </summary>
        [PropertyInjection]
        public IUserDAL userDAL1 { get; set; }
        private IUserDAL _iUserDAL = null;
        [Constructor]
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

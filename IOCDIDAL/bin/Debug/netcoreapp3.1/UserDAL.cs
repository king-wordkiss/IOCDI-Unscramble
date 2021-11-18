using IOCDIIDAL;
using IOCDIModel;
using System;
using System.Linq.Expressions;

namespace IOCDIDAL
{
    /// <summary>
    /// SQLServer
    /// </summary>
    public class UserDAL : IUserDAL
    {
        public UserModel Find(Expression<Func<UserModel, bool>> expression)
        {
            return new UserModel()
            {
                Id = 7,
                Name = "Zhangsan",
                Account = "Administrator",
                Email = "57265177@qq.com",
                Password = "123456677",
                Role = "Admin",
                LoginTime = DateTime.Now
            };
        }

        public void Update(UserModel userModel)
        {
            Console.WriteLine("数据库更新");
        }
    }
}

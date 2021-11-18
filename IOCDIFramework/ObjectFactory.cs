using IOCDIIBLL;
using IOCDIIDAL;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace IOCDIFramework
{
    public class ObjectFactory
    {
        public static IUserDAL CreateDAL() 
        {
            IUserDAL userDAL = null;
            //不能依赖细节 但是又要创建对象

            string config = ConfigurationManger.GetNode("IUserDAL");

            //取出程序集，在这相对与的是IUserDAL下的一个实现类，并把相对应的json文件给分解出来
            Assembly assembly = Assembly.Load(config.Split(',')[1]);
            Type type = assembly.GetType(config.Split(',')[0]);  // 这里是获取到UserDAL类型的一个对象
            userDAL = (IUserDAL)Activator.CreateInstance(type);//映射获取使用指定类型的无参数构造函数创建该类型的实例。
            return userDAL;
        }
        public static IUserBLL CreateBLL(IUserDAL userDAL)
        {
            IUserBLL userBLL = null;
            //不能依赖细节 但是又要创建对象

            string config = ConfigurationManger.GetNode("IUserBLL");

            Assembly assembly = Assembly.Load(config.Split(',')[1]);
            Type type = assembly.GetType(config.Split(',')[0]);
            userBLL = (IUserBLL)Activator.CreateInstance(type,new object[] { userDAL});
            return userBLL;
        }
    }
}

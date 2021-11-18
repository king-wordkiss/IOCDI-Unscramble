//using IOCDIBLL;
//using IOCDIDAL;
using IOCDIBLL;
using IOCDIDAL;
using IOCDIFramework;
using IOCDIFramework.CustomContainer;
using IOCDIIBLL;
using IOCDIIDAL;
using IOCDIModel;
using System;

namespace IOCDIConsoleProject
{
    /// <summary>
    /// IOC---DIP
    /// 贯彻DIP  做到了依赖抽象而不是依赖细节，代码也能跑起来
    /// 意义   扩展
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                {
                    //{
                    //    UserDAL userDAL = new UserDAL();
                    //    UserBLL userBLL = new UserBLL(userDAL);
                    //}
                }
                {
                    //贯彻DIP--抽象不能直接实例化--但是又不要细节--来个第三方 --多态可以实例化，但是为了贯彻DIP，所以使用第三方
                    //IUserDAL userDAL = ObjectFactory.CreateDAL(); //new IUserDAL();//new UserDAL();
                    //IUserBLL userBLL = ObjectFactory.CreateBLL(userDAL); //new IUserBLL(userDAL);
                    //UserModel userModel =  userBLL.Login("Administrator");
                    //Console.WriteLine(userModel.Name);
                }
                {
                    //需求是：上层仅以来抽象，就能完成对象的获取，需要写一个第三方工具
                    //常规IOC容器：（第三方---业务无关）容器对象--注册--生成
                    IContainer container = new Container();
                    container.Register<IUserDAL, UserDAL>();
                    container.Register<IUserDAL, UserDALMySql>();//非互斥  都可能用
                    container.Register<IUserBLL, UserBLL>();
                    IUserDAL userDAL = container.Resolve<IUserDAL>();
                    IUserBLL userBLL = container.Resolve<IUserBLL>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);            
            }
        }
    }
}

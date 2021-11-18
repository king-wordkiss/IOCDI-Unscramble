using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IOCDIFramework.CustomContainer
{
    /// <summary>
    /// 是用来生成对象
    /// 第三方   业务无关性
    /// </summary>
    public class Container : IContainer
    {
        //字典存数据
        private Dictionary<string, Type> ContainerDictionary = new Dictionary<string, Type>();
        public void Register<TFrom, TTo>() where TTo : TFrom
        {
            this.ContainerDictionary.Add(typeof(TFrom).FullName, typeof(TTo));
        }
        //public TFrom Resolve<TFrom>()
        //{
        //    string key = typeof(TFrom).FullName;
        //    Type type = this.ContainerDictionary[key];


        //    var ctor = type.GetConstructors()[0];
        //    #region 准备构造函数的参数
        //    List<object> paraList = new List<object>();
        //    foreach (var para in ctor.GetParameters())
        //    {
        //        Type paraType = para.ParameterType;//获取参数的类型
        //        string parakey = paraType.FullName;
        //        Type paraTargetType = this.ContainerDictionary[parakey];
        //        paraList.Add(Activator.CreateInstance(paraTargetType));
        //    }
        //    #endregion

        //    object oInstance = Activator.CreateInstance(type, paraList.ToArray());//用无参数构造函数来构造对象

        //    return (TFrom)oInstance;
        //}

        public TFrom Resolve<TFrom>() 
        {
            return (TFrom)this.ResolveObject(typeof(TFrom));
        }


        /// <summary>
        /// 递归--可以完成不限层级的东西
        /// </summary>
        /// <typeparam name="TFrom"></typeparam>
        /// <returns></returns>
        private object ResolveObject(Type abstracttype) 
        {
            string key = abstracttype.FullName;
            Type type = this.ContainerDictionary[key];

            #region 选择何时的构造参数
            ConstructorInfo ctor = null;
            ctor = type.GetConstructors().FirstOrDefault(c => c.IsDefined(typeof(ConstructorAttribute), true));
            if (ctor == null)
            {
                //参数个数最多的
                ctor = type.GetConstructors().OrderByDescending(c => c.GetParameters().Length).First();
            }
            //foreach (var item in )
            //{

            //}
            //var ctor = type.GetConstructors()[0];//直接第一个
            #endregion
            #region 准备构造函数的参数
            List<object> paraList = new List<object>();
            foreach (var para in ctor.GetParameters())
            {
                Type paraType = para.ParameterType;//获取参数的类型
                object paraInstance = this.ResolveObject(paraType);
                //string parakey = paraType.FullName;
                //Type paraTargetType = this.ContainerDictionary[parakey];
                //object paraInstance = Activator.CreateInstance(paraTargetType);
                paraList.Add(paraInstance);
            }
            #endregion

            object oInstance = Activator.CreateInstance(type,paraList.ToArray());//用无参数构造函数来构造对象
            #region 属性注入
            foreach (var prop in type.GetProperties().Where(p=>p.IsDefined(typeof(PropertyInjectionAttribute),true)))
            {
                Type propType = prop.PropertyType;
                object propInstance = this.ResolveObject(propType);
                prop.SetValue(oInstance, propInstance);
            }
            #endregion
            #region 方法注入

            #endregion

            return oInstance;
        }
    }
}

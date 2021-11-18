using System;
using System.Collections.Generic;
using System.Text;

namespace IOCDIFramework.CustomContainer
{
    public interface IContainer
    {
         void Register<TFrom, TTo>() where TTo : TFrom;

         TFrom Resolve<TFrom>();
    }
}

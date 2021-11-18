using System;
using System.Collections.Generic;
using System.Text;

namespace IOCDIFramework.CustomContainer
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyInjectionAttribute :Attribute
    {
    }
}

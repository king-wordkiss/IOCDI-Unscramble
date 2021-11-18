using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace IOCDIFramework
{
    public class ConfigurationManger
    {
        private static IConfigurationRoot _iConfigurationRoot;
        static ConfigurationManger() 
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsetting.json");
            _iConfigurationRoot = builder.Build();
        }

        public static string GetNode(string nodeName) 
        {
            return _iConfigurationRoot[nodeName];
        }
    }
}

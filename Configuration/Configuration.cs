using IConfiguration;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Configuration
{
    public class Configuration : IConfiguration.IConfiguration
    {
        private static IConfigurationRoot configurationRoot;

        static Configuration()
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");

            configurationRoot = builder.Build();
        }

        /// <summary>
        /// 访问配置文件的配置项
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Read(string key)
        {
            return Configuration.configurationRoot[key];
        }
    }
}

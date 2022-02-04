using EFCore;
using IConfiguration;
using IEFContext;
using System;

namespace EFContext
{
    public class EFContext : IEFContext.IEFContext
    {
        IConfiguration.IConfiguration _configuration;
        public EFContext(IConfiguration.IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public EFCoreContext CreateDBContext()
        {
            return new EFCoreContext(_configuration.Read("DBConnectStr")); //读取数据库连接字符串
        }
    }
}

using IEFContext;
using IService;
using Microsoft.EntityFrameworkCore;
using System;
using Common.Models;

namespace Service
{
    public class LoginService :ServiceBase,ILoginService
    {
        //实例化LoginService时，把实例对象eFContext传到它的基类Service中去了
        public LoginService(IEFContext.IEFContext eFContext):base(eFContext)
        {
            
        }
       
    }
}

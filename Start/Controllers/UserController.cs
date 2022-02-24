using Common.Models;
using IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Start.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        ILoginService _loginService;
        public UserController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
       [Route("login")]//不加的话访问不到该方法  访问地址api/user/login
        public IActionResult Login([FromForm]string username,[FromForm] int password)
        {
            try
            {
                var users = _loginService.Query<Tab_operator>(u => u.op_name == username && u.op_psw == password);

                if (users?.Count() > 0)
                {
                    var userInfo = users.ToList();
                    Tab_operator operators = userInfo[0];

                    //可以根据权限不同返回一个对应菜单


                    return Ok(operators);
                }
                else
                {
                    return NoContent();
                }
            }
            catch(Exception e) 
            { return NoContent(); }
        }

        [HttpGet]
        [Route("datagridall")]//不加的话访问不到该方法  访问地址api/user/login
        public IActionResult Datagridall()
        {
            try
            {
                var users = _loginService.Query<Tab_operator>(u => u.op_name != "admin");

                var userInfo = users.ToList();

                return Ok(userInfo);
            }
            catch (Exception e) { return Ok("读取失败");  }
        }
    }
}

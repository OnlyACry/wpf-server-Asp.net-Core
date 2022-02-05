using Common.Models;
using IService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Start.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class decaypoolController : ControllerBase
    {
        IfdecaypoolService _ifdecaypoolService;
        public decaypoolController(IfdecaypoolService ifdecaypoolService)
        {
            _ifdecaypoolService = ifdecaypoolService;
        }

        [HttpGet]
        [Route("datagridall")]//不加的话访问不到该方法  访问地址api/user/login
        public IActionResult datagridall()
        {
            //var all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => true);
            var all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => u.WorkMode == "0");

            if (all_DecayPools?.Count() > 0)
            {
                var userInfo = all_DecayPools.ToList();

                //可以根据权限不同返回一个对应菜单
                return Ok(userInfo);
            }
            else
            {
                return Ok("测试成功");
            }

        }
        //[HttpGet]
        //[Route("combobox1")]//不加的话访问不到该方法  访问地址api/user/login
        //public IActionResult combobox1()
        //{
        //    //var all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => true);
        //    var all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => u.DecayPoolName);

        //    if (all_DecayPools?.Count() > 0)
        //    {
        //        var userInfo = all_DecayPools.ToList();

        //        //可以根据权限不同返回一个对应菜单
        //        return Ok(userInfo);
        //    }
        //    else
        //    {
        //        return Ok("测试成功");
        //    }

        //}
    }
}

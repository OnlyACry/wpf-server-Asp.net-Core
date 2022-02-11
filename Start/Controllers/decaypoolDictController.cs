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
    public class decaypoolDictController : ControllerBase
    {
        IfdecaypoolService _ifdecaypoolService;
        public decaypoolDictController(IfdecaypoolService ifdecaypoolService)
        {
            _ifdecaypoolService = ifdecaypoolService;
        }

        /// <summary>
        /// 查询对应工作模式的衰变池字典数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("pooldictall")]//不加的话访问不到该方法  访问地址api/user/login
        public IActionResult pooldictall([FromForm] string WorkMode)
        {
            try
            {
                var all_DecayPools = _ifdecaypoolService.Query<dict_DecayPool>(u => u.DecayPoolType == WorkMode);

                if (all_DecayPools?.Count() > 0)
                {
                    var userInfo = all_DecayPools.ToList();

                    //可以根据权限不同返回一个对应菜单
                    return Ok(userInfo);
                }
                else
                {
                    return Ok("");
                }
            }
            catch (Exception e0)
            {
                return Ok("测试失败");
            }
        }

        [HttpPost]
        [Route("pooldictSignal")]//不加的话访问不到该方法  访问地址api/user/login
        public IActionResult pooldictSignal([FromForm] string PoolName)
        {
            try
            {
                var all_DecayPools = _ifdecaypoolService.Query<dict_DecayPool>(u => u.DecayPoolName == PoolName);

                if (all_DecayPools?.Count() > 0)
                {
                    var userInfo = all_DecayPools.ToList();

                    //可以根据权限不同返回一个对应菜单
                    return Ok(userInfo);
                }
                else
                {
                    return Ok("");
                }
            }
            catch (Exception e0)
            {
                return Ok("测试失败");
            }
        }
    }

    
}

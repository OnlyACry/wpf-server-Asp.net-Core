using Common.Models;
using IService;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Start.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignController : ControllerBase
    {
        IfdecaypoolService _ifdecaypoolService;
        public SignController(IfdecaypoolService ifdecaypoolService)
        {
            _ifdecaypoolService = ifdecaypoolService;
        }

        #region 查询
        [HttpPost]
        [Route("queryType")]//不加的话访问不到该方法  访问地址api/user/login
        public IActionResult datagridall([FromForm] string isopen)
        {
            //var all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => true);
            try
            {
                var all_ryzzs = _ifdecaypoolService.Query<dict_Sign>(u => u.IsOpen == Convert.ToInt32(isopen));

                if (all_ryzzs?.Count() > 0)
                {
                    var userInfo = all_ryzzs.ToList();

                    //可以根据权限不同返回一个对应菜单
                    return Ok(userInfo);
                }
                else return Ok("");
            }
            catch (Exception e0)
            {
                return Ok("");
            }
        }
        #endregion
    }
}

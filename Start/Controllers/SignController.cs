using Common.Models;
using IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        #region 查询记录类型
        [HttpPost]
        [Route("queryType")]//不加的话访问不到该方法  访问地址api/user/login
        public IActionResult queryType([FromForm]string isopen)
        {
            try
            {
                int s = Convert.ToInt32(isopen);
                var all_DecayPools = _ifdecaypoolService.Query<tb_Sign>(a => a.IsOpen == s);

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
            catch (Exception e1)
            {
                return Ok("测试失败");
            }

        }
        #endregion
    }
}

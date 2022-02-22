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
    public class decaypoolsecController : ControllerBase
    {
        IfdecaypoolService _ifdecaypoolService;
        public decaypoolsecController(IfdecaypoolService ifdecaypoolService)
        {
            _ifdecaypoolService = ifdecaypoolService;
        }

        #region 给衰变池开启/封闭
        [HttpPost]
        [Route("insertdata")]//不加的话访问不到该方法  访问地址api/user/login
        public IActionResult insertdata([FromForm] string decayPool)
        {
            try
            {
                //设置反序列化时跳过空值
                JsonSerializerSettings jsetting = new JsonSerializerSettings();
                jsetting.NullValueHandling = NullValueHandling.Ignore;
                //衰变池信息的反序列化
                tb_DecayPool DecayPool = JsonConvert.DeserializeObject<tb_DecayPool>(decayPool, jsetting);

                _ifdecaypoolService.Insert(DecayPool);

                return Ok("true");
            }
            catch (Exception e1)
            {
                return Ok(e1.Message);
            }

        }
        #endregion

        #region 查询衰变池是否开启/封闭
        [HttpPost]
        [Route("poolopen")]//不加的话访问不到该方法  访问地址api/user/login
        public IActionResult poolopen([FromForm] string PoolName, [FromForm] string Memo)
        {
            //var all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => true);
            try
            {
                var all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => u.WorkMode == "1" && u.DecayPoolName == PoolName && u.IsValid == 1 && u.Memo == Memo).OrderBy(u => u.RecordNo);

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

        #region 查询全部数据
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("datagridall")]//不加的话访问不到该方法  访问地址api/user/login
        public IActionResult datagridall()
        {
            try
            {
                var all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => u.WorkMode == "1" && u.IsValid == 1);

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
        #endregion

        #region 选择了衰变池，未选择记录类型
        /// <summary>
        /// 选择了衰变池，未选择记录类型
        /// </summary>
        /// <param name="poolname"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("poolselect")]//不加的话访问不到该方法  访问地址api/user/login
        public IActionResult Poolselect([FromForm] string PoolType)
        {
            //var all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => true);
            try
            {
                var all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => u.WorkMode == "1" && u.DecayPoolName == PoolType && u.IsValid == 1).OrderBy(u => u.RecordNo);

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

        #region 选择记录类型，未选择衰变池
        [HttpPost]
        [Route("typeselect")]//不加的话访问不到该方法  访问地址api/user/login
        public IActionResult typeselect([FromForm] string NoteType)
        {
            try
            {
                var all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => u.WorkMode == "1" && u.DecayPoolRecord == NoteType && u.IsValid == 1).OrderBy(u => u.RecordNo);

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

        #region 选择记录类型，选择衰变池
        [HttpPost]
        [Route("pooltypeselect")]//不加的话访问不到该方法  访问地址api/user/login
        public IActionResult pooltypeselect([FromForm] string PoolType, [FromForm] string NoteType)
        {
            try
            {
                var all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => u.WorkMode == "1" && u.DecayPoolName == PoolType && u.DecayPoolRecord == NoteType && u.IsValid == 1).OrderBy(u => u.RecordNo);

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

        #region 查询预估用水和 => 间歇存储式
        [HttpPost]
        [Route("selectWater2")]//不加的话访问不到该方法  访问地址api/user/login
        public IActionResult selectWater2([FromForm]DateTime starttime)
        {
            try
            {
                var all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => u.WorkMode == "1" && u.IsValid == 1 && u.RecordNo.Contains("M") && u.DecayPoolTime >= starttime && u.DecayPoolTime <= DateTime.Now);

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
        #endregion
    }
}

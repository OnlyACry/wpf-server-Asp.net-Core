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
            try
            {
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
            catch(Exception e0)
            {
                return Ok("测试失败");
            }
        }
        /// <summary>
        /// 根据选择的衰变池从数据库中读取数据 适用于更新、初始选择时的显示
        /// </summary>
        /// <param name="poolname"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("poolselect")]//不加的话访问不到该方法  访问地址api/user/login
        public IActionResult Poolselect([FromForm] string poolname)
        {
            //var all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => true);
            try
            {
                var all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => u.WorkMode == "0" && u.DecayPoolName == poolname);

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
            catch(Exception e1)
            {
                return Ok("测试失败");
            }

        }

        [HttpPost]
        [Route("updatedata")]//不加的话访问不到该方法  访问地址api/user/login
        public IActionResult updatedata([FromForm] string decayPool)
        {
            try
            {
                //设置反序列化时跳过空值
                JsonSerializerSettings jsetting = new JsonSerializerSettings();
                jsetting.NullValueHandling = NullValueHandling.Ignore;
                //衰变池信息的反序列化
                tb_DecayPool DecayPool = JsonConvert.DeserializeObject<tb_DecayPool>(decayPool, jsetting);

                _ifdecaypoolService.Update(DecayPool);

                return Ok("true");
            }
            catch (Exception e1)
            {
                return Ok(e1.Message);
            }

        }
        /// <summary>
        /// 插入衰变池数据
        /// </summary>
        /// <param name="decayPool"></param>
        /// <returns></returns>
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

        [HttpPost]
        [Route("deletedata")]//不加的话访问不到该方法  访问地址api/user/login
        public IActionResult deletedata([FromForm] string ListdecayPool)
        {
            try
            {
                //设置反序列化时跳过空值
                JsonSerializerSettings jsetting = new JsonSerializerSettings();
                jsetting.NullValueHandling = NullValueHandling.Ignore;
                //衰变池信息的反序列化
                List<tb_DecayPool> DecayPool = JsonConvert.DeserializeObject<List<tb_DecayPool>>(ListdecayPool, jsetting);

                _ifdecaypoolService.Delete(DecayPool);

                return Ok("true");
            }
            catch (Exception e1)
            {
                return Ok(e1.Message);
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

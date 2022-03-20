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
    public class ryzzController : ControllerBase
    {
        IfdecaypoolService _ifdecaypoolService;
        public ryzzController(IfdecaypoolService ifdecaypoolService)
        {
            _ifdecaypoolService = ifdecaypoolService;
        }

        #region 查询
        [HttpGet]
        [Route("datagridall")]//不加的话访问不到该方法  访问地址api/user/login
        public IActionResult datagridall()
        {
            //var all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => true);
            try
            {
                var all_ryzzs = _ifdecaypoolService.Query<tb_Ryzz>(u => true).OrderBy(u => u.DocumentCode);

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

        #region 新增
        [HttpPost]
        [Route("insertdata")]//不加的话访问不到该方法  访问地址api/user/login
        public IActionResult insertdata([FromForm] string ry)
        {
            try
            {
                //设置反序列化时跳过空值
                JsonSerializerSettings jsetting = new JsonSerializerSettings();
                jsetting.NullValueHandling = NullValueHandling.Ignore;
                //衰变池信息的反序列化
                tb_Ryzz tb_ry = JsonConvert.DeserializeObject<tb_Ryzz>(ry, jsetting);

                _ifdecaypoolService.Insert(tb_ry);

                return Ok("true");
            }
            catch (Exception e1)
            {
                return Ok(e1.Message);
            }

        }
        #endregion

        #region 修改
        [HttpPost]
        [Route("updatedata")]//不加的话访问不到该方法  访问地址api/user/login
        public IActionResult updatedata([FromForm] string ry)
        {
            try
            {
                //设置反序列化时跳过空值
                JsonSerializerSettings jsetting = new JsonSerializerSettings();
                jsetting.NullValueHandling = NullValueHandling.Ignore;
                //衰变池信息的反序列化
                tb_Ryzz rb_ry = JsonConvert.DeserializeObject<tb_Ryzz>(ry, jsetting);

                _ifdecaypoolService.Update(rb_ry);

                return Ok("true");
            }
            catch (Exception e1)
            {
                return Ok(e1.Message);
            }

        }
        #endregion

        #region 删除
        [HttpPost]
        [Route("deletedata")]//不加的话访问不到该方法  访问地址api/user/login
        public IActionResult deletedata([FromForm] string List_ryzz)
        {
            try
            {
                //设置反序列化时跳过空值
                JsonSerializerSettings jsetting = new JsonSerializerSettings();
                jsetting.NullValueHandling = NullValueHandling.Ignore;
                //衰变池信息的反序列化
                List<tb_Ryzz> tb_Ryzz = JsonConvert.DeserializeObject<List<tb_Ryzz>>(List_ryzz, jsetting);

                _ifdecaypoolService.Delete<tb_Ryzz>(tb_Ryzz);

                return Ok("true");
            }
            catch (Exception e1)
            {
                return Ok(e1.Message);
            }

        }
        #endregion
    }
}

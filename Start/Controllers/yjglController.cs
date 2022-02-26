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
    public class yjglController : ControllerBase
    {
        IfdecaypoolService _ifdecaypoolService;
        public yjglController(IfdecaypoolService ifdecaypoolService)
        {
            _ifdecaypoolService = ifdecaypoolService;
        }

        #region 查询全部数据
        [HttpGet]
        [Route("datagridall")]//不加的话访问不到该方法  访问地址api/user/login
        public IActionResult datagridall()
        {
            try
            {
                var all_Emer = _ifdecaypoolService.Query<tb_Emergency>(u => u.IsValid == 1);

                if (all_Emer?.Count() > 0)
                {
                    var userInfo = all_Emer.ToList();

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
                return Ok("");
            }
        }
        #endregion

        #region 删除数据
        [HttpPost]
        [Route("deletedata")]//不加的话访问不到该方法  访问地址api/user/login
        public IActionResult deletedata([FromForm] string List_Emer)
        {
            try
            {
                //设置反序列化时跳过空值
                JsonSerializerSettings jsetting = new JsonSerializerSettings();
                jsetting.NullValueHandling = NullValueHandling.Ignore;
                //衰变池信息的反序列化
                List<tb_Emergency> DecayPool = JsonConvert.DeserializeObject<List<tb_Emergency>>(List_Emer, jsetting);

                _ifdecaypoolService.Delete<tb_Emergency>(DecayPool);

                return Ok("true");
            }
            catch (Exception e1)
            {
                return Ok(e1.Message);
            }

        }
        #endregion

        #region 修改数据
        [HttpPost]
        [Route("updatedata")]//不加的话访问不到该方法  访问地址api/user/login
        public IActionResult updatedata([FromForm] string emer)
        {
            try
            {
                //设置反序列化时跳过空值
                JsonSerializerSettings jsetting = new JsonSerializerSettings();
                jsetting.NullValueHandling = NullValueHandling.Ignore;
                //衰变池信息的反序列化
                tb_Emergency emergency = JsonConvert.DeserializeObject<tb_Emergency>(emer, jsetting);

                _ifdecaypoolService.Update(emergency);

                return Ok("true");
            }
            catch (Exception e1)
            {
                return Ok(e1.Message);
            }

        }
        #endregion

        #region 增加数据
        [HttpPost]
        [Route("insertdata")]//不加的话访问不到该方法  访问地址api/user/login
        public IActionResult insertdata([FromForm] string Emer)
        {
            try
            {
                //设置反序列化时跳过空值
                JsonSerializerSettings jsetting = new JsonSerializerSettings();
                jsetting.NullValueHandling = NullValueHandling.Ignore;
                //衰变池信息的反序列化
                tb_Emergency emergency = JsonConvert.DeserializeObject<tb_Emergency>(Emer, jsetting);

                _ifdecaypoolService.Insert(emergency);

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

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
    public class zkwjController:ControllerBase
    {

        IfdecaypoolService _ifdecaypoolService;
        public zkwjController(IfdecaypoolService ifdecaypoolService)
        {
            _ifdecaypoolService = ifdecaypoolService;
        }

        #region 查询
        [HttpGet]
        [Route("datagridall")]//不加的话访问不到该方法  访问地址api/user/login
        public IActionResult datagridall()
        {
           
            try
            {
                var all_zkgls = _ifdecaypoolService.Query<tb_QCFile>(u => true).OrderBy(u => u.QCCode);

                if (all_zkgls?.Count() > 0)
                {
                    var userInfo = all_zkgls.ToList();

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
        public IActionResult insertdata([FromForm] string zk)
        {
            try
            {
                //设置反序列化时跳过空值
                JsonSerializerSettings jsetting = new JsonSerializerSettings();
                jsetting.NullValueHandling = NullValueHandling.Ignore;
                //衰变池信息的反序列化
                tb_QCFile tb_zk = JsonConvert.DeserializeObject<tb_QCFile>(zk, jsetting);

                _ifdecaypoolService.Insert(tb_zk);

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
        public IActionResult updatedata([FromForm] string zk)
        {
            try
            {
                //设置反序列化时跳过空值
                JsonSerializerSettings jsetting = new JsonSerializerSettings();
                jsetting.NullValueHandling = NullValueHandling.Ignore;
                //衰变池信息的反序列化
                tb_QCFile rb_zk = JsonConvert.DeserializeObject<tb_QCFile>(zk, jsetting);

                _ifdecaypoolService.Update(rb_zk);

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
        public IActionResult deletedata([FromForm] string List_zkwj)
        {
            try
            {
                //设置反序列化时跳过空值
                JsonSerializerSettings jsetting = new JsonSerializerSettings();
                jsetting.NullValueHandling = NullValueHandling.Ignore;
                //衰变池信息的反序列化
                List<tb_QCFile> tb_zkwj = JsonConvert.DeserializeObject<List<tb_QCFile>>(List_zkwj, jsetting);

                _ifdecaypoolService.Delete<tb_QCFile>(tb_zkwj);

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

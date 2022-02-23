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

        #region 查询全部
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("datagridall")]//不加的话访问不到该方法  访问地址api/user/login
        public IActionResult datagridall()
        {
            //var all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => true);
            try
            {
                var all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => u.WorkMode == "0" && u.IsValid == 1);

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
        #endregion

        #region 查询当前日期的衰变池数据
        [HttpGet]
        [Route("datenow")]//不加的话访问不到该方法  访问地址api/user/login
        public IActionResult datenow()
        {
            //var all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => true);
            try
            {
                var all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => u.WorkMode == "0" && u.IsValid == 1 && u.DecayPoolTime.ToString().Contains(DateTime.Now.ToString("d")));

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
                var all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => u.WorkMode == "0" && u.DecayPoolName == PoolType && u.IsValid == 1).OrderBy(u => u.DecayPoolCode);

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
            catch(Exception e1)
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
                var all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => u.WorkMode == "0" && u.DecayPoolRecord == NoteType && u.IsValid == 1);

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
                var all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => u.WorkMode == "0" && u.DecayPoolName == PoolType && u.DecayPoolRecord == NoteType && u.IsValid == 1).OrderBy(u=>u.DecayPoolCode);

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
            catch (Exception e1)
            {
                return Ok("测试失败");
            }

        }
        #endregion

        #region 更新数据
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="decayPool"></param>
        /// <returns></returns>
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
        #endregion

        #region 插入数据
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
        #endregion

        #region 删除数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="ListdecayPool"></param>
        /// <returns></returns>
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

                _ifdecaypoolService.Delete<tb_DecayPool>(DecayPool);

                return Ok("true");
            }
            catch (Exception e1)
            {
                return Ok(e1.Message);
            }

        }
        #endregion

        #region 查找
        /// <summary>
        /// 查找对应信息，有选定衰变池时
        /// </summary>
        /// <param name="SelectItem"></param>
        /// <param name="PoolName"></param>
        /// <param name="Item"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("searchdata")]//不加的话访问不到该方法  访问地址api/user/login
        public IActionResult searchdata([FromForm] string SelectItem, [FromForm] string PoolName, [FromForm] string Item)
        {
            try
            {
                var all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => u.WorkMode == "0" && u.IsValid == 1);
                switch (SelectItem)
                {
                    case "DecayPoolName":
                        all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => u.WorkMode == "0" && u.IsValid == 1 && u.DecayPoolName == PoolName && u.DecayPoolName == Item);
                        break;
                    case "DecayPoolTime":
                        all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => u.WorkMode == "0" && u.IsValid == 1 && u.DecayPoolName == PoolName && u.DecayPoolTime == Convert.ToDateTime(Item));
                        break;
                    case "RecordNo":
                        all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => u.WorkMode == "0" && u.IsValid == 1 && u.DecayPoolName == PoolName && u.RecordNo == Item);
                        break;
                    case "OperUser":
                        all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => u.WorkMode == "0" && u.IsValid == 1 && u.DecayPoolName == PoolName && u.OperUser == Item);
                        break;
                    case "PatientNum":
                        all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => u.WorkMode == "0" && u.IsValid == 1 && u.DecayPoolName == PoolName && u.PatientNum == int.Parse(Item));
                        break;
                    case "PreWater":
                        all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => u.WorkMode == "0" && u.IsValid == 1 && u.DecayPoolName == PoolName && u.PreWater == Item);
                        break;
                    case "OtherWater":
                        all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => u.WorkMode == "0" && u.IsValid == 1 && u.DecayPoolName == PoolName && u.OtherWater == Item);
                        break;
                    case "WaterTotal":
                        all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => u.WorkMode == "0" && u.IsValid == 1 && u.DecayPoolName == PoolName && u.WaterTotal == Item);
                        break;
                    case "ReferValue":
                        all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => u.WorkMode == "0" && u.IsValid == 1 && u.DecayPoolName == PoolName && u.ReferValue == Item);
                        break;
                    case "IntervalTime":
                        all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => u.WorkMode == "0" && u.IsValid == 1 && u.DecayPoolName == PoolName && u.IntervalTime == Item);
                        break;
                    case "OperTime":
                        all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => u.WorkMode == "0" && u.IsValid == 1 && u.DecayPoolName == PoolName && u.OperTime == Convert.ToDateTime(Item));
                        break;
                }
                return Ok(all_DecayPools);

            }
            catch (Exception e1)
            {
                return Ok(e1.Message);
            }

        }
        #endregion
        #region 搜索框，无衰变池选择
        /// <summary>
        /// 查找相应信息，无选择衰变池时
        /// </summary>
        /// <param name="SelectItem"></param>
        /// <param name="PoolName"></param>
        /// <param name="Item"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("searchdatapoolnull")]//不加的话访问不到该方法  访问地址api/user/login
        public IActionResult searchdatapoolnull([FromForm] string SelectItem, [FromForm] string Item)
        {
            try
            {
                var all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => u.WorkMode == "0");
                switch (SelectItem)
                {
                    case "DecayPoolName":
                        all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => u.WorkMode == "0" && u.DecayPoolName == Item);
                        break;
                    case "DecayPoolTime":
                        all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => u.WorkMode == "0" && u.DecayPoolTime == Convert.ToDateTime(Item));
                        break;
                    case "RecordNo":
                        all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => u.WorkMode == "0" && u.RecordNo == Item);
                        break;
                    case "OperUser":
                        all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => u.WorkMode == "0" && u.OperUser == Item);
                        break;
                    case "PatientNum":
                        all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => u.WorkMode == "0" && u.PatientNum == int.Parse(Item));
                        break;
                    case "PreWater":
                        all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => u.WorkMode == "0" && u.PreWater == Item);
                        break;
                    case "OtherWater":
                        all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => u.WorkMode == "0" && u.OtherWater == Item);
                        break;
                    case "WaterTotal":
                        all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => u.WorkMode == "0" && u.WaterTotal == Item);
                        break;
                    case "ReferValue":
                        all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => u.WorkMode == "0" && u.ReferValue == Item);
                        break;
                    case "IntervalTime":
                        all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => u.WorkMode == "0" && u.IntervalTime == Item);
                        break;
                    case "OperTime":
                        all_DecayPools = _ifdecaypoolService.Query<tb_DecayPool>(u => u.WorkMode == "0" && u.OperTime == Convert.ToDateTime(Item));
                        break;
                }
                return Ok(all_DecayPools);
            }
            catch (Exception e1)
            {
                return Ok(e1.Message);
            }

        }
        #endregion
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

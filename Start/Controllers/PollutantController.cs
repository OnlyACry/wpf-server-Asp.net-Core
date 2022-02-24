using Common.Models;
using IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Start.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollutantController:ControllerBase
    {
        IPollutantService _pollutantService;
        public PollutantController(IPollutantService pollutantService)
        {
            _pollutantService = pollutantService;
        }

        //得到datagrid的数据源
        [HttpPost]
        [Route("getAll")]
        public IActionResult getAll([FromForm] string PollutantType)
        {
                if (PollutantType== "PollutantRecordDatagrid_sc_gt")
            {
              var Pollut1 = _pollutantService.Query<tb_Pollutant_sc_gt>(u => u.IsValid == 1);
                if (Pollut1?.Count() > 0)
                {
                    var Pollut1Info = Pollut1.ToList();
                    return Ok(Pollut1Info);
                }
                else
                {
                    return NoContent();
                }

            }
            
          else  if (PollutantType == "PollutantRecordDatagrid_sc_yt")
            {
                var Pollut2 = _pollutantService.Query<tb_Pollutant_sc_yt>(u => u.IsValid == 1);
                if (Pollut2?.Count() > 0)
                {
                    var Pollut1Info = Pollut2.ToList();
                    return Ok(Pollut1Info);
                }
                else
                {
                    return NoContent();
                }

            }
            else if(PollutantType == "PollutantRecordDatagrid_sc_qt")
            {
                var Pollut3 = _pollutantService.Query<tb_Pollutant_sc_qt>(u => u.IsValid == 1);
                if (Pollut3?.Count() > 0)
                {
                    var Pollut1Info = Pollut3.ToList();
                    return Ok(Pollut1Info);
                }
                else
                {
                    return NoContent();
                }

            }
            else if (PollutantType == "PollutantRecordDatagrid_zs_gt")
            {
                var Pollut4 = _pollutantService.Query<tb_Pollutant_zs_gt>(u => u.IsValid == 1);
                if (Pollut4?.Count() > 0)
                {
                    var Pollut1Info = Pollut4.ToList();
                    return Ok(Pollut1Info);
                }
                else
                {
                    return NoContent();
                }
            }
            else if (PollutantType == "PollutantRecordDatagrid_zs_yt")
            {
                var Pollut5 = _pollutantService.Query<tb_Pollutant_zs_yt>(u => u.IsValid == 1);
                if (Pollut5?.Count() > 0)
                {
                    var Pollut1Info = Pollut5.ToList();
                    return Ok(Pollut1Info);
                }
                else
                {
                    return NoContent();
                }

            }
            else if (PollutantType == "PollutantRecordDatagrid_zs_qt")
            {
                var Pollut6 = _pollutantService.Query<tb_Pollutant_zs_qt>(u => u.IsValid == 1);

                if (Pollut6?.Count() > 0)
                {
                    var Pollut1Info = Pollut6.ToList();
                    return Ok(Pollut1Info);
                }
                else
                {
                    return NoContent();
                }

            }
            else if (PollutantType == "PollutantRecordDatagrid_bf_gt")
            {
                var Pollut7 = _pollutantService.Query<tb_Pollutant_bf_gt>(u => u.IsValid == 1);

                if (Pollut7?.Count() > 0)
                {
                    var Pollut1Info = Pollut7.ToList();
                    return Ok(Pollut1Info);
                }
                else
                {
                    return NoContent();
                }
            }
            else if (PollutantType == "PollutantRecordDatagrid_bf_yt")
            {
                var Pollut8 = _pollutantService.Query<tb_Pollutant_bf_yt>(u => u.IsValid == 1);

                if (Pollut8?.Count() > 0)
                {
                    var Pollut1Info = Pollut8.ToList();
                    return Ok(Pollut1Info);
                }
                else
                {
                    return NoContent();
                }
            }
            else 
            {
                var Pollut9 = _pollutantService.Query<tb_Pollutant_bf_qt>(u => u.IsValid == 1);
                if (Pollut9?.Count() > 0)
                {
                    var Pollut1Info = Pollut9.ToList();
                    return Ok(Pollut1Info);
                }
                else
                {
                    return NoContent();
                }
            }

        }


        [HttpPost]
        [Route("AddRecord")]
        public IActionResult AddRecord([FromForm] string PollutantType, [FromForm] string PollutantRecordStr)
        {
          string result=  CommonMethod(PollutantType, PollutantRecordStr, 1);
            return Ok(result);
        }
        [HttpPost]
        [Route("ReRecord")]
        public IActionResult ReRecord([FromForm] string PollutantType, [FromForm] string PollutantRecordStr)
        {
            string result = CommonMethod(PollutantType, PollutantRecordStr, 2);
            return Ok(result);


        }


        [HttpPost]
        [Route("DeRecord")]
        public IActionResult DeRecord([FromForm] string PollutantType, [FromForm] string PollutantRecordStr)
        {
            string result = CommonMethod(PollutantType, PollutantRecordStr, 3);
            return Ok(result);
        }
        /// <summary>
        /// 增删改通用方法
        /// </summary>
        /// <param name="PollutantType">污染物表类型</param>
        /// <param name="PollutantRecordStr"></param>
        /// <param name="flag">1表示增加，2表示修改，3表示删除</param>
        /// <returns></returns>
        public string CommonMethod(string PollutantType,string PollutantRecordStr,int flag)
        {
            if (PollutantType == "PollutantRecordDatagrid_sc_gt")
            {
                try
                {
                    tb_Pollutant_sc_gt PollutantRecord = JsonConvert.DeserializeObject<tb_Pollutant_sc_gt>(PollutantRecordStr);
                    switch (flag)
                    {
                        case 1:  _pollutantService.Insert<tb_Pollutant_sc_gt>(PollutantRecord);
                            break;
                        case 2:  _pollutantService.Update<tb_Pollutant_sc_gt>(PollutantRecord);
                            break;
                        case 3:  _pollutantService.Delete<tb_Pollutant_sc_gt>(PollutantRecord);
                            break;
                    }

                   
                    return "true";
                }
                catch (Exception e)
                {
                    return e.Message;
                }

            }
            else if (PollutantType == "PollutantRecordDatagrid_sc_yt")
            {
                try
                {
                    tb_Pollutant_sc_yt PollutantRecord = JsonConvert.DeserializeObject<tb_Pollutant_sc_yt>(PollutantRecordStr);
                    switch (flag)
                    {
                        case 1:
                            _pollutantService.Insert<tb_Pollutant_sc_yt>(PollutantRecord);
                            break;
                        case 2:
                            _pollutantService.Update<tb_Pollutant_sc_yt>(PollutantRecord);
                            break;
                        case 3:
                            _pollutantService.Delete<tb_Pollutant_sc_yt>(PollutantRecord);
                            break;
                    }
                    return "true";
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
            else if (PollutantType == "PollutantRecordDatagrid_sc_qt")
            {
                try
                {
                    tb_Pollutant_sc_qt PollutantRecord = JsonConvert.DeserializeObject<tb_Pollutant_sc_qt>(PollutantRecordStr);
                    switch (flag)
                    {
                        case 1:
                            _pollutantService.Insert<tb_Pollutant_sc_qt>(PollutantRecord);
                            break;
                        case 2:
                            _pollutantService.Update<tb_Pollutant_sc_qt>(PollutantRecord);
                            break;
                        case 3:
                            _pollutantService.Delete<tb_Pollutant_sc_qt>(PollutantRecord);
                            break;
                    }
                    return "true";
                }
                catch (Exception e)
                {
                    return e.Message;
                }

            }
            else if (PollutantType == "PollutantRecordDatagrid_zs_gt")
            {
                try
                {
                    tb_Pollutant_zs_gt PollutantRecord = JsonConvert.DeserializeObject<tb_Pollutant_zs_gt>(PollutantRecordStr);
                    switch (flag)
                    {
                        case 1:
                            _pollutantService.Insert<tb_Pollutant_zs_gt>(PollutantRecord);
                            break;
                        case 2:
                            _pollutantService.Update<tb_Pollutant_zs_gt>(PollutantRecord);
                            break;
                        case 3:
                            _pollutantService.Delete<tb_Pollutant_zs_gt>(PollutantRecord);
                            break;
                    }
                    return "true";
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
            else if (PollutantType == "PollutantRecordDatagrid_zs_yt")
            {
                try
                {
                    tb_Pollutant_zs_yt PollutantRecord = JsonConvert.DeserializeObject<tb_Pollutant_zs_yt>(PollutantRecordStr);
                    switch (flag)
                    {
                        case 1:
                            _pollutantService.Insert<tb_Pollutant_zs_yt>(PollutantRecord);
                            break;
                        case 2:
                            _pollutantService.Update<tb_Pollutant_zs_yt>(PollutantRecord);
                            break;
                        case 3:
                            _pollutantService.Delete<tb_Pollutant_zs_yt>(PollutantRecord);
                            break;
                    }
                    return "true";
                }
                catch (Exception e)
                {
                    return e.Message;
                }

            }
            else if (PollutantType == "PollutantRecordDatagrid_zs_qt")
            {
                try
                {
                    tb_Pollutant_zs_qt PollutantRecord = JsonConvert.DeserializeObject<tb_Pollutant_zs_qt>(PollutantRecordStr);
                    switch (flag)
                    {
                        case 1:
                            _pollutantService.Insert<tb_Pollutant_zs_qt>(PollutantRecord);
                            break;
                        case 2:
                            _pollutantService.Update<tb_Pollutant_zs_qt>(PollutantRecord);
                            break;
                        case 3:
                            _pollutantService.Delete<tb_Pollutant_zs_qt>(PollutantRecord);
                            break;
                    }
                    return "true";
                }
                catch (Exception e)
                {
                    return e.Message;
                }

            }
            else if (PollutantType == "PollutantRecordDatagrid_bf_gt")
            {
                try
                {
                    tb_Pollutant_bf_gt PollutantRecord = JsonConvert.DeserializeObject<tb_Pollutant_bf_gt>(PollutantRecordStr);
                    switch (flag)
                    {
                        case 1:
                            _pollutantService.Insert<tb_Pollutant_bf_gt>(PollutantRecord);
                            break;
                        case 2:
                            _pollutantService.Update<tb_Pollutant_bf_gt>(PollutantRecord);
                            break;
                        case 3:
                            _pollutantService.Delete<tb_Pollutant_bf_gt>(PollutantRecord);
                            break;
                    }
                    return "true";
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
            else if (PollutantType == "PollutantRecordDatagrid_bf_yt")
            {
                try
                {
                    tb_Pollutant_bf_yt PollutantRecord = JsonConvert.DeserializeObject<tb_Pollutant_bf_yt>(PollutantRecordStr);
                    switch (flag)
                    {
                        case 1:
                            _pollutantService.Insert<tb_Pollutant_bf_yt>(PollutantRecord);
                            break;
                        case 2:
                            _pollutantService.Update<tb_Pollutant_bf_yt>(PollutantRecord);
                            break;
                        case 3:
                            _pollutantService.Delete<tb_Pollutant_bf_yt>(PollutantRecord);
                            break;
                    }
                    return "true";
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
            else
            {
                try
                {
                    tb_Pollutant_bf_qt PollutantRecord = JsonConvert.DeserializeObject<tb_Pollutant_bf_qt>(PollutantRecordStr);
                    switch (flag)
                    {
                        case 1:
                            _pollutantService.Insert<tb_Pollutant_bf_qt>(PollutantRecord);
                            break;
                        case 2:
                            _pollutantService.Update<tb_Pollutant_bf_qt>(PollutantRecord);
                            break;
                        case 3:
                            _pollutantService.Delete<tb_Pollutant_bf_qt>(PollutantRecord);
                            break;
                    }
                    return "true";
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }

        }
    }


    
}

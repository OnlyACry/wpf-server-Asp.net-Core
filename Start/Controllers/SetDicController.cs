using Common.Models;
using IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Start.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetDicController:ControllerBase
    {
        ISetDicService _setDicService;
        public SetDicController(ISetDicService setDicService)
        {
            _setDicService = setDicService;
        }

        //得到字典表的数据源
        [HttpPost]
        [Route("getAllDic")]
        public IActionResult getAllDic([FromForm] string DicType)
        {

            //因为Pollut1声明为局部变量，好像化简不了代码，不能将if else放在外面

            if (DicType == "dict_Med")
            {
                var Pollut1 = _setDicService.Query<dict_Med>(u => u.IsValid == 1);
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
            else if (DicType == "dict_PollutantType")
            {
                var Pollut2 = _setDicService.Query<dict_PollutantType>(u => u.IsValid == 1);
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
            else if (DicType == "dict_Pollutant")
            {
                var Pollut3 = _setDicService.Query<dict_Pollutant>(u => u.IsValid == 1);
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
            else if (DicType == "dict_DecayPool")
            {
                var Pollut4 = _setDicService.Query<dict_DecayPool>(u => u.IsValid == 1);
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
            else if (DicType == "dict_PUnit")
            {
                var Pollut5 = _setDicService.Query<dict_PUnit>(u => u.IsValid == 1);
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
            else if (DicType == "dict_Company")
            {
                var Pollut5 = _setDicService.Query<dict_Company>(u => u.IsValid == 1);
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
            else if (DicType == "dict_Position")
            {
                var Pollut6 = _setDicService.Query<dict_Position>(u => u.IsValid == 1);

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
            else if (DicType == "dict_Process")
            {
                var Pollut7 = _setDicService.Query<dict_Process>(u => u.IsValid == 1);

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
            else if (DicType == "dict_Container")
            {
                var Pollut8 = _setDicService.Query<dict_Container>(u => u.IsValid == 1);

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
            else if (DicType == "dict_Source")
            {
                var Pollut9 = _setDicService.Query<dict_Source>(u => u.IsValid == 1);
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
            else if (DicType == "Tab_operator")
            {
                var Pollut10 = _setDicService.Query<Tab_operator>(u => u.op_valid == 1);
                if (Pollut10?.Count() > 0)
                {
                    var Pollut1Info = Pollut10.ToList();
                    return Ok(Pollut1Info);
                }
                else
                {
                    return NoContent();
                }
            }

            else 
            {
                var Pollut9 = _setDicService.Query<dict_DecayPoolState>(u => u.IsValid == 1);
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
        public IActionResult AddRecord([FromForm] string DicType, [FromForm] string DicRecordStr)
        {
            string result = CommonMethod(DicType, DicRecordStr, 1);
            return Ok(result);
        }
        [HttpPost]
        [Route("ReRecord")]
        public IActionResult ReRecord([FromForm] string DicType, [FromForm] string DicRecordStr)
        {
            string result = CommonMethod(DicType, DicRecordStr, 2);
            return Ok(result);


        }


        [HttpPost]
        [Route("DeRecord")]
        public IActionResult DeRecord([FromForm] string DicType, [FromForm] string DicRecordStr)
        {
            string result = CommonMethod(DicType, DicRecordStr, 3);
            return Ok(result);
        }




        /// <summary>
        /// 增删改通用方法
        /// </summary>
        /// <param name="PollutantType">字典表类型</param>
        /// <param name="PollutantRecordStr"></param>
        /// <param name="flag">1表示增加，2表示修改，3表示删除</param>
        /// <returns></returns>
        public string CommonMethod(string DicType, string DicRecordStr, int flag)
        {
            if (DicType == "dict_Pollutant")
            {
                try
                {
                    dict_Pollutant DicRecord = JsonConvert.DeserializeObject<dict_Pollutant>(DicRecordStr);
                    switch (flag)
                    {
                        case 1:
                            _setDicService.Insert<dict_Pollutant>(DicRecord);
                            break;
                        case 2:
                            _setDicService.Update<dict_Pollutant>(DicRecord);
                            break;
                        case 3:
                            _setDicService.Delete<dict_Pollutant>(DicRecord);
                            break;
                    }


                    return "true";
                }
                catch (Exception e)
                {
                    return e.Message;
                }

            }
            else if (DicType == "dict_Med")
            {
                try
                {
                    dict_Med DicRecord = JsonConvert.DeserializeObject<dict_Med>(DicRecordStr);
                    switch (flag)
                    {
                        case 1:
                            _setDicService.Insert<dict_Med>(DicRecord);
                            break;
                        case 2:
                            _setDicService.Update<dict_Med>(DicRecord);
                            break;
                        case 3:
                            _setDicService.Delete<dict_Med>(DicRecord);
                            break;
                    }
                    return "true";
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
            else if (DicType == "dict_DecayPool")
            {
                try
                {
                    dict_DecayPool DicRecord = JsonConvert.DeserializeObject<dict_DecayPool>(DicRecordStr);
                    switch (flag)
                    {
                        case 1:
                            _setDicService.Insert<dict_DecayPool>(DicRecord);
                            break;
                        case 2:
                            _setDicService.Update<dict_DecayPool>(DicRecord);
                            break;
                        case 3:
                            _setDicService.Delete<dict_DecayPool>(DicRecord);
                            break;
                    }
                    return "true";
                }
                catch (Exception e)
                {
                    return e.Message;
                }

            }
            else if (DicType == "dict_Position")
            {
                try
                {
                    dict_Position DicRecord = JsonConvert.DeserializeObject<dict_Position>(DicRecordStr);
                    switch (flag)
                    {
                        case 1:
                            _setDicService.Insert<dict_Position>(DicRecord);
                            break;
                        case 2:
                            _setDicService.Update<dict_Position>(DicRecord);
                            break;
                        case 3:
                            _setDicService.Delete<dict_Position>(DicRecord);
                            break;
                    }
                    return "true";
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
            else if (DicType == "dict_Process")
            {
                try
                {
                    dict_Process DicRecord = JsonConvert.DeserializeObject<dict_Process>(DicRecordStr);
                    switch (flag)
                    {
                        case 1:
                            _setDicService.Insert<dict_Process>(DicRecord);
                            break;
                        case 2:
                            _setDicService.Update<dict_Process>(DicRecord);
                            break;
                        case 3:
                            _setDicService.Delete<dict_Process>(DicRecord);
                            break;
                    }
                    return "true";
                }
                catch (Exception e)
                {
                    return e.Message;
                }

            }
            else if (DicType == "dict_Company")
            {
                try
                {
                    dict_Company DicRecord = JsonConvert.DeserializeObject<dict_Company>(DicRecordStr);
                    switch (flag)
                    {
                        case 1:
                            _setDicService.Insert<dict_Company>(DicRecord);
                            break;
                        case 2:
                            _setDicService.Update<dict_Company>(DicRecord);
                            break;
                        case 3:
                            _setDicService.Delete<dict_Company>(DicRecord);
                            break;
                    }
                    return "true";
                }
                catch (Exception e)
                {
                    return e.Message;
                }

            }
            else //多种核素标记
            {
                try
                {
                    //tb_Pollutant_bf_gt DicRecord = JsonConvert.DeserializeObject<tb_Pollutant_bf_gt>(DicRecordStr);
                    //switch (flag)
                    //{
                    //    case 1:
                    //        _setDicService.Insert<tb_Pollutant_bf_gt>(DicRecord);
                    //        break;
                    //    case 2:
                    //        _setDicService.Update<tb_Pollutant_bf_gt>(DicRecord);
                    //        break;
                    //    case 3:
                    //        _setDicService.Delete<tb_Pollutant_bf_gt>(DicRecord);
                    //        break;
                    //}
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

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
              var Pollut1 = _pollutantService.Query<tb_Pollutant>(u =>u.PollutantType=="固态"&&u.SourceName=="核素生产");
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
                var Pollut2 = _pollutantService.Query<tb_Pollutant>(u => u.PollutantType == "液态" && u.SourceName == "核素生产");
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
                var Pollut3 = _pollutantService.Query<tb_Pollutant>(u => u.PollutantType == "气态" && u.SourceName == "核素生产");
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
                var Pollut4 = _pollutantService.Query<tb_Pollutant>(u => u.PollutantType == "固态" && u.SourceName == "核素注射");
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
                var Pollut5 = _pollutantService.Query<tb_Pollutant>(u => u.PollutantType == "液态" && u.SourceName == "核素注射");
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
                var Pollut6 = _pollutantService.Query<tb_Pollutant>(u => u.PollutantType == "气态" && u.SourceName == "核素注射");

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
                var Pollut7 = _pollutantService.Query<tb_Pollutant>(u => u.PollutantType == "固态" && u.SourceName == "核素病房");

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
                var Pollut8 = _pollutantService.Query<tb_Pollutant>(u => u.PollutantType == "液态" && u.SourceName == "核素病房");

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
                var Pollut9 = _pollutantService.Query<tb_Pollutant>(u => u.PollutantType == "气态" && u.SourceName == "核素病房");
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
        public IActionResult AddRecord([FromForm] string PollutantRecordStr)
        {
            try
            {
                tb_Pollutant PollutantRecord = JsonConvert.DeserializeObject<tb_Pollutant>(PollutantRecordStr);
                _pollutantService.Insert<tb_Pollutant>(PollutantRecord);
                return Ok("true");
            }
            catch (Exception e) { return Ok(e.Message); };
        }
        [HttpPost]
        [Route("ReRecord")]
        public IActionResult ReRecord([FromForm] string PollutantRecordStr)
        {
            try
            {
                tb_Pollutant PollutantRecord = JsonConvert.DeserializeObject<tb_Pollutant>(PollutantRecordStr);
                _pollutantService.Update<tb_Pollutant>(PollutantRecord);
                return Ok("true");
            }
            catch (Exception e) { return Ok(e.Message); };


        }


        [HttpPost]
        [Route("DeRecord")]
        public IActionResult DeRecord([FromForm] string PollutantRecordStr)
        {
            try
            {
                List<tb_Pollutant> PollutantRecord = JsonConvert.DeserializeObject<List<tb_Pollutant>>(PollutantRecordStr);
                _pollutantService.Delete<tb_Pollutant>(PollutantRecord);
                return Ok("true");
            }
            catch (Exception e) { return Ok(e.Message); };
        }
       
    }


    
}

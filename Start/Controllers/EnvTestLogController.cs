using Common.Models;
using IService;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Start.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvTestLogController:ControllerBase
    {
        IEnvTestLogService _envTestLogService;

        public EnvTestLogController(IEnvTestLogService envTestLogService)
        {
            _envTestLogService = envTestLogService;
        }
        //得到datagrid的数据源
        [HttpGet]
        [Route("getAll")]
        public IActionResult getAll()
        {
            var envTestLogs = _envTestLogService.Query<tb_EnvTestLog>(u =>true);
            if (envTestLogs?.Count() > 0)
            {
                var envTestLogsInfo = envTestLogs.ToList();
                return Ok(envTestLogsInfo);
            }
            else
            {
                return NoContent();
            }
        }


        [HttpPost]
        [Route("AddRecord")]
        public IActionResult AddRecord([FromForm] string EnvTestLogRecordStr)
        {
            try
            {
                tb_EnvTestLog EnvTestLogRecord = JsonConvert.DeserializeObject<tb_EnvTestLog>(EnvTestLogRecordStr);
                _envTestLogService.Insert<tb_EnvTestLog>(EnvTestLogRecord);
                return Ok("true");
            }
            catch (Exception e) { return Ok(e.Message); };
        }
        [HttpPost]
        [Route("ReRecord")]
        public IActionResult ReRecord([FromForm] string EnvTestLogRecordStr)
        {
            try
            {
                tb_EnvTestLog EnvTestLogRecord = JsonConvert.DeserializeObject<tb_EnvTestLog>(EnvTestLogRecordStr);
                _envTestLogService.Update<tb_EnvTestLog>(EnvTestLogRecord);
                return Ok("true");
            }
            catch (Exception e) { return Ok(e.Message); };


        }


        [HttpPost]
        [Route("DeRecord")]
        public IActionResult DeRecord([FromForm] string EnvTestLogRecordStr)
        {
            try
            {
                List<tb_EnvTestLog> EnvTestLogRecord = JsonConvert.DeserializeObject<List<tb_EnvTestLog>>(EnvTestLogRecordStr);
                _envTestLogService.Delete<tb_EnvTestLog>(EnvTestLogRecord);
                return Ok("true");
            }
            catch (Exception e) { return Ok(e.Message); };
        }
    }
}

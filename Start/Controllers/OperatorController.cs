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
    public class OperatorController:ControllerBase
    {
        IOperatorService _OperatorService;
        public OperatorController(IOperatorService operatorService)
        {
            _OperatorService = operatorService;
        }


        //得到datagrid的数据源
        [HttpPost]
        [Route("getAll")]
        public IActionResult getAll()
        {           
                var operators = _OperatorService.Query<Tab_operator>(u => u.op_valid == 1);
                if (operators?.Count() > 0)
                {
                    var OperatorInfo = operators.ToList();
                    return Ok(OperatorInfo);
                }
                else
                {
                    return NoContent();
                }
        }

        [HttpPost]
        [Route("AddRecord")]
        public IActionResult AddRecord( [FromForm] string RecordStr)
        {
            Tab_operator Record = JsonConvert.DeserializeObject<Tab_operator>(RecordStr);
            try {
                _OperatorService.Insert<Tab_operator>(Record);
                return Ok("true");
            }
            catch(Exception e) { return Ok(e.Message); }
            
            
        }

        [HttpPost]
        [Route("ReRecord")]
        public IActionResult ReRecord([FromForm] string RecordStr)
        {
            Tab_operator Record = JsonConvert.DeserializeObject<Tab_operator>(RecordStr);
            try
            {
                _OperatorService.Update<Tab_operator>(Record);
                return Ok("true");
            }
            catch (Exception e) { return Ok(e.Message); }
        }

        [HttpPost]
        [Route("DeRecord")]
        public IActionResult DeRecord([FromForm] string RecordStr)
        {
            Tab_operator Record = JsonConvert.DeserializeObject<Tab_operator>(RecordStr);
            try
            {
                _OperatorService.Delete<Tab_operator>(Record);
                return Ok("true");
            }
            catch (Exception e) { return Ok(e.Message); }
        }

    }
}

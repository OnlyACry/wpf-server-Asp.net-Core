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
    public class PermissionController : ControllerBase
    {
        IPermissionService _permissionService;
        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        //得到所以权限的数据
        [HttpGet]
        [Route("getAll")]
        public IActionResult getAll()
        {
            
                var Permission = _permissionService.Query<tb_Permission>(u =>true);
                if (Permission?.Count() > 0)
                {
                    var PermissionInfo = Permission.ToList();
                    return Ok(PermissionInfo);
                }
                else
                {
                    return NoContent();
                }           
        }

        [HttpPost]
        [Route("RePermission")]
        public IActionResult RePermission([FromForm] string PermissionStr)
        {
           List<tb_Permission> RecordStr = JsonConvert.DeserializeObject<List<tb_Permission>>(PermissionStr);
            try
            {
                _permissionService.Update<tb_Permission>(RecordStr);
                return Ok("true");
            }
            catch (Exception e) { return Ok(e.Message); }
        }

        [HttpPost]
        [Route("getUserPermission")]
        public IActionResult getUserPermission([FromForm] string UserPermission)
        {

            var Permission = _permissionService.Query<tb_Permission>(u =>u.RoleName==UserPermission);
            if (Permission?.Count() > 0)
            {
                var PermissionInfo = Permission.ToList();
                return Ok(PermissionInfo[0].PermissionValue);
            }
            else
            {
                return NoContent();
            }
        }
    }
}

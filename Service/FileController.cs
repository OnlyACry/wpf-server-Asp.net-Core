using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Start.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
     public class FileController : ControllerBase
    {
        private readonly IWebHostEnvironment env;
        public FileController(IWebHostEnvironment env)
        {
            this.env = env;
        }

        [HttpPost]
        [Route("SaveFile")]//不加的话访问不到该方法  访问地址api/user/login
        public async Task<IActionResult> SaveFile([FromForm] IFormFile file, [FromForm] string filename)
        {
            try
            {
                await this.Save(file, filename);
                return Ok("true");
            }
            catch (Exception e0)
            {
                return null;
            }
        }

        public async Task Save(IFormFile file, string folderName)
        {
            //var filename = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filename = $"{folderName}";
            string route = Path.Combine(env.WebRootPath, "员工资质上传资料");

            if (!Directory.Exists(route))
            {
                System.IO.Directory.CreateDirectory(route);
            }

            string fileRoute = Path.Combine(route, filename);
            using (FileStream fileStream = System.IO.File.Create(fileRoute))
            {
                await file.OpenReadStream().CopyToAsync(fileStream);
            }
        }
        [HttpPost]
        [Route("SaveFileChangjia")]//不加的话访问不到该方法  访问地址api/user/login
        public async Task<IActionResult> SaveFileChangjia([FromForm] IFormFile file, [FromForm] string filename)
        {
            try
            {
                await this.SaveToo(file, filename);
                return Ok("true");
            }
            catch (Exception e0)
            {
                return null;
            }
        }
        public async Task SaveToo(IFormFile file, string folderName)
        {
            //var filename = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filename = $"{folderName}";
            string route = Path.Combine(env.WebRootPath, "厂家上传资料");

            if (!Directory.Exists(route))
            {
                System.IO.Directory.CreateDirectory(route);
            }

            string fileRoute = Path.Combine(route, filename);
            using (FileStream fileStream = System.IO.File.Create(fileRoute))
            {
                await file.OpenReadStream().CopyToAsync(fileStream);
            }
        }
    }
}

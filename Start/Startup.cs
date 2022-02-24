using IService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Start
{
    public class Startup
    {
        public Startup(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //注册Swagger
            services.AddSwaggerGen(s=> {

                s.SwaggerDoc("V1", new OpenApiInfo()
                {
                    Version = "V1",
                    Title="hsxt",
                    Description="核素系统"
                }) ;
            
            });

            services.AddControllers();

            //使用接口都需要在这注册一下，一般把接口当做构造函数的参数，当需要获取接口类型的参数时，会自动实例化后面那个实现类型的参数传进去
            services.AddTransient<IConfiguration.IConfiguration, Configuration.Configuration>();//IConfiguration是我新建的类库，要使用其中的类就需要.出来
            services.AddTransient<IEFContext.IEFContext, EFContext.EFContext>();
            services.AddTransient<ILoginService, LoginService>();//如果不加类库名，就需要在开头USing类库名

            services.AddTransient<IPollutantService, PollutantService>();
            services.AddTransient<ISetDicService, SetDicService>();
            services.AddTransient<IOperatorService, OperatorService>();
            services.AddTransient<IfdecaypoolService, fdecaypoolService>();







        }

        // This method gets called by the runtime. Use this method   to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //使用Swagger中间件
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("V1/swagger.json", "hsxt");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

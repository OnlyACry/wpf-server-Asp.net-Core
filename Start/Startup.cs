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
            //ע��Swagger
            services.AddSwaggerGen(s=> {

                s.SwaggerDoc("V1", new OpenApiInfo()
                {
                    Version = "V1",
                    Title="hsxt",
                    Description="����ϵͳ"
                }) ;
            
            });

            services.AddControllers();

            //ʹ�ýӿڶ���Ҫ����ע��һ�£�һ��ѽӿڵ������캯���Ĳ���������Ҫ��ȡ�ӿ����͵Ĳ���ʱ�����Զ�ʵ���������Ǹ�ʵ�����͵Ĳ�������ȥ
            services.AddTransient<IConfiguration.IConfiguration, Configuration.Configuration>();//IConfiguration�����½�����⣬Ҫʹ�����е������Ҫ.����
            services.AddTransient<IEFContext.IEFContext, EFContext.EFContext>();
            services.AddTransient<ILoginService, LoginService>();//������������������Ҫ�ڿ�ͷUSing�����

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
            //ʹ��Swagger�м��
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

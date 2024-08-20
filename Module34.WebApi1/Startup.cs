using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Module34.WebApi1.Contracts.Validators;
using Module34.WebApi1.Data;
using Module34.WebApi1.Data.Repos;
using Module34.WebApi1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Module34.WebApi1
{
    public class Startup
    {
        /// <summary>
        /// �������� ������������ �� ����� Json
        /// </summary>
        private IConfiguration Configuration
        { get; } = new ConfigurationBuilder()
          .AddJsonFile("appsettings.json")
          .AddJsonFile("appsettings.Development.json")
          .AddJsonFile("HomeOptions.json")
          .AddJsonFile(Path.Combine(Environment.CurrentDirectory, "appsettings.Development.json"))
          .Build();

        /*
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
        }
        */

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddDeviceRequestValidator>());

            // ����������� ������� ����������� ��� �������������� � ����� ������
            services.AddSingleton<IDeviceRepository, DeviceRepository>();
            services.AddSingleton<IRoomRepository, RoomRepository>();

            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<WebApi1Context>(options => options.UseSqlServer(connection), ServiceLifetime.Singleton);

            // ��������� ����� ������
            services.Configure<HomeOptions>(Configuration);

            // ��� �� ����� �������������, �� � MVC �� ����� ������ AddControllersWithViews()
            services.AddControllers();

            // ������������ �������������� ��������� ������������ WebApi � �������������� Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Module34.WebApi1", Version = "v1" });
            });

            // ���������� �����������
            var assembly = Assembly.GetAssembly(typeof(MappingProfile));
            services.AddAutoMapper(assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ����������� ����������� ��� ������� ��� ���������� ��������
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Module34.WebApi1 v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            // ������������ �������� � �������������
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

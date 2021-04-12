using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PhoneNumberValidator.Application.Services.Contracts;
using PhoneNumberValidator.Application.Services.Interfaces;
using PhoneNumberValidator.DAL;
using PhoneNumberValidator.DAL.Repository.Contracts;
using PhoneNumberValidator.DAL.Repository.Interfaces;
using PhoneNumberValidator.Web.Utilities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace PhoneNumberValidator.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Adding repositories to ioc container
            services.AddDbContext<DAL.ValidatorDBContext>(opt => opt.UseInMemoryDatabase("DemoDB"));
            services.AddScoped<INationalDoNotCallRepository, NationalDoNotCallRepository>();         
            services.AddScoped<IInternalDoNotCallRepository, InternalDoNotCallRepository>();
            services.AddScoped<IWhiteListRepository, WhiteListRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            #endregion

            #region Adding services to ioc container 
            services.AddScoped<IValidatePhoneNumberService, ValidatePhoneNumberService>();
            #endregion

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PhoneNumberValidator.Web", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                object p = app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PhoneNumberValidator.Web v1"));
            }

            //Populate in memory db
            var t = new PopulateDemoDB(services.GetService<INationalDoNotCallRepository>(),
                               services.GetService<IInternalDoNotCallRepository>(),
                               services.GetService<IWhiteListRepository>(),
                               services.GetService<IPersonRepository>());
            t.start();

            //var t4 =  services.GetService<INationalDoNotCallRepository>().GetAllAsync().;

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

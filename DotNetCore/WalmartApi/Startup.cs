using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DNC.Core.Configuration;
using DNC.Core.Data;
using DNC.Core.Domain.Walmart;
using DNC.Core.Infrastructure.Mapper;
using DNC.Data;
using DNC.Data.Infrastrucure.Mapper;
using DNC.Data.Walmart;
using DNC.Service.Products;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace WalmartApi
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
            services.Configure<WalmartApiConfig>(Configuration.GetSection("WalmartApi"));


            //repositories
            services.AddTransient(typeof(IRepository<>), typeof(EfRepository <>));


            //create AutoMapper configuration
            var config = new MapperConfiguration(cfg => {

                cfg.AddProfile(typeof(StoreMapperConfiguration));
            });

            //register
            AutoMapperConfiguration.Init(config);



            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<IWalmartServiceContext, WalmartService>();
            services.AddTransient<IRepositoryRest, WalmartRepository>();
            services.AddTransient<IProductService, ProductService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

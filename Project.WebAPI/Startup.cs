
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.DAL;
using Project.Model;
using Project.Model.Common;
using Project.Repository;
using Project.Repository.Common;
using Project.Service;
using Project.Service.Common;
using Autofac;
using AutoMapper;
using Autofac.Extensions.DependencyInjection;

namespace Project.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
        }
        
        public IContainer Container { get; private set; }

        public IConfiguration Configuration { get; private set; }
        

        // This method gets called by the runtime. Use this method to add services to the container.
        
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkNpgsql().AddDbContext<CarsContext>().BuildServiceProvider();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAutoMapper(typeof(RepositoryMapping),typeof(WebApiMapping));
 
            services.AddAutofac();
            
            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterAssemblyModules(typeof(RepositoryModule).Assembly,typeof(ServiceModule).Assembly);
            this.Container = builder.Build();

            return new AutofacServiceProvider(this.Container);

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




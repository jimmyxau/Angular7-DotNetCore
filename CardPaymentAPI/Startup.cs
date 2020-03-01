using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Infrastructure;
using Core.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;

namespace CardPaymentAPI
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
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options => { // to set Json property same as class property
                    var resolver = options.SerializerSettings.ContractResolver;
                    if(resolver != null)
                    {
                        (resolver as DefaultContractResolver).NamingStrategy = null;
                    }
                });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Configure Cors
            services.AddCors();

            // Dependency Injection
            services.AddTransient<IPaymentDetailService, PaymentDetailService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Use Cors
            app.UseCors(options =>
                options.WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseMvc();
        }
    }
}

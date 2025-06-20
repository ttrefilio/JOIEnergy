﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using JOIEnergy.Application.Services;
using JOIEnergy.Infrastructure.Providers;

namespace JOIEnergy
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
            var readings = InMemoryElectricityReadingProvider.GenerateMeterElectricityReadings();
            var pricePlans = InMemoryPricePlanProvider.GetPricePlans();
            var smartMeterToPricePlanAccounts = InMemorySmartMeterToPricePlanAccountsProvider.GetSmartMeterToPricePlanAccounts();

            services.AddControllers();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IMeterReadingService, MeterReadingService>();
            services.AddTransient<IPricePlanService, PricePlanService>();
            services.AddSingleton((IServiceProvider arg) => readings);
            services.AddSingleton((IServiceProvider arg) => pricePlans);
            services.AddSingleton((IServiceProvider arg) => smartMeterToPricePlanAccounts);

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}

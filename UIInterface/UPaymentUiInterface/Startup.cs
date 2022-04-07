using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ANUPayments.Models;
using ANUPayments.Payments;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace UPaymentUiInterface
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "UPaymentUiInterface", Version = "v1"});
            });

            var configuration = new ApiConfiguration()
            {
                Company = "Test",
                Mode = Mode.Staging,
                Password = "test",
                UserName = "test",
                ApiSecretKeyStaging = "jtest123",
                MerchantId = "1201",
                XHeaderAuthorization = "hWFfEkzkYE1X691J4qmcuZHAoet7Ds7ADhL",
                ApiSecretKeyLive = "jtest123"
            };
            services.AddTransient<IPaymentRequest, PaymentRequest>((func) => new PaymentRequest(configuration));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UPaymentUiInterface v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
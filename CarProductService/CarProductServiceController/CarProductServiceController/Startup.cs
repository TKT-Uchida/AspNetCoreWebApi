using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using CarProductServiceModel.Data;
// Add
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.Formatters;
using CarProductServiceModel.Models;
using Microsoft.AspNet.OData.Formatter;

namespace CarProductServiceController
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
            // Microsoft.AspNetCore.OData(Version="7.4.0-beta)をAddすると引数なしで指定可能。
            // UseMvcを使うから引数なしだとexceptionが発生してしまう
            // services.AddControllers();
            // services.AddControllers(mvcOptions => 
            //     mvcOptions.EnableEndpointRouting = false);

            // ↓ JSONシリアル化で循環参照を無視する設定
            services.AddControllers().AddNewtonsoftJson(settings =>
                settings.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddDbContext<CarProductServiceContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("CarProductServiceContext"),
                        (x => x.MigrationsAssembly("CarProductServiceMigration"))));
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "1.0.0",
                    Title = "CarProductService",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Shayne Boyer",
                        Email = string.Empty,
                        Url = new Uri("https://twitter.com/spboyer"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });
                c.SwaggerDoc("v2", new OpenApiInfo{ Version = "2.0.0", Title = "CarProductServiceEx" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            // services.AddOData();

            // services.AddMvcCore(options =>
            // {
            //     IEnumerable<ODataOutputFormatter> outputFormatters =
            //         options.OutputFormatters.OfType<ODataOutputFormatter>()
            //             .Where(foramtter => foramtter.SupportedMediaTypes.Count == 0);

            //     foreach (var outputFormatter in outputFormatters)
            //     {
            //         outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/odata"));
            //     }
            // });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "My API V2");
            });

            app.UseRouting();

            app.UseAuthorization();

            // app.UseMvc(routeBuilder =>
            // {
            //     routeBuilder.EnableDependencyInjection();
            //     routeBuilder.Expand().Select().Filter().Count().OrderBy().MaxTop(null).SkipToken();
            //     routeBuilder.MapODataServiceRoute("odateRoute","odata",GetEdmModel());
            // });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                // Microsoft.AspNetCore.OData(Version="7.4.0-beta)をAddするとここで指定可能。
                // endpoints.EnableDependencyInjection();
                // endpoints.Select().Filter().Expand().MaxTop(10);
                // endpoints.MapODataRoute("odata", "odata", GetEdmModel());
            });
        }

        private IEdmModel GetEdmModel()
        {
            var odataBuilder = new ODataConventionModelBuilder();

            odataBuilder.EntitySet<CarMaker>(nameof(CarMaker));
            odataBuilder.EntityType<CarMaker>().HasKey(c => c.MakerId);
            // odataBuilder.EntityType<PackedSales>().HasMany(f => f.Sales);
            
            // odataBuilder.EntitySet<Sales>(nameof(Sales));
            // odataBuilder.EntityType<Sales>().HasKey(c => new { c.SalesNo, c.PSalesNo });

            // odataBuilder.EntityType<Sales>().Ignore(s => s.Price); // Passwordなんか除外することができる
 
            return odataBuilder.GetEdmModel();
        }
    }
}

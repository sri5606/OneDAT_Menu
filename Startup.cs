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
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using OneDAT.Menu.Database.DynamoDB;
using OneDAT.Menu.Database.MongoDB;
using OneDAT.Menu.Interfaces.IServices;
using OneDAT.Helper.Enumerations;
using OneDAT.Menu.Interfaces.IViewModel;
using OneDAT.Menu.Common.ViewModel;
using OneDAT.Menu.Services;
using OneDAT.Menu.Database.DynamoDB.Repository;
using OneDAT.Menu.Interfaces.IRepository;
using DBContext = OneDAT.Menu.Database.DynamoDB.DBContext;
using ModelMapper = OneDAT.Menu.Database.DynamoDB.ModelMapper;
using Amazon.DynamoDBv2;
using OneDAT.Helper.Models;
using System.IO;
using System.Reflection;
using Microsoft.OpenApi.Models;
using OneDAT.Web.Helper.InterfaceBinder;
using OneDAT.Web.Helper.Filter;

namespace OneDAT.Menu
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IServiceProvider serviceProvider)
        {
            Configuration = configuration;
            ServiceProvider = serviceProvider;
        }


        public IConfiguration Configuration { get; }
        public IServiceProvider ServiceProvider { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                //options.AddPolicy("AllowAll",
                //    builder =>
                //    {
                //        builder
                //        .AllowAnyOrigin()
                //        .AllowAnyMethod()
                //        .AllowAnyHeader()
                //        .AllowCredentials();
                //    });
                services.AddCors(options =>
                {
                    options.AddPolicy("AllowAll",
                        builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
                });
            });

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(OneDATActionFilter));
                options.EnableEndpointRouting = false;
            })
                .SetCompatibilityVersion(CompatibilityVersion.Latest)
                .AddNewtonsoftJson(opt =>
                {
                    //opt.UseCamelCasing(true);
                    opt.SerializerSettings.ContractResolver = new DIContractResolver(new DIMetaDefault(services), ServiceProvider);
                }); ;
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "OneDAT Menu API",
                    Description = "OneDAT Menu API",
                    TermsOfService = new Uri("https://www.honeywell.com"),
                    Contact = new OpenApiContact() { Name = "OneDAT Menu", Email = "help@honeywell.com", Url = new Uri("https://www.honeywell.com") }
                });
                // Don't Remove below , it may use in future for token Authentication
                //c.AddSecurityDefinition("Bearer",
                //   new ApiKeyScheme
                //   {
                //       In = "header",
                //       Description = "Please enter into field the word 'Bearer' following by space and JWT",
                //       Name = "Authorization",
                //       Type = "apiKey"
                //   });
                //            c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
                //    { "Bearer", Enumerable.Empty<string>() },
                //});

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
                //c.DescribeAllEnumsAsStrings();
            });
            string databaseTypeString = Configuration.GetSection("AppInformation:DatabaseType").Value;
            DatabaseType databaseType = (DatabaseType)Enum.Parse(typeof(DatabaseType), databaseTypeString);
           
            services.AddOptions();
            services.Configure<AppInformation>(Configuration.GetSection("AppInformation"));
            //Added for supporting interface as a request parameter
            //services.TryAddSingleton<IDIMeta>(s =>
            //{
            //    return new DIMetaDefault(services);
            //});
            //services.AddTransient<IConfigureOptions<MvcJsonOptions>, JsonOptionsSetup>();
            //End
            Environment.SetEnvironmentVariable("AWS_ACCESS_KEY_ID", Configuration["AWS:AccessKey"]);
            Environment.SetEnvironmentVariable("AWS_SECRET_ACCESS_KEY", Configuration["AWS:SecretKey"]);
            Environment.SetEnvironmentVariable("AWS_REGION", Configuration["AWS:Region"]);
            services.AddControllers();

           
            services.AddTransient<ITechnologyService, TechnologyService>();
            services.AddTransient<ITechnologyViewModel, TechnologyViewModel>();


            services.AddDefaultAWSOptions(Configuration.GetAWSOptions());
            services.AddAWSService<IAmazonDynamoDB>();

            services.AddSingleton<DBContext>();
            services.AddSingleton<ModelMapper>();

            //Repository
            services.AddTransient<ITechnologyRepository, TechnologyDynamoDBRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            app.UseRouting();
            app.UseAuthorization();
            app.UseCors("AllowAll");
            app.UseMvc();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "OneDAT Catalyst API V1");
                c.RoutePrefix = string.Empty;
            });
        }

        

    }
}

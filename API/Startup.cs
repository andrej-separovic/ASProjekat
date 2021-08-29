using API.Core;
using Application;
using Application.Commands.Brand;
using Application.Commands.Order;
using Application.Commands.Product;
using Application.Commands.User;
using Application.Email;
using Application.Queries.Brand;
using Application.Queries.Log;
using Application.Queries.Order;
using Application.Queries.Products;
using EFDataAccess;
using Implementation.Commands;
using Implementation.Email;
using Implementation.Extensions;
using Implementation.Logging;
using Implementation.Queries;
using Implementation.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
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
            services.AddTransient<Context>();

            services.AddAutoMapper(typeof(QueryableExtensions).Assembly);

            services.AddTransient<UseCaseExecutor>();

            services.AddTransient<IApplicationActor, FakeAPIActor>();

            services.AddTransient<IUseCaseLogger, DatabaseUseCaseLogger>();

            services.AddHttpContextAccessor();

            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();

                var user = accessor.HttpContext.User;

                if (user.FindFirst("ActorData") == null)
                {
                    return new UnauthorizedActor();
                }

                var actorString = user.FindFirst("ActorData").Value;

                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

                return actor;
            });

            services.AddTransient<JwtManager>();

            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "asp_api",
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AndrejSuperSecretKey")),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Movie Festival Guide", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                       Enter 'Bearer' [space] and then your token in the text input below.
                       \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                 {
                     {
                         new OpenApiSecurityScheme
                           {
                             Reference = new OpenApiReference
                               {
                                 Type = ReferenceType.SecurityScheme,
                                 Id = "Bearer"
                               },
                               Scheme = "oauth2",
                               Name = "Bearer",
                               In = ParameterLocation.Header,
                             },
                             new List<string>()
                           }
                     });
            });

            services.AddTransient<IGetBrandsQuery, GetBrandsQuery>();
            services.AddTransient<IGetBrandQuery, GetBrandQuery>();
            services.AddTransient<ICreateBrandCommand, CreateBrandCommand>();
            services.AddTransient<IEditBrandCommand, EditBrandCommand>();
            services.AddTransient<IDeleteBrandCommand, DeleteBrandCommand>();
            services.AddTransient<CreateBrandValidator>();
            services.AddTransient<EditBrandValidator>();

            services.AddTransient<IGetProductsQuery, GetProductsQuery>();
            services.AddTransient<IGetProductQuery, GetProductQuery>();
            services.AddTransient<ICreateProductCommand, CreateProductCommand>();
            services.AddTransient<IEditProductCommand, EditProductCommand>();
            services.AddTransient<IDeleteProductCommand, DeleteProductCommand>();
            services.AddTransient<CreateProductValidator>();
            services.AddTransient<EditProductValidator>();

            services.AddTransient<IGetUseCaseLogsQuery, GetUseCaseLogsQuery>();
            services.AddTransient<IGetUseCaseLogQuery, GetUseCaseLogQuery>();

            services.AddTransient<IRegisterUserCommand, RegisterUserCommand>();
            services.AddTransient<RegisterUserValidator>();
            services.AddTransient<IEmailSender, SmtpEmailSender>(x => new SmtpEmailSender());

            services.AddTransient<IGetOrdersQuery, GetOrdersQuery>();
            services.AddTransient<IGetOrderQuery, GetOrderQuery>();
            services.AddTransient<IGetSelfOrdersQuery, GetSelfOrdersQuery>();
            services.AddTransient<ICreateOrderCommand, CreateOrderCommand>();
            services.AddTransient<IEditOrderCommand, EditOrderCommand>();
            services.AddTransient<CreateOrderValidator>();
            services.AddTransient<EditOrderValidator>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger");
            });

            app.UseRouting();

            app.UseMiddleware<GlobalExceptionHandler>();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

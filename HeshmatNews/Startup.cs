using System;
using System.Text;
using AutoMapper;
using dadachMovie.Services;
using dadachMovie.Services.Contracts;
using HeshmastNews.Data;
using HeshmastNews.Entities;
using HeshmastNews.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using VueCliMiddleware;

namespace HeshmastNews
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            //IOC
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IFileStorageService, InAppStorageService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<INewsService, NewsService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<ITagService, TagService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IAdminPageService, AdminPageService>();

            //Spa Static files config
            services.AddSpaStaticFiles(configuration: options => { options.RootPath = "wwwroot"; });
            services.AddHttpContextAccessor();
            services.AddControllers();
            services.AddIdentity<User, Role>(options => { options.User.RequireUniqueEmail = true; }
            ).AddEntityFrameworkStores<ApplicationDbContext>();
            //Http Accessor for Identity
            services.AddHttpContextAccessor();

            // JWT Setting
            var appSettingsSection = Configuration.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.Configure<AppSettings>(appSettingsSection);
            services.AddAuthentication(a =>
                {
                    a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                })
                ;
            //Cors
            services.AddCors(options =>
            {
                options.AddPolicy("VueCorsPolicy", builder =>
                {
                    builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .WithOrigins("https://localhost:5001");
                });
            });

            //Database
            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseMySql(Configuration.GetConnectionString("MariaDbConnection"),
                    new MariaDbServerVersion(new System.Version(10, 5, 10)));
            });
            //Cors
            services.AddCors(c =>
            {
                c.AddPolicy(name: MyAllowSpecificOrigins, opt =>
                    opt.WithOrigins("http://localhost:5000",
                            "http://localhost:8080")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials());
            });

            services.AddAutoMapper(typeof(HeshmatMapper.HeshmatMapper));

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Scheme = "bearer",
                    Description = "Please insert JWT token into field"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            // app.UseHttpsRedirection ();
            if ((!env.IsEnvironment("Backend")))
            {
                app.UseSpaStaticFiles();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });

            app.UseResponseCaching();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                if ((!env.IsEnvironment("Backend")))
                {
                    endpoints.MapToVueCliProxy(
                        "{*path}",
                        new SpaOptions { SourcePath = "ClientApp" },
                        npmScript: (env.IsEnvironment("Backend") ? null : "serve"),
                        regex: "Compiled successfully",
                        forceKill: true
                    );
                }
            });

            //     ServiceExtensions.CreateDefaultRolesAndUser(serviceProvider).Wait();
        }
    }
}
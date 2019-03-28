using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SeanDotNetDocker.DataAccess;
using SeanDotNetDocker.Models.Note;
using SeanDotNetDocker.Models.User;

namespace SeanDotNetDocker
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment he)
        {
            Configuration = configuration;
            environment = he;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment environment { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionstring = Configuration.GetConnectionString("ConnectionString_MySql_Localhost");
            if (environment.IsStaging() || environment.IsProduction())
                connectionstring = Configuration.GetConnectionString("ConnectionString_MySql_Docker");


            services.AddDbContext<IdentityContext>(options => options.UseMySql(connectionstring));
            services.AddIdentity<ApplicationUser, IdentityRole>(
                options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 3;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                }).AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();

            if (environment.IsStaging() || environment.IsProduction())
                services.AddDbContext<DBContext>(options => options.UseMySql(connectionstring));
            else services.AddDbContext<DBContext>(options => options.UseMySql(connectionstring));

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDirectoryBrowser();

            services.AddMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            #region ASP.NET Core 2.0 쿠키 인증: ConfigureServices()
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme =
                    CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(options =>
            {
                options.LoginPath = new PathString("/User/Login");
                options.AccessDeniedPath = new PathString("/User/Forbidden");
                options.SlidingExpiration = true;
            })
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    // 보안키 문자열 길게 설정할 것
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(
                            Configuration["SymmetricSecurityKey"])),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(5)
                };
            });
            #endregion

            #region //[User] Policy 설정
            services.AddAuthorization(options =>
            {
                // Claim based authorization
                options.AddPolicy("User", policy => policy.RequireClaim("User"));
                options.AddPolicy("Admin", policy => policy.RequireClaim("Admin"));  // 사이트 관리자
            });
            #endregion

            #region //[CORS] CORS 설정
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin",
                    builder => builder
                    //.WithOrigins("http://mathweb-test.ap-northeast-2.elasticbeanstalk.com")
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    );
            });
            #endregion

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            DependencyInjectionContainer(services);
        }

        private void DependencyInjectionContainer(IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<INoteCommentRepository, NoteCommentRepository>();
            services.AddTransient<INoteRepository, NoteRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseAuthentication();

            app.UseSession();

            app.UseStatusCodePages();

            app.UseCors("AllowAnyOrigin");

            app.UseStaticFiles();

            
            // 로그아웃 처리
            app.UseRouter(routes =>
            {
                // ~/Logout 경로 요청하면 자동으로 로그아웃
                routes.MapGet("Logout", async context =>
                {
                    await context.SignOutAsync("Cookies");
                    context.Response.Redirect("/");
                });
                routes.MapPost("Logout", async context =>
                {
                    await context.SignOutAsync("Cookies");
                    context.Response.Redirect("/");
                });
            });

            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.Run(async (context) =>
            {
                // 한글 출력
                context.Response.Headers["Content-Type"] = "text/html; charset=utf-8";
                await context.Response.WriteAsync("Knumbers 입니다. 사이트에 오류가 있으니 다시 시도해 보세요.", System.Text.Encoding.UTF8);
            });
        }
    }
}

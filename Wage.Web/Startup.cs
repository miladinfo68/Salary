using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Wage.Core.EmailService;
using Wage.Core.Interfaces;
using Wage.Core.Interfaces.IServices;
using Wage.Data;
using Wage.Services;
using Wage.Web.Functionality;

namespace Wage.Web
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
            services.Configure<EmailConfiguration>(Configuration.GetSection("EmailConfiguration"));
            var emailConfig = Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailSender, EmailSender>();

            services.AddControllersWithViews();
            services.AddMvc().AddSessionStateTempDataProvider().AddRazorRuntimeCompilation();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAutoMapper(typeof(Startup));
            services.AddSession();
            //services.AddMvc().AddRazorRuntimeCompilation();

            var dataAssemblyName = typeof(WageDbContext).Assembly.GetName().Name;
            services.AddDbContext<WageDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")
                    , x => x.MigrationsAssembly(dataAssemblyName)));

            //@@@@@@@@@@@@@@@@@@@@ jwt setting

            //Provide a secret key to Encrypt and Decrypt the Token
            var SecretKey = Encoding.ASCII.GetBytes(Configuration.GetSection("Jwt:Secret").Value);
            //Configure JWT Token Authentication
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(token =>
            {
                token.RequireHttpsMetadata = false;
                token.SaveToken = true;
                token.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    //Same Secret key will be used while creating the token
                    IssuerSigningKey = new SymmetricSecurityKey(SecretKey),
                    ValidateIssuer = true,
                    //Usually, this is your application base URL
                    ValidIssuer = Configuration.GetSection("Jwt:Issuer").Value,
                    ValidateAudience = true,
                    ValidAudience = Configuration.GetSection("Jwt:Audience").Value,
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
            //@@@@@@@@@@@@@@@@@@@@ 

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IGroupManagerService, GroupManagerService>();
            services.AddTransient<IGroupManagerScheduleService, GroupManagerScheduleService>();
            services.AddTransient<IGroupManagerDetailesService, GroupManagerDetailesService>();
            services.AddTransient<IHolidayService, HolidayService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IAccessLinkService, AccessLinkService>();
            services.AddTransient<IUserRoleService, UserRoleService>();
            services.AddTransient<IRoleAccessService, RoleAccessService>();



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
                app.UseExceptionHandler("/Home/Error");
            }
            //404
            app.UseStatusCodePagesWithReExecute("/Home/NotFound");

            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseRouting();

            app.UseSession();
            //Add JWToken to all incoming HTTP Request Header
            app.Use(async (context, next) =>
            {
                var JWToken = context.Session.GetString("JWToken");
                if (!string.IsNullOrEmpty(JWToken))
                {
                    context.Request.Headers.Add("Authorization", "Bearer " + JWToken);
                }
                await next();
            });
            //Add JWToken Authentication service         
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}

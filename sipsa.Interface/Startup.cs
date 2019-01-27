using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using sipsa.Dados;
using sipsa.Dominio.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace sipsa.Interface
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
            // Injeção das classes do sistema.
            services.AddScoped<UsuarioAutenticacao>();

            // Serviço de autenticação e armazenamento em cookie.
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Logon/Login";
                    options.AccessDeniedPath = "/Logon/AccessDenied";
                });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Administrador", policy =>
                    policy.RequireClaim(ClaimTypes.Role, "Administrador"));
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Serviço de comunicação com o banco de dados.
            services.AddDbContext<SipsaContexto>(options => 
                options.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionString")));

            // Mvc
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using sipsa._Base.Autenticacao;
using sipsa.DynamoDB;

namespace sipsa
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
            services.AddScoped<AutenticacaoUsuario>();

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

            // Busca recursos para exibição de mensagens.
            services.AddLocalization(o => o.ResourcesPath = "_Base/Resources");

            // Serviço de comunicação com o banco de dados.
            services.AddDynamoDB(Configuration);

            // Mvc
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddDataAnnotationsLocalization(o =>
                {
                    o.DataAnnotationLocalizerProvider = (type, factory) =>
                    {
                        return factory.Create(typeof(Validation));
                    };
                });
        }

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

            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

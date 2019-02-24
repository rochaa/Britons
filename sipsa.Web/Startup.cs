using System;
using System.Security.Claims;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Runtime;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using sipsa.Dados;
using sipsa.Dados.Repositorios;
using sipsa.Dominio.Membros;
using sipsa.Dominio.Usuarios;
using sipsa.Web._Base;
using sipsa.Web.Models;

namespace sipsa.Web {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            // Serviço de autenticação e armazenamento em cookie.
            services.AddAuthentication (CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie (options => {
                    options.LoginPath = "/Logon/Login";
                    options.AccessDeniedPath = "/Logon/AccessDenied";
                });
            services.AddAuthorization (options => {
                options.AddPolicy ("ADMINISTRADOR", policy =>
                    policy.RequireClaim (ClaimTypes.Role, "ADMINISTRADOR"));
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor> ();

            // Serviço de comunicação com o banco de dados.
            var credenciais = new BasicAWSCredentials (
                Environment.GetEnvironmentVariable ("AWSDynamoDB_AccessKey"),
                Environment.GetEnvironmentVariable ("AWSDynamoDB_SecretKey"));
            var client = new AmazonDynamoDBClient (credenciais, RegionEndpoint.SAEast1);
            services.AddSingleton (new SipsaContexto (client));

            // Mvc
            services.AddMvc (options => {
                    options.Filters.Add (new SipsaExceptionFilterAttribute ());
                })
                .SetCompatibilityVersion (CompatibilityVersion.Version_3_0);

            // Injeção das classes do sistema.
            services.AddScoped (typeof (IUsuarioRepositorio), typeof (UsuarioRepositorio));
            services.AddScoped (typeof (IMembroRepositorio), typeof (MembroRepositorio));
            services.AddScoped<UsuarioAutenticacao> ();
            services.AddScoped<UsuarioCadastro> ();
            services.AddScoped<MembroCadastro> ();

            // Mapeamento das classes de domínio com os modelos.
            Mapper.Initialize (cfg => {
                cfg.CreateMap<Usuario, UsuarioModel> ();
                cfg.CreateMap<UsuarioModel, Usuario> ();
                cfg.CreateMap<MembroModel, MembroDto> ();
                cfg.CreateMap<Membro, MembroModel> ()
                    .ForMember (m => m.Logradouro, a => a.MapFrom (s => s.Endereco.Logradouro))
                    .ForMember (m => m.Bairro, a => a.MapFrom (s => s.Endereco.Bairro))
                    .ForMember (m => m.Cep, a => a.MapFrom (s => s.Endereco.Cep))
                    .ForMember (m => m.DataAdmissao, a => a.MapFrom (s => s.Admissao.Data))
                    .ForMember (m => m.Ata, a => a.MapFrom (s => s.Admissao.Ata))
                    .ForMember (m => m.Recepcao, a => a.MapFrom (s => s.Admissao.Recepcao));
                cfg.CreateMap<MembroModel, Membro> ();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseExceptionHandler ("/Home/Error");
            }

            app.UseHttpsRedirection ();
            app.UseStaticFiles ();
            app.UseAuthentication ();

            app.UseMvc (routes => {
                routes.MapRoute (
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
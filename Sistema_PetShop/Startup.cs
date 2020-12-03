using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sistema_PetShop.Context;
using Sistema_PetShop.Models;
using Sistema_PetShop.Repositories.Implementation;
using Sistema_PetShop.Repositories.Interfaces;

namespace Sistema_PetShop
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //**********************************************************************************************************************************************************
            //**********************************************************************************************************************************************************

            //registrando o contexto como um serviço para a aplicação - quando a aplicação é executada, um serviço e criado para o contexto (sessão com o banco de dados)
            services.AddDbContext<AplicacaoDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnectionSuperPetShop")));

            //**********************************************************************************************************************************************************
            //**********************************************************************************************************************************************************
            //Registrando um serviço para os tipos do Identity
            //o metodo AddEntityFrameworkStores adiciona a implementação da classe de sessão com o banco (Context), armazenando os tipos do Identity
            // o método  AddDefaultTokenProviders inclui para o identity recursos de fornecimento de tokens par auxiliar na troca de senha, email...
            //services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AplicacaoDbContext>().AddDefaultTokenProviders();

            //Registrando um serviço para as interfaces, fornecendo ao controlador uma instancia da classe de implementação da interface

            //Transiente - o serviço é criado fornecendo um objeto, a cada solicitação.
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();


            //Singleton - o serviço é criado uma unica vez para todas as requisições (O mesmo objeto para todas as requisições)
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Scoped - O serviço cria o objeto para cada requisição (objeto por requisição, individual)
            services.AddScoped(carrinhoCompra => CarrinhoCompra.ObterCarrinho(carrinhoCompra));

            //**********************************************************************************************************************************************************
            //**********************************************************************************************************************************************************
            services.AddMemoryCache();
            services.AddSession();

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

                //teste
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseCookiePolicy();

            //Ativando a sessão - Session
            app.UseSession();

            //Ativando a Autenticação - adiciona a autenticação ao Pipeline da solicitação Identity
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

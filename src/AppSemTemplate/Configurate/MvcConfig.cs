using AppSemTemplate.Data;
using AppSemTemplate.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using AppSemTemplate.Configuration;
using System.Reflection;

namespace AppSemTemplate.Configurate{

    public static class MvcConfig{

        public static WebApplicationBuilder AddMvcConfiguration(this WebApplicationBuilder builder){
        
              builder.Configuration
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables()
                .AddUserSecrets(Assembly.GetExecutingAssembly(), true);


 builder.Services.Configure<ApiConfiguration>(builder.Configuration.GetSection(ApiConfiguration.ConfigName));           
        
         builder.Services.AddControllersWithViews(options =>
        {
        options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
        });

        builder.Services.Configure<RazorViewEngineOptions>(options =>
        {
            options.AreaViewLocationFormats.Clear();
            options.AreaViewLocationFormats.Add("/Modulos/{2}/Views/{1}/{0}.cshtml");
            options.AreaViewLocationFormats.Add("/Modulos/{2}/Views/Shared/{0}.cshtml");
            options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
        });

            builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
            ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

        return builder;
        }
    
    
        public static WebApplication UseMvcConfiguration(this WebApplication app){

                        if(app.Environment.IsDevelopment()){

            }
            else{
            app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

                app.MapAreaControllerRoute("AreaProdutos", "Produtos", "Produto/{controller=Cadastro}/{action=Index}/{id?}");
                app.MapAreaControllerRoute("AreaVendas", "Vendas", "Vendas/{controller=Gestao}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();
            using (var serviceScope = app.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                var singService = services.GetRequiredService<IOperacaoSingleton>();

                Console.WriteLine("Direto da Program.cs" + singService.OperacaoId);
            }
            return app;
            


        }
    }

}

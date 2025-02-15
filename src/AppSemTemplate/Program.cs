using AppSemTemplate.Data;
using Microsoft.EntityFrameworkCore;
using AppSemTemplate.Extensions;
using Microsoft.AspNetCore.Mvc.Razor;
using AppSemTemplate.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllersWithViews();

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

//builder.Services.AddRouting(options =>
//{
//    options.ConstraintMap["slugify"] = typeof(RouteSlugifyParameterTransformer);
//});


builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddTransient<IOperacaoTransient, Operacao>();
builder.Services.AddScoped<IOperacaoScoped, Operacao>();
builder.Services.AddSingleton<IOperacaoSingleton, Operacao>();
builder.Services.AddSingleton<IOperacaoSingletonInstance>(new Operacao(Guid.Empty));

builder.Services.AddTransient<OperacaoService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

//app.MapControllerRoute(
  //  name: "default",
    //pattern: "{controller:slugify=Home}/{action=sluify=}/{id?}");

//app.MapControllerRoute(
  //  name : "areas",
    //pattern : "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    app.MapAreaControllerRoute("AreaProdutos", "Produtos", "Produto/{controller=Cadastro}/{action=Index}/{id?}");
    app.MapAreaControllerRoute("AreaVendas", "Vendas", "Vendas/{controller=Gestao}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


  using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;

    var singService = services.GetRequiredService<IOperacaoSingleton>();

    Console.WriteLine("Direto da Program.cs" + singService.OperacaoId);
}

app.Run();
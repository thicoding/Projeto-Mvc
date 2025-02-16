using AppSemTemplate.Data;
using Microsoft.EntityFrameworkCore;
using AppSemTemplate.Extensions;
using Microsoft.AspNetCore.Mvc.Razor;
using AppSemTemplate.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;


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

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("PodeExcluirPermanentemente", policy =>
            policy.RequireRole("Admin"));

    options.AddPolicy("VerProdutos", policy =>
        policy.RequireClaim("Produtos", "VI"));
});

var app = builder.Build();

if(app.Environment.IsDevelopment()){

}
else{
  app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

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

app.MapRazorPages();
  using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;

    var singService = services.GetRequiredService<IOperacaoSingleton>();

    Console.WriteLine("Direto da Program.cs" + singService.OperacaoId);
}

app.Run();
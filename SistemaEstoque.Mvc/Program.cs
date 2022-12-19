using SistemaEstoque.Domain.Interfaces.Repositories;
using SistemaEstoque.Domain.Interfaces.Services;
using SistemaEstoque.Domain.Services;
using SistemaEstoque.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IMercadoriaDomainService, MercadoriaDomainService>();
builder.Services.AddTransient<IMercadoriaRepository, MercadoriaRepository>();

builder.Services.AddTransient<IEntradaDomainService, EntradaDomainService>();
builder.Services.AddTransient<IEntradaRepository, EntradaRepository>();

builder.Services.AddTransient<ISaidaDomainService, SaidaDomainService>();
builder.Services.AddTransient<ISaidaRepository, SaidaRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Mercadorias}/{action=Consulta}/{id?}");

app.Run();

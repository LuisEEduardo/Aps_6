using App.Application;
using App.Application.implementation;
using App.Data;
using App.Repositorio.Implementacao;
using App.Repositorio.Implementacao.ContextoDados;
using App.Repositorio.Implementacao.ContextoUsuario;
using App.Repositorio.Interface;
using App.Repositorio.Interface.ContextoDados;
using App.Repositorio.Interface.ContextoUsuario;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Contexto>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("UserDatabase"))
);

builder.Services.AddScoped(typeof(IBaseRepositorio<>), typeof(BaseRepositorio<>));
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IDadosRepositorio, DadosRepositorio>();

builder.Services.AddScoped<IUsuarioAplicacao, UsuarioAplicacao>();
builder.Services.AddScoped<IDadosAplicacao, DadosAplicacao>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();

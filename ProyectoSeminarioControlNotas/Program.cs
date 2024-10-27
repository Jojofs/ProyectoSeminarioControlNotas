using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProyectoSeminarioControlNotas.Models;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Configuracion de DbContext: Cuando se hacen pruebas locales debe cambiarse por la variable "conexionSQLServer", en caso de pasar al servidor debe usarse "conexionSQLServer"
builder.Services.AddDbContext<ProyectoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexionSQLServer")));

builder.Services.AddDefaultIdentity<Usuario>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>().AddEntityFrameworkStores<ProyectoDbContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Otras configuraciones...

    // Configuracion para bloqueo de cuenta (Lockout)
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Tiempo de bloqueo
    options.Lockout.MaxFailedAccessAttempts = 5; // Número máximo de intentos fallidos
    options.Lockout.AllowedForNewUsers = true; // Permite el bloqueo para nuevos usuarios
});



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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
//Proyecto realizado por el grupo #4 de Seminario 2024 UMG Cuilapa
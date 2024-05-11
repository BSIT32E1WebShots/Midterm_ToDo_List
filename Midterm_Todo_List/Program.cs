using Microsoft.EntityFrameworkCore;
using ToDo.Domain;
using System;
using ToDo.Repository;
using ToDo.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer("Server=DESKTOP-TAHDD9J\\SQLEXPRESS01;Database=dbToDO;Trusted_Connection=True;TrustServerCertificate=True");
});

builder.Services.AddSingleton<ToDoRepository>();
builder.Services.AddScoped<ToDoService>();
builder.Services.AddScoped<ToDoController>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ToDo}/{action=Index}/{id?}");

app.Run();


using Microsoft.AspNetCore.ResponseCompression;
using Tesing2.Server.Repository;
using Tesing2.Server.Services;
using Tesing2.Server.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Tesing2.Server.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddTransient<IHocSinhRepository<HocSinh>, HocSinhRepository>();
builder.Services.AddTransient<IHocSinhService, HocSinhService>();
builder.Services.AddDbContext<DapperContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

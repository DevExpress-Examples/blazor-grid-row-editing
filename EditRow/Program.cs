using EditRow.Data;
using EditRow.Data.Northwind;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();


builder.Services.AddDevExpressBlazor(opt => {
    opt.BootstrapVersion = DevExpress.Blazor.BootstrapVersion.v5;
});
builder.Services.AddEntityFrameworkSqlServer();
builder.Services.AddDbContextFactory<NorthwindContext>((sp, options) => {
    var env = sp.GetRequiredService<IWebHostEnvironment>();
    var dbPath = Path.Combine(env.ContentRootPath, "Northwind-5e44b51f.mdf");
    options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=" + dbPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if(!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

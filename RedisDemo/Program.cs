using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using RedisDemo.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

//Adding Caching info
builder.Services.AddStackExchangeRedisCache(opts =>
{
	opts.Configuration = builder.Configuration.GetConnectionString("Redis");
	opts.InstanceName = "RedisDemo_"; // prepend to every key this value (key - Den, as a result => RedisDemo_Den is the key)
});


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

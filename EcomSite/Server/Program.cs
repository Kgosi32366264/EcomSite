global using EcomSite.Server.Data;
global using Microsoft.EntityFrameworkCore;
global using EcomSite.Shared;
using EcomSite.Server.Services.CatergoryService;
using EcomSite.Server.Services.ProductService;
using EcomSite.Server.Services.AuthService;
using NLog.Extensions.Logging;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
{
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICatergoryService, CatergoryService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddLogging(loggingBuilder =>
{
  loggingBuilder.ClearProviders();
  loggingBuilder.SetMinimumLevel(LogLevel.Trace);
  loggingBuilder.SetMinimumLevel(LogLevel.Debug);
  loggingBuilder.AddNLog();
  loggingBuilder.AddNLogWeb();
});

//ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
//{
//  builder.AddConsole();
//});

//builder.Services.AddHttpContextAccessor();
//builder.Services.AddHttpLogging(logging => { logging.LoggingFields = HttpLoggingFields.All;});

var app = builder.Build();

app.UseHttpLogging();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
  app.UseWebAssemblyDebugging();
}
else
{
  app.UseExceptionHandler("/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}
app.UseCors();
app.UseHttpsRedirection();

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

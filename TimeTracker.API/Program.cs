using Microsoft.EntityFrameworkCore;
using TimeTracker.API.Data;
using TimeTracker.API.Repositories;
using TimeTracker.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ITimeEntryRepository, TimeEntryRepository>();    
builder.Services.AddScoped<ITimeEntryService, TimeEntryService>();  
builder.Services.AddDbContext<DataContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseWebAssemblyDebugging();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.MapRazorPages();
app.MapFallbackToFile("index.html");

app.UseAuthorization();

app.MapControllers();

app.Run();

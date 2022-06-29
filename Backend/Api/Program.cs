using Api.Helpers;
using Domain;
using Domain.Interfaces;
using Infrastructure;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

var _config = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(AutomapperProfile).Assembly);
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<StoreContext>();
builder.Services.AddDbContext<StoreContext>(o => o.UseSqlServer(_config.GetConnectionString("default")));
builder.Services.AddCors();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();



app.UseHttpsRedirection();

app.UseAuthorization();
app.UseStaticFiles(new StaticFileOptions()
{
    RequestPath = "/images",
    FileProvider = new PhysicalFileProvider(Path.Combine(app.Environment.ContentRootPath, "Images"))
});
app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.MapControllers();

app.Run();

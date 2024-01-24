using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shop.Application.Common.Interfaces;
using Shop.Application.Common.Models;
using Shop.Infrastructure.DataLayer;
using Shop.Infrastructure.Identity;
using Shop.Entities;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(x => x.Filters.Add(new AuthorizeFilter()));


builder.Services.AddDbContext<ShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShopDbContext"));

    if (builder.Environment.IsDevelopment())
    {
        options.EnableSensitiveDataLogging();
        options.EnableDetailedErrors();
        options.LogTo(Console.WriteLine,
            new[] { DbLoggerCategory.Database.Command.Name },
            LogLevel.Information);
    }
});


builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ShopDbContext>();


builder.Services.AddScoped<IIdentityService, IdentityService>();
builder.Services.AddScoped<IShopDbContext, ShopDbContext>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;    //Ova i netreba
                                                                               //Ova go koristime koga nekoja druga authentication primer oauth 2.0 
}).AddJwtBearer(x => {
    x.RequireHttpsMetadata = true;
    x.SaveToken = true;
    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = false,                                                 // ova e koj go izdava
        ValidateAudience = false,                                               // Ova e za kogo se odnesuva
        ValidateLifetime = false,                                               // Ova dali tokenot e istecen 
        ValidateIssuerSigningKey = true,                                        // 
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("SecretKey")))
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoint =>
{
    endpoint.MapControllers();
});

app.Run();

using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shop.Application.Common.Interfaces;
using Shop.Application.Common.Models;
using Shop.Application.Repositories.AddressRepository.Interface;
using Shop.Application.Repositories.AddressRepository.Services;
using Shop.Application.Repositories.CartRepository.Interface;
using Shop.Application.Repositories.CartRepository.Services;
using Shop.Application.Repositories.OrderRepository.Interface;
using Shop.Application.Repositories.OrderRepository.Services;
using Shop.Application.Repositories.ProductRepository.Interface;
using Shop.Application.Repositories.ProductRepository.Services;
using Shop.Entities;
using Shop.Infrastructure.DataLayer;
using Shop.Infrastructure.Identity;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// x => x.Filters.Add(new AuthorizeFilter())
builder.Services.AddControllers();


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

builder.Services.AddCors(x =>
{
    x.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:7141");
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();
    });
});


builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ShopDbContext>();


builder.Services.AddScoped<IIdentityService, IdentityService>();
builder.Services.AddScoped<IShopDbContext, ShopDbContext>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<ICartService, CartServices>();
builder.Services.AddScoped<IOrder, OrderService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var mapperConfig = new MapperConfiguration(mc =>
{
    mc.CreateMap<Product, ProductDto>();
    mc.CreateMap<ProductDto, Product>();
    mc.CreateMap<Address, AddressDto>();
    mc.CreateMap<AddressDto, Address>();
    /*    mc.CreateMap<CartItem, CartItemDto>();
        mc.CreateMap<CartItemDto, CartItem>();*/
    mc.CreateMap<Order, OrderDto>();
    mc.CreateMap<OrderDto, Order>();
});

IMapper mapper = mapperConfig.CreateMapper();

builder.Services.AddCors(options => options.AddPolicy("DefaultCorsPolicy", policy =>
{
    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader();
}));

builder.Services.AddSingleton(mapper);


builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;    //Ova i netreba
                                                                               //Ova go koristime koga nekoja druga authentication primer oauth 2.0 
}).AddJwtBearer(x =>
{
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
app.UseSession();
app.UseRouting();

app.UseCors("DefaultCorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoint =>
{
    endpoint.MapControllers();
});

app.Run();



using FreshMarket.Application.Interfaces;
using FreshMarket.Application.Services;
using FreshMarket.Infrastructure.Data;
using FreshMarket.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using FreshMarket.Infrastructure.Services;


var builder = WebApplication.CreateBuilder(args);

// Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));


// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductImageRepository, ProductImageRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();

// Services
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IAuthService, AuthService>();  
builder.Services.AddScoped<ICategoryService, CategoryService>();  
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<ICartService, CartService>();




// Services
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapControllers();

app.Run();
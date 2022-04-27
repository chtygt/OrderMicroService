using Microsoft.EntityFrameworkCore;
using Services.Product.Api.Services;
using Services.Product.Data;
using Services.Product.Repositories;
using Services.Shared.Authentication.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProductDb(builder.Configuration);
builder.Services.AddProductDataRepositories();
builder.Services.AddScoped<ProductService>();
builder.Services.AddAuthenticationTokenClientHelper(builder.Configuration);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
    using (var scope = app.Services.CreateScope())
    {
        var dataContext = scope.ServiceProvider.GetRequiredService<ProductDbContext>();
        dataContext.Database.Migrate();
    }
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

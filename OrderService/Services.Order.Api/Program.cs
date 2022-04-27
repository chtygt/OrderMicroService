using Microsoft.EntityFrameworkCore;
using Services.Order.Api.Services;
using Services.Order.Data;
using Services.Order.Repositories;
using Services.Shared.Authentication.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOrderDb(builder.Configuration);
builder.Services.AddOrderDataRepositories();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<OrderItemService>();
builder.Services.AddAuthenticationTokenClientHelper(builder.Configuration);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
    using (var scope = app.Services.CreateScope())
    {
        var dataContext = scope.ServiceProvider.GetRequiredService<OrderDbContext>();
        dataContext.Database.Migrate();
    }
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

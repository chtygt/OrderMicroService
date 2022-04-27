using Microsoft.EntityFrameworkCore;
using Services.Customer.Api.Services;
using Services.Customer.Data;
using Services.Customer.Repositories;
using Services.Shared.Authentication.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCustomerDb(builder.Configuration);
builder.Services.AddCustomerDataRepositories();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddAuthenticationTokenClientHelper(builder.Configuration);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
    using (var scope = app.Services.CreateScope())
    {
        var dataContext = scope.ServiceProvider.GetRequiredService<CustomerDbContext>();
        dataContext.Database.Migrate();
    }
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

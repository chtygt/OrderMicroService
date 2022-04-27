using GreenPipes;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Services.Order.Client.Base;
using Services.Product.Client.Base;
using Services.Customer.Client.Base;
using Services.Report.Data;
using Services.Report.EventBus.Consumers;
using Services.Report.Repositories;
using Services.Report.Services;
using Services.Report.Services.Events;
using Services.Shared.Authentication.Client;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddReportDb(builder.Configuration);
builder.Services.AddOrderDataRepositories();
builder.Services.AddScoped<ReportService>();
builder.Services.AddScoped<ReportEvents>();
builder.Services.AddOrderApiClient(op =>
{
    op.BaseUrl = ""; // for apigateway
    op.ApiPath = "http://order-service-db:3530/";
});
builder.Services.AddCustomerApiClient(op =>
{
    op.BaseUrl = ""; // for apigateway
    op.ApiPath = "http://customer-service-db:3510/";
});
builder.Services.AddProductApiClient(op =>
{
    op.BaseUrl = ""; // for apigateway
    op.ApiPath = "http://product-service-db:3520/";
});
builder.Services.AddAuthenticationTokenClientHelper(builder.Configuration);


#region EventBus

builder.Services.AddMassTransit(c =>
{
    c.AddConsumersFromNamespaceContaining<ReportRequestEventConsumer>();
    c.SetKebabCaseEndpointNameFormatter();
    c.UsingRabbitMq((busContext, conf) =>
    {
        conf.Host(builder.Configuration.GetConnectionString("RabbitMQ"));
        conf.ConfigureEndpoints(busContext);
        conf.UseRetry(r => r.Interval(5, TimeSpan.FromSeconds(2)));
    });
});

builder.Services.AddMassTransitHostedService();

#endregion
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    using (var scope = app.Services.CreateScope())
    {
        var dataContext = scope.ServiceProvider.GetRequiredService<ReportDbContext>();
        dataContext.Database.Migrate();
    }
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

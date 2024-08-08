using SanboxServerManager.Infrastructure;
using SanboxServerManager.Application;
using SanboxServerManager.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureMassTransit();
builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

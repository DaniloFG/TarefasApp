using TarefasApp.API.Extensions;
using TarefasApp.Application.Extensions;
using TarefasApp.Infra.Data.Extensions;
using TarefasApp.Infra.Storage.Extensions;
using TarefasApp.Domain.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddSwaggerDoc();
builder.Services.AddApplicationServices();
builder.Services.AddDomainServices();
builder.Services.AddDataContext(builder.Configuration);
builder.Services.AddMongoDb(builder.Configuration);

var app = builder.Build();

app.UseSwaggerDoc();
app.UseAuthorization();
app.MapControllers();
app.Run();

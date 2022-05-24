using Infra.API.Data;
using Infra.API.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<InfraDBContext>(
    o => o.UseNpgsql(builder.Configuration.GetValue<string>("DatabaseSettings:ConnectionString"))
    );

//builder.Services.AddControllers()
//            .AddJsonOptions(o => o.JsonSerializerOptions
//                .ReferenceHandler = ReferenceHandler.Preserve);

builder.Services.AddMvc()
     .AddNewtonsoftJson(
          options => {
              options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
          });

builder.Services.AddScoped<IInfraDBContext, InfraDBContext>();
builder.Services.AddScoped<IGlobalEnviromentRepository, GlobalEnviromentRepository>();
builder.Services.AddScoped<IServerRepository, ServerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();



app.Run();

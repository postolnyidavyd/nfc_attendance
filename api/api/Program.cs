using System.Text.Json.Serialization;
using DataAccess;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddServices(builder.Configuration);
builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapControllers();

app.Run();
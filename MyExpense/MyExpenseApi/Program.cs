using Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(settings =>
{
    settings.Title = "MyExpense API";
    settings.Version = "v1";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwaggerUi3(settings =>
{
    settings.Path = "/api";
    settings.DocumentPath = "/api/specification.json";
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
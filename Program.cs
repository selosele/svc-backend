using svc.App.Code.Repositories;
using svc.App.Code.Services;
using svc.App.Shared.Configs.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Configuration.AddJsonFile("secrets.json", optional: true, reloadOnChange: true);

Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true; // COLUMN_NAME -> columnName 변환
builder.Services.Configure<ConnectionString>(builder.Configuration.GetSection("ConnectionStrings")); // DB 연결
builder.Services.AddSingleton<CodeRepository>();
builder.Services.AddSingleton<CodeService>();
builder.Services.AddSingleton<ConnectionProvider>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

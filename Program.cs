using svc.App.Auth.Models.Profiles;
using svc.App.Auth.Repositories;
using svc.App.Auth.Services;
using svc.App.Code.Models.Profiles;
using svc.App.Code.Repositories;
using svc.App.Code.Services;
using svc.App.Shared.Configs.Database;
using svc.App.Shared.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("secrets.json", optional: true, reloadOnChange: true);

Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true; // COLUMN_NAME -> columnName 변환
builder.Services.Configure<ConnectionString>(builder.Configuration.GetSection("ConnectionStrings")); // DB 연결
builder.Services.AddSingleton<ConnectionProvider>();
builder.Services.AddSingleton<UserRepository>();
builder.Services.AddSingleton<UserRoleRepository>();
builder.Services.AddSingleton<CodeRepository>();
builder.Services.AddSingleton<AuthService>();
builder.Services.AddSingleton<CodeService>();
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile(typeof(AuthProfile));
    cfg.AddProfile(typeof(CodeProfile));
});
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new BizExceptionFilter());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

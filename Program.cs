using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using svc.App.Auth.Models.Profiles;
using svc.App.Auth.Repositories;
using svc.App.Auth.Services;
using svc.App.Code.Models.Profiles;
using svc.App.Code.Repositories;
using svc.App.Code.Services;
using svc.App.Menu.Models.Profiles;
using svc.App.Menu.Repositories;
using svc.App.Menu.Services;
using svc.App.Shared.Configs.Database;
using svc.App.Shared.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("secrets.json", optional: true, reloadOnChange: true);

Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true; // COLUMN_NAME -> columnName 변환
builder.Services.Configure<ConnectionString>(builder.Configuration.GetSection("ConnectionStrings")); // DB 연결
builder.Services.AddSingleton<ConnectionProvider>();
builder.Services.AddSingleton<UserRepository>();
builder.Services.AddSingleton<UserRoleRepository>();
builder.Services.AddSingleton<UserMenuRoleRepository>();
builder.Services.AddSingleton<CodeRepository>();
builder.Services.AddSingleton<MenuRepository>();
builder.Services.AddSingleton<MenuRoleRepository>();
builder.Services.AddSingleton<AuthService>();
builder.Services.AddSingleton<CodeService>();
builder.Services.AddSingleton<MenuService>();
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile(typeof(AuthProfile));
    cfg.AddProfile(typeof(CodeProfile));
    cfg.AddProfile(typeof(MenuProfile));
});
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new BizExceptionFilter());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication(cfg => 
{
    cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    cfg.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x => {
    x.RequireHttpsMetadata = false;
    x.SaveToken = false;
    x.TokenValidationParameters = new TokenValidationParameters {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["ApplicationSettings:JWTSecret"]!)
        ),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});

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

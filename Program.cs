using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Svc.App.Shared.Filters;
using Svc.App.Shared.Extensions;
using Svc.App.Shared.Models.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("secrets.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

// 운영 환경에서 SSL 인증서 적용
var certPath = builder.Configuration["ApplicationSettings:CertPfxPath"];
var certPassword = builder.Configuration["ApplicationSettings:CertPfxPassword"];

if (!string.IsNullOrEmpty(certPath) && !string.IsNullOrEmpty(certPassword))
{
    builder.WebHost.ConfigureKestrel(serverOptions =>
    {
        serverOptions.ListenLocalhost(5001, listenOptions =>
        {
            listenOptions.UseHttps(certPath, certPassword);
        });
    });
}
// else
// {
//     Console.WriteLine("⚠️ SSL 설정이 누락되어 HTTP로 실행");
//     builder.WebHost.ConfigureKestrel(serverOptions =>
//     {
//         serverOptions.ListenAnyIP(5000);
//     });
// }

builder.Services.SingletonScan("Svc.App.", ".Services");
builder.Services.SingletonScan("Svc.App.", ".Mappers");
builder.Services.AutoMapperProfileScan("Svc.App.", ".Profiles");
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));

var connectionStrings = builder.Configuration.GetSection("ConnectionStrings")
    .GetChildren()
    .ToDictionary(x => x.Key, x => x.Value);

builder.Services.AddSmartSql((sp, builder) =>
{
    builder.UseProperties((IEnumerable<KeyValuePair<string, string>>) connectionStrings);
});
builder.Services.AddControllers(x =>
{
    x.Filters.Add(new BizExceptionFilter());
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("RestrictedCors", policy =>
    {
        policy
            .WithOrigins(
                "http://localhost:4200",
                "https://35.203.170.186",
                "https://34.170.50.142",
                "https://svc-steel.vercel.app",
                "https://svc.selosele.com"
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
builder.Services.AddHttpClient();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication(x => 
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = false;
    x.TokenValidationParameters = new TokenValidationParameters
    {
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

app.UseCors("RestrictedCors");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

// app.UseDefaultFiles();
// app.UseStaticFiles();
// app.MapFallbackToFile("index.html");

app.MapControllers();

app.Run();

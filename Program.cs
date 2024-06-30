using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using svc.App.Auth.Models.Profiles;
using svc.App.Auth.Services;
using svc.App.Code.Models.Profiles;
using svc.App.Code.Services;
using svc.App.Menu.Models.Profiles;
using svc.App.Menu.Services;
using svc.App.Shared.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("secrets.json", optional: true, reloadOnChange: true);

builder.Services.AddSingleton<AuthService>();
builder.Services.AddSingleton<CodeService>();
builder.Services.AddSingleton<MenuService>();
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile(typeof(AuthProfile));
    cfg.AddProfile(typeof(CodeProfile));
    cfg.AddProfile(typeof(MenuProfile));
});

var connectionStrings = builder.Configuration.GetSection("ConnectionStrings")
    .GetChildren()
    .ToDictionary(x => x.Key, x => x.Value);

builder.Services.AddSmartSql((sp, builder) =>
                {
                    builder.UseProperties((IEnumerable<KeyValuePair<string, string>>) connectionStrings);
                })
                .AddRepositoryFromAssembly(o =>
                {
                    o.AssemblyString = "svc";
                    o.Filter = (type) => type.Namespace != null && type.Namespace.StartsWith("svc.App.") && type.Namespace.EndsWith(".Repositories");
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

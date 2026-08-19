using Backend.Models.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// ========================================
// 1. Database
// ========================================
builder.Services.AddDbContext<TestDBContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultDBConnection")
    );
});

// ========================================
// 2. Authentication
// ========================================
builder.Services
    .AddAuthentication(options =>
    {
        // 平常用 Cookie 保存登入狀態
        options.DefaultAuthenticateScheme =
            CookieAuthenticationDefaults.AuthenticationScheme;

        options.DefaultSignInScheme =
            CookieAuthenticationDefaults.AuthenticationScheme;

        // 需要登入時，導向 Google
        options.DefaultChallengeScheme =
            GoogleDefaults.AuthenticationScheme;
    })
    .AddCookie(options =>
    {
        // 如果之後使用 [Authorize]
        // 未登入時可以自訂處理方式
        options.Cookie.Name = "Backend.Auth";
    })
    .AddGoogle(options =>
    {
        options.ClientId =
            builder.Configuration["Authentication:Google:ClientId"]
            ?? throw new InvalidOperationException(
                "Authentication:Google:ClientId 尚未設定"
            );

        options.ClientSecret =
            builder.Configuration["Authentication:Google:ClientSecret"]
            ?? throw new InvalidOperationException(
                "Authentication:Google:ClientSecret 尚未設定"
            );

        // Google 登入完成後，
        // Google 會導回 ASP.NET Middleware 的這個網址
        options.CallbackPath = "/signin-google";
    });

// ========================================
// 3. Authorization
// ========================================
builder.Services.AddAuthorization();

// ========================================
// 4. Controllers
// ========================================
builder.Services.AddControllers();

// ========================================
// 5. CORS
// ========================================
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowNextJS", policy =>
    {
        policy
            .WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

// ========================================
// 6. Swagger
// ========================================
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1",
        Description = "系統 API 文件"
    });

    var xmlFileName =
        $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

    var xmlFilePath =
        Path.Combine(AppContext.BaseDirectory, xmlFileName);

    if (File.Exists(xmlFilePath))
    {
        options.IncludeXmlComments(xmlFilePath);
    }
});

// ========================================
// 這行一定要放在所有 builder.Services.xxx 之後
// ========================================
var app = builder.Build();

// ========================================
// HTTP Request Pipeline
// ========================================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(
            "/swagger/v1/swagger.json",
            "My API v1"
        );

        options.RoutePrefix = "swagger";
    });
}

// 如果目前 localhost HTTPS 憑證有問題，
// 測試 OAuth 時可以先註解觀察。
// app.UseHttpsRedirection();

// CORS 要在 Authentication / Authorization 前面
app.UseCors("AllowNextJS");

// 驗證「你是誰」
app.UseAuthentication();

// 授權「你能不能做這件事」
app.UseAuthorization();

// Controller Route
app.MapControllers();

app.Run();
using Backend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TestDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDBConnection")));


builder.Services.AddControllers();//方法的建置(動作)
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowNextJS", policy =>
    {
        policy
            .WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
builder.Services.AddEndpointsApiExplorer();//控制器路由建置
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1",
        Description = "系統 API 文件"
    });

    var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";//抓組件內的預設XML
    var xmlFilePath = Path.Combine(AppContext.BaseDirectory, xmlFileName);//組成應用程式路徑和抓取檔案名稱

    if (File.Exists(xmlFilePath))
    {
        options.IncludeXmlComments(xmlFilePath);
    }
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
        options.RoutePrefix = "swagger";
    });
}


app.UseCors("NextJsPolicy");

app.UseCors("AllowNextJS");

app.UseAuthorization();//守門員

app.MapControllers();//設定路由

app.Run();//執行

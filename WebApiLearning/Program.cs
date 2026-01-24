using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using WebApiLearning.Services;
var builder = WebApplication.CreateBuilder(args);

//CORS設定
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .AllowAnyOrigin()   // すべてのアクセス元を許可
            .AllowAnyHeader()   // すべてのヘッダーを許可
            .AllowAnyMethod();  // GET/POSTなど全許可
    });
});
builder.Services.AddControllers();

//DB設定
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IFaceDiagnosisService, FaceDiagnosisService>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

//Hello API
app.MapGet("/api/hello", () =>
{
    return Results.Ok(new { message = "こんにちは!ASP.NET Core Web APIへようこそ!" });
})
.WithName("GetHello")
.WithDescription("簡単な挨拶メッセージを返します。");

//Param API
app.MapGet("/api/param/{name}", (string name) =>
{
    return Results.Ok(new { message = $"Param = {name}" });
})
.WithName("GetParam")
.WithDescription("入力したパラメータを返します");

//POST API
app.MapPost("/api/user", async (UserRequest request, AppDbContext db) =>
{
    var user = new User { Name = request.Name, Age = request.Age };
    db.Users.Add(user);
    await db.SaveChangesAsync();
    return Results.Created($"/api/user/{user.Id}", user);
})
.WithName("PostUser")
.WithDescription("POST形式のAPI");

//Face API
app.MapPost("/api/Face", async (FaceRequest request, AppDbContext db) =>
{
    //　レスポンスを作成
    var sociableSum = request.EarlySociable + request.MidSociable + request.LateSociable;
    var message = "";
    if (sociableSum >= 15)
    {
        message = "明るいんですね！";
    }
    else if (sociableSum >= 10)
    {
        message = "暗いんですね!";
    }
    else
    {
        message = "きもw";
    }

    //DBにinsert
    var faceLog = new FaceLog
    {
        BirthDate = request.BirthDate,
        Gender = request.Gender,
        Job = request.Job,
        EarlySociable = request.EarlySociable,
        MidSociable = request.MidSociable,
        LateSociable = request.LateSociable
    };
    db.FaceLogs.Add(faceLog);
    await db.SaveChangesAsync();
    return Results.Created($"/api/Face/{faceLog.Id}", new { response = message });
})
.WithName("PostFace")
.WithDescription("FaceLogを登録するAPI");

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

//CORS有効化
app.UseCors();
app.MapControllers();
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

public class UserRequest
{
    public string Name { get; set; } = "";
    public int Age { get; set; }
}

public class FaceRequest
{
    public DateTime BirthDate { get; set; }
    public bool Gender { get; set; }
    public string Job { get; set; } = "";
    public int EarlySociable { get; set; }
    public int MidSociable { get; set; }
    public int LateSociable { get; set; }
}
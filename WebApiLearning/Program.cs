using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

//DB設定
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

//Hello API
app.MapGet("/api/hello",()=>{
    return Results.Ok(new {message = "こんにちは!ASP.NET Core Web APIへようこそ!"});
})
.WithName("GetHello")
.WithDescription("簡単な挨拶メッセージを返します。");

//Param API
app.MapGet("/api/param/{name}",(string name)=>{
    return Results.Ok(new {message = $"Param = {name}"});
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

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
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

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

public class UserRequest
{
    public string Name {get; set;} = "";
    public int Age {get; set;}
}
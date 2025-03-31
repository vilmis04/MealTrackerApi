using dotenv.net;
using MealTrackerApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MealContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MealContext") ?? throw new InvalidOperationException("Connection string 'MealContext' not found.")));

// builder.Configuration.SetBasePath(Directory.GetCurrentDirectory());
// builder.Configuration.AddJsonFile("appsettings.json", true);
// builder.Configuration.AddEnvironmentVariables();
IConfiguration configuration = builder.Configuration;

DotEnv.Load();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var envVars = DotEnv.Read();
builder.Services.AddDbContext<MealContext>(options => options.UseSqlServer(envVars["DB_CONNECTION_STRING"]));

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

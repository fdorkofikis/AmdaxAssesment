using SumSubWebhook;
using SumSubWebhook.Repository;
using SumSubWebhook.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IApplicantProcessService, ApplicantProcessService>();
builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    //NEED to install Nuget package for the corresponding DataBase
    //options.UseSqlServer(builder.Configuration.GetConnectionString("Database"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

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

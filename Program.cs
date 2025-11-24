using To_do_List.Contexto;
using To_do_List.Controllers;
using To_do_List.Interfaces;
using To_do_List.Model;
using To_do_List.services;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
///builder.Services.AddScoped<RegistrarModel>();
builder.Services.AddSqlServer<TareaContexto>(builder.Configuration.GetConnectionString("Appconnection"));
builder.Services.AddScoped<Itarea, TareaServicio>();

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

string? connectionString = builder.Configuration.GetConnectionString("Appconnection");



builder.Services.AddSqlServer<TareaContexto>(builder.Configuration.GetConnectionString("Appconnection"));
builder.Services.AddScoped<Itarea, TareaServicio>();


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                      });
});

builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using Microsoft.EntityFrameworkCore;
using PhotosApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Cors allow
builder.Services.AddCors(o => o.AddPolicy("LowCorsPolicy", builder =>
                             {
                                 builder.AllowAnyOrigin()
                                        .AllowAnyMethod()
                                        .AllowAnyHeader();
                             }));



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ImageDbContext>(x => x.UseSqlServer(connectionString));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("LowCorsPolicy");
app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();
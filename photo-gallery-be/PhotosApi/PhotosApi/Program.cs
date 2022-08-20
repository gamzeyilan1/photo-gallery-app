using Microsoft.EntityFrameworkCore;
using PhotosApi.Models;

var builder = WebApplication.CreateBuilder(args);

/* Allows CORS */
builder.Services.AddCors(o => o.AddPolicy("LowCorsPolicy", builder =>
                             {
                                 builder.AllowAnyOrigin()
                                        .AllowAnyMethod()
                                        .AllowAnyHeader();
                             }));



/* Adds services */
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/* Connects to the local DB using the Connection String defined on appsettings.json */
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ImageDbContext>(x => x.UseSqlServer(connectionString));
var app = builder.Build();

/* Configures the HTTP request pipeline. */
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
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer;
using shifts_logger.Data;
using shifts_logger.Interfaces;
using shifts_logger.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<IShiftLogsRepository, ShiftLogsRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add services to the container.
builder.Services.AddDbContext<ShiftLogsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("myConnString")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


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

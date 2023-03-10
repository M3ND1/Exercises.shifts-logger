using Microsoft.EntityFrameworkCore;
using shifts_logger.Data;
using shifts_logger.Interfaces;
using shifts_logger.Repository;
using shifts_logger.SeedData;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddScoped<IShiftLogsRepository, ShiftLogsRepository>();
builder.Services.AddDbContext<ShiftLogsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("myConnString")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    Seed.Initialize(services);
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();

await app.RunAsync();

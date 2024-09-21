using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using StepanovAlexandrKt_41_21.Database;

var builder = WebApplication.CreateBuilder(args);

var logger=LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();


try
{
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();
    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<StudentDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}

catch(Exception ex)
{
    logger.Error(ex,"Stopped programm because of exception");
}
finally
{
    LogManager.Shutdown();
}
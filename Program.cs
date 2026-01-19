using LIBRARY_MANAGEMENT_SYSTEM.Data;
using LIBRARY_MANAGEMENT_SYSTEM.Extensions;
var builder = WebApplication.CreateBuilder(args);
builder.ConfigureSerilog();
builder.ConfigureDatabase();
builder.ConfigureApplicationServices();
builder.ConfigureJwtAuthentication();
builder.ConfigureSwagger();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition =
            System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault;
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseGlobalMiddlewares();
app.UseDatabaseMigrationAndSeeding();
app.MapControllers();
app.Run();

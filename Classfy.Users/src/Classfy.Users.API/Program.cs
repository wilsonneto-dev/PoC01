using Classfy.Unified.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddConnections(builder.Configuration)
    .AddMapper()
    .AddRepositories()
    .AddUseCases()
    .AddControllersAndConfigure()
    .AddSwaggerAndConfigure("Classfy API", "v1");

var app = builder.Build();

if (app.Environment.IsDevelopment()) app.UseSwaggerAndConfigure("Classfy API");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

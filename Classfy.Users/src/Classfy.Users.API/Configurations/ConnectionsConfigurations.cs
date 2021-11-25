namespace Classfy.Unified.API.Configurations
{
    public static class ConnectionsConfigurations
    {
        public static IServiceCollection AddConnections(this IServiceCollection services, IConfiguration configuration)
        {
            /*
             var connectionString = configuration.GetConnectionString("ClassfyUsesrsDatabaseConnectionString");
             services.AddDbContext<ClassfyUsersDbContext>(options => options.UseSqlServer(connectionString));
            */
            return services;
        }
    }
}

namespace Classfy.Unified.API.Configurations
{
    public static class MapperConfigurations
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            /* var MapperConfig = new MapperConfiguration(cfg => { });
            services.AddSingleton(MapperConfig.CreateMapper()); */
            return services;
        }
    }
}

namespace Classfy.Unified.API.Configurations
{
    public static class SwaggerConfigurations
    {
        public static IServiceCollection AddSwaggerAndConfigure(this IServiceCollection services, string title, string version)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = title, Version = version });
            });
            return services;
        }

        public static WebApplication UseSwaggerAndConfigure(this WebApplication app, string title)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", title));
            return app;
        }
    }
}

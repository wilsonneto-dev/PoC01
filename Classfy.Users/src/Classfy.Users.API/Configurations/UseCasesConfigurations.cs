using MediatR;

namespace Classfy.Unified.API.Configurations
{
    public static class UseCasesConfigurations
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            // services.AddMediatR(typeof(CreateAuthorUseCase));
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // services.AddScoped<IAuthorRepository, AuthorRepository>();
            return services;
        }

        public static IServiceCollection AddValidations(this IServiceCollection services)
        {
            /* services.AddFluentValidation(
                fluentValoidation => 
                    fluentValoidation.RegisterValidatorsFromAssemblyContaining<CreateAuthorUseCase>()
            ); */
            return services;
        }
    }
}

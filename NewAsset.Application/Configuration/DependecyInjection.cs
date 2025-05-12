

namespace NewAsset.Application.Configuration
{

    /// <summary>
    /// This is an extension class to manage DI at the application
    /// layer
    /// </summary>
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddFluentValidation(validator=>
            validator.RegisterValidatorsFromAssemblyContaining<AssetCapitalInsuranceRegistrationRequestValidator>()
            );
            //for request passing thriugh mediaR
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}

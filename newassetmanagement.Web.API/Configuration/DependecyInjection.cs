

namespace NewAsset.Presentation.API.Configuration
{

    /// <summary>
    /// Extension class for dependency  management for the presentation layer
    /// </summary>
    public static class DependecyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add<ValidationFilter>(); //global validatin rules
            });
            return services;
        }
    }
}

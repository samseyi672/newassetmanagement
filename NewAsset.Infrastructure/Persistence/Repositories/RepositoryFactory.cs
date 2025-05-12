

namespace NewAsset.Infrastructure.Persistence.Repositories
{
    /// <summary>
    /// This class will get the required repository by DI at runtime
    /// </summary>  
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public RepositoryFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TRepository Create<TRepository>() where TRepository : class
        {
            return _serviceProvider.GetRequiredService<TRepository>();
        }
    }

}

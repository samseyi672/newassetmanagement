

namespace NewAsset.Application.Common.Interfaces.Persistence
{
    
    // Abastraction for all Repositories in the unitofwork
    public interface IRepositoryFactory
    {
        TRepository Create<TRepository>() where TRepository : class;
    }

}

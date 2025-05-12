
namespace NewAsset.Application.Common.Interfaces.Persistence
{
    /// <summary>
    /// This is for basic house keeping to dispose all connections properly
    /// and do UoW pattern
    /// </summary>
    public interface IUnitOfWork:IDisposable
    {
        //  void BeginTransaction();
        TRepository GetRepository<TRepository>() where TRepository : class;
        void Commit();
        void CommitAndCloseConnection();
        void Rollback();
    }
}

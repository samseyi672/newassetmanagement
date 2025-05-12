

namespace NewAsset.Infrastructure.Persistence.Repositories
{

    /// <summary>
    /// The UoW class use to manage and coordinate transactional 
    /// operations across multiple repositories within a single business operation.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        //private readonly DapperDataContext _dapperDataContext;
        private DapperDataContext _dapperDataContext;
        private readonly IRepositoryFactory _repositoryFactory;
        private MySqlConnection _connection;
        private IDbTransaction _transaction;
        public AppDbContext EFContext { get; private set; }
        private readonly Dictionary<Type, object> _repositories = new();

        public UnitOfWork(IConfiguration configuration, IRepositoryFactory repositoryFactory)
        {
            // _dapperDataContext = dapperDataContext;
            _repositoryFactory = repositoryFactory;
            string connectionString = configuration.GetConnectionString("dbconn");
            _connection = new MySqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
             _dapperDataContext = new DapperDataContext
            {
              Connection = _connection,
              Transaction = _transaction
            };
            EFContext = new AppDbContext(_connection,_transaction);
        }
        public TRepository GetRepository<TRepository>() where TRepository : class
        {
            var type = typeof(TRepository);

            if (!_repositories.ContainsKey(type))
            {
                var repo = _repositoryFactory.Create<TRepository>();
                _repositories[type] = repo;
            }

            return (TRepository)_repositories[type];
        }
        /*
        public void BeginTransaction()
        {
            _dapperDataContext.Connection?.Open();
            _dapperDataContext.Transaction = _dapperDataContext.Connection?.BeginTransaction();
        }
        */
        
        public void Commit()
        {
            _dapperDataContext.Transaction?.Commit();
            _dapperDataContext.Transaction?.Dispose();
            _dapperDataContext.Transaction = null;
        }
        
        /*
        public void CommitAndCloseConnection()
        {
            Commit();
            _dapperDataContext.Connection?.Close();
            _dapperDataContext.Connection?.Dispose();
        }
        */
        public void CommitAndCloseConnection()
        {
            Commit(); // already disposes the transaction
            if (_connection != null)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }
        /*
        public void Rollback()
        {
            _dapperDataContext.Transaction?.Rollback();
            _dapperDataContext.Transaction?.Dispose();
            _dapperDataContext.Transaction = null;
        }
        */
        public void Rollback()
        {
            if (_dapperDataContext.Transaction != null)
            {
                _dapperDataContext.Transaction.Rollback();
                _dapperDataContext.Transaction.Dispose();
                _dapperDataContext.Transaction = null;
            }
        }

        public void Dispose()
        {
            if (_disposed) return;
            if (_dapperDataContext == null)
            {
                _transaction?.Dispose();
                _connection?.Dispose();
                _disposed = true;
                GC.SuppressFinalize(this);
                _disposed = true;
                GC.SuppressFinalize(this);
            }
            else { 
            _dapperDataContext.Transaction?.Dispose();
            _dapperDataContext.Connection?.Dispose();
            _disposed = true;
            GC.SuppressFinalize(this);
            _disposed = true;
            GC.SuppressFinalize(this);
              }
        }
    }

}






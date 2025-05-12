


namespace NewAsset.Infrastructure.Persistence.DapperContext
{

    /// <summary>
    /// A context class to manage connection and transaction for consistency
    /// </summary>
    public sealed class DapperDataContext
    {
      //  private readonly IConfiguration _configuration;
      //  private readonly string? _connectionString;
       // private IDbConnection? _connection;
       // private IDbTransaction? Transaction;
      //  private readonly MySqlConnection Connection;
        public MySqlConnection? Connection { get; set; }
        public IDbTransaction? Transaction { get; set; }
        // private readonly DbTransaction _transaction;

        /*
        public IDbConnection? Connection
        {
            get
            {
                if (_connection is null || _connection.State != ConnectionState.Open)
                    _connection = new MySqlConnection(_connectionString);
                return _connection;
            }
        }
        */
        /*
        public IDbTransaction? Transaction
        {
            get
            {
                return _transaction;
            }

            set
            {
                _transaction = value;
            }
        }
        */
    }
}



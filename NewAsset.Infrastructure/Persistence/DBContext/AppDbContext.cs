

namespace NewAsset.Infrastructure.Persistence.DBContext
{

    /// <summary>
    /// A DbContext class to manage connection and transaction for consistency
    /// between Dapper and Ef
    /// </summary>
    public class AppDbContext : DbContext
    {
        private readonly MySqlConnection _connection;
        private readonly IDbTransaction _transaction;
        private readonly string _connectionString;

        /*
        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
         : base(options)
        {
            _connectionString = configuration.GetConnectionString("dbconn");
        }
        */
        public AppDbContext(MySqlConnection connection, IDbTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_connection, ServerVersion.AutoDetect(_connection));
        }
        public DbSet<User> Users { get; set; }

        public DbSet<MutualFundSubscription> MutualFundSubscription { get; set; }
        //SimplexLiquidationServiceRequest

        public DbSet<SimplexLiquidationServiceRequest> SimplexLiquidationServiceRequest { get; set; }

        public DbSet<PaymentNotificationOutsideOfFlutterwave> paymentnotificationoutsideofflutterwaves { set; get; }
        public DbSet<ClientBank> ClientBank { get; set; }
        public DbSet<RegistrationOtpSession> RegistrationOtpSession  { get;set;}
        public DbSet<IdCard> IdCard { get; set; }
        public DbSet<Signature> Signature { get; set; }
        public DbSet<UtilityBill> UtilityBill { get; set; }
        public DbSet<AssetCustomerReasonForNotReceivngOtpatReg> AssetCustomerReasonForNotReceivngOtpatRegs { get; set; }
        public DbSet<BvnValidation> BvnValidations { get; set; }

        public DbSet<PinRequestChange> PinRequestChanges { get; set; }
        public DbSet<CustomerDataNotFromBvn> CustomerDataNotFromBvn { get; set; }

        public DbSet<TMMFDetail> TMMFDetails { get; set; }
        public DbSet<HistoricalPerformance> HistoricalPerformances { get; set; }

        public DbSet<CustomerDevice> CustomerDevice { get; set; }
        public DbSet<MobileDevice> MobileDevice { get; set; }
        public DbSet<OtpSession> OtpSession { get; set; }
        public DbSet<Registration> Registration { get; set; }
        public DbSet<RegistrationOtpSession> RegistrationOtpSessions { get; set; }
        public DbSet<RegistrationSession> RegistrationSession { get; set; }
        public DbSet<UserCredentials> UserCredentials { get; set; }

        public DbSet<UserSession> UserSession { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _connectionString;
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseMySql(
                 _connectionString,
             options => options.MigrationsAssembly("EntityProject") // Change to your actual migrations project
   );
        }
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

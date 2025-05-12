
namespace NewAsset.Infrastructure.Configuration
{

    /// <summary>
    /// Central extension class to manage all the dependency injection
    /// in the infrastructure layer
    /// </summary>
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<DapperDataContext>();
            //user
            services.AddScoped<IRepositoryFactory, RepositoryFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
           // services.AddScoped<IGenericRepository<User>>(sp => sp.GetRequiredService<UserRepository>());
            services.RegisterGenericRepository<UserRepository,User>();
            //bvnvalidation
            services.AddScoped<IBvnValidationRepository,BvnValidationRepository>();
            // services.AddScoped<IGenericRepository<BvnValidation>>(sp => sp.GetRequiredService<BvnValidationRepository>());
            services.RegisterGenericRepository<IBvnValidationRepository,BvnValidation>();
            //clientbank
            services.AddScoped<IClientBankRepository,ClientBankRepository>();
            services.RegisterGenericRepository<IClientBankRepository,ClientBank>();
            //customerdatanotfrombvn
            services.AddScoped<ICustomerDataNotFromBvnRepository,CustomerDataNotFromBvnRepository>();
            services.RegisterGenericRepository<ICustomerDataNotFromBvnRepository,CustomerDataNotFromBvn>();
            //customerdevice
            services.AddScoped<ICustomerDeviceRepository,CustomerDeviceRepository>();
            services.RegisterGenericRepository<ICustomerDeviceRepository,CustomerDevice>();
            //historicalperformance
            services.AddScoped<IHistoricalPerformance,HistoricalPerformanceRepository>();
            //idcard
            services.AddScoped<IIdCardRepository,IdCardRepository>();
            services.RegisterGenericRepository<IIdCardRepository,IdCard>();
            //mobiledevice
            services.AddScoped<IMobileDeviceRepository,MobileDeviceRepository>();
            services.RegisterGenericRepository<IMobileDeviceRepository,MobileDevice>();
            //mutualfund
            services.AddScoped<IMutualFundSubscriptionRepository,MutualFundSubscriptionRepository>();
            services.RegisterGenericRepository<IMutualFundSubscriptionRepository,MutualFundSubscription>();
            //otpsession
            services.AddScoped<IOtpSessionRepository,OtpSessionRepository>();
            services.RegisterGenericRepository<IOtpSessionRepository,OtpSession>();
            //paymentoutsideofflutterwave
            services.AddScoped<IPaymentOutsideOfFlutterwave,PaymentOutsideOfFlutterwaveRepository>();
            return services;
        }
        private static IServiceCollection RegisterGenericRepository<TRepo, TEntity>(this IServiceCollection services)
         where TRepo : class, IGenericRepository<TEntity>
         where TEntity : class, IDbEntity
        {
            services.AddScoped<TRepo>();
            services.AddScoped<IGenericRepository<TEntity>>(sp => sp.GetRequiredService<TRepo>());
            return services;
        }

    }
}




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
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Core business services
            services.AddSingleton<ICoreBankingService,CoreBankingService>();
            services.AddSingleton<IBackOfficeCustomerChecker,BackOfficeCustomerChecker>();
            services.AddSingleton<IEmailNotificationService,EmailNotificationService>();
            services.AddSingleton<IHttpService,HttpService>();
            services.AddSingleton<INinValidationService,NinValidationService>();
            services.AddSingleton<IOtpNotificationService,OtpNotificationService>();
            services.AddSingleton<ITemplateService,TemplateService>();
            services.AddSingleton<IAssetCapitlInsuranceRegistrationService, AssetCapitlInsuranceRegistrationService>();

            return services;
        }
        public static IServiceCollection AddCachingServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMemoryCache();

            var appSettings = configuration.GetSection("AppSettingConfig").Get<AppSettings>();
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = appSettings.RedisIPAndPassword;
                options.InstanceName = appSettings.RedisInstanceName;
            });

            return services;
        }
        public static IServiceCollection AddSessionServices(this IServiceCollection services)
        {
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            return services;
        }
        /*
        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Asset Management API", Version = "v1" });
                c.SchemaFilter<SwaggerIgnoreFilter>();
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            return services;
        }
        */
        public static IServiceCollection AddConfigurationOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration.GetSection("AppSettingConfig"));
            services.Configure<AssetSimplexConfig>(configuration.GetSection("AssetSimplexConfig"));
            services.Configure<FolderPaths>(configuration.GetSection("FolderPaths"));
            services.Configure<OtpMessage>(configuration.GetSection("OtpMessages"));
            services.Configure<SmtpDetails>(configuration.GetSection("SMTPDetails"));

            return services;
        }
    }
}

using WebTeamHost.App.Interfaces.Repositories;
using WebTeamHost.Persistance.Contexts;
using WebTeamHost.Persistance.Repositories;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using WebTeamHost.Domain.Entities;

namespace WebTeamHost.Persistance.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddMappings();
            services.AddDbContext(configuration);
            services.AddIdentityAuth();
            services.AddRepositories();
        }

        //private static void AddMappings(this IServiceCollection services)
        //{
        //    services.AddAutoMapper(Assembly.GetExecutingAssembly());
        //}

        public static void AddIdentityAuth(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores <ApplicationDbContext>()
                .AddDefaultTokenProviders();
        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("PostgreSQLConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(
                    connectionString, 
                    builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                );
                //options.UseSqlServer(connectionString));
               //options.UseSqlServer(connectionString,
               //    builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services
                .AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
                .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddTransient<IGameRepository, GameRepository>()
                .AddTransient<ICategoryRepository, CategoryRepository>()
                .AddTransient<IDeveloperRepository, DeveloperRepository>()
                .AddTransient<IMediaFilesRepository, MediaFilesRepository>()
                .AddTransient<ICountryRepository, CountryRepository>()
                .AddTransient<IPlatformRepository, PlatformRepository>()
                .AddTransient<ICompanyRepository, CompanyRepository>()
                .AddTransient<IStaticFileRepository, StaticFileRepository>()
                .AddTransient<IUserInfoRepository, UserInfoRepository>()
                .AddTransient<IGroupRepository, GroupRepository>()
                .AddTransient<IMessageRepository, MessageRepository>()
                .AddTransient<IUserGroupRepository, UserGroupRepository>();
        }
    }
}

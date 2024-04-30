//using WebTeamHost.Application.Interfaces.Repositories;
//using WebTeamHost.Persistance.Contexts;
//using WebTeamHost.Persistance.Repositories;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using WebTeamHost.Identity.Contexts;
using WebTeamHost.Domain.Entities;

namespace WebTeamHost.Persistance.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddIdentityLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext(configuration);
            services.AddIdentityAuth();
            //services.AddIdentity<User, IdentityRole>();
            //services.AddMappings();
            //services.AddRepositories();
        }

        public static void AddIdentityAuth(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();
        }

        //public static void AddInfrastructureIdentityServices(this IServiceCollection services)
        //{
        //    services.AddScoped<IAuthService, AuthService>();
        //    services.AddScoped<IUserService, UserService>();
        //}

        //public static void AddInfrastructureIdentityMappingProfile(this IServiceCollection services)
        //{
        //    MapperConfiguration mappingConfig = new(mc =>
        //    {
        //        mc.AddProfile(new InfrastructureIdentityProfile());
        //    });

        //    services.AddSingleton(mappingConfig.CreateMapper());
        //}

        private static void AddMappings(this IServiceCollection services)
        {
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("PostgreSQLConnection");

            //services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseNpgsql(
                    connectionString,
                    b => b.MigrationsAssembly(typeof(AppIdentityDbContext).Assembly.FullName))
                );
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            //services
            //    .AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
            //    .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
            //    .AddTransient<IGameRepository, GameRepository>()
            //    .AddTransient<ICategoryRepository, CategoryRepository>()
            //    .AddTransient<IDeveloperRepository, DeveloperRepository>()
            //    .AddTransient<IMediaFilesRepository, MediaFilesRepository>()
            //    .AddTransient<ICountryRepository, CountryRepository>()
            //    .AddTransient<IPlatformRepository, PlatformRepository>()
            //    .AddTransient<ICompanyRepository, CompanyRepository>()
            //    .AddTransient<IStaticFileRepository, StaticFileRepository>();
        }
    }
}
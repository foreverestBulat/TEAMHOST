using WebTeamHost.Domain.Common;
using WebTeamHost.Domain.Common.Interfaces;
using WebTeamHost.Domain.Entities;

using Microsoft.EntityFrameworkCore;

using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebTeamHost.Persistance.Contexts
{
    public class ApplicationDbContext : IdentityDbContext//DbContext
    {
        private readonly IDomainEventDispatcher _dispatcher;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDomainEventDispatcher dispatcher)
            : base(options)
        {
            _dispatcher = dispatcher;
        }

        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDomainEventDispatcher dispatcher)
        //: base(options)
        //{
        //    _dispatcher = dispatcher;
        //}

        public DbSet<User> Users => Set<User>();
        public DbSet<Game> Games => Set<Game>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Developer> Developers => Set<Developer>();
        public DbSet<Country> Countries => Set<Country>();
        public DbSet<MediaFiles> ListMediaFiles => Set<MediaFiles>();
        public DbSet<Company> Companies => Set<Company>();
        public DbSet<Platform> Platforms => Set<Platform>();
        public DbSet<StaticFile> StaticFiles => Set<StaticFile>();
        public DbSet<UserInfo> UsersInfo => Set<UserInfo>();
        public DbSet<Message> Messages => Set<Message>();
        public DbSet<Group> Groups => Set<Group>();
        public DbSet<UserGroup> UserGroups => Set<UserGroup>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.Entity<UserInfo>(entity =>
            //{
            //    //entity.HasOne(u => u.UserInfo)
            //    //.WithOne();
            //     entity.HasIndex(e => e.UserId).IsUnique(true);

            //});

            modelBuilder.Entity<User>()
                .HasOne(u => u.UserInfo)
                .WithOne(u => u.User)
                .HasForeignKey<UserInfo>(u => u.UserId);

            //modelBuilder.Entity<User>()
            //    .HasIndex(x => x.UserInfoId).IsUnique(true);
            //.HasOne(x => x.UserInfo)
            //.WithOne();

            modelBuilder.Entity<UserGroup>()
                .HasIndex(x => x.UserId)
                .IsUnique(false);

            //modelBuilder.Entity<Group>()
            //    .HasIndex(x => x.User.)
            //    .IsUnique(false);

            modelBuilder.Entity<Group>()
                .HasIndex(x => x.UserId)
                .IsUnique(false);

            modelBuilder.Entity<Message>()
                .HasIndex(x => x.UserId)
                .IsUnique(false);
            //modelBuilder.Entity<UserGroup>(entity =>
            //{
            //    entity.HasKey(x => x.UserId1);
            //    entity
            //});



        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // ignore events if no dispatcher provided
            if (_dispatcher == null) return result;

            // dispatch events only if save was successful
            var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(e => e.Entity)
                .Where(e => e.DomainEvents.Any())
                .ToArray();

            await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

            return result;
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}
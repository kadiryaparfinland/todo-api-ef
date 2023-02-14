using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using ToDo.Domain.DBModel;
using ToDo.Domain.Enum;
using ToDo.Domain.IEntity;

namespace ToDo.Infrastructure.DBContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, UserRole, int>
    {
        private ICurrentUser _currentUser;
        //private IUserContext _serContext;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICurrentUser currentUser) : base(options)
        {
            _currentUser = currentUser;
        }


        public DbSet<ApplicationUser> Users { get; set; }

        public DbSet<TODO> ToDo { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.EnableSensitiveDataLogging()
            //    .LogTo(Console.WriteLine);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            foreach (var item in ChangeTracker.Entries<IAuditable>())
            {
                switch (item.State)
                {
                    case EntityState.Added:
                        item.Entity.DateCreated = DateTime.Now;
                        item.Entity.CreatedBy = item.Entity.CreatedBy != 0 ? item.Entity.CreatedBy : _currentUser.User.Id;
                        break;
                    case EntityState.Modified:
                        item.Entity.LastUpdated = DateTime.Now;
                        item.Entity.UpdatedBy = item.Entity.UpdatedBy != null ? item.Entity.UpdatedBy : _currentUser.User.Id;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using final_project.Data.Entities;
using RestaurantReservationSystem.Settings;
using System.Linq.Expressions;
using final_project.Shared;

namespace final_project.Data.Data
{
    public class AppDbContext : IdentityDbContext<AppUser, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<RestaurantFeature> RestaurantFeatures { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Customer>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<RestaurantFeature>()
                .HasKey(rf => new { rf.RestaurantId, rf.FeatureId });

            modelBuilder.Entity<RestaurantFeature>()
                .HasOne(rf => rf.Restaurant)
                .WithMany(r => r.RestaurantFeatures)
                .HasForeignKey(rf => rf.RestaurantId);

            modelBuilder.Entity<RestaurantFeature>()
                .HasOne(rf => rf.Feature)
                .WithMany(f => f.RestaurantFeatures)
                .HasForeignKey(rf => rf.FeatureId);




            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .HasQueryFilter(
                            BuildIsDeletedRestriction(entityType.ClrType)
                        );
                }
            }

        }

        private static LambdaExpression BuildIsDeletedRestriction(Type entityType)
        {
            var parameter = Expression.Parameter(entityType, "e");
            var prop = Expression.Property(parameter, nameof(BaseEntity.IsDeleted));
            var condition = Expression.Equal(prop, Expression.Constant(false));
            return Expression.Lambda(condition, parameter);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedDate = DateTime.UtcNow;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.ModifiedDate = DateTime.UtcNow;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}

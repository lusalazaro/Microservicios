using Microsoft.EntityFrameworkCore;
using Users.Api.Models;

namespace Users.Api.Data
{
    public class ApiDbContext(DbContextOptions<ApiDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder =>
            {
                builder.HasKey(u => u.Id);
                builder.HasOne(u => u.Profile)
                    .WithMany(p => p.Users)
                    .HasForeignKey(u => u.ProfileId);
            });

            modelBuilder.Entity<Profile>()
                .HasKey(p => p.Id);
        }
    }
}

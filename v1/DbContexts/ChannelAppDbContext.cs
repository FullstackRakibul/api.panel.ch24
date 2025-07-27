using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using v1.DbContexts.AuthModels;
using v1.DbContexts.Models;


namespace v1.DbContexts
{
    public class ChannelAppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ChannelAppDbContext(DbContextOptions<ChannelAppDbContext> options)
            : base(options)
        {

        }

        public DbSet<PublicData> PublicData { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<ApplicationRole> ApplicationRole { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .HasIndex(u => u.EmployeeId)
                .IsUnique();
        }


    }
}

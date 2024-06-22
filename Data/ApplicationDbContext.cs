using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using LMS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace LMS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<ApplicationUser>()
                .Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(100);


            builder.Entity<ApplicationUser>()
                .Property(e => e.MiddleName)
                .HasMaxLength(100);

            builder.Entity<ApplicationUser>()
                .Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Entity<ApplicationUser>()
                .Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(100);


            builder.Entity<ApplicationUser>()
                .Property(e => e.ProfileUrl)

                .HasMaxLength(500);


            builder.Entity<ApplicationUser>()
                .Property(e => e.IsActive)
                .HasDefaultValue(true);

            builder.Entity<ApplicationUser>()
                .Property(e => e.CreatedDate)
                .HasDefaultValueSql("GETDATE()");


            builder.Entity<IdentityRole>()
                .ToTable("Roles")
                .Property(p => p.Id)
                .HasColumnName("RoleId");
        }
    }
}


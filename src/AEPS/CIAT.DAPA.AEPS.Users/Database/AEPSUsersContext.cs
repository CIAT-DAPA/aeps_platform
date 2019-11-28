using CIAT.DAPA.AEPS.Users.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CIAT.DAPA.AEPS.Users.Database
{
    public class AEPSUsersContext : IdentityDbContext<ApplicationUser>
    {
        public AEPSUsersContext(DbContextOptions<AEPSUsersContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            // Shorten key length for Identity
            builder.Entity<ApplicationUser>(entity => {
                entity.Property(m => m.Id).HasMaxLength(127);
                entity.Property(m => m.EmailConfirmed).HasConversion<int>();
                entity.Property(m => m.LockoutEnabled).HasConversion<int>();
                entity.Property(m => m.PhoneNumberConfirmed).HasConversion<int>();
                entity.Property(m => m.TwoFactorEnabled).HasConversion<int>();
            });
            builder.Entity<IdentityRole>(entity => entity.Property(m => m.Id).HasMaxLength(127));
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.Property(m => m.LoginProvider).HasMaxLength(127);
                entity.Property(m => m.ProviderKey).HasMaxLength(127);
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.Property(m => m.UserId).HasMaxLength(127);
                entity.Property(m => m.RoleId).HasMaxLength(127);
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.Property(m => m.UserId).HasMaxLength(127);
                entity.Property(m => m.LoginProvider).HasMaxLength(127);
                entity.Property(m => m.Name).HasMaxLength(127);

            });
        }
    }
}

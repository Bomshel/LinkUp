using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Models
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = SeedConstant.AdminRoleId,
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole
                {
                    Id = SeedConstant.BloggerRoleId,
                    Name = "Blogger",
                    NormalizedName = "BLOGGER"
                },
                
                new IdentityRole
                {
                    Id = SeedConstant.SurferRoleId,
                    Name = "Surfer",
                    NormalizedName = "SURFER"
                }
            );
        }
    }

    public class AdminConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var admin = new ApplicationUser
            {
                Id = SeedConstant.AdminId,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                PhoneNumber = null,
                EmailConfirmed = true,
                PhoneNumberConfirmed = false,
                SecurityStamp = "AZFIVUH5E33SOS2YOJ6I6BNNDWXAOSYW",
                PasswordHash = "AQAAAAEAACcQAAAAEAdVIu+ItQE9Omh+YQ0kbXQZnUVWRFWrZ+l8qYsrCSane1XgbGd3J0B9R1+xT48BqQ==",
                AccessFailedCount = 0,
                ConcurrencyStamp = "707bbcdc-340d-4d1a-851c-4bdd201954d5",
                LockoutEnabled = false,
                LockoutEnd = null,
                TwoFactorEnabled = false,
                Discriminator = "Admin"
                
            };
            builder.Property(u => u.Discriminator).HasMaxLength(256);
            builder.HasData(admin);
        }
    }

    public class UsersWithRolesConfig : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            IdentityUserRole<string> iur = new IdentityUserRole<string>
            {
                RoleId = SeedConstant.AdminRoleId,
                UserId = SeedConstant.AdminId
            };

            builder.HasData(iur);
        }
    }
}

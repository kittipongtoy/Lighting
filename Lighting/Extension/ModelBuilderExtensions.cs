using Lighting.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Lighting.Extension
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            var pwd = "1234";
            var passwordHasher = new PasswordHasher<LightingUser>();

            List<Role> roles = new List<Role>()
            {
                new Role
                {
                    Name = "Admin",
                    NameThai = "Admin",
                    NormalizedName = "Admin",
                    created_at = DateTime.UtcNow,
                    updated_at = DateTime.UtcNow
                }
            };

            builder.Entity<Role>().HasData(roles);

            var user = new LightingUser
            {
                UserName = "Admin@Lighting.com",
                Email = "Admin@Lighting.com",
                EmailConfirmed = false,
                Firstname = "Admin",
                Lastname = "Admin",
            };
            user.EmployeeCode = "Admin";
            user.EmployeeCodeInt = 1;
            user.NormalizedUserName = user.UserName.ToLower();
            user.NormalizedEmail = "";
            user.PasswordHash = passwordHasher.HashPassword(user, pwd);
            builder.Entity<LightingUser>().HasData(user);

            List<LightingUser> LightingUser = new List<LightingUser>() {
                user
            };

            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();
            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = LightingUser[0].Id,
                RoleId = roles.First(q => q.Name == "Admin").Id
            });
            builder.Entity<IdentityUserRole<string>>().HasData(userRoles);

            // add Download type 
            List<DownloadTypes> downloadTypes = new List<DownloadTypes>()
            {
                new DownloadTypes
                {
                    DownloadType_name_ENG = "L&E BIM OBJECTS",
                    DownloadType_name_TH = "L&E BIM OBJECTS",
                    id=1,
                    created_at = DateTime.UtcNow,
                    updated_at = DateTime.UtcNow, 
                },

                new DownloadTypes
                {
                    DownloadType_name_ENG = "CATALOGUE",
                    DownloadType_name_TH = "CATALOGUE",
                    id=2,
                    created_at = DateTime.UtcNow,
                    updated_at = DateTime.UtcNow,
                },

                new DownloadTypes
                {
                    DownloadType_name_ENG = "COMPANY PROFILE",
                    DownloadType_name_TH = "COMPANY PROFILE",
                    id=3,
                    created_at = DateTime.UtcNow,
                    updated_at = DateTime.UtcNow,
                },

                new DownloadTypes
                {
                    DownloadType_name_ENG = "IES FILE",
                    DownloadType_name_TH = "IES FILE",
                    id=4,
                    created_at = DateTime.UtcNow,
                    updated_at = DateTime.UtcNow,
                },

                new DownloadTypes
                {
                    DownloadType_name_ENG = "LEAFLET",
                    DownloadType_name_TH = "LEAFLET",
                    id=5,
                    created_at = DateTime.UtcNow,
                    updated_at = DateTime.UtcNow,
                }

            };
             
            builder.Entity<DownloadTypes>().HasData(downloadTypes);
        }
    }
}

﻿using SkillSeek.Domain.Constants;
using SkillSeek.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace SkillSeek.Infrastructure.Persistence.Seed;

public class DbInitializer(ApplicationDbContext dbContext, RoleManager<Role> roleManager, UserManager<User> userManager)
    : IDbInitializer
{
    public async Task Initialize()
    {
        try
        {
            if (!roleManager.RoleExistsAsync(Constants.Roles.Admin).GetAwaiter().GetResult())
            {
                roleManager.CreateAsync(new Role(Constants.Roles.Admin)).GetAwaiter().GetResult();
            }
            
            if (!roleManager.RoleExistsAsync(Constants.Roles.Professional).GetAwaiter().GetResult())
            {
                roleManager.CreateAsync(new Role(Constants.Roles.Professional)).GetAwaiter().GetResult();
            }
            
            if (!roleManager.RoleExistsAsync(Constants.Roles.Customer).GetAwaiter().GetResult())
            {
                roleManager.CreateAsync(new Role(Constants.Roles.Customer)).GetAwaiter().GetResult();
            }

            if (!dbContext.Users.Any())
            {
                var superAdminUser = new User
                {
                    Name = "Super Admin",
                    Email = "superadmin@superadmin.com",
                    NormalizedEmail = "superadmin@superadmin.com".ToUpper(),
                    UserName = "superadmin@superadmin.com",
                    NormalizedUserName = "superadmin@superadmin.com".ToUpper(),
                    Address = "Harold Street",
                    State = "State Somewhere",
                    PhoneNumber = "9800000000",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };

                userManager.CreateAsync(superAdminUser, Constants.Passwords.Password).GetAwaiter().GetResult();
                userManager.AddToRoleAsync(superAdminUser, Constants.Roles.Admin).GetAwaiter().GetResult();
                
                await dbContext.SaveChangesAsync();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
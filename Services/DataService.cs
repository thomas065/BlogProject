using BlogProject.Data;
using BlogProject.Enums;
using BlogProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Services
{
    public class DataService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<BlogUser> _userManager;

        public DataService(ApplicationDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<BlogUser> userManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task ManageDataAsync()
        {
            //Task 3: Create the database from the migrations
            await _dbContext.Database.MigrateAsync();

            //Task 1: Seeding a few Roles into the system
            await SeedRolesAsync();

            //Task 2: (Seed) Programmatically add user's into the system
            await SeedUsersAsync();
        }

        private async Task SeedRolesAsync()
        {
            //If there are already roles in the system, do nothing.
            if (_dbContext.Roles.Any())
            {
                return;
            }

            //Otherwise, we want to create a few roles.
            foreach (var role in Enum.GetNames(typeof(BlogRole)))
            {
                //I need to use the role manager to create roles
                await _roleManager.CreateAsync(new IdentityRole(role));
            }

        }

        private async Task SeedUsersAsync()
        {
            //If there are already users in the system, do nothing.
            if (_dbContext.Users.Any())
            {
                return;
            }

            //Step 1: Creates a new instance of BlogUser
            var adminUser = new BlogUser()
            {
                Email = "thomasjbell065@mailinator.com",
                UserName = "thomasjbell065@mailinator.com",
                FirstName = "Thomas",
                LastName = "Bell",
                PhoneNumber = "(800) 555-1212",
                EmailConfirmed = true
            };

            //Step 2: Use the UserManager to create a new user that is defined by the adminUser variable
            await _userManager.CreateAsync(adminUser, "Abc123!");

            //Step 3: Add this new USer to the Administrator role
            await _userManager.AddToRoleAsync(adminUser, BlogRole.Administrator.ToString());

            //Step 4 Create Moderator user
            var modUser = new BlogUser()
            {
                Email = "davidbanner@mailinator.com",
                UserName = "davidbanner@mailinator.com",
                FirstName = "David",
                LastName = "Banner",
                PhoneNumber = "(800) 555-1213",
                EmailConfirmed = true
            };

            await _userManager.CreateAsync(modUser, "Abc123!");
            await _userManager.AddToRoleAsync(modUser, BlogRole.Moderator.ToString());
        }









    }
}

using Dynamic.Domain.Entities;
using Dynamic.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Dynamic.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager)
        {
            var defaultUser = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

            if (userManager.Users.All(u => u.UserName != defaultUser.UserName))
            {
                await userManager.CreateAsync(defaultUser, "Administrator1!");
            }
        }

        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            // Seed, if necessary
            if (!context.TodoLists.Any())
            {
                context.TodoLists.Add(new TodoList
                {
                    Title = "Shopping",
                    Items =
                    {
                        new TodoItem { Title = "Apples", Done = true },
                        new TodoItem { Title = "Milk", Done = true },
                        new TodoItem { Title = "Bread", Done = true },
                        new TodoItem { Title = "Toilet paper" },
                        new TodoItem { Title = "Pasta" },
                        new TodoItem { Title = "Tissues" },
                        new TodoItem { Title = "Tuna" },
                        new TodoItem { Title = "Water" }
                    }
                });

            }
            if (!context.Events.Any()){
                context.Events.Add(new Event 
                {
                    Name = "State of Origin",
                    TimeStart = DateTime.Today,
                    Capacity = 50000,
                    LocationStart = "Suncorp Stadium",
                });

                context.Events.Add(new Event 
                {
                    Name = "Boat Cruise",
                    TimeStart = DateTime.Parse("5/1/2021 8:30:52 AM"),
                    Capacity = 100,
                    LocationStart = "Big Boat",
                });

                context.Events.Add(new Event 
                {
                    Name = "Catalina Wine Mixer",
                    TimeStart = DateTime.Parse("10/10/2020 8:30:52 AM"),
                    Capacity = 50,
                    LocationStart = "Napa Valley",
                });
            }
            await context.SaveChangesAsync();
        }
    }
}

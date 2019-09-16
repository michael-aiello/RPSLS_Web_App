using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace RPSLS_Web_App.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new RPSLS_Web_AppContext(
                serviceProvider.GetRequiredService<DbContextOptions<RPSLS_Web_AppContext>>()))
            {
                // look for players
                if(context.Player.Any())
                {
                    return;
                }
                // using random name generator to get seed names
                context.Player.AddRange(
                    new Player
                    {
                        Wins = 0,
                        Losses = 0,
                        Draws = 0,
                        Name = "Sheldon",
                        CreatedOn = DateTime.Now,
                        UpdatedOn = DateTime.Now
                    },

                    new Player
                    {
                        Wins = 0,
                        Losses = 0,
                        Draws = 0,
                        Name = "Kathy",
                        CreatedOn = DateTime.Now,
                        UpdatedOn = DateTime.Now
                    },

                    new Player
                    {
                        Wins = 0,
                        Losses = 0,
                        Draws = 0,
                        Name = "Mya",
                        CreatedOn = DateTime.Now,
                        UpdatedOn = DateTime.Now
                    },

                    new Player
                    {
                        Wins = 0,
                        Losses = 0,
                        Draws = 0,
                        Name = "Roy",
                        CreatedOn = DateTime.Now,
                        UpdatedOn = DateTime.Now
                    },

                    new Player
                    {
                        Wins = 0,
                        Losses = 0,
                        Draws = 0,
                        Name = "Mathew",
                        CreatedOn = DateTime.Now,
                        UpdatedOn = DateTime.Now
                    },

                    new Player
                    {
                        Wins = 0,
                        Losses = 0,
                        Draws = 0,
                        Name = "Floyd",
                        CreatedOn = DateTime.Now,
                        UpdatedOn = DateTime.Now
                    },

                    new Player
                    {
                        Wins = 0,
                        Losses = 0,
                        Draws = 0,
                        Name = "Alexandra ",
                        CreatedOn = DateTime.Now,
                        UpdatedOn = DateTime.Now
                    },

                    new Player
                    {
                        Wins = 0,
                        Losses = 0,
                        Draws = 0,
                        Name = "Lorenzo",
                        CreatedOn = DateTime.Now,
                        UpdatedOn = DateTime.Now
                    },

                    new Player
                    {
                        Wins = 0,
                        Losses = 0,
                        Draws = 0,
                        Name = "Frederick",
                        CreatedOn = DateTime.Now,
                        UpdatedOn = DateTime.Now
                    },

                    new Player
                    {
                        Wins = 0,
                        Losses = 0,
                        Draws = 0,
                        Name = "Connie",
                        CreatedOn = DateTime.Now,
                        UpdatedOn = DateTime.Now
                    }

                    );
                context.SaveChanges();
            }
        }
    }
}

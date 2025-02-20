using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcShawl.Data;
using System;
using System.Linq;

namespace MvcShawl.Models;

    public static class seedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new MvcShawlContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcShawlContext>>()))

            {

                if (context.Shawl.Any())
                {
                    return;
                }
                    context.Shawl.AddRange(
                        new Shawl
                        {
                            Id = "1",
                            Name = "Fluffy Shawl",
                            Material = "Wool",
                            Colour = "White",
                            Price = "49.99",
                            Description = "A warm and cozy woolen shawl for winter."
                        },

                        new Shawl
                        {
                            Id = "2",
                            Name = "Fancy Shawl",
                            Material = "Silk",
                            Colour = "Red",
                            Price = "49.99",
                            Description = "A super fancy red silk shawl!"
                        },
                        new Shawl
                        {
                            Id = "3",
                            Name = "Classy Shawl",
                            Material = "Cashmere",
                            Colour = "Red",
                            Price = "49.99",
                            Description = "The classiest shawl we have by far."
                        },
                        new Shawl
                        {
                            Id = "4",
                            Name = "Normal, Unremarkable Shawl",
                            Material = "Polyester",
                            Colour = "beige",
                            Price = "5.99",
                            Description = "its ok I guess"
                        },
                        new Shawl
                        {
                            Id = "5",
                            Name = "Big Shawl",
                            Material = "Cotton",
                            Colour = "Green",
                            Price = "499.99",
                            Description = "please buy this it takes up a lot of inventory space"
                        }
                    );
                    context.SaveChanges();
                }
            }
        }


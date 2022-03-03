using API.Entities;
using Microsoft.AspNetCore.Identity;

namespace API.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(StoreContext context, UserManager<User> userManager)
        {
            if(!userManager.Users.Any())
            {
                var user = new User{
                    UserName= "bob",
                    Email= "bob@test.com"
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
                await userManager.AddToRoleAsync(user, "Member");

                var admin = new User{
                    UserName= "admin",
                    Email= "admin@test.com"
                };

                await userManager.CreateAsync(admin, "Pa$$w0rd");
                await userManager.AddToRolesAsync(admin, new[] {"Member", "Admin"});

            }

            if (context.Products.Any()) return;

            var products = new List<Product>{
                new Product{
                    Name="Black Robe",
                    Description="lovely summer robe for pretty ladies",
                    Price=30,
                    PictureUrl="/images/products/boot-ang1.png",
                    Type ="Robe",
                    Brand = "H&M",
                    QuantityInStock=100
                },
                new Product{
                    Name="Red Robe",
                    Description="lovely summer robe for pretty ladies",
                    Price=3500,
                    PictureUrl="/images/products/boot-core2.png",
                    Type ="Robe",
                    Brand = "Mongo",
                    QuantityInStock=100
                },
                new Product{
                    Name="Blue Robe",
                    Description="lovely summer robe for pretty ladies",
                    Price=1000,
                    PictureUrl="/images/products/boot-redis1.png",
                    Type ="Dress",
                    Brand = "Zara",
                    QuantityInStock=100
                },
                new Product{
                    Name="Green Robe",
                    Description="lovely summer robe for pretty ladies",
                    Price=4900,
                    PictureUrl="/images/products/glove-code2.png",
                    Type ="Robe",
                    Brand = "Gucci",
                    QuantityInStock=100
                },
                new Product{
                    Name="Pink Robe",
                    Description="lovely summer robe for pretty ladies",
                    Price=7000,
                    PictureUrl="/images/products/hat-core1.png",
                    Type ="Dress",
                    Brand = "Zara",
                    QuantityInStock=100
                },
                new Product{
                    Name="Khaki Caftan",
                    Description="lovely summer robe for pretty ladies",
                    Price=9300,
                    PictureUrl="/images/products/hat-core1.png",
                    Type ="Caftan",
                    Brand = "Diamand",
                    QuantityInStock=100
                }
            };

            foreach (var product in products)
            {
                context.Products.Add(product);
            }

            context.SaveChanges();
        }
    }
}
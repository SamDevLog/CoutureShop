using API.Entities;

namespace API.Data
{
    public static class DbInitializer
    {
        public static void Initialize(StoreContext context){
            if(context.Products.Any()) return;

            var products = new List<Product>{
                new Product{
                    Name="Black Robe",
                    Description="lovely summer robe for pretty ladies",
                    Price=30,
                    PictureUrl="kqsjdhqklsjdhqslk",
                    ProductType="Robe",
                    QuantityInStock=100
                },new Product{
                    Name="Red Robe",
                    Description="lovely summer robe for pretty ladies",
                    Price=30,
                    PictureUrl="kqsjdhqklsjdhqslk",
                    ProductType="Robe",
                    QuantityInStock=100
                },new Product{
                    Name="Blue Robe",
                    Description="lovely summer robe for pretty ladies",
                    Price=30,
                    PictureUrl="kqsjdhqklsjdhqslk",
                    ProductType="Dress",
                    QuantityInStock=100
                },new Product{
                    Name="Green Robe",
                    Description="lovely summer robe for pretty ladies",
                    Price=30,
                    PictureUrl="kqsjdhqklsjdhqslk",
                    ProductType="Robe",
                    QuantityInStock=100
                },new Product{
                    Name="Pink Robe",
                    Description="lovely summer robe for pretty ladies",
                    Price=30,
                    PictureUrl="kqsjdhqklsjdhqslk",
                    ProductType="Dress",
                    QuantityInStock=100
                },
            };

            foreach (var product in products)
            {
                context.Products.Add(product);
            }

            context.SaveChanges();
        }
    }
}
using CWRetail.Model;
using Microsoft.EntityFrameworkCore;

namespace CWRetail.Provider
{
    public class ProductProvider
    {
        public static Product CreateProduct(string name, double price, string type, bool active)
        {
            return new Product
            {
                Name = name,
                Price = price,
                Type = type,
                Active = active
            };
        }
        public static void GetUpdatedProduct(Product product, string name, double price, string type, bool active)
        {
            product.Name = name;
            product.Price = price;
            product.Type = type;
            product.Active = active;
        }

        public static Product? GetDeleteProduct(Product[] products, int id)
        {
            return products.SingleOrDefault(x => x.Id == id);
        }

        public static Product[] CreateDefaultData()
        {
            var res = new List<Product>();
            res.Add(new Product { Name = "JHSS", Price = 14.5, Type = "Books", Active = true });
            res.Add(new Product { Name = "SDFGA", Price = 15.5, Type = "Food", Active = true });
            res.Add(new Product { Name = "JHSS", Price = 17.5, Type = "Electronics", Active = true });
            res.Add(new Product { Name = "GAAYR", Price = 121.5, Type = "Toys", Active = true });
            res.Add(new Product { Name = "UJEWT", Price = 12.5, Type = "Electronics", Active = true });
            res.Add(new Product { Name = "JETSRT", Price = 155.5, Type = "Furniture", Active = true });
            res.Add(new Product { Name = "ARWER", Price = 12.5, Type = "Electronics", Active = true });
            res.Add(new Product { Name = "HWRTEGHE", Price = 177.5, Type = "Books", Active = true });
            res.Add(new Product { Name = "QGRETG", Price = 12.5, Type = "Books", Active = true });
            res.Add(new Product { Name = "HERT6", Price = 12.5, Type = "Electronics", Active = true });
            res.Add(new Product { Name = "HGWRT", Price = 14.5, Type = "Food", Active = true });
            res.Add(new Product { Name = "QRYE5", Price = 13.5, Type = "Books", Active = true });
            res.Add(new Product { Name = "OT789O7", Price = 166.5, Type = "Electronics", Active = true });
            res.Add(new Product { Name = "AERGER", Price = 1246.5, Type = "Food", Active = true });
            res.Add(new Product { Name = "JETDRT", Price = 163.5, Type = "Toys", Active = true });
            res.Add(new Product { Name = "HWBERTGH", Price = 1255.5, Type = "Electronics", Active = true });
            res.Add(new Product { Name = "TWTHR", Price = 17.5, Type = "Furniture", Active = true });
            res.Add(new Product { Name = "KJUYR", Price = 14.5, Type = "Electronics", Active = true });
            res.Add(new Product { Name = "ARGR", Price = 123.5, Type = "Books", Active = true });
            res.Add(new Product { Name = "K87U", Price = 122.5, Type = "Toys", Active = true });
            res.Add(new Product { Name = "758RJIK8", Price = 127.5, Type = "Electronics", Active = true });
            res.Add(new Product { Name = "RTYHWE", Price = 132.5, Type = "Books", Active = true });
            res.Add(new Product { Name = "45HYG4WE", Price = 312.5, Type = "Electronics", Active = true });
            res.Add(new Product { Name = "JKR6T7YJH", Price = 152.5, Type = "Furniture", Active = true });
            res.Add(new Product { Name = "WSRTHG", Price = 128.5, Type = "Books", Active = true });
            return res.ToArray();
        }
    }
}

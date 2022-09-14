using CWRetail.Model;
using Microsoft.EntityFrameworkCore;

namespace CWRetail.Provider
{
    public class ProductProvider
    {
        public static Product CreateProduct(string name, double price, string type, bool active)
        {
            return  new Product
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
    }
}

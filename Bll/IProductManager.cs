using System.Collections.Generic;
using Dal;

namespace Bll
{
    public interface IProductManager
    {
        int AddProduct(Product p);
        void DeleteProduct(Product p);
        List<Product> GetAllProducts();
        Product GetProductById(int productId);
        List<Product> GetProductsInPriceRange(decimal minPrice, decimal maxPrice);
        List<Product> GetSpecialPriceProducts();
        void UpdateProduct(Product p);
    }
}
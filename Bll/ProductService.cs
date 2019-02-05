using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;

namespace Bll
{
    public class ProductService : IProductService
    {       
        private readonly IUnitOfWork unitOfWork;
        private readonly IClock clock;

        public ProductService(IUnitOfWork unitOfWork, IClock clock)
        {
            this.unitOfWork = unitOfWork;
            this.clock = clock;
        }
        public List<Product> GetAllProducts() => unitOfWork.ProductRepository.List().ToList();        

        public List<Product> GetSpecialPriceProducts()
        {
            var products = unitOfWork.ProductRepository.List().ToList();
            if (clock.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                foreach (var item in products)
                {
                    item.UnitPrice = item.UnitPrice * 0.85M;
                }
            }
            return products;
        }

        public List<Product> GetProductsInPriceRange(decimal minPrice, decimal maxPrice) =>
            unitOfWork.ProductRepository.List()
            .Where(p => p.UnitPrice >= minPrice && p.UnitPrice <= maxPrice).ToList();        

        public Product GetProductById(int productId) => 
            unitOfWork.ProductRepository.List()
            .Single(p => p.ProductID == productId);            


        public int AddProduct(Product p)
        {

            if (p.Category != null && p.Category.CategoryID == 0)
            {
                unitOfWork.CategoryRepository.Add(p.Category);
            }
            unitOfWork.ProductRepository.Add(p);

            this.unitOfWork.Commit();
            return p.ProductID;
        }

        public void UpdateProduct(Product p)
        {
            unitOfWork.ProductRepository.Update(p);
            unitOfWork.Commit();          
        }

        public void DeleteProduct(Product p)
        {
            unitOfWork.ProductRepository.Delete(p);
            unitOfWork.Commit();          
        }
    }
}

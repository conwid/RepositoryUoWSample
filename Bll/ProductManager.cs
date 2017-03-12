using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;

namespace Bll
{
    public class ProductManager : IProductManager
    {
       
        private IUnitOfWork unitOfWork;

        private readonly IClock clock;

        public ProductManager(IUnitOfWork unitOfWork, IClock clock)
        {
            this.unitOfWork = unitOfWork;
            this.clock = clock;
        }
        public List<Product> GetAllProducts()
        {

            return unitOfWork.ProductRepository.List().ToList();
        }

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

        public List<Product> GetProductsInPriceRange(decimal minPrice, decimal maxPrice)
        {
            return unitOfWork.ProductRepository.List().Where(p => p.UnitPrice >= minPrice && p.UnitPrice <= maxPrice).ToList();

        }

        public Product GetProductById(int productId)
        {
            return unitOfWork.ProductRepository.List().Single(p => p.ProductID == productId);

        }


        public int AddProduct(Product p)
        {

            if (p.Category != null && p.Category.CategoryID == 0)
            {
                unitOfWork.CategoryRepository.Add(p.Category);
            }
            int id = unitOfWork.ProductRepository.Add(p);

            this.unitOfWork.Commit();
            return id;
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

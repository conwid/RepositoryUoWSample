using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class UnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; }
        public IProductRepository ProductRepository { get; }
        private readonly NorthwindContext ctx;

        public UnitOfWork(ICategoryRepository categoryRepository, IProductRepository productRepository, NorthwindContext ctx)
        {
            this.CategoryRepository = categoryRepository;
            this.ProductRepository = productRepository;
            this.ctx = ctx;
        }    

        public void Commit()
        {
            this.ctx.SaveChanges();
        }
    }
}

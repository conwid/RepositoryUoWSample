using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    
    public class ProductRepository : IProductRepository
    {
        private readonly NorthwindContext ctx;

        public ProductRepository(NorthwindContext ctx)
        {
            this.ctx = ctx;
        }
        public int Add(Product p)
        {
            ctx.Products.Add(p);
            return p.ProductID;
        }

        public void Delete(Product p)
        {
            var prod = ctx.Products.Single(product => product.ProductID == p.ProductID);
            ctx.Products.Remove(prod);
        }

        public Product Get(int productId)
        {
            return ctx.Products.Single(product => product.ProductID == productId);
        }

        public IQueryable<Product> List()
        {
            return ctx.Products;
        }

        public void Update(Product p)
        {
            var entry = ctx.Entry(p);
            if (entry.State == System.Data.Entity.EntityState.Detached)
            {
                ctx.Products.Attach(p);
            }
            entry.State = System.Data.Entity.EntityState.Modified;           
        }
    }    
}

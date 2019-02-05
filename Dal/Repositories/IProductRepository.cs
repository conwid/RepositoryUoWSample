using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{   

    public interface IProductRepository
    {
        void Add( Product p );
        IQueryable<Product> List();
        Product Get( int productId );
        void Update( Product p );
        void Delete( Product p );
    }

   
}

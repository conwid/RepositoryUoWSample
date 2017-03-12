using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
  
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }

        void Commit();
    }   
}

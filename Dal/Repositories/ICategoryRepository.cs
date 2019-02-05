using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public interface ICategoryRepository
    {
        void Add(Category c);
        IQueryable<Category> List();
        Category Get(int categoryId);
        void Update(Category c);
        void Delete(Category c);
    }
}

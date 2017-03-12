﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly NorthwindContext ctx;
        public CategoryRepository(NorthwindContext ctx)
        {
            this.ctx = ctx;
        }
        public int Add(Category p)
        {
            ctx.Categories.Add(p);
            return p.CategoryID;
        }

        public void Delete(Category p)
        {
            var prod = ctx.Categories.Single(product => product.CategoryID == p.CategoryID);
            ctx.Categories.Remove(prod);
        }

        public Category Get(int productId)
        {
            return ctx.Categories.Single(product => product.CategoryID == productId);
        }

        public IQueryable<Category> List()
        {
            return ctx.Categories;
        }

        public void Update(Category p)
        {
            var entry = ctx.Entry(p);
            if (entry.State == System.Data.Entity.EntityState.Detached)
            {
                ctx.Categories.Attach(p);
            }
            entry.State = System.Data.Entity.EntityState.Modified;
        }
    }
}

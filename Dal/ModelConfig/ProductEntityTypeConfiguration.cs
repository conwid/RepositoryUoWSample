using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.ModelConfig
{
    public class ProductEntityTypeConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductEntityTypeConfiguration()
        {
           Property(e => e.UnitPrice).HasColumnType("money").HasPrecision(19, 4);
        }
    }
}

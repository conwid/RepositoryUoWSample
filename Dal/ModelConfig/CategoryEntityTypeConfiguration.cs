using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.ModelConfig
{
    public class CategoryEntityTypeConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryEntityTypeConfiguration()
        {
            Property(e => e.Description).HasColumnType("ntext");
            Property(e => e.Picture).HasColumnType("image");
        }
    }
}

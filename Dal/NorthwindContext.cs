namespace Dal
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

   
    public partial class NorthwindContext : DbContext
    {
        public NorthwindContext() : base( "name=NorthwindContext" )
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

      
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {            
            modelBuilder.Entity<Product>()
                .Property( e => e.UnitPrice )
                .HasPrecision( 19, 4 );
        }
    }
}

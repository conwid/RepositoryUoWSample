namespace Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        public int ProductID { get; set; }

        [Required]
        [StringLength( 40 )]
        public string ProductName { get; set; }
        public int? CategoryID { get; set; }

        [Column( TypeName = "money" )]
        public decimal? UnitPrice { get; set; }
        public bool Discontinued { get; set; }

        public virtual Category Category { get; set; }
    }
}

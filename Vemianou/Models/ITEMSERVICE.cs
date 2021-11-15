namespace Vemianou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ITEMSERVICE")]
    public partial class ITEMSERVICE
    {
        [Key]
        public int iditemservice { get; set; }

        public int iditem { get; set; }

        public int idservice { get; set; }

        public double prixnow { get; set; }

        public int detail1 { get; set; }

        public int detail2 { get; set; }

        public string detail3 { get; set; }

        public virtual ITEM ITEM { get; set; }
    }
}

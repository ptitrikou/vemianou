namespace Vemianou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ITEMCOMPOZ")]
    public partial class ITEMCOMPOZ
    {
        [Key]
        public int iditemcompoz { get; set; }

        public int iditem1 { get; set; }

        public int iditem2 { get; set; }

        public double qtecompoz { get; set; }

        public int typcompoz { get; set; }

        public int unitecompoz { get; set; }

        public string libcompoz { get; set; }

        public bool choicprod { get; set; }

        public string libunit { get; set; }

        public string libcompoz2 { get; set; }

        [Column(TypeName = "money")]
        public decimal prixachat { get; set; }

        [Column(TypeName = "money")]
        public decimal totdebourse { get; set; }

        public int typcompoz2 { get; set; }

        public int typcompoz3 { get; set; }

        [Column(TypeName = "money")]
        public decimal totprix { get; set; }

        [Column(TypeName = "money")]
        public decimal prixvent { get; set; }

        public double qtemin { get; set; }

        public double prixrevien { get; set; }

        public int det1 { get; set; }

        public int idconditionnement { get; set; }

        public virtual ITEM ITEM { get; set; }

        public virtual ITEM ITEM1 { get; set; }
    }
}

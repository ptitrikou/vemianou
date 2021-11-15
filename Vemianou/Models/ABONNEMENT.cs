namespace Vemianou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ABONNEMENT")]
    public partial class ABONNEMENT
    {
        [Key]
        public int idabonn { get; set; }

        public int iditem { get; set; }

        public int userId { get; set; }

        public string libabonn { get; set; }

        public int periodabonn { get; set; }

        public int typperiodabonn { get; set; }

        [Column(TypeName = "date")]
        public DateTime datedebutvalid { get; set; }

        public TimeSpan? heuredebutvalid { get; set; }

        public int breakable { get; set; }

        public virtual ITEM ITEM { get; set; }

        public virtual USER USER { get; set; }
    }
}

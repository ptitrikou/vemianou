namespace Vemianou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ABONN")]
    public partial class ABONN
    {
        [Key]
        public int idabonn { get; set; }

        [StringLength(512)]
        public string libabonn { get; set; }

        public int iduser { get; set; }

        public string detabonn { get; set; }

        public string detabonn2 { get; set; }

        public int typeabonn { get; set; }

        public bool etatabonn { get; set; }

        public int etatabonn2 { get; set; }

        [Column(TypeName = "date")]
        public DateTime datstart { get; set; }

        public TimeSpan? heurestart { get; set; }

        public int nbperiodprev { get; set; }

        public int typperiod { get; set; }

        [Column(TypeName = "date")]
        public DateTime dateeffect { get; set; }

        public TimeSpan heureeffect { get; set; }

        [Column(TypeName = "date")]
        public DateTime datend { get; set; }

        public TimeSpan? heurend { get; set; }

        public virtual USER USER { get; set; }
    }
}

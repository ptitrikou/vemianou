namespace Vemianou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DECOMPTS
    {
        [Key]
        public int iddecompt { get; set; }

        public int? numerot { get; set; }

        [StringLength(512)]
        public string codelemen { get; set; }

        [Column(TypeName = "text")]
        public string descript { get; set; }
    }
}

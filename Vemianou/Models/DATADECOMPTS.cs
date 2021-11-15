namespace Vemianou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DATADECOMPTS
    {
        [Key]
        public int idelemen { get; set; }

        [Required]
        [StringLength(512)]
        public string codelemen { get; set; }

        [Column(TypeName = "text")]
        public string nomelemen { get; set; }

        public int? typelement { get; set; }

        public bool? activ { get; set; }

        [Column(TypeName = "text")]
        public string descript { get; set; }

        [Column(TypeName = "text")]
        public string descript2 { get; set; }

        [Column(TypeName = "text")]
        public string nomintern { get; set; }

        public bool defau { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? idcateg { get; set; }

        public int? typerelatif { get; set; }

        public int? ordraffich { get; set; }

        public int? typ2 { get; set; }

        public int? typ3 { get; set; }

        [StringLength(500)]
        public string pref1 { get; set; }

        [StringLength(500)]
        public string pref2 { get; set; }

        public int? ordraffich2 { get; set; }

        public int? ordreaffich3 { get; set; }

        [Column(TypeName = "text")]
        public string descript4 { get; set; }

        [StringLength(50)]
        public string pref3 { get; set; }
    }
}

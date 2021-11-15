namespace Vemianou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PARAMS
    {
        [Key]
        public int IDparam { get; set; }

        [StringLength(64)]
        public string codparam { get; set; }

        [StringLength(256)]
        public string libp { get; set; }

        public int? p1 { get; set; }

        public int? p2 { get; set; }

        public int? p3 { get; set; }

        public int? p4 { get; set; }

        public int? p5 { get; set; }

        public int? p6 { get; set; }

        public int? p7 { get; set; }

        public int? p8 { get; set; }

        public int? p9 { get; set; }

        public int? p10 { get; set; }

        public bool? p11 { get; set; }

        public bool? p12 { get; set; }

        public bool? p13 { get; set; }

        public bool? p14 { get; set; }

        public bool? p15 { get; set; }

        public bool? p16 { get; set; }

        public bool? p17 { get; set; }

        public bool? p18 { get; set; }

        public bool? p19 { get; set; }

        public bool? p20 { get; set; }

        [Column(TypeName = "text")]
        public string p21 { get; set; }

        [Column(TypeName = "text")]
        public string p22 { get; set; }

        [Column(TypeName = "text")]
        public string p23 { get; set; }

        [Column(TypeName = "text")]
        public string p24 { get; set; }

        [Column(TypeName = "text")]
        public string p25 { get; set; }

        [Column(TypeName = "text")]
        public string p26 { get; set; }

        [Column(TypeName = "text")]
        public string p27 { get; set; }

        [Column(TypeName = "text")]
        public string p28 { get; set; }

        [Column(TypeName = "text")]
        public string p29 { get; set; }

        [Column(TypeName = "text")]
        public string p30 { get; set; }

        public DateTime? p40 { get; set; }

        public DateTime? p41 { get; set; }

        public DateTime? p42 { get; set; }

        public DateTime? p43 { get; set; }

        public DateTime? p44 { get; set; }

        [Column(TypeName = "image")]
        public byte[] p45 { get; set; }

        public long? p46 { get; set; }

        public long? p47 { get; set; }

        public long? p48 { get; set; }

        public long? p49 { get; set; }

        public long? p50 { get; set; }
    }
}

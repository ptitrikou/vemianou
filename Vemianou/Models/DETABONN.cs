namespace Vemianou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DETABONN")]
    public partial class DETABONN
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idabonn { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iditem { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "date")]
        public DateTime datstart { get; set; }

        public TimeSpan? heurestart { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "date")]
        public DateTime datend { get; set; }

        public TimeSpan? heurend { get; set; }

        [StringLength(512)]
        public string details1 { get; set; }

        [StringLength(512)]
        public string details2 { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int breakable { get; set; }

        public virtual ITEM ITEM { get; set; }
    }
}

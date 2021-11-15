namespace Vemianou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ITEMDATA")]
    public partial class ITEMDATA
    {
        [Key]
        public int iditemdata { get; set; }

        public int iditem { get; set; }

        public int nbvues { get; set; }

        public short nbcontacts { get; set; }

        public short nbcmds { get; set; }

        public short nbdevis { get; set; }

        public int nblike { get; set; }

        public int nbdisklike { get; set; }

        public string codespec { get; set; }

        [StringLength(255)]
        public string valspec { get; set; }

        public virtual ITEM ITEM { get; set; }
    }
}

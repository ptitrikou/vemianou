namespace Vemianou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SOUSFAMILL")]
    public partial class SOUSFAMILL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SOUSFAMILL()
        {
            ITEM = new HashSet<ITEM>();
        }

        [Key]
        public int idsousfamill { get; set; }

        public string libsousfamill { get; set; }

        public int typsousfamill { get; set; }

        public string detsousfamill { get; set; }

        public int detsousfamill2 { get; set; }

        public int ordresousfamill { get; set; }

        public string imgsousfamill1 { get; set; }

        public byte[] imgsousfamill2 { get; set; }

        public int param1 { get; set; }

        public int param2 { get; set; }

        public string param3 { get; set; }

        public int idfamill { get; set; }

        public short etatsousfamill { get; set; }

        public virtual FAMILL FAMILL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ITEM> ITEM { get; set; }
    }
}

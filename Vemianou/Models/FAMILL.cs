namespace Vemianou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FAMILL")]
    public partial class FAMILL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FAMILL()
        {
            SOUSFAMILL = new HashSet<SOUSFAMILL>();
        }

        [Key]
        public int idfamill { get; set; }

        public int idgroupfamill { get; set; }

        public string libfamill { get; set; }

        public int typfamill { get; set; }

        public string imgfamill1 { get; set; }

        public byte[] imgfamill2 { get; set; }

        public int param1 { get; set; }

        public int param2 { get; set; }

        public string param3 { get; set; }

        public int ordrefamill { get; set; }

        public int etatfamill { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SOUSFAMILL> SOUSFAMILL { get; set; }

        public virtual GROUPFAMILL GROUPFAMILL { get; set; }
    }
}

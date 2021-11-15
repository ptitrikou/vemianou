namespace Vemianou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GROUPFAMILL")]
    public partial class GROUPFAMILL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GROUPFAMILL()
        {
            FAMILL = new HashSet<FAMILL>();
        }

        [Key]
        public int idgroupfamill { get; set; }

        public string libgroup { get; set; }

        public string imaggroup { get; set; }

        public byte[] imaggroup2 { get; set; }

        public int ordregroup { get; set; }

        public int etatgroup { get; set; }

        public int param1 { get; set; }

        public int param2 { get; set; }

        public int param3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAMILL> FAMILL { get; set; }
    }
}

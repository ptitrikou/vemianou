namespace Vemianou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USER")]
    public partial class USER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USER()
        {
            ABONN = new HashSet<ABONN>();
            ABONNEMENT = new HashSet<ABONNEMENT>();
            VENTE = new HashSet<VENTE>();
        }

        [Key]
        public int iduser { get; set; }

        [StringLength(64)]
        public string coduser { get; set; }

        [StringLength(64)]
        public string nomuser { get; set; }

        [StringLength(64)]
        public string prenomsuser { get; set; }

        [StringLength(128)]
        public string nomprenomsuser { get; set; }

        public int sexeuser { get; set; }

        [StringLength(256)]
        public string lienphoto1 { get; set; }

        [StringLength(256)]
        public string lienphoto2 { get; set; }

        public byte[] imaguser1 { get; set; }

        public byte[] imaguser2 { get; set; }

        public bool statut { get; set; }

        public int statut2 { get; set; }

        public int statut3 { get; set; }

        [StringLength(128)]
        public string loginuser { get; set; }

        [StringLength(128)]
        public string passeuser { get; set; }

        [StringLength(128)]
        public string email { get; set; }

        [StringLength(4)]
        public string indicatifuser { get; set; }

        [StringLength(128)]
        public string teluser { get; set; }

        public string adressuser { get; set; }

        public DateTime datecreat { get; set; }

        public int typuser { get; set; }

        public int typuser2 { get; set; }

        public int idville { get; set; }

        public int idpays { get; set; }

        [StringLength(255)]
        public string gpsuser { get; set; }

        [StringLength(255)]
        public string details1 { get; set; }

        [StringLength(255)]
        public string details2 { get; set; }

        [StringLength(255)]
        public string details3 { get; set; }

        public TimeSpan? responseTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ABONN> ABONN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ABONNEMENT> ABONNEMENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VENTE> VENTE { get; set; }
    }
}

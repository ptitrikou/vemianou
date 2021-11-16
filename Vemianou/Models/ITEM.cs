namespace Vemianou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ITEM")]
    public partial class ITEM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ITEM()
        {
            ABONNEMENT = new HashSet<ABONNEMENT>();
            DETVENTE = new HashSet<DETVENTE>();
            ITEMCOMPOZ = new HashSet<ITEMCOMPOZ>();
            ITEMCOMPOZ1 = new HashSet<ITEMCOMPOZ>();
            ITEMDATA = new HashSet<ITEMDATA>();
            ITEMSERVICE = new HashSet<ITEMSERVICE>();
            DETABONN = new HashSet<DETABONN>();
        }

        [Key]
        public int iditem { get; set; }

        [StringLength(255)]
        public string designation { get; set; }

        
        public string designdetails { get; set; }

        [StringLength(255)]
        public string designdetails2 { get; set; }

        public double prixitem { get; set; }

        public double prix1 { get; set; }

        public double prix2 { get; set; }

        public double prix3 { get; set; }

        public double tauxremiz { get; set; }

        [StringLength(10)]
        public string devise { get; set; }

        public int typeitem { get; set; }

        public int category { get; set; }

        public int commandmin { get; set; }

        public int nbgarantie { get; set; }

        public int typperiodgarantie { get; set; }

        [StringLength(255)]
        public string capacitappro { get; set; }

        [StringLength(255)]
        public string typeappro { get; set; }

        [StringLength(255)]
        public string detailslivraison { get; set; }

        public int etatitem { get; set; }

        public int etatitem2 { get; set; }

        public int etatitem3 { get; set; }

        public int ordre1 { get; set; }

        public int ordre2 { get; set; }

        public int notifs { get; set; }

        public int? typpublish { get; set; }

        public DateTime datpublish { get; set; }

        public DateTime datpromo1 { get; set; }

        public DateTime datpromo2 { get; set; }

        [StringLength(255)]
        public string numcontact { get; set; }

        public int payscontact { get; set; }

        public string imagpath1 { get; set; }

        public string imagpath2 { get; set; }

        public string imagpath3 { get; set; }

        public string imagpath4 { get; set; }

        public string imagpath5 { get; set; }

        public string imagpath6 { get; set; }

        public string imagpath7 { get; set; }

        public string imagpath8 { get; set; }

        public byte[] imageitem { get; set; }

        public byte[] imageitem2 { get; set; }

        public byte[] imageitem3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ABONNEMENT> ABONNEMENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETVENTE> DETVENTE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ITEMCOMPOZ> ITEMCOMPOZ { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ITEMCOMPOZ> ITEMCOMPOZ1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ITEMDATA> ITEMDATA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ITEMSERVICE> ITEMSERVICE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETABONN> DETABONN { get; set; }

        public virtual SOUSFAMILL SOUSFAMILL { get; set; }
    }
}

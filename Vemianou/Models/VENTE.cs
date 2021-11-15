namespace Vemianou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VENTE")]
    public partial class VENTE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VENTE()
        {
            DETVENTE = new HashSet<DETVENTE>();
        }

        [Key]
        public int idvente { get; set; }

        public int iduser { get; set; }

        public DateTime datvente { get; set; }

        public DateTime heurvente { get; set; }

        [Column(TypeName = "text")]
        public string detailsvente { get; set; }

        [StringLength(128)]
        public string codevente { get; set; }

        [Column(TypeName = "text")]
        public string comments { get; set; }

        public int? escomptglob { get; set; }

        public double remizglob { get; set; }

        [Column(TypeName = "money")]
        public decimal totalvente { get; set; }

        [Column(TypeName = "text")]
        public string naturvente { get; set; }

        public DateTime datenr { get; set; }

        [StringLength(500)]
        public string loginutiliz { get; set; }

        [Column(TypeName = "money")]
        public decimal totalregle { get; set; }

        [Column(TypeName = "money")]
        public decimal restaregler { get; set; }

        public int qtenormtout { get; set; }

        public int qtenorm1 { get; set; }

        public int qtenorm2 { get; set; }

        [Column(TypeName = "image")]
        public byte[] fichier1 { get; set; }

        public int idpdv { get; set; }

        public bool encaiss { get; set; }

        public int idutiliz { get; set; }

        public int idutiliz2 { get; set; }

        public int idutiliz3 { get; set; }

        public int naturvent2 { get; set; }

        public int naturvent3 { get; set; }

        public int idevent { get; set; }

        public int etatvente { get; set; }

        public int etatvente2 { get; set; }

        public double tauxremiz { get; set; }

        public double tauxtva { get; set; }

        public double montanttva { get; set; }

        [Column(TypeName = "money")]
        public decimal montantht { get; set; }

        [Column(TypeName = "money")]
        public decimal montantttc { get; set; }

        public int idcommand { get; set; }

        public int nbecheanc { get; set; }

        public int typecheanc { get; set; }

        public int modtax { get; set; }

        public DateTime echeancpaiemen { get; set; }

        public DateTime datecheanc { get; set; }

        public int marknotif1 { get; set; }

        public int marknotif2 { get; set; }

        public int modcharge { get; set; }

        public int valdevise { get; set; }

        [Column(TypeName = "text")]
        public string ref1 { get; set; }

        [Column(TypeName = "text")]
        public string ref2 { get; set; }

        public int statut1 { get; set; }

        public int statut2 { get; set; }

        public int decomptstock { get; set; }

        public DateTime datlastmodif { get; set; }

        public int idlastmodif { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETVENTE> DETVENTE { get; set; }

        public virtual USER USER { get; set; }
    }
}

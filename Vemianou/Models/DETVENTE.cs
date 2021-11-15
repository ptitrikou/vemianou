namespace Vemianou.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DETVENTE")]
    public partial class DETVENTE
    {
        [Key]
        public int iddetail { get; set; }

        public int idvente { get; set; }

        public int iditem { get; set; }

        public double qteachat { get; set; }

        [Column(TypeName = "money")]
        public decimal prixunit { get; set; }

        [Column(TypeName = "money")]
        public decimal remizprod { get; set; }

        [Column(TypeName = "money")]
        public decimal escomptprod { get; set; }

        public double qtelivre { get; set; }

        public double qtemin { get; set; }

        public double tauxremiz { get; set; }

        public double tauxescompt { get; set; }

        [Column(TypeName = "money")]
        public decimal soustot { get; set; }

        [StringLength(1000)]
        public string codedetail1 { get; set; }

        [Column(TypeName = "text")]
        public string detailsprod { get; set; }

        [Column(TypeName = "money")]
        public decimal prixachat1 { get; set; }

        [Column(TypeName = "text")]
        public string numserie { get; set; }

        public int idcondachat { get; set; }

        public int idcondlivre { get; set; }

        public int idrubrikfact { get; set; }

        public int idrubrikfact2 { get; set; }

        [Column(TypeName = "text")]
        public string descitem1 { get; set; }

        [Column(TypeName = "text")]
        public string descitem2 { get; set; }

        [Column(TypeName = "text")]
        public string descitem3 { get; set; }

        public int ordrai1 { get; set; }

        public int ordrai2 { get; set; }

        public int typdetail1 { get; set; }

        [Column(TypeName = "text")]
        public string typdetail2 { get; set; }

        [StringLength(64)]
        public string typdetail3 { get; set; }

        [Column(TypeName = "text")]
        public string idunik { get; set; }

        public int nbgarannti { get; set; }

        public int typperiodg2 { get; set; }

        public int caract1 { get; set; }

        public int caract2 { get; set; }

        public int caract3 { get; set; }

        public virtual ITEM ITEM { get; set; }

        public virtual VENTE VENTE { get; set; }
    }
}

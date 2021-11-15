namespace Vemianou.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelCristal : DbContext
    {
        public ModelCristal()
            : base("name=ModelCristal")
        {
        }

        public virtual DbSet<ABONN> ABONN { get; set; }
        public virtual DbSet<ABONNEMENT> ABONNEMENT { get; set; }
        public virtual DbSet<DATADECOMPTS> DATADECOMPTS { get; set; }
        public virtual DbSet<DECOMPTS> DECOMPTS { get; set; }
        public virtual DbSet<DETVENTE> DETVENTE { get; set; }
        public virtual DbSet<FAMILL> FAMILL { get; set; }
        public virtual DbSet<GROUPFAMILL> GROUPFAMILL { get; set; }
        public virtual DbSet<ITEM> ITEM { get; set; }
        public virtual DbSet<ITEMCOMPOZ> ITEMCOMPOZ { get; set; }
        public virtual DbSet<ITEMDATA> ITEMDATA { get; set; }
        public virtual DbSet<ITEMSERVICE> ITEMSERVICE { get; set; }
        public virtual DbSet<PARAMS> PARAMS { get; set; }
        public virtual DbSet<SOUSFAMILL> SOUSFAMILL { get; set; }
        public virtual DbSet<USER> USER { get; set; }
        public virtual DbSet<VENTE> VENTE { get; set; }
        public virtual DbSet<DETABONN> DETABONN { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ABONN>()
                .Property(e => e.libabonn)
                .IsUnicode(false);

            modelBuilder.Entity<ABONN>()
                .Property(e => e.detabonn)
                .IsUnicode(false);

            modelBuilder.Entity<ABONN>()
                .Property(e => e.detabonn2)
                .IsUnicode(false);

            modelBuilder.Entity<ABONN>()
                .Property(e => e.heurestart)
                .HasPrecision(0);

            modelBuilder.Entity<ABONNEMENT>()
                .Property(e => e.libabonn)
                .IsUnicode(false);

            modelBuilder.Entity<ABONNEMENT>()
                .Property(e => e.heuredebutvalid)
                .HasPrecision(0);

            modelBuilder.Entity<DATADECOMPTS>()
                .Property(e => e.codelemen)
                .IsUnicode(false);

            modelBuilder.Entity<DATADECOMPTS>()
                .Property(e => e.nomelemen)
                .IsUnicode(false);

            modelBuilder.Entity<DATADECOMPTS>()
                .Property(e => e.descript)
                .IsUnicode(false);

            modelBuilder.Entity<DATADECOMPTS>()
                .Property(e => e.descript2)
                .IsUnicode(false);

            modelBuilder.Entity<DATADECOMPTS>()
                .Property(e => e.nomintern)
                .IsUnicode(false);

            modelBuilder.Entity<DATADECOMPTS>()
                .Property(e => e.idcateg)
                .HasPrecision(19, 0);

            modelBuilder.Entity<DATADECOMPTS>()
                .Property(e => e.pref1)
                .IsUnicode(false);

            modelBuilder.Entity<DATADECOMPTS>()
                .Property(e => e.pref2)
                .IsUnicode(false);

            modelBuilder.Entity<DATADECOMPTS>()
                .Property(e => e.descript4)
                .IsUnicode(false);

            modelBuilder.Entity<DATADECOMPTS>()
                .Property(e => e.pref3)
                .IsUnicode(false);

            modelBuilder.Entity<DECOMPTS>()
                .Property(e => e.codelemen)
                .IsUnicode(false);

            modelBuilder.Entity<DECOMPTS>()
                .Property(e => e.descript)
                .IsUnicode(false);

            modelBuilder.Entity<DETVENTE>()
                .Property(e => e.prixunit)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DETVENTE>()
                .Property(e => e.remizprod)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DETVENTE>()
                .Property(e => e.escomptprod)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DETVENTE>()
                .Property(e => e.soustot)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DETVENTE>()
                .Property(e => e.codedetail1)
                .IsUnicode(false);

            modelBuilder.Entity<DETVENTE>()
                .Property(e => e.detailsprod)
                .IsUnicode(false);

            modelBuilder.Entity<DETVENTE>()
                .Property(e => e.prixachat1)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DETVENTE>()
                .Property(e => e.numserie)
                .IsUnicode(false);

            modelBuilder.Entity<DETVENTE>()
                .Property(e => e.descitem1)
                .IsUnicode(false);

            modelBuilder.Entity<DETVENTE>()
                .Property(e => e.descitem2)
                .IsUnicode(false);

            modelBuilder.Entity<DETVENTE>()
                .Property(e => e.descitem3)
                .IsUnicode(false);

            modelBuilder.Entity<DETVENTE>()
                .Property(e => e.typdetail2)
                .IsUnicode(false);

            modelBuilder.Entity<DETVENTE>()
                .Property(e => e.typdetail3)
                .IsUnicode(false);

            modelBuilder.Entity<DETVENTE>()
                .Property(e => e.idunik)
                .IsUnicode(false);

            modelBuilder.Entity<FAMILL>()
                .Property(e => e.libfamill)
                .IsUnicode(false);

            modelBuilder.Entity<FAMILL>()
                .Property(e => e.imgfamill1)
                .IsUnicode(false);

            modelBuilder.Entity<FAMILL>()
                .Property(e => e.param3)
                .IsUnicode(false);

            modelBuilder.Entity<FAMILL>()
                .HasMany(e => e.SOUSFAMILL)
                .WithRequired(e => e.FAMILL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GROUPFAMILL>()
                .Property(e => e.libgroup)
                .IsUnicode(false);

            modelBuilder.Entity<GROUPFAMILL>()
                .Property(e => e.imaggroup)
                .IsUnicode(false);

            modelBuilder.Entity<GROUPFAMILL>()
                .HasMany(e => e.FAMILL)
                .WithRequired(e => e.GROUPFAMILL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ITEM>()
                .Property(e => e.designation)
                .IsUnicode(false);

            modelBuilder.Entity<ITEM>()
                .Property(e => e.designdetails)
                .IsUnicode(false);

            modelBuilder.Entity<ITEM>()
                .Property(e => e.designdetails2)
                .IsUnicode(false);

            modelBuilder.Entity<ITEM>()
                .Property(e => e.devise)
                .IsUnicode(false);

            modelBuilder.Entity<ITEM>()
                .Property(e => e.capacitappro)
                .IsUnicode(false);

            modelBuilder.Entity<ITEM>()
                .Property(e => e.typeappro)
                .IsUnicode(false);

            modelBuilder.Entity<ITEM>()
                .Property(e => e.detailslivraison)
                .IsUnicode(false);

            modelBuilder.Entity<ITEM>()
                .Property(e => e.numcontact)
                .IsUnicode(false);

            modelBuilder.Entity<ITEM>()
                .Property(e => e.imagpath1)
                .IsUnicode(false);

            modelBuilder.Entity<ITEM>()
                .Property(e => e.imagpath2)
                .IsUnicode(false);

            modelBuilder.Entity<ITEM>()
                .Property(e => e.imagpath3)
                .IsUnicode(false);

            modelBuilder.Entity<ITEM>()
                .Property(e => e.imagpath4)
                .IsUnicode(false);

            modelBuilder.Entity<ITEM>()
                .Property(e => e.imagpath5)
                .IsUnicode(false);

            modelBuilder.Entity<ITEM>()
                .Property(e => e.imagpath6)
                .IsUnicode(false);

            modelBuilder.Entity<ITEM>()
                .Property(e => e.imagpath7)
                .IsUnicode(false);

            modelBuilder.Entity<ITEM>()
                .Property(e => e.imagpath8)
                .IsUnicode(false);

            modelBuilder.Entity<ITEM>()
                .HasMany(e => e.ABONNEMENT)
                .WithRequired(e => e.ITEM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ITEM>()
                .HasMany(e => e.DETVENTE)
                .WithRequired(e => e.ITEM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ITEM>()
                .HasMany(e => e.ITEMCOMPOZ)
                .WithRequired(e => e.ITEM)
                .HasForeignKey(e => e.iditem1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ITEM>()
                .HasMany(e => e.ITEMCOMPOZ1)
                .WithRequired(e => e.ITEM1)
                .HasForeignKey(e => e.iditem2)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ITEM>()
                .HasMany(e => e.ITEMDATA)
                .WithRequired(e => e.ITEM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ITEM>()
                .HasMany(e => e.ITEMSERVICE)
                .WithRequired(e => e.ITEM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ITEM>()
                .HasMany(e => e.DETABONN)
                .WithRequired(e => e.ITEM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ITEMCOMPOZ>()
                .Property(e => e.libcompoz)
                .IsUnicode(false);

            modelBuilder.Entity<ITEMCOMPOZ>()
                .Property(e => e.libunit)
                .IsUnicode(false);

            modelBuilder.Entity<ITEMCOMPOZ>()
                .Property(e => e.libcompoz2)
                .IsUnicode(false);

            modelBuilder.Entity<ITEMCOMPOZ>()
                .Property(e => e.prixachat)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ITEMCOMPOZ>()
                .Property(e => e.totdebourse)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ITEMCOMPOZ>()
                .Property(e => e.totprix)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ITEMCOMPOZ>()
                .Property(e => e.prixvent)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ITEMDATA>()
                .Property(e => e.codespec)
                .IsUnicode(false);

            modelBuilder.Entity<ITEMDATA>()
                .Property(e => e.valspec)
                .IsUnicode(false);

            modelBuilder.Entity<ITEMSERVICE>()
                .Property(e => e.detail3)
                .IsUnicode(false);

            modelBuilder.Entity<PARAMS>()
                .Property(e => e.codparam)
                .IsUnicode(false);

            modelBuilder.Entity<PARAMS>()
                .Property(e => e.libp)
                .IsUnicode(false);

            modelBuilder.Entity<PARAMS>()
                .Property(e => e.p21)
                .IsUnicode(false);

            modelBuilder.Entity<PARAMS>()
                .Property(e => e.p22)
                .IsUnicode(false);

            modelBuilder.Entity<PARAMS>()
                .Property(e => e.p23)
                .IsUnicode(false);

            modelBuilder.Entity<PARAMS>()
                .Property(e => e.p24)
                .IsUnicode(false);

            modelBuilder.Entity<PARAMS>()
                .Property(e => e.p25)
                .IsUnicode(false);

            modelBuilder.Entity<PARAMS>()
                .Property(e => e.p26)
                .IsUnicode(false);

            modelBuilder.Entity<PARAMS>()
                .Property(e => e.p27)
                .IsUnicode(false);

            modelBuilder.Entity<PARAMS>()
                .Property(e => e.p28)
                .IsUnicode(false);

            modelBuilder.Entity<PARAMS>()
                .Property(e => e.p29)
                .IsUnicode(false);

            modelBuilder.Entity<PARAMS>()
                .Property(e => e.p30)
                .IsUnicode(false);

            modelBuilder.Entity<SOUSFAMILL>()
                .Property(e => e.libsousfamill)
                .IsUnicode(false);

            modelBuilder.Entity<SOUSFAMILL>()
                .Property(e => e.detsousfamill)
                .IsUnicode(false);

            modelBuilder.Entity<SOUSFAMILL>()
                .Property(e => e.imgsousfamill1)
                .IsUnicode(false);

            modelBuilder.Entity<SOUSFAMILL>()
                .Property(e => e.param3)
                .IsUnicode(false);

            modelBuilder.Entity<SOUSFAMILL>()
                .HasMany(e => e.ITEM)
                .WithRequired(e => e.SOUSFAMILL)
                .HasForeignKey(e => e.category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.coduser)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.nomuser)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.prenomsuser)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.nomprenomsuser)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.lienphoto1)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.lienphoto2)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.loginuser)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.passeuser)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.indicatifuser)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.teluser)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.adressuser)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.gpsuser)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.details1)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.details2)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.details3)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.responseTime)
                .HasPrecision(0);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.ABONN)
                .WithRequired(e => e.USER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.ABONNEMENT)
                .WithRequired(e => e.USER)
                .HasForeignKey(e => e.userId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.VENTE)
                .WithRequired(e => e.USER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VENTE>()
                .Property(e => e.detailsvente)
                .IsUnicode(false);

            modelBuilder.Entity<VENTE>()
                .Property(e => e.codevente)
                .IsUnicode(false);

            modelBuilder.Entity<VENTE>()
                .Property(e => e.comments)
                .IsUnicode(false);

            modelBuilder.Entity<VENTE>()
                .Property(e => e.totalvente)
                .HasPrecision(19, 4);

            modelBuilder.Entity<VENTE>()
                .Property(e => e.naturvente)
                .IsUnicode(false);

            modelBuilder.Entity<VENTE>()
                .Property(e => e.loginutiliz)
                .IsUnicode(false);

            modelBuilder.Entity<VENTE>()
                .Property(e => e.totalregle)
                .HasPrecision(19, 4);

            modelBuilder.Entity<VENTE>()
                .Property(e => e.restaregler)
                .HasPrecision(19, 4);

            modelBuilder.Entity<VENTE>()
                .Property(e => e.montantht)
                .HasPrecision(19, 4);

            modelBuilder.Entity<VENTE>()
                .Property(e => e.montantttc)
                .HasPrecision(19, 4);

            modelBuilder.Entity<VENTE>()
                .Property(e => e.ref1)
                .IsUnicode(false);

            modelBuilder.Entity<VENTE>()
                .Property(e => e.ref2)
                .IsUnicode(false);

            modelBuilder.Entity<VENTE>()
                .HasMany(e => e.DETVENTE)
                .WithRequired(e => e.VENTE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DETABONN>()
                .Property(e => e.heurestart)
                .HasPrecision(0);

            modelBuilder.Entity<DETABONN>()
                .Property(e => e.details1)
                .IsUnicode(false);

            modelBuilder.Entity<DETABONN>()
                .Property(e => e.details2)
                .IsUnicode(false);
        }
    }
}

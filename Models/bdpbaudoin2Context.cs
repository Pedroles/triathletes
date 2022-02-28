using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace triathletes.Models
{
    public partial class bdpbaudoin2Context : DbContext
    {
        public bdpbaudoin2Context()
        {
        }

        public bdpbaudoin2Context(DbContextOptions<bdpbaudoin2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorie> Categories { get; set; }
        public virtual DbSet<Club> Clubs { get; set; }
        public virtual DbSet<Controler> Controlers { get; set; }
        public virtual DbSet<Inscription> Inscriptions { get; set; }
        public virtual DbSet<Licence> Licences { get; set; }
        public virtual DbSet<LicenceClub> LicenceClubs { get; set; }
        public virtual DbSet<ProduitDopant> ProduitDopants { get; set; }
        public virtual DbSet<Triathlon> Triathlons { get; set; }
        public virtual DbSet<TypeTriathlon> TypeTriathlons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=192.168.4.1;port=3306;user=sqlpbaudoin;password=savary;database=bdpbaudoin2;sslmode=none");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorie>(entity =>
            {
                entity.HasKey(e => e.CatId)
                    .HasName("PRIMARY");

                entity.ToTable("CATEGORIE");

                entity.Property(e => e.CatId)
                    .HasColumnType("int(11)")
                    .HasColumnName("CAT_ID");

                entity.Property(e => e.CatAgeDébut)
                    .HasColumnType("int(11)")
                    .HasColumnName("CAT_AGE_DÉBUT")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CatAgeFin)
                    .HasColumnType("int(11)")
                    .HasColumnName("CAT_AGE_FIN")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CatLibelle)
                    .HasMaxLength(128)
                    .HasColumnName("CAT_LIBELLE")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Club>(entity =>
            {
                entity.ToTable("CLUB");

                entity.Property(e => e.ClubId)
                    .HasColumnType("int(11)")
                    .HasColumnName("CLUB_ID");

                entity.Property(e => e.ClubCp)
                    .HasMaxLength(5)
                    .HasColumnName("CLUB_CP")
                    .HasDefaultValueSql("'NULL'")
                    .IsFixedLength(true);

                entity.Property(e => e.ClubNom)
                    .HasMaxLength(128)
                    .HasColumnName("CLUB_NOM")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ClubRue)
                    .HasMaxLength(128)
                    .HasColumnName("CLUB_RUE")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ClubTel)
                    .HasMaxLength(32)
                    .HasColumnName("CLUB_TEL")
                    .HasDefaultValueSql("'NULL'")
                    .IsFixedLength(true);

                entity.Property(e => e.ClubVille)
                    .HasMaxLength(128)
                    .HasColumnName("CLUB_VILLE")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Controler>(entity =>
            {
                entity.HasKey(e => new { e.TriId, e.InscDossard, e.DopId })
                    .HasName("PRIMARY");

                entity.ToTable("CONTROLER");

                entity.HasIndex(e => new { e.TriId, e.InscDossard }, "I_FK_CONTROLER_INSCRIPTION");

                entity.HasIndex(e => e.DopId, "I_FK_CONTROLER_PRODUIT_DOPANT");

                entity.Property(e => e.TriId)
                    .HasColumnType("int(11)")
                    .HasColumnName("TRI_ID");

                entity.Property(e => e.InscDossard)
                    .HasColumnType("int(11)")
                    .HasColumnName("INSC_DOSSARD");

                entity.Property(e => e.DopId)
                    .HasColumnType("int(11)")
                    .HasColumnName("DOP_ID");

                entity.Property(e => e.ControleRésultat)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("CONTROLE_RÉSULTAT")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Dop)
                    .WithMany(p => p.Controlers)
                    .HasForeignKey(d => d.DopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONTROLER_PRODUIT_DOPANT");

                entity.HasOne(d => d.Inscription)
                    .WithMany(p => p.Controlers)
                    .HasForeignKey(d => new { d.TriId, d.InscDossard })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONTROLER_INSCRIPTION");
            });

            modelBuilder.Entity<Inscription>(entity =>
            {
                entity.HasKey(e => new { e.TriId, e.InscDossard })
                    .HasName("PRIMARY");

                entity.ToTable("INSCRIPTION");

                entity.HasIndex(e => e.LicId, "I_FK_INSCRIPTION_LICENCE");

                entity.HasIndex(e => e.TriId, "I_FK_INSCRIPTION_TRIATHLON");

                entity.Property(e => e.TriId)
                    .HasColumnType("int(11)")
                    .HasColumnName("TRI_ID");

                entity.Property(e => e.InscDossard)
                    .HasColumnType("int(11)")
                    .HasColumnName("INSC_DOSSARD");

                entity.Property(e => e.InscClassement)
                    .HasColumnType("int(11)")
                    .HasColumnName("INSC_CLASSEMENT")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.InscDateInscription)
                    .HasColumnType("date")
                    .HasColumnName("INSC_DATE_INSCRIPTION")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.InscForfait)
                    .HasColumnName("INSC_FORFAIT")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.InscTempsCourse)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("INSC_TEMPS_COURSE")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.InscTempsNatation)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("INSC_TEMPS_NATATION")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.InscTempsVelo)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("INSC_TEMPS_VELO")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.LicId)
                    .HasColumnType("int(11)")
                    .HasColumnName("LIC_ID");

                entity.HasOne(d => d.Lic)
                    .WithMany(p => p.Inscriptions)
                    .HasForeignKey(d => d.LicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_INSCRIPTION_LICENCE");

                entity.HasOne(d => d.Tri)
                    .WithMany(p => p.Inscriptions)
                    .HasForeignKey(d => d.TriId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_INSCRIPTION_TRIATHLON");
            });

            modelBuilder.Entity<Licence>(entity =>
            {
                entity.HasKey(e => e.LicId)
                    .HasName("PRIMARY");

                entity.ToTable("LICENCE");

                entity.HasIndex(e => e.CatId, "I_FK_LICENCE_CATEGORIE");

                entity.Property(e => e.LicId)
                    .HasColumnType("int(11)")
                    .HasColumnName("LIC_ID");

                entity.Property(e => e.CatId)
                    .HasColumnType("int(11)")
                    .HasColumnName("CAT_ID");

                entity.Property(e => e.LicCodePostal)
                    .HasMaxLength(32)
                    .HasColumnName("LIC_CODE_POSTAL")
                    .HasDefaultValueSql("'NULL'")
                    .IsFixedLength(true);

                entity.Property(e => e.LicDateNaissance)
                    .HasColumnType("date")
                    .HasColumnName("LIC_DATE_NAISSANCE")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.LicEmail)
                    .HasMaxLength(128)
                    .HasColumnName("LIC_EMAIL")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.LicNom)
                    .HasMaxLength(128)
                    .HasColumnName("LIC_NOM")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.LicPhoto)
                    .HasColumnType("longblob")
                    .HasColumnName("LIC_PHOTO")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.LicPrenom)
                    .HasMaxLength(128)
                    .HasColumnName("LIC_PRENOM")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.LicRue)
                    .HasMaxLength(128)
                    .HasColumnName("LIC_RUE")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.LicSexe)
                    .HasMaxLength(128)
                    .HasColumnName("LIC_SEXE")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.LicVille)
                    .HasMaxLength(128)
                    .HasColumnName("LIC_VILLE")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Licences)
                    .HasForeignKey(d => d.CatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LICENCE_CATEGORIE");
            });

            modelBuilder.Entity<LicenceClub>(entity =>
            {
                entity.HasKey(e => e.LicId)
                    .HasName("PRIMARY");

                entity.ToTable("LICENCE_CLUB");

                entity.HasIndex(e => e.ClubId, "I_FK_LICENCE_CLUB_CLUB");

                entity.HasIndex(e => e.ClubIdAdherer, "I_FK_LICENCE_CLUB_CLUB1");

                entity.Property(e => e.LicId)
                    .HasColumnType("int(11)")
                    .HasColumnName("LIC_ID");

                entity.Property(e => e.ClubId)
                    .HasColumnType("int(11)")
                    .HasColumnName("CLUB_ID")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ClubIdAdherer)
                    .HasColumnType("int(11)")
                    .HasColumnName("CLUB_ID_ADHERER");

                entity.Property(e => e.LicDatePremiereLice)
                    .HasColumnType("date")
                    .HasColumnName("LIC_DATE_PREMIERE_LICE")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.LicenceClubClubs)
                    .HasForeignKey(d => d.ClubId)
                    .HasConstraintName("FK_LICENCE_CLUB_CLUB");

                entity.HasOne(d => d.ClubIdAdhererNavigation)
                    .WithMany(p => p.LicenceClubClubIdAdhererNavigations)
                    .HasForeignKey(d => d.ClubIdAdherer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LICENCE_CLUB_CLUB1");

                entity.HasOne(d => d.Lic)
                    .WithOne(p => p.LicenceClub)
                    .HasForeignKey<LicenceClub>(d => d.LicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LICENCE_CLUB_LICENCE");
            });

            modelBuilder.Entity<ProduitDopant>(entity =>
            {
                entity.HasKey(e => e.DopId)
                    .HasName("PRIMARY");

                entity.ToTable("PRODUIT_DOPANT");

                entity.Property(e => e.DopId)
                    .HasColumnType("int(11)")
                    .HasColumnName("DOP_ID");

                entity.Property(e => e.DopLibelle)
                    .HasMaxLength(128)
                    .HasColumnName("DOP_LIBELLE")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.DopTauxMax)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("DOP_TAUX_MAX")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Triathlon>(entity =>
            {
                entity.HasKey(e => e.TriId)
                    .HasName("PRIMARY");

                entity.ToTable("TRIATHLON");

                entity.HasIndex(e => e.TypeId, "I_FK_TRIATHLON_TYPE_TRIATHLON");

                entity.Property(e => e.TriId)
                    .HasColumnType("int(11)")
                    .HasColumnName("TRI_ID");

                entity.Property(e => e.TriCp)
                    .HasMaxLength(32)
                    .HasColumnName("TRI_CP")
                    .HasDefaultValueSql("'NULL'")
                    .IsFixedLength(true);

                entity.Property(e => e.TriDate)
                    .HasColumnType("date")
                    .HasColumnName("TRI_DATE")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TriLieu)
                    .HasMaxLength(128)
                    .HasColumnName("TRI_LIEU")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TriNom)
                    .HasMaxLength(128)
                    .HasColumnName("TRI_NOM")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TriVille)
                    .HasMaxLength(128)
                    .HasColumnName("TRI_VILLE")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TypeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("TYPE_ID");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Triathlons)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TRIATHLON_TYPE_TRIATHLON");
            });

            modelBuilder.Entity<TypeTriathlon>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PRIMARY");

                entity.ToTable("TYPE_TRIATHLON");

                entity.Property(e => e.TypeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("TYPE_ID");

                entity.Property(e => e.TypeDistanceCourse)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("TYPE_DISTANCE_COURSE")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TypeDistanceNatation)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("TYPE_DISTANCE_NATATION")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TypeDistanceVelo)
                    .HasColumnType("decimal(10,2)")
                    .HasColumnName("TYPE_DISTANCE_VELO")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TypeLibelle)
                    .HasMaxLength(128)
                    .HasColumnName("TYPE_LIBELLE")
                    .HasDefaultValueSql("'NULL'");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

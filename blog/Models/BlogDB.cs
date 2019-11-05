namespace blog.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BlogDB : DbContext
    {
        public BlogDB()
            : base("name=BlogDB")
        {
        }

        public virtual DbSet<Etiket> Etikets { get; set; }
        public virtual DbSet<Kullanici> Kullanicis { get; set; }
        public virtual DbSet<Makale> Makales { get; set; }
        public virtual DbSet<Yorum> Yorums { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Etiket>()
                .HasMany(e => e.Makales)
                .WithMany(e => e.Etikets)
                .Map(m => m.ToTable("EtiketMakale").MapLeftKey("EtiketId").MapRightKey("MakaleId"));

            modelBuilder.Entity<Kullanici>()
                .HasMany(e => e.Makales)
                .WithRequired(e => e.kullanıcı)
                .HasForeignKey(e => e.kullaniciId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kullanici>()
                .HasMany(e => e.Yorums)
                .WithRequired(e => e.kullanıcı)
                .HasForeignKey(e => e.KullaniciId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Makale>()
                .HasMany(e => e.Yorums)
                .WithRequired(e => e.Makale)
                .WillCascadeOnDelete(false);
        }
    }
}

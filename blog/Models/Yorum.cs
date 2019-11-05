namespace blog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Yorum")]
    public partial class Yorum
    {
        public int id { get; set; }

        [Required]
        public string Yorumİcerik { get; set; }

        public int KullaniciId { get; set; }

        public int MakaleId { get; set; }

        public DateTime tarih { get; set; }

        public virtual Kullanici kullanıcı { get; set; }

        public virtual Makale Makale { get; set; }
    }
}

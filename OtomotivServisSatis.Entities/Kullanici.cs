using System.ComponentModel.DataAnnotations;

namespace OtomotivServisSatis.Entities
{
    public class Kullanici : IEntity
    {
        public int Id { get; set; }
        [StringLength(50)]
        [Display(Name = "Ad"),Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Adi { get; set; }
        [StringLength(50) , Display(Name = "Soyad"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        
        public string Soyadi { get; set; }
        [StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Email { get; set; }
        [StringLength(20)]
        public string? Telefon { get; set; }
        [StringLength(50)]      
        public string? KullaniciAdi { get; set; } //sayfada kontrol etmıyor fakat veritabanı hala bu bılgılerı beklıyor.
        [StringLength(50), Required(ErrorMessage = "{0} Boş Bırakılamaz!"),Display(Name ="Şifre")]
        public string Sifre { get; set; }
        public bool AktifMi { get; set; }
        [Display(Name = "Eklenme Tarihi"),ScaffoldColumn(false)] //ekranda bu prop için gerekli alanları olusturmaz.
        public DateTime? EklenmeTarihi { get; set; } = DateTime.Now;
        [Display(Name = " Kullanıcı Rolü"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public int RolId { get; set; }
        [Display(Name = " Kullanıcı Rolü")]
        public virtual Rol? Rol { get; set; }
        public Guid? UserGuid { get; set; } = Guid.NewGuid();
    }
}

﻿using System.ComponentModel.DataAnnotations;

namespace OtomotivServisSatis.Entities
{
    public class Rol : IEntity
    {
        public int Id { get; set; }
        [StringLength(50)]
        [Display(Name = "Adı"), Required(ErrorMessage = "{0} Boş Bırakılamaz!")]
        public string Adi { get; set; }
    }
}

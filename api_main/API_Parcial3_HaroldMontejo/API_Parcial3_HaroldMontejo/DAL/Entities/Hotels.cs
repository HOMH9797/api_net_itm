using System.ComponentModel.DataAnnotations;

namespace API_Parcial3_HaroldMontejo.DAL.Entities
{
    public class Hotels : AuditBase
    {
        [Display(Name = "Hotel"), Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        public string Name { get; set; }
        [Display(Name = "Dirección"), Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Address { get; set; }
        [Display(Name = "Teléfono"), Required(ErrorMessage = "El campo {0} es obligatorio")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El número de teléfono debe tener 10 dígitos")]
        public string Phone { get; set; }
        [Display(Name = "Estrellas"), Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Range(0, 5, ErrorMessage = "El valor debe estar entre 0 y 5")]
        public int Start { get; set; }
        [Display(Name = "Ciudad"),Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string City { get; set; }
    }
}

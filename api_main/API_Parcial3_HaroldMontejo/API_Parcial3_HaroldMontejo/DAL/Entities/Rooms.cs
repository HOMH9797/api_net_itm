using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API_Parcial3_HaroldMontejo.DAL.Entities
{
    public class Rooms : AuditBase
    {
        [Display(Name = "Número"), Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Range(100, int.MaxValue, ErrorMessage = "El valor debe ser como minimos 100")]
        public int Number { get; set; }

        [Display(Name = "Máximo Guespedes"), Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El valor minimo de ser 1")]
        public int MaxGuests { get; set; }

        [Display(Name = "Habilitada")]
        [DefaultValue(true)]
        public bool Availability { get; set; }
    }
}

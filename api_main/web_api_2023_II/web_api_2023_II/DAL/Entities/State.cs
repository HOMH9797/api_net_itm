using System.ComponentModel.DataAnnotations;

namespace web_api_2023_II.DAL.Entities
{
    public class State : AuditBase
    {
        [Display(Name = "Estado/Departamento")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres")]
        [Required(ErrorMessage = "!El campo {0} es obligatorio!")]
        public string Name { get; set; }
        [Display(Name = "País")]
        public Country? Country { get; set; }
        [Display(Name = "Id País")]
        public Guid CountryId { get; set; }
    }
}

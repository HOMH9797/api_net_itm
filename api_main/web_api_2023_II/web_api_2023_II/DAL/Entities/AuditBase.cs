using System.ComponentModel.DataAnnotations;

namespace web_api_2023_II.DAL.Entities
{
    public class AuditBase
    {
        [Key] // DataAnnotation me sirve para definir que esta propiedad ID es un PK
        [Required] // Para los campos obligatorios, o sea que deben tener un valor (no permite nulls)
        public Guid Id { get; set; } // Sera la PK de todas las tablas de mi DB 
        public DateTime? CreatedDate { get; set; } // Campos nullables, notacion elivs (?)
        public DateTime? ModifiedDate { get; set;} 
    }
}

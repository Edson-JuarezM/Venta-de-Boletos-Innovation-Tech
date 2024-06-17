using SuperChampiniones.Dto;
using System.ComponentModel.DataAnnotations;

namespace SuperChampiniones.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required,MinLength(5)]
        public string? Email { get; set; }
        [Required,MinLength(4)]
        public string? Password { get; set; }
        [Required,MinLength(3)]
        public string? Nombre { get; set; }
        public RolEnum Rol { get; set; }

        public virtual List<Venta>?Ventas { get; set; }
    }
        
}

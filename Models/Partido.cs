using System.ComponentModel.DataAnnotations;

namespace SuperChampiniones.Models
{
    public class Partido
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(3)]
        public string? EquipoA { get; set; }
        [Required, MinLength(3)]
        public string? EquipoB { get; set; }

        public DateTime? Fecha_Hora { get; set; }
        public string? UrlEscudA { get; set; }
        public string? UrlEscudB { get; set; }
        public virtual List<Venta>? Ventas { get; set; }
    }
}

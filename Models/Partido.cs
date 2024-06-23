using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string? UrlEscudoA { get; set; }
        public string? UrlEscudoB { get; set; }
        //para archivos
        [NotMapped]
        [Display (Name ="Cargar Escudo 1")]
        public IFormFile? EscudoFile1 { get; set; }
        [NotMapped]
        [Display(Name = "Cargar Escudo 2")]
        public IFormFile? EscudoFile2 { get; set; }
        public virtual List<Venta>? Ventas { get; set; }
    }
}

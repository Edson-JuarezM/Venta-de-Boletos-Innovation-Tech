using SuperChampiniones.Dto;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperChampiniones.Models
{

    public class Venta
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int NroRecibo { get; set; }
        public SectorEnum? Sector { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Fecha { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        [Required]
        public int? PartidoId { get; set; }
        public int? Miembro_VipId { get; set; }
        public virtual Miembro_Vip? Miembro_Vip { get; set; }
        public virtual Usuario? Usuario { get; set; }
        public virtual Partido? Partido { get; set; }
    }
    public class ReporteViewModel
    {
        [NotMapped]
        public int Mes { get; set; }
        public int Ventas { get; set; }
        public decimal Total { get; set; }
    }
    public enum SectorEnum
    {
        Preferencia,
        General,
        CurvaNorte,
        CurvaSur
    }
}

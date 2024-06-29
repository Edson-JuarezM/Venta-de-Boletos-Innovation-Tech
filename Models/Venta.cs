using SuperChampiniones.Dto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperChampiniones.Models
{
    public class Venta
    {
        [Key]
        public int Id { get; set; }
        public int NroRecibo { get; set; }

        public SectorEnum? Sector { get; set; }
        [Column(TypeName ="date")]
        public DateTime? Fecha { get; set; }
        public int UsuarioId { get; set; }
        public int Miembro_VipId { get; set; }
        public int PartidoId { get; set; }
        
        public virtual Usuario? Usuario { get; set; }
        public virtual Miembro_Vip? Miembro_Vip { get; set; }
        public virtual Partido?  Partido{ get; set; }
    }
}

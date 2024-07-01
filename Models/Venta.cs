﻿using SuperChampiniones.Dto;
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
        public int? Miembro_VipId { get; set; }
        [Required]
        public int PartidoId { get; set; }
        public Usuario? Usuario { get; set; }
        public Partido? Partido { get; set; }
        public Miembro_Vip? Miembro_Vip { get; set; }
    }
    public enum SectorEnum
    {
        Preferencia,
        General,
        CurvaNorte,
        CurvaSur
    }
}

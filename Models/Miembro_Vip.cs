﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperChampiniones.Models
{
    public class Miembro_Vip
    {
        [Key] //llave primaria
        public int Id { get; set; }
        [Required,MinLength(3)]
        public string? Nombre { get; set; }

        [Required,MinLength(7),MaxLength(8)]
        public string? Ci { get; set; }
        [Required]
        public int? Celular { get; set; }

        [Display(Name = "Fecha de Registro")]
        public DateTime FechaRegistro { get; set; }

        public decimal Saldo { get; set; }
        [NotMapped]
        public decimal montoRecarga { get; set; }
        public virtual List<Venta>? Ventas { get; set; } 

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

#nullable disable // Para quitar el aviso de nulls
 
namespace ProyectoFinal.Models   
{
    public class EstadoVenta // Entidad Estado de Venta
    {
        [Key]  
        public int EstadoVentaId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio. Seleccione el estado de venta")]
        public string EstadoDeVenta { get; set; } // Estado
        public bool Estado { get; set; } = true;     

    }
}
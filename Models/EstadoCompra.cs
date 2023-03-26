using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

#nullable disable // Para quitar el aviso de nulls
 
namespace ProyectoFinal.Models   
{
    public class EstadoCompra // Entidad Estado de Compra
    {
        [Key]  
        public int EstadoCompraId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio. Seleccione el estado de compra")]
        public string EstadoDeCompra { get; set; } // Estado
        public bool Estado { get; set; } = true;     

    }
}
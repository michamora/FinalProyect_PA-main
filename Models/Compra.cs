using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

#nullable disable // Para quitar el aviso de nulls
 
namespace ProyectoFinal.Models  
{
    public class Compra // Entidad 
    {
        [Key]
        public int CompraId { get; set; }   

        [DataType(DataType.Date)]  
        public DateTime Fecha { get; set; } 
        public decimal Total { get; set; }
        public decimal ITBIS { get; set; }
        public decimal SubTotal { get; set; }
        public double Existencia { get; set; }
        public double UnidadesVendidas { get; set;}

        [Required(ErrorMessage = "Ingrese el monto a pagar.")]
        public decimal PagoObtenido { get; set;}

        public decimal MontoRestante { get; set;}

        public decimal MetodoDePago { get; set;}

        public bool Estado { get; set; } = true;



        //-------------------------------------------------------------------------------------

        [ForeignKey("PagoId")]
        public virtual Pago Pago { get; set; } 

        
        [ForeignKey("CompraId")]
        public virtual List<CompraDetalle> compraDetalle { get; set; } 

        public Compra()
        {
            CompraId = 0;
            Fecha = DateTime.Now;
            ITBIS = 0;
            SubTotal = 0;
            Total = 0;
            Existencia = 0;

            compraDetalle = new List<CompraDetalle>();
        }
    }
}
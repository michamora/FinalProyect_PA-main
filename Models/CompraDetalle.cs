using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 
#nullable disable // Para quitar el aviso de nulls

namespace ProyectoFinal.Models
{
    public class CompraDetalle // Detalles de la venta
    {
        [Key]
       
        public int Id { get; set; }

        public int CompraId { get; set; }

        public int SuplidorId { get; set; }
     
        public int ArticuloId { get; set; }

        public int PagoId { get; set; }

        public string NombreDetalle { get; set; }
        public double CantidadDetalle { get; set; }
        public decimal PrecioDetalle { get; set; }
        public decimal ImporteDetalle { get; set; }
        

        public virtual Articulo articulo {get; set;}

        public Compra compra { get; set; } = new Compra();
        


        //-------------------------------------------------------------------------------------


        public CompraDetalle()
        {
            Id = 0;
            CompraId = 0;
            SuplidorId = 0;
            ArticuloId = 0;
            PagoId = 0;
            NombreDetalle ="";
            CantidadDetalle = 0;
            PrecioDetalle = 0;
            ImporteDetalle = 0;
        }

        public CompraDetalle(int id, int compraId, int suplidorId, int articuloId, int pagoid, string nombreDetalle, double cantidadDetalle, decimal precioDetalle, decimal importeDetalle)
        {
            Id = id;
            CompraId = CompraId;
            SuplidorId = suplidorId;
            ArticuloId = articuloId;
            PagoId = pagoid;
            NombreDetalle = nombreDetalle;
            CantidadDetalle = cantidadDetalle;
            PrecioDetalle = precioDetalle;
            ImporteDetalle = importeDetalle;

        }
    }
}
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 
#nullable disable // Para quitar el aviso de nulls

namespace ProyectoFinal.Models
{
    public class VentasDetalle // Detalles de la venta
    {
        [Key]
       
        public int Id { get; set; }
      
        public int VentaId { get; set; }
     
        public int ClienteId { get; set; }
            

        public int CompraId { get; set; }

        public int PagoId { get; set; }

        public int SuplidorId { get; set; }
        
        public double Cantidad { get; set; }

        public decimal PrecioArticuloComprado { get; set; }

        public string Descripcion { get; set; }

        public decimal Importe { get; set; }

        public virtual Articulo articulo {get; set;}

        public virtual Compra compra {get; set;}

        public Ventas venta { get; set; } = new Ventas();


        //-------------------------------------------------------------------------------------


        public VentasDetalle()
        {
            Id = 0;
            VentaId = 0;
            ClienteId = 0;
        
            CompraId = 0;
            SuplidorId = 0;
            PagoId = 0;
            Cantidad = 0;    
            PrecioArticuloComprado = 0;  
            Descripcion = string.Empty;  
        }

        public VentasDetalle(int id, int ventaId, int clienteId, int suplidorId, int compraId, int pagoid, int cantidad, decimal precioArticuloComprado, string descripcion)
        {
            Id = id;
            VentaId = ventaId;
            ClienteId = clienteId;
            SuplidorId = suplidorId;
    
            CompraId = compraId;
            PagoId = pagoid;
            Cantidad = cantidad;
            PrecioArticuloComprado = precioArticuloComprado;
            Descripcion = descripcion;
        }
    }
}
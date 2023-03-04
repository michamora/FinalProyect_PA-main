using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


#nullable disable // Para quitar el aviso de nulls

namespace ProyectoFinal.Models  
{
    public class Compra // Entidad Compra
    {
        [Key]  
        public int CompraId { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime FechaCompra { get; set; }
        public int ArticuloId { get; set; }
        public int SuplidorId { get; set; }

        [Required]
        [Range(1, float.MaxValue, ErrorMessage = "Ingrese la cantidad a comprar del articulo.")]
        public double CantidadComprada { get; set; }

        [Required]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Ingrese un precio mayor a 0.")]
        public decimal Precio { get; set; }

        public bool Estado { get; set; } = true;

        public int UsuarioId { get; set; }

        //-------------------------------------------------------------------------------------

        [ForeignKey("ArticuloId")]
        public virtual Articulo Articulo{ get; set; }

        [ForeignKey("SuplidorId")]
        public virtual Suplidor Suplidor{ get; set; }

        [ForeignKey("CompraId")]
        public List<VentasDetalle> VentasDetalle { get; set; }
        

        public Compra()
        {
            ArticuloId = 0;
            SuplidorId = 0;
            UsuarioId = 0; 
            FechaCompra = DateTime.Now;
            CantidadComprada = 0;
            Precio = 0;
            
            VentasDetalle = new List<VentasDetalle>();
        }    

        public Compra(int articuloId, int suplidorId, int usuarioId, int fechaCompra, double cantidadComprada, decimal precio)
        {
   
            SuplidorId = suplidorId;
            ArticuloId = articuloId;
            UsuarioId = usuarioId;
            FechaCompra = DateTime.Now;
            CantidadComprada = cantidadComprada;
            Precio = precio;
          
        }
    }
}
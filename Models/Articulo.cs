using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


#nullable disable // Para quitar el aviso de nulls

namespace ProyectoFinal.Models  
{
    public class Articulo // Entidad Articulo
    {
        [Key]  
        public int ArticuloId { get; set; }

        [Required(ErrorMessage = "Campo suplidor es obligatorio.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Seleccione el suplidor del articulo.")]         
        public int SuplidorId { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre del articulo.")]
        public string Nombre { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }

        [Required(ErrorMessage = "Campo categoria es obligatorio.")]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Seleccione la categoria del articulo.")] 
        public int CategoriaId { get; set; }

        [Required]
        [Range(1, float.MaxValue, ErrorMessage = "Ingrese la cantidad del articulo.")]
        public double CantidadRegistrada { get; set; }

        [Required]
        [Range(1, float.MaxValue, ErrorMessage = "Ingrese la cantidad a comprar del articulo.")]
        public double CantidadComprada { get; set; }

        [Required]
        [Range(1, float.MaxValue, ErrorMessage = "Ingrese la cantidad a aumentar del articulo.")]
        public double CantidadAumentada { get; set; }

        [Required]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Ingrese un costo mayor a 0.")]
        public decimal Costo { get; set; }

        [Required]
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Ingrese un precio mayor a 0.")]
        public decimal Precio { get; set; }

        public bool Estado { get; set; } = true;

        public int UsuarioId { get; set; }
        

        //-------------------------------------------------------------------------------------

        [ForeignKey("CategoriaId")]
        public virtual Categoria Categoria { get; set; }

        public virtual Suplidor Suplidor { get; set; }

        public Articulo()
        {
            ArticuloId = 0;
            UsuarioId = 0; 
            SuplidorId = 0;
            CategoriaId = 0;
            Nombre = string.Empty;
            FechaCreacion = DateTime.Now;
            CantidadRegistrada = 0;
            CantidadComprada = 0;
            Costo = 0;
            Precio = 0;
        }     
    }
}
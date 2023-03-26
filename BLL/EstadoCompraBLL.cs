using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Models;
using ProyectoFinal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


#nullable disable // Para quitar el aviso de nulls

namespace ProyectoFinal.BLL // BLL Para el estado de compra
{
    public class EstadoCompraBLL
    {
        private ApplicationDbContext contexto;

        public EstadoCompraBLL(ApplicationDbContext _contexto)
        {
            contexto = _contexto;
        }

        public async Task<EstadoCompra> Buscar(int id)
        {
            EstadoCompra estadoCompra = new EstadoCompra();

            try
            {
                estadoCompra = await contexto.EstadoCompra.FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
            return estadoCompra;
        }


        public List<EstadoCompra> GetList(Expression<Func<EstadoCompra, bool>> estadoCompra)
        {
            List<EstadoCompra> Lista = new List<EstadoCompra>();
            try
            {
                Lista = contexto.EstadoCompra
                .Where(p => p.Estado == true)
                .Where(estadoCompra)
                .AsNoTracking()
                .ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        }
    }
}

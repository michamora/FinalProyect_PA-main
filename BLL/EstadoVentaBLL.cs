using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Models;
using ProyectoFinal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


#nullable disable // Para quitar el aviso de nulls

namespace ProyectoFinal.BLL // BLL Para el estado de venta
{
    public class EstadoVentaBLL
    {
        private ApplicationDbContext contexto;

        public EstadoVentaBLL(ApplicationDbContext _contexto)
        {
            contexto = _contexto;
        }

        public async Task<EstadoVenta> Buscar(int id)
        {
            EstadoVenta estadoVenta = new EstadoVenta();

            try
            {
                estadoVenta = await contexto.EstadoVenta.FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
            return estadoVenta;
        }


        public List<EstadoVenta> GetList(Expression<Func<EstadoVenta, bool>> estadoVenta)
        {
            List<EstadoVenta> Lista = new List<EstadoVenta>();
            try
            {
                Lista = contexto.EstadoVenta
                .Where(p => p.Estado == true)
                .Where(estadoVenta)
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

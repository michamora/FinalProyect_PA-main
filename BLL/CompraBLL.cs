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

namespace ProyectoFinal.BLL
{
    public class CompraBLL // BLL para Compra
    {
        private ApplicationDbContext contexto;

        public CompraBLL(ApplicationDbContext _contexto)
        {
            contexto = _contexto;
        }

        private bool Existe(int id)
        {
            try
            {
                return contexto.Compra.AsNoTracking().Any(p => p.CompraId == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Guardar(Compra compra)
        {
        
            if (!Existe(compra.CompraId))
                return  Insertar(compra);
            else
                return  Modificar(compra);
        }

        private bool Insertar(Compra compra)
        { 
            bool Insertado = false;

            try
            {
                if (contexto.Compra.Add(compra) != null)
                {
                    foreach (var item in compra.compraDetalle)
                    {
                        item.articulo.CantidadRegistrada -= item.CantidadDetalle;
                    }
                    Insertado =  contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Insertado;
        }

        private bool Modificar(Compra compra)
        {
            bool Insertado = false;

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM CompraDetalle Where CompraId = {compra.CompraId}");
                foreach (var item in compra.compraDetalle)
                {
                    contexto.Entry(item).State = EntityState.Added;

                    item.articulo.CantidadRegistrada -= item.CantidadDetalle;
                }

                contexto.Entry(compra).State = EntityState.Modified;
                Insertado =  contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return Insertado;
        }

        public Compra Buscar(int id)
         {
            Compra compra;

            try
            {
                compra = contexto.Compra
                .Include( e => e.compraDetalle)
                .Where( e => e.CompraId == id && e.Estado == true).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            return compra;
        }

    
        public bool Eliminar(int id)
        {
            bool paso = false;

            try
            {           
               var compra = Buscar(id);

                if (compra != null)
                {      

                    foreach (var item in compra.compraDetalle)
                    {
                        item.articulo.CantidadRegistrada += item.CantidadDetalle;
                    }

                    compra.Estado = false;
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

         public List<Compra> GetList(Expression<Func<Compra, bool>> compra)
        {
            List<Compra> Lista = new List<Compra>();
            try
            {
                Lista =  contexto.Compra
                .Where(v => v.Estado == true)
                .Where(compra)
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

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
    public class CompraBLL // BLL Para Compra
    {
        private ApplicationDbContext contexto;

        public CompraBLL(ApplicationDbContext _contexto)
        {
            contexto = _contexto;
        }

        private bool Existe(int id)
        {
            bool existe = false;

            try
            {
                existe = contexto.Compra.Any(c => c.CompraId == id);
            }
            catch (Exception)
            {
                throw;
            }
            return existe;
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
                contexto.Entry(compra).State = EntityState.Modified;
                Insertado = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            return Insertado;
        }

        public Compra Buscar(int id)
        {
            return contexto.Compra
                .Where(a => a.CompraId == id && a.Estado == true)
                .SingleOrDefault();
        }

        public bool Eliminar(int id)
        {
            bool Eliminado = false;

            try
            {
                var compra = Buscar(id);

                if (compra!= null)
                {
                    compra.Estado = false;
                    Eliminado = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Eliminado;
        }

        public List<Compra> GetList(Expression<Func<Compra, bool>> compra)
        {
            List<Compra> Lista = new List<Compra>();
            try
            {
                Lista = contexto.Compra
                .Where(a => a.Estado == true)
                .Where(compra)
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

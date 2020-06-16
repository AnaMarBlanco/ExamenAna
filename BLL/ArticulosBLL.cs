using AnaMPrimerParcial.DAL;
using AnaMPrimerParcial.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnaMPrimerParcial.BLL
{
    class ArticulosBLL
    {
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
              
                var Articulo = contexto.Articulos.Find(id);
                if (Articulo != null)
                {
                    contexto.Articulos.Remove(Articulo);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static Articulos Buscar(int Id)
        {
            Contexto contexto = new Contexto();
            Articulos Articulo;

            try
            {
                Articulo = contexto.Articulos.Find(Id);
            }
            catch (Exception)
            {

                throw;
            }
            contexto.Dispose();
            return Articulo;


        }
        public static bool Guardar(Articulos Articulo)
        {
            if (!Existe(Articulo.ArticuloID))
                return Insertar(Articulo);
            else
                return Modificar(Articulo);
        }
        public static bool Modificar(Articulos Articulo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(Articulo).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static bool Insertar(Articulos Articulo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
              
                contexto.Articulos.Add(Articulo);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }


       
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Articulos
                .Any(e => e.ArticuloID == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado; 
        }
    }
}

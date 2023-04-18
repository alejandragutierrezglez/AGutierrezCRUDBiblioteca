using DL;
using ML;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Libro
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezBibliotecaEntities context = new DL.AGutierrezBibliotecaEntities())
                {
                    var query = context.LibroGetAll().ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var resultLibro in query)
                        {
                            ML.Libro libro = new ML.Libro();
                            libro.IdLibro = resultLibro.IdLibro;
                            libro.Nombre = resultLibro.Nombre;
                            libro.FechaPublicacion = resultLibro.FechaPublicacion.Value;
                            libro.NumeroPaginas = resultLibro.NumeroPaginas.Value;
                            libro.Autor = new ML.Autor();
                            libro.Autor.IdAutor = resultLibro.IdAutor.Value;

                            result.Objects.Add(libro);
                        }
                        result.Correct = true;
                    }
                }
            }


            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Correct = false;
                result.Ex = ex;

            }
            return result;


        }

        public static ML.Result GetById(int IdLibro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezBibliotecaEntities context = new DL.AGutierrezBibliotecaEntities())
                {
                    var query = context.LibroGetById(IdLibro).FirstOrDefault();

                    if (query != null)
                    {
                        ML.Libro libro = new ML.Libro();
                        libro.IdLibro = query.IdLibro;
                        libro.Nombre = query.Nombre;
                        libro.FechaPublicacion = query.FechaPublicacion.Value;
                        libro.NumeroPaginas = query.NumeroPaginas.Value;
                        libro.Autor = new ML.Autor();
                        libro.Autor.IdAutor = query.IdAutor.Value;

                        result.Object = libro;

                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Correct = false;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Add(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezBibliotecaEntities context = new DL.AGutierrezBibliotecaEntities())
                {
                    int query = context.LibroAdd(libro.Nombre, libro.FechaPublicacion, libro.NumeroPaginas, libro.Autor.IdAutor);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Update(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezBibliotecaEntities context = new DL.AGutierrezBibliotecaEntities())           
                {
                    int query = context.LibroUpdate(libro.IdLibro, libro.Nombre, libro.FechaPublicacion, libro.NumeroPaginas, libro.Autor.IdAutor);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;

        }

        public static ML.Result Delete(int IdLibro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezBibliotecaEntities context = new DL.AGutierrezBibliotecaEntities()) 
                {
                    int query = context.LibroDelete(IdLibro);                    

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }


    }
}

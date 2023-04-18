using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Autor
    {
        public static ML.Result GetAll()

        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AGutierrezBibliotecaEntities context = new DL.AGutierrezBibliotecaEntities())

                {
                    var query = context.AutorGetAll().ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var resultAutor in query)
                        {
                            ML.Autor autor = new ML.Autor();
                            autor.IdAutor= resultAutor.IdAutor;
                            autor.ApellidoPaterno= resultAutor.ApellidoPaterno;
                            autor.ApellidoMaterno = resultAutor.ApellidoMaterno;
                            autor.Nombre = resultAutor.Nombre;
                           

                            result.Objects.Add(autor);
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
    }
}

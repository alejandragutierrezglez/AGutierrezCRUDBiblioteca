using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class LibroController : Controller
    {
        // GET: Libro


        public ActionResult GetAll()
        {
            ML.Result result = new ML.Result();
            ML.Libro libro = new ML.Libro();

            ServiceReferenceLibro.ServiceLibroClient serviceLibro = new ServiceReferenceLibro.ServiceLibroClient();
            result = serviceLibro.GetAll();

            if (result.Correct)
            {
                libro.Libros = result.Objects;
            }
            else
            {
                result.Correct = false;
            }

            return View(libro);
        }
        public ActionResult Delete(int IdLibro)
        {
            ML.Result result = new ML.Result();
            ServiceReferenceLibro.ServiceLibroClient serviceLibro = new ServiceReferenceLibro.ServiceLibroClient();
            serviceLibro.Delete(IdLibro);

            if (result.Correct)
            {
                ViewBag.Message = "Se ha eliminado el registro";
                return PartialView("Modal");
            }
            else
            {
                ViewBag.Message = "No se ha eliminado el registro";
                return PartialView("Modal");
            }          


        }

        public ActionResult Form()
        {
            ML.Libro libro = new ML.Libro();


            return View(libro);
        }
    }
}
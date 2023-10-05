using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        public ActionResult GetAll()
        {
            ML.Result result = BL.Materia.GetAllEF();

            ML.Materia materia = new ML.Materia();  

            materia.Materias = new List<object>();

            if (result.Correct)
            {
                materia.Materias = result.Objects;
                return View(materia);
            }
            else
            {
                ViewBag.Message = result.Message;
                return View(materia);
            }
            
        }

        [HttpGet]//Abre la vista o el formulario
        public ActionResult Form(byte? IdMateria) 
        { 
            if (IdMateria == null)
            {
                //add
                //Mostrar un formulario vacio
                ViewBag.Accion = "Agregar";
                return View();
            }
            else
            {
                //GetbyId
                ML.Result result = BL.Materia.GetByIdEF(IdMateria.Value);
                ML.Materia materia = new ML.Materia();
                if (result.Correct)
                {
                    materia = (ML.Materia)result.Object;//Unboxing
                }
                //Mostrar un formulario con los datos del registro seleccionado
                ViewBag.Accion = "Actualizar";
                return View(materia);
            }
          
            
        }

        [HttpPost]//recibe la información que viene desde el formulario
        public ActionResult Form(ML.Materia materia)
        {

            HttpPostedFileBase file = Request.Files["Image"];

            if (file.ContentLength > 0)
            {
                materia.Imagen = ConvertToBytes(file);

                string imagenBase64 = Convert.ToBase64String(materia.Imagen);
            }

                ML.Result result = new ML.Result();

            if (materia.IdMateria == 0)
            {
                //add
                result = BL.Materia.AddEF(materia);

                if (result.Correct)
                {
                     ViewBag.Mensaje = result.Message;
                    return View("Modal");
                }
                else
                {
                    ViewBag.Mensaje = result.Message;
                    return View("Modal");
                }
               
                
            }
            else
            {
                //Update

                result = BL.Materia.UpdateEF(materia);

                if (result.Correct)
                {
                    ViewBag.Mensaje = result.Message;
                    return View("Modal");
                }
                else
                {
                    ViewBag.Mensaje = result.Message;
                    return View("Modal");
                }
               
            }


        }

        public byte[] ConvertToBytes(HttpPostedFileBase Imagen)
        {
            byte[] data = null;
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Imagen.InputStream);
            data = reader.ReadBytes((int)Imagen.ContentLength);

            return data;
        }
    }
}
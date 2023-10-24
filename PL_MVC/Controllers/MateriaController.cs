using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Materia materia = new ML.Materia();
            materia.Semestre = new ML.Semestre();
            ML.Result resultSemestre = BL.Semestre.GetAll();

            materia.Nombre = (materia.Nombre==null)?"":materia.Nombre;
            materia.Creditos = (materia.Creditos==null)? byte.Parse(""):materia.Creditos;
            ML.Result result = BL.Materia.GetAllEF(materia);

            materia.Semestre.Semestres = resultSemestre.Objects;

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

        [HttpPost]
        public ActionResult GetAll(ML.Materia materia)
        {
             

            materia.Nombre = (materia.Nombre == null) ? "" : materia.Nombre;
            materia.Creditos = (materia.Creditos == null) ? byte.Parse("") : materia.Creditos;
            ML.Result result = BL.Materia.GetAllEF(materia);



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
            ML.Materia materia = new ML.Materia(); //global

            materia.Semestre = new ML.Semestre();
            materia.Grupo = new ML.Grupo();
            materia.Grupo.Plantel = new ML.Plantel(); //Pais

            ML.Result resultSemestre = BL.Semestre.GetAll(); //DDL Independientes
            ML.Result resultPlantel = BL.Plantel.GetAll();

            materia.Semestre.Semestres = resultSemestre.Objects;
            materia.Grupo.Plantel.Planteles = resultPlantel.Objects;

            if (IdMateria == null)
            {
                //add
                //Mostrar un formulario vacio
               
                ViewBag.Accion = "Agregar";
                return View(materia);
            }
            else
            {
                //GetbyId
                ML.Result result = BL.Materia.GetByIdEF(IdMateria.Value);
                
                if (result.Correct)
                {
                    materia = (ML.Materia)result.Object;//Unboxing
                    materia.Semestre.Semestres = resultSemestre.Objects;

                    materia.Grupo = new ML.Grupo();
                    materia.Grupo.Plantel = new ML.Plantel();
                    materia.Grupo.Plantel.Planteles = resultPlantel.Objects;
                }
                //Mostrar un formulario con los datos del registro seleccionado
                ViewBag.Accion = "Actualizar";
                return View(materia);
            }
          
            
        }

        [HttpPost]//recibe la información que viene desde el formulario
        public ActionResult Form(ML.Materia materia, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                
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
            else
            {
                ML.Result resultSemestre = BL.Semestre.GetAll(); //DDL Independientes
                ML.Result resultPlantel = BL.Plantel.GetAll();

                materia.Semestre.Semestres = resultSemestre.Objects;
                materia.Grupo.Plantel.Planteles = resultPlantel.Objects;
                return View(materia);
            }
            


        }

        [HttpGet]
        public ActionResult Delete(byte IdMateria)
        {
            ML.Result result = BL.Materia.DeleteEF(IdMateria);

            if (result.Correct)
            {
                ViewBag.Mensaje = "La materia se ha eliminado correctamente";
            }
            else
            {
                ViewBag.Mensaje = "La materia no se ha eliminado correctamente " + result.Message;
            }

            return PartialView("Modal");
        }

        public byte[] ConvertToBytes(HttpPostedFileBase Imagen)
        {
            byte[] data = null;
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Imagen.InputStream);
            data = reader.ReadBytes((int)Imagen.ContentLength);

            return data;
        }

        public JsonResult GetGrupos(int IdPlantel)
        {
            var result = BL.Grupo.GetByIdPlantel(IdPlantel);

            return Json(result.Objects);
        }

        [HttpPost]
        public JsonResult CambiarStatus(byte idMateria, bool estatus)
        {
            ML.Result result = BL.Materia.ChangeStatus(idMateria, estatus);

            return Json(result);
        }

        [HttpGet]
        public ActionResult CargaMasiva()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CargaMasiva(HttpPostedFileBase cargaMasiva)
        {
            //var archivo = System.IO.File.OpenText(cargaMasiva.ContentType);
            using (StreamReader file = new StreamReader(cargaMasiva.InputStream))
            {

                string row = file.ReadLine();

                while (!file.EndOfStream)
                {
                    row = file.ReadLine();

                    string[] rowFinal = row.Split('|');

                    ML.Materia materia = new ML.Materia();

                    materia.Nombre = rowFinal[0];
                    materia.Creditos = byte.Parse(rowFinal[1]);
                    materia.Costo = decimal.Parse(rowFinal[2]);

                    materia.Semestre = new ML.Semestre();
                    materia.Semestre.IdSemestre = byte.Parse(rowFinal[3]);

                    materia.Grupo = new ML.Grupo();
                    materia.Grupo.IdGrupo = int.Parse(rowFinal[4]);

                    ML.Result result = BL.Materia.AddEF(materia);

                    if (result.Correct)
                    {

                    }
                    else
                    {
                        
                    }

                }
            }

                return View();
        }


    }
}
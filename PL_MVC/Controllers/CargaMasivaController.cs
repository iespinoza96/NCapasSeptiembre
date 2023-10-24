using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class CargaMasivaController : Controller
    {
        // GET: CargaMasiva
        [HttpGet]
        public ActionResult Carga()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Carga(HttpPostedFileBase excel)
        {
            if (excel != null) 
            {
                string extensionArchivo = Path.GetExtension(excel.FileName).ToLower();
                string extesionValida = ConfigurationManager.AppSettings["TipoExcel"];

                if (extensionArchivo == extesionValida)
                {
                    string rutaproyecto = Server.MapPath("~/MateriaCarga/");
                    string filePath = rutaproyecto + Path.GetFileNameWithoutExtension(excel.FileName) + '-' + DateTime.Now.ToString("yyyyMMddHHmmss") + extesionValida;

                    if (!System.IO.File.Exists(filePath))
                    {

                        excel.SaveAs(filePath); //crear copia

                        string connectionStringExcel = ConfigurationManager.AppSettings["ConnectionString"];


                    }

                }
                else
                {
                    ViewBag.Mensaje = "Por favor seleccione un archivo tipo .xlsx";
                    return View("Modal");
                }
            }
            else
            {
                ViewBag.Mensaje = "Por favor seleccione un archivo";
                return View("Modal");
            }
            return View();
        }


    }
}
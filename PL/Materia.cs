using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Materia
    {
        //5 metodos ADD,UPDATE, DELETE, GETALL Y GETBYID
        public static void Add()
        {
            ML.Materia materia = new ML.Materia();

            //Console.WriteLine("Ingrese un ID para el alumno:");
            //materia.IdMateria = byte.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese un nombre:");
            materia.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese los creditos:");
            materia.Creditos = byte.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el costo:");
            materia.Costo = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el id del semestre:");
            materia.Semestre = new ML.Semestre();
            materia.Semestre.IdSemestre = byte.Parse(Console.ReadLine());//fk
            //enviar información




            //ML.Result result  = BL.Materia.Add(materia); //QUERY
            //ML.Result result  = BL.Materia.AddSP(materia); //SP
            //ML.Result result  = BL.Materia.AddEF(materia); //EF
            ML.Result result  = BL.Materia.AddLINQ(materia); //LINQ

            if (result.Correct)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        public static void Update()
        {
            ML.Materia materia = new ML.Materia();

            Console.WriteLine("Ingrese un ID para el alumno:");
            materia.IdMateria = byte.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese un nombre:");
            materia.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese los creditos:");
            materia.Creditos = byte.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el costo:");
            materia.Costo = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el id del semestre:");
            materia.Semestre = new ML.Semestre();
            materia.Semestre.IdSemestre = byte.Parse(Console.ReadLine());//fk


            //ML.Result result = BL.Materia.Update(materia);
            //ML.Result result = BL.Materia.UpdateEF(materia);//EF
            ML.Result result = BL.Materia.UpdateLINQ(materia);//LINQ

            if (result.Correct)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        public static void GetAll()
        {
           // ML.Result result = BL.Materia.GetAll(); //SQL Client SP
            //ML.Result result = BL.Materia.GetAllEF(); //EF
            ML.Result result = BL.Materia.GetAllLINQ(); //LINQ

            if (result.Correct)
            {
                foreach (ML.Materia materia in result.Objects)
                {
                    Console.WriteLine("********************************************");

                    Console.WriteLine("El ID de la materia es: " + materia.IdMateria);
                    Console.WriteLine("El nombre de la materia es: " + materia.Nombre);
                    Console.WriteLine("Los creditos de la materia es: " + materia.Creditos);
                    Console.WriteLine("El costo de la materia es: " + materia.Costo);
                    Console.WriteLine("El Id del semestre es: " + materia.Semestre.IdSemestre);
                    Console.WriteLine("El nombre del semestre es: " + materia.Semestre.Nombre);

                   
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //PL.Alumno alumno = new PL.Alumno();

            //alumno.Add(); //cuando el metodo no es static

            //PL.Materia.Add(); //cuando el metodo es static
            //PL.Materia.Update(); //cuando el metodo es static
            PL.Materia.GetAll(); //cuando el metodo es static
            Console.ReadKey();
        }
    }
}

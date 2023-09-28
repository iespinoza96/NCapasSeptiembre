using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Materia
    {
        public byte IdMateria { get; set; }
        public string Nombre { get; set; }
        public byte Creditos { get; set; }
        public decimal Costo { get; set; }

        public ML.Semestre Semestre { get; set; } //Propiedad de navegación 
        //public byte IdSemestre { get; set; }


    }
}

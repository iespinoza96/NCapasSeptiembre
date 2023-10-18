using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Materia
    {
        public byte IdMateria { get; set; }

        [Required]
        [DisplayName("Nombre:")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage="Solo se aceptan letras")]
        
        public string Nombre { get; set; }

        [Required]
        public byte Creditos { get; set; }

        [Required]
        public decimal Costo { get; set; }
        //public string Imagen { get; set; }
        public byte[] Imagen { get; set; }
        public bool Estatus { get; set; }

        public ML.Semestre Semestre { get; set; } //Propiedad de navegación 
        //public byte IdSemestre { get; set; }

        public ML.Grupo Grupo { get; set; }

        public List<object> Materias { get; set; }

    }
}

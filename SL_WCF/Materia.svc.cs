using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Materia" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Materia.svc or Materia.svc.cs at the Solution Explorer and start debugging.
    public class Materia : IMateria
    {
        public ML.Result Add(ML.Materia materia)
        {
            ML.Result result = BL.Materia.AddEF(materia);

            return result;
        }

        public ML.Result Update(ML.Materia materia)
        {
            ML.Result result = BL.Materia.UpdateEF(materia);

            return result;
        }

        public ML.Result Delete(byte idMateria)
        {
            ML.Result result = BL.Materia.DeleteEF(idMateria);

            return result;
        }

        public ML.Result GetAll()
        {
            ML.Result result = BL.Materia.GetAllLINQ();

            return result;
        }
        public void DoWork()
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Grupo
    {
        public static ML.Result GetByIdPlantel(int idPlantel)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasGSEntities context = new DL_EF.IEspinozaProgramacionNCapasGSEntities())
                {
                    var query = context.GrupoGetByIdPlantel(idPlantel).ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var row in query)
                        {
                            ML.Grupo grupo = new ML.Grupo();

                            grupo.IdGrupo = row.IdGrupo;
                            grupo.Nombre = row.Nombre;

                            grupo.Plantel = new ML.Plantel();
                            grupo.Plantel.IdPlantel = row.IdPlantel.Value;

                            result.Objects.Add(grupo);
                        }

                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al realizar la consulta en la base de datos " + result.Ex;
                throw;
            }

            return result;
        }
    }
}

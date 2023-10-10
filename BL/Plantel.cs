﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Plantel
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasGSEntities context = new DL_EF.IEspinozaProgramacionNCapasGSEntities())
                {
                    var query = context.PlantelGetAll().ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var row in query)
                        {
                            ML.Plantel plantel = new ML.Plantel();

                            plantel.IdPlantel = row.IdPlantel;
                            plantel.Nombre = row.Nombre;


                            result.Objects.Add(plantel);
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

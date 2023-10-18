using ML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Materia
    {
        //13 metodos  2 ADD,2 UPDATE, 2 DELETE, GETALL Y GETBYID
        //QUERY
        public static ML.Result Add(ML.Materia materia)
        {

            ML.Result result = new ML.Result();

            try
            {
                string query = "INSERT INTO Materia (Nombre,Creditos,Costo) VALUES (@Nombre,@Creditos,@Costo)";

                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    context.Open();

                    using (SqlCommand cmd = new SqlCommand(query, context))
                    {
                        cmd.Parameters.AddWithValue("@Nombr", materia.Nombre);
                        cmd.Parameters.AddWithValue("@Creditos", materia.Creditos);
                        cmd.Parameters.AddWithValue("@Costo", materia.Costo);

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                            result.Message = "Materia insertada correctamente";
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "La materia no pudo ser insertada correctamente  " + result.Ex;

            }

            return result;
        }

        public static ML.Result Update(ML.Materia materia)
        {

            ML.Result result = new ML.Result();

            try
            {
                string query = "UPDATE [Materia] SET [Nombre] = @Nombre,[Creditos] = @Creditos,[Costo] = @Costo WHERE IdMateria = @IdMateria";

                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    context.Open();

                    using (SqlCommand cmd = new SqlCommand(query, context))
                    {
                        cmd.Parameters.AddWithValue("@IdMateria", materia.IdMateria);
                        cmd.Parameters.AddWithValue("@Nombre", materia.Nombre);
                        cmd.Parameters.AddWithValue("@Creditos", materia.Creditos);
                        cmd.Parameters.AddWithValue("@Costo", materia.Costo);

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                            result.Message = "Materia acutalizada correctamente";
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "La materia no pudo ser acrtualizada correctamente  " + result.Ex;

            }

            return result;
        }

        //STORED PROCEDURE

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "MateriaGetAll";

                    using (SqlCommand cmd = new SqlCommand(query, context))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable materiaTable = new DataTable();// creamos una tabla vacia

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd); //enviamos el cmd 

                        sqlDataAdapter.Fill(materiaTable); //llenar la tabla que estaba vacia

                        if (materiaTable.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow item in materiaTable.Rows)
                            {
                                ML.Materia materia = new ML.Materia();

                                materia.IdMateria = byte.Parse(item[0].ToString());
                                materia.Nombre = item[1].ToString();
                                materia.Creditos = byte.Parse(item[2].ToString());
                                materia.Costo = decimal.Parse(item[3].ToString());

                                materia.Semestre = new ML.Semestre();
                                materia.Semestre.IdSemestre = byte.Parse(item[4].ToString());
                                result.Objects.Add(materia);


                            }

                            result.Correct = true;
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al realizar la consulta en la base de datos " + result.Ex;
                //throw;
            }

            return result;
        }

        public static ML.Result AddSP(ML.Materia materia)
        {

            ML.Result result = new ML.Result();

            try
            {
                string query = "MateriaAdd";

                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    context.Open();


                    using (SqlCommand cmd = new SqlCommand(query, context))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Nombre", materia.Nombre);
                        cmd.Parameters.AddWithValue("@Creditos", materia.Creditos);
                        cmd.Parameters.AddWithValue("@Costo", materia.Costo);

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                            result.Message = "Materia insertada correctamente";
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "La materia no pudo ser insertada correctamente  " + result.Ex;

            }

            return result;
        }

        public static ML.Result GetById()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "MateriaGetById";

                    using (SqlCommand cmd = new SqlCommand(query, context))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable materiaTable = new DataTable();// creamos una tabla vacia

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd); //enviamos el cmd 

                        sqlDataAdapter.Fill(materiaTable); //llenar la tabla que estaba vacia

                        if (materiaTable.Rows.Count > 0)
                        {


                            DataRow item = materiaTable.Rows[0];

                            ML.Materia materia = new ML.Materia();

                            materia.IdMateria = byte.Parse(item[0].ToString());
                            materia.Nombre = item[1].ToString();
                            materia.Creditos = byte.Parse(item[2].ToString());
                            materia.Costo = decimal.Parse(item[3].ToString());

                            result.Object = materia;




                            result.Correct = true;
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al realizar la consulta en la base de datos " + result.Ex;
                //throw;
            }

            return result;
        }

        //Entity Framework 

        public static ML.Result GetAllEF(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasGSEntities context = new DL_EF.IEspinozaProgramacionNCapasGSEntities())
                {
                    var query = context.MateriaGetAll(materia.Nombre, materia.Creditos).ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var row in query)
                        {
                            materia = new ML.Materia();

                            materia.IdMateria = row.IdMateria;
                            materia.Nombre = row.Nombre;
                            materia.Creditos = row.Creditos.Value;
                            materia.Costo = row.Costo.Value;
                            materia.Estatus = row.Estatus.Value;

                            materia.Semestre = new ML.Semestre();
                            // row.IdSemestre = (row.IdSemestre == null)? byte.Parse("0") : row.IdSemestre.Value;
                            materia.Semestre.IdSemestre = row.IdSemestre;
                            materia.Semestre.Nombre = row.SemestreNombre;

                            materia.Grupo = new ML.Grupo();
                            materia.Grupo.IdGrupo = row.IdGrupo;
                            materia.Grupo.Nombre = row.GrupoNombre;

                            materia.Grupo.Plantel = new ML.Plantel();
                            materia.Grupo.Plantel.IdPlantel = row.IdPlantel;
                            materia.Grupo.Plantel.Nombre = row.PlantelNombre;

                            result.Objects.Add(materia);
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
                //throw;
            }

            return result;
        }

        public static ML.Result GetByIdEF(byte IdMateria)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasGSEntities context = new DL_EF.IEspinozaProgramacionNCapasGSEntities())
                {
                    var query = context.MateriaGetById(IdMateria).FirstOrDefault();

                    if (query != null)
                    {
                        ML.Materia materia = new ML.Materia();
                        materia = new ML.Materia();

                        materia.IdMateria = query.IdMateria;
                        materia.Nombre = query.Nombre;
                        materia.Creditos = query.Creditos.Value;
                        materia.Costo = query.Costo.Value;

                        materia.Semestre = new ML.Semestre();
                        materia.Semestre.IdSemestre = query.IdSemestre;
                        materia.Semestre.Nombre = query.SemestreNombre;

                        result.Object = materia;//Boxing


                        result.Correct = true;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al realizar la consulta en la base de datos " + result.Ex;
                //throw;
            }

            return result;
        }

        public static ML.Result AddEF(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasGSEntities context = new DL_EF.IEspinozaProgramacionNCapasGSEntities())
                {
                    int query = context.MateriaAdd(materia.Nombre, materia.Creditos, materia.Costo, materia.Semestre.IdSemestre);

                    if (query > 0)
                    {
                        result.Correct = true;
                        result.Message = "Materia insertada correctamente";
                    }
                }

            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.Ex = ex;
                result.Message = "La materia no pudo ser insertada correctamente  " + result.Ex;
            }
            return result;
        }

        public static ML.Result UpdateEF(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasGSEntities context = new DL_EF.IEspinozaProgramacionNCapasGSEntities())
                {
                    int query = context.MateriaUpdate(materia.IdMateria, materia.Nombre, materia.Creditos, materia.Costo, materia.Semestre.IdSemestre);

                    if (query > 0)
                    {
                        result.Correct = true;
                        result.Message = "Registro actualizado correctamente";
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "La materia no pudo ser actualizada correctamente  " + result.Ex;
                throw;
            }

            return result;
        }

        public static ML.Result DeleteEF(byte idMateria)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasGSEntities context = new DL_EF.IEspinozaProgramacionNCapasGSEntities())
                {
                    int query = context.MateriaDelete(idMateria);

                    if (query > 0)
                    {
                        result.Correct = true;
                        result.Message = "Registro actualizado correctamente";
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "La materia no pudo ser actualizada correctamente  " + result.Ex;
                throw;
            }

            return result;
        }

        public static ML.Result ChangeStatus(byte idMateria, bool estatus)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasGSEntities context = new DL_EF.IEspinozaProgramacionNCapasGSEntities())
                {
                    int query = context.MateriaEstatus(idMateria, estatus);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }




        //LINQ

        public static ML.Result AddLINQ(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasGSEntities context = new DL_EF.IEspinozaProgramacionNCapasGSEntities())
                {
                    DL_EF.Materia materiaLINQ = new DL_EF.Materia();

                    materiaLINQ.Nombre = materia.Nombre;
                    materiaLINQ.Creditos = materia.Creditos;
                    materiaLINQ.Costo = materia.Costo;
                    materiaLINQ.IdSemestre = materia.Semestre.IdSemestre;

                    context.Materias.Add(materiaLINQ); //INSERT INTO MATERIA 
                    int RowsAffected = context.SaveChanges();

                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                        result.Message = "Materia insertada correctamente";
                    }

                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "La materia no pudo ser actualizada correctamente  " + result.Ex;

                throw;
            }

            return result;
        }

        public static ML.Result UpdateLINQ(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasGSEntities context = new DL_EF.IEspinozaProgramacionNCapasGSEntities())
                {
                    var materiaLINQ = (from queryLINQ in context.Materias //FROM Materia
                                       where queryLINQ.IdMateria == materia.IdMateria //WHERE IdMateria = 5
                                       select queryLINQ).SingleOrDefault();//SELECT IdMateria,Nombre,Costo,Creditos,IdSemestre

                    if (materiaLINQ != null)
                    {
                        materiaLINQ.Nombre = materia.Nombre;
                        materiaLINQ.Creditos = materia.Creditos;
                        materiaLINQ.Costo = materia.Costo;
                        materiaLINQ.IdSemestre = materia.Semestre.IdSemestre;
                        int RowsAffected = context.SaveChanges();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                            result.Message = "Materia actualizada correctamente";
                        }

                    }


                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;

                result.Message = "No se encontró la materia" + materia.IdMateria + result.Ex.Message;
            }


            return result;
        }

        public static ML.Result GetAllLINQ()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasGSEntities context = new DL_EF.IEspinozaProgramacionNCapasGSEntities())
                {
                    var query = (from materiaLINQ in context.Materias //FROM Materia
                                 join semetreLINQ in context.Semestres on materiaLINQ.IdSemestre equals semetreLINQ.IdSemestre
                                 //  join aliasVaraiable in tablaModeloB on tablaModeloA.FK equals tablaModeloB.PK
                                 select new
                                 {
                                     IdMateria = materiaLINQ.IdMateria,
                                     Nombre = materiaLINQ.Nombre,
                                     Costo = materiaLINQ.Costo,
                                     Creditos = materiaLINQ.Creditos,
                                     IdSemestre = materiaLINQ.IdSemestre,
                                     SemestreNombre = semetreLINQ.Nombre
                                 });

                    result.Objects = new List<object>();

                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var obj in query)
                        {
                            ML.Materia materia = new ML.Materia();
                            materia.IdMateria = obj.IdMateria;
                            materia.Nombre = obj.Nombre;
                            materia.Creditos = obj.Creditos.Value;
                            materia.Costo = obj.Costo.Value;

                            materia.Semestre = new ML.Semestre();
                            materia.Semestre.IdSemestre = obj.IdSemestre.Value;
                            materia.Semestre.Nombre = obj.SemestreNombre;

                            result.Objects.Add(materia);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se encontraron registros";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public static ML.Result GetByNombre(string nombre)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.IEspinozaProgramacionNCapasGSEntities context = new DL_EF.IEspinozaProgramacionNCapasGSEntities())
                {
                    var query = context.MateriaGetByNombre(nombre).FirstOrDefault();

                    if (query != null)
                    {
                        ML.Materia materia = new ML.Materia();

                        materia.Nombre = query.Nombre;
                        materia.Creditos = query.Creditos.Value;

                        result.Object = materia;//Boxing


                        result.Correct = true;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al realizar la consulta en la base de datos " + result.Ex;
                //throw;
            }

            return result;
        }

    }
}

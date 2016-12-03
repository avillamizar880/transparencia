using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AuditoriasCiudadanas.Models
{
    public class DbManagement
    {


        /// <summary>
        /// función que ejecuta una instrucción Sql o Procedimiento almacenado y retorna un conjunto de tablas con los datos devueltos por el Procedimiento
        /// </summary>
        /// <param name="sSql">Sentencia Sql</param>
        /// <param name="sTipoComando">Tipo de Comando a ejecutar</param>
        /// <param name="connString">Cadena de conexion utilizada</param>
        /// <param name="parametros">Lista de objetos de tipo ParametrosPA</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static List<DataTable> getDatos(string sSql, System.Data.CommandType sTipoComando, string connString, List<PaParams> parametros)
        {
            List<DataTable> functionReturnValue = default(List<DataTable>);
            List<DataTable> DatosSalida = new List<DataTable>();
            DataTable tablaParametros = new DataTable("Params");

            int i = 0;
            string paramPo = "";
            SqlDataReader lector = default(SqlDataReader);
            bool parametrosSalida = false;
            System.Data.SqlClient.SqlConnection connSQL = new System.Data.SqlClient.SqlConnection(connString);
            SqlCommand comando = new SqlCommand(sSql, connSQL);
            comando.CommandTimeout = 60;
             comando.CommandType = sTipoComando;

            try
            {

                if (comando.Connection.State == ConnectionState.Closed)
                    comando.Connection.Open();
                //Abrimos la conexion
                if (parametros != null)
                {
                    //***Agregar parametros al procedimiento que estamos llamando***
                    int iNumParametros = parametros.Count;
                    //UBound(parametros)

                    for (i = 0; i <= iNumParametros - 1; i++)
                    {
                        if (parametros[i].getDireccion() != null & parametros[i].getLongitud() != null)
                        {
                            if ((ParameterDirection)parametros[i].getDireccion() == ParameterDirection.Output)
                            {
                                SqlParameter param = new SqlParameter(parametros[i].getNombre(), parametros[i].getTipoDato(),(int)parametros[i].getLongitud());
                                param.Direction = (ParameterDirection) parametros[i].getDireccion();
                                comando.Parameters.Add(param);
                                parametrosSalida = true;
                            }
                            else {
                                comando.Parameters.Add(parametros[i].getNombre(), parametros[i].getTipoDato()).Value = parametros[i].getValor();
                            }
                            if (parametros[i].getTipoDato() != SqlDbType.Structured)
                            {
                                paramPo = paramPo + parametros[i].getNombre() + "=" + parametros[i].getValor().ToString()  + ",";
                            }
                        }
                    }
                    //***Fin de agregar parametros al procedimiento que estamos llamando***
                }
                //HttpContext.Current.Response.Write("TIMEOUT DE EJECUCION EN " & comando.CommandTimeout & " SQL " & sSql)
                lector = comando.ExecuteReader();

                int indexTabla = 0;

                do
                {
                    DataTable dtb = new DataTable("DataTable" + indexTabla);
                    int indexRecorrido = 0;
                    DataRow drTb = default(DataRow);

                    while (lector.Read())
                    {
                        drTb = dtb.NewRow();

                        for (int ind = 0; ind <= lector.FieldCount - 1; ind++)
                        {
                            if (indexRecorrido == 0)
                            {
                                dtb.Columns.Add(lector.GetName(ind), lector.GetFieldType(ind));
                                drTb[ind]= lector.GetValue(ind);
                            }
                            else {
                                drTb[ind] = lector.GetValue(ind);
                            }
                        }

                        dtb.Rows.Add(drTb);

                        indexRecorrido = indexRecorrido + 1;
                    }

                    //if (dtb.Rows.Count > 0)
                    //{
                    //    DatosSalida.Add(dtb);
                    //}
                    //else {
                    //    dtb = null;
                    //}
                    DatosSalida.Add(dtb);

                    indexTabla = indexTabla + 1;
                } while (lector.NextResult());
                comando.Connection.Close();
                lector.Close();


                int paSal = 0;
                //****Se verifica si existen parametros de salida en el procedimiento*****
                if (parametrosSalida == true)
                {
                    DataRow fila = tablaParametros.NewRow();
                    //***Se recorren los parametros y los que son de salida se agregan a una tabla que será la respuesta final****
                    for (int j = 0; j <= parametros.Count - 1; j++)
                    {
                        if (parametros[j].getDireccion() != null && (ParameterDirection) parametros[j].getDireccion() == ParameterDirection.Output)
                        {
                            paSal = paSal + 1;
                            DataColumn columna = new DataColumn(parametros[j].getNombre().Remove(0, 1));
                            tablaParametros.Columns.Add(columna);
                            fila[tablaParametros.Columns.Count - 1] = comando.Parameters[parametros[j].getNombre()].Value;
                        }
                    }
                    if ((paSal != 0))
                    {
                        tablaParametros.Rows.Add(fila);
                    }
                }

                DatosSalida.Add(tablaParametros);

            }
            catch (Exception ex)
            {
                DataTable tablaError = new DataTable("Error");
                tablaError.Columns.Add("msg_err");
                tablaError.Rows.Add(ex.Message);
                DatosSalida.Add(tablaError);
            }
            finally
            {
                //***Cerrar la conexion****
                comando.Connection.Close();
                comando.Connection.Dispose();
                comando.Dispose();
                functionReturnValue = DatosSalida;
            }
            return functionReturnValue;

        }

    }

}


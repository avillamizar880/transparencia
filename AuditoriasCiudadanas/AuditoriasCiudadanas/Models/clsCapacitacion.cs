using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace AuditoriasCiudadanas.Models
{
    public class clsCapacitacion
    {
        static string cadTransparencia = ConfigurationManager.ConnectionStrings["Transparencia"].ConnectionString;
        public static string addRecursoMultimedia(int tipo_recurso,string titulo,string descripcion,string ruta, int id_usuario)
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            string cod_error = "0";
            string mensaje_error = "";
            string outTxt = "";
            parametros.Add(new PaParams("@titulo", SqlDbType.NVarChar, titulo, ParameterDirection.Input));
            parametros.Add(new PaParams("@descripcion", SqlDbType.NVarChar, descripcion, ParameterDirection.Input));
            parametros.Add(new PaParams("@ruta_url", SqlDbType.VarChar, ruta, ParameterDirection.Input,300));
            parametros.Add(new PaParams("@tipo_recurso", SqlDbType.Int, tipo_recurso, ParameterDirection.Input));
            parametros.Add(new PaParams("@id_usuario", SqlDbType.Int, id_usuario, ParameterDirection.Input));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.pa_ins_recurso_multimedia", CommandType.StoredProcedure, cadTransparencia, parametros);
            if (Data.Count > 1)
            {
                if (Data[1].Rows.Count > 0)
                {
                    cod_error = Data[1].Rows[0]["cod_error"].ToString();
                    mensaje_error = Data[1].Rows[0]["mensaje_error"].ToString();
                }
            }

            outTxt = cod_error + "<||>" + mensaje_error;
            return outTxt;
        }

        public static string delRecursoMultimedia(int id_recurso, int id_usuario) {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            string cod_error = "0";
            string mensaje_error = "";
            string outTxt = "";
            parametros.Add(new PaParams("@id_recurso", SqlDbType.Int, id_recurso, ParameterDirection.Input));
            parametros.Add(new PaParams("@id_usuario", SqlDbType.Int, id_usuario, ParameterDirection.Input));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.pa_del_recurso_multimedia", CommandType.StoredProcedure, cadTransparencia, parametros);
            if (Data.Count > 1)
            {
                if (Data[1].Rows.Count > 0)
                {
                    cod_error = Data[1].Rows[0]["cod_error"].ToString();
                    mensaje_error = Data[1].Rows[0]["mensaje_error"].ToString();
                }
            }

            outTxt = cod_error + "<||>" + mensaje_error;
            return outTxt;

        }

        public static string modRecursoMultimedia(int id_recurso, string titulo, string descripcion, string ruta, int id_usuario)
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            string cod_error = "0";
            string mensaje_error = "";
            string outTxt = "";
            parametros.Add(new PaParams("@id_recurso", SqlDbType.Int, id_recurso, ParameterDirection.Input));
            parametros.Add(new PaParams("@titulo", SqlDbType.NVarChar, titulo, ParameterDirection.Input));
            parametros.Add(new PaParams("@descripcion", SqlDbType.NVarChar, descripcion, ParameterDirection.Input));
            parametros.Add(new PaParams("@ruta_url", SqlDbType.VarChar, ruta, ParameterDirection.Input, 300));
            parametros.Add(new PaParams("@id_usuario", SqlDbType.Int, id_usuario, ParameterDirection.Input));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.pa_upd_recursos_multimedia", CommandType.StoredProcedure, cadTransparencia, parametros);
            if (Data.Count > 1)
            {
                if (Data[1].Rows.Count > 0)
                {
                    cod_error = Data[1].Rows[0]["cod_error"].ToString();
                    mensaje_error = Data[1].Rows[0]["mensaje_error"].ToString();
                }
            }

            outTxt = cod_error + "<||>" + mensaje_error;
            return outTxt;
        }


        public static List<DataTable> ObtListadoRecursoMutimedia(int tipo_recurso,int pag,int pagsize) {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@tipo_recurso", SqlDbType.Int, tipo_recurso, ParameterDirection.Input));
            parametros.Add(new PaParams("@pagenum", SqlDbType.Int, pag, ParameterDirection.Input));
            parametros.Add(new PaParams("@pagesize", SqlDbType.Int, pagsize, ParameterDirection.Input));
            Data = DbManagement.getDatos("dbo.pa_obt_recursos_multimedia", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;
        }

        public static string addTemaCapacitacion(string titulo, string detalle, int id_usuario)
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            string cod_error = "0";
            string mensaje_error = "";
            string outTxt = "";
            parametros.Add(new PaParams("@titulo", SqlDbType.NVarChar, titulo, ParameterDirection.Input));
            parametros.Add(new PaParams("@detalle", SqlDbType.NVarChar, detalle, ParameterDirection.Input));
            parametros.Add(new PaParams("@id_usuario", SqlDbType.Int, id_usuario, ParameterDirection.Input));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.pa_ins_temacapacitacion", CommandType.StoredProcedure, cadTransparencia, parametros);
            if (Data.Count > 1)
            {
                if (Data[1].Rows.Count > 0)
                {
                    cod_error = Data[1].Rows[0]["cod_error"].ToString();
                    mensaje_error = Data[1].Rows[0]["mensaje_error"].ToString();
                }
            }

            outTxt = cod_error + "<||>" + mensaje_error;
            return outTxt;
        }
    }
}
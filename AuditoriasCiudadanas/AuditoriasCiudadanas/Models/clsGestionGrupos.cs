using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;

namespace AuditoriasCiudadanas.Models
{
    public class clsGestionGrupos
    {
        static string cadTransparencia = ConfigurationManager.ConnectionStrings["Transparencia"].ConnectionString;

        /// <summary>
        /// Funcion para guardar postulacion de buenas practicas
        /// </summary>
        /// <param name="bpin_proy"></param>
        /// <param name="detalle"></param>
        /// <param name="id_usuario"></param>
        /// <param name="id_gac"></param>
        /// <returns></returns>
        public static string addBuenasPracticas(string bpin_proy, string hecho,string descripcion, int id_usuario, int id_gac)
        {
            string outTxt = "";
            DateTime fecha_cre = DateTime.Now;
            string cod_error = "";
            string mensaje_error = "";
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@id_usuario_cre", SqlDbType.Int, id_usuario, ParameterDirection.Input));
            parametros.Add(new PaParams("@codigo_bpin", SqlDbType.VarChar, bpin_proy, ParameterDirection.Input, 15));
            parametros.Add(new PaParams("@hecho", SqlDbType.VarChar, hecho, ParameterDirection.Input, 1000));
            parametros.Add(new PaParams("@descripcion", SqlDbType.VarChar, descripcion, ParameterDirection.Input, 1000));
            parametros.Add(new PaParams("@id_gac", SqlDbType.Int, id_gac, ParameterDirection.Input));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.pa_ins_buenas_practicas", CommandType.StoredProcedure, cadTransparencia, parametros);
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

        public static List<DataTable> obtBuenasPracticas(int pag, int pagsize)
        {
            DataTable dtInfo = new DataTable();
            DateTime fecha_cre = DateTime.Now;
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();

            parametros.Add(new PaParams("@estado", SqlDbType.Int, System.DBNull.Value, ParameterDirection.Input));
            parametros.Add(new PaParams("@pagenum", SqlDbType.Int, pag, ParameterDirection.Input));
            parametros.Add(new PaParams("@pagesize", SqlDbType.Int, pagsize, ParameterDirection.Input));
            Data = DbManagement.getDatos("dbo.pa_obt_buenas_practicas", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;
        }
        public static List<DataTable> obtBuenasPracticasById(int id_recurso)
        {
            DataTable dtInfo = new DataTable();
            DateTime fecha_cre = DateTime.Now;
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@id_buena_practica", SqlDbType.Int, id_recurso, ParameterDirection.Input));
            Data = DbManagement.getDatos("dbo.pa_obt_info_buena_practica", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;
        }

        public static string aprobarBuenasPracticas(int id_practica,int id_usuario) {
            string outTxt = "";
            string cod_error = "";
            string mensaje_error = "";
            DataTable dtInfo = new DataTable();
            DateTime fecha_cre = DateTime.Now;
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@id_practica", SqlDbType.Int, id_practica, ParameterDirection.Input));
            parametros.Add(new PaParams("@id_usuario", SqlDbType.Int, id_usuario, ParameterDirection.Input));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.pa_publicar_buena_practica", CommandType.StoredProcedure, cadTransparencia, parametros);
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

        public static string addExperienciasGac(string bpin_proy, string descripcion, string ruta_adjunto, int id_usuario, int id_gac)
        {
            string outTxt = "";
            DateTime fecha_cre = DateTime.Now;
            string cod_error = "";
            string mensaje_error = "";
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@id_usuario_cre", SqlDbType.Int, id_usuario, ParameterDirection.Input));
            parametros.Add(new PaParams("@codigo_bpin", SqlDbType.VarChar, bpin_proy, ParameterDirection.Input, 15));
            parametros.Add(new PaParams("@descripcion", SqlDbType.VarChar, descripcion, ParameterDirection.Input, 1000));
            parametros.Add(new PaParams("@ruta_Url", SqlDbType.VarChar, ruta_adjunto, ParameterDirection.Input, 500));
            parametros.Add(new PaParams("@id_gac", SqlDbType.Int, id_gac, ParameterDirection.Input));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.pa_ins_experienciasGac", CommandType.StoredProcedure, cadTransparencia, parametros);
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

        public static List<DataTable> obtExperienciasGAC(int pag, int pagsize)
        {
            DataTable dtInfo = new DataTable();
            DateTime fecha_cre = DateTime.Now;
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();

            parametros.Add(new PaParams("@estado", SqlDbType.Int, System.DBNull.Value, ParameterDirection.Input));
            parametros.Add(new PaParams("@pagenum", SqlDbType.Int, pag, ParameterDirection.Input));
            parametros.Add(new PaParams("@pagesize", SqlDbType.Int, pagsize, ParameterDirection.Input));
            Data = DbManagement.getDatos("dbo.pa_obt_experiencias_gac", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;
        }

        public static List<DataTable> obtExperienciaGacById(int id_recurso)
        {
            DataTable dtInfo = new DataTable();
            DateTime fecha_cre = DateTime.Now;
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@id_experiencia", SqlDbType.Int, id_recurso, ParameterDirection.Input));
            Data = DbManagement.getDatos("dbo.pa_obt_info_experienciagac", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;
        }

        public static string aprobarExperienciasGac(int id_experiencia, int id_usuario)
        {
            string outTxt = "";
            string cod_error = "";
            string mensaje_error = "";
            DataTable dtInfo = new DataTable();
            DateTime fecha_cre = DateTime.Now;
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@id_experiencia", SqlDbType.Int, id_experiencia, ParameterDirection.Input));
            parametros.Add(new PaParams("@id_usuario", SqlDbType.Int, id_usuario, ParameterDirection.Input));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.pa_publicar_experienciasGac", CommandType.StoredProcedure, cadTransparencia, parametros);
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
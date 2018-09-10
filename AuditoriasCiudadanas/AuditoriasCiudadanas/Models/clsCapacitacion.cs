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


        public static List<DataTable> ObtListadoRecursoMutimedia(string tipo_recurso, int pag, int pagsize)
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@tipo_recurso", SqlDbType.VarChar, tipo_recurso, ParameterDirection.Input));
            parametros.Add(new PaParams("@pagenum", SqlDbType.Int, pag, ParameterDirection.Input));
            parametros.Add(new PaParams("@pagesize", SqlDbType.Int, pagsize, ParameterDirection.Input));
            Data = DbManagement.getDatos("dbo.pa_obt_recursos_multimedia", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;
        }

        public static string crearCuestionarioEvaluacion(int id_tipo, string titulo, string descripcion, int id_usuario, int id_capacitacion)
        {

            string outTxt = "";
            string cod_error = "0";
            string mensaje_error = "";
            string idCuestionario = "0";
            DateTime fecha = DateTime.Now;
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@id_tipo_cuestionario", SqlDbType.Int, id_tipo, ParameterDirection.Input));
            parametros.Add(new PaParams("@fecha_creacion", SqlDbType.DateTime, fecha, ParameterDirection.Input));
            parametros.Add(new PaParams("@id_usuario_cre", SqlDbType.Int, id_usuario, ParameterDirection.Input));
            parametros.Add(new PaParams("@titulo", SqlDbType.VarChar, titulo, ParameterDirection.Input, 100));
            parametros.Add(new PaParams("@descripcion", SqlDbType.VarChar, descripcion, ParameterDirection.Input, 200));
            parametros.Add(new PaParams("@id_capacitacion", SqlDbType.Int, id_capacitacion, ParameterDirection.Input));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@idCuestionario", SqlDbType.Int, idCuestionario, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.[pa_ins_cuestionario_capacitacion]", CommandType.StoredProcedure, cadTransparencia, parametros);
            if (Data.Count > 1)
            {
                if (Data[1].Rows.Count > 0)
                {
                    cod_error = Data[1].Rows[0]["cod_error"].ToString();
                    mensaje_error = Data[1].Rows[0]["mensaje_error"].ToString();
                    idCuestionario = Data[1].Rows[0]["idCuestionario"].ToString();
                }
            }

            outTxt = cod_error + "<||>" + mensaje_error + "<||>" + idCuestionario + "<||>" + id_tipo.ToString();
            return outTxt;
        }

        public static List<DataTable> obtCuestionarioCapacitacion(int id_capacitacion)
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@id_capacitacion", SqlDbType.Int, id_capacitacion, ParameterDirection.Input));
            Data = DbManagement.getDatos("dbo.pa_obt_cuestionario_capacitacion", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;

        }

        public static List<DataTable> obtRecursoMultimediaById(int id_recurso)
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@id_recurso", SqlDbType.Int, id_recurso, ParameterDirection.Input));
            Data = DbManagement.getDatos("dbo.pa_obt_InfoRecursoMultimedia", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id_cap"></param>
        /// <param name="id_modulo"></param>
        /// <returns></returns>
        public static List<DataTable> ObtRecursosModuloCap(int id_cap,int id_modulo, int id_usuario)
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@idCap", SqlDbType.Int, id_cap, ParameterDirection.Input));
            parametros.Add(new PaParams("@modulo", SqlDbType.Int, id_modulo, ParameterDirection.Input));
            parametros.Add(new PaParams("@idUsuario", SqlDbType.Int, id_usuario, ParameterDirection.Input));
            Data = DbManagement.getDatos("dbo.pa_obt_reccapusuario", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;
        }

        /// <summary>
        /// Funcion que retorna los recursos de un modulo especifico de capacitacion
        /// </summary>
        /// <param name="id_cap">id de capacitacion</param>
        /// <param name="id_modulo">id de modulo</param>
        /// <returns></returns>
        public static List<DataTable> ObtModulosCapacitacion(int id_cap)
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@idCap", SqlDbType.Int, id_cap, ParameterDirection.Input));
            Data = DbManagement.getDatos("dbo.pa_obt_modulos_capacitacion", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;
        }

        ///------------------------ANGELICA-----------------

        /// <summary>
        /// Funcion que retorna los modulos de una capacitacion vistos por usuario
        /// </summary>
        /// <param name="id_cap">id de capacitacion</param>
        /// <param name="id_usuairo">id de usuario</param>
        /// <returns></returns>
        public static List<DataTable> ObtModulosCapacitacionUsu(int id_cap, int id_usuario)
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@idCap", SqlDbType.Int, id_cap, ParameterDirection.Input));
            parametros.Add(new PaParams("@idUsuario", SqlDbType.Int, id_usuario, ParameterDirection.Input));
            Data = DbManagement.getDatos("dbo.pa_obt_modulos_capacitacion_usuario", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tituloRec"></param>
        /// <param name="tipo_aux"></param>
        /// <param name="modulo_aux"></param>
        /// <param name="id_cap_aux"></param>
        /// <param name="url"></param>
        /// <param name="id_usuario_aux"></param>
        /// <returns></returns>
        public static string addRecCapacutacion(string tituloRec, int tipo_aux, int modulo_aux, int id_cap_aux, string url, int id_usuario_aux)
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            string cod_error = "0";
            string mensaje_error = "";
            string outTxt = "";
            parametros.Add(new PaParams("@idCap", SqlDbType.Int, id_cap_aux, ParameterDirection.Input));
            parametros.Add(new PaParams("@modulo", SqlDbType.Int, modulo_aux, ParameterDirection.Input));
            parametros.Add(new PaParams("@idTipoMultimedia", SqlDbType.Int, tipo_aux, ParameterDirection.Input));
            parametros.Add(new PaParams("@Titulo", SqlDbType.NVarChar, tituloRec, ParameterDirection.Input));
            parametros.Add(new PaParams("@URL", SqlDbType.NVarChar, url, ParameterDirection.Input));
            parametros.Add(new PaParams("@id_usuario", SqlDbType.Int, id_usuario_aux, ParameterDirection.Input));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.pa_ins_recursocapacitacion", CommandType.StoredProcedure, cadTransparencia, parametros);
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

        public static string delRecCapacitacion(int id_reccap_aux, int id_usuario_aux)
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            string cod_error = "0";
            string mensaje_error = "";
            string outTxt = "";
            parametros.Add(new PaParams("@idRCap", SqlDbType.Int, id_reccap_aux, ParameterDirection.Input));
            parametros.Add(new PaParams("@id_usuario", SqlDbType.Int, id_usuario_aux, ParameterDirection.Input));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.pa_del_recursocapacitacion", CommandType.StoredProcedure, cadTransparencia, parametros);
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

        public static string delTemaCapacitacion(int id_cap, int id_usuario)
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            string cod_error = "0";
            string titulo = "";
            string detalle = "";
            string mensaje_error = "";
            string outTxt = "";
            string activo = "0";
            parametros.Add(new PaParams("@idCap", SqlDbType.Int, id_cap, ParameterDirection.Input));
            parametros.Add(new PaParams("@titulo", SqlDbType.NVarChar, titulo, ParameterDirection.Input));
            parametros.Add(new PaParams("@detalle", SqlDbType.NVarChar, detalle, ParameterDirection.Input));
            parametros.Add(new PaParams("@activo", SqlDbType.NVarChar, activo, ParameterDirection.Input));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.pa_upd_temacapacitacion", CommandType.StoredProcedure, cadTransparencia, parametros);
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


        public static string updTemaCapacitacion(int id_cap, string titulo, string detalle, int id_usuario)
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            string cod_error = "0";
            string mensaje_error = "";
            string outTxt = "";
            string activo = "1";
            parametros.Add(new PaParams("@idCap", SqlDbType.Int, id_cap, ParameterDirection.Input));
            parametros.Add(new PaParams("@titulo", SqlDbType.NVarChar, titulo, ParameterDirection.Input));
            parametros.Add(new PaParams("@detalle", SqlDbType.NVarChar, detalle, ParameterDirection.Input));
            parametros.Add(new PaParams("@activo", SqlDbType.NVarChar, activo, ParameterDirection.Input));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.pa_upd_temacapacitacion", CommandType.StoredProcedure, cadTransparencia, parametros);
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

        internal static List<DataTable> obtRecursosCapacitacion(int id_cap)
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@idCap", SqlDbType.Int, id_cap, ParameterDirection.Input));
            Data = DbManagement.getDatos("dbo.pa_obt_recursoscapacitacion", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;
        }

        public static List<DataTable> listTemaCapacitacion()
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            Data = DbManagement.getDatos("dbo.pa_listar_temacapacitacion", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;
        }

        public static string registrarRCaptVisto(int id_reccap_aux, int id_usuario_aux)
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            string cod_error = "0";
            string mensaje_error = "";
            string outTxt = "";
            parametros.Add(new PaParams("@idRCap", SqlDbType.Int, id_reccap_aux, ParameterDirection.Input));
            parametros.Add(new PaParams("@idUsuario", SqlDbType.Int, id_usuario_aux, ParameterDirection.Input));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.pa_ins_recCapUsuario", CommandType.StoredProcedure, cadTransparencia, parametros);
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

        ///-----------------DIANA Y WILLIAM---------------------------------
        /// <summary>
        /// Obtiene la url del video
        /// </summary>
        /// <param name="nombreCapacitacion">Es el nombre de la capacitación</param>
        /// <returns>Devuelve la url del video en youtube</returns>
        static public string ObtenerUrlCapacitacion(string nombreCapacitacion)
        {
            var parametros = new List<PaParams>();
            parametros.Add(new PaParams("@nombreCapacitacion", SqlDbType.VarChar, nombreCapacitacion, ParameterDirection.Input, 100));
            var dtUrlCapacitacion = DbManagement.getDatosDataTable("dbo.pa_obt_urlcap", CommandType.StoredProcedure, cadTransparencia, parametros);
            if (dtUrlCapacitacion != null && dtUrlCapacitacion.Rows.Count > 0) return dtUrlCapacitacion.Rows[0].ItemArray[0].ToString();
            else return string.Empty;//Significa que no hubo datos
        }

        
    }
}
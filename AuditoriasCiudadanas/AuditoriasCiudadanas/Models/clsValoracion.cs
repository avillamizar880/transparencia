using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

namespace AuditoriasCiudadanas.Models
{
    public class clsValoracion
    {
        static string cadTransparencia = ConfigurationManager.ConnectionStrings["Transparencia"].ConnectionString;

        public static List<DataTable> listaTipoCuestionario() {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            Data = DbManagement.getDatos("dbo.pa_listar_tiposcuestionario", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;
        }
        
        public static string crearCuestionario(int id_tipo,string titulo, string descripcion, int id_usuario)
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
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@idCuestionario", SqlDbType.Int, idCuestionario, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.[pa_ins_cuestionario]", CommandType.StoredProcedure, cadTransparencia, parametros);
            if (Data.Count > 1)
            {
                if (Data[1].Rows.Count > 0)
                {
                    cod_error = Data[1].Rows[0]["cod_error"].ToString();
                    mensaje_error = Data[1].Rows[0]["mensaje_error"].ToString();
                    idCuestionario = Data[1].Rows[0]["idCuestionario"].ToString();
                }
            }

            outTxt = cod_error + "<||>" + mensaje_error + "<||>" +  idCuestionario;
            return outTxt;
        }


        public static string modificarCuestionario(int id_cuestionario,int id_tipo, string titulo, string descripcion, int id_usuario)
        {

            string outTxt = "";
            string cod_error = "0";
            string mensaje_error = "";
            DateTime fecha = DateTime.Now;
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@id_cuestionario", SqlDbType.Int, id_cuestionario, ParameterDirection.Input));
            parametros.Add(new PaParams("@id_tipo_cuestionario", SqlDbType.Int, id_tipo, ParameterDirection.Input));
            parametros.Add(new PaParams("@fecha_modif", SqlDbType.DateTime, fecha, ParameterDirection.Input));
            parametros.Add(new PaParams("@id_usuario_modif", SqlDbType.Int, id_usuario, ParameterDirection.Input));
            parametros.Add(new PaParams("@titulo", SqlDbType.VarChar, titulo, ParameterDirection.Input, 100));
            parametros.Add(new PaParams("@descripcion", SqlDbType.VarChar, descripcion, ParameterDirection.Input, 200));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.[pa_upd_cuestionario]", CommandType.StoredProcedure, cadTransparencia, parametros);
            if (Data.Count > 1)
            {
                if (Data[1].Rows.Count > 0)
                {
                    cod_error = Data[1].Rows[0]["cod_error"].ToString();
                    mensaje_error = Data[1].Rows[0]["mensaje_error"].ToString();
                }
            }

            outTxt = cod_error + "<||>" + mensaje_error ;
            return outTxt;
        }


        public static string insPregunta(string xml_info)
        {
            string cod_error = "-1";
            string mensaje_error = "@ERROR";
            string outTxt = "";
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@PREGUNTA", SqlDbType.Xml, xml_info, ParameterDirection.Input));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.pa_ins_pregunta", CommandType.StoredProcedure, cadTransparencia, parametros);
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

        public static string modifPregunta(string xml_info,int id_pregunta)
        {
            string cod_error = "-1";
            string mensaje_error = "@ERROR";
            string outTxt = "";
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@PREGUNTA", SqlDbType.Xml, xml_info, ParameterDirection.Input));
            parametros.Add(new PaParams("@id_pregunta", SqlDbType.Int, id_pregunta, ParameterDirection.Input));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.pa_upd_pregunta", CommandType.StoredProcedure, cadTransparencia, parametros);
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

        public static List<DataTable> obtPreguntasCuestionario(int id_cuestionario) {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@id_cuestionario", SqlDbType.Int, id_cuestionario, ParameterDirection.Input));
            Data = DbManagement.getDatos("dbo.pa_obt_preguntas_cuestionario", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;
       
        }

        public static List<DataTable> obtPreguntaById(int id_pregunta)
        {
            string outTxt = "";
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@id_pregunta", SqlDbType.Int, id_pregunta, ParameterDirection.Input));
            Data = DbManagement.getDatos("dbo.pa_obt_pregunta", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;

        }

        public static string insRespuestas(string xml_info,int id_usuario)
        {
            string cod_error = "-1";
            string mensaje_error = "@ERROR";
            string outTxt = "";
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@id_usuario", SqlDbType.Int, id_usuario, ParameterDirection.Input));
            parametros.Add(new PaParams("@RESPUESTA", SqlDbType.Xml, xml_info, ParameterDirection.Input));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.pa_ins_respuesta_usu", CommandType.StoredProcedure, cadTransparencia, parametros);
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

        public static List<DataTable> obtCuestionarioAyuda()
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            Data = DbManagement.getDatos("dbo.[pa_obt_cuestionario_ayuda]", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;

        }

    }
}
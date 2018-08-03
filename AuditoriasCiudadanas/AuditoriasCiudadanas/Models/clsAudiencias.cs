using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

namespace AuditoriasCiudadanas.Models
{
    public class clsAudiencias
    {
        static string cadTransparencia = ConfigurationManager.ConnectionStrings["Transparencia"].ConnectionString;
        public static string insActaReuniones(string cod_bpin, DateTime fecha, string descripcion, string ruta_arc, int id_usuario,string id_lugar, int idGac)
        {
            string cod_error = "-1";
            string mensaje_error = "@ERROR";
            string outTxt = "";
            int id_tipo_audiencia = 4;
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@idAudiencia", SqlDbType.Int, System.DBNull.Value, ParameterDirection.Input));
            parametros.Add(new PaParams("@idTipoAudiencia", SqlDbType.Int, id_tipo_audiencia, ParameterDirection.Input));
            parametros.Add(new PaParams("@CodigoBPIN", SqlDbType.VarChar, cod_bpin, ParameterDirection.Input,15));
            parametros.Add(new PaParams("@Fecha", SqlDbType.DateTime, fecha, ParameterDirection.Input));
            parametros.Add(new PaParams("@descripcion", SqlDbType.VarChar, descripcion, ParameterDirection.Input,1000));
            parametros.Add(new PaParams("@ruta", SqlDbType.VarChar, ruta_arc, ParameterDirection.Input,200));
            parametros.Add(new PaParams("@IdUsuario", SqlDbType.Int, id_usuario, ParameterDirection.Input));
            parametros.Add(new PaParams("@idDivipola", SqlDbType.VarChar, id_lugar, ParameterDirection.Input, 15));
            parametros.Add(new PaParams("@idGac", SqlDbType.VarChar, idGac, ParameterDirection.Input, 15));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output, 100));
            Data = DbManagement.getDatos("dbo.pa_ins_acta", CommandType.StoredProcedure, cadTransparencia, parametros);
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

        public static string insRegObservaciones(string cod_bpin,string info_faltante,string info_clara, string info_completa, string comunidad_benef, string dudas, DateTime fecha_posterior_1, DateTime fecha_posterior_2,int id_usuario,int id_grupo)
        {
            string cod_error = "-1";
            string mensaje_error = "@ERROR";
            string outTxt = "";
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@info_faltante", SqlDbType.VarChar, info_faltante, ParameterDirection.Input, 200));
            parametros.Add(new PaParams("@info_clara", SqlDbType.VarChar, info_clara, ParameterDirection.Input, 200));
            parametros.Add(new PaParams("@info_completa", SqlDbType.VarChar, info_completa, ParameterDirection.Input, 200));
            parametros.Add(new PaParams("@comunidad_benef", SqlDbType.VarChar, comunidad_benef, ParameterDirection.Input,200));
            parametros.Add(new PaParams("@dudas", SqlDbType.VarChar, dudas, ParameterDirection.Input, 200));
            parametros.Add(new PaParams("@fecha_posterior_1", SqlDbType.DateTime, fecha_posterior_1, ParameterDirection.Input));
            parametros.Add(new PaParams("@fecha_posterior_2", SqlDbType.DateTime, fecha_posterior_2, ParameterDirection.Input));
            parametros.Add(new PaParams("@id_usuario", SqlDbType.Int, id_usuario, ParameterDirection.Input));
            parametros.Add(new PaParams("@codigo_bpin", SqlDbType.VarChar, cod_bpin, ParameterDirection.Input,15));
            parametros.Add(new PaParams("@id_gac", SqlDbType.Int, id_grupo, ParameterDirection.Input));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output,100));
            Data = DbManagement.getDatos("dbo.pa_ins_observaciones_aud", CommandType.StoredProcedure, cadTransparencia, parametros);
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

        public static string insProponerFechaReuPrevias(string cod_bpin, DateTime fecha, int id_usuario)
        {
            string cod_error = "-1";
            string mensaje_error = "@ERROR";
            string outTxt = "";
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@CodigoBPIN", SqlDbType.VarChar, cod_bpin, ParameterDirection.Input, 15));
            parametros.Add(new PaParams("@id_usuario", SqlDbType.Int, id_usuario, ParameterDirection.Input));
            parametros.Add(new PaParams("@fecha_propuesta", SqlDbType.DateTime, fecha, ParameterDirection.Input));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.pa_ins_fecha_reuprevia", CommandType.StoredProcedure, cadTransparencia, parametros);
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

        public static string insValoracionProyecto(DataTable datatable)
        {
            string cod_error = "-1";
            string mensaje_error = "@ERROR";
            string outTxt = "";
            List<DataTable> Data = new List<DataTable>();
            DataSet dsEnvio = new DataSet();

            dsEnvio.DataSetName = "ROOT";
            dsEnvio.Tables.Add(datatable.Copy());
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@l_CATALOGO", SqlDbType.Xml, dsEnvio.GetXml(), ParameterDirection.Input));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output, 100));
            Data = DbManagement.getDatos("dbo.pa_ins_ValoracionProy", CommandType.StoredProcedure, cadTransparencia, parametros);
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

        public static List<DataTable> obtInformeProceso(string cod_bpin, int id_GAC, int tipo_audiencia, int idaudiencia)
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@CodigoBPIN", SqlDbType.VarChar, cod_bpin, ParameterDirection.Input, 15));
            parametros.Add(new PaParams("@id_GAC", SqlDbType.Int, id_GAC, ParameterDirection.Input));
            parametros.Add(new PaParams("@id_TipoAudiencia", SqlDbType.Int, tipo_audiencia, ParameterDirection.Input));
            parametros.Add(new PaParams("@idAudiencia", SqlDbType.Int, idaudiencia, ParameterDirection.Input));
            parametros.Add(new PaParams("@idInforme", SqlDbType.Int, 0, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.pa_obt_datos_informeproceso", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;

        }

        public static string insCompromisos(string xml_info,int num_asistentes) {
            //falta agregar el número de asistentes al pa_ins_compromisos_aud
            string cod_error = "-1";
            string mensaje_error = "@ERROR";
            string outTxt = "";
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@l_CATALOGO", SqlDbType.Xml, xml_info, ParameterDirection.Input));
            parametros.Add(new PaParams("@num_asistentes", SqlDbType.Int, num_asistentes, ParameterDirection.Input));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.pa_ins_compromisos_aud", CommandType.StoredProcedure, cadTransparencia, parametros);
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

        public static string insInformeProceso(string xml_info)
        {
            //falta agregar el número de asistentes al pa_ins_compromisos_aud
            string cod_error = "-1";
            string mensaje_error = "@ERROR";
            string outTxt = "";
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@l_INFORME", SqlDbType.Xml, xml_info, ParameterDirection.Input));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.pa_ins_InformeProceso", CommandType.StoredProcedure, cadTransparencia, parametros);
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

        public static List<DataTable> listarTipoAudiencias()
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            Data = DbManagement.getDatos("dbo.pa_listar_tipoaudiencia", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;
        }

        public static string insFechaAudiencias(string cod_bpin, int tipo_audiencia, string id_municipio, DateTime fecha, int id_usuario,string direccion)
        {
            
            string cod_error = "-1";
            string mensaje_error = "@ERROR";
            string outTxt = "";
                       
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();

            parametros.Add(new PaParams("@CodigoBPIN", SqlDbType.VarChar, cod_bpin, ParameterDirection.Input, 15));
            if (id_usuario > 0)
            {
                parametros.Add(new PaParams("@idUsuario", SqlDbType.Int, id_usuario, ParameterDirection.Input));
            }
            else {
                parametros.Add(new PaParams("@idUsuario", SqlDbType.Int, DBNull.Value, ParameterDirection.Input));
            }
            
            parametros.Add(new PaParams("@fecha", SqlDbType.DateTime, fecha, ParameterDirection.Input));
            parametros.Add(new PaParams("@idDivipola", SqlDbType.VarChar, id_municipio, ParameterDirection.Input,500));
            parametros.Add(new PaParams("@idTipoAudiencia", SqlDbType.Int, tipo_audiencia, ParameterDirection.Input));
            parametros.Add(new PaParams("@direccion", SqlDbType.VarChar, direccion, ParameterDirection.Input));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.pa_ins_audiencia", CommandType.StoredProcedure, cadTransparencia, parametros);
            if (Data.Count > 1)
            {
                if (Data[1].Rows.Count > 0)
                {
                    cod_error = Data[1].Rows[0]["cod_error"].ToString();
                    mensaje_error = Data[1].Rows[0]["mensaje_error"].ToString();
                }
            }
            if (mensaje_error.ToUpper().IndexOf("FK_AUDIENCIAS_PROYECTO") > -1) {
                mensaje_error = "Bpin proyecto no válido";
            }
            if (mensaje_error.ToUpper().IndexOf("FK_AUDIENCIAS_DIVIPOLA") > -1) {
                mensaje_error = "Lugar no válido";
            }
            outTxt = cod_error + "<||>" + mensaje_error;
            return outTxt;

        }


        public static string pdfRegObservaciones(string cod_bpin, int id_gac)
        {
            string cod_error = "-1";
            string mensaje_error = "@ERROR";
            string outTxt = "";
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@codigo_bpin", SqlDbType.VarChar, cod_bpin, ParameterDirection.Input, 15));
            parametros.Add(new PaParams("@id_gac", SqlDbType.Int, id_gac, ParameterDirection.Input));
            parametros.Add(new PaParams("@html_pdf", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.pa_sql_observaciones_aud_pdf", CommandType.StoredProcedure, cadTransparencia, parametros);
            if (Data.Count > 1)
            {
                if (Data[1].Rows.Count > 0)
                {
                    cod_error = Data[1].Rows[0]["cod_error"].ToString();
                    mensaje_error = Data[1].Rows[0]["mensaje_error"].ToString();
                }
                if (cod_error == ""){
                    mensaje_error = Data[1].Rows[0]["html_pdf"].ToString();
                }
            }
            outTxt = cod_error + "<||>" + mensaje_error;
            return outTxt;
        }

        public static List<DataTable> obtRegObservaciones(string cod_bpin, int id_gac) {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@codigo_bpin", SqlDbType.VarChar, cod_bpin, ParameterDirection.Input, 15));
            parametros.Add(new PaParams("@id_gac", SqlDbType.Int, id_gac, ParameterDirection.Input, 15));
            Data = DbManagement.getDatos("dbo.pa_sql_observaciones_aud", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;
        }

        public static List<DataTable> obtRegCompromisos(int id_audiencia)
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@id_audiencia", SqlDbType.Int, id_audiencia, ParameterDirection.Input));
            Data = DbManagement.getDatos("dbo.pa_sql_compromisos_aud", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;
        }

        public static List<DataTable> obtActaReunionPrevia(string cod_bpin, int id_gac)
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@codigo_bpin", SqlDbType.VarChar, cod_bpin, ParameterDirection.Input, 15));
            parametros.Add(new PaParams("@id_gac", SqlDbType.Int, id_gac, ParameterDirection.Input));
            Data = DbManagement.getDatos("dbo.pa_sql_acta_reuPrevias", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;
        }

        public static List<DataTable> obtValoracionProy(string cod_bpin)
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@codigo_bpin", SqlDbType.VarChar, cod_bpin, ParameterDirection.Input, 15));
            Data = DbManagement.getDatos("dbo.pa_sql_valoracion", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;
        }

        public static string BorrarAdjuntosCompromisos(int id_audiencia) {
            string cod_error = "-1";
            string mensaje_error = "@ERROR";
            string outTxt = "";
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@id_audiencia", SqlDbType.Int, id_audiencia, ParameterDirection.Input));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.pa_del_adjuntoCompromisosAud", CommandType.StoredProcedure, cadTransparencia, parametros);
            if (Data.Count > 1)
            {
                if (Data[1].Rows.Count > 0)
                {
                    cod_error = Data[1].Rows[0]["cod_error"].ToString();
                    mensaje_error = Data[1].Rows[0]["mensaje_error"].ToString();
                }
                if (cod_error == "")
                {
                    mensaje_error = Data[1].Rows[0]["html_pdf"].ToString();
                }
            }
            outTxt = cod_error + "<||>" + mensaje_error;
            return outTxt;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace AuditoriasCiudadanas.Controllers
{
    public class AudienciasController
    {
        public string formato(string cadena)
        {
            return HttpUtility.HtmlEncode(cadena);
        }
        public string insActaReuniones(string cod_bpin, DateTime fecha, string tema, string ruta_arc, int id_usuario,int id_lugar)
        {
            string outTxt = "";
            outTxt = Models.clsAudiencias.insActaReuniones(cod_bpin, fecha, tema, ruta_arc, id_usuario,id_lugar);
            return outTxt;
        }

        public string insRegObservaciones(string cod_bpin, string info_clara, string info_completa, string comunidad_benef, string dudas, DateTime fecha_posterior_1, DateTime fecha_posterior_2, int id_usuario)
        {
            string outTxt = "";
            outTxt = Models.clsAudiencias.insRegObservaciones(cod_bpin,info_clara,info_completa,comunidad_benef,dudas,fecha_posterior_1,fecha_posterior_2,id_usuario);
            return outTxt;
        }

        public string insProponerFechaReuPrevias(string cod_bpin, DateTime fecha, int id_usuario)
        {
            string outTxt = "";
            outTxt = Models.clsAudiencias.insProponerFechaReuPrevias(cod_bpin,fecha,id_usuario);
            return outTxt;
        }

        public string insCompromisos(string xml_info,int num_asistentes) {
            string outTxt = "";
            outTxt = Models.clsAudiencias.insCompromisos(xml_info,num_asistentes);
            return outTxt;
        }

        public string insValoracionProyecto(DataTable datatable)
        {
            string outTxt = "";
            outTxt = Models.clsAudiencias.insValoracionProyecto(datatable);
            return outTxt;
        }


        public string obtInformeProceso(string cod_bpin, int id_GAC , int tipo_audiencia, int idaudiencia)
        {
            string outTxt = "";
            List<DataTable> listaInfo = new List<DataTable>();
            listaInfo = Models.clsAudiencias.obtInformeProceso(cod_bpin, id_GAC, tipo_audiencia, idaudiencia);
            DataTable dtTareas = listaInfo[0];
            DataTable dtActividades = listaInfo[1];
            DataTable dtCompromisos = listaInfo[2];
            DataTable dtDudas = listaInfo[3];

            if (dtTareas.Rows.Count > 0)
            {
                string tareasobs = "";
                tareasobs += "<div class=\"row\">";
                tareasobs += "<div class=\"col-sm-3\">";
                tareasobs += "<div class=\"form-group\">";
                tareasobs += "<label for=\"user\">Tarea del grupo</label>";
                tareasobs += "</div>";
                tareasobs += "</div>";
                tareasobs += "<div class=\"col-sm-3\">";
                tareasobs += "<div class=\"form-group\">";
                tareasobs += "<label for=\"user\">Responsable(s)</label>";
                tareasobs += "</div>";
                tareasobs += "</div>";
                tareasobs += "<div class=\"col-sm-2\"><div class=\"form-group\">";
                tareasobs += "<label for=\"dtp_input2\" class=\"control-label\">Fecha</label>";
                tareasobs += "</div>";
                tareasobs += "</div>";
                tareasobs += "<div class=\"col-sm-4\">";
                tareasobs += "<div class=\"form-group\">";
                tareasobs += "<label for=\"user\">Resultados de Observaciones</label>";
                tareasobs += "</div>";
                tareasobs += "</div>";
                tareasobs += "</div>";
                for (int i = 0; i <= dtTareas.Rows.Count - 1; i++)
                {
                    tareasobs += "<div class=\"row\">";
                    tareasobs += "<input type = \"hidden\" id=\"idtarea_input"+ i +"\" value=\"" + formato(dtTareas.Rows[i]["idTarea"].ToString().Trim()) + "\"/>";
                    tareasobs += "<div class=\"col-sm-3\">";
                    tareasobs += "<div class=\"form-group\">";
                    tareasobs += formato(dtTareas.Rows[i]["detalle"].ToString().Trim());
                    tareasobs += "</div>";
                    tareasobs += "</div>";
                    tareasobs += "<div class=\"col-sm-3\">";
                    tareasobs += "<div class=\"form-group\">";
                    tareasobs += formato(dtTareas.Rows[i]["responsable"].ToString().Trim());
                    tareasobs += "</div>";
                    tareasobs += "</div>";
                    tareasobs += "<div class=\"col-sm-2\"><div class=\"form-group\">";
                    tareasobs += formato(dtTareas.Rows[i]["fecha"].ToString().Trim());
                    tareasobs += "</div>";
                    tareasobs += "</div>";
                    tareasobs += "<div class=\"col-sm-4\">";
                    tareasobs += "<div class=\"form-group\">";
                    string obs = formato(dtTareas.Rows[i]["observacion"].ToString().Trim());
                    if (!String.IsNullOrEmpty(obs))
                    {
                        tareasobs += "<input type = \"text\" class=\"form-control\" id=\"idobstarea_input" + i + "\"  value=\"" + obs + "\"/>";
                    }
                    else
                    {
                        tareasobs += "<input type = \"text\" class=\"form-control\" id=\"idobstarea_input" + i + "\" >";
                    }
                    tareasobs += "</div>";
                    tareasobs += "</div>";
                    tareasobs += "</div>";
                }

                outTxt += "$(\"#divTablaTareasGrupo\").html('" + tareasobs + "');";
            }
            else
            {
                outTxt += "$(\"#divTablaTareasGrupo\").html('" + "No hay tareas programadas para realizar observaciones." + "');";

            }

            if (dtActividades.Rows.Count > 0)
            {
                string actividadsobs = "";
                actividadsobs += "<div class=\"row\">";
                actividadsobs += "<div class=\"col-sm-6\">";
                actividadsobs += "<div class=\"form-group\">";
                actividadsobs += "<label for=\"user\">Actividad del proyecto</label>";
                actividadsobs += "</div>";
                actividadsobs += "</div>";
                actividadsobs += "<div class=\"col-sm-6\">";
                actividadsobs += "<div class=\"form-group\">";
                actividadsobs += "<label for=\"user\">Resultados de Observaciones</label>";
                actividadsobs += "</div>";
                actividadsobs += "</div>";
                actividadsobs += "</div>";
                for (int i = 0; i <= dtActividades.Rows.Count - 1; i++)
                {
                    actividadsobs += "<div class=\"row\">";
                    actividadsobs += "<input type = \"hidden\" id=\"idactividad_input" + i + "\" value=\"" + formato(dtActividades.Rows[i]["idActividad"].ToString().Trim()) + "\"/>";
                    actividadsobs += "<div class=\"col-sm-6\">";
                    actividadsobs += "<div class=\"form-group\">";
                    actividadsobs += formato(dtActividades.Rows[i]["NomActividad"].ToString().Trim());
                    actividadsobs += "</div>";
                    actividadsobs += "</div>";
                    actividadsobs += "<div class=\"col-sm-6\">";
                    actividadsobs += "<div class=\"form-group\">";
                    string obs = formato(dtActividades.Rows[i]["observacion"].ToString().Trim());
                    if (!String.IsNullOrEmpty(obs))
                    {
                        actividadsobs += "<input type = \"text\" class=\"form-control\" id=\"idobsactividad_input" + i + "\"  value=\"" + obs + "\"/>";
                    }
                    else
                    {
                        actividadsobs += "<input type = \"text\" class=\"form-control\" id=\"idobsactividad_input" + i + "\" >";
                    }
                    actividadsobs += "</div>";
                    actividadsobs += "</div>";
                    actividadsobs += "</div>";
                }

                outTxt += "$(\"#divActividadesProy\").html('" + actividadsobs + "');";
            }
            else
            {
                outTxt += "$(\"#divActividadesProy\").html('" + "No hay actividades programadas para realizar observaciones." + "');";

            }

            return outTxt;
        }

        public DataTable listarTipoAudiencias() {
            DataTable dtInfo = new DataTable();
            dtInfo = Models.clsAudiencias.listarTipoAudiencias()[0];
            return dtInfo;
        }

        public string insFechaAudiencias(string cod_bpin, int tipo_audiencia, string id_municipio, DateTime fecha, int id_usuario,string direccion)
        {
            string outTxt = "";
            outTxt = Models.clsAudiencias.insFechaAudiencias(cod_bpin, tipo_audiencia, id_municipio, fecha, id_usuario,direccion);
            return outTxt;
        }
    }
}
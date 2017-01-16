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


        public string insInformeProceso(string xml_info)
        {
            string outTxt = "";
            outTxt = Models.clsAudiencias.insInformeProceso(xml_info);
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
            DataTable dtParams = listaInfo[4];

            String idInforme ="";
            String divInforme ="";

            if (dtParams.Rows.Count > 0)
            {
                idInforme = dtParams.Rows[0]["idInforme"].ToString();
            }
            if (String.IsNullOrEmpty(idInforme))
            {
                divInforme = "<input type = \"hidden\" id = \"hdidinforme\" runat = \"server\" />";

            }
            else
            {
                divInforme = "<input type = \"hidden\" id = \"hdidinforme\" runat = \"server\" value=\""+idInforme+"\" />";

            }
            outTxt += "$(\"#divInforme\").html('" + divInforme + "');";


            if (dtTareas.Rows.Count > 0)
            {
                string tareasobs = "";
                tareasobs += "<div class=\"row \">";
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
                    tareasobs += "<div class=\"row ObsTareas\">";
                    tareasobs += "<input type = \"hidden\"  class=\"form-control idTarea\"  id=\"idtarea_input" + i +"\" value=\"" + formato(dtTareas.Rows[i]["idTarea"].ToString().Trim()) + "\"/>";
                    tareasobs += "<div class=\"col-sm-3\">";
                    tareasobs += "<div class=\"form-group\">";
                    tareasobs += formato(dtTareas.Rows[i]["detalle"].ToString().Trim());
                    tareasobs += "</div>";
                    tareasobs += "</div>";
                    tareasobs += "<div class=\"col-sm-2\">";
                    tareasobs += "<div class=\"form-group\">";
                    tareasobs += formato(dtTareas.Rows[i]["responsable"].ToString().Trim());
                    tareasobs += "</div>";
                    tareasobs += "</div>";
                    tareasobs += "<div class=\"col-sm-2\"><div class=\"form-group\">";
                    tareasobs += formato(dtTareas.Rows[i]["fecha"].ToString().Trim());
                    tareasobs += "</div>";
                    tareasobs += "</div>";
                    tareasobs += "<div class=\"col-sm-1\">";
                    tareasobs += "<div class=\"form-group\">";
                    string PorcTarea = formato(dtTareas.Rows[i]["Porcentaje"].ToString().Trim());
                    if (!String.IsNullOrEmpty(PorcTarea))
                    {
                        tareasobs += "<input type = \"text\" class=\"form-control PorcTarea\" id=\"PorcTarea_input" + i + "\"  value=\"" + PorcTarea + "\"/>";
                    }
                    else
                    {
                        tareasobs += "<input type = \"text\" class=\"form-control PorcTarea\" id=\"PorcTarea_input" + i + "\" placeholder=\"%\">";
                    }
                    tareasobs += "</div>";
                    tareasobs += "</div>";
                    tareasobs += "<div class=\"col-sm-4\">";
                    tareasobs += "<div class=\"form-group\">";
                    string obs = formato(dtTareas.Rows[i]["observacion"].ToString().Trim());
                    if (!String.IsNullOrEmpty(obs))
                    {
                        tareasobs += "<input type = \"text\" class=\"form-control obsTarea\" id=\"idobstarea_input" + i + "\"  value=\"" + obs + "\"/>";
                    }
                    else
                    {
                        tareasobs += "<input type = \"text\" class=\"form-control obsTarea\" id=\"idobstarea_input" + i + "\" placeholder=\"Observaciones\">";
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
                    actividadsobs += "<div class=\"row ObsActividades\">";
                    actividadsobs += "<input type = \"hidden\" class=\"form-control idActividad\"  id=\"idactividad_input" + i + "\" value=\"" + formato(dtActividades.Rows[i]["idActividad"].ToString().Trim()) + "\"/>";
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
                        actividadsobs += "<input type = \"text\" class=\"form-control obsActividad\" id=\"idobsactividad_input" + i + "\"  value=\"" + obs + "\"/>";
                    }
                    else
                    {
                        actividadsobs += "<input type = \"text\" class=\"form-control obsActividad\" id=\"idobsactividad_input" + i + "\" placeholder=\"Observaciones\" >";
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

            string compromisosobs = "";
            int k = 0;
            if (dtCompromisos.Rows.Count > 0)
            {
                for ( k= 0; k <= dtCompromisos.Rows.Count - 1; k++)
                {
                    compromisosobs += "<div class=\"row ObsCompromisos\">";
                    compromisosobs += "<input type = \"hidden\"  class=\"form-control idCompromiso \" id=\"idcompromiso_input" + k + "\" value=\"" + formato(dtCompromisos.Rows[k]["idInfObservacionC"].ToString().Trim()) + "\"/>";
                    compromisosobs += "<div class=\"col-sm-4\">";
                    compromisosobs += "<div class=\"form-group\">";
                    String compro = formato(dtCompromisos.Rows[k]["Compromiso"].ToString().Trim());
                    if (!String.IsNullOrEmpty(compro))
                    {
                        compromisosobs += "<input type = \"text\" class=\"form-control Compromiso \" id=\"comprom_input" + k + "\"  value=\"" + compro + "\"/>";
                    }
                    else
                    {
                        compromisosobs += "<input type = \"text\" class=\"form-control Compromiso\" id=\"comprom_input" + k + "\" placeholder=\"Compromiso\" >";
                    }
                    compromisosobs += "</div>";
                    compromisosobs += "</div>";
                    compromisosobs += "<div class=\"col-sm-4\">";
                    compromisosobs += "<div class=\"form-group\">";
                    String respon = formato(dtCompromisos.Rows[k]["Responsable"].ToString().Trim());
                    if (!String.IsNullOrEmpty(respon))
                    {
                        compromisosobs += "<input type = \"text\" class=\"form-control ResponsableComp\" id=\"responcomp_input" + k + "\"  value=\"" + respon + "\"/>";
                    }
                    else
                    {
                        compromisosobs += "<input type = \"text\" class=\"form-control ResponsableComp\" id=\"responcomp_input" + k + "\" placeholder=\"Responsable\" >";
                    }
                    compromisosobs += "</div>";
                    compromisosobs += "</div>";
                    compromisosobs += "<div class=\"col-sm-4\">";
                    compromisosobs += "<div class=\"form-group\">";
                    string obs = formato(dtCompromisos.Rows[k]["observacion"].ToString().Trim());
                    if (!String.IsNullOrEmpty(obs))
                    {
                        compromisosobs += "<input type = \"text\" class=\"form-control ObsComprom\" id=\"obscomp_input" + k + "\"  value=\"" + obs + "\"/>";
                    }
                    else
                    {
                        compromisosobs += "<input type = \"text\" class=\"form-control ObsComprom\" id=\"obscomp_input" + k + "\" placeholder=\"Observaciones\" >";
                    }
                    compromisosobs += "</div>";
                    compromisosobs += "</div>";
                    compromisosobs += "</div>";
                }
            }
            compromisosobs += "<input type = \"hidden\" id=\"contadork\" value=\"" + k + "\"/>";

            outTxt += "$(\"#divtablacompobs\").html('" + compromisosobs + "');";

            string dudas = "";
            int d = 0;
            if (dtDudas.Rows.Count > 0)
            {
                for (d = 0; d <= dtDudas.Rows.Count - 1; d++)
                {
                    dudas += "<div class=\"row ObsDudas\">";
                    dudas += "<input type = \"hidden\" class=\"form-control idDuda\" id=\"idduda_input" + d + "\" value=\"" + formato(dtDudas.Rows[d]["idInfObservacionD"].ToString().Trim()) + "\"/>";
                    dudas += "<div class=\"col-sm-8\">";
                    dudas += "<div class=\"form-group\">";
                    String duda = formato(dtDudas.Rows[d]["Duda"].ToString().Trim());
                    if (!String.IsNullOrEmpty(duda))
                    {
                        dudas += "<input type = \"textarea\" class=\"form-control Duda\" id=\"duda_input" + d + "\"  value=\"" + duda + "\"/>";
                    }
                    else
                    {
                        dudas += "<input type = \"textarea\" class=\"form-control Duda\" id=\"duda_input" + d + "\" placeholder=\"Ejemplo: ¿Por qué hay retrasos en la obra, si el cronograma detalla que a la fecha debe estar el primer piso del hospital construido?\" >";
                    }
                    dudas += "</div>";
                    dudas += "</div>";
                    dudas += "<div class=\"col-sm-4\">";
                    dudas += "<div class=\"form-group\">";
                    String respon = formato(dtCompromisos.Rows[d]["Responsable"].ToString().Trim());
                    if (!String.IsNullOrEmpty(respon))
                    {
                        dudas += "<input type = \"textarea\" class=\"form-control ResponsableD\" id=\"responduda_input" + d + "\"  value=\"" + respon + "\"/>";
                    }
                    else
                    {
                        dudas += "<input type = \"textarea\" class=\"form-control ResponsableD\" id=\"responduda_input" + d + "\" placeholder=\"Responsable\" >";
                    }
                    dudas += "</div>";
                    dudas += "</div>";
                    dudas += "</div>";
                }
            }
            dudas += "<input type = \"hidden\" id=\"contadord\" value=\"" + d + "\"/>";

            outTxt += "$(\"#divDudas\").html('" + dudas + "');";

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
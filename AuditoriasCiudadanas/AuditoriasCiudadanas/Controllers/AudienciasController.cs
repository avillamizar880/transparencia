using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Globalization;

namespace AuditoriasCiudadanas.Controllers
{
    public class AudienciasController
    {
        public string formato(string cadena)
        {
            //return HttpUtility.HtmlEncode(cadena);
            return HttpUtility.HtmlEncode(cadena).Replace("\r", " ").Replace("\n", " ");
        }

        public string formato_fecha(string cadena)
        {
            string cad_aux = cadena;
            if (!string.IsNullOrEmpty(cadena))
            {
                DateTime dt = Convert.ToDateTime(cadena);
                cad_aux = dt.ToString("d MMMM yyyy",
                        CultureInfo.CreateSpecificCulture("es-co"));
            }

            return cad_aux;
        }

        public string insActaReuniones(string cod_bpin, DateTime fecha, string tema, string ruta_arc, int id_usuario, int id_lugar)
        {
            string outTxt = "";
            outTxt = Models.clsAudiencias.insActaReuniones(cod_bpin, fecha, tema, ruta_arc, id_usuario, id_lugar);
            return outTxt;
        }

        public string insRegObservaciones(string cod_bpin, string info_faltante, string info_clara, string info_completa, string comunidad_benef, string dudas, DateTime fecha_posterior_1, DateTime fecha_posterior_2, int id_usuario,int id_grupo)
        {
            string outTxt = "";
            outTxt = Models.clsAudiencias.insRegObservaciones(cod_bpin, info_faltante, info_clara, info_completa, comunidad_benef, dudas, fecha_posterior_1, fecha_posterior_2, id_usuario,id_grupo);
            return outTxt;
        }


        public string pdfRegObservaciones(string cod_bpin)
        {
            string outTxt = "";
            outTxt = Models.clsAudiencias.pdfRegObservaciones(cod_bpin);
            return outTxt;
        }

        public string insProponerFechaReuPrevias(string cod_bpin, DateTime fecha, int id_usuario)
        {
            string outTxt = "";
            outTxt = Models.clsAudiencias.insProponerFechaReuPrevias(cod_bpin, fecha, id_usuario);
            return outTxt;
        }

        public string insCompromisos(string xml_info, int num_asistentes)
        {
            string outTxt = "";
            outTxt = Models.clsAudiencias.insCompromisos(xml_info, num_asistentes);
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

        public string obtInformeProceso(string cod_bpin, int id_GAC, int tipo_audiencia, int idaudiencia, int estado)
        {
            string outTxt = "";
            List<DataTable> listaInfo = new List<DataTable>();
            listaInfo = Models.clsAudiencias.obtInformeProceso(cod_bpin, id_GAC, tipo_audiencia, idaudiencia);
            DataTable dtTareas = listaInfo[0];
            DataTable dtActividades = listaInfo[1];
            DataTable dtCompromisos = listaInfo[2];
            DataTable dtDudas = listaInfo[3];
            DataTable dtParams = listaInfo[4];

            String idInforme = "";
            String divInforme = "";
            String ronly = "";

            if (estado == 2)
            { ronly = "readonly"; }

            if (dtParams.Rows.Count > 0)
            {
                idInforme = dtParams.Rows[0]["idInforme"].ToString();
            }
            if (String.IsNullOrEmpty(idInforme))
            {
                divInforme = "<input " + ronly + " type = \"hidden\" id = \"hdidinforme\" runat = \"server\" />";

            }
            else
            {
                divInforme = "<input " + ronly + " type = \"hidden\" id = \"hdidinforme\" runat = \"server\" value=\"" + idInforme + "\" />";

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
                tareasobs += "<div class=\"col-sm-2\">";
                tareasobs += "<div class=\"form-group\">";
                tareasobs += "<label for=\"user\">Responsable(s)</label>";
                tareasobs += "</div>";
                tareasobs += "</div>";
                tareasobs += "<div class=\"col-sm-2\"><div class=\"form-group\">";
                tareasobs += "<label for=\"dtp_input2\" class=\"control-label\">Fecha</label>";
                tareasobs += "</div>";
                tareasobs += "</div>";
                tareasobs += "<div class=\"col-sm-1\">";
                tareasobs += "<div class=\"form-group\">";
                tareasobs += "<label for=\"dtp_input2\" class=\"control-label\">Porc.</label>";
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
                    tareasobs += "<input type = \"hidden\"  class=\"form-control idTarea\"  id=\"idtarea_input" + i + "\" value=\"" + formato(dtTareas.Rows[i]["idTarea"].ToString().Trim()) + "\"/>";
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
                    tareasobs += formato_fecha(formato(dtTareas.Rows[i]["fecha"].ToString().Trim()));
                    tareasobs += "</div>";
                    tareasobs += "</div>";
                    tareasobs += "<div class=\"col-sm-1\">";
                    tareasobs += "<div class=\"form-group\">";
                    string PorcTarea = formato(dtTareas.Rows[i]["Porcentaje"].ToString().Trim());
                    if (!String.IsNullOrEmpty(PorcTarea))
                    {
                        tareasobs += "<input " + ronly + "  type = \"text\" class=\"form-control PorcTarea\" id=\"PorcTarea_input" + i + "\"  value=\"" + PorcTarea + "\"/>";
                    }
                    else
                    {
                        tareasobs += "<input " + ronly + " type = \"text\" class=\"form-control PorcTarea\" id=\"PorcTarea_input" + i + "\" placeholder=\"%\">";
                    }
                    tareasobs += "</div>";
                    tareasobs += "</div>";
                    tareasobs += "<div class=\"col-sm-4\">";
                    tareasobs += "<div class=\"form-group\">";
                    string obs = formato(dtTareas.Rows[i]["observacion"].ToString().Trim());
                    if (!String.IsNullOrEmpty(obs))
                    {
                        tareasobs += "<input " + ronly + " type = \"text\" class=\"form-control obsTarea\" id=\"idobstarea_input" + i + "\"  value=\"" + obs + "\"/>";
                    }
                    else
                    {
                        tareasobs += "<input " + ronly + " type = \"text\" class=\"form-control obsTarea\" id=\"idobstarea_input" + i + "\" placeholder=\"Observaciones\">";
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
                        actividadsobs += "<input  " + ronly + " type = \"text\" class=\"form-control obsActividad\" id=\"idobsactividad_input" + i + "\"  value=\"" + obs + "\"/>";
                    }
                    else
                    {
                        actividadsobs += "<input " + ronly + " type = \"text\" class=\"form-control obsActividad\" id=\"idobsactividad_input" + i + "\" placeholder=\"Observaciones\" >";
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
                for (k = 0; k <= dtCompromisos.Rows.Count - 1; k++)
                {
                    compromisosobs += "<div class=\"row ObsCompromisos\">";
                    compromisosobs += "<input type = \"hidden\"  class=\"form-control idCompromiso \" id=\"idcompromiso_input" + k + "\" value=\"" + formato(dtCompromisos.Rows[k]["idInfObservacionC"].ToString().Trim()) + "\"/>";
                    compromisosobs += "<div class=\"col-sm-4\">";
                    compromisosobs += "<div class=\"form-group\">";
                    String compro = formato(dtCompromisos.Rows[k]["Compromiso"].ToString().Trim());
                    if (!String.IsNullOrEmpty(compro))
                    {
                        compromisosobs += "<input " + ronly + " type = \"text\" class=\"form-control Compromiso \" id=\"comprom_input" + k + "\"  value=\"" + compro + "\"/>";
                    }
                    else
                    {
                        compromisosobs += "<input " + ronly + " type = \"text\" class=\"form-control Compromiso\" id=\"comprom_input" + k + "\" placeholder=\"Compromiso\" >";
                    }
                    compromisosobs += "</div>";
                    compromisosobs += "</div>";
                    compromisosobs += "<div class=\"col-sm-4\">";
                    compromisosobs += "<div class=\"form-group\">";
                    String respon = formato(dtCompromisos.Rows[k]["Responsable"].ToString().Trim());
                    if (!String.IsNullOrEmpty(respon))
                    {
                        compromisosobs += "<input " + ronly + " type = \"text\" class=\"form-control ResponsableComp\" id=\"responcomp_input" + k + "\"  value=\"" + respon + "\"/>";
                    }
                    else
                    {
                        compromisosobs += "<input " + ronly + " type = \"text\" class=\"form-control ResponsableComp\" id=\"responcomp_input" + k + "\" placeholder=\"Responsable\" >";
                    }
                    compromisosobs += "</div>";
                    compromisosobs += "</div>";
                    compromisosobs += "<div class=\"col-sm-4\">";
                    compromisosobs += "<div class=\"form-group\">";
                    string obs = formato(dtCompromisos.Rows[k]["observacion"].ToString().Trim());
                    if (!String.IsNullOrEmpty(obs))
                    {
                        compromisosobs += "<input " + ronly + " type = \"text\" class=\"form-control ObsComprom\" id=\"obscomp_input" + k + "\"  value=\"" + obs + "\"/>";
                    }
                    else
                    {
                        compromisosobs += "<input " + ronly + " type = \"text\" class=\"form-control ObsComprom\" id=\"obscomp_input" + k + "\" placeholder=\"Observaciones\" >";
                    }
                    compromisosobs += "</div>";
                    compromisosobs += "</div>";
                    compromisosobs += "</div>";
                }
            }
            compromisosobs += "<input type = \"hidden\" id=\"contadork\" value=\"" + k + "\"/>";

            outTxt += "$(\"#divtablacompobs\").html('" + compromisosobs + "');";

            string dudas = "";
            if (tipo_audiencia == 1)
            {
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
                            dudas += "<input " + ronly + " type = \"textarea\" class=\"form-control Duda\" id=\"duda_input" + d + "\"  value=\"" + duda + "\"/>";
                        }
                        else
                        {
                            dudas += "<input " + ronly + " type = \"textarea\" class=\"form-control Duda\" id=\"duda_input" + d + "\" placeholder=\"Ejemplo: ¿Por qué hay retrasos en la obra, si el cronograma detalla que a la fecha debe estar el primer piso del hospital construido?\" >";
                        }
                        dudas += "</div>";
                        dudas += "</div>";
                        dudas += "<div class=\"col-sm-4\">";
                        dudas += "<div class=\"form-group\">";
                        String respon = formato(dtDudas.Rows[d]["Responsable"].ToString().Trim());
                        if (!String.IsNullOrEmpty(respon))
                        {
                            dudas += "<input " + ronly + " type = \"textarea\" class=\"form-control ResponsableD\" id=\"responduda_input" + d + "\"  value=\"" + respon + "\"/>";
                        }
                        else
                        {
                            dudas += "<input " + ronly + " type = \"textarea\" class=\"form-control ResponsableD\" id=\"responduda_input" + d + "\" placeholder=\"Responsable\" >";
                        }
                        dudas += "</div>";
                        dudas += "</div>";
                        dudas += "</div>";
                    }
                }
                dudas += "<input type = \"hidden\" id=\"contadord\" value=\"" + d + "\"/>";
            }
            else
            {
                int d = 0;
                if ((dtDudas.Rows.Count > 0) && (!String.IsNullOrEmpty(dtDudas.Rows[0]["idInfObservacionD"].ToString())))
                {
                    for (d = 0; d <= dtDudas.Rows.Count - 1; d++)
                    {
                        dudas += "<div class=\"row ObsDudas\">";
                        dudas += "<input type = \"hidden\" class=\"form-control idDuda\" id=\"idduda_input" + d + "\" value=\"" + formato(dtDudas.Rows[d]["idInfObservacionD"].ToString().Trim()) + "\"/>";
                        dudas += "<div class=\"col-sm-6\">";
                        dudas += "<div class=\"form-group\">";
                        String duda = formato(dtDudas.Rows[d]["Duda"].ToString().Trim());
                        if (!String.IsNullOrEmpty(duda))
                        {
                            dudas += "<input " + ronly + " type = \"textarea\" class=\"form-control Duda\" id=\"duda_input" + d + "\"  value=\"" + duda + "\"/>";
                        }
                        else
                        {
                            dudas += "<input " + ronly + " type = \"textarea\" class=\"form-control Duda\" id=\"duda_input" + d + "\" placeholder=\"Sobre la ejecución del proyecto\" >";
                        }
                        dudas += "</div>";
                        dudas += "</div>";
                        dudas += "<div class=\"col-sm-6\">";
                        dudas += "<div class=\"form-group\">";
                        String conclu = formato(dtDudas.Rows[d]["Conclusiones"].ToString().Trim());
                        if (!String.IsNullOrEmpty(conclu))
                        {
                            dudas += "<input " + ronly + " type = \"textarea\" class=\"form-control ConclusionesD\" id=\"responduda_input" + d + "\"  value=\"" + conclu + "\"/>";
                        }
                        else
                        {
                            dudas += "<input " + ronly + " type = \"textarea\" class=\"form-control ConclusionesD\" id=\"responduda_input" + d + "\" placeholder=\"Conclusiones\" >";
                        }
                        dudas += "</div>";
                        dudas += "</div>";
                        dudas += "</div>";
                    }
                }
                else
                {
                    dudas += "<div class=\"row ObsDudas\">";
                    dudas += "<div class=\"col-sm-6\">";
                    dudas += "<div class=\"form-group\">";
                    dudas += "<input " + ronly + " type = \"textarea\" class=\"form-control Duda\" id=\"duda_input" + d + "\" placeholder=\"Sobre la ejecución del proyecto\" >";
                    dudas += "</div>";
                    dudas += "</div>";
                    dudas += "<div class=\"col-sm-6\">";
                    dudas += "<div class=\"form-group\">";
                    dudas += "<input " + ronly + " type = \"textarea\" class=\"form-control ConclusionesD\" id=\"responduda_input" + d + "\" placeholder=\"Conclusiones\" >";
                    dudas += "</div></div>";
                    dudas += "</div>";
                    d++;
                    dudas += "<div class=\"row ObsDudas\">";
                    dudas += "<div class=\"col-sm-6\">";
                    dudas += "<div class=\"form-group\">";
                    dudas += "<input " + ronly + " type = \"textarea\" class=\"form-control Duda\" id=\"duda_input" + d + "\" placeholder=\"Sobre las Audiencias Públicas\" >";
                    dudas += "</div>";
                    dudas += "</div>";
                    dudas += "<div class=\"col-sm-6\">";
                    dudas += "<div class=\"form-group\">";
                    dudas += "<input " + ronly + " type = \"textarea\" class=\"form-control ConclusionesD\" id=\"responduda_input" + d + "\" placeholder=\"Conclusiones\" >";
                    dudas += "</div></div>";
                    dudas += "</div>";
                    d++;
                    dudas += "<div class=\"row ObsDudas\">";
                    dudas += "<div class=\"col-sm-6\">";
                    dudas += "<div class=\"form-group\">";
                    dudas += "<input " + ronly + " type = \"textarea\" class=\"form-control Duda\" id=\"duda_input" + d + "\" placeholder=\"Sobre el Grupo Auditor Ciudadano\" >";
                    dudas += "</div>";
                    dudas += "</div>";
                    dudas += "<div class=\"col-sm-6\">";
                    dudas += "<div class=\"form-group\">";
                    dudas += "<input " + ronly + " type = \"textarea\" class=\"form-control ConclusionesD\" id=\"responduda_input" + d + "\" placeholder=\"Conclusiones\" >";
                    dudas += "</div></div>";
                    dudas += "</div>";

                }
                dudas += "<input type = \"hidden\" id=\"contadord\" value=\"" + d + "\"/>";
            }
            outTxt += "$(\"#divDudas\").html('" + dudas + "');";

            return outTxt;
        }

        public DataTable listarTipoAudiencias()
        {
            DataTable dtInfo = new DataTable();
            dtInfo = Models.clsAudiencias.listarTipoAudiencias()[0];
            return dtInfo;
        }

        public string insFechaAudiencias(string cod_bpin, int tipo_audiencia, string id_municipio, DateTime fecha, int id_usuario, string direccion)
        {
            string outTxt = "";
            outTxt = Models.clsAudiencias.insFechaAudiencias(cod_bpin, tipo_audiencia, id_municipio, fecha, id_usuario, direccion);
            return outTxt;
        }

        public string obtInformePrevioInicio(string cod_bpin)
        {
            string outTxt = "";
            List<DataTable> lista_info = Models.clsAudiencias.obtRegObservaciones(cod_bpin);
            if (lista_info.Count >= 1)
            {
                DataTable dtInfo = lista_info[0];
                outTxt += "<div class=\"container\">";
                outTxt += "<h1 style=\"color:#0091ab;border-bottom: 2px solid #3ab54a;padding-bottom: 15px;\">Primer Informe con Observaciones Previas</h1><br><br>";
                if (dtInfo.Rows.Count > 0)
                {
                    for (int i = 0; i < dtInfo.Rows.Count; i++)
                    {
                        outTxt += "<p>Registrado por: " + formato(dtInfo.Rows[i]["Nombre"].ToString().Trim()) + ", el día " + formato_fecha(dtInfo.Rows[i]["fechaCreacion"].ToString().Trim()) + "</p><br>";
                        outTxt += "<table>";
                        outTxt += "<tr><td style=\"font-weight:bold\"><span>1.¿Qué información hace falta para analizar de manera adecuada el proyecto?</span></td></tr>";
                        outTxt += "<tr><td><span>" + formato(dtInfo.Rows[i]["infoFaltante"].ToString().Trim()) + "</span></td></tr>";
                        outTxt += "<tr><td style=\"font-weight:bold\"><span>2.¿El proyecto tiene la información completa cargada al aplicativo?</span></td></tr>";
                        outTxt += "<tr><td><span>" + formato(dtInfo.Rows[i]["infoCompleta"].ToString().Trim()) + "</span></td></tr>";
                        outTxt += "<tr><td style=\"font-weight:bold\"><span>3.¿Qué debe explicarse en una Audiencia de Inicio o no es clara? ¿Por qué?</span></td></tr>";
                        outTxt += "<tr><td><span>" + formato(dtInfo.Rows[i]["infoClara"].ToString().Trim()) + "</span></td></tr>";
                        outTxt += "<tr><td style=\"font-weight:bold\"><span>4.¿Cuáles son las dudas que la comunidad beneficiaria tiene sobre el proyecto y su alcance?</span></td></tr>";
                        outTxt += "<tr><td><span>" + formato(dtInfo.Rows[i]["ComunidadBenef"].ToString().Trim()) + "</span></td></tr>";
                        outTxt += "<tr><td style=\"font-weight:bold\"><span>5.Enumere las dudas que deben ser resueltas en la Audiencia de Inicio para que su trabajo de control social tenga herramientas suficientes para continuar</span></td></tr>";
                        outTxt += "<tr><td><span>" + formato(dtInfo.Rows[i]["dudas"].ToString().Trim()) + "</span></td></tr></br>";
                        outTxt += "</table>";
                        outTxt += "<br>";
                        outTxt += "<p style=\"color:#0091ab; font-weight:300\">Propuestas de Fechas sobre Audiencias posteriores</p></br>";
                        outTxt += "<table><tr><td style=\"font-weight:bold;padding-right:10px;\"><span>Fecha de Audiencia de Seguimiento</span></td><td style=\"font-weight:bold;padding-right:10px;\">Fecha de Audiencia de Cierre</td></tr>";
                        outTxt += "<tr><td>" + formato_fecha(dtInfo.Rows[i]["fechaCreacion"].ToString().Trim()) + "</td><td>" + formato_fecha(dtInfo.Rows[i]["fechaCreacion"].ToString().Trim()) + "</td></tr></table>";
                    }
                }
                outTxt += "</div>";

            }
            return outTxt;
        }


        public string obtRegCompromisos(int id_audiencia)
        {
            string outTxt = "";
            List<DataTable> lista_info = Models.clsAudiencias.obtRegCompromisos(id_audiencia);
            if (lista_info.Count >= 1)
            {
                DataTable dtCompromisos = lista_info[0];
                DataTable dtAsistentes = lista_info[1];
                DataTable dtAdjuntos = lista_info[2];
                outTxt += "<div class=\"container\">";
                outTxt += "<h1 class=\"text-center\">Registro de Compromisos</h1>";
                //outTxt += "<p>Registrado por: " + formato(dtCompromisos.Rows[0]["Nombre"].ToString().Trim()) + ", el día " + formato_fecha(dtCompromisos.Rows[0]["fecha_cre"].ToString().Trim()) + "</p><br>";
                outTxt += "<p>Registrado por: " + formato(dtCompromisos.Rows[0]["Nombre"].ToString().Trim()) + "</p><br>";
                if (dtAsistentes.Rows.Count > 0)
                {
                    outTxt += "<div class=\"panel-heading\">";
                    outTxt += "<h4 style=\"color:#0091ab;border-bottom: 2px solid #3ab54a;padding-bottom: 15px;\">Asistentes:</h4><br>";
                    outTxt += "<p style=\"font-weight:bold\">Cantidad de personas que asistieron por cada categoria:</p></div>";
                    outTxt += "<table>";
                    outTxt += "<thead>";
                    outTxt += "<tr>";
                    outTxt += "<th style=\"padding:10px;font-weight:bold\">Categoría</th>";
                    outTxt += "<th style=\"padding:10px;font-weight:bold\">Cantidad</th>";
                    outTxt += "</tr></thead>";
                    outTxt += "<tbody>";
                    for (int i = 0; i < dtAsistentes.Rows.Count; i++)
                    {
                        outTxt += "<tr><td style=\"padding: 10px;\">";
                        outTxt += formato(dtAsistentes.Rows[i]["nom_tipo"].ToString().Trim());
                        outTxt += "</td><td style=\"padding: 10px;\">";
                        outTxt += formato(dtAsistentes.Rows[i]["cantidad"].ToString().Trim());
                        outTxt += "</td></tr>";
                    }
                    outTxt += "</tbody></table>";
                }
                if (dtCompromisos.Rows.Count > 0)
                {
                    outTxt += "<div class=\"panel-heading\">";
                    outTxt += "<h4 style=\"color:#0091ab;border-bottom: 2px solid #3ab54a;padding-bottom: 15px;\">Compromisos:</h4><br>";
                    outTxt += "<p style=\"font-weight:bold\">Durante las Audiencias cada uno de los actores puede asumir compromisos teniendo en cuenta sus competencias de ley.</p>";
                    outTxt += "</div>";
                    outTxt += "<br>";
                    outTxt += "<table style=\"border-collapse: separate;\">";
                    outTxt += "<thead>";
                    outTxt += "<tr>";
                    outTxt += "<th style=\"padding:10px;font-weight:bold\">Título del Compromiso</th>";
                    outTxt += "<th style=\"padding:10px;font-weight:bold\">Responsables(s)</th>";
                    outTxt += "<th style=\"padding:10px;font-weight:bold\">Fecha de Cumplimiento</th>";
                    outTxt += "</tr>";
                    outTxt += "</thead>";
                    outTxt += "<tbody>";
                    for (int i = 0; i < dtCompromisos.Rows.Count; i++)
                    {
                        outTxt += "<tr>";
                        outTxt += "<td style=\"padding:10px;\">" + formato(dtCompromisos.Rows[i]["compromiso"].ToString().Trim()) + "</td>";
                        outTxt += "<td style=\"padding:10px;\">" + formato(dtCompromisos.Rows[i]["responsable"].ToString().Trim()) + "</td>";
                        outTxt += "<td style=\"padding:10px;\">" + formato_fecha(dtCompromisos.Rows[i]["fecha"].ToString().Trim()) + "</td>";
                        outTxt += "</tr>";
                    }
                    outTxt += "</tbody>";
                    outTxt += "</table>";

                }
                if (dtAdjuntos.Rows.Count > 0)
                {
                    outTxt += "<div class=\"panel-heading\"><h4 style=\"color:#0091ab;border-bottom: 2px solid #3ab54a;padding-bottom: 15px;\">Fotografías de la Sesión:</h4></div>";
                    outTxt += "<table>";
                    for (int i = 0; i < dtAdjuntos.Rows.Count; i++)
                    {
                        string ruta_img = dtAdjuntos.Rows[i]["url"].ToString().Trim();
                        outTxt += "<tr>";
                        outTxt += "<td style=\"padding:10px;\">";
                        outTxt += "<img src=\"" + ruta_img + "\">";
                        outTxt += "</td>";
                        outTxt += "</tr>";

                    }
                    outTxt += "</table>";
                }
                outTxt += "</div>";
            }
            return outTxt;
        }

        public string obtActaReunionPrevia(string cod_bpin)
        {
            string outTxt = "";
            List<DataTable> lista_info = Models.clsAudiencias.obtActaReunionPrevia(cod_bpin);
            if (lista_info.Count >= 1)
            {
                DataTable dtInfo = lista_info[0];
                outTxt += "<div class=\"container\">";
                outTxt += "<h1 style=\"color:#0091ab;border-bottom: 2px solid #3ab54a;padding-bottom: 15px;\">Acta de Reuniones Previas</h1><br><br>";
                if (dtInfo.Rows.Count > 0)
                {
                    for (int i = 0; i < dtInfo.Rows.Count; i++)
                    {
                        string url_asistencia = formato(dtInfo.Rows[i]["ruta"].ToString().Trim());
                        outTxt += "<p>Registrado por: " + formato(dtInfo.Rows[i]["Nombre"].ToString().Trim()) + ", el día " + formato_fecha(dtInfo.Rows[i]["fecha"].ToString().Trim()) + "</p><br>";
                        outTxt += "<div>";
                        outTxt += "<h4 style=\"color:#0091ab;border-bottom: 2px solid #3ab54a;padding-bottom: 15px;\">Tema:</h4>";
                        outTxt += "<span>" + formato(dtInfo.Rows[i]["descripcion"].ToString().Trim()) + "</span>";
                        outTxt += "</div>";
                        outTxt += "<table style=\"border-collapse: separate;\">";
                        outTxt += "<thead>";
                        outTxt += "<tr>";
                        outTxt += "<th style=\"padding:10px;color:#0091ab;border-bottom: 2px solid #3ab54a;padding-bottom: 15px;\">Lugar</th>";
                        outTxt += "<th style=\"padding:10px;color:#0091ab;border-bottom: 2px solid #3ab54a;padding-bottom: 15px;\">Fecha</th>";
                        outTxt += "</tr>";
                        outTxt += "</thead>";
                        outTxt += "<tbody>";
                        outTxt += "<tr>";
                        outTxt += "<td style=\"padding:10px;\">" + formato(dtInfo.Rows[i]["municipio"].ToString().Trim()) + "</td>";
                        outTxt += "<td style=\"padding:10px;\">" + formato_fecha(dtInfo.Rows[i]["fecha"].ToString().Trim()) + "</td>";
                        outTxt += "</tr>";
                        outTxt += "</tbody>";
                        outTxt += "</table>";
                        outTxt += "<br>";
                        if (!string.IsNullOrEmpty(url_asistencia))
                        {
                            outTxt += "<div><h4 style=\"color:#0091ab;border-bottom: 2px solid #3ab54a;padding-bottom: 15px;\">Fotografía de la Asistencia:</h4></div><br>";
                            outTxt += "<table>";
                            //string ruta_img = "../../" + url_asistencia;
                            string ruta_img = url_asistencia;
                            outTxt += "<tr>";
                            outTxt += "<td style=\"padding:10px;\">";
                            outTxt += "<img src=\"" + ruta_img + "\">";
                            outTxt += "</td>";
                            outTxt += "</tr>";
                            outTxt += "</table>";
                            outTxt += "<br>";
                        }
                    }

                }


                outTxt += "</div>";
            }
            return outTxt;
        }

        public string obtValoracionProyecto(string cod_bpin)
        {
            string outTxt = "";
            List<DataTable> lista_info = Models.clsAudiencias.obtValoracionProy(cod_bpin);
            if (lista_info.Count >= 1)
            {
                DataTable dtInfo = lista_info[0];
                outTxt += "<div class=\"container\">";
                outTxt += "<h1 style=\"color:#0091ab;border-bottom: 2px solid #3ab54a;padding-bottom: 15px;\">Valoración del proyecto</h1><br><br>";
                if (dtInfo.Rows.Count > 0)
                {
                    for (int i = 0; i < dtInfo.Rows.Count; i++)
                    {
                        outTxt += "<p>Registrado por: " + formato(dtInfo.Rows[i]["Nombre"].ToString().Trim()) + ", el día " + formato_fecha(dtInfo.Rows[i]["fechaCreacion"].ToString().Trim()) + "</p><br>";
                        outTxt += "<div>";
                        outTxt += "<h4 style=\"color:#0091ab;border-bottom: 2px solid #3ab54a;padding-bottom: 15px;\">•	Sobre la ejecución del proyecto:</h4>";
                        outTxt += "</div>";
                        outTxt += "<table>";
                        outTxt += "<tr><td style=\"font-weight:bold\"><span>1.	¿Las actividades proyectadas por el ejecutor del proyecto fueron ejecutadas en el tiempo establecido? </span></td></tr>";
                        outTxt += "<tr><td><span>Respuesta: " + formato(dtInfo.Rows[i]["ProyP1"].ToString().Trim()) + "</span></td></tr>";
                        outTxt += "<tr><td style=\"font-weight:bold\"><span>2.	¿Los tiempos de ejecución del proyecto se han cumplido, si no ha sido así se ha informado a la comunidad de manera adecuada para no afectar su proceso de seguimiento?</span></td></tr>";
                        outTxt += "<tr><td><span>Respuesta: " + formato(dtInfo.Rows[i]["ProyP2"].ToString().Trim()) + "</span></td></tr>";
                        outTxt += "<tr><td style=\"font-weight:bold\"><span>3.	¿El presupuesto asignado para el proyecto ha sido modificado? ¿Si es así, cree usted que la razón es alguna de las siguientes?</span></td></tr>";
                        String op = formato(dtInfo.Rows[i]["ProyP3Op"].ToString().Trim());
                        String op3 = "";
                        if (op == "1") { op3 = "Falta de estudios previos"; }
                        else if (op == "2") { op3 = "Falta de planeación efectiva"; }
                        else if (op == "3") { op3 = "Problemas de contratación"; }
                        else if (op == "4") { op3 = "Otra"; }
                        outTxt += "<tr><td><span>Respuesta: " + formato(dtInfo.Rows[i]["ProyP3"].ToString().Trim()) + " - " + formato(dtInfo.Rows[i]["ProyP3Cual"].ToString().Trim()) + " - " + op3 + "</span></td></tr>";
                        outTxt += "<tr><td style=\"font-weight:bold\"><span>4.	¿El proyecto cumplió con las metas y objetivos propuestos al momento de su formulación?</span></td></tr>";
                        outTxt += "<tr><td><span>Respuesta: " + formato(dtInfo.Rows[i]["ProyP4"].ToString().Trim()) + "</span></td></tr>";
                        outTxt += "<tr><td style=\"font-weight:bold\"><span>5.	¿El proyecto benefició la población establecida en la formulación?</span></td></tr>";
                        outTxt += "<tr><td><span>Respuesta: " + formato(dtInfo.Rows[i]["ProyP5"].ToString().Trim()) + "</span></td></tr></br>";
                        outTxt += "</table>";
                        outTxt += "<br>";

                        outTxt += "<div>";
                        outTxt += "<h4 style=\"color:#0091ab;border-bottom: 2px solid #3ab54a;padding-bottom: 15px;\">•	Sobre las Audiencias de públicas:</h4>";
                        outTxt += "</div>";
                        outTxt += "<table>";
                        outTxt += "<tr><td style=\"font-weight:bold\"><span>1.	Asistió a las Audiencias Públicas que se han realizado en el marco del proyecto </span></td></tr>";
                        outTxt += "<tr><td><span>Respuesta: " + formato(dtInfo.Rows[i]["AudP1"].ToString().Trim()) + "</span></td></tr>";
                        outTxt += "<tr><td style=\"font-weight:bold\"><span>2.	Considera que las Audiencias cumplieron sus objetivos como espacios de diálogo entre los actores más relevantes de la ejecución de los proyectos de regalías.</span></td></tr>";
                        outTxt += "<tr><td><span>Respuesta: " + formato(dtInfo.Rows[i]["AudP2"].ToString().Trim()) + "</span></td></tr>";
                        outTxt += "<tr><td style=\"font-weight:bold\"><span>3.	En su opinión, las dudas, comentarios y observaciones que se realizaron durante las audiencias públicas fueron atendidas de manera clara por el actor a quien se le formularon:</span></td></tr>";
                        outTxt += "<tr><td style=\"font-weight:bold\"><span>o	Grupo Auditor Ciudadano </span></td></tr>";
                        outTxt += "<tr><td><span>Respuesta: " + formato(dtInfo.Rows[i]["AudP3GAC"].ToString().Trim()) + "</span></td></tr>";
                        outTxt += "<tr><td style=\"font-weight:bold\"><span>o	Interventor</span></td></tr>";
                        outTxt += "<tr><td><span>Respuesta: " + formato(dtInfo.Rows[i]["AudP3Int"].ToString().Trim()) + "</span></td></tr></br>";
                        outTxt += "<tr><td style=\"font-weight:bold\"><span>o	Supervisor </span></td></tr>";
                        outTxt += "<tr><td><span>Respuesta: " + formato(dtInfo.Rows[i]["AudP3Sup"].ToString().Trim()) + "</span></td></tr>";
                        outTxt += "<tr><td style=\"font-weight:bold\"><span>o	Contratista</span></td></tr>";
                        outTxt += "<tr><td><span>Respuesta: " + formato(dtInfo.Rows[i]["AudP3Con"].ToString().Trim()) + "</span></td></tr></br>";
                        outTxt += "<tr><td style=\"font-weight:bold\"><span>o	Entidad Ejecutora </span></td></tr>";
                        outTxt += "<tr><td><span>Respuesta: " + formato(dtInfo.Rows[i]["AudP3Eje"].ToString().Trim()) + "</span></td></tr>";
                        outTxt += "<tr><td style=\"font-weight:bold\"><span>o	Entidad territorial</span></td></tr>";
                        outTxt += "<tr><td><span>Respuesta: " + formato(dtInfo.Rows[i]["AudP3Ent"].ToString().Trim()) + "</span></td></tr></br>";
                        outTxt += "<tr><td style=\"font-weight:bold\"><span>4.	Los compromisos estipulados en las audiencias para cada una de los actores se cumplieron de manera diligente y, por lo tanto, el espacio fue efectivo para lograr un ejercicio de seguimiento con mayor impacto por parte de los involucrados:</span></td></tr>";
                        outTxt += "<tr><td style=\"font-weight:bold\"><span>o	Grupo Auditor Ciudadano </span></td></tr>";
                        outTxt += "<tr><td><span>Respuesta: " + formato(dtInfo.Rows[i]["AudP4GAC"].ToString().Trim()) + "</span></td></tr>";
                        outTxt += "<tr><td style=\"font-weight:bold\"><span>o	Interventor</span></td></tr>";
                        outTxt += "<tr><td><span>Respuesta: " + formato(dtInfo.Rows[i]["AudP4Int"].ToString().Trim()) + "</span></td></tr></br>";
                        outTxt += "<tr><td style=\"font-weight:bold\"><span>o	Supervisor </span></td></tr>";
                        outTxt += "<tr><td><span>Respuesta: " + formato(dtInfo.Rows[i]["AudP4Sup"].ToString().Trim()) + "</span></td></tr>";
                        outTxt += "<tr><td style=\"font-weight:bold\"><span>o	Contratista</span></td></tr>";
                        outTxt += "<tr><td><span>Respuesta: " + formato(dtInfo.Rows[i]["AudP4Con"].ToString().Trim()) + "</span></td></tr></br>";
                        outTxt += "<tr><td style=\"font-weight:bold\"><span>o	Entidad Ejecutora </span></td></tr>";
                        outTxt += "<tr><td><span>Respuesta: " + formato(dtInfo.Rows[i]["AudP4Eje"].ToString().Trim()) + "</span></td></tr>";
                        outTxt += "<tr><td style=\"font-weight:bold\"><span>o	Entidad territorial</span></td></tr>";
                        outTxt += "<tr><td><span>Respuesta: " + formato(dtInfo.Rows[i]["AudP4Ent"].ToString().Trim()) + "</span></td></tr></br>";
                        outTxt += "<tr><td style=\"font-weight:bold\"><span>5.	Hubo voluntad de la Entidad Territorial por atender las necesidades del Grupo Auditor ciudadano y lograr consolidar un buen trabajo entre la alcaldía y los ciudadanos.</span></td></tr>";
                        outTxt += "<tr><td><span>Respuesta: " + formato(dtInfo.Rows[i]["AudP5"].ToString().Trim()) + "</span></td></tr>";
                        outTxt += "<tr><td style=\"font-weight:bold\"><span>6.	La convocatoria de la Audiencias fue adecuada, por lo cual los líderes sociales, los beneficiarios del proyecto y las autoridades territoriales tuvieron un espacio de interacción adecuado. </span></td></tr>";
                        outTxt += "<tr><td><span>Respuesta: " + formato(dtInfo.Rows[i]["AudP6"].ToString().Trim()) + "</span></td></tr>";
                        outTxt += "</table>";
                        outTxt += "<br>";

                        outTxt += "<div>";
                        outTxt += "<h4 style=\"color:#0091ab;border-bottom: 2px solid #3ab54a;padding-bottom: 15px;\">•	Sobre el Grupo Auditor Ciudadano:</h4>";
                        outTxt += "</div>";
                        outTxt += "<table>";
                        outTxt += "<tr><td style=\"font-weight:bold\"><span>1.	El Grupo Auditor Ciudadano cumplió adecuadamente con su plan de trabajo y promovió la participación de más ciudadanos en este proceso </span></td></tr>";
                        outTxt += "<tr><td><span>Respuesta: " + formato(dtInfo.Rows[i]["GacP1"].ToString().Trim()) + "</span></td></tr>";
                        outTxt += "<tr><td style=\"font-weight:bold\"><span>2.	El Grupo Auditor Ciudadano tuvo una comunicación fluida con los beneficiarios del proyecto.</span></td></tr>";
                        outTxt += "<tr><td><span>Respuesta: " + formato(dtInfo.Rows[i]["GacP2"].ToString().Trim()) + "</span></td></tr>";
                        outTxt += "<tr><td style=\"font-weight:bold\"><span>3.	La relación del Grupo Auditor Ciudadano con otros actores involucrados en la ejecución del proyecto benefició su seguimiento.</span></td></tr>";
                        outTxt += "<tr><td><span>Respuesta: " + formato(dtInfo.Rows[i]["GacP3"].ToString().Trim()) + "</span></td></tr>";
                        outTxt += "</table>";
                        outTxt += "<br>";

                    }

                }


                outTxt += "</div>";
            }
            return outTxt;
        }
    }
}

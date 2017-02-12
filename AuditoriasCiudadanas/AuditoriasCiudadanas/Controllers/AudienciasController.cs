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

        public string insRegObservaciones(string cod_bpin, string info_faltante, string info_clara, string info_completa, string comunidad_benef, string dudas, DateTime fecha_posterior_1, DateTime fecha_posterior_2, int id_usuario)
        {
            string outTxt = "";
            outTxt = Models.clsAudiencias.insRegObservaciones(cod_bpin, info_faltante, info_clara, info_completa, comunidad_benef, dudas, fecha_posterior_1, fecha_posterior_2, id_usuario);
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
                outTxt += "<p>Registrado por: " + formato(dtCompromisos.Rows[0]["Nombre"].ToString().Trim()) + ", el día " + formato_fecha(dtCompromisos.Rows[0]["fecha_cre"].ToString().Trim()) + "</p><br>";
                if (dtAsistentes.Rows.Count > 0)
                {
                    outTxt += "<div class=\"panel-heading\">";
                    outTxt += "<h4 style=\"color:#0091ab;border-bottom: 2px solid #3ab54a;padding-bottom: 15px;\">Asistentes:</h4>";
                    outTxt += "<span>Cantidad de personas que asistieron por cada categoria.</span></div>";
                    outTxt += "<table>";
                    outTxt += "<thead>";
                    outTxt += "<tr>";
                    outTxt += "<th style=\"padding:10px;\">Categoría</th>";
                    outTxt += "<th style=\"padding:10px;\">Cantidad</th>";
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
                    outTxt += "<h4 style=\"color:#0091ab;border-bottom: 2px solid #3ab54a;padding-bottom: 15px;\">Compromisos:</h4>";
                    outTxt += "<p>Durante las Audiencias cada uno de los actores puede asumir compromisos teniendo en cuenta sus competencias de ley.</p>";
                    outTxt += "</div>";
                    outTxt += "<table style=\"border-collapse: separate;\">";
                    outTxt += "<thead>";
                    outTxt += "<tr>";
                    outTxt += "<th style=\"padding:10px;\">Título del Compromisos</th>";
                    outTxt += "<th style=\"padding:10px;\">Responsables(s)</th>";
                    outTxt += "<th style=\"padding:10px;\">Fecha de Cumplimiento</th>";
                    outTxt += "</tr>";
                    outTxt += "</thead>";
                    outTxt += "<tbody>";
                    for (int i = 0; i < dtCompromisos.Rows.Count; i++)
                    {
                        outTxt += "<tr>";
                        outTxt += "<td style=\"padding:10px;\">" + formato(dtCompromisos.Rows[i]["compromiso"].ToString().Trim()) + "</td>";
                        outTxt += "<td style=\"padding:10px;\">" + formato(dtCompromisos.Rows[i]["responsable"].ToString().Trim()) + "</td>";
                        outTxt += "<td style=\"padding:10px;\">" + formato_fecha(dtAsistentes.Rows[i]["fecha"].ToString().Trim()) + "</td>";
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
                        string ruta_img = "../../" + dtAdjuntos.Rows[i]["url"].ToString().Trim();
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
                outTxt += "<h1 class=\"text-center\">Acta de Reuniones previas</h1>";
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
                        outTxt += "<th style=\"padding:10px;\">Lugar</th>";
                        outTxt += "<th style=\"padding:10px;\">Fecha</th>";
                        outTxt += "</tr>";
                        outTxt += "</thead>";
                        outTxt += "<tbody>";
                        outTxt += "<tr>";
                        outTxt += "<td style=\"padding:10px;\">" + formato(dtInfo.Rows[i]["municipio"].ToString().Trim()) + "</td>";
                        outTxt += "<td style=\"padding:10px;\">" + formato_fecha(dtInfo.Rows[i]["fecha"].ToString().Trim()) + "</td>";
                        outTxt += "</tr>";
                        outTxt += "</tbody>";
                        outTxt += "</table>";
                        if (!string.IsNullOrEmpty(url_asistencia))
                        {
                            outTxt += "<div class=\"panel-heading\"><h4 style=\"color:#0091ab;border-bottom: 2px solid #3ab54a;padding-bottom: 15px;\">Fotografía de la Asistencia:</h4></div>";
                            outTxt += "<table>";
                            string ruta_img = "../../" + url_asistencia;
                            outTxt += "<tr>";
                            outTxt += "<td style=\"padding:10px;\">";
                            outTxt += "<img src=\"" + ruta_img + "\">";
                            outTxt += "</td>";
                            outTxt += "</tr>";
                            outTxt += "</table>";
                        }
                    }

                }


                outTxt += "</div>";
            }
            return outTxt;
        }

    }
}

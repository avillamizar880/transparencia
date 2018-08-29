using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;

namespace AuditoriasCiudadanas.Controllers
{
    public class EstadisticasController
    {
        public string formato(string cadena)
        {
            return HttpUtility.HtmlEncode(cadena).Replace("\r", " ").Replace("\n", " ");
        }

        public string formato_anyo(string cadena)
        {
            string cad_aux = cadena;
            if (!string.IsNullOrEmpty(cadena))
            {
                DateTime dt = Convert.ToDateTime(cadena);
                cad_aux = dt.ToString("yyyy",
                        CultureInfo.CreateSpecificCulture("es-co"));
            }

            return cad_aux;

        }

        public string obtEstadisticas(String opcion)
        {
            String outTxt = "";

            List<DataTable> listaInfo = new List<DataTable>();
            listaInfo = Models.clsEstadisticas.obtEstadisticas(opcion);
            DataTable dtGacXLocal = listaInfo[0];
            DataTable dtAudXLocal = listaInfo[1];
            DataTable dtProyectosGac = listaInfo[2];
            DataTable dtGACXTiempo = listaInfo[3];
            DataTable dtProyectosAud = listaInfo[4];
            DataTable dtAsistentes = listaInfo[5];
            DataTable dtHallazgos = listaInfo[6];
            DataTable dtPerCapacitadas = listaInfo[7];
            DataTable dtNivelCap = listaInfo[8];

            String GacXLocal = "";
            if (dtGacXLocal.Rows.Count > 0)
            {

                GacXLocal += "<div class=\"input-group\"> <span class=\"input-group-addon\">Filtro</span>";
                GacXLocal += "<input id =\"filter\" type=\"text\" class=\"form-control\" placeholder=\"Filtre por Departamento o Municipio\">";
                GacXLocal += "</div>";
                GacXLocal += "<div class=\"table-responsive\"><table class=\"table table-hover table-striped\"><thead><tr><th>Departamento</th><th>Municipio</th><th>Cantidad</th></tr></thead><tbody class=\"searchable\">";
                for (int i = 0; i <= dtGacXLocal.Rows.Count - 1; i++)
                {
                    GacXLocal += "<tr>";
                    GacXLocal += "<td>" + formato(dtGacXLocal.Rows[i]["depto"].ToString().Trim()) + "</td>";
                    GacXLocal += "<td>" + formato(dtGacXLocal.Rows[i]["ciudad"].ToString().Trim()) + "</td>";
                    GacXLocal += "<td>" + formato(dtGacXLocal.Rows[i]["numero"].ToString().Trim()) + "</td>";
                    GacXLocal += "</tr>";
                }
                GacXLocal += "</tbody></table></div></div>";
                outTxt += "$(\"#divGacXLocal\").html('" + GacXLocal + "');";
            }
            else
            {
                outTxt += "$(\"#divGacXLocal\").html('" + "No hay información disponible." + "');";
            }

            String AudXLocal = "";
            if (dtAudXLocal.Rows.Count > 0)
            {
                AudXLocal += "<div class=\"input-group\"> <span class=\"input-group-addon\">Filtro</span>";
                AudXLocal += "<input id =\"filter2\" type=\"text\" class=\"form-control\" placeholder=\"Filtre por Departamento o Municipio\">";
                AudXLocal += "</div>";
                AudXLocal += "<div class=\"table-responsive\"><table class=\"table table-hover table-striped\"><thead><tr><th>Departamento</th><th>Municipio</th><th>Cantidad</th></tr></thead><tbody class=\"searchable2\">";
                for (int i = 0; i <= dtAudXLocal.Rows.Count - 1; i++)
                {
                    AudXLocal += "<tr>";
                    AudXLocal += "<td>" + formato(dtAudXLocal.Rows[i]["depto"].ToString().Trim()) + "</td>";
                    AudXLocal += "<td>" + formato(dtAudXLocal.Rows[i]["ciudad"].ToString().Trim()) + "</td>";
                    AudXLocal += "<td>" + formato(dtAudXLocal.Rows[i]["numero"].ToString().Trim()) + "</td>";
                    AudXLocal += "</tr>";
                }
                AudXLocal += "</tbody></table></div></div>";
                outTxt += "$(\"#divAudXLocal\").html('" + AudXLocal + "');";
            }
            else
            {
                outTxt += "$(\"#divAudXLocal\").html('" + "No hay información disponible." + "');";
            }

            //Número de proyectos con GAC conformado
            String ProyectosGac = "";
            if (dtProyectosGac.Rows.Count > 0)
            {
                ProyectosGac += "Total de proyectos con Grupo Auditor Ciudadano: " + dtProyectosGac.Rows.Count;

                ProyectosGac += "<div class=\"input-group\"> <span class=\"input-group-addon\">Filtro</span>";
                ProyectosGac += "<input id =\"filter3\" type=\"text\" class=\"form-control\" placeholder=\"Filtre por Departamento o Municipio\">";
                ProyectosGac += "</div>";
                ProyectosGac += "<div class=\"table-responsive\"><table class=\"table table-hover table-striped\"><thead><tr><th>CodigoBPIN</th><th>Departamento</th><th>Municipio</th><th>Cantidad</th></tr></thead><tbody class=\"searchable3\">";
                for (int i = 0; i <= dtProyectosGac.Rows.Count - 1; i++)
                {
                    ProyectosGac += "<tr>";
                    ProyectosGac += "<td>" + formato(dtProyectosGac.Rows[i]["codigobpin"].ToString().Trim()) + "</td>";
                    ProyectosGac += "<td>" + formato(dtProyectosGac.Rows[i]["depto"].ToString().Trim()) + "</td>";
                    ProyectosGac += "<td>" + formato(dtProyectosGac.Rows[i]["ciudad"].ToString().Trim()) + "</td>";
                    ProyectosGac += "<td>" + formato(dtProyectosGac.Rows[i]["numero"].ToString().Trim()) + "</td>";
                    ProyectosGac += "</tr>";
                }
                ProyectosGac += "</tbody></table></div></div>";
                outTxt += "$(\"#divProyectosGac\").html('" + ProyectosGac + "');";
            }
            else
            {
                outTxt += "$(\"#divProyectosGac\").html('" + "No hay información disponible." + "');";
            }

            //Miembros GAC registrados(en un intervalo de tiempo por ubicación).
            String GACXTiempo = "";
            if (dtGACXTiempo.Rows.Count > 0)
            {
                GACXTiempo += "<div class=\"input-group\"> <span class=\"input-group-addon\">Filtro</span>";
                GACXTiempo += "<input id =\"filter4\" type=\"text\" class=\"form-control\" placeholder=\"Filtre por Departamento o Municipio\">";
                GACXTiempo += "</div>";
                GACXTiempo += "<div class=\"table-responsive\"><table class=\"table table-hover table-striped\"><thead><tr><th>Mes</th><th>Departamento</th><th>Municipio</th><th>Cantidad</th></tr></thead><tbody class=\"searchable4\">";
                for (int i = 0; i <= dtGACXTiempo.Rows.Count - 1; i++)
                {
                    GACXTiempo += "<tr>";
                    GACXTiempo += "<td>" + formato(dtGACXTiempo.Rows[i]["fechaCreacion"].ToString().Trim()) + "</td>";
                    GACXTiempo += "<td>" + formato(dtGACXTiempo.Rows[i]["depto"].ToString().Trim()) + "</td>";
                    GACXTiempo += "<td>" + formato(dtGACXTiempo.Rows[i]["ciudad"].ToString().Trim()) + "</td>";
                    GACXTiempo += "<td>" + formato(dtGACXTiempo.Rows[i]["numero"].ToString().Trim()) + "</td>";
                    GACXTiempo += "</tr>";
                }
                GACXTiempo += "</tbody></table></div></div>";
                outTxt += "$(\"#divGACXTiempo\").html('" + GACXTiempo + "');";
            }
            else
            {
                outTxt += "$(\"#divGACXTiempo\").html('" + "No hay información disponible." + "');";
            }

            //proyectos con audiencias realizadas
            String ProyectosAud = "";
            if (dtProyectosAud.Rows.Count > 0)
            {
                
                ProyectosAud += "<div class=\"table-responsive\"><table class=\"table table-hover table-striped\"><thead><tr><th>Tipo</th><th>Cantidad</th></tr></thead><tbody >";
                for (int i = 0; i <= dtProyectosAud.Rows.Count - 1; i++)
                {
                    ProyectosAud += "<tr>";
                    ProyectosAud += "<td>" + formato(dtProyectosAud.Rows[i]["tipo"].ToString().Trim()) + "</td>";
                    ProyectosAud += "<td>" + formato(dtProyectosAud.Rows[i]["numero"].ToString().Trim()) + "</td>";
                    ProyectosAud += "</tr>";
                }
                ProyectosAud += "</tbody></table></div></div>";
                outTxt += "$(\"#divProyectosAud\").html('" + ProyectosAud + "');";
            }
            else
            {
                outTxt += "$(\"#divProyectosAud\").html('" + "No hay información disponible." + "');";
            }

            //Cantidad asistentes por audiencia
            string infoAsistencia = "";
            if (dtAsistentes.Rows.Count > 0)
            {
                infoAsistencia += "<div class=\"table-responsive\"><table class=\"table table-hover table-striped\"><thead><tr><th>Tipo</th><th>Cantidad</th></tr></thead><tbody >";
                for (int i = 0; i <= dtAsistentes.Rows.Count - 1; i++)
                {
                    infoAsistencia += "<tr>";
                    infoAsistencia += "<td>" + formato(dtAsistentes.Rows[i]["tipo"].ToString().Trim()) + "</td>";
                    infoAsistencia += "<td>" + formato(dtAsistentes.Rows[i]["numero"].ToString().Trim()) + "</td>";
                    infoAsistencia += "</tr>";
                }
                infoAsistencia += "</tbody></table></div></div>";
                outTxt += "$(\"#divAsistentes\").html('" + infoAsistencia + "');";

            }
            else {
                outTxt += "$(\"#divAsistentes\").html('" + "No hay información disponible." + "');";
            }
            

            //Cantidad de hallazgos
            string infoHallazgos = "";
            if (dtHallazgos.Rows.Count > 0)
            {
                infoHallazgos += "<p>Hallazgos registrados hasta el momento: " + dtHallazgos.Rows[0]["numero"].ToString() + "</p>";
            }
            else {
                infoHallazgos += "<p>No hay información disponible</p>";
            }

            outTxt += "$(\"#divHallazgos\").html('" + infoHallazgos + "');";
            outTxt += "$(\"#divSatisfaccion\").html('" + "No hay información disponible." + "');";
            outTxt += "$(\"#divEvaluaciones\").html('" + "No hay información disponible." + "');";


            string PerCapacitadas = "";
            if (dtPerCapacitadas.Rows.Count > 0)
            {
                PerCapacitadas += "<p>Personas que han aprobado evaluaciones de capacitación</p>";
                PerCapacitadas += "<div class=\"table-responsive\"><table class=\"table table-hover table-striped\"><thead><tr><th>Tema Capacitación</th><th>Cantidad</th></tr></thead><tbody >";
                for (int i = 0; i <= dtPerCapacitadas.Rows.Count - 1; i++)
                {
                    PerCapacitadas += "<tr>";
                    PerCapacitadas += "<td>" + formato(dtPerCapacitadas.Rows[i]["Tema"].ToString().Trim()) + "</td>";
                    PerCapacitadas += "<td>" + formato(dtPerCapacitadas.Rows[i]["Cantidad"].ToString().Trim()) + "</td>";
                    PerCapacitadas += "</tr>";
                }
                PerCapacitadas += "</tbody></table></div></div>";
            }
            else
            {
                PerCapacitadas += "<p>No hay información disponible</p>";
            }

            outTxt += "$(\"#divPerCapacitadas\").html('" + PerCapacitadas + "');";

            string NivelCap = "";
            if (dtNivelCap.Rows.Count > 0)
            {
                NivelCap += "<p>Nivel de capacitación</p>";
                NivelCap += "<div class=\"input-group\"> <span class=\"input-group-addon\">Filtro</span>";
                NivelCap += "<input id =\"filter5\" type=\"text\" class=\"form-control\" placeholder=\"Filtre por Departamento o Municipio\">";
                NivelCap += "</div>";
                NivelCap += "<div class=\"table-responsive\"><table class=\"table table-hover table-striped\"><thead><tr><th>Tema Capacitación</th><th>Departamento</th><th>Municipio</th><th>Recursos vistos</th><th>Evaluaciones Aprobadas</th></tr></thead><tbody class=\"searchable5\">";
                for (int i = 0; i <= dtNivelCap.Rows.Count - 1; i++)
                {
                    NivelCap += "<tr>";
                    NivelCap += "<td>" + formato(dtNivelCap.Rows[i]["tema"].ToString().Trim()) + "</td>";
                    NivelCap += "<td>" + formato(dtNivelCap.Rows[i]["Ciudad"].ToString().Trim()) + "</td>";
                    NivelCap += "<td>" + formato(dtNivelCap.Rows[i]["Depto"].ToString().Trim()) + "</td>";
                    NivelCap += "<td>" + formato(dtNivelCap.Rows[i]["Recursos"].ToString().Trim()) + "</td>";
                    NivelCap += "<td>" + formato(dtNivelCap.Rows[i]["Evaluaciones"].ToString().Trim()) + "</td>";
                    NivelCap += "</tr>";
                }
                NivelCap += "</tbody></table></div></div>";
            }
            else
            {
                NivelCap += "<p>No hay información disponible</p>";
            }

            outTxt += "$(\"#divNivelCap\").html('" + NivelCap + "');";



            return outTxt;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace AuditoriasCiudadanas.Controllers
{
    public class ProyectosController
    {
        public string obtInfoProyecto(string id_proyecto){
            String outTxt = "";
            List<DataTable> listaInfo = new List<DataTable>();
            listaInfo = Models.clsProyectos.obtInfoProyecto(id_proyecto);
            DataTable dtGeneral = listaInfo[0];
            DataTable dtProductos = listaInfo[1];
            DataTable dtContratista = listaInfo[2];
            DataTable dtPresupMonto = listaInfo[3];
            DataTable dtPresupModif = listaInfo[4];
            DataTable dtPresupProd = listaInfo[5];
            DataTable dtFormulacion = listaInfo[6];
            DataTable dtPlaneacion = listaInfo[7];
            DataTable dtTecnica = listaInfo[8];
            DataTable dtGrupos = listaInfo[9];

            //Tab General
            if (dtGeneral.Rows.Count > 0)
            {
                outTxt += "$(\"#divObjetivoDet\").html(" + dtGeneral.Rows[0]["Objetivo"].ToString() + ");";
                outTxt += "$(\"#divSectorDet\").html(" + dtGeneral.Rows[0]["Sector"].ToString() + ");";
                outTxt += "$(\"#divLocalizacionDet\").html(" + dtGeneral.Rows[0][""].ToString() + ");";
                outTxt += "$(\"#divEntidadEjecDet\").html(" + dtGeneral.Rows[0][""].ToString() + ");";
                outTxt += "$(\"#divProductosDet\").html(" + dtGeneral.Rows[0][""].ToString() + ");";
                outTxt += "$(\"#divCronogramaDet\").html(" + dtGeneral.Rows[0][""].ToString() + ");";
            }
            //Tab contratista
            outTxt += "$(\"#divContratistaDet\").html(" + dtContratista.Rows[0][""].ToString() + ");";
            outTxt += "$(\"#divInterventorDet\").html(" + dtContratista.Rows[0][""].ToString() + ");";
            outTxt += "$(\"#divSupervisorDet\").html(" + dtContratista.Rows[0][""].ToString() + ");";
            outTxt += "$(\"#divPolizasDet\").html(" + dtContratista.Rows[0][""].ToString() + ");";

            //Tab Presupuesto (Tablas:montos, modificaciones, costos por producto)
            //--------------------------------------------------------------------
            string tablaMonto = "<div class=\"table-responsive\"><table class=\"table\"><thead><tr><th>Entidad</th><th>Valor</th></tr></thead>";
            for (int i = 0; i < dtPresupMonto.Rows.Count - 1; i++) {
                tablaMonto += "<tr>";
                tablaMonto += "<td>" + dtPresupMonto.Rows[i]["entidad"].ToString() + "</td>";
                tablaMonto += "<td>" + dtPresupMonto.Rows[i]["valor"].ToString() + "</td>";
                tablaMonto += "</tr>";
            }
            tablaMonto += "</tbody></table></div></div>";
            outTxt += "$(\"#divPresupuestoDet\").html(" + tablaMonto + ")";
            //--------------------------------------------------------------------
            if (dtPresupModif.Rows.Count > 0)
            {
                string tablaModif = "<div class=\"table-responsive\"><table class=\"table\"><thead><tr><th>Concepto</th><th>Valor</th></tr></thead>";
                for (int i = 0; i < dtPresupModif.Rows.Count - 1; i++)
                {
                    tablaModif += "<tr>";
                    tablaModif += "<td>" + dtPresupModif.Rows[i]["entidad"].ToString() + "</td>";
                    tablaModif += "<td>" + dtPresupModif.Rows[i]["valor"].ToString() + "</td>";
                    tablaModif += "</tr>";
                }
                tablaModif += "</tbody></table></div></div>";

                outTxt += "$(\"#divModifPresupDet\").html(" + tablaModif + ");";
            }
            else {
                outTxt += "$(\"#divModifPresupDet\").html(" + "No hay modificaciones al presupuesto en el OCAD donde fue aprobado el proyecto." + ");";
            }

            //-----------------------------------------------------------------------
            string tablaCosto = "<div class=\"table-responsive\"><table class=\"table\"><thead><tr><th>Actividad</th><th>Valor</th></tr></thead>";
            for (int i = 0; i < dtPresupProd.Rows.Count - 1; i++)
            {
                tablaCosto += "<tr>";
                tablaCosto += "<td>" + dtPresupProd.Rows[i]["actividad"].ToString() + "</td>";
                tablaCosto += "<td>" + dtPresupProd.Rows[i]["valor"].ToString() + "</td>";
                tablaCosto += "</tr>";
            }
            tablaCosto += "</tbody></table></div></div>";
            outTxt += "$(\"#divCostoActividadDet\").html(" + tablaCosto + ");";
            //------------------------------------------------------------------------
            //Tab formulacion
            outTxt += "$(\"#divFechaOcadDet\").html(" + dtGeneral.Rows[0][""].ToString();
            outTxt += "$(\"#divActaOcadDet\").html(" + dtGeneral.Rows[0][""].ToString();
            outTxt += "$(\"#divCriteriosDet\").html(" + dtGeneral.Rows[0][""].ToString();
            outTxt += "$(\"#divPresOcadDet\").html(" + dtGeneral.Rows[0][""].ToString();
            outTxt += "$(\"#divPersonaDet\").html(" + dtGeneral.Rows[0][""].ToString();

            //Tab planeacion
            outTxt += "$(\"#divDescripDet\").html(" + dtGeneral.Rows[0][""].ToString();
            outTxt += "$(\"#divDocPlaDet\").html(" + dtGeneral.Rows[0][""].ToString();
            outTxt += "$(\"#divEspecifDet\").html(" + dtGeneral.Rows[0][""].ToString();

            //Información Calidad y técnica (Pendiente armar tabs)
            //outTxt += "$(\"#\").html(" + dtGeneral.Rows[0][""].ToString();
            //outTxt += "$(\"#\").html(" + dtGeneral.Rows[0][""].ToString();

            //Grupos Auditores (agrupar por id_grupo)
            if (dtGrupos.Rows.Count > 0)
            {
                string tablaGrupos = "<div class=\"table-responsive\"><table class=\"table\"><thead><tr><th>Nombre</th><th>Teléfono</th><th>Email</th></tr></thead>";
                for (int i = 0; i < dtGrupos.Rows.Count - 1; i++)
                {
                    tablaGrupos += "<tr>";
                    tablaGrupos += "<td>" + dtGrupos.Rows[i]["nombre"].ToString() + "</td>";
                    tablaGrupos += "<td>" + dtGrupos.Rows[i]["telefono"].ToString() + "</td>";
                    tablaGrupos += "<td>" + dtGrupos.Rows[i]["email"].ToString() + "</td>";
                    tablaGrupos += "</tr>";
                }
                tablaGrupos += "</tbody></table></div></div>";

                outTxt += "$(\"#divGruposAud\").html(" + tablaGrupos + ");";
            }
            else
            {
                outTxt += "$(\"#divGruposAud\").html(" + "Aún no hay grupos ciudadanos auditando el proyecto." + ");";
            }

            return outTxt;
        }
    }
}
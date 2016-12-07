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
            String outTxt="";
            List<DataTable> listaInfo = new List<DataTable>();
            listaInfo = Models.clsProyectos.obtInfoProyecto(id_proyecto);
            DataTable dtGeneral = listaInfo[0];
            DataTable dtProductos = listaInfo[1];
            DataTable dtCronograma = listaInfo[2];
            DataTable dtContratista = listaInfo[3];
            DataTable dtPoliza = listaInfo[4];
            DataTable dtPresupMonto = listaInfo[5];
            DataTable dtPresupModif = listaInfo[6];
            DataTable dtPresupProd = listaInfo[7];
            DataTable dtPagosContrato = listaInfo[8];
            DataTable dtFormulacion = listaInfo[9];
            DataTable dtProyectosOcad = listaInfo[10];
            DataTable dtPlaneacion = listaInfo[11];
            DataTable dtTecnica = listaInfo[12];
            DataTable dtGrupos = listaInfo[13];

            //Tab General
            if (dtGeneral.Rows.Count > 0)
            {
                outTxt += "$(\"#divObjetivoDet\").html(" + dtGeneral.Rows[0]["Objetivo"].ToString() + ");";
                outTxt += "$(\"#divSectorDet\").html(" + dtGeneral.Rows[0]["Sector"].ToString() + ");";
                outTxt += "$(\"#divLocalizacionDet\").html(" + dtGeneral.Rows[0]["Localizacion"].ToString() + ");";
                outTxt += "$(\"#divEntidadEjecDet\").html(" + dtGeneral.Rows[0]["EntidadEjecutora"].ToString() + ");";
                outTxt += "$(\"#divPresupuestoTotal\").html(" + dtGeneral.Rows[0]["Presupuesto"].ToString() + ");";
                // outTxt += "$(\"#divBeneficiarios\").html(" + dtGeneral.Rows[0]["Beneficiarios"].ToString() + ");";
            }
            if (dtProductos.Rows.Count > 0)
            {
                string Productos = "<ul>";
                for (int i = 0; i < dtProductos.Rows.Count - 1; i++)
                {
                    Productos += "<li>" + dtProductos.Rows[i]["NombreProducto"].ToString() + "</li>";
                }
                Productos += "</ul>";
                outTxt += "$(\"#divProductosDet\").html(" + Productos + ");";
            }
            if (dtCronograma.Rows.Count > 0)
            {
                string Planeado = "";
                string Ejecutado = "";
                for (int i = 0; i < dtCronograma.Rows.Count - 1; i++)
                {
                    Planeado += "<div class=\"cronoItem\">";
                    Planeado += "<span class=\"glyphicon glyphicon-flag\"></span>";
                    Planeado += "<span class=\"dataHito\">" + dtCronograma.Rows[i]["FechaInicial"].ToString() + "</span>";
                    Planeado += "<p>" + dtCronograma.Rows[i]["Actividad"].ToString() + "</p>";
                    Planeado += "</div>";
                    if (dtCronograma.Rows[i]["FechaEje"].ToString() != "")
                    {
                        Ejecutado += "<div class=\"cronoItem\">";
                        Ejecutado += "<span class=\"glyphicon glyphicon-flag\"></span>";
                        Ejecutado += "<span class=\"dataHito\">" + dtCronograma.Rows[i]["FechaEje"].ToString() + "</span>";
                        Ejecutado += "<p>" + dtCronograma.Rows[i]["Actividad"].ToString() + "</p>";
                        Ejecutado += "</div>";
                    }
                }
                outTxt += "$(\"#divCronogramaDet\").html(" + Planeado + ");";
                outTxt += "$(\"#divCronoEjecDet\").html(" + Ejecutado + ");";
            }

            //Tab contratista
            if (dtContratista.Rows.Count > 0)
            {
                outTxt += "$(\"#divContratistaDet\").html(" + dtContratista.Rows[0]["NombresCttista"].ToString() + ");";
                outTxt += "$(\"#divInterventorDet\").html(" + dtContratista.Rows[0]["NomInterventor"].ToString() + ");";
                outTxt += "$(\"#divSupervisorDet\").html(" + dtContratista.Rows[0]["NomSupervisor"].ToString() + ");";
            }
            if (dtPoliza.Rows.Count > 0)
            {
                string Poliza = "<p>";
                for (int i = 0; i < dtProductos.Rows.Count - 1; i++)
                {
                    Poliza += "<b>" + dtPoliza.Rows[i]["nomTipoAmparo"].ToString() + "</b>. Aseguradora: " + dtPoliza.Rows[i]["nombreAseguradora"].ToString() + ". Número de Amparo: " + dtPoliza.Rows[i]["numeroAmparo"].ToString() + ". Beneficiario: " + dtPoliza.Rows[i]["beneficiario"].ToString() + ". Tomador: " + dtPoliza.Rows[i]["tomador"].ToString() + ". Número de cubrimientos: " + dtPoliza.Rows[i]["numeroCubrimientos"].ToString() + ". Fecha Expedición: " + dtPoliza.Rows[i]["fechaExpedicion"].ToString() + ". Número de Aprobación: " + dtPoliza.Rows[i]["NumAprobacion"].ToString() + ". Fecha Documento de Aprobación: " + dtPoliza.Rows[i]["FechaDocAprobacion"].ToString() + ". - ";
                }
                Poliza += "</p>";
                outTxt += "$(\"#divPolizasDet\").html(" + Poliza + ");";
            }
            //Tab Presupuesto (Tablas:montos, modificaciones, costos por producto)
            //--------------------------------------------------------------------
            if (dtPresupMonto.Rows.Count > 0)
            {
                string tablaMonto = "<div class=\"table-responsive\"><table class=\"table\"><thead><tr><th>Entidad</th><th>Valor</th></tr></thead>";
                for (int i = 0; i < dtPresupMonto.Rows.Count - 1; i++)
                {
                    tablaMonto += "<tr>";
                    tablaMonto += "<td>" + dtPresupMonto.Rows[i]["Entidad"].ToString() + "</td>";
                    tablaMonto += "<td>" + dtPresupMonto.Rows[i]["Valor"].ToString() + "</td>";
                    tablaMonto += "</tr>";
                }
                tablaMonto += "</tbody></table></div></div>";
                outTxt += "$(\"#divPresupuestoDet\").html(" + tablaMonto + ");";
            }
            //--------------------------------------------------------------------
            if (dtPresupModif.Rows.Count > 0)
            {
                string tablaModif = "<div class=\"table-responsive\"><table class=\"table\"><thead><tr><th>Concepto</th><th>Descripcion</th><th>Fecha</th></tr></thead>";
                for (int i = 0; i < dtPresupModif.Rows.Count - 1; i++)
                {
                    tablaModif += "<tr>";
                    tablaModif += "<td>" + dtPresupModif.Rows[i]["Tipo"].ToString() + "</td>";
                    tablaModif += "<td>" + dtPresupModif.Rows[i]["Descripcion"].ToString() + "</td>";
                    tablaModif += "<td>" + dtPresupModif.Rows[i]["Fecha"].ToString() + "</td>";
                    tablaModif += "</tr>";
                }
                tablaModif += "</tbody></table></div></div>";

                outTxt += "$(\"#divModifPresupDet\").html(" + tablaModif + ");";
            }
            else
            {
                outTxt += "$(\"#divModifPresupDet\").html('" + "No hay modificaciones al presupuesto en el OCAD donde fue aprobado el proyecto." + "');";
                
            }
            // OJO, NO ESTAN LOS DATOS
            //-----------------------------------------------------------------------
            if (dtPresupProd.Rows.Count > 0)
            {
                string tablaCosto = "<div class=\"table-responsive\"><table class=\"table\"><thead><tr><th>Actividad</th><th>Valor</th></tr></thead>";
                for (int i = 0; i < dtPresupProd.Rows.Count - 1; i++)
                {
                    tablaCosto += "<tr>";
                    tablaCosto += "<td>" + dtPresupProd.Rows[i]["actividad"].ToString() + "</td>";
                    tablaCosto += "<td>" + dtPresupProd.Rows[i]["valor"].ToString() + "</td>";
                    tablaCosto += "</tr>";
                }
                tablaCosto += "</tbody></table></div></div>";
                outTxt += "$(\"#divCostoActividadDet\").html('" + tablaCosto + "');";
            }
            //------------------------------------------------------------------------
            if (dtPagosContrato.Rows.Count > 0)
            {
                string tablaPagos = "<div class=\"table-responsive\"><table class=\"table\"><thead><tr><th>Concepto</th><th>Fuente Financiación</th><th>Fecha</th><th>Valor</th></tr></thead>";
                for (int i = 0; i < dtPagosContrato.Rows.Count - 1; i++)
                {
                    tablaPagos += "<tr>";
                    tablaPagos += "<td>" + dtPagosContrato.Rows[i]["Concepto"].ToString() + "</td>";
                    tablaPagos += "<td>" + dtPagosContrato.Rows[i]["Fuente"].ToString() + "</td>";
                    tablaPagos += "<td>" + dtPagosContrato.Rows[i]["Fecha"].ToString() + "</td>";
                    tablaPagos += "<td>" + dtPagosContrato.Rows[i]["Valor"].ToString() + "</td>";
                    tablaPagos += "</tr>";
                }
                tablaPagos += "</tbody></table></div></div>";
                outTxt += "$(\"#divPagosContrato\").html(" + tablaPagos + ");";
            }
            //------------------------------------------------------------------------
            //Tab formulacion
            if (dtFormulacion.Rows.Count > 0)
            {
                outTxt += "$(\"#divFechaOcadDet\").html(" + dtFormulacion.Rows[0]["Fecha"].ToString() + " - " + dtFormulacion.Rows[0]["NomOcad"].ToString() + "." + ");";
                //-- No esta el acta sino el número
                outTxt += "$(\"#divActaOcadDet\").html(" + dtFormulacion.Rows[0]["Doc"].ToString() + ");";
                //-- No se tiene el dato
                outTxt += "$(\"#divCriteriosDet\").html(" + dtFormulacion.Rows[0]["priorizacion"].ToString() + ");";
            }

            if (dtProyectosOcad.Rows.Count > 0)
            {
                string Proyectos = "<ul>";
                for (int i = 0; i < dtProyectosOcad.Rows.Count - 1; i++)
                {
                    Proyectos += "<li>" + dtProyectosOcad.Rows[i]["Proyecto"].ToString() + ". - " + dtProyectosOcad.Rows[i]["Localizacion"].ToString() + "</li>";
                }
                Proyectos += "</ul>";
                outTxt += "$(\"#divPresOcadDet\").html(" + Proyectos + ");";
            }

            // OJO, NO ESTAN LOS DATOS
            //-----------------------------------------------------------------------
            //outTxt += "$(\"#divPersonaDet\").html(" + dtGeneral.Rows[0][""].ToString();

            //Tab planeacion
            // OJO, NO ESTAN LOS DATOS
            //-----------------------------------------------------------------------
            //outTxt += "$(\"#divDescripDet\").html(" + dtPlaneacion.Rows[0][""].ToString();
            //outTxt += "$(\"#divDocPlaDet\").html(" + dtPlaneacion.Rows[0][""].ToString();
            //outTxt += "$(\"#divEspecifDet\").html(" + dtPlaneacion.Rows[0][""].ToString();

            //Información Calidad y técnica (Pendiente armar tabs)
            //outTxt += "$(\"#\").html(" + dtTecnica.Rows[0]["Titulo"].ToString();
            //outTxt += "$(\"#\").html(" + dtTecnica.Rows[0]["Descripcion"].ToString();
            //outTxt += "$(\"#\").html(" + dtTecnica.Rows[0]["Fecha"].ToString();
            //outTxt += "$(\"#\").html(" + dtTecnica.Rows[0]["Adjunto"].ToString();
            //outTxt += "$(\"#\").html(" + dtTecnica.Rows[0]["UrlFoto"].ToString();
            //outTxt += "$(\"#\").html(" + dtTecnica.Rows[0]["NomUsuario"].ToString();

            //Grupos Auditores (agrupar por idgrupo)
            if (dtGrupos.Rows.Count > 0)
            {
                string idGrupo = dtGrupos.Rows[0]["idgrupo"].ToString();
                string tablaGrupos = "Grupo: " + idGrupo;
                tablaGrupos += "<div class=\"table-responsive\"><table class=\"table\"><thead><tr><th>Nombre</th><th>Teléfono</th><th>Email</th></tr></thead>";
                for (int i = 0; i < dtGrupos.Rows.Count - 1; i++)
                {
                    if (idGrupo != dtGrupos.Rows[i]["idgrupo"].ToString())
                    {
                        tablaGrupos += "</tbody></table></div></div>";
                        tablaGrupos += "Grupo: " + idGrupo;
                        tablaGrupos += "<div class=\"table-responsive\"><table class=\"table\"><thead><tr><th>Nombre</th><th>Teléfono</th><th>Email</th></tr></thead>";
                    }
                    tablaGrupos += "<tr>";
                    tablaGrupos += "<td>" + dtGrupos.Rows[i]["nombre"].ToString() + "</td>";
                    tablaGrupos += "<td>" + dtGrupos.Rows[i]["telefono"].ToString() + "</td>";
                    tablaGrupos += "<td>" + dtGrupos.Rows[i]["email"].ToString() + "</td>";
                    tablaGrupos += "</tr>";

                    idGrupo = dtGrupos.Rows[i]["idgrupo"].ToString();
                }
                tablaGrupos += "</tbody></table></div></div>";

                outTxt += "$(\"#divGruposAud\").html(" + tablaGrupos + ");";
            }
            else
            {
                outTxt += "$(\"#divGruposAud\").html('" + "Aún no hay grupos ciudadanos auditando el proyecto." + "');";
            }

            return outTxt;
        }
    }
}
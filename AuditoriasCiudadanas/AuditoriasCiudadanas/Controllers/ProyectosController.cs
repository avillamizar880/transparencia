using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace AuditoriasCiudadanas.Controllers
{
    public class ProyectosController
    {

        public string obtInfoProyecto(string id_proyecto,int id_usuario) {
            String outTxt = "";
            String bpinProyecto = "";  //CAMBIAR POR VALOR DE DT CORRESPONDIENTE
   
            List<DataTable> listaInfo = new List<DataTable>();
            listaInfo = Models.clsProyectos.obtInfoProyecto(id_proyecto,id_usuario);
            DataTable dtGeneral = listaInfo[0];
            DataTable dtProductos = listaInfo[1];
            DataTable dtCronograma = listaInfo[2];
            DataTable dtIndicadores = listaInfo[3];
            DataTable dtContratista = listaInfo[4];
            DataTable dtPoliza = listaInfo[5];
            DataTable dtPresupMonto = listaInfo[6];
            DataTable dtPresupModif = listaInfo[7];
            //DataTable dtPresupProd = listaInfo[8];  --TRAEN UNA FILA VACIA Y GENERA ERROR
            DataTable dtPresupProd = new DataTable("dtPresupProd");
            DataTable dtPagosContrato = listaInfo[9];
            DataTable dtFormulacion = listaInfo[10];
            DataTable dtProyectosOcad = listaInfo[11];
            DataTable dtAjustes = listaInfo[12];
            DataTable dtRequisitos = listaInfo[13];
            //DataTable dtPlaneacion = listaInfo[14];  --TRAEN UNA FILA VACIA Y GENERA ERROR
            DataTable dtPlaneacion = new DataTable("dtPlaneacion");
            DataTable dtTecnica = listaInfo[15];
            DataTable dtGrupos = listaInfo[16];
            //DataTable dtUsuarios = listaInfo[17];   //AGREGAR SELECT DE USUARIO
            DataTable dtAuditor = listaInfo[17];   
            DataTable dtRol = listaInfo[18];
            DataTable dtDescInfoTecnica = listaInfo[19];
            string auditor = "";  //VARIABLE PARA REVISAR SI ES AUDITOR EN EL PROYECTO
            if (dtAuditor.Rows.Count >= 1)
            {
                auditor = dtAuditor.Rows[0]["auditor"].ToString();
            }
            string tipo_rol = "";  //VARIABLE PARA REVISAR ROL DEL USUARIO EN EL PROYECTO
            if(dtRol.Rows.Count>=1){
                tipo_rol=dtRol.Rows[0]["idrol"].ToString();
            }

            //Tab General
            if (dtGeneral.Rows.Count > 0)
            {
                String ejecutor = "";
                outTxt += "$(\"#txtNombreProyecto\").html('" + "<h3>" + dtGeneral.Rows[0]["Objetivo"].ToString() + "</h3>" + "');";
                outTxt += "$(\"#divSectorDet\").html('" + dtGeneral.Rows[0]["Sector"].ToString() + "');";
                outTxt += "$(\"#divLocalizacionDet\").html('" + dtGeneral.Rows[0]["Localizacion"].ToString() + "');";
                outTxt += "$(\"#txtUbicaProyecto\").html(\"" + dtGeneral.Rows[0]["Localizacion"].ToString() + "\");";
                outTxt += "$(\"#txtNomContratista\").html(\"" + dtGeneral.Rows[0]["NomEntidadEjecutora"].ToString() + "\");";
                ejecutor += "Nombre: " + dtGeneral.Rows[0]["NomEntidadEjecutora"].ToString();
                ejecutor += "<br>Nit: " + dtGeneral.Rows[0]["NitEntidad"].ToString();
                ejecutor += "<br>Contacto: " + dtGeneral.Rows[0]["Contacto"].ToString();
                ejecutor += "<br>Email: " + dtGeneral.Rows[0]["email"].ToString();
                outTxt += "$(\"#divEntidadEjecDet\").html('" + ejecutor + "');";

                outTxt += "$(\"#divPresupuestoTotal\").html('" + dtGeneral.Rows[0]["Presupuesto"].ToString() + "');";
                outTxt += "$(\"#divBeneficiarios\").html('" + dtGeneral.Rows[0]["Beneficiarios"].ToString() + "');";
                bpinProyecto = dtGeneral.Rows[0]["bpin"].ToString();
                outTxt += "$(\"#spnPinProyecto\").html(\"" + "BPIN: " + bpinProyecto + "\");";
            }
            if (dtProductos.Rows.Count > 0)
            {
                string Productos = "<ul>";
                for (int i = 0; i <= dtProductos.Rows.Count - 1; i++)
                {
                    Productos += "<li>" + dtProductos.Rows[i]["NombreProducto"].ToString() + "</li>";
                }
                Productos += "</ul>";
                outTxt += "$(\"#divProductosDet\").html('" + Productos + "');";
            }
            if (dtCronograma.Rows.Count > 0)
            {
                string Planeado = "";
                string Ejecutado = "";
                for (int i = 0; i <= dtCronograma.Rows.Count - 1; i++)
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
                outTxt += "$(\"#divCronogramaDet\").html('" + Planeado + "');";
                outTxt += "$(\"#divCronoEjecDet\").html('" + Ejecutado + "');";
            }
            // Indicadores
            if (dtIndicadores.Rows.Count > 0)
            {
                string tablaIndi = "<div class=\"table-responsive\"><table class=\"table table-hover table-striped\"><thead><tr><th>Indicador</th><th>Producto</th><th>Cantidad</th><th>Valor Meta</th><th>Fecha Inicial</th><th>Fecha Final</th><th>Ejecutado</th><th>%</th></tr></thead><tbody>";
                for (int i = 0; i <= dtIndicadores.Rows.Count - 1; i++)
                {
                    tablaIndi += "<tr>";
                    tablaIndi += "<td>" + dtIndicadores.Rows[i]["NomIndicador"].ToString() + "</td>";
                    tablaIndi += "<td>" + dtIndicadores.Rows[i]["NombreProducto"].ToString() + "</td>";
                    tablaIndi += "<td>" + dtIndicadores.Rows[i]["CantidadProducto"].ToString() + " " + dtIndicadores.Rows[i]["NomUnidadProducto"].ToString() + "</td>";
                    tablaIndi += "<td>" + dtIndicadores.Rows[i]["ValorMeta"].ToString() + "</td>";
                    tablaIndi += "<td>" + dtIndicadores.Rows[i]["FechaInicio"].ToString() + "</td>";
                    tablaIndi += "<td>" + dtIndicadores.Rows[i]["FechaFinal"].ToString() + "</td>";
                    tablaIndi += "<td>" + dtIndicadores.Rows[i]["ValorEjecutado"].ToString() + "</td>";
                    tablaIndi += "<td>" + dtIndicadores.Rows[i]["PorEjecutado"].ToString() + "</td>";
                    tablaIndi += "</tr>";
                }
                tablaIndi += "</tbody></table></div></div>";
                outTxt += "$(\"#divIndicadores\").html('" + tablaIndi + "');";
            }
            //Tab contratista
            if (dtContratista.Rows.Count > 0)
            {
                string contratos = "";
                contratos += "<h2>Contratista y Vigilancia</h2>";
                for (int i = 0; i <= dtContratista.Rows.Count - 1; i++)
                {
                    contratos += "<button class=\"btn btn-info\" type=\"button\" onclick=\"javascript:verDetalleContrato(" + "\\'" + dtContratista.Rows[i]["NumCtto"].ToString() + "\\'" + ");\"><span class=\"glyphicon glyphicon-plus\"></span>VER DETALLE</button>";
                    contratos += "<div class=\"list-group-item\">";
                    contratos += "<div class=\"col-sm-12\"><h4>Contrato: ";
                    contratos += dtContratista.Rows[i]["NumCtto"].ToString();
                    contratos += "</h4>";
                    contratos += dtContratista.Rows[i]["Objeto"].ToString();
                    contratos += "</div>";
                    contratos += "<div class=\"col-sm-12\"><h4>Contratista Seleccionado</h4><div>";
                    contratos += dtContratista.Rows[i]["NombresCttista"].ToString();
                    contratos += "</div></div>";
                    contratos += "<div class=\"col-sm-6\"><h4>Interventor Designado</h4><div>";
                    contratos += dtContratista.Rows[i]["NomInterventor"].ToString();
                    contratos += "</div></div>";
                    contratos += "<div class=\"col-sm-6\"><h4>Supervisor</h4><div>";
                    contratos += dtContratista.Rows[i]["NomSupervisor"].ToString();
                    contratos += "</div></div></div>";
                }
                outTxt += "$(\"#divContrato\").html('" + contratos + "');";
            }
            

            //Tab Presupuesto (Tablas:montos, modificaciones, costos por producto)
            //--------------------------------------------------------------------
            if (dtPresupMonto.Rows.Count > 0)
            {
                string tablaMonto = "<div class=\"table-responsive\"><table class=\"table table-hover table-striped\"><thead><tr><th>Entidad</th><th>Valor</th></tr></thead><tbody>";
                for (int i = 0; i <= dtPresupMonto.Rows.Count - 1; i++)
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
                string tablaModif = "<div class=\"table-responsive\"><table class=\"table table-hover table-striped\"><thead><tr><th>Concepto</th><th>Descripcion</th><th>Fecha</th></tr></thead>";
                for (int i = 0; i <= dtPresupModif.Rows.Count - 1; i++)
                {
                    tablaModif += "<tr>";
                    tablaModif += "<td>" + dtPresupModif.Rows[i]["Tipo"].ToString() + "</td>";
                    tablaModif += "<td>" + dtPresupModif.Rows[i]["Descripcion"].ToString() + "</td>";
                    tablaModif += "<td>" + dtPresupModif.Rows[i]["Fecha"].ToString() + "</td>";
                    tablaModif += "</tr>";
                }
                tablaModif += "</tbody></table></div></div>";

                outTxt += "$(\"#divModifPresupDet\").html('" + tablaModif + "');";
            }
            else
            {
                outTxt += "$(\"#divModifPresupDet\").html('" + "No hay modificaciones al presupuesto en el OCAD donde fue aprobado el proyecto." + "');";

            }
            // OJO, NO ESTAN LOS DATOS
            ////-----------------------------------------------------------------------
            if (dtPresupProd.Rows.Count > 0)
            {
                string tablaCosto = "<div class=\"table-responsive\"><table class=\"table table-hover table-striped\"><thead><tr><th>Actividad</th><th>Valor</th></tr></thead><tbody>";
                for (int i = 0; i <= dtPresupProd.Rows.Count - 1; i++)
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
                for (int i = 0; i <= dtPagosContrato.Rows.Count - 1; i++)
                {
                    tablaPagos += "<tr>";
                    tablaPagos += "<td>" + dtPagosContrato.Rows[i]["Concepto"].ToString() + "</td>";
                    tablaPagos += "<td>" + dtPagosContrato.Rows[i]["Fuente"].ToString() + "</td>";
                    tablaPagos += "<td>" + dtPagosContrato.Rows[i]["Fecha"].ToString() + "</td>";
                    tablaPagos += "<td>" + dtPagosContrato.Rows[i]["Valor"].ToString() + "</td>";
                    tablaPagos += "</tr>";
                }
                tablaPagos += "</tbody></table></div></div>";
                outTxt += "$(\"#divPagosContrato\").html('" + tablaPagos + "');";
            }
            //------------------------------------------------------------------------
            //Tab formulacion
            if (dtFormulacion.Rows.Count > 0)
            {
                outTxt += "$(\"#divFechaOcadDet\").html('" + dtFormulacion.Rows[0]["Fecha"].ToString() + " - " + dtFormulacion.Rows[0]["NomOcad"].ToString() + "." + "');";
                //-- No esta el acta sino el número 
                outTxt += "$(\"#divNumActaOcad\").html('" + dtFormulacion.Rows[0]["Doc"].ToString() + "');";
                //-------si se tuviera documento Acta OCAD---------------------------------------------------------------------:
                //outTxt += "$(\"#divActaOcadDet\").atrr(\"onclick\",verDocumento('acta_ocad','" + bpinProyecto + "'))";
                //outTxt += "$(\"#divActaOcadDocumento\").attr(\"class\")=\"showObj\"";
                //---------------------------------------------------------------------------------------------------

                //-- No se tiene el dato
                outTxt += "$(\"#divCriteriosDetTexto\").html('" + dtFormulacion.Rows[0]["priorizacion"].ToString() + "');";
                //-------si se tuviera documento priorizacion---------------------------------------------------------------------:
                //outTxt += "$(\"#divCriteriosDet\").atrr(\"onclick\",verDocumento('criterios_priori','" + bpinProyecto + "'))";
                //outTxt += "$(\"#divCriteriosDocumento\").attr(\"class\")=\"showObj\"";
                //---------------------------------------------------------------------------------------------------
            }

            if (dtProyectosOcad.Rows.Count > 0)
            {
                string Proyectos = "<ul>";
                for (int i = 0; i <= dtProyectosOcad.Rows.Count - 1; i++)
                {
                    Proyectos += "<li>" + dtProyectosOcad.Rows[i]["Proyecto"].ToString() + ". - " + dtProyectosOcad.Rows[i]["Localizacion"].ToString() + "</li>";
                }
                Proyectos += "</ul>";
                outTxt += "$(\"#divPresOcadDet\").html(" + Proyectos + ");";
            }
            //Ajustes
            if (dtAjustes.Rows.Count > 0)
            {
                string tablaAjustes = "<div class=\"table-responsive\"><table class=\"table\"><thead><tr><th>Documento</th><th>Fecha</th><th>Cambio Alcance</th><th>Disminución Beneficio</th><th>Reducción Meta</th><th>Fuentes Financiación</th><th>Incremento Valor</th><th>Disminución Valor</th></tr></thead>";
                for (int i = 0; i <= dtPagosContrato.Rows.Count - 1; i++)
                {
                    tablaAjustes += "<tr>";
                    tablaAjustes += "<td>" + dtAjustes.Rows[i]["NumDoc"].ToString() + "</td>";
                    tablaAjustes += "<td>" + dtAjustes.Rows[i]["FechaDoc"].ToString() + "</td>";
                    tablaAjustes += "<td>" + dtAjustes.Rows[i]["CambioAlcance"].ToString() + "</td>";
                    tablaAjustes += "<td>" + dtAjustes.Rows[i]["DisminucionBenef"].ToString() + "</td>";
                    tablaAjustes += "<td>" + dtAjustes.Rows[i]["ReduccionMeta"].ToString() + "</td>";
                    tablaAjustes += "<td>" + dtAjustes.Rows[i]["ModificacionFuentesFin"].ToString() + "</td>";
                    tablaAjustes += "<td>" + dtAjustes.Rows[i]["IncrementosValor"].ToString() + "</td>";
                    tablaAjustes += "<td>" + dtAjustes.Rows[i]["DisminucionValor"].ToString() + "</td>";
                    tablaAjustes += "</tr>";
                }
                tablaAjustes += "</tbody></table></div></div>";
                outTxt += "$(\"#divPagosContrato\").html('" + tablaAjustes + "');";
            }
            if (dtRequisitos.Rows.Count > 0)
            {
                string tablaRequisitos = "<div class=\"table-responsive\"><table class=\"table\"><thead><tr><th>Código</th><th>Requisito</th><th>Fecha</th></tr></thead>";
                for (int i = 0; i <= dtPagosContrato.Rows.Count - 1; i++)
                {
                    tablaRequisitos += "<tr>";
                    tablaRequisitos += "<td>" + dtRequisitos.Rows[i]["CodRequisito"].ToString() + "</td>";
                    tablaRequisitos += "<td>" + dtRequisitos.Rows[i]["NomRequisito"].ToString() + "</td>";
                    tablaRequisitos += "<td>" + dtRequisitos.Rows[i]["Fecha"].ToString() + "</td>";
                    tablaRequisitos += "</tr>";
                }
                tablaRequisitos += "</tbody></table></div></div>";
                outTxt += "$(\"#divRequisitos\").html('" + tablaRequisitos + "');";
            }
            // OJO, NO ESTAN LOS DATOS
            //-----------------------------------------------------------------------
            //outTxt += "$(\"#divPersonaDet\").html(" + dtGeneral.Rows[0][""].ToString();

            //TAB PLANEACION
            // OJO, NO ESTAN LOS DATOS
            //-----------------------------------------------------------------------
            //outTxt += "$(\"#divDescripDet\").html(" + dtPlaneacion.Rows[0][""].ToString();
            //outTxt += "$(\"#divEspecifDet\").html(" + dtPlaneacion.Rows[0][""].ToString();
            //-------si se tuviera documento planeacion---------------------------------------------------------------------:
            //outTxt += "$(\"#divDocPlaDet\").atrr(\"onclick\",verDocumento('planeacion','" + bpinProyecto + "'))";
            //outTxt += "$(\"#divDocPlaneacion\").attr(\"class\")=\"showObj\"";
            //---------------------------------------------------------------------------------------------------

            //----VALIDA SI EXISTE DESC DE INF TECNICA AGREGADA-----
            string textoInfoTecnica = "";
            string textoInfoTecnica_aux = "";
            if (dtDescInfoTecnica.Rows.Count > 0)
            {
                textoInfoTecnica += "$(\"#divInformacionCalidad\").hide();";
                textoInfoTecnica += "$(\"#divItemsCalidad\").show();";
                for (int i = 0; i <= dtDescInfoTecnica.Rows.Count - 1; i++)
                {
                    textoInfoTecnica_aux += "<h4>" + dtDescInfoTecnica.Rows[i]["Titulo"].ToString() + "</h4>";
                    textoInfoTecnica_aux += "<div class=\"row\">";
                    textoInfoTecnica_aux += "<div class=\"col-sm-12\">";
                    textoInfoTecnica_aux += "<p>" + dtDescInfoTecnica.Rows[i]["Descripcion"].ToString() + "</p>";
                    textoInfoTecnica_aux += "</div>";
                    textoInfoTecnica_aux += "</div>";
                }
                textoInfoTecnica += "$(\"#divInfoDescCalidad\").html('" + textoInfoTecnica_aux + "');";
            }
            else
            {
                textoInfoTecnica += "$(\"#divItemsCalidad\").hide();";
                textoInfoTecnica += "$(\"#divInformacionCalidad\").show();";
            }
            outTxt += textoInfoTecnica;

            //SIMULACION DE DATOS FORMULARIO------------------------
            //DataTable dt_aux = new DataTable("calidad");
            //dt_aux.Columns.Add("idInfo", typeof(String));
            //dt_aux.Columns.Add("Titulo", typeof(String));
            //dt_aux.Columns.Add("UrlFoto", typeof(String));
            //dt_aux.Columns.Add("Descripcion", typeof(String));
            //DataRow fila_aux = dt_aux.NewRow();
            //fila_aux["idInfo"] = "500";
            //fila_aux["Titulo"] = "AVANCE OBRA COMEDOR INFANTIL";
            //fila_aux["UrlFoto"] = "../../Content/img/imgTest.jpg";
            //fila_aux["Descripcion"] = "La obra avanza según el cronograma";
            //dt_aux.Rows.Add(fila_aux);
            //dtTecnica = dt_aux.Copy();
            //-------------------------------------------------------

            if (dtTecnica.Rows.Count > 0)
            {
                string infoTecnica = "";
                //Información Calidad y técnica 
                for (int i = 0; i <= dtTecnica.Rows.Count - 1; i++)
                {
                    string ruta_img = "../../" + dtTecnica.Rows[i]["UrlFoto"].ToString();
                    infoTecnica += "<div class=\"list-group-item\">";
                    infoTecnica += "<h4>" + dtTecnica.Rows[i]["Titulo"].ToString() + "</h4> ";
                    infoTecnica += "<div class=\"col-sm-2 mediaItem\">";
                    infoTecnica += "<img src=\"" + ruta_img + "\">";
                    infoTecnica += "</div>";
                    infoTecnica += "<div class=\"col-sm-10\">";
                    infoTecnica += "<p>" + dtTecnica.Rows[i]["Descripcion"].ToString() + "</p>";
                    infoTecnica += "<div class=\"btn btn-default\">";
                    infoTecnica += "<a role=\"button\" onclick=\"javascript:verInfoTecnica(" + dtTecnica.Rows[i]["idInfo"].ToString() + ");\">";
                    infoTecnica += "<span class=\"glyphicon glyphicon-comment\"></span>Ver Detalles</a></div>";
                    infoTecnica += "</div>";
                    infoTecnica += "</div>";
                }
                outTxt += "$(\"#divInfoTecnicaDet\").html('" + infoTecnica + "');";
            }

            //Grupos Auditores (agrupar por idgrupo) 
            string outTxtGrupos = pintarGACProyecto(dtGrupos, auditor, id_usuario);
            outTxt += outTxtGrupos;



            return outTxt;
        }

        public string obtGACProyecto(string codigo_bpin,int id_usuario){
            string outTxtGrupos = "";
            List<DataTable> listaInfo = new List<DataTable>();
            listaInfo = Models.clsProyectos.obtGACProyecto(codigo_bpin,id_usuario);
            DataTable dtGrupos = listaInfo[0];
            DataTable dtAuditor = listaInfo[1];  //TRAER ROL
            string auditor = "";  //VARIABLE PARA REVISAR SI ES AUDITOR EN EL PROYECTO
            if (dtAuditor.Rows.Count > 1)
            {
                auditor = dtAuditor.Rows[0]["auditor"].ToString();
            }
            outTxtGrupos =pintarGACProyecto(dtGrupos,auditor,id_usuario);
            return outTxtGrupos;
        }

        public string pintarGACProyecto(DataTable dtGrupos,String auditor,int id_usuario){
            string outTxtGrupos = "";
            if (dtGrupos.Rows.Count > 0)
            {
                //< div class="card card-block">
                //                 <div class="card-title">
                //                 <h4>Grupo de Auditores A<a href= "#" class="fr" title="Unirse al GAC"><img src = "img/iconHand.png" /></ a >< a href="#" class="fr"><img src = "img/FB-f-Logo__blue_29.png" /></ a >
                //                       < a href="#" class="fr"><img src = "img/iconEmail.png" /></ a ></ h4 >
                //                        < div class="card-block clearfix">
                //                 <div class="btn btn-info"><a href = "" > Plan de Trabajo</a>
                //                 </div>
                //                 <div class="btn btn-info"><a href = "profileProject_DetailedDoc.html" > Gestión </ a ></ div >
                //                 </ div >
                //                 </ div >
                //                 < div class="list-group uppText">
                //                   <div class="list-group-item">
                //                   <div class="col-sm-6"><span class="glyphicon glyphicon-user"></span> Luke Sky Walker
                //                  </div>
                //                   <div class="col-sm-2"><span class="glyphicon glyphicon-earphone"></span> <span>304 6579876</span> </div>
                //                   <div class="col-sm-4"><span class="glyphicon glyphicon-envelope"></span> <span><a href = "mailto:#" > luke@gac1.com</a></span></div>
                //                   </div>
                //                 </div>
                //               </div>

    //              agregado += '</tr></table><div style="text-align: center;vertical-align: middle;"><input name="btnTerminar" type="button" id="btnTerminar" value="Terminar" class="boton_general" onclick="javascript:GuardarAnexosExpediente(\'IND\');"></div>';
    //$('#dvExpedientes').html(agregado);

                string idGrupo = dtGrupos.Rows[0]["idgrupo"].ToString();
                string idUsuarioGrupo = dtGrupos.Rows[0]["idUsuario"].ToString();
                int contGrupos = 1;
                string tablaGrupos = "<div class=\"card card-block\"><div class=\"card - title\">";
                tablaGrupos += "<h4>Grupo 1";
                if (auditor != "1")
                {
                    tablaGrupos += "<a role=\"button\" onclick=\"UnirseGAC(" + idGrupo + ");\" class=\"fr\" title=\"Unirse al GAC\"><img src=\"../../Content/img/iconHand.png\" /></a>";
                }
                else {
                    if (id_usuario.ToString() == idUsuarioGrupo) { 
                        tablaGrupos += "<a role=\"button\" onclick=\"javascript:RetirarseGAC(" + idGrupo + ");\" class=\"fr\" title=\"Retirarse del GAC\"><img src = \"../../Content/img/iconHand_retiro.png\" /></a >";
                    }
                }
                tablaGrupos += "<a href=\"#\" class=\"fr\"><img src = \"../../Content/img/FB-f-Logo__blue_29.png\"/></a>";
                tablaGrupos += "<a href=\"#\" class=\"fr\"><img src=\"../../Content/img/iconEmail.png\"/></a></h4>";
                tablaGrupos += "<div class=\"card - block clearfix\">";
                tablaGrupos += "<div class=\"btn btn-info\"><a role=\"button\" onclick=\"obtPlanTrabajoGAC(" + idGrupo + ");\"> Plan de Trabajo</a></div>";
                tablaGrupos += "<div class=\"btn btn-info\"><a role=\"button\" onclick=\"obtGestionGAC(" + idGrupo + ");\"> Gestión </a></div>";
                tablaGrupos += "</div></div>";
                tablaGrupos += "<div class=\"list - group uppText\">";
                for (int i = 0; i <= dtGrupos.Rows.Count - 1; i++)
                {
                    idUsuarioGrupo = dtGrupos.Rows[i]["idUsuario"].ToString();
                    if (idGrupo != dtGrupos.Rows[i]["idgrupo"].ToString())
                    {
                        contGrupos++;
                        tablaGrupos += "</div></div>";
                        tablaGrupos += "<div class=\"card card-block\"><div class=\"card-title\">";
                        tablaGrupos += "<h4>Grupo " + contGrupos;
                        if (auditor != "1")
                        {
                            tablaGrupos += "<a role=\"button\" onclick=\"UnirseGAC(" + idGrupo + ");\" class=\"fr\" title=\"Unirse al GAC\"><img src=\"../../Content/img/iconHand.png\" /></a>";
                        }
                        else
                        {
                            if (id_usuario.ToString() == idUsuarioGrupo)
                            {
                                tablaGrupos += "<a role=\"button\" onclick=\"javascript:RetirarseGAC(" + idGrupo + ");\" class=\"fr\" title=\"Retirarse del GAC\"><img src = \"../../Content/img/iconHand_retiro.png\" /></a >";
                            }

                        }
                        tablaGrupos += "<a href=\"#\" class=\"fr\"><img src = \"../../Content/img/iconEmail.png\" /></a></h4>";
                        tablaGrupos += "<div class=\"card-block clearfix\">";
                        tablaGrupos += "<div class=\"btn btn-info\"><a role=\"button\" onclick=\"obtPlanTrabajoGAC(" + idGrupo + ");\"> Plan de Trabajo</a></div>";
                        tablaGrupos += "<div class=\"btn btn-info\"><a role=\"button\" onclick=\"obtGestionGAC(" + idGrupo + ");\">Gestión </a></div>";
                        tablaGrupos += "</div></div>";
                        tablaGrupos += "<div class=\"list-group uppText\">";
                    }
                    tablaGrupos += "<div class=\"list-group-item\">";
                    tablaGrupos += "<div class=\"col-sm-6\"><span class=\"glyphicon glyphicon-user\"></span>" + dtGrupos.Rows[i]["nombre"].ToString() + "</div>";
                    tablaGrupos += "<div class=\"col-sm-2\"><span class=\"glyphicon glyphicon-earphone\"></span><span>" + dtGrupos.Rows[i]["telefono"].ToString() + "</span></div>";
                    tablaGrupos += "<div class=\"col-sm-4\"><span class=\"glyphicon glyphicon-envelope\"></span><span><a href = \"mailto:#\" >" + dtGrupos.Rows[i]["email"].ToString() + "</a></span></div>";
                    tablaGrupos += "</div>";

                    idGrupo = dtGrupos.Rows[i]["idgrupo"].ToString();
                }
                tablaGrupos += "</div></div>";

                outTxtGrupos += "$(\"#divListadoAudit\").html(\'" + tablaGrupos + "\');";
                //deshabilitar boton btnUnirseGAC
                //outTxtGrupos += "$('#btnUnirseGAC').attr(\"disabled\", \"disabled\");";
                //outTxtGrupos += "$('#btnUnirseGAC').children().off('click');";
            }
            else
            {
                outTxtGrupos += "$(\"#divListadoAudit\").html('" + "Aún no hay grupos ciudadanos auditando el proyecto." + "');";
                //habilitar boton btnUnirseGAC
                //outTxtGrupos += "$('#btnUnirseGAC').removeAttr(\"disabled\");";
                //outTxtGrupos += "$('#btnUnirseGAC').children().on('click');";
            }
            return outTxtGrupos;
        
        }


    public string addDescTecnica(string bpin_proy,string titulo, string descripcion, int id_usuario)
    {
        string outTxt = "";
        outTxt = Models.clsProyectos.addDescripTecnica(bpin_proy,titulo, descripcion, id_usuario);
        return outTxt;
    }
    
    public string addInfoTecnica(string bpin_proy, string titulo, string descripcion, string[] adjuntos, int id_usuario) 
    {
            string outTxt = "";
            outTxt = Models.clsProyectos.addInfoTecnica(bpin_proy, titulo, descripcion, adjuntos, id_usuario);
            return outTxt;
    }

   public string obtInfoTecnica(int id_info)
        {
            string outTxt = "";
            DataTable dtTecnica = Models.clsProyectos.obtInfoTecnica(id_info)[0];
            if (dtTecnica.Rows.Count > 0)
            {
                string infoTecnica = "";
                int cant_imagenes = dtTecnica.Rows.Count;  //traer cantidad imagenes
                //Información Calidad y técnica  VISTA DETALLADA
                for (int i = 0; i <= dtTecnica.Rows.Count - 1; i++)
                {
                    outTxt += "$(\"#divTituloDetCalidad\").html(\"<p>" + dtTecnica.Rows[i]["Titulo"].ToString() + "</p>\");";
                    outTxt += "$(\"#divTextoDetCalidad\").html(\"<p>" + dtTecnica.Rows[i]["Descripcion"].ToString() + "</p>\");";
                    infoTecnica += "<div id=\"carousel-example-generic\" class=\"carousel slide\" data-ride=\"carousel\">";
                    infoTecnica += "<ol class=\"carousel-indicators\">";
                    for (int j = 0; j <= cant_imagenes - 1; j++) {
                        infoTecnica += "li data-target=\"#carousel-example-generic\" data-slide-to=\"" + j.ToString() + "\" class=\"active\"></li>";
                    }
                    infoTecnica += "</ol>";
                    infoTecnica += "<div class=\"carousel-inner\" role=\"listbox\">";
                    for (int k = 0; k <= cant_imagenes - 1; k++)
                    {
                        infoTecnica += "<div class=\"item active\">";
                        infoTecnica += "<img src=\"" + dtTecnica.Rows[i]["UrlFoto"].ToString() + "\" alt=\"detalleInfo\">";
                        infoTecnica += "</div>";
                    }
                    infoTecnica += "</div>";
                    infoTecnica += "<a class=\"left carousel-control\" href=\"#carousel-example-generic\" role=\"button\" data-slide=\"prev\">";
                    infoTecnica += "<span class=\"glyphicon glyphicon-chevron-left\" aria-hidden=\"true\"></span>";
                    infoTecnica += "<span class=\"sr-only\">Anterior</span>";
                    infoTecnica += "</a>";
                    infoTecnica += "<a class=\"right carousel-control\" href=\"#carousel-example-generic\" role=\"button\" data-slide=\"next\">";
                    infoTecnica += "<span class=\"glyphicon glyphicon-chevron-right\" aria-hidden=\"true\"></span>";
                    infoTecnica += "<span class=\"sr-only\">Siguiente</span>";
                    infoTecnica += "</a>";
                    infoTecnica += "</div>";

                    if (!String.IsNullOrEmpty(dtTecnica.Rows[i]["Adjunto"].ToString())) {
                        //HABILITA BOTONES DOCUMENTO
                        outTxt += "$(\"#btnDescargarDocDetalle\").atrr(\"onclick\",verDocumento('infotecnica','" + id_info.ToString() + "'))";
                        outTxt += "$(\"#divBtnDescargaDocInfoDet\").attr(\"class\")=\"showObj\"";
                    }
                }

                outTxt += "$(\"#divImagenesCarousel\").html('" + infoTecnica + "');";
            }
            else {
                outTxt = "$(\"#divImagenesCarousel\").html('" + " " + "');";
            }
            return outTxt;
        }

        public string modifInfoTecnica(int id_info, string titulo, string descripcion, string[] adjuntos, int id_usuario)
        {
            string outTxt = "";
            List<DataTable> listaInfo = new List<DataTable>();
            listaInfo = Models.clsProyectos.ModifInfoTecnica(id_info, titulo, descripcion, adjuntos, id_usuario);
            return outTxt;
        }

        public string obtGestionProyecto(string bpin_proyecto, int id_grupo, int id_usuario)
        {
            string outTxt = "";
            List<DataTable> listaInfo = new List<DataTable>();
            listaInfo = Models.clsProyectos.obtInfoGestionProy(bpin_proyecto, id_grupo, id_usuario);
            DataTable dtGeneral = listaInfo[0];
            DataTable dtAudiencias = listaInfo[1];
            DataTable dtObservaciones = listaInfo[2];
            DataTable dtObserUsu = listaInfo[3];
            DataTable dtReunionPrevia = listaInfo[4];
            DataTable dtInformeAplicativo = listaInfo[5];
            DataTable dtEvaluaExp = listaInfo[6];
            DataTable dtValoracion = listaInfo[7];

            //Falta definir la evaluación posterior (por grupo o por proyecto?)
            //DataTable dtEvaluacionPosterior = listaInfo[8];
            String EvaluacionP = "";


            String BotonesGestion = "";
            String idrol = "";
            String idperfil = "";
            String auditor = "";

            String idAudInicio = "";
            String fechaAudInicio = "";         
            String yaPasoAudInicio = "0";        /*1 YA PASO, 0 AUN NO HA PASADO*/
            String ActaAudInicio = "";
            String idAudSeguimiento = "";
            String fechaAudSeguimiento = "";
            String yaPasoAudSeguimiento = "0";        /*1 YA PASO, 0 AUN NO HA PASADO*/
            String ActaAudSeguimiento = "";
            String idAudCierre = "";
            String fechaAudCierre ="";
            String yaPasoAudCierre = "0";        /*1 YA PASO, 0 AUN NO HA PASADO*/
            String ActaAudCierre = "";

            if (dtGeneral.Rows.Count > 0)
            {
                idrol = dtGeneral.Rows[0]["idrol"].ToString();
                idperfil = dtGeneral.Rows[0]["idperfil"].ToString();
                auditor = dtGeneral.Rows[0]["auditor"].ToString();
            }
            if (dtAudiencias.Rows.Count > 0)
            {
                for (int i = 0; i <= dtAudiencias.Rows.Count - 1; i++)
                {
                    switch (dtAudiencias.Rows[i]["idTipoAudiencia"].ToString())
                    {
                        case "1":
                            idAudInicio = dtAudiencias.Rows[i]["idAudiencia"].ToString();
                            yaPasoAudInicio = dtAudiencias.Rows[i]["antesaud"].ToString();
                            fechaAudInicio = dtAudiencias.Rows[i]["fecha"].ToString();
                            ActaAudInicio = dtAudiencias.Rows[i]["acta"].ToString();
                            break;
                        case "2":
                            idAudSeguimiento = dtAudiencias.Rows[i]["idAudiencia"].ToString();
                            yaPasoAudSeguimiento = dtAudiencias.Rows[i]["antesaud"].ToString();
                            fechaAudSeguimiento = dtAudiencias.Rows[i]["fecha"].ToString();
                            ActaAudSeguimiento = dtAudiencias.Rows[i]["acta"].ToString();
                            break;
                        case "3":
                            idAudCierre = dtAudiencias.Rows[i]["idAudiencia"].ToString();
                            yaPasoAudCierre = dtAudiencias.Rows[i]["antesaud"].ToString();
                            fechaAudCierre = dtAudiencias.Rows[i]["fecha"].ToString();
                            ActaAudCierre = dtAudiencias.Rows[i]["acta"].ToString();
                            break;
                    }
                }
            }

            String InformeAudInicio = "";
            String InformeAudSeguimiento = "";
            String InformeAudCierre = "";

            if (dtInformeAplicativo.Rows.Count > 0)
            {
                for (int i = 0; i <= dtInformeAplicativo.Rows.Count - 1; i++)
                {
                    switch (dtInformeAplicativo.Rows[i]["idTipoAudiencia"].ToString())
                    {
                        case "1":
                            InformeAudInicio = dtInformeAplicativo.Rows[i]["informe"].ToString();
                            break;
                        case "2":
                            InformeAudSeguimiento = dtInformeAplicativo.Rows[i]["informe"].ToString();
                            break;
                        case "3":
                            InformeAudCierre = dtInformeAplicativo.Rows[i]["informe"].ToString();
                            break;
                    }
                }
            }

            String idEvaAudInicio = "";
            String idEvaAudSeguimiento = "";
            String idEvaAudCierre = "";

            if (dtEvaluaExp.Rows.Count > 0)
            {
                for (int i = 0; i <= dtEvaluaExp.Rows.Count - 1; i++)
                {
                    switch (dtEvaluaExp.Rows[i]["idTipoAudiencia"].ToString())
                    {
                        case "1":
                            idEvaAudInicio = dtEvaluaExp.Rows[i]["IdEvaluarAudiencia"].ToString();
                            break;
                        case "2":
                            idEvaAudSeguimiento = dtEvaluaExp.Rows[i]["IdEvaluarAudiencia"].ToString();
                            break;
                        case "3":
                            idEvaAudCierre = dtEvaluaExp.Rows[i]["IdEvaluarAudiencia"].ToString();
                            break;
                    }
                }
            }

            String idObserUsu = "";
            if (dtObserUsu.Rows.Count>0) {
                idObserUsu = dtObserUsu.Rows[0]["idObservacion"].ToString();
            }
            String InfObservaciones = "";
            String idObservacion = "";
            if (dtObservaciones.Rows.Count > 0)
            {
                idObservacion = dtObservaciones.Rows[0]["idObservacion"].ToString();
            }
            if ((String.IsNullOrEmpty(idObservacion)) && (!String.IsNullOrEmpty(auditor)) && (yaPasoAudInicio == "0"))
            {
                //generar documento
                InfObservaciones += "<div class=\"row itemGAC opcional\">";
                InfObservaciones += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_1.jpg\"/></span><span> Informe con Observaciones</span></div>";
                InfObservaciones += "<div class=\"col-sm-5\"><a onclick=\"javascript:obtInformeObsReuPrevias(" + "\\'" + bpin_proyecto + "\\'" + "," + "\\'" + id_usuario + "\\'" + ");\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-file\"></span> Generar Informe</a></div>";
            }
            else if ((String.IsNullOrEmpty(idObservacion)) && (!String.IsNullOrEmpty(auditor)) && (yaPasoAudInicio == "1"))
            {
                InfObservaciones += "<div class=\"row itemGAC deshabilitada\">";
                InfObservaciones += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_1.jpg\"/></span><span> Informe con Observaciones</span></div>";
            }
            else if ((String.IsNullOrEmpty(idObservacion)) && (String.IsNullOrEmpty(auditor)))
            {
                InfObservaciones += "<div class=\"row itemGAC deshabilitada\">";
                InfObservaciones += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_1.jpg\"/></span><span> Informe con Observaciones</span></div>";
            }
            else if (!String.IsNullOrEmpty(idObservacion))
            {
                //ver documento
                InfObservaciones += "<div class=\"row itemGAC realizada\">";
                InfObservaciones += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_1.jpg\"/></span><span> Informe con Observaciones</span></div>";
                InfObservaciones += "<div class=\"col-sm-5\"><a href=\"\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-eye-open\"></span> Ver Informe</a></div>";
            }
            if ((!String.IsNullOrEmpty(idObservacion)) && (String.IsNullOrEmpty(idObserUsu)) && (yaPasoAudInicio == "0"))
            {
                //ya existe una obs pero no es del usuario logueado
                InfObservaciones += "<div class=\"col-sm-5\"><a onclick=\"javascript:obtInformeObsReuPrevias(" + "\\'" + bpin_proyecto + "\\'" + "," + "\\'" + id_usuario + "\\'" + ");\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-file\"></span> Generar Informe</a></div>";
            }
            InfObservaciones += "</div>";

            String ReunionesPrevias = "";

            String actaReunionPrevia = "";
                        if (dtReunionPrevia.Rows.Count > 0)
            {
                actaReunionPrevia = dtReunionPrevia.Rows[0]["acta"].ToString();
            }
            if ((String.IsNullOrEmpty(actaReunionPrevia)) && (!String.IsNullOrEmpty(auditor)) && (yaPasoAudInicio == "0")) //No hay acta, es auditor y no ha pasado fecha de inicio
            {
                //AQUIIIIIIIIIIIIIIIIIIIII  \'IND\'  
                ReunionesPrevias += "<div class=\"row itemGAC opcional\">";
                ReunionesPrevias += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_1.jpg\"/></span><span>Reuniones Previas con Autoridades</span></div>";
                ReunionesPrevias += "<div class=\"col-sm-5\"><a  onclick=\"javascript:generarActaReuPrevias(" + "\\'" + bpin_proyecto + "\\'" + "," + "\\'" + id_usuario + "\\'" + ");\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-file\"></span> Generar Acta</a></div>";
            }
            else if ((String.IsNullOrEmpty(actaReunionPrevia)) && (!String.IsNullOrEmpty(auditor)) && (yaPasoAudInicio == "1")) //No hay acta, es auditor y ya ha pasado fecha de inicio
            {
                ReunionesPrevias += "<div class=\"row itemGAC deshabilitada\">";
                ReunionesPrevias += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_1.jpg\"/></span><span>Reuniones Previas con Autoridades</span></div>";
            }
            else if ((String.IsNullOrEmpty(actaReunionPrevia)) && (String.IsNullOrEmpty(auditor))) //No hay acta, pero no es auditor
            {
                ReunionesPrevias += "<div class=\"row itemGAC deshabilitada\">";
                ReunionesPrevias += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_1.jpg\"/></span><span>Reuniones Previas con Autoridades</span></div>";
            }
            else if (!String.IsNullOrEmpty(actaReunionPrevia)) //Hay acta
            {
                ReunionesPrevias += "<div class=\"row itemGAC realizada\">";
                ReunionesPrevias += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_1.jpg\"/></span><span>Reuniones Previas con Autoridades</span></div>";
                ReunionesPrevias += "<div class=\"col-sm-5\"><a role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-eye-open\"></span> Ver Acta</a></div>";

            }
            else
            {
                ReunionesPrevias += "<div class=\"row itemGAC deshabilitada\">";
                ReunionesPrevias += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_1.jpg\"/></span><span>Reuniones Previas con Autoridades</span></div>";
            }
            ReunionesPrevias += "</div>";
           

            String InfAplicativoAudInicio = "";

            if ((String.IsNullOrEmpty(InformeAudInicio)) && (!String.IsNullOrEmpty(auditor)) && (yaPasoAudInicio == "0")) //No hay informe, es auditor y no ha pasado fecha de inicio
            {
                InfAplicativoAudInicio += "<div class=\"row itemGAC pendiente\">";
                InfAplicativoAudInicio += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe del Aplicativo</span></div>";
                InfAplicativoAudInicio += "<div class=\"col-sm-5\"><a href=\"\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-file\"></span>Generar Acta</a></div>";
            }
            else if ((String.IsNullOrEmpty(InformeAudInicio)) && (!String.IsNullOrEmpty(auditor)) && (yaPasoAudInicio == "1")) //No hay informe, es auditor y ya ha pasado fecha de inicio
            {
                InfAplicativoAudInicio += "<div class=\"row itemGAC deshabilitada\">";
                InfAplicativoAudInicio += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe del Aplicativo</span></div>";
            }
            else if ((String.IsNullOrEmpty(InformeAudInicio)) && (String.IsNullOrEmpty(auditor))) //No hay informe, pero no es auditor
            {
                InfAplicativoAudInicio += "<div class=\"row itemGAC deshabilitada\">";
                InfAplicativoAudInicio += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe del Aplicativo</span></div>";
            }
            else if (!String.IsNullOrEmpty(InformeAudInicio)) //Hay informe
            {
                InfAplicativoAudInicio += "<div class=\"row itemGAC realizada\">";
                InfAplicativoAudInicio += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe del Aplicativo</span></div>";
                InfAplicativoAudInicio += "<div class=\"col-sm-5\"><a href=\"\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-eye-open\"></span> Ver Acta</a></div>";
            }
            else
            {
                InfAplicativoAudInicio += "<div class=\"row itemGAC deshabilitada\">";
                InfAplicativoAudInicio += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe del Aplicativo</span></div>";
            }
            InfAplicativoAudInicio += "</div>";

            String AudienciaInicio = "";
            if ((yaPasoAudInicio == "0")) //No ha pasado fecha de inicio
            {
                AudienciaInicio += "<div class=\"row itemGAC deshabilitada\">";
                AudienciaInicio += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_2.jpg\"/></span><span>Audiencia de Inicio</span></div>";
                if (!String.IsNullOrEmpty(fechaAudInicio)){
                    AudienciaInicio += "<a href =\"\"><img src =\"../../Content/img/FB-f-Logo__blue_29.png\"/></a>";
                    AudienciaInicio += "<a href =\"\"><img src =\"../../Content/img/iconEmail.png\"/></a>";
                }
            }
            else if ((String.IsNullOrEmpty(ActaAudInicio)) && (!String.IsNullOrEmpty(auditor)) && (yaPasoAudInicio == "1")) //No hay acta, es auditor y ya ha pasado fecha de inicio
            {
                AudienciaInicio += "<div class=\"row itemGAC pendiente\">";
                AudienciaInicio += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_2.jpg\"/></span><span>Audiencia de Inicio</span></div>";
                if (String.IsNullOrEmpty(idEvaAudInicio)) // el usuario no ha evaluado
                {
                    AudienciaInicio += "<div class=\"col-sm-5\"><a href=\"\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-eye-open\"></span>Evalúa tu Experiencia</a></div>";
                }
            }
            else if ((String.IsNullOrEmpty(ActaAudInicio)) && (String.IsNullOrEmpty(auditor))) //No hay acta, pero no es auditor
            {
                AudienciaInicio += "<div class=\"row itemGAC pendiente\">";
                AudienciaInicio += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_2.jpg\"/></span><span>Audiencia de Inicio</span></div>";
            }
            else if ((!String.IsNullOrEmpty(ActaAudInicio))&& (!String.IsNullOrEmpty(auditor))) //Hay acta y es auditor
            {
                AudienciaInicio += "<div class=\"row itemGAC realizada\">";
                AudienciaInicio += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_2.jpg\"/></span><span>Audiencia de Inicio</span></div>";
                AudienciaInicio += "<div class=\"col-sm-5\"><a href=\"\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-eye-open\"></span> Ver Acta</a></div>";
                if (String.IsNullOrEmpty(idEvaAudInicio)) // el usuario no ha evaluado
                {
                    AudienciaInicio += "<div class=\"col-sm-5\"><a href=\"\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-eye-open\"></span>Evalúa tu Experiencia</a></div>";
                }
            }
            else if ((!String.IsNullOrEmpty(ActaAudInicio)) && (String.IsNullOrEmpty(auditor))) //Hay acta y no es auditor
            {
                AudienciaInicio += "<div class=\"row itemGAC realizada\">";
                AudienciaInicio += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_2.jpg\"/></span><span>Audiencia de Inicio</span></div>";
                AudienciaInicio += "<div class=\"col-sm-5\"><a href=\"\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-eye-open\"></span> Ver Acta</a></div>";
            }
            else
            {
                AudienciaInicio += "<div class=\"row itemGAC deshabilitada\">";
                AudienciaInicio += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_2.jpg\"/></span><span>Audiencia de Inicio</span></div>";
            }

            AudienciaInicio += "</div>";

            String PlanTrabajoInicio = "";
            if ((yaPasoAudInicio == "0")) //No ha pasado fecha de inicio
            {
                PlanTrabajoInicio += "<div class=\"row itemGAC deshabilitada\">";
                PlanTrabajoInicio += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Plan de trabajo ajustable</span></div>";
            }
            else if ((yaPasoAudInicio == "1") && (yaPasoAudSeguimiento == "0")) //No ha pasado fecha de seguimiento
            {
                PlanTrabajoInicio += "<div class=\"row itemGAC pendiente\">";
                PlanTrabajoInicio += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Plan de trabajo ajustable</span></div>";
                if (!String.IsNullOrEmpty(auditor)) //Es auditor
                {
                    PlanTrabajoInicio += "<div class=\"col-sm-5\"><a href=\"\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-file\"></span> Editar plan de trabajo</a></div>";
                }
                else  //no es auditor
                {
                    PlanTrabajoInicio += "<div class=\"col-sm-5\"><a href=\"\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-file\"></span> Ver plan de trabajo</a></div>";
                }
            }
            else if (yaPasoAudSeguimiento == "1") //ya paso audiencia de seguimiento
            {
                PlanTrabajoInicio += "<div class=\"row itemGAC realizada\">";
                PlanTrabajoInicio += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Plan de trabajo ajustable</span></div>";
            }
            PlanTrabajoInicio += "</div>";

            //String ActaAudienciaInicio = "";

            String VerificacionAudInicio = "";
            if ((yaPasoAudInicio == "0")) //No ha pasado fecha de inicio
            {
                VerificacionAudInicio += "<div class=\"row itemGAC deshabilitada\">";
                VerificacionAudInicio += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_2.jpg\"/></span><span>Verificación</span></div>";
            }
            else if ((yaPasoAudInicio == "1") && (yaPasoAudSeguimiento == "0")) //No ha pasado fecha de seguimiento
            {
                VerificacionAudInicio += "<div class=\"row itemGAC pendiente\">";
                VerificacionAudInicio += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_2.jpg\"/></span><span>Verificación</span></div>";
                if (!String.IsNullOrEmpty(auditor)) //Es auditor
                {
                    VerificacionAudInicio += "<div class=\"col-sm-5\"><a href=\"\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-file\"></span> Generar observaciones</a></div>";
                }
                else  //no es auditor
                {
                    VerificacionAudInicio += "<div class=\"col-sm-5\"><a href=\"\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-file\"></span> Ver observaciones</a></div>";
                }
            }
            else if (yaPasoAudSeguimiento == "1") //ya paso audiencia de seguimiento
            {
                VerificacionAudInicio += "<div class=\"row itemGAC realizada\">";
                VerificacionAudInicio += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_2.jpg\"/></span><span>Verificación</span></div>";
                VerificacionAudInicio += "<div class=\"col-sm-5\"><a href=\"\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon  glyphicon-eye-open\"></span> Ver observaciones</a></div>";
            }
            VerificacionAudInicio += "</div>";

            String InformeProceso = "";
            if ((yaPasoAudInicio == "0")) //No ha pasado fecha de inicio
            {
                InformeProceso += "<div class=\"row itemGAC deshabilitada\">";
                InformeProceso += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe del Proceso</span></div>";
            }
            else if ((yaPasoAudInicio == "1") && (yaPasoAudSeguimiento == "0")) //No ha pasado fecha de seguimiento
            {
                InformeProceso += "<div class=\"row itemGAC pendiente\">";
                InformeProceso += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe del Proceso</span></div>";
                if (!String.IsNullOrEmpty(auditor)) //Es auditor
                {
                    InformeProceso += "<div class=\"col-sm-5\"><a onclick=\"javascript:informeproceso(" + "\\'" + bpin_proyecto + "\\'" + "," + "\\'" + id_usuario + "\\'" + ",2," + "\\'" + idAudSeguimiento + "\\'" + ");\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon  glyphicon-file\"></span> Diligenciar Informe</a></div>";
                }
                else  //no es auditor
                {
                    InformeProceso += "<div class=\"col-sm-5\"><a href=\"\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon  glyphicon-eye-open\"></span> Ver Informe</a></div>";
                }
            }
            else if (yaPasoAudSeguimiento == "1") //ya paso audiencia de seguimiento
            {
                InformeProceso += "<div class=\"row itemGAC realizada\">";
                InformeProceso += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe del Proceso</span></div>";
                InformeProceso += "<div class=\"col-sm-5\"><a href=\"\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon  glyphicon-eye-open\"></span> Ver informe</a></div>";
            }
            InformeProceso += "</div>";

            String AudienciaSeguimiento = "";
            if ((yaPasoAudSeguimiento == "0")) //No ha pasado fecha de Seguimiento
            {
                AudienciaSeguimiento += "<div class=\"row itemGAC deshabilitada\">";
                AudienciaSeguimiento += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_2.jpg\"/></span><span>Audiencia de Seguimiento</span></div>";
                if (!String.IsNullOrEmpty(fechaAudSeguimiento))
                {
                    AudienciaSeguimiento += "<a href =\"\"><img src =\"../../Content/img/FB-f-Logo__blue_29.png\"/></a>";
                    AudienciaSeguimiento += "<a href =\"\"><img src =\"../../Content/img/iconEmail.png\"/></a>";
                }
            }
            else if ((String.IsNullOrEmpty(ActaAudSeguimiento)) && (!String.IsNullOrEmpty(auditor)) && (yaPasoAudSeguimiento == "1")) //No hay acta, es auditor y ya ha pasado fecha de Seguimiento
            {
                AudienciaSeguimiento += "<div class=\"row itemGAC pendiente\">";
                AudienciaSeguimiento += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_2.jpg\"/></span><span>Audiencia de Seguimiento</span></div>";
                if (String.IsNullOrEmpty(idEvaAudSeguimiento)) // el usuario no ha evaluado
                {
                    AudienciaSeguimiento += "<div class=\"col-sm-5\"><a href=\"\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-eye-open\"></span>Evalúa tu Experiencia</a></div>";
                }
            }
            else if ((String.IsNullOrEmpty(ActaAudSeguimiento)) && (String.IsNullOrEmpty(auditor))) //No hay acta, pero no es auditor
            {
                AudienciaSeguimiento += "<div class=\"row itemGAC pendiente\">";
                AudienciaSeguimiento += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_2.jpg\"/></span><span>Audiencia de Seguimiento</span></div>";
            }
            else if ((!String.IsNullOrEmpty(ActaAudSeguimiento)) && (!String.IsNullOrEmpty(auditor))) //Hay acta y es auditor
            {
                AudienciaSeguimiento += "<div class=\"row itemGAC realizada\">";
                AudienciaSeguimiento += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_2.jpg\"/></span><span>Audiencia de Seguimiento</span></div>";
                AudienciaSeguimiento += "<div class=\"col-sm-5\"><a href=\"\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-eye-open\"></span> Ver Acta</a></div>";
                if (String.IsNullOrEmpty(idEvaAudSeguimiento)) // el usuario no ha evaluado
                {
                    AudienciaSeguimiento += "<div class=\"col-sm-5\"><a href=\"\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-eye-open\"></span>Evalúa tu Experiencia</a></div>";
                }
            }
            else if ((!String.IsNullOrEmpty(ActaAudSeguimiento)) && (String.IsNullOrEmpty(auditor))) //Hay acta y no es auditor
            {
                AudienciaSeguimiento += "<div class=\"row itemGAC realizada\">";
                AudienciaSeguimiento += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_2.jpg\"/></span><span>Audiencia de Seguimiento</span></div>";
                AudienciaSeguimiento += "<div class=\"col-sm-5\"><a href=\"\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-eye-open\"></span> Ver Acta</a></div>";
            }
            else
            {
                AudienciaSeguimiento += "<div class=\"row itemGAC deshabilitada\">";
                AudienciaSeguimiento += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_2.jpg\"/></span><span>Audiencia de Seguimiento</span></div>";
            }
            AudienciaSeguimiento += "</div>";

            String InfAplicativoAudSeg = "";
            if ((String.IsNullOrEmpty(InformeAudSeguimiento)) && (!String.IsNullOrEmpty(auditor)) && (yaPasoAudSeguimiento == "0")) //No hay informe, es auditor y no ha pasado fecha de seguimiento
            {
                InfAplicativoAudSeg += "<div class=\"row itemGAC deshabilitada\">";
                InfAplicativoAudSeg += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe del Aplicativo</span></div>";
            }
            else if ((String.IsNullOrEmpty(InformeAudSeguimiento)) && (!String.IsNullOrEmpty(auditor)) && (yaPasoAudSeguimiento == "1")) //No hay informe, es auditor y ya ha pasado fecha de seguimiento
            {
                InfAplicativoAudSeg += "<div class=\"row itemGAC pendiente\">";
                InfAplicativoAudSeg += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe del Aplicativo</span></div>";
                InfAplicativoAudSeg += "<div class=\"col-sm-5\"><a href=\"\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-file\"></span>Generar Informe</a></div>";

            }
            else if ((String.IsNullOrEmpty(InformeAudSeguimiento)) && (String.IsNullOrEmpty(auditor))) //No hay informe, pero no es auditor
            {
                InfAplicativoAudSeg += "<div class=\"row itemGAC deshabilitada\">";
                InfAplicativoAudSeg += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe del Aplicativo</span></div>";
            }
            else if (!String.IsNullOrEmpty(InformeAudSeguimiento)) //Hay informe
            {
                InfAplicativoAudSeg += "<div class=\"row itemGAC realizada\">";
                InfAplicativoAudSeg += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe del Aplicativo</span></div>";
                InfAplicativoAudSeg += "<div class=\"col-sm-5\"><a href=\"\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-eye-open\"></span> Ver Informe</a></div>";
            }
            else
            {
                InfAplicativoAudSeg += "<div class=\"row itemGAC deshabilitada\">";
                InfAplicativoAudSeg += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe del Aplicativo</span></div>";
            }
            InfAplicativoAudSeg += "</div>";

            String PlanTrabajoSeguimiento = "";
            if ((yaPasoAudSeguimiento == "0")) //No ha pasado fecha de Seguimiento
            {
                PlanTrabajoSeguimiento += "<div class=\"row itemGAC deshabilitada\">";
                PlanTrabajoSeguimiento += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Plan de trabajo ajustable</span></div>";
            }
            else if ((yaPasoAudSeguimiento == "1") && (yaPasoAudCierre == "0")) //No ha pasado fecha de cierre
            {
                PlanTrabajoSeguimiento += "<div class=\"row itemGAC pendiente\">";
                PlanTrabajoSeguimiento += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Plan de trabajo ajustable</span></div>";
                if (!String.IsNullOrEmpty(auditor)) //Es auditor
                {
                    PlanTrabajoSeguimiento += "<div class=\"col-sm-5\"><a href=\"\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-file\"></span> Editar plan de trabajo</a></div>";
                }
                else  //no es auditor
                {
                    PlanTrabajoSeguimiento += "<div class=\"col-sm-5\"><a href=\"\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-file\"></span> Ver plan de trabajo</a></div>";
                }
            }
            else if (yaPasoAudCierre == "1") //ya paso audiencia de cierre
            {
                PlanTrabajoSeguimiento += "<div class=\"row itemGAC realizada\">";
                PlanTrabajoSeguimiento += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Plan de trabajo ajustable</span></div>";
            }
            PlanTrabajoSeguimiento += "</div>";

            //String ActaAudienciaSeg = "";

            String VerificacionAudSeg = "";
            if ((yaPasoAudSeguimiento == "0")) //No ha pasado fecha de seguimiento
            {
                VerificacionAudSeg += "<div class=\"row itemGAC deshabilitada\">";
                VerificacionAudSeg += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_2.jpg\"/></span><span>Verificación</span></div>";
            }
            else if ((yaPasoAudSeguimiento == "1") && (yaPasoAudCierre == "0")) //No ha pasado fecha de cierre
            {
                VerificacionAudSeg += "<div class=\"row itemGAC pendiente\">";
                VerificacionAudSeg += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_2.jpg\"/></span><span>Verificación</span></div>";
                if (!String.IsNullOrEmpty(auditor)) //Es auditor
                {
                    VerificacionAudSeg += "<div class=\"col-sm-5\"><a href=\"\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-file\"></span> Generar observaciones</a></div>";
                }
                else  //no es auditor
                {
                    VerificacionAudSeg += "<div class=\"col-sm-5\"><a href=\"\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-file\"></span> Ver observaciones</a></div>";
                }
            }
            else if (yaPasoAudCierre == "1") //ya paso audiencia de cierre
            {
                VerificacionAudSeg += "<div class=\"row itemGAC realizada\">";
                VerificacionAudSeg += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_2.jpg\"/></span><span>Verificación</span></div>";
                VerificacionAudSeg += "<div class=\"col-sm-5\"><a href=\"\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon  glyphicon-eye-open\"></span> Ver observaciones</a></div>";
            }
            VerificacionAudSeg += "</div>";

            String valoracion = "";
            if (dtValoracion.Rows.Count > 0)
            {
                valoracion = dtValoracion.Rows[0]["idValoracion"].ToString();
            }
            String ValoracionProyecto = "";
            if ((yaPasoAudSeguimiento == "0")) //No ha pasado fecha de seguimiento
            {
                ValoracionProyecto += "<div class=\"row itemGAC deshabilitada\">";
                ValoracionProyecto += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_2.jpg\"/></span><span>Valoración del proyecto</span></div>";
            }
            else if ((yaPasoAudSeguimiento == "1") && (yaPasoAudCierre == "0")) //No ha pasado fecha de cierre
            {
                ValoracionProyecto += "<div class=\"row itemGAC pendiente\">";
                ValoracionProyecto += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_2.jpg\"/></span><span>Valoración del proyecto</span></div>";
                if ((!String.IsNullOrEmpty(auditor))&& (!String.IsNullOrEmpty(valoracion)))  //Es auditor y no ha valorado
                {
                    ValoracionProyecto += "<div class=\"col-sm-5\"><a  onclick=\"javascript:valorarproyecto(" + "\\'" + bpin_proyecto + "\\'" + "," + "\\'" + id_usuario + "\\'" + ");\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-file\"></span> Valorar Aquí</a></div>";
                }
                else  //no es auditor
                {
                    ValoracionProyecto += "<div class=\"col-sm-5\"><a href=\"\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon  glyphicon-eye-open\"></span> Ver Valoración</a></div>";
                }
            }
            else if (yaPasoAudCierre == "1") //ya paso audiencia de cierre
            {
                ValoracionProyecto += "<div class=\"row itemGAC realizada\">";
                ValoracionProyecto += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_2.jpg\"/></span><span>Valoración del proyecto</span></div>";
                ValoracionProyecto += "<div class=\"col-sm-5\"><a href=\"\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon  glyphicon-eye-open\"></span> Ver Valoración</a></div>";
            }
            ValoracionProyecto += "</div>";


            String AudienciaCierre = "";
            if ((yaPasoAudCierre == "0")) //No ha pasado fecha de cierre
            {
                AudienciaCierre += "<div class=\"row itemGAC deshabilitada\">";
                AudienciaCierre += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_2.jpg\"/></span><span>Audiencia de Cierre</span></div>";
                if (!String.IsNullOrEmpty(fechaAudCierre))
                {
                    AudienciaCierre += "<a href =\"\"><img src =\"../../Content/img/FB-f-Logo__blue_29.png\"/></a>";
                    AudienciaCierre += "<a href =\"\"><img src =\"../../Content/img/iconEmail.png\"/></a>";
                }
            }
            else if ((String.IsNullOrEmpty(ActaAudCierre)) && (!String.IsNullOrEmpty(auditor)) && (yaPasoAudCierre == "1")) //No hay acta, es auditor y ya ha pasado fecha de Cierre
            {
                AudienciaCierre += "<div class=\"row itemGAC pendiente\">";
                AudienciaCierre += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_2.jpg\"/></span><span>Audiencia de Cierre</span></div>";
                if (String.IsNullOrEmpty(idEvaAudCierre)) // el usuario no ha evaluado
                {
                    AudienciaCierre += "<div class=\"col-sm-5\"><a href=\"\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-eye-open\"></span>Evalúa tu Experiencia</a></div>";
                }
            }
            else if ((String.IsNullOrEmpty(ActaAudCierre)) && (String.IsNullOrEmpty(auditor))) //No hay acta, pero no es auditor
            {
                AudienciaCierre += "<div class=\"row itemGAC pendiente\">";
                AudienciaCierre += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_2.jpg\"/></span><span>Audiencia de Cierre</span></div>";
            }
            else if ((!String.IsNullOrEmpty(ActaAudCierre)) && (!String.IsNullOrEmpty(auditor))) //Hay acta y es auditor
            {
                AudienciaCierre += "<div class=\"row itemGAC realizada\">";
                AudienciaCierre += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_2.jpg\"/></span><span>Audiencia de Cierre</span></div>";
                AudienciaCierre += "<div class=\"col-sm-5\"><a href=\"\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-eye-open\"></span> Ver Acta</a></div>";
                if (String.IsNullOrEmpty(idEvaAudCierre)) // el usuario no ha evaluado
                {
                    AudienciaCierre += "<div class=\"col-sm-5\"><a href=\"\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-eye-open\"></span>Evalúa tu Experiencia</a></div>";
                }
            }
            else if ((!String.IsNullOrEmpty(ActaAudCierre)) && (String.IsNullOrEmpty(auditor))) //Hay acta y no es auditor
            {
                AudienciaCierre += "<div class=\"row itemGAC realizada\">";
                AudienciaCierre += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_2.jpg\"/></span><span>Audiencia de Cierre</span></div>";
                AudienciaCierre += "<div class=\"col-sm-5\"><a href=\"\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-eye-open\"></span> Ver Acta</a></div>";
            }
            else
            {
                AudienciaCierre += "<div class=\"row itemGAC deshabilitada\">";
                AudienciaCierre += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_2.jpg\"/></span><span>Audiencia de Cierre</span></div>";
            }
            AudienciaCierre += "</div>";

            String InfAplicativoAudCierre = "";
            if ((String.IsNullOrEmpty(InformeAudCierre)) && (!String.IsNullOrEmpty(auditor)) && (yaPasoAudCierre == "0")) //No hay informe, es auditor y no ha pasado fecha de Cierre
            {
                InfAplicativoAudCierre += "<div class=\"row itemGAC deshabilitada\">";
                InfAplicativoAudCierre += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe del Aplicativo</span></div>";
            }
            else if ((String.IsNullOrEmpty(InformeAudCierre)) && (!String.IsNullOrEmpty(auditor)) && (yaPasoAudCierre == "1")) //No hay informe, es auditor y ya ha pasado fecha de Cierre
            {
                InfAplicativoAudCierre += "<div class=\"row itemGAC pendiente\">";
                InfAplicativoAudCierre += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe del Aplicativo</span></div>";
                InfAplicativoAudCierre += "<div class=\"col-sm-5\"><a href=\"\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-file\"></span>Generar Informe</a></div>";

            }
            else if ((String.IsNullOrEmpty(InformeAudCierre)) && (String.IsNullOrEmpty(auditor))) //No hay informe, pero no es auditor
            {
                InfAplicativoAudCierre += "<div class=\"row itemGAC deshabilitada\">";
                InfAplicativoAudCierre += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe del Aplicativo</span></div>";
            }
            else if (!String.IsNullOrEmpty(InformeAudCierre)) //Hay informe
            {
                InfAplicativoAudCierre += "<div class=\"row itemGAC realizada\">";
                InfAplicativoAudCierre += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe del Aplicativo</span></div>";
                InfAplicativoAudCierre += "<div class=\"col-sm-5\"><a href=\"\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-eye-open\"></span> Ver Informe</a></div>";
            }
            else
            {
                InfAplicativoAudCierre += "<div class=\"row itemGAC deshabilitada\">";
                InfAplicativoAudCierre += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe del Aplicativo</span></div>";
            }
            InfAplicativoAudCierre += "</div>";

            String Evaluacionposterior = "";
            if ((yaPasoAudCierre == "0")) //no ha pasado fecha de Cierre
            {
                Evaluacionposterior += "<div class=\"row itemGAC deshabilitada\">";
                Evaluacionposterior += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Evaluación Posterior</span></div>";
            }
            else if ((String.IsNullOrEmpty(EvaluacionP)) && (!String.IsNullOrEmpty(auditor)) && (yaPasoAudCierre == "1")) //No hay evaluacion, es auditor y ya ha pasado fecha de Cierre
            {
                Evaluacionposterior += "<div class=\"row itemGAC pendiente\">";
                Evaluacionposterior += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Evaluación Posterior</span></div>";
                Evaluacionposterior += "<div class=\"col-sm-5\"><a href=\"\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-file\"></span>Crear Evaluacion</a></div>";

            }
            else if ((String.IsNullOrEmpty(EvaluacionP)) && (String.IsNullOrEmpty(auditor))) //No hay evaluacion, pero no es auditor
            {
                Evaluacionposterior += "<div class=\"row itemGAC deshabilitada\">";
                Evaluacionposterior += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Evaluación Posterior</span></div>";
            }
            else if (!String.IsNullOrEmpty(EvaluacionP)) //Hay evaluacion
            {
                Evaluacionposterior += "<div class=\"row itemGAC realizada\">";
                Evaluacionposterior += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Evaluación Posterior</span></div>";
                Evaluacionposterior += "<a href =\"\"><img src =\"../../Content/img/FB-f-Logo__blue_29.png\"/></a>";
                Evaluacionposterior += "<a href =\"\"><img src =\"../../Content/img/iconEmail.png\"/></a>";
            }
            else
            {
                Evaluacionposterior += "<div class=\"row itemGAC deshabilitada\">";
                Evaluacionposterior += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Evaluación Posterior</span></div>";
            }
            Evaluacionposterior += "</div>";

            BotonesGestion = InfObservaciones + ReunionesPrevias + InfAplicativoAudInicio; //3
            BotonesGestion += AudienciaInicio + PlanTrabajoInicio + VerificacionAudInicio + InformeProceso; //4
            BotonesGestion += AudienciaSeguimiento + InfAplicativoAudSeg + PlanTrabajoSeguimiento + VerificacionAudSeg + ValoracionProyecto; //5
            BotonesGestion += AudienciaCierre + InfAplicativoAudCierre + Evaluacionposterior; //3

                outTxt += "$(\"#divGestion\").html('" + BotonesGestion + "');";

                return outTxt;
        }

/// <summary>
/// ObtenerTotalAuditoresXPalabraClave
/// </summary>
/// <param name="palabraClave"></param>
/// <returns></returns>
    public string ObtenerTotalAuditoresXPalabraClave(string palabraClave)
    {
        string rta = string.Empty;
        DataTable dtSalida = Models.clsProyectos.ObtenerTotalAuditoresXPalabraClave(palabraClave);
        if (dtSalida != null) //Se valida que la consulta de la base de datos venga con datos
        {
            dtSalida.TableName = "tabla";
            rta = "{\"Head\":" + JsonConvert.SerializeObject(dtSalida) + "}";
        }
        return rta;
    }

    /// <summary>
    /// Sirve para obtener el nombre, categoría, ruta de imagen de cada auditor
    /// </summary>
    /// <param name="palabraClave">Corresponde la nombre solicitado por el usario</param>
    /// <returns>Devuelve un string con los datos solicitados</returns>
    public string ObtenerAuditoresProyectosXPalabraClave(string palabraClave)
    {
      string rta = string.Empty;
      DataTable dtSalida = Models.clsProyectos.ObtInfoAuditoresProyectos(palabraClave);
      if (dtSalida != null) //Se valida que la consulta de la base de datos venga con datos
      {
        dtSalida.TableName = "tabla";
        rta = "{\"Head\":" + JsonConvert.SerializeObject(dtSalida) + "}";
      }
      return rta;
    }

    /// <summary>
    /// Sirve para traer los proyectos que coincidan con la palabra clave
    /// </summary>
    /// <param name="palabraClave">Devuelve un string con los datos solicitados</param>
    /// <param name="numPag">Correponde al número de la página que desea consultar</param>
    /// <param name="tamanoPag">Correponde al tamaño de la página</param>
    /// <returns></returns>
    public string ObtenerProyectosXPalabraClave(string palabraClave, int numPag, int tamanoPag)
    {
      string rta = string.Empty;
      DataTable dtSalida = Models.clsProyectos.ObtInfoBuscarProyectos(palabraClave, numPag, tamanoPag);
      if (dtSalida != null) //Se valida que la consulta de la base de datos venga con datos
      {
        dtSalida.TableName = "tabla";
        rta = "{\"Head\":" + JsonConvert.SerializeObject(dtSalida) + "}";
      }
      return rta;
    }

    /// <summary>
    /// Sirve para conocer el total de proyectos auditables presentes en la base de datos
    /// </summary>
    /// <param name="palabraClave">Devuelve un string con los datos solicitados</param>
    /// <returns>El número de proyectos presentes</returns>
    public string ObtenerTotalProyectosAuditables(string palabraClave)
    {
      string rta = string.Empty;
      DataTable dtSalida = Models.clsProyectos.ObtenerTotalProyectosAuditables(palabraClave);
      if (dtSalida != null) //Se valida que la consulta de la base de datos venga con datos
      {
        dtSalida.TableName = "tabla";
        rta = "{\"Head\":" + JsonConvert.SerializeObject(dtSalida) + "}";
      }
      return rta;
    }

        public string obtContratosProyecto(string NumCtto)
        {
            string outTxt = "";
            List<DataTable> listaInfo = new List<DataTable>();
            listaInfo = Models.clsProyectos.obtInfoContratoProy(NumCtto);
            DataTable dtContrato = listaInfo[0];
            DataTable dtActividades = listaInfo[1];
            DataTable dtInterventor = listaInfo[2];
            DataTable dtSupervisor = listaInfo[3];
            DataTable dtPoliza = listaInfo[4];
            DataTable dtModificaciones = listaInfo[5];

            String DetContrato = "";

            if (dtContrato.Rows.Count > 0)
            {
                DetContrato += "<div class=\"col-sm-6\"><h4>Número de Contrato</h4><div>";
                DetContrato += dtContrato.Rows[0]["NumCtto"].ToString();
                DetContrato += "</div></div>";
                DetContrato += "<div class=\"col-sm-6\"><h4>Valor Contratado</h4><div>";
                DetContrato += dtContrato.Rows[0]["ValorCtto"].ToString();
                DetContrato += "</div></div>";
                DetContrato += "<div class=\"col-sm-12\"><h4>Objeto del Contrato</h4><div>";
                DetContrato += dtContrato.Rows[0]["ObjetoCtto"].ToString();
                DetContrato += "</div></div>";
                DetContrato += "<div class=\"col-sm-6\"><h4>Fecha Suscripcion</h4><div>";
                DetContrato += dtContrato.Rows[0]["FechaSuscripcion"].ToString();
                DetContrato += "</div></div>";
                DetContrato += "<div class=\"col-sm-6\"><h4>Fecha Inicio</h4><div>";
                DetContrato += dtContrato.Rows[0]["FechaInicio"].ToString();
                DetContrato += "</div></div>";
                DetContrato += "<div class=\"col-sm-12\"><h4>Modalidad de Contratación</h4><div>";
                DetContrato += dtContrato.Rows[0]["NomModalidad"].ToString();
                DetContrato += "</div></div>";
            }

            DetContrato += "<div class=\"col-sm-12\"><h4>Actividades del contrato</h4>";
            

            if (dtActividades.Rows.Count > 0)
            {
                DetContrato = "<div class=\"table-responsive\"><table class=\"table table-hover table-striped\"><thead><tr><th>Nombre</th><th>Fecha Ejecución</th><th>Cantidad Ejecutado</th></tr></thead>";
                for (int i = 0; i <= dtActividades.Rows.Count - 1; i++)
                {
                    DetContrato += "<tr>";
                    DetContrato += "<td>" + dtActividades.Rows[i]["NomActividadCon"].ToString() + "</td>";
                    DetContrato += "<td>" + dtActividades.Rows[i]["FechaEje"].ToString() + "</td>";
                    DetContrato += "<td>" + dtActividades.Rows[i]["CantidadEje"].ToString() + "</td>";
                    DetContrato += "</tr>";
                }
                DetContrato += "</div>";
            }
            DetContrato += "</div>";


            DetContrato += "<div class=\"col-sm-12\"><h4>Contratista Seleccionado</h4>";
            if (dtContrato.Rows.Count > 0)
            {
                DetContrato += "<div>";
                DetContrato += "Nombre: " + dtContrato.Rows[0]["NombresCttista"].ToString() + "<br>";
                DetContrato += "Rep. Legal: " + dtContrato.Rows[0]["NombreRepLegalCttista"].ToString() + "<br>";
                DetContrato += "Nit: " + dtContrato.Rows[0]["NitCttista"].ToString() + "<br>";
                DetContrato += "Telefono: " + dtContrato.Rows[0]["Telefono"].ToString() + "<br>";
                DetContrato += "Correo: " + dtContrato.Rows[0]["Email"].ToString() + "<br>";
                DetContrato += "</div>";
            }
            DetContrato += "</div>";

            DetContrato += "<div class=\"col-sm-6\"><h4>Interventor Designado</h4>";
            if (dtInterventor.Rows.Count > 0)
            {
                DetContrato += "<div>";
                DetContrato += "Nombre: " + dtInterventor.Rows[0]["NomInterventor"].ToString() + "<br>";
                DetContrato += "Rep. Legal: " + dtInterventor.Rows[0]["NomRepLegalInterventor"].ToString() + "<br>";
                DetContrato += "Nit: " + dtInterventor.Rows[0]["NitInterventor"].ToString() + "<br>";
                DetContrato += "Telefono: " + dtInterventor.Rows[0]["Telefono"].ToString() + "<br>";
                DetContrato += "Correo: " + dtInterventor.Rows[0]["Email"].ToString() + "<br>";
                DetContrato += "</div>";
            }
            DetContrato += "</div>";


            DetContrato += "<div class=\"col-sm-6\"><h4>Supervisor</h4>";
            if (dtSupervisor.Rows.Count > 0)
            {
                DetContrato += "<div>";
                DetContrato += "Nombre: " + dtSupervisor.Rows[0]["NomSupervisor"].ToString() + "<br>";
                DetContrato += "Nit: " + dtSupervisor.Rows[0]["NitSupervisor"].ToString() + "<br>";
                DetContrato += "Dependencia: " + dtSupervisor.Rows[0]["NomDependencia"].ToString() + "<br>";
                DetContrato += "Cargo: " + dtSupervisor.Rows[0]["NomCargo"].ToString() + "<br>";
                DetContrato += "Telefono: " + dtSupervisor.Rows[0]["Telefono"].ToString() + "<br>";
                DetContrato += "Correo: " + dtSupervisor.Rows[0]["Email"].ToString() + "<br>";
                DetContrato += "</div>";
            }
            DetContrato += "</div>";

            DetContrato += "<div class=\"col-sm-12\"><h4>Información general de Pólizas y Garantías</h4>";
            DetContrato += "<p>";
            if (dtPoliza.Rows.Count > 0)
            {
                
                for (int i = 0; i <= dtPoliza.Rows.Count - 1; i++)
                {
                    DetContrato += "<br><b>" + dtPoliza.Rows[i]["nomTipoAmparo"].ToString() + "</b>. Aseguradora: " + dtPoliza.Rows[i]["nombreAseguradora"].ToString() + ". Número de Amparo: " + dtPoliza.Rows[i]["numeroAmparo"].ToString() + ". Beneficiario: " + dtPoliza.Rows[i]["beneficiario"].ToString() + ". Tomador: " + dtPoliza.Rows[i]["tomador"].ToString() + ". Número de cubrimientos: " + dtPoliza.Rows[i]["numeroCubrimientos"].ToString() + ". Fecha Expedición: " + dtPoliza.Rows[i]["fechaExpedicion"].ToString() + ". Número de Aprobación: " + dtPoliza.Rows[i]["NumAprobacion"].ToString() + ". Fecha Documento de Aprobación: " + dtPoliza.Rows[i]["FechaDocAprobacion"].ToString() + ". - ";
                }

            }
            //falta programación
            DetContrato += "</p>";
            DetContrato += "<div id =\"divPolizaDet\" class=\"btn btn-default hideObj\">";
            DetContrato += "<a role =\"button\" id=\"divPolizaDocumento\">";
            DetContrato += "<span class=\"glyphicon glyphicon-save-file\"></span>VER DOCUMENTO</a>";
            DetContrato += "</div></div>";

            DetContrato += "<div class=\"col-sm-12\"><h4>Información de modificaciones</h4>";

            if (dtModificaciones.Rows.Count > 0)
            {
                DetContrato = "<div class=\"table-responsive\"><table class=\"table table-hover table-striped\"><thead><tr><th>Modificación</th><th>Fecha</th><th>Unidad</th><th>Cantidad</th><th>Valor</th></tr></thead>";

                for (int i = 0; i <= dtModificaciones.Rows.Count - 1; i++)
                {
                    DetContrato += "<tr>";
                    DetContrato += "<td>" + dtModificaciones.Rows[i]["NomTipoModificacion"].ToString() + "</td>";
                    DetContrato += "<td>" + dtModificaciones.Rows[i]["FechaModificacion"].ToString() + "</td>";
                    DetContrato += "<td>" + dtModificaciones.Rows[i]["UnidadTiempoModif"].ToString() + "</td>";
                    DetContrato += "<td>" + dtModificaciones.Rows[i]["CantidadTiempoModif"].ToString() + "</td>";
                    DetContrato += "<td>" + dtModificaciones.Rows[i]["ValorModif"].ToString() + "</td>";
                    DetContrato += "</tr>";
                }
                DetContrato += "</div>";

            }
            DetContrato += "</div>";

            outTxt += "$(\"#divDetContrato\").html('" + DetContrato + "');";

            return outTxt;

        }

    /// <summary>
    /// Sirve para obtener el total de grupos auditorias ciudadanas
    /// </summary>
    /// <param name="palabraClave">Es la palabra clave de la búsqueda</param>
    /// <returns>El # de grupos de auditorias ciudadanas</returns>
    public string ObtenerTotalGruposAuditoresCiudadanos(string palabraClave)
    {
      string rta = string.Empty;
      DataTable dtSalida = Models.clsProyectos.ObtenerTotalGruposAuditoriasCiudadanas(palabraClave);
      if (dtSalida != null) //Se valida que la consulta de la base de datos venga con datos
      {
        dtSalida.TableName = "tabla";
        rta = "{\"Head\":" + JsonConvert.SerializeObject(dtSalida) + "}";
      }
      return rta;
    }
    /// <summary>
    /// Sirve para traer los grupos de auditores ciudadanos que coincidan con la palabra clave
    /// </summary>
    /// <param name="palabraClave">Es la palabra clave solicitada en la búsqueda</param>
    /// <param name="numPag">Correponde al número de la página que desea consultar</param>
    /// <param name="tamanoPag">Correponde al tamaño de la página</param>
    /// <returns>Devuelve una cadena de texto con los datos solicitados</returns>
    public string ObtenerGacXPalabraClave(string palabraClave, int numPag, int tamanoPag)
    {
      string rta = string.Empty;
      DataTable dtSalida = Models.clsProyectos.ObtInfoGac(palabraClave, numPag, tamanoPag);
      if (dtSalida != null) //Se valida que la consulta de la base de datos venga con datos
      {
        dtSalida.TableName = "tabla";
        rta = "{\"Head\":" + JsonConvert.SerializeObject(dtSalida) + "}";
      }
      return rta;
    }
    /// <summary>
    /// Sirve para modificar el estado de un miembro de un grupo auditor
    /// </summary>
    /// <param name="parametrosModificar">Contiene los parámetros necesarios para hacer la modificación del registro</param>
    /// <returns>Devuelve una cadena de texto que indica si se realizó o no la actividad</returns>
    public string ModificarEstadoMiembroGac(string parametrosModificar)
    {
      var parametos = parametrosModificar.Split('*');//El * es un caracter que usamos para separar los datos a manipular
      return Models.clsProyectos.ModificarEstadoMiembroGac(parametos);
    }
    /// <summary>
    /// Sirve para modificar el estado de un grupo auditor
    /// </summary>
    /// <param name="parametrosModificar">Contiene los parámetros necesarios para hacer la modificación del registro</param>
    /// <returns>Devuelve una cadena de texto que indica si se realizó o no la actividad</returns>
    public string ModificarEstadoGac(string parametrosModificar)
    {
      var parametos = parametrosModificar.Split('*');//El * es un caracter que usamos para separar los datos a manipular
      return Models.clsProyectos.ModificarEstadoGac(parametos);
    }

  }
    }
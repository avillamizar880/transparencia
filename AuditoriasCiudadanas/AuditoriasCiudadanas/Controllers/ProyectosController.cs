using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Globalization;

namespace AuditoriasCiudadanas.Controllers
{
    public class ProyectosController
    {
        public string formato(string cadena) {
            return HttpUtility.HtmlEncode(cadena).Replace("\r", " ").Replace("\n", " ");
        }
        public string formato_moneda(string cadena) {
            string cad_aux = cadena;
            string cad_miles = "";
            char[] charsToTrim = {'.'};
            int posicion = 0;
               if (!string.IsNullOrEmpty(cadena)) {
                if (cadena.IndexOf(",") > -1) {
                    posicion = cadena.IndexOf(",");
                }else if (cadena.IndexOf(".") > -1){
                    posicion = cadena.IndexOf(".");
                }else {
                    posicion = cadena.Length;
                }
                if (posicion > 0) { 
                  cad_aux = cadena.Substring(0, posicion);
                    int q = (int)(cad_aux.Length / 3);
                    int r = cad_aux.Length % 3;
                    cad_miles = cad_aux.Substring(0, r) + ".";
                    int cont = r;
                    for (int i = 1; i <= q; i++)
                    {
                        cad_miles += cad_aux.Substring(cont, 3) + ".";
                        cont += 3;
                    }
                  cad_miles = cad_miles.TrimStart(charsToTrim);
                  cad_miles = "$" + cad_miles.TrimEnd(charsToTrim);

                }
                 //double dec_cadena = Convert.ToDouble(cadena);
                //CultureInfo elGR = System.Globalization.CultureInfo.GetCultureInfo("es-co");
                //cad_aux = String.Format("{0:C}", dec_cadena); 
            }
            return cad_miles;
        }
        public string formato_miles(string cadena) {
            string cad_aux = cadena;
            string cad_miles = "";
            char[] charsToTrim = { '.' };
            int posicion = 0;
            if (!string.IsNullOrEmpty(cadena))
            {
                if (cadena.IndexOf(",") > -1){
                    posicion = cadena.IndexOf(",");
                }else if (cadena.IndexOf(".") > -1){
                    posicion = cadena.IndexOf(".");
                }else{
                    posicion = cadena.Length;
                }
                if (posicion > 0)
                {
                    cad_aux = cadena.Substring(0, posicion);
                    int q = (int)(cad_aux.Length / 3);
                    int r = cad_aux.Length % 3;
                    cad_miles = cad_aux.Substring(0, r) + ".";
                    int cont = r;
                    for (int i = 1; i <= q; i++)
                    {
                        cad_miles += cad_aux.Substring(cont, 3) + ".";
                        cont += 3;
                    }
                    cad_miles = cad_miles.TrimEnd(charsToTrim);
                }
                
            }



            return cad_miles;
           
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

        public string formato_anyo(string cadena) {
            string cad_aux = cadena;
            if (!string.IsNullOrEmpty(cadena))
            {
                DateTime dt = Convert.ToDateTime(cadena);
                cad_aux = dt.ToString("yyyy",
                        CultureInfo.CreateSpecificCulture("es-co"));
            }

            return cad_aux;

        }

        public string MonthName(int month)
        {
            DateTimeFormatInfo dtinfo = new CultureInfo("es-CO", false).DateTimeFormat;
            return dtinfo.GetMonthName(month);
        }

        public string obtInfoProyecto(string id_proyecto,int id_usuario) {
            String outTxt = "";
            String bpinProyecto = "";  //CAMBIAR POR VALOR DE DT CORRESPONDIENTE
   
            List<DataTable> listaInfo = new List<DataTable>();
            listaInfo = Models.clsProyectos.obtInfoProyecto(id_proyecto, id_usuario);
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

            //si es auditor del proyecto, deshabilitar botón seguir
            //Tab General
            if (dtGeneral.Rows.Count > 0)
            {
                String ejecutor = "";
                outTxt += "$(\"#txtNombreProyecto\").html('" + "<h3>" + formato(dtGeneral.Rows[0]["Objetivo"].ToString().Trim()) + "</h3>" + "');";
                outTxt += "$(\"#divSectorDet\").html('" + formato(dtGeneral.Rows[0]["Sector"].ToString().Trim()) + "');";
                outTxt += "$(\"#divLocalizacionDet\").html('" + formato(dtGeneral.Rows[0]["Localizacion"].ToString().Trim()) + "');";
                outTxt += "$(\"#txtUbicaProyecto\").html(\"" + formato(dtGeneral.Rows[0]["Localizacion"].ToString().Trim()) + "\");";
                outTxt += "$(\"#txtNomContratista\").html(\"" + formato(dtGeneral.Rows[0]["NomEntidadEjecutora"].ToString().Trim()) + "\");";
                ejecutor += "Nombre: " + formato(dtGeneral.Rows[0]["NomEntidadEjecutora"].ToString().Trim());
                ejecutor += "<br>Nit: " + formato(dtGeneral.Rows[0]["NitEntidad"].ToString().Trim());
                ejecutor += "<br>Contacto: " + formato(dtGeneral.Rows[0]["Contacto"].ToString().Trim());
                ejecutor += "<br>Email: " + formato(dtGeneral.Rows[0]["email"].ToString().Trim());
                outTxt += "$(\"#divEntidadEjecDet\").html('" + ejecutor + "');";

                outTxt += "$(\"#divEstado\").html('" + formato(dtGeneral.Rows[0]["Estado"].ToString().Trim()) + "');";

                outTxt += "$(\"#divPresupuestoTotal\").html('" + formato(formato_moneda(dtGeneral.Rows[0]["Presupuesto"].ToString().Trim())) + "');";
                outTxt += "$(\"#divBeneficiarios\").html('" + formato(formato_miles(dtGeneral.Rows[0]["Beneficiarios"].ToString().Trim())) + "');";
                bpinProyecto = formato(dtGeneral.Rows[0]["bpin"].ToString().Trim());
                outTxt += "$(\"#spnPinProyecto\").html(\"" + "BPIN: " + bpinProyecto + "\");";
                String ejefis = "";
                String ejefin = "";
                String ejecutado = "";
                ejefis = formato(dtGeneral.Rows[0]["PorEjecucionFisica"].ToString().Trim());
                ejefin = formato(dtGeneral.Rows[0]["PorEjecucionFinanc"].ToString().Trim());
                ejecutado += "<div class=\"col-sm-6\"><strong> Porcentaje físico: </strong>";
                if (!String.IsNullOrEmpty(ejefis))
                {
                    ejecutado += ejefis+"%";

                }
                else
                {
                    ejecutado += "No disponible";

                }
                ejecutado += "</div> ";
                ejecutado += "<div class=\"col-sm-6\"><strong> Porcentaje financiero: </strong>";
                if (!String.IsNullOrEmpty(ejefin))
                {
                    ejecutado += ejefin + "%";

                }
                else
                {
                    ejecutado += "No disponible";

                }
                ejecutado += "</div></br></br> ";
                outTxt += "$(\"#divEjecucionDet\").html('" + ejecutado + "');";


            }
            if (dtProductos.Rows.Count > 0)
            {
                string Productos = "<ul>";
                for (int i = 0; i <= dtProductos.Rows.Count - 1; i++)
                {
                    Productos += "<li><strong>" + formato(dtProductos.Rows[i]["NombreProducto"].ToString().Trim()) + "</strong></li>";
                }
                Productos += "</ul>";
                outTxt += "$(\"#divProductosDet\").html('" + Productos + "');";
            }
            
            //cronograma de actividades
            if (dtCronograma.Rows.Count > 0)
            {
                string outCronograma = "";
                string outItemsCrono = "";
                DateTime max_planeado = DateTime.Parse(dtCronograma.AsEnumerable()
               .Max(row => row["FechaCtto"])
               .ToString());

                DateTime min_planeado = DateTime.Parse(dtCronograma.AsEnumerable()
                .Min(row => row["FechaCtto"])
                .ToString());

                DateTime max_ejecutado = DateTime.Parse(dtCronograma.AsEnumerable()
                .Max(row => row["FechaEje"])
                .ToString());

                DateTime min_ejecutado = DateTime.Parse(dtCronograma.AsEnumerable()
                .Min(row => row["FechaEje"])
                .ToString());

                DateTime limite_inferior;
                DateTime limite_superior;
                if (min_planeado < min_ejecutado)
                {
                    limite_inferior = min_planeado;
                }
                else
                {
                    limite_inferior = min_ejecutado;
                }

                if (max_planeado > max_ejecutado)
                {
                    limite_superior = max_planeado;
                }
                else
                {
                    limite_superior = max_ejecutado;
                }
                string fecha_min = (limite_inferior.ToString("MMMM") + " " + limite_inferior.Year.ToString()).ToUpper();
                string fecha_max = (limite_superior.ToString("MMMM") + " " + limite_superior.Year.ToString()).ToUpper();
                int mes_ini = limite_inferior.Month;
                int mes_fin = limite_superior.Month;
                int anyo_ini = limite_inferior.Year;
                int anyo_fin = limite_superior.Year;
             
                for (int j = anyo_ini; j <= anyo_fin; j++)
                {

                    if (j == anyo_ini)
                    {
                        if (j != anyo_fin)
                        {
                            for (int i = mes_ini; i <= 12; i++)
                            {
                                outItemsCrono += "<option anyo=\"" +  j.ToString() + "\" mes=\"" + i.ToString() + "\">" + MonthName(i).ToUpper() + " - " + j.ToString() + "</option>";
                            }
                        }
                        else
                        {
                            for (int i = mes_ini; i <= mes_fin; i++)
                            {
                                outItemsCrono += "<option anyo=\"" + j.ToString() + "\" mes=\"" + i.ToString() + "\">" + MonthName(i).ToUpper() + " - " + j.ToString() + "</option>";
                            }
                        }

                    }
                    else
                    {
                        if (j != anyo_fin)
                        {
                            for (int i = 1; i <= 12; i++)
                            {
                                outItemsCrono += "<option anyo=\"" + j.ToString() + "\" mes=\"" + i.ToString() + "\">" + MonthName(i).ToUpper() + " - " + j.ToString() + "</option>";
                            }
                        }
                        else
                        {
                            for (int i = 1; i <= mes_fin; i++)
                            {
                                outItemsCrono += "<option anyo=\"" + j.ToString() + "\" mes=\"" + i.ToString() + "\">" + MonthName(i).ToUpper() + " - " + j.ToString() + "</option>";
                            }
                        }
                    }
                }
                outCronograma += "<div class=\"row\">";
                outCronograma += "<div class=\"form-group col-sm-6\">";
                outCronograma += "<label for=\"ddlCronoIni\">Mostrar desde</label>";
                outCronograma += "<select class=\"form-control\" id=\"ddlCronoIni\">";
                //agrega items
                outCronograma += outItemsCrono;
                outCronograma += "</select>";
                outCronograma += "</div>";
                outCronograma += "<div class=\"form-group col-sm-6\">";
                outCronograma += "<label for=\"ddlCronoFin\">Hasta</label>";
                outCronograma += "<select class=\"form-control\" id=\"ddlCronoFin\">";
                //agrega items
                outCronograma += outItemsCrono;
                outCronograma += "</select>";
                outCronograma += "</div>";
                outCronograma += "</div>";

                outTxt += obtCronogramaProyecto(bpinProyecto,min_planeado, min_ejecutado);
                

             outTxt += "$(\"#divFiltroCronograma\").html('" + outCronograma + "');";
            }
            else {
                outTxt += "$(\"#divCronogramaPlan\").hide();";
                outTxt += "$(\"#divCronoEjec\").hide();";

            }
            //// Indicadores
            if (dtIndicadores.Rows.Count > 0)
            {
                string tablaIndi = "<div class=\"table-responsive\"><table class=\"table table-hover table-striped\"><thead><tr><th>Producto</th><th>Cantidad</th><th>Indicador</th><th>Valor meta</th><th>Vigencia</th><th>Ejecutado</th><th>%</th></tr></thead><tbody>";
                for (int i = 0; i <= dtIndicadores.Rows.Count - 1; i++)
                {
                    tablaIndi += "<tr>";
                    tablaIndi += "<td>" + formato(dtIndicadores.Rows[i]["NombreProducto"].ToString().Trim()) + "</td>";
                    tablaIndi += "<td>" + formato(formato_miles(dtIndicadores.Rows[i]["CantidadProducto"].ToString().Trim())) + " - " + formato(dtIndicadores.Rows[i]["NomUnidadProducto"].ToString().Trim()) + "</td>";
                    tablaIndi += "<td>" + formato(dtIndicadores.Rows[i]["NomIndicador"].ToString().Trim()) + "</td>";
                    tablaIndi += "<td>" + formato(formato_miles(dtIndicadores.Rows[i]["ValorMeta"].ToString().Trim())) + "</td>";
                    //tablaIndi += "<td>" + formato(formato_fecha(dtIndicadores.Rows[i]["FechaInicio"].ToString().Trim())) + "</td>";
                    //tablaIndi += "<td>" + formato(formato_fecha(dtIndicadores.Rows[i]["FechaFinal"].ToString().Trim())) + "</td>";
                    tablaIndi += "<td class=\"col-sm-1\">" + formato(formato_anyo(dtIndicadores.Rows[i]["FechaInicio"].ToString().Trim())) + "-" + formato(formato_anyo(dtIndicadores.Rows[i]["FechaFinal"].ToString().Trim())) + "</td>";
                    tablaIndi += "<td>" + formato(formato_miles(dtIndicadores.Rows[i]["ValorEjecutado"].ToString().Trim())) + "</td>";
                    tablaIndi += "<td>" + formato(dtIndicadores.Rows[i]["PorEjecutado"].ToString().Trim()) + "</td>";
                    tablaIndi += "</tr>";
                }
                tablaIndi += "</tbody></table></div></div>";
                outTxt += "$(\"#divIndicadores\").html('" + tablaIndi + "');";
            }
            ////Tab contratista
            string contratos = "";
            contratos += "<h2>Contratistas y supervisión</h2>";
            if (dtContratista.Rows.Count > 0)
            {
                //contratos += "<p>En esta sección encontrará información acerca de los contratos mediante los cuales actualmente se ejecuta el proyecto, y de las personas o entidades a cargo de su vigilancia.<br>";
                //contratos += "Recuerde que el supervisor de un contrato es un funcionario público de la entidad ejecutora, mientras que el interventor es una persona o entidad externa que posee conocimientos especializados para hacer seguimiento a aspectos específicos del contrato.<br>";
                //contratos += "Puede suceder que un solo proyecto se ejecute mediante más de un contrato.Haga clic en “Ver detalle” para acceder a información adicional sobre cada contrato.</p>";
                //Se realiza cambio según documento de descripciones dado
                contratos += "<p>En esta sección encontrará la información sobre el detalle de cada uno de los contratos realizados para obtener los productos previstos en el proyecto. También encontrará información del supervisor designado por la entidad ejecutora y el interventor responsable de la valoración de la calidad del (los) bien (es) y/o servicio (s) contratado (s).</p>";

 
                for (int i = 0; i <= dtContratista.Rows.Count - 1; i++)
                {
                    contratos += "<button class=\"btn btn-info\" type=\"button\" onclick=\"javascript:verDetalleContrato(" + "\\'" + formato(dtContratista.Rows[i]["NumCtto"].ToString().Trim()) + "\\'" + ");\"><span class=\"glyphicon glyphicon-plus\"></span>VER DETALLE</button>";
                    contratos += "<div class=\"list-group-item\">";
                    contratos += "<div class=\"col-sm-12\"><h4>Contrato: ";
                    contratos += formato(dtContratista.Rows[i]["NumCtto"].ToString().Trim());
                    contratos += "</h4>";
                    contratos += formato(dtContratista.Rows[i]["Objeto"].ToString().Trim());
                    contratos += "</div>";
                    contratos += "<div class=\"col-sm-12\"><h4>Contratista seleccionado</h4><div>";
                    contratos += formato(dtContratista.Rows[i]["NombresCttista"].ToString().Trim());
                    //contratos += "</div></div>";
                    //contratos += "<div class=\"col-sm-6\"><h4>Interventor Designado</h4><div>";
                    //contratos += formato(dtContratista.Rows[i]["NomInterventor"].ToString().Trim());
                    //contratos += "</div></div>";
                    //contratos += "<div class=\"col-sm-6\"><h4>Supervisor</h4><div>";
                    //contratos += formato(dtContratista.Rows[i]["NomSupervisor"].ToString().Trim());
                    contratos += "</div></div></div>";
                }
            }
            outTxt += "$(\"#divContrato\").html('" + contratos + "');";

            //Tab Presupuesto (Tablas:montos, modificaciones, costos por producto)
            //--------------------------------------------------------------------
            if (dtPresupMonto.Rows.Count > 0)
            {
                string tablaMonto = "<div class=\"table-responsive\"><table class=\"table table-hover table-striped\"><thead><tr><th>Entidad</th><th>Fuente financiación</th><th>Vigencia</th><th>Valor</th></tr></thead><tbody>";
                for (int i = 0; i <= dtPresupMonto.Rows.Count - 1; i++)
                {
                    tablaMonto += "<tr>";
                    //tablaMonto += "<td>" + formato(dtPresupMonto.Rows[i]["CodEntidad"].ToString().Trim()) + "</td>";
                    tablaMonto += "<td>" + formato(dtPresupMonto.Rows[i]["Entidad"].ToString().Trim()) + "</td>";
                    //tablaMonto += "<td>" + formato(dtPresupMonto.Rows[i]["CodFuenteFin"].ToString().Trim()) + "</td>";
                    tablaMonto += "<td>" + formato(dtPresupMonto.Rows[i]["NomFuenteFin"].ToString().Trim()) + "</td>";
                    tablaMonto += "<td>" + formato(dtPresupMonto.Rows[i]["Vigencia"].ToString().Trim()) + "</td>";
                    tablaMonto += "<td>" + formato(formato_moneda(dtPresupMonto.Rows[i]["Valor"].ToString().Trim())) + "</td>";
                    tablaMonto += "</tr>";
                }
                tablaMonto += "</tbody></table></div></div>";
                outTxt += "$(\"#divPresupuestoDet\").html('" + tablaMonto + "');";
            }
            //--------------------------------------------------------------------
            //se deshabilita por peticion laura gaitan 31/enero/2017
            //if (dtPresupModif.Rows.Count > 0)
            //{
            //    string tablaModif = "<div class=\"table-responsive\"><table class=\"table table-hover table-striped\"><thead><tr><th>Concepto</th><th>Descripcion</th><th>Fecha</th></tr></thead><tbody>";
            //    for (int i = 0; i <= dtPresupModif.Rows.Count - 1; i++)
            //    {
            //        tablaModif += "<tr>";
            //        tablaModif += "<td>" + formato(dtPresupModif.Rows[i]["Tipo"].ToString().Trim()) + "</td>";
            //        tablaModif += "<td>" + formato(dtPresupModif.Rows[i]["Descripcion"].ToString().Trim()) + "</td>";
            //        tablaModif += "<td>" + formato(formato_fecha(dtPresupModif.Rows[i]["Fecha"].ToString().Trim())) + "</td>";
            //        tablaModif += "</tr>";
            //    }
            //    tablaModif += "</tbody></table></div></div>";

            //    outTxt += "$(\"#divModifPresupDet\").html('" + tablaModif + "');";
            //}
            //else
            //{
            //    outTxt += "$(\"#divModifPresupDet\").html('" + "No hay modificaciones al presupuesto en el OCAD donde fue aprobado el proyecto." + "');";

            //}
            ////-----------------------------------------------------------------------
            //Eliminado petición 31 de enero
            //if (dtPresupProd.Rows.Count > 0)
            //{
            //    string tablaCosto = "<div class=\"table-responsive\"><table class=\"table table-hover table-striped\"><thead><tr><th>Actividad</th><th>Valor</th></tr></thead><tbody>";
            //    for (int i = 0; i <= dtPresupProd.Rows.Count - 1; i++)
            //    {
            //        tablaCosto += "<tr>";
            //        tablaCosto += "<td>" + formato(dtPresupProd.Rows[i]["actividad"].ToString().Trim()) + "</td>";
            //        tablaCosto += "<td>" + formato(formato_moneda(dtPresupProd.Rows[i]["valor"].ToString().Trim())) + "</td>";
            //        tablaCosto += "</tr>";
            //    }
            //    tablaCosto += "</tbody></table></div></div>";
            //    outTxt += "$(\"#divCostoActividadDet\").html('" + tablaCosto + "');";
            //}
            //------------------------------------------------------------------------
            if (dtPagosContrato.Rows.Count > 0)
            {
                string tablaPagos = "<div class=\"table-responsive\"><table class=\"table\"><thead><tr><th>Contrato</th><th>Concepto</th><th>Fuente de financiación</th><th>Fecha</th><th>Valor</th></tr></thead><tbody>";
                for (int i = 0; i <= dtPagosContrato.Rows.Count - 1; i++)
                {
                    tablaPagos += "<tr>";
                    tablaPagos += "<td>" + formato(dtPagosContrato.Rows[i]["NumCtto"].ToString().Trim()) + "</td>";
                    tablaPagos += "<td>" + formato(dtPagosContrato.Rows[i]["Concepto"].ToString().Trim()) + "</td>";
                    tablaPagos += "<td>" + formato(dtPagosContrato.Rows[i]["Fuente"].ToString().Trim()) + "</td>";
                    tablaPagos += "<td>" + formato(formato_fecha(dtPagosContrato.Rows[i]["Fecha"].ToString().Trim())) + "</td>";
                    tablaPagos += "<td>" + formato(formato_moneda(dtPagosContrato.Rows[i]["Valor"].ToString().Trim())) + "</td>";
                    tablaPagos += "</tr>";
                }
                tablaPagos += "</tbody></table></div></div>";
                outTxt += "$(\"#divPagosContrato\").html('" + tablaPagos + "');";
            }
            //------------------------------------------------------------------------
            //Tab formulacion
            if (dtFormulacion.Rows.Count > 0)
            {
                outTxt += "$(\"#divFechaOcadDet\").html('" + formato(formato_fecha(dtFormulacion.Rows[0]["Fecha"].ToString().Trim())) + " - " + formato(dtFormulacion.Rows[0]["NomOcad"].ToString().Trim()) + "." + "');";
                //-- No esta el acta sino el número 
                outTxt += "$(\"#divNumActaOcad\").html('" + formato(dtFormulacion.Rows[0]["Doc"].ToString().Trim()) + " - " + formato(formato_fecha(dtFormulacion.Rows[0]["Fecha"].ToString().Trim())) + "');";
                //-------si se tuviera documento Acta OCAD---------------------------------------------------------------------:
                //outTxt += "$(\"#divActaOcadDet\").atrr(\"onclick\",verDocumento('acta_ocad','" + bpinProyecto + "'))";
                //outTxt += "$(\"#divActaOcadDocumento\").attr(\"class\")=\"showObj\"";
                //---------------------------------------------------------------------------------------------------

                //-- No se tiene el dato
                outTxt += "$(\"#divCriteriosDetTexto\").html('" + formato(dtFormulacion.Rows[0]["priorizacion"].ToString()) + "');";
                //-------si se tuviera documento priorizacion---------------------------------------------------------------------:
                //outTxt += "$(\"#divCriteriosDet\").atrr(\"onclick\",verDocumento('criterios_priori','" + bpinProyecto + "'))";
                //outTxt += "$(\"#divCriteriosDocumento\").attr(\"class\")=\"showObj\"";
                //---------------------------------------------------------------------------------------------------
            }

            //----------Datos no disponibles ---------------
            //if (dtProyectosOcad.Rows.Count > 0)
            //{
            //    string Proyectos = "<ul>";
            //    for (int i = 0; i <= dtProyectosOcad.Rows.Count - 1; i++)
            //    {
            //        Proyectos += "<li>" + formato(dtProyectosOcad.Rows[i]["Proyecto"].ToString().Trim()) + ". - " + formato(dtProyectosOcad.Rows[i]["Localizacion"].ToString().Trim()) + "</li>";
            //    }
            //    Proyectos += "</ul>";
            //    outTxt += "$(\"#divPresOcadDet\").html('" + Proyectos + "');";
            //}
            //Ajustes
            if (dtAjustes.Rows.Count > 0)
            {
                string tablaAjustes = "<div class=\"table-responsive\"><table class=\"table\"><thead><tr><th>Documento</th><th>Fecha</th><th>Cambio de alcance</th><th>Disminución en beneficio</th><th>Reducción en meta</th><th>Fuentes de financiación</th><th>Incremento en valor</th><th>Disminución en valor</th></tr></thead><tbody>";
                for (int i = 0; i <= dtAjustes.Rows.Count - 1; i++)
                {
                    tablaAjustes += "<tr>";
                    tablaAjustes += "<td>" + formato(dtAjustes.Rows[i]["NumDoc"].ToString().Trim()) + "</td>";
                    tablaAjustes += "<td>" + formato(formato_fecha(dtAjustes.Rows[i]["FechaDoc"].ToString().Trim())) + "</td>";
                    tablaAjustes += "<td>" + formato(dtAjustes.Rows[i]["CambioAlcance"].ToString().Trim()) + "</td>";
                    tablaAjustes += "<td>" + formato(dtAjustes.Rows[i]["DisminucionBenef"].ToString().Trim()) + "</td>";
                    tablaAjustes += "<td>" + formato(dtAjustes.Rows[i]["ReduccionMeta"].ToString().Trim()) + "</td>";
                    tablaAjustes += "<td>" + formato(dtAjustes.Rows[i]["ModificacionFuentesFin"].ToString().Trim()) + "</td>";
                    tablaAjustes += "<td>" + formato(dtAjustes.Rows[i]["IncrementosValor"].ToString().Trim()) + "</td>";
                    tablaAjustes += "<td>" + formato(dtAjustes.Rows[i]["DisminucionValor"].ToString().Trim()) + "</td>";
                    tablaAjustes += "</tr>";
                }
                tablaAjustes += "</tbody></table></div></div>";
                outTxt += "$(\"#divAjustes\").html('" + tablaAjustes + "');";
            }
            if (dtRequisitos.Rows.Count > 0)
            {
                string tablaRequisitos = "<div class=\"table-responsive\"><table class=\"table\"><thead><tr><th>Código</th><th>Requisito</th><th>Fecha</th></tr></thead><tbody>";
                for (int i = 0; i <= dtRequisitos.Rows.Count - 1; i++)
                {
                    tablaRequisitos += "<tr>";
                    tablaRequisitos += "<td>" + formato(dtRequisitos.Rows[i]["CodRequisito"].ToString().Trim()) + "</td>";
                    tablaRequisitos += "<td>" + formato(dtRequisitos.Rows[i]["NomRequisito"].ToString().Trim()) + "</td>";
                    tablaRequisitos += "<td>" + formato(formato_fecha(dtRequisitos.Rows[i]["Fecha"].ToString().Trim())) + "</td>";
                    tablaRequisitos += "</tr>";
                }
                tablaRequisitos += "</tbody></table></div></div>";
                outTxt += "$(\"#divRequisitos\").html('" + tablaRequisitos + "');";
            }
            // OJO, NO ESTAN LOS DATOS
            //-----------------------------------------------------------------------
             //Estructura de tabla, si 
             //<%--<ul class="list-group">
             //<li class="list-group-item"><span class="glyphicon glyphicon-user"></span><span id="spnNomFormula"></span></li>
             //<li class="list-group-item"><span class="glyphicon glyphicon-credit-card"></span><span id="spnIdentifFormula"></span></li>
             //<li class="list-group-item"><span class="glyphicon glyphicon-envelope"></span><span id="spnEmailFormula"></span></li>
             //<li class="list-group-item"><span class="glyphicon glyphicon-earphone"></span><span id="contactoFormula"></span></li>
             //</ul>--%>

            //TAB PLANEACION
            // OJO, NO ESTAN LOS DATOS
            //-----------------------------------------------------------------------
            //outTxt += "$(\"#divDescripDet\").html(" + dtPlaneacion.Rows[0][""].ToString();
            //outTxt += "$(\"#divEspecifDet\").html(" + dtPlaneacion.Rows[0][""].ToString();
            //-------si se tuviera documento planeacion---------------------------------------------------------------------:
            //outTxt += "$(\"#divDocPlaDet\").atrr(\"onclick\",verDocumento('planeacion','" + bpinProyecto + "'))";
            //outTxt += "$(\"#divDocPlaneacion\").attr(\"class\")=\"showObj\"";
            //---------------------------------------------------------------------------------------------------

            //----INFORMACION TECNICA PROYECTO-----
            string outInfoTecnica = pintarInfoTecnicaProyecto(dtTecnica, dtDescInfoTecnica, tipo_rol, id_usuario, bpinProyecto);
            outTxt += outInfoTecnica;

            //Grupos Auditores (agrupar por idgrupo) 
            string outTxtGrupos = pintarGACProyecto(dtGrupos, auditor, id_usuario, bpinProyecto);
            outTxt += outTxtGrupos;



            return outTxt;
        }

        public string obtCronogramaProyecto(string codigo_bpin,DateTime fecha_ini,DateTime fecha_fin) {
            string outTxtCronograma = "";
            List<DataTable> listaInfo = new List<DataTable>();
            listaInfo = Models.clsProyectos.obtCronogramaProyecto(codigo_bpin,fecha_ini,fecha_fin);
            DataTable dtCronograma = listaInfo[0];
            outTxtCronograma = pintarCronogramaProyecto(dtCronograma);
            return outTxtCronograma;
        }

   public string pintarCronogramaProyecto(DataTable dtCronograma){
       string outCronoDet="";
       string Planeado="";
       string Ejecutado="";
        for (int i = 0; i <= dtCronograma.Rows.Count - 1; i++)
        {
            Planeado += "<div class=\"cronoItem\">";
            Planeado += "<span class=\"glyphicon glyphicon-flag\"></span>";
            Planeado += "<span class=\"dataHito\">" + formato(formato_fecha(dtCronograma.Rows[i]["FechaCtto"].ToString().Trim())) + "</span>";
            Planeado += "<p>" + formato(dtCronograma.Rows[i]["NomActividad"].ToString().Trim()) ;
            Planeado += "<br> Contrato: " + formato(dtCronograma.Rows[i]["NumCtto"].ToString().Trim()) + "</p>";
            Planeado += "</div>";
            if (dtCronograma.Rows[i]["FechaEje"].ToString() != "")
            {
                Ejecutado += "<div class=\"cronoItem\">";
                Ejecutado += "<span class=\"glyphicon glyphicon-flag\"></span>";
                Ejecutado += "<span class=\"dataHito\">" + formato(formato_fecha(dtCronograma.Rows[i]["FechaEje"].ToString().Trim())) + "</span>";
                Ejecutado += "<p>" + formato(dtCronograma.Rows[i]["NomActividad"].ToString().Trim()) + "</p>";
                Ejecutado += "<br>";
                Ejecutado += "</div>";
            }
        }
        outCronoDet += "$(\"#divCronogramaDet\").html('" + Planeado + "');";
        outCronoDet += "$(\"#divCronoEjecDet\").html('" + Ejecutado + "');";
        outCronoDet += "$(\"#divCronogramaPlan\").show();";
        outCronoDet += "$(\"#divCronoEjec\").show();";

        return outCronoDet;
   }


    public string obtGACProyecto(string codigo_bpin,int id_usuario){
            string outTxtGrupos = "";
            List<DataTable> listaInfo = new List<DataTable>();
            listaInfo = Models.clsProyectos.obtGACProyecto(codigo_bpin,id_usuario);
            DataTable dtGrupos = listaInfo[0];
            DataTable dtAuditor = listaInfo[1];  //TRAER ROL
            string auditor = "";  //VARIABLE PARA REVISAR SI ES AUDITOR EN EL PROYECTO
            if (dtAuditor.Rows.Count >= 1)
            {
                auditor = dtAuditor.Rows[0]["auditor"].ToString();
            }
            outTxtGrupos =pintarGACProyecto(dtGrupos,auditor,id_usuario, codigo_bpin);
            return outTxtGrupos;
        }

    public string obtGACProyectoCant(string codigo_bpin, int id_usuario)
    {
        string outTxtGrupos = "";
        List<DataTable> listaInfo = new List<DataTable>();
        listaInfo = Models.clsProyectos.obtGACProyecto(codigo_bpin, id_usuario);
        DataTable dtGrupos = listaInfo[0];
        var query = from row in dtGrupos.AsEnumerable()
                    group row by row.Field<int>("idgrupo") into grupos
                    orderby grupos.Key
                    select new
                    {
                        idgrupo = grupos.Key,
                        cantidad = grupos.Count()
                    };

        string cantGrupos = query.Count().ToString();
        outTxtGrupos = cantGrupos;
        return outTxtGrupos;
    }
        public string pintarGACProyecto(DataTable dtGrupos,String auditor,int id_usuario, String codigo_bpin)
        {
            string outTxtGrupos = "";
            //grupos distintos
            //var query = from row in dtGrupos.AsEnumerable()
            //            group row by row.Field<int>("idgrupo") into grupos
            //            orderby grupos.Key
            //            select new
            //            {
            //                idgrupo = grupos.Key,
            //                cantidad = grupos.Count()
            //            };

            //string cantGrupos = query.Count().ToString();


            string cantGrupos = "0";
            int contGrupos = 0;
            if (dtGrupos.Rows.Count > 0)
            {
                string idGrupo = dtGrupos.Rows[0]["idgrupo"].ToString();
                string idUsuarioGrupo = dtGrupos.Rows[0]["idUsuario"].ToString();
                contGrupos = 1;
                string tablaGrupos = "<div class=\"card card-block\"><div class=\"card - title\">";
                tablaGrupos += "<h4>Grupo 1</h4>";
                tablaGrupos += "<div class=\"opcionesList\">";

                if (auditor != "1")
                {
                    tablaGrupos += "<a role=\"button\" onclick=\"UnirseGAC(" + idGrupo + ");\" class=\"fr\" title=\"Unirse al GAC\"><img src=\"../../Content/img/iconHand.png\" /><span>Unirse</span></a>";
                }
                else {
                    if (id_usuario.ToString() == idUsuarioGrupo) { 
                        tablaGrupos += "<a role=\"button\" onclick=\"javascript:RetirarseGAC(" + idGrupo + ");\" class=\"fr\" title=\"Retirarse del GAC\"><img src = \"../../Content/img/iconHand_retiro.png\" /><span>Retirarse</span></a>";
                    }
                }

                string urlRedir = "";
                if (HttpContext.Current.Request.Url.IsDefaultPort)
                {urlRedir = "http://" + HttpContext.Current.Request.Url.Host;
                }
                else
                {urlRedir = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port;
                }

                tablaGrupos += "<div class=\"recuadroRedes\" data-toggle=\"tooltip\" title=\"Usted puede invitar por medio de su mail o de la red social Facebook a otros ciudadanos, para que se conviertan en Auditores Ciudadanos y se unan a su Grupo Auditor Ciudadano\"><a role=\"button\" onclick=\"fnFacebookInvitacion(\\'" + urlRedir + "/views/General/EnvioFacebook\\',\\'" + codigo_bpin + "\\', 0," + contGrupos + ")\"  class=\"fr\" ><img src = \"../../Content/img/FB-f-Logo__blue_29.png\"/></a>";
                tablaGrupos += "<a role=\"button\" onclick=\"fnVentanaCorreo(\\'" + urlRedir + "/views/General/EnvioCorreo\\',\\'" + codigo_bpin + "\\', 0," + contGrupos + ")\" class=\"fr\" ><img src=\"../../Content/img/iconEmail.png\"/></a></div>";
                tablaGrupos += "</div>";
                tablaGrupos += "<div class=\"card - block clearfix\">";
                tablaGrupos += "<div class=\"btn btn-info\"><a role=\"button\" onclick=\"obtPlanTrabajoGAC(" + idGrupo + ");\"> Plan de Trabajo</a></div>";
                tablaGrupos += "<div class=\"btn btn-info\"><a role=\"button\" onclick=\"obtGestionGAC(" + idGrupo + ");\"> Gestión </a></div>";
                tablaGrupos += "</div></div>";
                tablaGrupos += "<div class=\"list - group uppText\">";
                tablaGrupos += "<div class=\"list-group-item\">";
                tablaGrupos += "<div class=\"col-sm-6\"><strong> Nombre </strong></div>";
                tablaGrupos += "<div class=\"col-sm-6\"><strong> Correo electrónico </strong></div>";
                tablaGrupos += "</div>";
                for (int i = 0; i <= dtGrupos.Rows.Count - 1; i++)
                {
                    string id_grupo_fila = dtGrupos.Rows[i]["idgrupo"].ToString();
                    string id_usuario_fila = dtGrupos.Rows[i]["idUsuario"].ToString();

                    if (idGrupo != id_grupo_fila)
                    {
                        contGrupos++;
                        tablaGrupos += "</div></div>";
                        tablaGrupos += "<div class=\"card card-block\"><div class=\"card-title\">";
                        tablaGrupos += "<h4>Grupo " + contGrupos + "</h4>";
                        tablaGrupos += "<div class=\"opcionesList\">";
                        if (auditor != "1")
                        {
                              tablaGrupos += "<a role=\"button\" onclick=\"UnirseGAC(" + id_grupo_fila + ");\" class=\"fr\" title=\"Unirse al GAC\"><img src=\"../../Content/img/iconHand.png\" /><span>Unirse</span></a>";
                        }
                        else
                        {
                            if (id_usuario.ToString() == id_usuario_fila)
                            {
                                tablaGrupos += "<a role=\"button\" onclick=\"javascript:RetirarseGAC(" + id_grupo_fila + ");\" class=\"fr\" title=\"Retirarse del GAC\"><img src = \"../../Content/img/iconHand_retiro.png\" /><span>Retirarse</span></a>";
                            }

                        }

                        tablaGrupos += "<div class=\"recuadroRedes\" data-toggle=\"tooltip\" title=\"Usted puede invitar por medio de su mail o de la red social Facebook a otros ciudadanos, para que se conviertan en Auditores Ciudadanos y se unan a su Grupo Auditor Ciudadano\"><a role=\"button\" onclick=\"fnFacebookInvitacion(\\'" + urlRedir + "/views/General/EnvioFacebook\\',\\'" + codigo_bpin + "\\', 0," + contGrupos + ")\"  class=\"fr\" ><img src = \"../../Content/img/FB-f-Logo__blue_29.png\"/></a>";
                        tablaGrupos += "<a role=\"button\" onclick=\"fnVentanaCorreo(\\'" + urlRedir + "/views/General/EnvioCorreo\\',\\'" + codigo_bpin + "\\', 0," + contGrupos + ")\" class=\"fr\"><img src = \"../../Content/img/iconEmail.png\" /></a></div>";


                        tablaGrupos += "</div>";
                        tablaGrupos += "<div class=\"card-block clearfix\">";
                        tablaGrupos += "<div class=\"btn btn-info\"><a role=\"button\" onclick=\"obtPlanTrabajoGAC(" + id_grupo_fila + ");\"> Plan de Trabajo</a></div>";
                        tablaGrupos += "<div class=\"btn btn-info\"><a role=\"button\" onclick=\"obtGestionGAC(" + id_grupo_fila + ");\">Gestión </a></div>";
                        tablaGrupos += "</div></div>";
                        tablaGrupos += "<div class=\"list-group uppText\">";
                        tablaGrupos += "<div class=\"list-group-item\">";
                        tablaGrupos += "<div class=\"col-sm-6\"><strong> Nombre </strong></div>";
                        tablaGrupos += "<div class=\"col-sm-6\"><strong> Correo electrónico </strong></div>";
                        tablaGrupos += "</div>";
                    }
                    tablaGrupos += "<div class=\"list-group-item\">";
                    tablaGrupos += "<div class=\"col-sm-6\"><span class=\"glyphicon glyphicon-user\"></span>" + dtGrupos.Rows[i]["nombre"].ToString() + "</div>";
                    //tablaGrupos += "<div class=\"col-sm-2\"><span class=\"glyphicon glyphicon-earphone\"></span><span>" + dtGrupos.Rows[i]["telefono"].ToString() + "</span></div>";
                    tablaGrupos += "<div class=\"col-sm-6\"><span class=\"glyphicon glyphicon-envelope\"></span><span><a href = \"mailto:#\" >" + dtGrupos.Rows[i]["email"].ToString() + "</a></span></div>";
                    tablaGrupos += "</div>";

                    idGrupo = dtGrupos.Rows[i]["idgrupo"].ToString();
                    idUsuarioGrupo = dtGrupos.Rows[i]["idUsuario"].ToString();
                }
                tablaGrupos += "</div></div>";

                outTxtGrupos += "$(\"#divListadoAudit\").html(\'" + tablaGrupos + "\');";
                //deshabilitar boton btnUnirseGAC
                if (auditor.Equals("1")) {
                    //outTxtGrupos += "$('#btnSeguirProy').hide();";
                    outTxtGrupos += "$('#btnUnirseGAC').hide();";
                }

                
            }
            else
            {
                outTxtGrupos += "$(\"#divListadoAudit\").html('" + "Aún no hay grupos ciudadanos auditando el proyecto." + "');";
                //habilitar boton btnUnirseGAC
                //outTxtGrupos += "$('#btnSeguirProy').show();";
                outTxtGrupos += "$('#btnUnirseGAC').show();";
                
            }
            cantGrupos = contGrupos.ToString();
            outTxtGrupos += "$(\"#hdCantGrupos\").val(\'"+ cantGrupos + "\');";
            outTxtGrupos += "$(\"#hdAuditorProy\").val(\'" + auditor + "\');";

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

    public string modifInfoTecnica(int id_info, string titulo, string descripcion, string[] adjuntos, int id_usuario)
    {
        string outTxt = "";
        outTxt = Models.clsProyectos.ModifInfoTecnica(id_info, titulo, descripcion, adjuntos, id_usuario);
        return outTxt;
    }

    public string obtInfoTecnicaProyecto(string codigo_bpin,int id_usuario)
    {
        string outInfoTecnica = "";
        List<DataTable> listaInfo = new List<DataTable>();
        listaInfo = Models.clsProyectos.obtInfoTecnicaProyecto(codigo_bpin, id_usuario);
        DataTable dtRol = listaInfo[0];
        DataTable dtTecnica = listaInfo[1];
        DataTable dtDescInfoTecnica = listaInfo[2];

        string tipo_rol = "";  //VARIABLE PARA REVISAR ROL DEL USUARIO EN EL PROYECTO
            if(dtRol.Rows.Count>=1){
                tipo_rol=dtRol.Rows[0]["idrol"].ToString();
            }
            outInfoTecnica = pintarInfoTecnicaProyecto(dtTecnica, dtDescInfoTecnica, tipo_rol, id_usuario, codigo_bpin);
            return outInfoTecnica;
    }

    public string pintarInfoTecnicaProyecto(DataTable dtTecnica,DataTable dtDescInfoTecnica, string tipo_rol, int id_usuario, String codigo_bpin) {
        string outTxt = "";
        string textoInfoTecnica = "";
        string textoInfoTecnica_aux = "";
        //es interventor del proyecto
        if (dtDescInfoTecnica.Rows.Count > 0)
        {
            textoInfoTecnica += "$(\"#divInformacionCalidad\").hide();";  //deshabilita agregar descripcion inicial

            if (tipo_rol.Equals("3"))
            {
                textoInfoTecnica += "$(\"#btnNuevoInforme\").show();";  //agrega avances
                textoInfoTecnica += "$(\"#divItemsCalidad\").show();";  //visualiza avances
            }
            else
            {
                textoInfoTecnica += "$(\"#divItemsCalidad\").show();";  //visualiza avances
                textoInfoTecnica += "$(\"#btnNuevoInforme\").hide();";  //boton add avances
                textoInfoTecnica += "$(\"#NewInfoTecnicaProyecto\").hide();";  //form add avances
                textoInfoTecnica += "$(\"#divInfoTecnicaDet\").show();";  //visualiza avances
            }
            for (int i = 0; i <= dtDescInfoTecnica.Rows.Count - 1; i++)
            {
                textoInfoTecnica_aux += "<h4>" + formato(dtDescInfoTecnica.Rows[i]["Titulo"].ToString().Trim()) + "</h4>";
                textoInfoTecnica_aux += "<div class=\"row\">";
                textoInfoTecnica_aux += "<div class=\"col-sm-12\">";
                textoInfoTecnica_aux += "<p>" + formato(dtDescInfoTecnica.Rows[i]["Descripcion"].ToString().Trim()) + "</p>";
                textoInfoTecnica_aux += "</div>";
                textoInfoTecnica_aux += "</div>";
            }
            //pinta descripción inicial
            textoInfoTecnica += "$(\"#divInfoDescCalidad\").html('" + textoInfoTecnica_aux + "');";
            textoInfoTecnica += "$(\"#divInfoDescCalidad\").show();";  //habilita div contenedor
        }
        else
        {
            //deshabilita registro de avances
            textoInfoTecnica += "$(\"#divItemsCalidad\").hide();";
            if (tipo_rol.Equals("3"))
            {
                textoInfoTecnica += "$(\"#divInformacionCalidad\").show();";  //habilita agregar desc
            }
            else
            {
                textoInfoTecnica += "$(\"#divInformacionCalidad\").hide();";  //deshabilita agregar descripcion inicial
            }
        }


        outTxt += textoInfoTecnica;
        //-------------------------------------------------------

        if (dtTecnica.Rows.Count > 0)
        {
            string infoTecnica = "";
            //Información Calidad y técnica 
            for (int i = 0; i <= dtTecnica.Rows.Count - 1; i++)
            {
                string ruta_img = "../../" + dtTecnica.Rows[i]["UrlFoto"].ToString().Trim();
                infoTecnica += "<div class=\"list-group-item\">";
                infoTecnica += "<h4>" + formato(dtTecnica.Rows[i]["Titulo"].ToString().Trim()) + "</h4> ";
                infoTecnica += "<div class=\"col-sm-2 mediaItem\">";
                infoTecnica += "<img src=\"" + ruta_img + "\">";
                infoTecnica += "</div>";
                infoTecnica += "<div class=\"col-sm-10\">";
                infoTecnica += "<p>" + formato(dtTecnica.Rows[i]["Descripcion"].ToString().Trim()) + "</p>";
                infoTecnica += "<div class=\"btn btn-default\">";
                infoTecnica += "<a role=\"button\" onclick=\"javascript:verInfoTecnica(" + dtTecnica.Rows[i]["idInfo"].ToString().Trim() + ");\">";
                infoTecnica += "<span class=\"glyphicon glyphicon-comment\"></span>Ver detalles</a></div>";
                infoTecnica += "</div>";
                infoTecnica += "</div>";
            }
            outTxt += "$(\"#divInfoTecnicaDet\").html('" + infoTecnica + "');";
            if (tipo_rol.Equals("3"))
            {
                outTxt += "$(\"#btnEditarContenidoCalidad\").show();";  //habilita editar info tecnica
            }
            else
            {
                outTxt += "$(\"#btnEditarContenidoCalidad\").hide();";  //deshabilita editar info
            }
        }
        return outTxt;


    }

   public string obtInfoTecnica(int id_info)
        {
            string outTxt = "";
            DataTable dtTecnica = Models.clsProyectos.obtInfoTecnica(id_info)[0];
            if (dtTecnica.Rows.Count > 0)
            {

                 //<ol class="carousel-indicators">
                 //               <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                 //               <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                 //               <li data-target="#carousel-example-generic" data-slide-to="2"></li>
                 //             </ol>

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
                        infoTecnica += "<li data-target=\"#carousel-example-generic\" data-slide-to=\"" + j.ToString() + "\" class=\"active\"></li>";
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
                    if (cant_imagenes > 1) { 
                        infoTecnica += "<a class=\"left carousel-control\" href=\"#carousel-example-generic\" role=\"button\" data-slide=\"prev\">";
                        infoTecnica += "<span class=\"glyphicon glyphicon-chevron-left\" aria-hidden=\"true\"></span>";
                        infoTecnica += "<span class=\"sr-only\">Anterior</span>";
                        infoTecnica += "</a>";
                        infoTecnica += "<a class=\"right carousel-control\" href=\"#carousel-example-generic\" role=\"button\" data-slide=\"next\">";
                        infoTecnica += "<span class=\"glyphicon glyphicon-chevron-right\" aria-hidden=\"true\"></span>";
                        infoTecnica += "<span class=\"sr-only\">Siguiente</span>";
                        infoTecnica += "</a>";
                    }
                    
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
                outTxt += "$(\"#divImagenesCarousel\").html('" + " " + "');";
            }
            outTxt += "$(\"#hd_infoTecnica\").val(\'" + id_info + "\');";
            return outTxt;
        }

   public string obtInfoTecnicaById(int id_info)
   {
       string outTxt = "";
       DataTable dtTecnica = Models.clsProyectos.obtInfoTecnica(id_info)[0];
       AuditoriasCiudadanas.App_Code.funciones datos= new AuditoriasCiudadanas.App_Code.funciones();
       outTxt = datos.convertToJson(dtTecnica);
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
            DataTable dtInformeProceso= listaInfo[5];
            DataTable dtEvaluaExp = listaInfo[6];
            DataTable dtValoracion = listaInfo[7];
            DataTable dtCompromisos = listaInfo[8];


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
            String fechaAudCierre = "";
            String yaPasoAudCierre = "0";        /*1 YA PASO, 0 AUN NO HA PASADO*/
            String ActaAudCierre = "";
            String idReunionPrevia = "";
            String fechaReunionPrevia = "";
            String yaPasoReunionPrevia = "0";        /*1 YA PASO, 0 AUN NO HA PASADO*/
            String ActaReunionPrevia = "";

            String BtnHallazgo = "";


            BtnHallazgo = "<a role=\"button\" onclick=\"javascript:generarReporteHallazgos(" + id_grupo +")\" class=\"btn btn-info\">Reportar hallazgos</a><br />";
            outTxt += "$(\"#divBtnHallazgos\").html('" + BtnHallazgo + "');";

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
                        case "4":
                            idReunionPrevia = dtAudiencias.Rows[i]["idAudiencia"].ToString();
                            yaPasoReunionPrevia = dtAudiencias.Rows[i]["antesaud"].ToString();
                            fechaReunionPrevia = dtAudiencias.Rows[i]["fecha"].ToString();
                            ActaReunionPrevia = dtAudiencias.Rows[i]["acta"].ToString();
                            break;
                    }
                }
            }

            String InformePrevAudSeg = "";
            String InformePreAudCierre = "";

            if (dtInformeProceso.Rows.Count > 0)
            {
                for (int i = 0; i <= dtInformeProceso.Rows.Count - 1; i++)
                {
                    switch (dtInformeProceso.Rows[i]["idTipoAudiencia"].ToString())
                    {
                        case "1":
                            InformePrevAudSeg = dtInformeProceso.Rows[i]["informe"].ToString();
                            break;
                        case "2":
                            InformePreAudCierre = dtInformeProceso.Rows[i]["informe"].ToString();
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

            //variables compromisos
            String idCompromisoInicio = "";
            String idCompromisoSeguimiento = "";
            String idCompromisoCierre = "";

            if (dtCompromisos.Rows.Count > 0)
            {
                for (int i = 0; i <= dtCompromisos.Rows.Count - 1; i++)
                {
                    switch (dtCompromisos.Rows[i]["idTipoAudiencia"].ToString())
                    {
                        case "1":
                            idCompromisoInicio = dtCompromisos.Rows[i]["idCompromiso"].ToString();
                            break;
                        case "2":
                            idCompromisoSeguimiento = dtCompromisos.Rows[i]["idCompromiso"].ToString();
                            break;
                        case "3":
                            idCompromisoCierre = dtCompromisos.Rows[i]["idCompromiso"].ToString();
                            break;
                    }
                }
            }




            String InfCapacitacion = "";
            InfCapacitacion += "<div class=\"row itemGAC realizada\">";
            InfCapacitacion += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Capacitación</span></div>";
            InfCapacitacion += "</div>";


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
                InfObservaciones += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_4.jpg\"/></span><span> Informe con Observaciones</span></div>";
                InfObservaciones += "<div class=\"col-sm-5\"><a onclick=\"javascript:RegInformeObsReuPrevias(" + "\\'" + bpin_proyecto + "\\'" + "," + "\\'" + id_usuario + "\\'" + ");\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-file\"></span> Generar Informe</a></div>";
            }
            else if ((String.IsNullOrEmpty(idObservacion)) && (!String.IsNullOrEmpty(auditor)) && (yaPasoAudInicio == "1"))
            {
                InfObservaciones += "<div class=\"row itemGAC deshabilitada\">";
                InfObservaciones += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_4.jpg\"/></span><span> Informe con Observaciones</span></div>";
            }
            else if ((String.IsNullOrEmpty(idObservacion)) && (String.IsNullOrEmpty(auditor)))
            {
                InfObservaciones += "<div class=\"row itemGAC deshabilitada\">";
                InfObservaciones += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_4.jpg\"/></span><span> Informe con Observaciones</span></div>";
            }
            else if (!String.IsNullOrEmpty(idObservacion))
            {
                //ver documento
                InfObservaciones += "<div class=\"row itemGAC realizada\">";
                InfObservaciones += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_4.jpg\"/></span><span> Informe con Observaciones</span></div>";
                InfObservaciones += "<div class=\"col-sm-5\"><a onclick=\"javascript:VerInformeObsReuPrevias(" + "\\'" + bpin_proyecto + "\\'" + ");\"  role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-eye-open\"></span> Ver Informe</a></div>";
            }
            if ((!String.IsNullOrEmpty(idObservacion)) && (String.IsNullOrEmpty(idObserUsu)) && (yaPasoAudInicio == "0"))
            {
                //ya existe una obs pero no es del usuario logueado
                InfObservaciones += "<div class=\"col-sm-5\"><a onclick=\"javascript:RegInformeObsReuPrevias(" + "\\'" + bpin_proyecto + "\\'" + "," + "\\'" + id_usuario + "\\'" + ");\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-file\"></span> Generar Informe</a></div>";
            }
            InfObservaciones += "</div>";

            String ReunionesPrevias = "";

            String actaReunionPrevia = "";
                        if (dtReunionPrevia.Rows.Count > 0)
            {
                actaReunionPrevia = dtReunionPrevia.Rows[0]["ruta"].ToString();
            }
            if ((String.IsNullOrEmpty(actaReunionPrevia)) && (!String.IsNullOrEmpty(auditor)) && (yaPasoAudInicio == "0")) //No hay acta, es auditor y no ha pasado fecha de inicio
            {
                //\'IND\'  
                ReunionesPrevias += "<div class=\"row itemGAC opcional\">";
                ReunionesPrevias += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_5.jpg\"/></span><span>Reuniones Previas con Autoridades<br/><div id=\"ff\">"+formato(formato_fecha(fechaReunionPrevia))+"</div></span></div>";
                ReunionesPrevias += "<div class=\"col-sm-5\"><a  onclick=\"javascript:generarActaReuPrevias(" + "\\'" + bpin_proyecto + "\\'" + "," + "\\'" + id_usuario + "\\'" + ");\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-file\"></span> Generar Acta</a></div>";
            }
            else if ((String.IsNullOrEmpty(actaReunionPrevia)) && (!String.IsNullOrEmpty(auditor)) && (yaPasoAudInicio == "1")) //No hay acta, es auditor y ya ha pasado fecha de inicio
            {
                ReunionesPrevias += "<div class=\"row itemGAC deshabilitada\">";
                ReunionesPrevias += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_5.jpg\"/></span><span>Reuniones Previas con Autoridades<br/><div id=\"ff\">" + formato(formato_fecha(fechaReunionPrevia)) + "</div></span></div>";
            }
            else if ((String.IsNullOrEmpty(actaReunionPrevia)) && (String.IsNullOrEmpty(auditor))) //No hay acta, pero no es auditor
            {
                ReunionesPrevias += "<div class=\"row itemGAC deshabilitada\">";
                ReunionesPrevias += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_5.jpg\"/></span><span>Reuniones Previas con Autoridades<br/><div id=\"ff\">" + formato(formato_fecha(fechaReunionPrevia)) + "</div></span></div>";
            }
            else if (!String.IsNullOrEmpty(actaReunionPrevia)) //Hay acta
            {
                ReunionesPrevias += "<div class=\"row itemGAC realizada\">";
                ReunionesPrevias += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_5.jpg\"/></span><span>Reuniones Previas con Autoridades<br/><div id=\"ff\">" + formato(formato_fecha(fechaReunionPrevia)) + "</div></span></div>";
                ReunionesPrevias += "<div class=\"col-sm-5\"><a onclick=\"javascript:VerActaReuPrevias(" + "\\'" + bpin_proyecto + "\\'" + ");\"  class=\"btn btn-default\"><span class=\"glyphicon glyphicon-eye-open\"></span> Ver Acta</a></div>";

            }
            else
            {
                ReunionesPrevias += "<div class=\"row itemGAC deshabilitada\">";
                ReunionesPrevias += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_5.jpg\"/></span><span>Reuniones Previas con Autoridades<br/><div id=\"ff\">" + formato(formato_fecha(fechaReunionPrevia)) + "</div></span></div>";
            }
            ReunionesPrevias += "</div>";
           

            //String InfAplicativoAudInicio = "";

            //if ((String.IsNullOrEmpty(InformeAudInicio)) && (!String.IsNullOrEmpty(auditor)) && (yaPasoAudInicio == "0")) //No hay informe, es auditor y no ha pasado fecha de inicio
            //{
            //    InfAplicativoAudInicio += "<div class=\"row itemGAC pendiente\">";
            //    InfAplicativoAudInicio += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe del Aplicativo</span></div>";
            //    //InfAplicativoAudInicio += "<div class=\"col-sm-5\"><a onclick=\"javascript:alert(" + "\\'En construccion\\'" + ");\"  role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-file\"></span>Generar Acta</a></div>";
            //    InfAplicativoAudInicio += "<div class=\"col-sm-5\"><a onclick=\"javascript:alert(" + "\\'En construccion\\'" + ");\" role=\"button\"  class=\"btn btn-default\"><span class=\"glyphicon glyphicon-file\"></span>Descargar presentación GAC</a></div>";
            //}
            ////else if ((String.IsNullOrEmpty(InformeAudInicio)) && (!String.IsNullOrEmpty(auditor)) && (yaPasoAudInicio == "1")) //No hay informe, es auditor y ya ha pasado fecha de inicio
            //else if ((String.IsNullOrEmpty(InformeAudInicio)) && (!String.IsNullOrEmpty(auditor)) ) //No hay informe, es auditor y ya ha pasado fecha de inicio
            //{
            //    InfAplicativoAudInicio += "<div class=\"row itemGAC deshabilitada\">";
            //    InfAplicativoAudInicio += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe del Aplicativo</span></div>";
            //}
            //else if ((String.IsNullOrEmpty(InformeAudInicio)) && (String.IsNullOrEmpty(auditor))) //No hay informe, pero no es auditor
            //{
            //    InfAplicativoAudInicio += "<div class=\"row itemGAC deshabilitada\">";
            //    InfAplicativoAudInicio += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe del Aplicativo</span></div>";
            //}
            //else if (!String.IsNullOrEmpty(InformeAudInicio)) //Hay informe
            //{
            //    InfAplicativoAudInicio += "<div class=\"row itemGAC realizada\">";
            //    InfAplicativoAudInicio += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe del Aplicativo</span></div>";
            //    InfAplicativoAudInicio += "<div class=\"col-sm-5\"><a onclick=\"javascript:alert(" + "\\'En construccion\\'" + ");\"  role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-eye-open\"></span> Ver Acta</a></div>";
            //}
            //else
            //{
            //    InfAplicativoAudInicio += "<div class=\"row itemGAC deshabilitada\">";
            //    InfAplicativoAudInicio += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe del Aplicativo</span></div>";
            //}
            //InfAplicativoAudInicio += "</div>";

            String AudienciaInicio = "";
            if ((yaPasoAudInicio == "0")) //No ha pasado fecha de inicio
            {
                AudienciaInicio += "<div class=\"row itemGAC deshabilitada\">";
                AudienciaInicio += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_1.jpg\"/></span><span>Audiencia de Inicio<br/>" + formato(formato_fecha(fechaAudInicio)) + "</span></div>";
                if (!String.IsNullOrEmpty(fechaAudInicio)){
                    AudienciaInicio += "<a href =\"\"><img alt=\"Invitar a la audiencia\" src =\"../../Content/img/FB-f-Logo__blue_29.png\"/></a>";
                    AudienciaInicio += "<a onclick=\"\" ><img  alt=\"Invitar la audiencia\" src =\"../../Content/img/iconEmail.png\"/></a>";
                    //fnFacebook('http://www.facebook.com/sharer.php?u=http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port + "/views/audiencias/invitacion?tipo=Inicio&fecha=26/10/2016 3:00 pm&fechacompromiso="+ fechaAudInicio.ToString() + " 03:15 pm&lugar=colegio de la comunidad'
                }
            }
            //else if ((String.IsNullOrEmpty(ActaAudInicio)) && (!String.IsNullOrEmpty(auditor)) && (yaPasoAudInicio == "1")) //No hay acta, es auditor y ya ha pasado fecha de inicio
            else if ((String.IsNullOrEmpty(ActaAudInicio)) && (!String.IsNullOrEmpty(auditor)) ) //No hay acta, es auditor y ya ha pasado fecha de inicio
            {
                AudienciaInicio += "<div class=\"row itemGAC pendiente\">";
                AudienciaInicio += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_1.jpg\"/></span><span>Audiencia de Inicio<br/>" + formato(formato_fecha(fechaAudInicio)) + "</span></div>";

                //habilita registro de compromisos
                if (string.IsNullOrEmpty(idCompromisoInicio))
                {
                    AudienciaInicio += "<div class=\"col-sm-5 botonGestion\"><a onclick =\"javascript:InsRegistroCompromisos(" + "\\'" + idAudInicio + "\\'" + ");\"  role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-file\"></span>Registrar Compromisos</a></div>";
                }
                else {
                    AudienciaInicio += "<div class=\"col-sm-5 botonGestion\"><a onclick =\"javascript:verRegistroCompromisos(" + "\\'" + idAudInicio + "\\'" + ");\"  role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-eye-open\"></span>Ver Compromisos</a></div>";
                }
                //evalua tu experiencia
                if (String.IsNullOrEmpty(idEvaAudInicio)) // el usuario no ha evaluado
                {
                    AudienciaInicio += "<div class=\"col-sm-5\"><a onclick =\"javascript:obtEvaluacionExperiencia(" + "\\'" + idAudInicio + "\\'" + ");\"  role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-eye-open\"></span> Evalúa tu Experiencia</a></div>";
          
                }

                
            }
            else if ((String.IsNullOrEmpty(ActaAudInicio)) && (String.IsNullOrEmpty(auditor))) //No hay acta, pero no es auditor
            {
                AudienciaInicio += "<div class=\"row itemGAC pendiente\">";
                AudienciaInicio += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_1.jpg\"/></span><span>Audiencia de Inicio<br/>" + formato(formato_fecha(fechaAudInicio)) + "</span></div>";
            }
            else if ((!String.IsNullOrEmpty(ActaAudInicio))&& (!String.IsNullOrEmpty(auditor))) //Hay acta y es auditor
            {
                AudienciaInicio += "<div class=\"row itemGAC realizada\">";
                AudienciaInicio += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_1.jpg\"/></span><span>Audiencia de Inicio<br/>" + formato(formato_fecha(fechaAudInicio)) + "</span></div>";
                AudienciaInicio += "<div class=\"col-sm-5\"><a onclick=\"javascript:alert(" + "\\'En construccion\\'" + ");\"  role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-eye-open\"></span> Ver Acta</a></div>";
                if (String.IsNullOrEmpty(idEvaAudInicio)) // el usuario no ha evaluado
                {
                    AudienciaInicio += "<div class=\"col-sm-5\"><a onclick=\"javascript:alert(" + "\\'En construccion\\'" + ");\"  role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-eye-open\"></span>Evalúa tu Experiencia</a></div>";
                }
            }
            else if ((!String.IsNullOrEmpty(ActaAudInicio)) && (String.IsNullOrEmpty(auditor))) //Hay acta y no es auditor
            {
                AudienciaInicio += "<div class=\"row itemGAC realizada\">";
                AudienciaInicio += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_1.jpg\"/></span><span>Audiencia de Inicio<br/>" + formato(formato_fecha(fechaAudInicio)) + "</span></div>";
                AudienciaInicio += "<div class=\"col-sm-5\"><a onclick=\"javascript:alert(" + "\\'En construccion\\'" + ");\"  role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-eye-open\"></span> Ver Acta</a></div>";
            }
            else
            {
                AudienciaInicio += "<div class=\"row itemGAC deshabilitada\">";
                AudienciaInicio += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_1.jpg\"/></span><span>Audiencia de Inicio<br/>" + formato(formato_fecha(fechaAudInicio)) + "</span></div>";
            }

            AudienciaInicio += "</div>";

            //String PlanTrabajoInicio = "";
            //if ((yaPasoAudInicio == "0")) //No ha pasado fecha de inicio
            //{
            //    PlanTrabajoInicio += "<div class=\"row itemGAC deshabilitada\">";
            //    PlanTrabajoInicio += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Plan de trabajo ajustable</span></div>";
            //}
            ////else if ((yaPasoAudInicio == "1") && (yaPasoAudSeguimiento == "0")) //No ha pasado fecha de seguimiento
            //else if ((!String.IsNullOrEmpty(ActaAudInicio)) && (yaPasoAudSeguimiento == "0")) //No ha pasado fecha de seguimiento
            //{
            //    PlanTrabajoInicio += "<div class=\"row itemGAC pendiente\">";
            //    PlanTrabajoInicio += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Plan de trabajo ajustable</span></div>";
            //    if (!String.IsNullOrEmpty(auditor)) //Es auditor
            //    {
            //        PlanTrabajoInicio += "<div class=\"col-sm-5\"><a onclick=\"javascript:alert(" + "\\'En construccion\\'" + ");\"  role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-file\"></span> Editar plan de trabajo</a></div>";
            //    }
            //    else  //no es auditor
            //    {
            //        PlanTrabajoInicio += "<div class=\"col-sm-5\"><a onclick=\"javascript:alert(" + "\\'En construccion\\'" + ");\"  role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-file\"></span> Ver plan de trabajo</a></div>";
            //    }
            //}
            ////else if (yaPasoAudSeguimiento == "1") //ya paso audiencia de seguimiento
            //else if (!String.IsNullOrEmpty(ActaAudInicio)) //ya paso audiencia de seguimiento
            //{
            //    PlanTrabajoInicio += "<div class=\"row itemGAC realizada\">";
            //    PlanTrabajoInicio += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Plan de trabajo ajustable</span></div>";
            //}
            //PlanTrabajoInicio += "</div>";

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
                    VerificacionAudInicio += "<div class=\"col-sm-5\"><a onclick=\"obtPlanTrabajoGAC(" + id_grupo + ");\"  role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-file\"></span> Editar Plan de Trabajo</a></div>";
                }
                else  //no es auditor
                {
                    VerificacionAudInicio += "<div class=\"col-sm-5\"><a onclick=\"obtPlanTrabajoGAC(" + id_grupo + ");\"  role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-file\"></span> Ver Plan de Trabajo</a></div>";
                }
            }
            else if (yaPasoAudSeguimiento == "1") //ya paso audiencia de seguimiento
            {
                VerificacionAudInicio += "<div class=\"row itemGAC realizada\">";
                VerificacionAudInicio += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_2.jpg\"/></span><span>Verificación</span></div>";
                VerificacionAudInicio += "<div class=\"col-sm-5\"><a onclick=\"obtPlanTrabajoGAC(" + id_grupo + ");\"  role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-file\"></span> Ver Plan de Trabajo</a></div>";
            }
            VerificacionAudInicio += "</div>";

            String InformeProceso = "";
            if ((yaPasoAudInicio == "0")) //No ha pasado fecha de inicio
            {
                InformeProceso += "<div class=\"row itemGAC deshabilitada\">";
                InformeProceso += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe de Gestión</span></div>";
            }
            else if ((yaPasoAudInicio == "1") && (yaPasoAudSeguimiento == "0")) //No ha pasado fecha de seguimiento
            {
                InformeProceso += "<div class=\"row itemGAC pendiente\">";
                InformeProceso += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe de Gestión</span></div>";
                if (!String.IsNullOrEmpty(auditor)) //Es auditor
                {
                    InformeProceso += "<div class=\"col-sm-5\"><a onclick=\"javascript:informeproceso(" + "\\'" + bpin_proyecto + "\\'" + "," + "\\'" + id_usuario + "\\'" + ",1,1," + "\\'" + idAudInicio + "\\'," + id_grupo + ");\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon  glyphicon-file\"></span> Diligenciar Informe</a></div>";
                }
                else  //no es auditor
                {
                    InformeProceso += "<div class=\"col-sm-5\"><a onclick=\"javascript:informeproceso(" + "\\'" + bpin_proyecto + "\\'" + "," + "\\'" + id_usuario + "\\'" + ",1,2," + "\\'" + idAudInicio + "\\'," + id_grupo + ");\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon  glyphicon-eye-open\"></span> Ver Informe</a></div>";
                }
            }
            else if (yaPasoAudSeguimiento == "1") //ya paso audiencia de seguimiento
            {
                InformeProceso += "<div class=\"row itemGAC realizada\">";
                InformeProceso += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe de Gestión</span></div>";
                InformeProceso += "<div class=\"col-sm-5\"><a onclick=\"javascript:informeproceso(" + "\\'" + bpin_proyecto + "\\'" + "," + "\\'" + id_usuario + "\\'" + ",1,2," + "\\'" + idAudInicio + "\\'," + id_grupo + ");\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon  glyphicon-eye-open\"></span> Ver Informe</a></div>";
            }
            InformeProceso += "</div>";

            String AudienciaSeguimiento = "";
            if ((yaPasoAudSeguimiento == "0")) //No ha pasado fecha de Seguimiento
            {
                AudienciaSeguimiento += "<div class=\"row itemGAC deshabilitada\">";
                AudienciaSeguimiento += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_1.jpg\"/></span><span>Audiencia de Seguimiento<br/><div id=\"ff\">" + formato(formato_fecha(fechaAudSeguimiento)) + " </div></span></div>";
                if (!String.IsNullOrEmpty(fechaAudSeguimiento))
                {
                    AudienciaSeguimiento += "<a href =\"\"><img  alt=\"Invitar a la audiencia\"  src =\"../../Content/img/FB-f-Logo__blue_29.png\"/></a>";
                    AudienciaSeguimiento += "<a href =\"\"><img alt=\"Invitar a la audiencia\"  src =\"../../Content/img/iconEmail.png\"/></a>";
                }
            }
            else if ((String.IsNullOrEmpty(ActaAudSeguimiento)) && (!String.IsNullOrEmpty(auditor)) && (yaPasoAudSeguimiento == "1")) //No hay acta, es auditor y ya ha pasado fecha de Seguimiento
            {
                AudienciaSeguimiento += "<div class=\"row itemGAC pendiente\">";
                AudienciaSeguimiento += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_1.jpg\"/></span><span>Audiencia de Seguimiento<br/><div id=\"ff\">" + formato(formato_fecha(fechaAudSeguimiento)) + " </div></span></div>";
                if (String.IsNullOrEmpty(idEvaAudSeguimiento)) // el usuario no ha evaluado
                {
                    AudienciaSeguimiento += "<div class=\"col-sm-5\"><a onclick=\"javascript:alert(" + "\\'En construccion\\'" + ");\"  role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-eye-open\"></span>Evalúa tu Experiencia</a></div>";
                }
            }
            else if ((String.IsNullOrEmpty(ActaAudSeguimiento)) && (String.IsNullOrEmpty(auditor))) //No hay acta, pero no es auditor
            {
                AudienciaSeguimiento += "<div class=\"row itemGAC pendiente\">";
                AudienciaSeguimiento += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_1.jpg\"/></span><span>Audiencia de Seguimiento<br/><div id=\"ff\">" + formato(formato_fecha(fechaAudSeguimiento)) + " </div></span></div>";
            }
            else if ((!String.IsNullOrEmpty(ActaAudSeguimiento)) && (!String.IsNullOrEmpty(auditor))) //Hay acta y es auditor
            {
                AudienciaSeguimiento += "<div class=\"row itemGAC realizada\">";
                AudienciaSeguimiento += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_1.jpg\"/></span><span>Audiencia de Seguimiento<br/><div id=\"ff\">" + formato(formato_fecha(fechaAudSeguimiento)) + " </div></span></div>";
                AudienciaSeguimiento += "<div class=\"col-sm-5\"><a onclick=\"javascript:alert(" + "\\'En construccion\\'" + ");\"  role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-eye-open\"></span> Ver Acta</a></div>";
                if (String.IsNullOrEmpty(idEvaAudSeguimiento)) // el usuario no ha evaluado
                {
                    AudienciaSeguimiento += "<div class=\"col-sm-5\"><a onclick=\"javascript:alert(" + "\\'En construccion\\'" + ");\"  role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-eye-open\"></span>Evalúa tu Experiencia</a></div>";
                }
            }
            else if ((!String.IsNullOrEmpty(ActaAudSeguimiento)) && (String.IsNullOrEmpty(auditor))) //Hay acta y no es auditor
            {
                AudienciaSeguimiento += "<div class=\"row itemGAC realizada\">";
                AudienciaSeguimiento += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_1.jpg\"/></span><span>Audiencia de Seguimiento<br/><div id=\"ff\">" + formato(formato_fecha(fechaAudSeguimiento)) + " </div></span></div>";
                AudienciaSeguimiento += "<div class=\"col-sm-5\"><a onclick=\"javascript:alert(" + "\\'En construccion\\'" + ");\"  role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-eye-open\"></span> Ver Acta</a></div>";
            }
            else
            {
                AudienciaSeguimiento += "<div class=\"row itemGAC deshabilitada\">";
                AudienciaSeguimiento += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_1.jpg\"/></span><span>Audiencia de Seguimiento<br/><div id=\"ff\">" + formato(formato_fecha(fechaAudSeguimiento)) + " </div></span></div>";
            }
            AudienciaSeguimiento += "</div>";

            //String InfAplicativoAudSeg = "";
            //if ((String.IsNullOrEmpty(InformeAudSeguimiento)) && (!String.IsNullOrEmpty(auditor)) && (yaPasoAudSeguimiento == "0")) //No hay informe, es auditor y no ha pasado fecha de seguimiento
            //{
            //    InfAplicativoAudSeg += "<div class=\"row itemGAC deshabilitada\">";
            //    InfAplicativoAudSeg += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe del Aplicativo</span></div>";
            //}
            //else if ((String.IsNullOrEmpty(InformeAudSeguimiento)) && (!String.IsNullOrEmpty(auditor)) && (yaPasoAudSeguimiento == "1")) //No hay informe, es auditor y ya ha pasado fecha de seguimiento
            //{
            //    InfAplicativoAudSeg += "<div class=\"row itemGAC pendiente\">";
            //    InfAplicativoAudSeg += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe del Aplicativo</span></div>";
            //    InfAplicativoAudSeg += "<div class=\"col-sm-5\"><a onclick=\"javascript:informeproceso(" + "\\'" + bpin_proyecto + "\\'" + "," + "\\'" + id_usuario + "\\'" + ",2," + "\\'" + idAudSeguimiento + "\\'," + id_grupo + ");\" role=\"button\"  class=\"btn btn-default\"><span class=\"glyphicon glyphicon-file\"></span>Generar Informe</a></div>";

            //}
            //else if ((String.IsNullOrEmpty(InformeAudSeguimiento)) && (String.IsNullOrEmpty(auditor))) //No hay informe, pero no es auditor
            //{
            //    InfAplicativoAudSeg += "<div class=\"row itemGAC deshabilitada\">";
            //    InfAplicativoAudSeg += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe del Aplicativo</span></div>";
            //}
            //else if (!String.IsNullOrEmpty(InformeAudSeguimiento)) //Hay informe
            //{
            //    InfAplicativoAudSeg += "<div class=\"row itemGAC realizada\">";
            //    InfAplicativoAudSeg += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe del Aplicativo</span></div>";
            //    InfAplicativoAudSeg += "<div class=\"col-sm-5\"><a onclick=\"javascript:alert(" + "\\'En construccion\\'" + ");\"  role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-eye-open\"></span> Ver Informe</a></div>";
            //}
            //else
            //{
            //    InfAplicativoAudSeg += "<div class=\"row itemGAC deshabilitada\">";
            //    InfAplicativoAudSeg += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe del Aplicativo</span></div>";
            //}
            //InfAplicativoAudSeg += "</div>";

            //String PlanTrabajoSeguimiento = "";
            //if ((yaPasoAudSeguimiento == "0")) //No ha pasado fecha de Seguimiento
            //{
            //    PlanTrabajoSeguimiento += "<div class=\"row itemGAC deshabilitada\">";
            //    PlanTrabajoSeguimiento += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Plan de trabajo ajustable</span></div>";
            //}
            //else if ((yaPasoAudSeguimiento == "1") && (yaPasoAudCierre == "0")) //No ha pasado fecha de cierre
            //{
            //    PlanTrabajoSeguimiento += "<div class=\"row itemGAC pendiente\">";
            //    PlanTrabajoSeguimiento += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Plan de trabajo ajustable</span></div>";
            //    if (!String.IsNullOrEmpty(auditor)) //Es auditor
            //    {
            //        PlanTrabajoSeguimiento += "<div class=\"col-sm-5\"><a onclick=\"javascript:alert(" + "\\'En construccion\\'" + ");\"  role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-file\"></span> Editar plan de trabajo</a></div>";
            //    }
            //    else  //no es auditor
            //    {
            //        PlanTrabajoSeguimiento += "<div class=\"col-sm-5\"><a onclick=\"javascript:alert(" + "\\'En construccion\\'" + ");\"  role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-file\"></span> Ver plan de trabajo</a></div>";
            //    }
            //}
            //else if (yaPasoAudCierre == "1") //ya paso audiencia de cierre
            //{
            //    PlanTrabajoSeguimiento += "<div class=\"row itemGAC realizada\">";
            //    PlanTrabajoSeguimiento += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Plan de trabajo ajustable</span></div>";
            //}
            //PlanTrabajoSeguimiento += "</div>";

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
                    VerificacionAudSeg += "<div class=\"col-sm-5\"><a onclick=\"obtPlanTrabajoGAC(" + id_grupo + ");\"  role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-file\"></span> Editar Plan de Trabajo</a></div>";
                }
                else  //no es auditor
                {
                    VerificacionAudSeg += "<div class=\"col-sm-5\"><a onclick=\"obtPlanTrabajoGAC(" + id_grupo + ");\"  role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-file\"></span> Ver Plan de Trabajo</a></div>";
                }
            }
            else if (yaPasoAudCierre == "1") //ya paso audiencia de cierre
            {
                VerificacionAudSeg += "<div class=\"row itemGAC realizada\">";
                VerificacionAudSeg += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_2.jpg\"/></span><span>Verificación</span></div>";
                VerificacionAudSeg += "<div class=\"col-sm-5\"><a onclick=\"obtPlanTrabajoGAC(" + id_grupo + ");\"  role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-file\"></span> Ver Plan de Trabajo</a></div>";
            }
            VerificacionAudSeg += "</div>";


            String InformeProcesoCierre = "";
            if ((yaPasoAudSeguimiento == "0")) //No ha pasado fecha de seguimiento
            {
                InformeProcesoCierre += "<div class=\"row itemGAC deshabilitada\">";
                InformeProcesoCierre += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe de Gestión</span></div>";
            }
            else if ((yaPasoAudSeguimiento == "1") && (yaPasoAudCierre == "0")) //No ha pasado fecha de cierre
            {
                InformeProcesoCierre += "<div class=\"row itemGAC pendiente\">";
                InformeProcesoCierre += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe de Gestión</span></div>";
                if (!String.IsNullOrEmpty(auditor)) //Es auditor
                {
                    InformeProcesoCierre += "<div class=\"col-sm-5\"><a onclick=\"javascript:informeproceso(" + "\\'" + bpin_proyecto + "\\'" + "," + "\\'" + id_usuario + "\\'" + ",2,1," + "\\'" + idAudInicio + "\\'," + id_grupo + ");\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon  glyphicon-file\"></span> Diligenciar Informe</a></div>";
                }
                else  //no es auditor
                {
                    InformeProcesoCierre += "<div class=\"col-sm-5\"><a onclick=\"javascript:informeproceso(" + "\\'" + bpin_proyecto + "\\'" + "," + "\\'" + id_usuario + "\\'" + ",2,2," + "\\'" + idAudInicio + "\\'," + id_grupo + ");\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon  glyphicon-eye-open\"></span> Ver Informe</a></div>";
                }
            }
            else if (yaPasoAudCierre == "1") //ya paso audiencia de cierre
            {
                InformeProcesoCierre += "<div class=\"row itemGAC realizada\">";
                InformeProcesoCierre += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe de Gestión</span></div>";
                InformeProcesoCierre += "<div class=\"col-sm-5\"><a onclick=\"javascript:informeproceso(" + "\\'" + bpin_proyecto + "\\'" + "," + "\\'" + id_usuario + "\\'" + ",2,2," + "\\'" + idAudInicio + "\\'," + id_grupo + ");\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon  glyphicon-eye-open\"></span> Ver Informe</a></div>";
            }
            InformeProcesoCierre += "</div>";

            String valoracion = "";
            if (dtValoracion.Rows.Count > 0)
            {
                valoracion = dtValoracion.Rows[0]["idValoracion"].ToString();
            }
            String ValoracionProyecto = "";
            if ((yaPasoAudSeguimiento == "0")) //No ha pasado fecha de seguimiento
            {
                ValoracionProyecto += "<div class=\"row itemGAC deshabilitada\">";
                ValoracionProyecto += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_6.jpg\"/></span><span>Valoración del proyecto</span></div>";
            }
            else if ((yaPasoAudSeguimiento == "1") && (yaPasoAudCierre == "0")) //No ha pasado fecha de cierre
            {
                ValoracionProyecto += "<div class=\"row itemGAC pendiente\">";
                ValoracionProyecto += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_6.jpg\"/></span><span>Valoración del proyecto</span></div>";
                if ((!String.IsNullOrEmpty(auditor))&& (!String.IsNullOrEmpty(valoracion)))  //Es auditor y no ha valorado
                {
                    ValoracionProyecto += "<div class=\"col-sm-5\"><a onclick=\"javascript:valorarproyecto(" + "\\'" + bpin_proyecto + "\\'" + "," + "\\'" + id_usuario + "\\',1" + ");\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-file\"></span> Valorar Aquí</a></div>";
                }
                else  //no es auditor
                {
                    ValoracionProyecto += "<div class=\"col-sm-5\"><a onclick=\"javascript:valorarproyecto(" + "\\'" + bpin_proyecto + "\\'" + "," + "\\'" + id_usuario + "\\',2" + ");\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon  glyphicon-eye-open\"></span> Ver Valoración</a></div>";
                }
            }
            else if (yaPasoAudCierre == "1") //ya paso audiencia de cierre
            {
                ValoracionProyecto += "<div class=\"row itemGAC realizada\">";
                ValoracionProyecto += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_6.jpg\"/></span><span>Valoración del proyecto</span></div>";
                ValoracionProyecto += "<div class=\"col-sm-5\"><a  onclick=\"javascript:VerValoracionProyecto(" + "\\'" + bpin_proyecto + "\\'" + ");\"  role=\"button\"  class=\"btn btn-default\"><span class=\"glyphicon  glyphicon-eye-open\"></span> Ver Valoración</a></div>";
            }
            ValoracionProyecto += "</div>";


            String AudienciaCierre = "";
            if ((yaPasoAudCierre == "0")) //No ha pasado fecha de cierre
            {
                AudienciaCierre += "<div class=\"row itemGAC deshabilitada\">";
                AudienciaCierre += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_1.jpg\"/></span><span>Audiencia de Cierre<br/>" + formato(formato_fecha(fechaAudCierre)) + "</span></div>";
                if (!String.IsNullOrEmpty(fechaAudCierre))
                {
                    AudienciaCierre += "<a href =\"\"><img alt=\"Invitar a la audiencia\" src =\"../../Content/img/FB-f-Logo__blue_29.png\"/></a>";
                    AudienciaCierre += "<a href =\"\"><img alt=\"Invitar a la audiencia\" src =\"../../Content/img/iconEmail.png\"/></a>";
                }
            }
            else if ((String.IsNullOrEmpty(ActaAudCierre)) && (!String.IsNullOrEmpty(auditor)) && (yaPasoAudCierre == "1")) //No hay acta, es auditor y ya ha pasado fecha de Cierre
            {
                AudienciaCierre += "<div class=\"row itemGAC pendiente\">";
                AudienciaCierre += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_1.jpg\"/></span><span>Audiencia de Cierre<br/>" + formato(formato_fecha(fechaAudCierre)) + "</span></div>";
                if (String.IsNullOrEmpty(idEvaAudCierre)) // el usuario no ha evaluado
                {
                    AudienciaCierre += "<div class=\"col-sm-5\"><a onclick=\"javascript:alert(" + "\\'En construccion\\'" + ");\"  role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-eye-open\"></span>Evalúa tu Experiencia</a></div>";
                }
            }
            else if ((String.IsNullOrEmpty(ActaAudCierre)) && (String.IsNullOrEmpty(auditor))) //No hay acta, pero no es auditor
            {
                AudienciaCierre += "<div class=\"row itemGAC pendiente\">";
                AudienciaCierre += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_1.jpg\"/></span><span>Audiencia de Cierre<br/>" + formato(formato_fecha(fechaAudCierre)) + "</span></div>";
            }
            else if ((!String.IsNullOrEmpty(ActaAudCierre)) && (!String.IsNullOrEmpty(auditor))) //Hay acta y es auditor
            {
                AudienciaCierre += "<div class=\"row itemGAC realizada\">";
                AudienciaCierre += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_1.jpg\"/></span><span>Audiencia de Cierre<br/>" + formato(formato_fecha(fechaAudCierre)) + "</span></div>";
                AudienciaCierre += "<div class=\"col-sm-5\"><a onclick=\"javascript:alert(" + "\\'En construccion\\'" + ");\"  role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-eye-open\"></span> Ver Acta</a></div>";
                if (String.IsNullOrEmpty(idEvaAudCierre)) // el usuario no ha evaluado
                {
                    AudienciaCierre += "<div class=\"col-sm-5\"><a onclick=\"javascript:alert(" + "\\'En construccion\\'" + ");\"  role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-eye-open\"></span>Evalúa tu Experiencia</a></div>";
                }
            }
            else if ((!String.IsNullOrEmpty(ActaAudCierre)) && (String.IsNullOrEmpty(auditor))) //Hay acta y no es auditor
            {
                AudienciaCierre += "<div class=\"row itemGAC realizada\">";
                AudienciaCierre += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_1.jpg\"/></span><span>Audiencia de Cierre<br/>" + formato(formato_fecha(fechaAudCierre)) + "</span></div>";
                AudienciaCierre += "<div class=\"col-sm-5\"><a onclick=\"javascript:alert(" + "\\'En construccion\\'" + ");\"  role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-eye-open\"></span> Ver Acta</a></div>";
            }
            else
            {
                AudienciaCierre += "<div class=\"row itemGAC deshabilitada\">";
                AudienciaCierre += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_1.jpg\"/></span><span>Audiencia de Cierre<br/>" + formato(formato_fecha(fechaAudCierre)) + "</span></div>";
            }
            AudienciaCierre += "</div>";

            //String InfAplicativoAudCierre = "";
            //if ((String.IsNullOrEmpty(InformeAudCierre)) && (!String.IsNullOrEmpty(auditor)) && (yaPasoAudCierre == "0")) //No hay informe, es auditor y no ha pasado fecha de Cierre
            //{
            //    InfAplicativoAudCierre += "<div class=\"row itemGAC deshabilitada\">";
            //    InfAplicativoAudCierre += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe del Aplicativo</span></div>";
            //}
            //else if ((String.IsNullOrEmpty(InformeAudCierre)) && (!String.IsNullOrEmpty(auditor)) && (yaPasoAudCierre == "1")) //No hay informe, es auditor y ya ha pasado fecha de Cierre
            //{
            //    InfAplicativoAudCierre += "<div class=\"row itemGAC pendiente\">";
            //    InfAplicativoAudCierre += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe del Aplicativo</span></div>";
            //    InfAplicativoAudCierre += "<div class=\"col-sm-5\"><a onclick=\"javascript:alert(" + "\\'En construccion\\'" + ");\"  role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-file\"></span>Generar Informe</a></div>";

            //}
            //else if ((String.IsNullOrEmpty(InformeAudCierre)) && (String.IsNullOrEmpty(auditor))) //No hay informe, pero no es auditor
            //{
            //    InfAplicativoAudCierre += "<div class=\"row itemGAC deshabilitada\">";
            //    InfAplicativoAudCierre += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe del Aplicativo</span></div>";
            //}
            //else if (!String.IsNullOrEmpty(InformeAudCierre)) //Hay informe
            //{
            //    InfAplicativoAudCierre += "<div class=\"row itemGAC realizada\">";
            //    InfAplicativoAudCierre += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe del Aplicativo</span></div>";
            //    InfAplicativoAudCierre += "<div class=\"col-sm-5\"><a onclick=\"javascript:alert(" + "\\'En construccion\\'" + ");\"  role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-eye-open\"></span> Ver Informe</a></div>";
            //}
            //else
            //{
            //    InfAplicativoAudCierre += "<div class=\"row itemGAC deshabilitada\">";
            //    InfAplicativoAudCierre += "<div class=\"col-sm-7\"><span class=\"gestionIc\"></span><span>Informe del Aplicativo</span></div>";
            //}
            //InfAplicativoAudCierre += "</div>";

            String Evaluacionposterior = "";
            if ((yaPasoAudCierre == "0")) //no ha pasado fecha de Cierre
            {
                Evaluacionposterior += "<div class=\"row itemGAC deshabilitada\">";
                Evaluacionposterior += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_7.jpg\"/></span><span>Evaluación Posterior</span></div>";
            }
            else if ((String.IsNullOrEmpty(EvaluacionP)) && (!String.IsNullOrEmpty(auditor)) && (yaPasoAudCierre == "1")) //No hay evaluacion, es auditor y ya ha pasado fecha de Cierre
            {
                Evaluacionposterior += "<div class=\"row itemGAC pendiente\">";
                Evaluacionposterior += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_7.jpg\"/></span><span>Evaluación Posterior</span></div>";
                Evaluacionposterior += "<div class=\"col-sm-5\"><a onclick=\"javascript:configEvaluacionPosterior(" + "\\'" + bpin_proyecto + "\\'" + "," + "\\'" + id_usuario + "\\'" + ");\" role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-file\"></span>Crear evaluación</a></div>";

            }
            else if ((String.IsNullOrEmpty(EvaluacionP)) && (String.IsNullOrEmpty(auditor))) //No hay evaluacion, pero no es auditor
            {
                Evaluacionposterior += "<div class=\"row itemGAC deshabilitada\">";
                Evaluacionposterior += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_7.jpg\"/></span><span>Evaluación Posterior</span></div>";
            }
            else if (!String.IsNullOrEmpty(EvaluacionP)) //Hay evaluacion
            {
                Evaluacionposterior += "<div class=\"row itemGAC realizada\">";
                Evaluacionposterior += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_7.jpg\"/></span><span>Evaluación Posterior</span></div>";
                Evaluacionposterior += "<div class=\"col-sm-5\"><a onclick=\"javascript:responderEvaluacionPosterior(" + "\\'" + bpin_proyecto + "\\'" + "," + "\\'" + id_usuario + "\\'" + ");\"  role=\"button\" class=\"btn btn-default\"><span class=\"glyphicon glyphicon-file\"></span>Responder evaluación</a></div>";
                Evaluacionposterior += "<a href =\"\"><img alt=\"Invitar a la responder\" src =\"../../Content/img/FB-f-Logo__blue_29.png\"/></a>";
                Evaluacionposterior += "<a href =\"\"><img alt=\"Invitar a la responder\" src =\"../../Content/img/iconEmail.png\"/></a>";
            }
            else
            {
                Evaluacionposterior += "<div class=\"row itemGAC deshabilitada\">";
                Evaluacionposterior += "<div class=\"col-sm-7\"><span class=\"gestionIc\"><img src =\"../../Content/img/icon_gestion_7.jpg\"/></span><span>Evaluación Posterior</span></div>";
            }
            Evaluacionposterior += "</div>";

            BotonesGestion = InfCapacitacion + InfObservaciones + ReunionesPrevias ; //3
            BotonesGestion += AudienciaInicio  + VerificacionAudInicio + InformeProceso; //3
            BotonesGestion += AudienciaSeguimiento   + VerificacionAudSeg + InformeProcesoCierre + ValoracionProyecto; //4
            BotonesGestion += AudienciaCierre  + Evaluacionposterior; //2

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

            String TipoContrato = "";

            if (dtContrato.Rows.Count > 0)
            {
                TipoContrato = formato(dtContrato.Rows[0]["CodTipoCtto"].ToString());
                DetContrato += "<div class=\"col-sm-6\"><h4>Número de contrato</h4>";
                DetContrato += "<div class=\"alert alert-info\">";
                DetContrato += formato(dtContrato.Rows[0]["NumCtto"].ToString());
                DetContrato += "</div>";
                DetContrato += "<div class=\"form-group\"><span class=\"glyphicon glyphicon-info-sign XLtext\"></span>";
                DetContrato += "<span>" + "Número asignado al contrato dentro del proyecto." + "</span>";
                DetContrato += "</div>";
                DetContrato += "</div></div>";
                DetContrato += "<div class=\"col-sm-6\"><h4>Valor contratado</h4>";
                
                DetContrato += "<div class=\"alert alert-info\">";
                DetContrato += formato_moneda(dtContrato.Rows[0]["ValorCtto"].ToString());
                DetContrato += "</div>";
                DetContrato += "<div class=\"form-group\"><span class=\"glyphicon glyphicon-info-sign XLtext\"></span>";
                DetContrato += "<span>" + "Monto de recursos asignados al contrato" + "</span>";
                DetContrato += "</div>";
                DetContrato += "</div></div>";
                DetContrato += "<div class=\"col-sm-12\"><h4>Objeto del contrato</h4>";
                
                DetContrato += "<div class=\"alert alert-info\">";
                DetContrato += formato(dtContrato.Rows[0]["ObjetoCtto"].ToString());
                DetContrato += "</div>";
                DetContrato += "<div class=\"form-group\"><span class=\"glyphicon glyphicon-info-sign XLtext\"></span>";
                DetContrato += "<span>" + "Obligación que adquiere el contratista para ser ejecutado." + "</span>";
                DetContrato += "</div>";
                DetContrato += "</div></div>";
                DetContrato += "<div class=\"col-sm-6\"><h4>Fecha de suscripción</h4>";
                
                DetContrato += "<div class=\"alert alert-info\">";
                DetContrato += formato(formato_fecha(dtContrato.Rows[0]["FechaSuscripcion"].ToString()));
                DetContrato += "</div>";
                DetContrato += "<div class=\"form-group\"><span class=\"glyphicon glyphicon-info-sign XLtext\"></span>";
                DetContrato += "<span>" + "Fecha en la que se firma el contrato." + "</span>";
                DetContrato += "</div>";
                DetContrato += "</div></div>";
                DetContrato += "<div class=\"col-sm-6\"><h4>Fecha de inicio</h4>";
               
                DetContrato += "<div class=\"alert alert-info\">";
                DetContrato += formato(formato_fecha(dtContrato.Rows[0]["FechaInicio"].ToString()));
                DetContrato += "</div>";
                DetContrato += "<div class=\"form-group\"><span class=\"glyphicon glyphicon-info-sign XLtext\"></span>";
                DetContrato += "<span>" + "Fecha en la que comienzan las actividades propuestas en el contrato. " + "</span>";
                DetContrato += "</div>";
                DetContrato += "</div></div>";
                DetContrato += "<div class=\"col-sm-12\"><h4>Modalidad de contratación</h4>";
                
                DetContrato += "<div class=\"alert alert-info\">";
                DetContrato += formato(dtContrato.Rows[0]["NomModalidad"].ToString());
                DetContrato += "</div>";
                DetContrato += "<div class=\"form-group\"><span class=\"glyphicon glyphicon-info-sign XLtext\"></span>";
                DetContrato += "<span>" + "La legislación colombiana contempla variadas formas de seleccionar el contratista. Aquí se describe la modalidad que se aplicó para la contratación de este proyecto. (Licitación pública, concurso de méritos, contratación directa, etc.)" + "</span>";
                DetContrato += "</div>";
                DetContrato += "</div></div>";
            }

            DetContrato += "<div class=\"col-sm-12\"><h4>Contratista seleccionado</h4>";
            
            if (dtContrato.Rows.Count > 0)
            {
                DetContrato += "<div class=\"alert alert-info\">";
                DetContrato += "Nombre: " + formato(dtContrato.Rows[0]["NombresCttista"].ToString()) + "<br>";
                DetContrato += "Rep. Legal: " + formato(dtContrato.Rows[0]["NombreRepLegalCttista"].ToString()) + "<br>";
                DetContrato += "Nit: " + formato(dtContrato.Rows[0]["NitCttista"].ToString()) + "<br>";
                DetContrato += "Telefono: " + formato(dtContrato.Rows[0]["Telefono"].ToString()) + "<br>";
                DetContrato += "Correo: " + formato(dtContrato.Rows[0]["Email"].ToString()) + "<br>";
                DetContrato += "</div>";
            }
            DetContrato += "</div>";
            DetContrato += "<div class=\"form-group\"><span class=\"glyphicon glyphicon-info-sign XLtext\"></span>";
            DetContrato += "<span>" + "Muestra la información básica de la persona natural o jurídica seleccionada para ejecutar el contrato." + "</span>";
            DetContrato += "</div>";

            if (TipoContrato!="13")
            {

                DetContrato += "<div class=\"col-sm-6\"><h4>Interventor </h4>";
                
                if (dtInterventor.Rows.Count > 0)
                {
                    DetContrato += "<div class=\"alert alert-info\">";
                    DetContrato += "Nombre: " + formato(dtInterventor.Rows[0]["NomInterventor"].ToString()) + "<br>";
                    DetContrato += "Rep. Legal: " + formato(dtInterventor.Rows[0]["NomRepLegalInterventor"].ToString()) + "<br>";
                    DetContrato += "Nit: " + formato(dtInterventor.Rows[0]["NitInterventor"].ToString()) + "<br>";
                    DetContrato += "Telefono: " + formato(dtInterventor.Rows[0]["Telefono"].ToString()) + "<br>";
                    DetContrato += "Correo: " + formato(dtInterventor.Rows[0]["Email"].ToString()) + "<br>";
                    DetContrato += "</div>";
                }
                else
                {
                    DetContrato += "<div class=\"alert alert-info\"><p>Información no incluida en el Sistema por parte de Entidad Ejecutora</p></div>";
                }
                DetContrato += "<div class=\"form-group\"><span class=\"glyphicon glyphicon-info-sign XLtext\"></span>";
                DetContrato += "<span>" + "Es la persona o firma externa, encargada de realizar la verificación del cumplimiento del contrato." + "</span>";
                DetContrato += "</div>";
                
                DetContrato += "</div>";
            }

            DetContrato += "<div class=\"col-sm-6\"><h4>Supervisor designado</h4>";
            

            if (dtSupervisor.Rows.Count > 0)
            {
                DetContrato += "<div class=\"alert alert-info\">";
                DetContrato += "Nombre: " + formato(dtSupervisor.Rows[0]["NomSupervisor"].ToString()) + "<br>";
                DetContrato += "Nit: " + formato(dtSupervisor.Rows[0]["NitSupervisor"].ToString()) + "<br>";
                DetContrato += "Dependencia: " + formato(dtSupervisor.Rows[0]["NomDependencia"].ToString()) + "<br>";
                DetContrato += "Cargo: " + formato(dtSupervisor.Rows[0]["NomCargo"].ToString()) + "<br>";
                DetContrato += "Telefono: " + formato(dtSupervisor.Rows[0]["Telefono"].ToString()) + "<br>";
                DetContrato += "Correo: " + formato(dtSupervisor.Rows[0]["Email"].ToString()) + "<br>";
                DetContrato += "</div>";
            }
            else
            {
                DetContrato += "<div class=\"alert alert-info\"><p>Información no incluida en el Sistema por parte de Entidad Ejecutora</p></div>";
            }
            DetContrato += "<div class=\"form-group\"><span class=\"glyphicon glyphicon-info-sign XLtext\"></span>";
            DetContrato += "<span>" + "Se encuentran los datos del funcionario de la entidad ejecutora, encargado de hacer seguimiento y verificar el cumplimiento de las obligaciones del Contratista e Interventor y que se alcancen los productos previstos en el proyecto" + "</span>";
            DetContrato += "</div>";
            DetContrato += "</div>";


            //DetContrato += "<div class=\"col-sm-12\"><h4>Actividades del contrato</h4>";
           
            //if (dtActividades.Rows.Count > 0)
            //{
            //    DetContrato += "<div class=\"table-responsive\"><table class=\"table table-hover table-striped\"><thead><tr><th>Nombre</th><th>Fecha Ejecución</th><th>Cantidad Ejecutado</th></tr></thead><tbody>";
            //    for (int i = 0; i <= dtActividades.Rows.Count - 1; i++)
            //    {
            //        DetContrato += "<tr>";
            //        DetContrato += "<td>" + formato(dtActividades.Rows[i]["NomActividadCon"].ToString()) + "</td>";
            //        DetContrato += "<td>" + formato(formato_fecha(dtActividades.Rows[i]["FechaEje"].ToString())) + "</td>";
            //        DetContrato += "<td>" + formato_miles(dtActividades.Rows[i]["CantidadEje"].ToString()) + "</td>";
            //        DetContrato += "</tr>";
            //    }
            //    DetContrato += "</tbody></table></div>";
            //}
            //DetContrato += "<div class=\"form-group\"><span class=\"glyphicon glyphicon-info-sign XLtext\"></span>";
            //DetContrato += "<span>" + "Son las actividades previstas para cumplir con el objeto del contrato. Debe verificarse su coherencia con el aporte a lo que se espera alcanzar con el proyecto." + "</span>";
            //DetContrato += "</div>";
            //DetContrato += "</div>";
            DetContrato += "<div class=\"col-sm-12\"><h4>Información general de pólizas y garantías</h4>";
            
            DetContrato += "<div class=\"alert alert-info\"><p>";
            if (dtPoliza.Rows.Count > 0)
            {
                
                for (int i = 0; i <= dtPoliza.Rows.Count - 1; i++)
                {
                    DetContrato += "<br><b>" + formato(dtPoliza.Rows[i]["nomTipoAmparo"].ToString()) + "</b>. Aseguradora: " + dtPoliza.Rows[i]["nombreAseguradora"].ToString() + ". Número de Amparo: " + dtPoliza.Rows[i]["numeroAmparo"].ToString() + ". Beneficiario: " + dtPoliza.Rows[i]["beneficiario"].ToString() + ". Tomador: " + dtPoliza.Rows[i]["tomador"].ToString() + ". Número de cubrimientos: " + dtPoliza.Rows[i]["numeroCubrimientos"].ToString() + ". Fecha Expedición: " + dtPoliza.Rows[i]["fechaExpedicion"].ToString() + ". Número de Aprobación: " + dtPoliza.Rows[i]["NumAprobacion"].ToString() + ". Fecha Documento de Aprobación: " + dtPoliza.Rows[i]["FechaDocAprobacion"].ToString() + ". - ";
                }

            }
            //falta programación
            DetContrato += "</p></div>";

            DetContrato += "<div id =\"divPolizaDet\" class=\"btn btn-default hideObj\">";
            DetContrato += "<a role =\"button\" id=\"divPolizaDocumento\">";
            DetContrato += "<span class=\"glyphicon glyphicon-save-file\"></span>VER DOCUMENTO</a>";
            DetContrato += "</div>";
            DetContrato += "<div class=\"form-group\"><span class=\"glyphicon glyphicon-info-sign XLtext\"></span>";
            DetContrato += "<span>" + "Se describe(n) la (s) póliza (s) de garantía(s) que ampara(n) la ejecución y cumplimiento del contrato" + "</span>";
            DetContrato += "</div>";
            DetContrato += "</div>";

            DetContrato += "<div class=\"col-sm-12\"><h4>Modificación al contrato</h4>";
            

            if (dtModificaciones.Rows.Count > 0)
            {
                DetContrato += "<div class=\"table-responsive\"><table class=\"table table-hover table-striped\"><thead><tr><th>Modificación</th><th>Fecha</th><th>Unidad</th><th>Cantidad</th><th>Valor</th></tr></thead><tbody>";

                for (int i = 0; i <= dtModificaciones.Rows.Count - 1; i++)
                {
                    DetContrato += "<tr>";
                    DetContrato += "<td>" + formato(dtModificaciones.Rows[i]["NomTipoModificacion"].ToString()) + "</td>";
                    DetContrato += "<td>" + formato(formato_fecha(dtModificaciones.Rows[i]["FechaModificacion"].ToString())) + "</td>";
                    DetContrato += "<td>" + formato(dtModificaciones.Rows[i]["UnidadTiempoModif"].ToString()) + "</td>";
                    DetContrato += "<td>" + formato(dtModificaciones.Rows[i]["CantidadTiempoModif"].ToString()) + "</td>";
                    DetContrato += "<td>" + formato_moneda(dtModificaciones.Rows[i]["ValorModif"].ToString()) + "</td>";
                    DetContrato += "</tr>";
                }
                DetContrato += "</tbody></table></div>";

            }
            DetContrato += "<div class=\"form-group\"><span class=\"glyphicon glyphicon-info-sign XLtext\"></span>";
            DetContrato += "<span>" + "Se muestran las modificaciones realizadas a los contratos en términos de tiempos, recursos y demás ajustes contractuales" + "</span>";
            DetContrato += "</div>";
            DetContrato += "</div>";

            outTxt += "$(\"#divDetContrato\").html('" + DetContrato + "');";

            return outTxt;

        }

        public DataTable listarProyectos()
        {
            DataTable dtInfo = new DataTable();
            DataTable dt_aux = new DataTable("proyectos");
            dt_aux.Columns.Add("id", typeof(String));
            dt_aux.Columns.Add("nom_proyecto", typeof(String));
            List<DataTable> list_proyectos = Models.clsProyectos.listarProyectosAll();
            dtInfo = list_proyectos[0];
            foreach (DataRow fila in dtInfo.Rows)
            {
                DataRow fila_aux = dt_aux.NewRow();
                fila_aux["id"] = fila["CodigoBPIN"].ToString();
                fila_aux["nom_proyecto"] = fila["CodigoBPIN"].ToString() + "-" + fila["OBJETO"].ToString();
                dt_aux.Rows.Add(fila_aux);
            }
            return dt_aux;
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
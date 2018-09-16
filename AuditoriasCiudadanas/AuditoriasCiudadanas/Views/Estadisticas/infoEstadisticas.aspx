<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="infoEstadisticas.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Estadisticas.infoEstadisticas" %>
<div class="container">
     <input type="hidden" id="hdIdUsuario" runat="server" />
    <div id="divEncabezadoEstadis" class="row">
        <div class="headSection">
            <div id="divPin" class="col-sm-12 headTit mt20">
                <span>ESTADÍSTICAS</span>
             </div>
        </div>
    </div>
    <div id="divCuerpoEstadis" class="row">
        <div class="col-sm-3">
            <div class="row form-group">
                <div class="leftMenu" id="divOpcionesInfo">
                        <!--TABS-->
                        <ul class="nav nav-tabs nav-stacked" id="opcionesInfo">
                            <li id="itemCaracterizacion" class="active"><a id="enlaceCaracterizacion" data-toggle="tab" href="#divCaracterizacion">Caracterización <span class="glyphicon glyphicon-menu-right"></span></a></li>
                            <li id="itemProyecto"><a id="enlaceProyecto" data-toggle="tab" href="#divProyecto">Acceso a la Información <span class="glyphicon glyphicon-menu-right"></span></a></li>
                            <li id="itemCapacitacion"><a id="enlaceCapacitacion" data-toggle="tab" href="#divCapacitacion">Capacitación <span class="glyphicon glyphicon-menu-right"></span></a></li>
                            <li id="itemGAC"><a id="enlaceGAC" data-toggle="tab" href="#divGAC">Grupos Auditores Ciudadanos <span class="glyphicon glyphicon-menu-right"></span></a></li>
                            <li id="itemAudiencias"><a id="enlaceAudiencias" data-toggle="tab" href="#divAudiencias">Audiencias <span class="glyphicon glyphicon-menu-right"></span></a></li>
                            <li id="itemVerificacion"><a id="enlaceVerificacion" data-toggle="tab" href="#divVerificacion">Verificación <span class="glyphicon glyphicon-menu-right"></span></a></li>
<%--                            <li id="itemValoracion"><a id="enlaceValoracion" data-toggle="tab" href="#divValoracion">Valoración <span class="glyphicon glyphicon-menu-right"></span></a></li>
                            <li id="itemIncentivos"><a id="enlaceIncentivos" data-toggle="tab" href="#divIncentivos">Incentivos <span class="glyphicon glyphicon-menu-right"></span></a></li>--%>
                            <li id="itemReportes"><a id="enlaceReportes" data-toggle="tab" href="#divReportes">Informes <span class="glyphicon glyphicon-menu-right"></span></a></li>
                        </ul>
                 </div>
            </div>
        </div>
        <div class="col-sm-9">
            <div class="generalInfo">
                <div id="divDetalleProyecto" class="tab-content responsive" runat="server">
                    <!--CONTENT1 GENERAL INFO-->
                    <div id="divCaracterizacion" class="tab-pane fade in active">
                        <h2>Caracterización </h2>
                        <div class="col-sm-12">
                            <h4>Número de grupos auditores por Localización </h4>
                            
                            <div id="divGacXLocal" runat="server" class="alert alert-info"></div>
                        </div>
                        <div class="col-sm-12">
                            <h4>Número de auditores por Localización</h4>
                            
                            <div id="divAudXLocal" runat="server" class="alert alert-info"></div>
                            <br /><br />
                        </div>
                     
                    </div>
                    <!--CONTENT4 Formulación y Aprobación-->
                    <div id="divProyecto" class="tab-pane fade">
                        <h2>Acceso a la información</h2>
                        <div class="col-sm-12">
                            <h4>Número de proyectos con GAC conformado</h4>
                            
                            <div id="divProyectosGac"   class="alert alert-info" runat="server">
                            </div>
                        </div>
                    </div>
                    
                           
                    <!--CONTENT3 Financiación y Presupuesto-->
                    <div id="divCapacitacion" class="tab-pane fade">
                        <h2>Capacitación</h2>
                        <p>Estadísticas de capacitación.</p>
                        <div class="col-sm-12">
                            <h4>Personas Capacitadas por categoria </h4>
                            <div id="divPerCapacitadas"  class="alert alert-info" runat="server">
                            </div>
                        </div>
                        <div class="col-sm-12">
                            <h4>Nivel de capacitación realizado por Regiones</h4>
                            <div id="divNivelCap"  class="alert alert-info" runat="server">
                            </div>
                        </div>
                    </div>
                    <!--CONTENT2 GAC-->
                    <div id="divGAC" class="tab-pane fade">
                        <h2>Grupos auditores ciudadanos </h2>

                         <div class="col-sm-12">
                            <h4>Miembros GAC registrados</h4>
                            
                            <div id="divGACXTiempo"  class="alert alert-info" runat="server">
                            </div>
                        </div>
                    </div>
                    <!--CONTENT5 Planeación y Aprobación-->
                    <div id="divAudiencias" class="tab-pane fade">
        <h2>Audiencias</h2>
        <!--Descripción-->
        <div class="col-sm-12">
            <h4>Proyectos con audiencias realizadas </h4>
            <div id="divProyectosAud"  class="alert alert-info" runat="server">
            </div>
        </div>
        <!--Documento de planeación-->
        <div class="col-sm-12">
                <h4>Cantidad de asistentes a audiencias </h4>
                <div id="divAsistentes"  class="alert alert-info" runat="server">
            </div>
        </div>
       
    </div>
    <!--CONTENT Verificacion-->
    <div id="divVerificacion" class="tab-pane fade">
        <h2>Verificación</h2>
        <div class="col-sm-12">
                <h4>Cantidad de hallazgos </h4>
                <div id="divHallazgos"  class="alert alert-info" runat="server">
            </div>
        </div>
        </div>
        <!--CONTENT Valoracion-->
        <div id="divValoracion" class="hideObj">
            <input type="hidden" id="hd_infoTecnica" runat="server" value="" />
            <h2>Valoración </h2>
            
            <div class="col-sm-12">
                    <h4>Nivel de satisfacción – autoevaluación </h4>
                    <div id="divSatisfaccion"  class="alert alert-info" runat="server">
                </div>
            </div>
            <div class="col-sm-12">
                    <h4>Número de evaluaciones a proyectos programadas  </h4>
                    <div id="divEvaluaciones"  class="alert alert-info" runat="server">
                </div>
            </div>
        </div>
        <!--CONTENT Incentivos-->
        <div id="divIncentivos" class="tab-pane fade">
          <h2>Incentivos </h2>
        </div>
        <div id="divReportes" class="tab-pane fade">
             <h2>Reportes Descargables </h2>
            <div class="col-sm-12">
                <div id="divDetReportes">
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="ddlCategoria" class="required">Categoría</label>
                                <!-- departamento-->
                                <asp:dropdownlist id="ddlCategoria" class="form-control" runat="server" datatextfield="nom_grupo" datavaluefield="id_grupo_estadistica" tooltip="--Categoría--">
                                </asp:dropdownlist>
                                <div id="error_ddlCategoria" class="alert alert-danger alert-dismissible" hidden="hidden">Categoría no puede ser vacía</div>
                            </div>

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label for="ddlTipoReporte" class="required">Tipo Reporte</label>
                                <!-- departamento-->
                                <asp:dropdownlist id="ddlTipoReporte" style="width:550px" class="form-control" runat="server" datatextfield="nom_tipo_estadistica" datavaluefield="id_tipo_estadistica" tooltip="--Tipo--">
                                </asp:dropdownlist>
                                <div id="error_ddlTipoReporte" class="alert alert-danger alert-dismissible" hidden="hidden">Tipo reporte no puede ser vacío</div>
                            </div>
                            
                        </div>
                    </div>
                    <div class="form-group row" id="divFechas">
                        <div class="col-sm-5">
                            <label for="FechaInicioCorte" class="control-label">Fecha Inicio:</label>
                            <div class="input-group date form_date datetimepicker" data-date="" data-date-format="dd/MM/yyyy" data-link-field="FechaInicioCorte" data-link-format="dd/mm/yyyy">
                                <input id="dtpFechaInicio" class="form-control" size="16" type="text" value="" readonly>
                                <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                                <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                            </div>
                            <input type="hidden" id="FechaInicioCorte" value="" />
                        </div>
                        <div class="col-sm-5">
                            <label for="FechaFinCorte" class="control-label">Fecha Fin:</label>
                            <div class="input-group date form_date datetimepicker" data-date="" data-date-format="dd/MM/yyyy" data-link-field="FechaFinCorte" data-link-format="dd/mm/yyyy">
                                <input id="dtpFechaFin" class="form-control" size="16" type="text" value="" readonly>
                                <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                                <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                            </div>
                            <input type="hidden" id="FechaFinCorte" value="" />
                        </div>

                    </div>
                    <div class="row text-center">
                        <div class="col-sm-6">
                                <div class="input-group btn btn-primary" onclick="javascript:ObtenerReporteEstadisticas();">Generar</div>
                        </div>
                            
   
                    </div>
                </div>
            </div>
        </div>

     </div>
   </div>
  </div>
 </div>
</div> 
<div id="divOtros">

</div>                           
    <!-- /.container -->
<script type="text/javascript">
    if ($(document).ready(function () {
        $.getScript('../../Scripts/EstadisticasFunciones.js', function () {
           $.getScript('../../Scripts/EstadisticasAcciones.js', function () {
               $("#divFechas").hide();
        });
    });
}));
</script>
<script type="text/javascript">
    $('ul.nav.nav-tabs  a').click(function (e) {
        e.preventDefault();
        $(this).tab('show');
    });

    (function ($) {
        // Test for making sure event are maintained
        fakewaffle.responsiveTabs(['xs', 'sm']);
    })(jQuery);

    $(document).ready(function () {

        (function ($) {

            $('#filter').keyup(function () {

                var rex = new RegExp($(this).val(), 'i');
                $('.searchable tr').hide();
                $('.searchable tr').filter(function () {
                    return rex.test($(this).text());
                }).show();

            })

        }(jQuery));
        (function ($) {

            $('#filter2').keyup(function () {

                var rex = new RegExp($(this).val(), 'i');
                $('.searchable2 tr').hide();
                $('.searchable2 tr').filter(function () {
                    return rex.test($(this).text());
                }).show();

            })

        }(jQuery));
        (function ($) {

            $('#filter3').keyup(function () {

                var rex = new RegExp($(this).val(), 'i');
                $('.searchable3 tr').hide();
                $('.searchable3 tr').filter(function () {
                    return rex.test($(this).text());
                }).show();

            })

        }(jQuery));
        (function ($) {

            $('#filter4').keyup(function () {

                var rex = new RegExp($(this).val(), 'i');
                $('.searchable4 tr').hide();
                $('.searchable4 tr').filter(function () {
                    return rex.test($(this).text());
                }).show();

            })

        }(jQuery));
        (function ($) {

            $('#filter5').keyup(function () {

                var rex = new RegExp($(this).val(), 'i');
                $('.searchable5 tr').hide();
                $('.searchable5 tr').filter(function () {
                    return rex.test($(this).text());
                }).show();

            })

        }(jQuery));
    });

   </script>
<script type="text/javascript">
    $('.form_datetime').datetimepicker({
        language: 'es',
        weekStart: 1,
        todayBtn: 1,
        autoclose: 1,
        todayHighlight: 1,
        startView: 2,
        forceParse: 0,
        showMeridian: 1
    });
    $('.form_date').datetimepicker({
        language: 'es',
        weekStart: 1,
        todayBtn: 1,
        autoclose: 1,
        todayHighlight: 1,
        startView: 2,
        minView: 2,
        forceParse: 0
    });
    $('.form_time').datetimepicker({
        language: 'es',
        weekStart: 1,
        todayBtn: 1,
        autoclose: 1,
        todayHighlight: 1,
        startView: 1,
        minView: 0,
        maxView: 1,
        forceParse: 0
    });
</script>
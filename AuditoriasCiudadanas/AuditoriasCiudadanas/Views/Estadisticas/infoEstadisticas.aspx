<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="infoEstadisticas.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Estadisticas.infoEstadisticas" %>
<%-- <!-- MIGA DE PAN -->
    <div class="container">
    	<div class="row">
    	<ol class="breadcrumb">
          <li><a href="#">Inicio</a></li>
          <li><a href="#">Estadísticas</a></li>
          <li class="active">Estadísticas</li>
        </ol>
        </div>
    </div>--%>
 <!-- Page Content -->
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
<%--                            <div id="divGacXLocal_help" class="form-group">
                                <span class="glyphicon glyphicon-info-sign XLtext"></span>
                                <span>Número de grupos auditores por Localización .</span>
                            </div>--%>
                        </div>
                        <div class="col-sm-12">
                            <h4>Número de auditores por Localización</h4>
                            
                            <div id="divAudXLocal" runat="server" class="alert alert-info"></div>
<%--                            <div id="divAudXLocal_help" class="form-group">
                                <span class="glyphicon glyphicon-info-sign XLtext"></span>
                                <span>Número de auditores por Localización</span>
                            </div>--%>
                            <br /><br />
                        </div>
                        <!--sector al que apunta-->
                        <%--    <div class="col-sm-12">
                                <h4>Sector al que apunta</h4>
                             
                                <div id="divSectorDet" runat="server" class="alert alert-info"></div>
                                <div id="divSectorDet_help" class="form-group">
                                    <span class="glyphicon glyphicon-info-sign XLtext"></span>
                                    <span>Clasificación de la inversión a partir de su principal objeto, por ejemplo: educación, salud, transporte, entre otros. Para regalías no hay ninguna restricción de inversión.</span>
                                </div>
                            </div>
                            <!--LOCALIZACION-->
                            <div class="col-sm-12">
                                <h4>Localización</h4> 
                             
                                <div id="divLocalizacionDet" runat="server" class="alert alert-info"></div>
                                <div id="divLocalizacionDet_help" class="form-group">
                                    <span class="glyphicon glyphicon-info-sign XLtext"></span>
                                    <span>Lugar en cual se ubica la ejecución del proyecto, por ejemplo: Vereda, municipio, departamento.</span>
                                </div>
                            </div>
                            <!--BENEFICIARIOS-->
                            <div class="col-sm-12">
                                <h4>Beneficiarios</h4>
                             
                                <div id="divBeneficiarios" runat="server" class="alert alert-info"></div>
                                <div id="divBeneficiarios_help" class="form-group">
                                    <span class="glyphicon glyphicon-info-sign XLtext"></span>
                                    <span>En la formulación del proyecto se identifica quiénes harán uso del proyecto después de su ejecución. Los beneficiarios pueden ser, por ejemplo: número de personas, familia, estudiantes, entre otros.</span>
                                </div>
                        </div>
                        <!--ENTIDAD-->

                        <div class="col-sm-12">
                            <h4>Entidad ejecutora de los recursos</h4>
                            
                            <div id="divEntidadEjecDet" runat="server" class="alert alert-info"></div>
                            <div id="divEntidadEjecDet_help" class="form-group">
                                <span class="glyphicon glyphicon-info-sign XLtext"></span>
                                <span>Entidad responsable de la contratación de los recursos y de la entrega de los bienes y servicios, producto de la ejecución proyectos.</span>
                            </div>

                        </div>
                        <!--PRODUCTOS DEL PROYECTO-->
                        <div class="col-sm-12">
                            <h4>Productos del proyecto</h4>
                             
                            <div id="divProductosDet" runat="server" class="alert alert-info"></div>
                            <div id="divProductosDet_help" class="form-group">
                                <span class="glyphicon glyphicon-info-sign XLtext"></span>
                                <span>Bienes y servicios generados a partir de la ejecución del proyecto, por ejemplo: Kilometros de carretera construidas, número de aulas construidas, etc.</span>
                            </div>
                        </div>--%>
                       
                    </div>
                    <!--CONTENT4 Formulación y Aprobación-->
                    <div id="divProyecto" class="tab-pane fade">
                        <h2>Acceso a la información</h2>
                        <!--fecha y OCAD-->
<%--                        <div id="divProyecto_help" class="form-group">
                           <p>Esta pestaña resume la información estadística relacionada con la visualizacion de información de proyectos, entre otros aspectos.
                            </p>
                        </div>--%>
                       
                        <%--<div class="col-sm-12">
                            <h4>Número de veces que la información del proyecto ha sido visualizada por ciudadanos</h4>
                            <div id="divFechaOcadDet" runat="server" class="alert alert-info"></div>
                            <div id="divFechaOcadDet_help" class="form-group">
                                <span class="glyphicon glyphicon-info-sign XLtext"></span><span>o	Número de veces que la información del proyecto ha sido visualizada por ciudadanos.</span></div>

                        </div>
                        <!--Acta OCAD-->
                        <div class="col-sm-12">
                            <h4>Número de usuarios para los perfiles registrados </h4>
                            <div id="divNumActaOcad" runat="server" class="alert alert-info"></div>
                            <div id="divNumActaOcad_help" class="form-group">
                                <span class="glyphicon glyphicon-info-sign XLtext"></span><span>Número de usuarios para los perfiles registrados.</span></div>
                            
                        </div>--%>
                        <div class="col-sm-12">
                            <h4>Número de proyectos con GAC conformado</h4>
                            
                            <div id="divProyectosGac"   class="alert alert-info" runat="server">
                            </div>
<%--                            <div id="divProyectosGac_help" class="form-group">
                                <span class="glyphicon glyphicon-info-sign XLtext"></span>
                                <span>o	Número de proyectos con GAC conformado.</span>
                            </div>--%>
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
                            <h4>Nivel de capacitación</h4>
                            <div id="divNivelCap"  class="alert alert-info" runat="server">
                            </div>
                        </div>
                        <%--<div class="col-sm-12">
                            <h4>Fuentes de financiación del proyecto</h4>
                            <div class="table-responsive" id="divPresupuestoDet"> </div>
                            <div id="divPresupuestoDet_help" class="form-group">
                                <span class="glyphicon glyphicon-info-sign XLtext"></span>
                                <span>Contiene información de todas las fuentes que financian el proyecto.</span>
                            </div>
                        </div>
                        <div class="col-sm-12">
                            <h4>Ejecución física y financiera</h4>
                            <div class="table-responsive" id="divEjecucionDet"> </div>
                            <div id="divEjecucionDet_help" class="form-group">
                                <span class="glyphicon glyphicon-info-sign XLtext"></span>
                                <span>Contiene información del porcentaje de ejecución física y financiera del proyecto.</span>
                            </div>
                        </div>
                        <!--MODIFICACIONES AL PRESUPUESTO-->
                       <div class="col-sm-12">
                            <h4>Pagos del contrato</h4>
                             <div id="divPagosContrato_help" class="form-group">
                                <span class="glyphicon glyphicon-info-sign XLtext"></span>
                                <span>Pagos que se han efectuado a los contratistas (sea Contratos de bienes y/o servicios o del Interventor) destacando la fuente de financiación de la cual se hace el desembolso.</span>
                            </div>
                            <div class="table-responsive" id="divPagosContrato">
                            </div>
                        </div>--%>
                    </div>
                    <!--CONTENT2 GAC-->
                    <div id="divGAC" class="tab-pane fade">
                        <h2>Grupos auditores ciudadanos </h2>

                         <div class="col-sm-12">
                            <h4>Miembros GAC registrados</h4>
                            
                            <div id="divGACXTiempo"  class="alert alert-info" runat="server">
                            </div>
<%--                            <div id="divGACXTiempo_help" class="form-group">
                                <span class="glyphicon glyphicon-info-sign XLtext"></span>
                                <span>o	Miembros GAC registrados.</span>
                            </div>--%>
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
<%--        <div id="divVerifiacion_help">
            <p>Estadísticas de verificación.</p>
        </div>--%>
        <div class="col-sm-12">
                <h4>Cantidad de hallazgos </h4>
                <div id="divHallazgos"  class="alert alert-info" runat="server">
            </div>
        </div>
        <%--<div class="col-sm-12">
                <h4>o	Cantidad de hallazgos </h4>
                <div id="div1" runat="server">
            </div>
        </div>--%>
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
                <%--<div class="col-sm-12">
                    <h4>Cantidad de auditores por rango de evaluación </h4>
                    <div id="div1" runat="server">
                </div>
            </div>--%>
            <div class="col-sm-12">
                    <h4>Número de evaluaciones a proyectos programadas  </h4>
                    <div id="divEvaluaciones"  class="alert alert-info" runat="server">
                </div>
            </div>
        </div>
        <!--CONTENT Incentivos-->
        <div id="divIncentivos" class="tab-pane fade">
          <h2>Incentivos </h2>
            <%--<div class="col-sm-12">
               <h4>Cantidad de auditores por rango de evaluación </h4>
                <div id="div1" runat="server">
            </div>
        </div>--%>


        </div>

     </div>
   </div>
  </div>
 </div>
                         
    <div id="divModalAviso">
        <button id="btnOpenModal" type="button" class="btn btn-info btn-lg hideObj" data-toggle="modal" data-target="#myModalGAC"></button>
        <div class="modal fade" id="myModalGAC" role="dialog">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">PARTICIPAR EN UN GAC</h4>
                    </div>
                    <div class="modal-body">
                        <p>Participar en un Grupo Auditor Ciudadano (GAC) le permite interactuar y colaborar en el trabajo de otros auditores ciudadanos que están vigilando el proyecto de su interés.</p>
                        <p>Además, como miembro de un GAC, tendrá acceso a información del proyecto y a herramientas y formatos para realizar un ejercicio efectivo de control social.</p>
                        <p>En esta sección usted podrá crear o unirse a un GAC que actualmente vigile este proyecto</p>
                        <p>Para mayor información sobre qué hace un GAC,  puede remitirse a la Cartilla Auditorías Ciudadanas una forma de vigilar las Regalías<a href="#"> (Ver) </a></p>
                        
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Aceptar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>                            
    <!-- /.container -->
<script type="text/javascript">
    if ($(document).ready(function () {
        $.getScript('../../Scripts/ProyectosFunciones.js', function () {
           $.getScript('../../Scripts/ProyectosAcciones.js', function () {
            var id_proyecto = $("#hfidproyecto").val();
            var id_usuario = $("#hdIdUsuario").val();
            if (id_usuario == "") {
              $("#btnOpenModal").trigger("click");
            }
            verDetalleProyecto(id_proyecto, id_usuario);
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
        $('.js-alert-test').click(function () {
            bootbox.alert('Button Clicked: Event was maintained');
        });
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
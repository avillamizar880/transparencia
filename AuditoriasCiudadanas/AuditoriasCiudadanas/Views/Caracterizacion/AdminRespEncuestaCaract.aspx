<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminRespEncuestaCaract.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Caracterizacion.AdminRespEncuestaCaract" %>
<div class="container">
    	<div class="row">
    	<ol class="breadcrumb">
          <li><a role="button" onclick="cargaMenu('AccesoInformacion/BuscadorProyectosAuditores','dvPrincipal')">Inicio</a></li>
          <li><a role="button" onclick="cargaMenu('Caracterizacion/AdminEncuestaCaractCorte','dvPrincipal')">Corte encuestas caracterización</a></li>
          <li class="active">Detalle encuestas</li>
        </ol>
        </div>
    </div>
<div class="container" id="detalleBuscarEncuesta">
    <input type="hidden" id="hdIdUsuario" runat="server" />
    <input type="hidden" id="hdFechaIni" runat="server" />
    <input type="hidden" id="hdFechaFin" runat="server" />
    <div id="divEncabezadoEstadis" class="row">
        <div class="headSection">
            <div id="divPin" class="col-sm-12 headTit">
                <span>CORTE INFORMACIÓN ENCUESTA CARACTERIZACIÓN</span>
            </div>
        </div>
    </div>
    <div id="divCuerpoEstadis" class="row">
        <div class="col-sm-3">
            <div class="row form-group">
                <div class="leftMenu" id="divOpcionesInfo">
                    <!--TABS-->
                    <ul class="nav nav-tabs nav-stacked" id="opcionesInfo">
                        <li id="itemCaracterizacion1" class="active"><a id="enlaceCaracterizacion1" data-toggle="tab" href="#divCaracterizacion1">Información básica <span class="glyphicon glyphicon-menu-right"></span></a></li>
                        <li id="itemCaracterizacion2"><a id="enlaceCaracterizacion2" data-toggle="tab" href="#divCaracterizacion2">Condiciones de participación <span class="glyphicon glyphicon-menu-right"></span></a></li>
                        <li id="itemCaracterizacion3"><a id="enlaceCaracterizacion3" data-toggle="tab" href="#divCaracterizacion3">Instrumentos y herramientas <span class="glyphicon glyphicon-menu-right"></span></a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="col-sm-9">
            <div class="generalInfo">
                <div id="divDetalleProyecto" class="tab-content responsive" runat="server">
                <!--CONTENT1 Información general encuesta de caracterización-->
                    <div id="divCaracterizacion1" class="tab-pane fade in active">
                    <h2>Parte 1</h2>
                    <div class="col-sm-12">
                        <h4>Información básica del usuario registrado en el sistema</h4>
                        <div id="div2" runat="server" class="alert alert-info">
                        <%--INICIO DE LA TABLA--%>
                       <div class="input-group"> <span class="input-group-addon">Filtro</span>
                        <input id ="filter" type="text" class="form-control" placeholder="Filtre por alguno de los campos de la tabla">
                        </div>
                <div class="table-responsive">
                    <table id="infoGeneralEnc" class="table table-hover table-striped">
                    </table>
                </div>
           <%-- FIN DE LA TABLA--%>
             </div>
             <div id="divGacXLocal_help2" class="form-group">
                <span class="glyphicon glyphicon-info-sign XLtext"></span>
                <span>Información básica del usuario registrado en el sistema al corte seleccionado.</span>
             </div>
          </div>
                    <br />
                    <br />
                </div>
                      <!--CONTENT2 Información encuesta de caracterización 2-->
                    <div id="divCaracterizacion2" class="tab-pane fade">
                        <h2>Parte 2</h2>
                         <div class="col-sm-12">
                            <h4>Condiciones de participación en el municipio del auditor ciudadano</h4>
                            <div id="divGACXTiempo"  class="alert alert-info" runat="server">
                             <div class="input-group"> <span class="input-group-addon">Filtro</span>
                                <input id ="filter2" type="text" class="form-control" placeholder="Filtre por alguno de los campos de la tabla">
                            </div>
                <%--INICIO DE LA TABLA--%>
                <div class="table-responsive">
                <table id="MecanismosParticipacion" class="table table-hover table-striped">
                </table>
            </div>
            <%--FIN DE LA TABLA--%>
                            </div>
                            <div id="divGACXTiempo_help" class="form-group">
                                <span class="glyphicon glyphicon-info-sign XLtext"></span>
                                <span>Información que muestra las condiciones de participación en el municipio del auditor ciudadano.</span>
                            </div>
                        </div>
                    </div>
                    <div id="divCaracterizacion3" class="tab-pane fade">
                        <h2>Parte 3</h2>
                         <div class="col-sm-12">
                            <h4>Instrumentos y herramientas para el ejercicio de participación</h4>
                            <div id="div3"  class="alert alert-info" runat="server">
                                 <div class="input-group"> <span class="input-group-addon">Filtro</span>
                                    <input id ="filter3" type="text" class="form-control" placeholder="Filtre por Departamento o Municipio">
                            </div>
                <div class="table-responsive">
                <table id="estrategias" class="table table-hover table-striped">
                </table>
            </div>
                            </div>
                            <div id="divGACXTiempo_help3" class="form-group">
                                <span class="glyphicon glyphicon-info-sign XLtext"></span>
                                <span>Información que muestra los instrumentos y herramientas para el ejercicio de participación.</span>
                            </div>
                        </div>
                    </div>
            </div>
            </div>
        </div>
</div>
</div>
  <!-- /.container -->
<script type="text/javascript">
    if ($(document).ready(function () {
        $.getScript('../../Scripts/EncuestaCaracterizacion.js', function () {
        var fecha_ini = $("#hdFechaIni").val();
        var fecha_fin = $("#hdFechaFin").val();
        VerDetalleReporteEncuestaCaracterizacion(fecha_ini, fecha_fin);
    });
    }));
</script>
<script type="text/javascript">

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
        //(function ($) {

        //    $('#filter4').keyup(function () {

        //        var rex = new RegExp($(this).val(), 'i');
        //        $('.searchable4 tr').hide();
        //        $('.searchable4 tr').filter(function () {
        //            return rex.test($(this).text());
        //        }).show();

        //    })

        //}(jQuery));
    });

   </script>



    
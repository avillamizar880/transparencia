<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminRespEncuestaCaract.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Caracterizacion.AdminRespEncuestaCaract" %>

<div class="container">
    <input type="hidden" id="hdIdUsuario" runat="server" />
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
                        <li id="itemCaracterizacion1" class="active"><a id="enlaceCaracterizacion1" data-toggle="tab" href="#divCaracterizacion1">Información general <span class="glyphicon glyphicon-menu-right"></span></a></li>
                        <li id="itemCaracterizacion2"><a id="enlaceCaracterizacion2" data-toggle="tab" href="#divCaracterizacion2">Información parte 2 encuesta <span class="glyphicon glyphicon-menu-right"></span></a></li>
                        <li id="itemCaracterizacion3"><a id="enlaceCaracterizacion3" data-toggle="tab" href="#divCaracterizacion3">Información parte 3 encuesta <span class="glyphicon glyphicon-menu-right"></span></a></li>
                    </ul>
                </div>
            </div>

        </div>
        <div class="col-sm-9">
            <div class="generalInfo">
                <%--<div id="divDetalleProyecto" class="tab-content responsive" runat="server">REVISAR DIV--%>
                <!--CONTENT1 Información general encuesta de caracterización-->
                <div id="divCaracterizacion1" class="tab-pane fade in active">
                    <h2>Información general</h2>
                    <div class="col-sm-12">
                        <h4>Información general</h4>

                        <div id="div2" runat="server" class="alert alert-info">

                            <div class="table-responsive">
                <table id="infogeneral" class="table table-hover table-striped">
                    <thead>
                        <tr>
                            <th>Nombre del ciudadano</th>
                            <th>Email</th>
                            <th>Fecha aplicación</th>
                            <th>Municipio al que pertenece</th>
                            <th>Género</th>
                            <th>Rango de edad</th>
                            <th>Ocupación</th>
                            <th>Actualmente reside en:</th>
                            <th data-toggle="tooltip" title="¿Pertenece a una comunidad étnica minoritaria?" data-placement="bottom">Comunidad minoritaria</th>
                        </tr>
                    </thead>

                    <tbody class="searchable">
                        <tr>
                            <td>Diana Patricia Bautista Otálora</td>
                            <td>diana.bautista.otalora@gmail.com</td>
                            <td>2017-02-13</td>
                            <td>PIEDECUESTA,SANTANDER</td>
                            <td>Femenino</td>
                            <td>30 a 34</td>
                            <td>Ingeniera electrónica</td>
                            <td>Cabecera municipal</td>
                            <td>No</td>


                        </tr>

                </table>
            </div>

                        </div>
                        <div id="divGacXLocal_help2" class="form-group">
                            <span class="glyphicon glyphicon-info-sign XLtext"></span>
                            <span>Información general de la encuesta de caracterización al corte seleccionado</span>
                        </div>
                    </div>
                    <br />
                    <br />
                </div>
            </div>
            <!--CONTENT2 Información encuesta de caracterización 2-->
                    <div id="divCaracterizacion2" class="tab-pane fade">
                        <h2>Información parte 2 encuesta  </h2>

                         <div class="col-sm-12">
                            <h4>Información parte 2 encuesta de caracterización</h4>
                            
                            <div id="divGACXTiempo"  class="alert alert-info" runat="server">
                                  <div class="table-responsive">
                <table id="MecanismosParticipacion" class="table table-hover table-striped">
                    <thead>
                        <tr>
                            <th data-toggle="tooltip" title="¿Actualmente pertenece a alguna organización social o instancia de participación ciudadana?" data-placement="bottom">Pertenencia a alguna instancia de participación ciudadana</th>
                            <th data-toggle="tooltip" title="Mecanismos de participación ciudadana que ha promovido o en los que ha participado en los últimos tres años" data-placement="bottom">Mecanismos de participación ciudadana (promoción o participación) </th>
                            <th data-toggle="tooltip" title="¿La Alcaldía cuenta con recursos destinados para la promoción de la participación ciudadana en su territorio?" data-placement="bottom">Recursos para promover participación ciudadana</th>
                            <th data-toggle="tooltip" title="¿El DNP ha adelantado Auditorías Visibles en su municipio?" data-placement="bottom">Auditorias Visibles</th>
                            <th data-toggle="tooltip" title="La organización civil o instancia de participación con la que actualmente tiene vinculación, ¿cuenta con un plan de acción para orientar su labor de control social?" data-placement="bottom">Plan de acción Control social</th>
                            <th data-toggle="tooltip" title="Por favor seleccione las estrategias, mecanismos o instrumentos que utiliza la ciudadanía para reportar los hallazgos que obtienen de su ejercicio de control social" data-placement="bottom">Estrategias reporte hallazgos</th>
                            <th data-toggle="tooltip" title="Desde su perspectiva, por favor califique la gestión de las autoridades locales en el momento de promover el control ciudadano a la gestión pública o a proyectos específicos" data-placement="bottom">Gestion autoridades locales</th>
                        </tr>
                        <tbody class="searchable">
                            <tr>
                                <td>No</td>
                                <td>Voto para elecciones presidenciales&Voto para elecciones departamentales&Voto para elecciones municipales&Referendo</td>
                                <td>No sé</td>
                                <td>No sé</td>
                                <td>No</td>
                                <td>En el kiosko del barrio</td>
                                <td>Buena</td>
                            </tr>

                        </tbody>
                </table>
            </div>
                            </div>
                            <div id="divGACXTiempo_help" class="form-group">
                                <span class="glyphicon glyphicon-info-sign XLtext"></span>
                                <span>o	Información 2</span>
                            </div>
                        </div>
                    </div>
                    <div id="divCaracterizacion3" class="tab-pane fade">
                        <h2>Información parte 3 encuesta  </h2>

                         <div class="col-sm-12">
                            <h4>Información parte 3 encuesta de caracterización</h4>
                            
                            <div id="div3"  class="alert alert-info" runat="server">
                                <div class="table-responsive">
                <table id="estrategias" class="table table-hover table-striped">
                    <thead>
                        <tr>
                            <th data-toggle="tooltip" title="Por favor seleccione las estrategias, mecanismos o instrumentos que utiliza la ciudadanía para hacer seguimiento a la gestión o a proyectos de las autoridades locales" data-placement="bottom">Estrategias Seguimiento Gestión</th>
                            <th data-toggle="tooltip" title="Durante el año 2016, ¿usted ha radicado/presentado o ha tramitado una respuesta a al menos un derecho de petición donde se solicita el acceso a información específica o algún documento particular del municipio?" data-placement="bottom">Derechos de petición</th>
                            <th data-toggle="tooltip" title="Desde su experiencia, por favor califique la facilidad con la que se puede acceder a la información pública del municipio para hacer seguimiento a la gestión o proyectos de las autoridades locales" data-placement="bottom">Facilidad acceso a la información</th>
                            <th data-toggle="tooltip" title="¿La labor de control social de las organizaciones sociales o instancias de participación ha motivado algún cambio en la gestión o proyectos de las autoridades locales?" data-placement="bottom">Cambios en la gestión local gracias al control social</th>
                            <th data-toggle="tooltip" title="Desde su experiencia, por favor califique la frecuencia con la que se hacen ejercicios de seguimiento a lo público o de control social sobre la gestión de las autoridades locales en su municipio" data-placement="bottom">Frecuencia control social</th>
                            <th data-toggle="tooltip" title="Desde su percepción, ¿Usted considera que en su municipio existen condiciones adecuadas de seguridad para realizar control social?" data-placement="bottom">Condiciones seguridad control social</th>
                        </tr>
                        <tbody class="searchable">
                            <tr>
                                <td>Por parlante en el barrio</td>
                                <td>No sé</td>
                                <td>Es fácil acceder a la información pública del municipio, pues se encuentra publicada en sitios web o documentos impresos de fácil acceso</td>
                                <td>No sé</td>
                                <td>Nunca o rara vez se hacen ejercicios de control social en el municipio</td>
                                <td>Sí</td>
                            </tr>
                            <tr>
                                <td>Por parlante en el barrio</td>
                                <td>No sé</td>
                                <td>Es fácil acceder a la información pública del municipio, pues se encuentra publicada en sitios web o documentos impresos de fácil acceso</td>
                                <td>No sé</td>
                                <td>Nunca o rara vez se hacen ejercicios de control social en el municipio</td>
                                <td>Sí</td>
                            </tr>

                </table>
            </div>
                            </div>
                            <div id="divGACXTiempo_help3" class="form-group">
                                <span class="glyphicon glyphicon-info-sign XLtext"></span>
                                <span>o	Información 3</span>
                            </div>
                        </div>
                    </div>
        </div>
    </div>
</div>
<%--</div>REVISAR DIV--%>
                         
                   
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
    });

</script>






<script>
    $(document).ready(function () {
        $('[data-toggle="tooltip"]').tooltip();
    });
</script>


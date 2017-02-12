<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InformePrevioInicio.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Audiencias.RegistrarObservaciones" %>
<div class="container">
    <h1>Primer Informe con Observaciones Previas</h1>
    <div class="center-block" id="divDatosInforme">
        <input type="hidden" id="hfidproyecto" runat="server"/>
        <input type="hidden" id="hdIdUsuario" runat="server" />
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4>Para tener en cuenta:</h4>
                <p>Este informe de observaciones es la principal herramienta del Grupo Auditor para la preparación de la Audiencia de Inicio, una vez se ha analizado la información disponible del proyecto en el aplicativo y socializado con los beneficiarios, los Auditores prepararán las principales reflexiones a desarrollar en la Audiencia.</p>
            </div>
        </div>
        <div class="panel panel-default">
             <div class="panel-heading">
                <h4>Hágase las siguientes preguntas:</h4>
            </div>
            <div class="panel-body">
                 <div class="form-group">
                    <label for="txtInfoFaltante" class="required">1.¿Qué información hace falta para analizar de manera adecuada el proyecto?</label>
                    <input type="text" class="form-control" id="txtInfoFaltante">
                     <div id="error_txtInfoFaltante" class="alert alert-danger alert-dismissible" hidden="hidden">La respuesta no puede ser vacía</div>
                </div>
                <div class="form-group">
                    <label for="txtInfoCompleta" class="required">2.¿El proyecto tiene la información completa cargada al aplicativo?</label>
                    <input type="text" class="form-control" id="txtInfoCompleta">
                    <div id="error_txtInfoCompleta" class="alert alert-danger alert-dismissible" hidden="hidden">La respuesta no puede ser vacía</div>
                </div>
                <div class="form-group">
                    <label for="txtInfoClara" class="required">3.¿Qué debe explicarse en una Audiencia de Inicio o no es clara? ¿Por qué?</label>
                    <input type="text" class="form-control" id="txtInfoClara">
                    <div id="error_txtInfoClara" class="alert alert-danger alert-dismissible" hidden="hidden">La respuesta no puede ser vacía</div>
                </div>
                <div class="form-group">
                    <label for="txtComunidad" class="required">4.¿Cuáles son las dudas que la comunidad beneficiaria tiene sobre el proyecto y su alcance?</label>
                    <input type="text" class="form-control" id="txtComunidad">
                    <div id="error_txtComunidad" class="alert alert-danger alert-dismissible" hidden="hidden">La respuesta no puede ser vacía</div>
                </div>
                <div class="form-group">
                    <label for="txtDudas" class="required">5.Enumere las dudas que deben ser resueltas en la Audiencia de Inicio para que su trabajo de control social tenga herramientas suficientes para continuar</label>
                    <input type="text" class="form-control" id="txtDudas">
                    <div id="error_txtDudas" class="alert alert-danger alert-dismissible" hidden="hidden">La respuesta no puede ser vacía</div>
                </div>

            </div>
        </div>
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4>Propuestas de Fechas sobre Audiencias posteriores</h4>
                <p>Como resultado de este primer encuentro y conociendo el detalle del proyecto, se podrían proponer por parte del Grupo Auditor Ciudadano las fechas posteriores de las audiencias de seguimiento (s) y de cierre.</p>
            </div>
            <div class="panel-body">
                <div class="row">
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="fecha_posterior_1" class="control-label required">Fecha de Audiencia de Seguimiento</label>
                            <div class="input-group date form_date datetimepicker" data-date="" data-date-format="dd MM yyyy" data-link-field="fecha_posterior_1" data-link-format="yyyy-mm-dd">
                                <input class="form-control" size="16" type="text" value="" readonly>
                                <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                                <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                            </div>
                             <div id="error_fecha_posterior_1" class="alert alert-danger alert-dismissible" hidden="hidden">La fecha no puede ser vacía</div>
                            <input type="hidden" id="fecha_posterior_1" value="" /><br />
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="fecha_posterior_2" class="control-label required">Fecha de Audiencia de Cierre</label>
                            <div class="input-group date form_date datetimepicker" data-date="" data-date-format="dd MM yyyy" data-link-field="fecha_posterior_2" data-link-format="yyyy-mm-dd">
                                <input class="form-control" size="16" type="text" value="" readonly>
                                <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                                <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                            </div>
                             <div id="error_fecha_posterior_2" class="alert alert-danger alert-dismissible" hidden="hidden">La fecha no puede ser vacía</div>
                            <input type="hidden" id="fecha_posterior_2" value="" /><br />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!--BOTONERA-->
        <div class="botonera text-center">
            <div class="btn btn-primary"><a role="button" id="btnObsInformePrevio" runat="server">GUARDAR<span class="glyphicon glyphicon-chevron-right"></span></a></div>
        </div>
    </div>
</div>
<script type="text/javascript">
    if ($(document).ready(function () {
         $.getScript("../../Scripts/AudienciasFunciones.js", function () {
                 $.getScript("../../Scripts/AudienciasAcciones.js", function () {
    });
    });
    }));
</script>

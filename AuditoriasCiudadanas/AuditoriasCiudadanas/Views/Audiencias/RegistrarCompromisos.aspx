<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarCompromisos.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Audiencias.RegistrarCompromisos" %>
<div class="container w70">
    <h1 class="text-center">Registro de Compromisos</h1>
    <div id="divCompromisos">
        <input type="hidden" id="hdIdAudiencia" value="" runat="server" />
        <input type="hidden" id="hdIdUsuario" value="" runat="server" />
        <div id="divAsistente" class="well">
            <div class="row">
                <div class="col-sm-4">
                    <div class="form-group">
                        <label for="ddlTipoAsistente" class="required">Tipo Asistente</label>
                        <select class="form-control" id="ddlTipoAsistente">
                            <option value="">[Seleccione un tipo de Asistente]</option>
                            <option value="1">Auditores Ciudadanos (GAC)</option>
                            <option value="2">Ejecutor el proyecto</option>
                            <option value="3">Personero Municipal</option>
                            <option value="4">Controlaría Municipal</option>
                            <option value="5">Organizaciones sociales</option>
                            <option value="6">Contratista</option>
                            <option value="7">Supervisor</option>
                            <option value="8">Interventor</option>
                            <option value="9">Beneficiarios</option>
                            <option value="10">otros</option>
                        </select>
                    </div>
                </div>
                <div class="col-sm-4">
                    <div class="form-group">
                        <label for="compromiso_1" class="required">Número Asistentes</label>
                        <input type="text" class="form-control" id="cantidad_1" placeholder="Cantidad">
                    </div>
                </div>
                <div class="col-sm-1">
            	<a class="btn btn-default MT25" role="button"><span class="glyphicon glyphicon-trash"></span></a>
            </div>
            </div>
        </div>
        <div class="btn btn-default mb15" id="btnAgregarTipoAsistente"><span class="glyphicon glyphicon-plus"></span>Agregar Categoría Asistente</div>
        <div id="divDetCompromisos" class="well">
            <div class="row registro">
                <div class="col-sm-11">
                    <!--LEFT CONTENT-->
                    <div class="col-sm-4">
                        <div class="form-group">
                            <label for="compromiso_1" class="required">Titulo del Compromiso</label>
                            <input type="text" class="form-control compromiso" id="compromiso_1" placeholder="Titulo del compromiso">
                        </div>
                    </div>
                    <!--CENTER CONTENT-->
                    <div class="col-sm-4">
                        <div class="form-group">
                            <label for="responsable_1" class="required">Responsables(s)</label>
                            <input type="text" class="form-control responsable" id="responsable_1" placeholder="Responsables">
                        </div>
                    </div>
                    <!--RIGHT CONTENT-->
                    <div class="col-sm-4">
                        <div class="form-group">
                            <label for="dtp_input_1" class="control-label required">Fecha(s) de Cumplimiento</label>
                            <div class="input-group date form_date" data-date="" data-date-format="dd MM yyyy" data-link-field="dtp_input_1" data-link-format="yyyy-mm-dd">
                                <input class="form-control" size="16" type="text" id="fecha_1" value="" readonly>
                                <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                                <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                            </div>
                            <input type="hidden" id="dtp_input_1" value="" class="fecha" /><br />
                        </div>
                    </div>
                  
                </div>
            </div>
            
        </div>
        <div class="btn btn-default mb15" id="btnAgregarCompromiso"><span class="glyphicon glyphicon-plus"></span>Agregar Compromiso</div>
    </div>

    <div class="well text-center">
        <button class="btn btn-info" id="btnGuardarCompromisos"><span class="glyphicon glyphicon-save"></span>Guardar Compromisos</button>
    </div>
</div>
<script type="text/javascript">
    if ($(document).ready(function () {
         $.getScript('../../Scripts/AudienciasFunciones.js', function () {
             $.getScript('../../Scripts/AudienciasAcciones.js', function () {

             });
         });
     }));
</script>

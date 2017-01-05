<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarCompromisos.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Audiencias.RegistrarCompromisos" %>
<div class="container">
    <h1 class="text-center">Registro de Compromisos</h1>
    <div id="divCompromisos">
        <div class="row">
            <div class="col-sm-4">
                <div class="form-group">
                    <label for="numero_asistentes">Número de Asistentes</label>
                    <input type="text" class="form-control" id="numero_asistentes">
                </div>
            </div>
        </div>
        <div class="row registro">
            <!--LEFT CONTENT-->
            <div class="col-sm-4">
                <div class="form-group">
                    <label for="compromiso_1">Titulo del Compromiso</label>
                    <input type="text" class="form-control compromiso" id="compromiso_1" placeholder="Titulo del compromiso">
                </div>
            </div>
            <!--CENTER CONTENT-->
            <div class="col-sm-4">
                <div class="form-group">
                    <label for="responsable_1">Responsables(s)</label>
                    <input type="text" class="form-control responsable" id="responsable_1" placeholder="Responsables">
                </div>
            </div>
            <!--RIGHT CONTENT-->
            <div class="col-sm-4">
                <div class="form-group">
                    <label for="dtp_input_1" class="control-label">Fecha(s) de Cumplimiento</label>
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
    <div class="btn btn-default mb15" id="btnAgregarCompromiso"><span class="glyphicon glyphicon-plus"></span>Agregar Compromiso</div>
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

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProponerFechaReuPrevias.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Audiencias.ProponerFechaAudPrevias" %>
<!-- Custom CSS -->
<link href="../../Content/bootstrap.min.css" rel="stylesheet" />
<link href="../../Content/logo-nav.css" rel="stylesheet" />
<link href="../../Content/screenView.css" rel="stylesheet" />
<link href="../../Content/bootstrap-datetimepicker.min.css" rel="stylesheet" />
<script src="../../Scripts/jquery-1.12.4.min.js"></script>
<script src="../../Scripts/bootstrap.min.js"></script>
<script src="../../Scripts/bootbox.min.js"></script>
<script src="../../Scripts/bootstrap-datetimepicker.js"></script>
<script src="../../Scripts/bootstrap-datetimepicker.es.js"></script>
<script src="../../Scripts/jquery.blockUI.js"></script>
<script src="../../Scripts/ajaxPost.js"></script>
<div class="container">
 <input type="hidden" id="hfidproyecto" runat="server"/>
 <input type="hidden" id="hdIdUsuario" runat="server" />
    <h1 id="hTitulo" runat="server" class="text-center">Reunión Previa con Autoridades</h1>
    <div class="w60 center-block">
        <div class="form-group">
            <label for="txtAsunto">Agende la reuni&oacute;n previa con autoridades. P&oacute;ngase de acuerdo con su grupo auditor ciudadano y proponga una fecha e inform&eacute;le a las autoridades.</label>
        </div>
        <div class="row">
            <div class="col-sm-6">
                <div class="form-group">
                    <label for="fecha_posterior_1" class="control-label">Fecha</label>
                    <div class="input-group date form_date datetimepicker" data-date="" data-date-format="dd MM yyyy" data-link-field="fecha_posterior_1" data-link-format="yyyy-mm-dd">
                        <input class="form-control" size="16" type="text" value="" readonly>
                        <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                        <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                    </div>
                    <input type="hidden" id="fecha_posterior_1" value="" /><br />
                </div>
            </div>
        </div>
        <!--BOTONERA-->
        <div class="botonera text-center">
            <div class="btn btn-primary"><a id="btnProponerFechaPrevias" runat="server" role="button">PROPONER<span class="glyphicon glyphicon-chevron-right"></span></a></div>
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
<script type="text/javascript">
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
</script>
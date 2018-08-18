<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarFechaAud.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Audiencias.RegistrarFechaAud" %>
<div class="container" id="divInfoAudiencia">
 <input type="hidden" id="hdIdUsuario" runat="server" />
    <h1 id="hTitulo" runat="server" class="text-center">Registro Fecha Audiencia</h1>
    <div class="w60 center-block" id="divDatosAudiencia">
        <div class="form-group">
            <label for="txtAsunto">Registre los datos relacionados con la audiencia.</label>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <div class="form-group">
                    <%--proyecto--%>
                     <label for="txtProyecto" class="required">BPIN-Proyecto</label>
                    <asp:textbox id="txtProyecto" class="form-control acProyecto" data-items="20" runat="server" autocomplete="on" />
                    <asp:hiddenfield id="hdIdProyecto" runat="server" />
                    <div id="error_txtProyecto" class="alert alert-danger alert-dismissible" hidden="hidden">BPIN-Proyecto no puede ser vacío</div>
                    <div id="error_hdIdProyecto" class="alert alert-danger alert-dismissible" hidden="hidden">BPIN-Proyecto no válido</div>
                </div>
                </div>
        </div>
        <div class="row">
             <div class="col-sm-6">
                 <div class="form-group">
                     <label for="ddlTipoAudiencia" class="required">Tipo Audiencia</label>
                     <asp:dropdownlist id="ddlTipoAudiencia" class="form-control" runat="server" datatextfield="nombre" datavaluefield="idTipoAudiencia" tooltip="[--Tipo Audiencia--]">
                       </asp:dropdownlist>
                     <div id="error_ddlTipoAudiencia" class="alert alert-danger alert-dismissible" hidden="hidden">Tipo audiencia no puede ser vacía</div>
                 </div>
                 </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <div class="form-group">
                    <label for="txtMunicipio" class="required">Lugar-Municipio</label>
                    <asp:textbox id="txtMunicipio" class="form-control" data-items="20" runat="server" autocomplete="on" />
                    <asp:hiddenfield id="hdIdMunicipio" runat="server" />
                    <div id="error_txtMunicipio" class="alert alert-danger alert-dismissible" hidden="hidden">Lugar-Municipio no puede ser vacío</div>
                    <div id="error_hdIdMunicipio" class="alert alert-danger alert-dismissible" hidden="hidden">Lugar-Municipio no válido</div>

                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <div class="form-group">
                    <label for="txtDireccion">Dirección</label>
                    <asp:textbox id="txtDireccion" class="form-control" data-items="20" runat="server" autocomplete="on" />
                    <div id="error_txtDireccion" class="alert alert-danger alert-dismissible" hidden="hidden">Dirección no puede ser vacía</div>
               </div>
            </div>
        </div>
        <div class="row">
             <div class="col-sm-6">
                <div class="form-group">
                    <label for="dtp_fecha" class="control-label required">Fecha</label>
                    <div class="input-group date form_datetime" data-date="" data-date-format="yyyy-mm-dd - hh:ii" data-link-field="dtp_fecha" data-link-format="yyyy-mm-dd - hh:ii">
                        <input class="form-control" size="16" type="text" value="" readonly>
                        <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                        <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                    </div>
                    <input type="hidden" id="dtp_fecha" value="" /><br />
                    <div id="error_dtp_fecha" class="alert alert-danger alert-dismissible" hidden="hidden">Fecha no puede ser vacía</div>
                </div>
            </div>

        </div>

        <!--BOTONERA-->
        <div class="botonera text-center">
            <div class="btn btn-primary"><a id="btnRegistrarFechaAud" runat="server" role="button">REGISTRAR<span class="glyphicon glyphicon-chevron-right"></span></a></div>
        </div>
    </div>
</div>

<script type="text/javascript">
   if ($(document).ready(function () {
        $.getScript("../../Scripts/AudienciasFunciones.js", function () {
                $.getScript("../../Scripts/AudienciasAcciones.js", function () {
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
           });
        });
    }));
</script>

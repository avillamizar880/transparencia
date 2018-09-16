<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnlacesDNP.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Administracion.EnlacesDNP" %>

<div class="container" id="divInfoEnlaceDNP">
    <h1 class="text-center">Enlaces DNP</h1>
    <input type="hidden" id="hdIdUsuario" runat="server" />
    <input type="hidden" id="hdDllContent" runat="server" />
    <div class="col-sm-12 well">
        <div id="divDetReportes">
            <div class="row">
                <div class="col-sm-6">
                    <div class="form-group">
                        <label for="ddlTipoEnlace" class="required">Tipo Enlace</label>
                        <!-- departamento-->
                        <asp:dropdownlist id="ddlTipoEnlace" class="form-control" runat="server" datatextfield="descripcion" datavaluefield="id_enlace" tooltip="--Seleccione--">
                        </asp:dropdownlist>
                        <div id="error_ddlTipoEnlace" class="alert alert-danger alert-dismissible" hidden="hidden">Tipo Enlace no puede ser vacío</div>
                    </div>

                </div>
            </div>
            <div class="row">
                <div class="col-sm-12">
                    <div class="form-group">
                        <label for="txtURL" class="required">URL</label>
                        <input type="text" class="form-control" id="txtURL">
                        <div id="error_txtURL" class="alert alert-danger alert-dismissible" hidden="hidden">URL no puede ser vacío</div>
                    </div>
                </div>
            </div>
            <div class="row text-center">
                <div class="col-sm-6">
                    <div class="input-group btn btn-primary" id="btnGuardarEnlaceDNP">Guardar</div>
                </div>


            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    if ($(document).ready(function () {
        $.getScript("../../Scripts/EnlacesDNPFunciones.js", function () {
            $.getScript("../../Scripts/EnlacesDNPAcciones.js", function () {
                //reload_enlaces();
            });
        });
    }));
</script>

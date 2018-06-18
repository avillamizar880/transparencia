<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_enlaces.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Capacitacion.admin_enlaces" %>
<div class="container" id="divContEnlaces">
    <h1 class="text-center">Enlaces de Interés</h1>
    <div class="well text-center">
        <div class="btn btn-info mb15" id="btnNewEnlace"><span class="glyphicon glyphicon-plus"></span>Nuevo Enlace</div>
    </div>
    <div class="enlacesBox" id="divListadoEnlaces">
    </div>
    <div class="col-md-12 text-center">
        <nav id="divPagEnlaces" aria-label="Page navigation">
            <ul id="paginador" class="pagination">
            </ul>
        </nav>
    </div>
</div>
<div class="container hideObj" id="divInfoEnlace">
    <div class="plantillasHeader">
        <h5>
            <a id="btnVolverListadoAdmin" role="button" onclick="volver_listado_admin('divInfoEnlace','divContEnlaces');"><span class="glyphicon glyphicon-chevron-left"></span>VOLVER A ENLACES
            </a>
        </h5>
    </div>
<input type="hidden" id="hdIdUsuario" runat="server" />
<input type="hidden" id="hdIdRecurso" runat="server" />
    <h1 class="text-center">Enlaces de Interés</h1>
    <div class="form-group">
        <label for="txtTitulo" class="required">Título</label>
        <input type="text" class="form-control" id="txtTitulo">
        <div id="error_txtTitulo" class="alert alert-danger alert-dismissible" hidden="hidden">Título no puede ser vacío</div>
    </div>
    <div class="form-group">
        <label for="txtDescripcion" class="required">Descripción</label>
        <input type="text" class="form-control" id="txtDescripcion">
        <div id="error_txtDescripcion" class="alert alert-danger alert-dismissible" hidden="hidden">Descripción no puede ser vacío</div>
    </div>
    <div class="form-group">
        <label for="txtEnlace" class="required">Link</label>
        <input type="text" class="form-control" id="txtEnlace">
        <div id="error_txtEnlace" class="alert alert-danger alert-dismissible" hidden="hidden">Link no puede ser vacío</div>
    </div>

      <!--BOTONERA-->
    <div class="botonera text-center">
        <div class="btn btn-primary"><a id="btnCrearEnlace" role="button">GUARDAR<span class="glyphicon glyphicon-chevron-right"></span></a></div>
    </div>
</div>
<script type="text/javascript">
   if ($(document).ready(function () {
        $.getScript("../../Scripts/CapacitacionFunciones.js", function () {
                $.getScript("../../Scripts/CapacitacionAcciones.js", function () {
                reload_enlaces();
            });
        });
    }));
</script>

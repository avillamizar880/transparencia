<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_recursoscapacitacion.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Capacitacion.admin_recursoscapacitacion" %>
<div class="container" id="divInfoRecursos">
<input type="hidden" id="hdIdUsuario" runat="server" />
<input type="hidden" id="hdIdCap" runat="server" />
        <h1>Recursos de la Capacitación</h1>

    <div id="editarTCap">
    <div class="form-group">
        <label for="txtTitulo" class="required">Título</label>
        <input type="text" class="form-control" id="txtTitulo">
        <div id="error_txtTitulo" class="alert alert-danger alert-dismissible" hidden="hidden">Título no puede ser vacío</div>
    </div>
    <div class="form-group">
        <label for="txtDescripcion" class="required">Detalle</label>
        <input type="text" class="form-control" id="txtDescripcion">
        <div id="error_txtDescripcion" class="alert alert-danger alert-dismissible" hidden="hidden">Detalle no puede ser vacío</div>
    </div>
      <!--BOTONERA-->
    <div class="botonera text-center">
        <div class="btn btn-primary"><a id="btnEditarTemaCapacitacion" role="button">GUARDAR<span class="glyphicon glyphicon-chevron-right"></span></a></div>

    </div>
    </div>
     <div class="container">
        <div class="row">
                  <div id="datosRCap" class="list-group uppText clearfix"></div>


            <div class="btn btn-info" id="btnAñadirRCap"><a href="#"> <span class="glyphicon glyphicon-plus"></span>Añadir Recurso</a></div>
        </div>
    <div id="crearRCap">
    <div class="form-group">
        <label for="txtTituloRCap" class="required">Título</label>
        <input type="text" class="form-control" id="txtTituloRCap">
        <div id="error_txtTituloRCap" class="alert alert-danger alert-dismissible" hidden="hidden">Título no puede ser vacío</div>
    </div>
    <div class="form-group">
        <label for="txtModulo" class="required">Módulo</label>
        <input type="text" class="form-control" id="txtModulo">
        <div id="error_txtModulo" class="alert alert-danger alert-dismissible" hidden="hidden">El módulo no puede ser vacío</div>
    </div>
    <div class="form-group">
        <label for="txtTipoRCap" class="required">Tipo</label>
        <input type="text" class="form-control" id="txtTipoRCap">
        <div id="error_txtTipoRCap" class="alert alert-danger alert-dismissible" hidden="hidden">Tipo no puede ser vacío</div>
    </div>
    <div class="form-group">
        <label for="txtURLRCap" class="required">URL</label>
        <input type="text" class="form-control" id="txtURLRCap">
        <div id="error_txtURLRCap" class="alert alert-danger alert-dismissible" hidden="hidden">URL no puede ser vacío</div>
    </div>
      <!--BOTONERA-->
    <div class="botonera text-center">
        <div class="btn "><a id="btnVolverRCap" role="button">VOLVER<span class="glyphicon "></span></a></div>
        <div class="btn btn-primary"><a id="btnCrearRecursoCapacitacion" role="button">GUARDAR RECURSO<span class="glyphicon glyphicon-chevron-right"></span></a></div>

    </div>
    </div>
    </div>
</div>
<script type="text/javascript">
   if ($(document).ready(function () {
        $.getScript("../../Scripts/CapacitacionFunciones.js", function () {
                $.getScript("../../Scripts/CapacitacionAcciones.js", function () {
            });
  
       CargarDatosCapacitacion();
        });
    }));
</script>
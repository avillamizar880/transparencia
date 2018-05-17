<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_recursoscapacitacion.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Capacitacion.admin_recursoscapacitacion" %>
<div class="container" id="divInfoRecursos">
<input type="hidden" id="hdIdUsuario" runat="server" />
<input type="hidden" id="hdIdCap" runat="server" />
        <h1>Recursos de la Capacitación</h1>

        <div class="container">
        <div class="row">
                  <div id="datosTCap" class="list-group uppText clearfix"></div>


            <div class="btn btn-info" id="btnAñadirTCap"><a href="#"> <span class="glyphicon glyphicon-plus"></span>Añadir</a></div>
        </div>
    </div>



    <div id="crearTCap">
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
        <div class="btn "><a id="btnVolverTCap" role="button">VOLVER<span class="glyphicon "></span></a></div>
        <div class="btn btn-primary"><a id="btnCrearTemaCapacitacion" role="button">GUARDAR<span class="glyphicon glyphicon-chevron-right"></span></a></div>

    </div>
    </div>
</div>
<script type="text/javascript">
   if ($(document).ready(function () {
        $.getScript("../../Scripts/CapacitacionFunciones.js", function () {
                $.getScript("../../Scripts/CapacitacionAcciones.js", function () {
            });
  
       CargarDatosTemaCapacitacion();
        });
    }));
</script>
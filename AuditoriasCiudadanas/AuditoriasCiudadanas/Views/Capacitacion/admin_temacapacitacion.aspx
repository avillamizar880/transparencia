<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_temacapacitacion.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Capacitacion.admin_temacapacitacion" %>
<div class="container" id="divInfoEnlace">
<input type="hidden" id="hdIdUsuario" runat="server" />

        <div class="container">
                	<h1 class="text-center">Capacitaciones</h1>
                    <div class="well text-center">  
                         <div class="btn btn-info mb15"  id="btnAñadirTCap"><span class="glyphicon glyphicon-plus"></span> Agregar Capacitación</div>  
                    </div>
                    <div class="capacitacionBox">
                    <div id="datosTCap"></div>
                    </div>
        </div>



    <div id="crearTCap">
    <div class="panel panel-capacitacion">
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
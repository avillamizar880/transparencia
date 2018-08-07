<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AprobacionBuenasPracticas.aspx.cs" Inherits="AuditoriasCiudadanas.Views.GestionGAC.AprobacionBuenasPracticas" %>
    <div class="container">
    <h1 class="text-center">Reconocer Buena Práctica</h1>
    	<div class="w60 center-block">
            <div id="divListadoPracticas">

            </div>
        <!--BOTONERA-->
             <div class="botonera text-center">
              	<div class="btn btn-primary"><a href=""><span class="glyphicon glyphicon-ok-sign"></span> Publicar</a></div>
             </div>
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
          obtBuenasPracticas();
    }));
</script>
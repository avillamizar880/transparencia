<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_enlaces.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Capacitacion.admin_enlaces" %>
<div class="container">
    	<h1 class="text-center">Enlaces de Interés</h1>
        <div class="well text-center">
         	<div class="btn btn-info mb15"><span class="glyphicon glyphicon-plus"></span> Nuevo Enlace</div>  
         </div>
        <div class="enlacesBox">
            <div class="row">
                <div class="col-md-4">
                    <div class="panel panel-capacitacion">
                        <div class="panel-heading">1. Capacitación y comunidad </div>
                        <div class="panel-body">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean at fringilla purus. Nam vitae eleifend est. Integer sagittis lectus sit amet posuere lobortis.
                            <a href="#" class="btn btn-info">Ver enlace</a>
                        </div>
                        <div class="panel-footer">
                            <a href="#" class="btn btn-default"><span class="glyphicon glyphicon-edit"></span>Editar</a>
                            <a href="#" class="btn btn-default"><span class="glyphicon glyphicon-trash"></span>Eliminar</a>
                        </div>

                    </div>
                </div>
                <div class="col-md-4">
                    <div class="panel panel-capacitacion">
                        <div class="panel-heading">1. Capacitación y comunidad </div>
                        <div class="panel-body">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean at fringilla purus. Nam vitae eleifend est. Integer sagittis lectus sit amet posuere lobortis.
               <a href="#" class="btn btn-info">Ver enlace</a>
                        </div>
                        <div class="panel-footer">
                            <a href="#" class="btn btn-default"><span class="glyphicon glyphicon-edit"></span>Editar</a>
                            <a href="#" class="btn btn-default"><span class="glyphicon glyphicon-trash"></span>Eliminar</a>
                        </div>

                    </div>
                </div>
                <div class="col-md-4">
                    <div class="panel panel-capacitacion">
                        <div class="panel-heading">1. Capacitación y comunidad </div>
                        <div class="panel-body">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean at fringilla purus. Nam vitae eleifend est. Integer sagittis lectus sit amet posuere lobortis.
               <a href="#" class="btn btn-info">Ver enlace</a>
                        </div>
                        <div class="panel-footer">
                            <a href="#" class="btn btn-default"><span class="glyphicon glyphicon-edit"></span>Editar</a>
                            <a href="#" class="btn btn-default"><span class="glyphicon glyphicon-trash"></span>Eliminar</a>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    <div class="col-md-12 text-center">
        <nav id="divPagEnlaces" aria-label="Page navigation">
            <ul class="pagination">
            </ul>
        </nav>
    </div>

<div class="container hideObj" id="divInfoEnlace">
<input type="hidden" id="hdIdUsuario" runat="server" />
    <h1>Creación de Enlaces</h1>
    <div class="form-group">
        <label for="txtTitulo" class="required">Título</label>
        <input type="text" class="form-control" id="txtTitulo">
        <div id="error_txtTitulo" class="alert alert-danger alert-dismissible" hidden="hidden">Títulol no puede ser vacío</div>
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
            });
        });
    }));
</script>

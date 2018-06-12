<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminForo.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Comunicacion.adminForo" %>

<!-- Page Content -->
<div class="container" id="NoSession" runat="server">
    <h1 class="text-center">Foro</h1>
    <div class="alert alert-danger">
        <strong>Error:</strong> Debes iniciar sesión para usar el espacio virtual.
    </div>
</div>

<input type="hidden" id="hdIdUsuario" runat="server" value="" />
<div class="container" id="divInfoForo" runat="server">
    <h1 class="text-center">Foro</h1>
    <div class="sendBox well">
        <div class="form-group">
            <div class="row">
                <div class="col-md-8">
                    <input type="text" id="txtBuscarTema" class="form-control" placeholder="Buscar por tema o descripcion">
                </div>
                <div class="col-md-2"><a class="btn btn-primary" role="button" id="btnBuscarTema" ><span class="glyphicon glyphicon-search"></span> Buscar</a></div>
                <div class="col-md-2"><a class="btn btn-default pull-right" role="button" id="btnNuevoTema"><span class="glyphicon glyphicon-plus"></span> Nuevo Tema</a></div>
            </div>

        </div>
    </div>
    <div class="sendBox well" style="display: none;" id="divNuevoTema">
        <form>
            <div class="form-group">
                <div class="row">
                    <div class="col-md-10">
                        <input type="text" class="form-control" id="txtTemaForo" placeholder="Añade un nuevo tema">
                    </div>
                </div>
            </div>
            <div class="form-group">
                <textarea class="form-control" rows="4" id="txtDescripcionForo" placeholder="Comparte un comentario"></textarea>
            </div>
            <div class="form-group">
                <button class="btn btn-primary" onclick="guardarTema(); return false;"><span class="glyphicon glyphicon-send"></span> COMENTAR</button>
            </div>
        </form>
    </div>

</div>


<script type="text/javascript">
    if ($(document).ready(function () {
        $.getScript("/Scripts/ComunicacionFunciones.js", function () {
            $.getScript("/Scripts/ComunicacionAcciones.js", function () {
            });
        });
    }));
</script>

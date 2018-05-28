<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cambioClave.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Usuarios.cambioClave" %>
    <!-- Page Content -->
    <div class="container" id="divCambioClave">
    	<h1>Cambio Clave</h1>
        <div class="center-block w60">
            <form>
                <div class="form-group">
                    <label for="txtPassword_ant" class="required">Clave anterior</label>
                    <input type="password" class="form-control" id="txtPassword_ant">
                    <div id="error_txtPassword_ant" class="alert alert-danger alert-dismissible" hidden="hidden">Clave anterior no puede ser vacía</div>
                </div>
                 
                <div class="form-group">
                    <label for="txtPassword" class="required">Nueva Clave</label>
                    <input type="password" class="form-control" id="txtPassword">
                    <div id="error_txtPassword" class="alert alert-danger alert-dismissible" hidden="hidden">Nueva clave no puede ser vacía</div>
                </div>

                <div class="form-group" >
                    <label for="txtPassword_2" class="required">Confirma nueva Clave</label>
                    <input type="password" class="form-control" id="txtPassword_2">
                    <div id="error_txtPassword_2" class="alert alert-danger alert-dismissible" hidden="hidden">Confirmación no puede ser vacía</div>
                </div>
                <!--BOTONERA-->
                <div class="botonera text-center">
                    <div class="btn btn-primary"><a id="btnCambiarClave" role="button">GUARDAR<span class="glyphicon glyphicon-chevron-right"></span></a></div>
                </div>
                <input type="hidden" id="hdIdUsuario" value="" runat="server" />
            </form>
        </div>
    </div>
<script type="text/javascript">
   if ($(document).ready(function () {
        $.getScript("../../Scripts/UsuariosFunciones.js", function () {
                $.getScript("../../Scripts/UsuariosAcciones.js", function () {
            });
        });
    }));
</script>

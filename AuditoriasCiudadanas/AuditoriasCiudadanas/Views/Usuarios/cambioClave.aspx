<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cambioClave.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Usuarios.cambioClave" %>
<script src="../../Scripts/UsuariosFunciones.js"></script>
<script src="../../Scripts/UsuariosAcciones.js"></script>
    <!-- Page Content -->
    <div class="container">
    	<h1>Cambio Clave</h1>
        <div class="center-block w60">
            <form>
                <div class="form-group">
                    <label for="txtPassword_ant">Clave anterior</label>
                    <input type="password" class="form-control" id="txtPassword_ant">
                </div>
                <div class="form-group">
                    <label for="txtPassword">Nueva Clave</label>
                    <input type="password" class="form-control" id="txtPassword">
                </div>
                <div class="form-group">
                    <label for="txtPassword_2">Confirma nueva Clave</label>
                    <input type="password" class="form-control" id="txtPassword_2">
                </div>
                <!--BOTONERA-->
                <div class="botonera text-center">
                    <div class="btn btn-primary"><a id="btnCambiarClave" role="button">GUARDAR<span class="glyphicon glyphicon-chevron-right"></span></a></div>
                </div>
                <input type="hidden" id="hdIdUsuario" value="" runat="server" />
            </form>
        </div>
    </div>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="olvidoClave_ajax.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Usuarios.olvidoClave_ajax" %>
 <!-- Page Content -->
<div class="container" id="divInfoUsuario">
    <input type="hidden" id="hdIdUsuario" runat="server" />
    <h1>Restablecimiento de Clave</h1>
    <div class="center-block w60" id="divConfirmaEnvio" runat="server">
        <input type="hidden" id="hdEnvio" runat="server" />

        <div class="formSteps">
            <div class="step" data-toggle="tooltip" title="Obtener código de verificación"><span class="glyphicon glyphicon-edit"></span>Paso 1</div>
            <div class="step currentStep" data-toggle="tooltip" title="Ingresar código de Verificación"><span class="glyphicon glyphicon-question-sign"></span>Paso 2</div>
            <div class="step" data-toggle="tooltip" title="Ingresar Nueva Clave"><span class="glyphicon glyphicon-user"></span>Paso 3</div>
        </div>
        <div class="well text-center">
            <h2>Ingresar código de verificación</h2>
            <p id="textoVerifica" runat="server"></p>
        </div>
           <div class="form-group">
               <label for="txtCodigoVerifica" class="required">Código</label>
                <input type="text" class="form-control" id="txtCodigoVerifica">
                <div id="error_txtCodigoVerifica" class="alert alert-danger alert-dismissible" hidden="hidden">Código no puede ser vacío</div>
            </div>
        <div class="botonera">
            <div class="btn btn-primary fr"><a role="button" id="btnVerificaCodigoClave" runat="server">Verificar<span class="glyphicon glyphicon-chevron-right"></span></a></div>
        </div>
    </div>
    <div id="divNotificaError" runat="server">
        <div class="well text-center">
            <h2 id="textoVerificaError" runat="server"></h2>
        </div>
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

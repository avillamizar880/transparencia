<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="olvidoClave.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Usuarios.olvidoClave" %>
 <!-- Page Content -->
<div class="container" id="divInfoUsuario">
    <h1>Re establecimiento de Clave</h1>
    <div class="center-block w60" id="divConfirmaEnvio" runat="server">
        <input type="hidden" id="hdEnvio" runat="server" />
           <div class="formSteps">
                <div class="step currentStep" data-toggle="tooltip" title="Obtener código de verificación"><span class="glyphicon glyphicon-edit"></span>Paso 1</div>
                <div class="step" data-toggle="tooltip" title="Ingresar código de Verificación"><span class="glyphicon glyphicon-question-sign"></span>Paso 2</div>
                <div class="step" data-toggle="tooltip" title="Ingresar Nueva Clave"><span class="glyphicon glyphicon-user"></span>Paso 3</div>
            </div>
        <div class="well text-center">
            <h2 id="textoVerifica">Para asignar una nueva clave ingrese el correo electrónico registrado, se enviará un código de verificación al mismo.</h2>
        </div>
           <div class="form-group">
               <label for="txtEmail" class="required">Correo Electrónico</label>
                <input type="text" class="form-control" id="txtEmail">
                <div id="error_txtEmail" class="alert alert-danger alert-dismissible" hidden="hidden">Correo electrónico no puede ser vacío</div>
            </div>
        <div class="botonera">
            <div class="btn btn-primary fr"><a role="button" id="btnEnviaCodigoClave" runat="server">Enviar <span class="glyphicon glyphicon-chevron-right"></span></a></div>
        </div>
    </div>

</div>
<script type="text/javascript">
   if ($(document).ready(function () {
        $.getScript("../../Scripts/UsuariosFunciones.js", function () {
                $.getScript("../../Scripts/UsuariosAcciones.js", function () {
                $('[data-toggle="tooltip"]').tooltip();
            });
        });
    }));
</script>

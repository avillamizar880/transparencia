<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="restablecerPassword.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Usuarios.restablecerPassword" %>
 <!-- Page Content -->
<div class="container" id="divInfoUsuario">
    <h1>Re establecimiento de Clave</h1>
    <div class="center-block w60" id="divConfirmaEnvio" runat="server">
        <input type="hidden" id="hdIdUsuario" value="" runat="server" />
           <div class="formSteps">
                <div class="step" data-toggle="tooltip" title="Obtener código de verificación"><span class="glyphicon glyphicon-edit"></span>Paso 1</div>
                <div class="step" data-toggle="tooltip" title="Ingresar código de Verificación"><span class="glyphicon glyphicon-question-sign"></span>Paso 2</div>
                <div class="step currentStep" data-toggle="tooltip" title="Ingresar Nueva Clave"><span class="glyphicon glyphicon-user"></span>Paso 3</div>
            </div>
        <div class="text-center">
            <h2 id="textoVerifica" runat="server"></h2>
        </div>
        <div id="divNuevaClave" runat="server">
            <h1>Cambio Clave</h1>
            <div class="center-block w60">
                <form>
                    <div class="form-group">
                        <label for="txtPassword" class="required">Nueva Clave</label>
                        <input type="password" class="form-control" id="txtPassword">
                    </div>
                    <div class="form-group">
                        <label for="txtPassword_2" class="required">Confirma nueva Clave</label>
                        <input type="password" class="form-control" id="txtPassword_2">
                    </div>
                    <!--BOTONERA-->
                    <div class="botonera text-center">
                        <div class="btn btn-primary"><a id="btnCambiarClaveOlvido" role="button">GUARDAR<span class="glyphicon glyphicon-chevron-right"></span></a></div>
                    </div>
                    
                </form>
            </div>
        </div>  
    </div>
</div>
   <!-- Page Content -->

<script type="text/javascript">
    if ($(document).ready(function () {
         $.getScript("../../Scripts/UsuariosFunciones.js", function () {
         $.getScript("../../Scripts/UsuariosAcciones.js", function () {
         $('[data-toggle="tooltip"]').tooltip();
    });
    });
    }));
</script>
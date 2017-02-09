<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="verificaCuenta.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Usuarios.verificaCuenta" %>
 <!-- Page Content -->
<di class="container">
    <h1>Registro de usuario</h1>
    <div class="center-block w60" id="divConfirmaEnvio" runat="server">
        <input type="hidden" id="hdEnvio" runat="server" />
        <div class="formSteps">
            <div class="step"><span class="glyphicon glyphicon-edit"></span>Paso 1</div>
            <div class="step currentStep"><span class="glyphicon glyphicon-question-sign"></span>Paso 2</div>
            <div class="step"><span class="glyphicon glyphicon-user"></span>Paso 3</div>
            <div class="step"><span class="glyphicon glyphicon-equalizer"></span>Paso 4</div>
            <%--<div class="step"><span class="glyphicon glyphicon-blackboard"></span>Paso 5</div>--%>
        </div>
        <div class="well text-center">
            <h2 id="textoVerifica"></h2>
        </div>
        <div class="botonera">
            <%--  <div class="btn btn-default"><a role="button" id="btnVolverProy">VOLVER AL PROYECTO</a></div>--%>
            <%--<div class="btn btn-primary fr"><a role="button" id="btnVerificaCuenta" runat="server">Siguiente <span class="glyphicon glyphicon-chevron-right"></span></a></div>--%>
        </div>
    </div>

</di
    v>
<script type="text/javascript">
   if ($(document).ready(function () {
        $.getScript("../../Scripts/UsuariosFunciones.js", function () {
                $.getScript("../../Scripts/UsuariosAcciones.js", function () {
                var envio = $("hdEnvio").val();
                if (envio != "OK") {
                     $("#textoVerifica").html("Hemos enviado a su correo un link de verificación, por favor revise su correo.");
                   } else {
                        $("#textoVerifica").html("Ha ocurrido un error al enviar correo de verificación: " + envio);

                   }
            });
        });
    }));
</script>

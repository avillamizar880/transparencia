<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EncuestaParte4.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Caracterizacion.EncuestaParte4" %>
<div class="container">
        <input type="hidden" id="hfmunicipio" runat="server"/>
        <input type="hidden" id="hfUsuarioId" runat="server"/>
        <form id="form2" runat="server">
        <h1 class="text-center">Encuesta de caracterización</h1>
        <div class="center-block w60">
     <div class="formSteps">
        	<div class="step" data-toggle="tooltip" title="En este paso debe ingresar la información básica para ser registrado en nuestro sistema."><span class="glyphicon glyphicon-edit"></span>Paso 1</div>
            <div class="step" data-toggle="tooltip" title="Encontrará preguntas sobre las condiciones de participación que existen en su municipio."><span class="glyphicon glyphicon-question-sign"></span>Paso 2</div>
            <div class="step" data-toggle="tooltip" title="Responderá preguntas sobre los instrumentos y herramientas que utiliza en su ejercicio de participación, además de recolectar información sobre su experiencia en control social."><span class="glyphicon glyphicon-user"></span>Paso 3</div>
            <div class="step currentStep" data-toggle="tooltip" title="Terminación de la encuesta. Siga su recorrido por nuestro sistema."><span class="glyphicon glyphicon-blackboard"></span>Paso 4</div>						
     </div>
    
  </div>
    <div class="botonera text-center" >
        <div class="btn btn-primary" onclick="Atras('3')">Atrás <span class="glyphicon glyphicon-chevron-left"></span></div>
        <div class="btn btn-primary" onclick="Siguiente('5')">Siguiente <span class="glyphicon glyphicon-chevron-right"></span></div>
        <div class="btn btn-primary" onclick="Reenviar('../Views/Capacitacion/CapacitacionInicialFaseI','dvPrincipal')">Continuar después ...<span class="glyphicon"></span></div>
    </div>
    </form>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            InicializarCajasTexto(4);
            $('[data-toggle="tooltip"]').tooltip();
        });
    </script>
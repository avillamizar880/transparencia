<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EncuestaParte5.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Caracterizacion.EncuestaParte5" %>
<div class="container">
        <input type="hidden" id="hfmunicipio" runat="server"/>
        <input type="hidden" id="hfUsuarioId" runat="server"/>
        <form id="form2" runat="server">
        <h1 class="text-center">Encuesta de caracterización</h1>
        <div class="center-block w60">
      <div class="formSteps">
        	<div class="step completed"><span class="glyphicon glyphicon-ok"></span>Paso 1</div>
            <div class="step completed"><span class="glyphicon glyphicon-ok"></span>Paso 2</div>
            <div class="step completed"><span class="glyphicon glyphicon-ok"></span>Paso 3</div>
            <div class="step completed"><span class="glyphicon glyphicon-ok"></span>Paso 4</div>
        </div>
        <div class="well">
        	<h1 class="text-center">Haz finalizado la encuesta</h1>
            <h1 class="text-center">¡Ya culminaste tu registro!</h1>
        	<p>Ahora eres un auditor Ciudadano básico, puedes seguir capacitándote para tener más puntuación y aparecer en el ranking.</p>
        </div>
        <div class="botonera text-center">
              <%--<div class="btn btn-default"><a href="">VOLVER AL PROYECTO</a></div>--%>
              <%--<div class="btn btn-primary"><a href="">Seguir Capacitándome <span class="glyphicon glyphicon-chevron-right"></span></a></div>--%>
              <div class="btn btn-primary" onclick="Reenviar('../Views/Capacitacion/CapacitacionInicialFaseI','dvPrincipal')">IR A CAPACITACIÓN INICIAL<span class="glyphicon"></span></div>
        </div>
    </div>
    </form>
    </div>

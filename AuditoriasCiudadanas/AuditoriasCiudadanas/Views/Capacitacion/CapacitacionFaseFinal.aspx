<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CapacitacionFaseFinal.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Capacitacion.CapacitacionFaseFinal" %>

<div class="container">
        <div class="center-block w60">
        <div class="formSteps">
        	<div class="step completed"><span class="glyphicon glyphicon-ok"></span>Paso 1</div>
            <div class="step completed"><span class="glyphicon glyphicon-ok"></span>Paso 2</div>
            <div class="step completed"><span class="glyphicon glyphicon-ok"></span>Paso 3</div>
            <div class="step completed"><span class="glyphicon glyphicon-ok"></span>Paso 4</div>
        </div>
        <div class="well">
        	<h1 class="text-center">¡Ya culminaste tu registro!</h1>
        	<p>Ahora eres un auditor Ciudadano básico, puedes seguir capacitándote para tener  más puntuación  y aparecer en el ranking.</p>
        </div>
        <!--BTN ACTIONS-->
        <div class="botonera text-center">
              <div class="btn btn-default" onclick="Reenviar('../Views/AccesoInformacion/BuscadorProyectosAuditores','dvPrincipal')"><a href="#">VOLVER AL PROYECTO</a></div>
              <div class="btn btn-primary" onclick="cargaMenu('Capacitacion/list_informacion','dvPrincipal')"><a href="#">Seguir Capacitándome <span class="glyphicon glyphicon-chevron-right"></span></a></div>
        </div>
        </div>
    </div>



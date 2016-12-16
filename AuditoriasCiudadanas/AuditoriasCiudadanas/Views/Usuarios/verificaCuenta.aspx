<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="verificaCuenta.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Usuarios.verificaCuenta" %>
<script src="../../Scripts/UsuariosFunciones.js"></script>
<script src="../../Scripts/UsuariosAcciones.js"></script>
 <!-- Page Content -->
 <div class="container">
    	<h1>Nuevo Usuario</h1>
        <div class="center-block w60">
        <div class="formSteps">
        	<div class="step currentStep"><span class="glyphicon glyphicon-edit"></span>Paso 1</div>
            <div class="step"><span class="glyphicon glyphicon-question-sign"></span>Paso 2</div>
            <div class="step"><span class="glyphicon glyphicon-user"></span>Paso 3</div>
            <div class="step"><span class="glyphicon glyphicon-equalizer"></span>Paso 4</div>
            <div class="step"><span class="glyphicon glyphicon-blackboard"></span>Paso 5</div>			
        </div>
        <div class="well text-center">
        <h2>Hemos enviado a tu correo un link de verificación, por favor revisa tu correo.</h2>
        </div>
            <div class="botonera">
                <div class="btn btn-default"><a role="button" id="btnVolverProy">VOLVER AL PROYECTO</a></div>
                <div class="btn btn-primary fr"><a role="button" id="btnVerificaCuenta" runat="server">Siguiente <span class="glyphicon glyphicon-chevron-right"></span></a></div>
            </div>
        </div>
    </div>

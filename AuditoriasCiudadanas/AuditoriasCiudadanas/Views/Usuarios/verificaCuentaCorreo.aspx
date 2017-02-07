<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="verificaCuentaCorreo.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Usuarios.verificaCuentaCorreo" %>
<link href="../../Content/bootstrap.min.css" rel="stylesheet" />
<link href="../../Content/logo-nav.css" rel="stylesheet" />
<link href="../../Content/screenView.css" rel="stylesheet" />
<link href="../../Content/jquery-ui.min.css" rel="stylesheet" />
 <!-- Page Content -->
<div class="container">
    <h1>Registro de usuario</h1>
    <div class="center-block w60">
        <input type="hidden" id="hdEnvio" runat="server" value="" />
         <div class="formSteps">
            <div class="step"><span class="glyphicon glyphicon-edit"></span>Paso 1</div>
            <div class="step"><span class="glyphicon glyphicon-question-sign"></span>Paso 2</div>
            <div class="step currentStep"><span class="glyphicon glyphicon-user"></span>Paso 3</div>
            <div class="step"><span class="glyphicon glyphicon-equalizer"></span>Paso 4</div>
           <%-- <div class="step"><span class="glyphicon glyphicon-blackboard"></span>Paso 5</div>--%>
        </div>
        <h1 class="text-center"><span class="glyphicon glyphicon-ok"></span>Correo verificado</h1>
        <div class="well text-center">
            <h2 id="textoVerifica" runat="server"></h2>
        </div>
        <div class="botonera">
            <%--<div class="btn btn-default"><a onclick="volver_proyecto()" role="button">VOLVER AL PROYECTO</a></div>--%>
            <div class="btn btn-primary fr"><a href="#" role="button" id="btnVerificaCuenta" runat="server">Siguiente <span class="glyphicon glyphicon-chevron-right"></span></a></div>
        </div>
    </div>
</div>
    <!-- /.container -->
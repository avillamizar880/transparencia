<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminEncuestaCaractGenerar.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Caracterizacion.AdminEncuestaCaractGenerar" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Generar Encuesta de Caracterización</title>
   
        <%-- Archivos CSS--%>
        <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
        <link href="../../Content/logo-nav.css" rel="stylesheet" />
        <link href="../../Content/screenView.css" rel="stylesheet" />
       
      <%-- Archivos JS--%>
        <script src="../../Scripts/jquery-1.12.4.min.js" type="text/javascript" ></script>
          <script src="../../Scripts/jquery-ui-1.12.1.js" type="text/javascript" ></script>
        <script src="../../Scripts/bootstrap.min.js"></script>
        <script src="../../Scripts/jquery.blockUI.js"></script>
        <script src="../../Scripts/EncuestaCaracterizacion.js" type="text/javascript"></script>  
</head>
<%--;ObtenerGeneros() onload="ObtenerMunicipios()"--%>
<body class="inside">
<div class="container-fluid">
    <!-- Navigation -->
    <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
        	<div class="container">
        	<div class="col-sm-6">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Desplegar</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="#">
                    <img src="../../Content/img/logo.png" alt="Auditorias ciudadanas"/>
                </a>
                <!-- SEARCH PROJECTS -->
                <div class="input-group">
                <input type="text" class="form-control" placeholder="Buscar Proyectos..."/>
                  <span class="input-group-btn">
                    <button class="btn btn-info" type="button"><span class="glyphicon glyphicon-search"></span></button>
                  </span>
                  
                </div>
            </div>
            </div>
            <div class="col-sm-6">
            	<div class="LogIn"><a href="#" class="btn btn-primary"><span class="glyphicon glyphicon-user"></span>Inicie Sesión</a><br/>
                    <a href="nuevoUsuarioTCP.html" target="_self">¿Nuevo usuario? Ingrese Aquí</a></div>
            </div>
            </div>
            <div class="row">
            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            	<div class="container">
                <ul class="nav navbar-nav">
                     <li>
                         <a href="projectInfo.html" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Administración<span class="glyphicon glyphicon-menu-down"></span></a>
                         <ul class="dropdown-menu">
                            <li><a href="">Capacitaciones</a></li>
                            <li><a href="../Administracion/CategoriasAuditor.aspx">Categorías Auditor</a></li>
                            <li><a href="">Enlaces de interés</a></li>
                            <li><a href="">Guías y manuales</a></li>
                            <li><a href="">Videos Instructivos</a></li>
                         </ul>
                     </li>
                      <li>
                        <a href="index.html">Consultar</a>
                     </li>
                    <li>
                        <a href="projectInfo.html" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Encuestas de Caracterización<span class="glyphicon glyphicon-menu-down"></span></a>
                         <ul class="dropdown-menu">
                          <li><a href="AdminEncuestaCaractCorte.aspx">Cortes de información</a></li>
                          <li><a href="AdminEncuestaCaractGenerar.aspx">Generar notificación</a></li>
                          <li><a href="AdminEncuestaCaractTerminar.aspx">Terminar encuestas</a></li>
                         </ul>
                    </li>
                    <li>
                         <a href="espacioVirtual.html">Información</a>
                    </li>
                    <li>
                        <a href="espacioVirtual.html">Publicar</a>
                    </li>
                </ul>
                </div>
            </div>
            </div>
            <!-- /.navbar-collapse -->
    </nav>
</div>

<%--GENERAR NOTIFICACIÓN--%>
<div class="container">
    <h1 class="text-center">Encuesta de Caracterización</h1>
    <h2 class="text-center">Generar notificación</h2>
    <div class="center-block w60">
        <div class="jumbotron">
          <div class="container">
                    <p>¿Está seguro de que desea enviar una notificación a todas las personas que no han realizado la encuesta de caracterización?</p>
                    <div class="botonera text-center">
                        <div class="btn btn-primary">Cancelar </div>
                        <div class="btn btn-primary">Generar Notificación </div>
                    </div>
          </div>
        </div>
    </div>
</div>

    <!-- FOOTER -->
<footer>
   <div class="container-fluid">
    	Todos los derechos Reservados
   </div>
</footer>

</body>
</html>

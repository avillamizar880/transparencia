<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategoriasAuditor.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Administracion.CategoriasAuditor" %>
<script type="text/javascript">
			$(document).ready(function() {
			    CargarTiposAuditor();
			});
</script>

<%--<body onload="CargarDatos()">
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
            	<div class="LogIn"><a href="" class="btn btn-primary"><span class="glyphicon glyphicon-user"></span>Inicie Sesión</a><br/>
                    <a href="nuevoUsuarioTCP.html">¿Nuevo usuario? Ingrese Aquí</a></div>
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
                              <li><a href="">Categorías Auditores</a></li>
                              <li><a href="">Enlaces de interés</a></li>
                              <li><a href="">Guías y manuales</a></li>
                              <li><a href="">Videos Instructivos</a></li>
                              <li><a href="">Usuarios</a></li>
                         </ul>
                    </li>
                    <li class="active">
                        <a href="profileProject.html">Consultar</a>
                    </li>
                    <li>
                        <a href="espacioVirtual.html" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Encuestas de Caracterización<span class="glyphicon glyphicon-menu-down"></span></a>
                         <ul class="dropdown-menu">
                          <li><a href="">Corte de información</a></li>
                          <li><a href="">Generar notificación</a></li>
                          <li><a href="">Terminar encuesta</a></li>
                         </ul>
                    </li>
                      <li>
                        <a href="projectInfo.html" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Información<span class="glyphicon glyphicon-menu-down"></span></a>
                         <ul class="dropdown-menu">
                          <li><a href="">Guías y manuales</a></li>
                          <li><a href="">Enlaces de interés</a></li>
                          <li><a href="">Videos Instructivos</a></li>
                          <li><a href="">Capacitaciones</a></li>
                         </ul>
                    </li>
                    <li>
                        <a href="espacioVirtual.html">Publicar</a>
                    </li>
                    <li>
                        <a href="../Administracion/BuscadorProyectosAuditores.aspx" class="glyphicon glyphicon-search"></a>
                    </li>
                    
                </ul>
                </div>
            </div>

            </div>
            <!-- /.navbar-collapse -->
    </nav>
	</div>--%>
        <!-- /.container -->
    <!-- Page Content -->
    <div class="container">
        <div class="row">
        	<h2 class="text-center">Categorías Auditor</h2>
            <div id="datos" class="list-group uppText"></div>
            <div class="btn btn-info" onclick="AnadirRegistro()"><a href="#"> <span class="glyphicon glyphicon-plus"></span>Añadir</a></div>
        </div>
    </div>
  <!-- FOOTER -->
<%--<footer>
    <div class="container-fluid">
    	Todos los derechos Reservados
    </div>
</footer>--%>

<%--VENTANA MODAL PARA AÑADIR FOTOGRAFÍA--%>
<div class="modal fade" id="ingresarActualizarRegistro" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"></div>
<%--</body>--%>
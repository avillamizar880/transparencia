<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuscadorProyectosAuditores.aspx.cs" Inherits="AuditoriasCiudadanas.Views.AccesoInformacion.BuscadorProyectosAuditores" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Búsqueda Proyectos o Auditores</title>
     <%-- Archivos CSS--%>
        <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
        <link href="../../Content/logo-nav.css" rel="stylesheet" />
        <link href="../../Content/screenView.css" rel="stylesheet" />
        <link href="../../Content/estilos_checkbox_sinradio.css" rel="stylesheet" />
       <%-- <link href="../../Content/jquery-ui.css" rel="stylesheet" />--%>
        <%-- <link href="../../Content/estilo_checkbox.css" rel="stylesheet" />--%>
      
       
      <%-- Archivos JS--%>
      <%--  <script src="../../Scripts/jquery-1.12.4.min.js" type="text/javascript" ></script>
        <script src="../../Scripts/bootstrap.min.js"></script>--%>
        <script src="../../Scripts/jquery-1.12.4.min.js" type="text/javascript" ></script>
        <script src="../../Scripts/jquery-ui-1.12.1.js" type="text/javascript" ></script>
        <script src="../../Scripts/jquery.blockUI.js" type="text/javascript" ></script>
        <script src="../../Scripts/bootstrap.min.js"></script>
        <script src="../../Scripts/BuscarProyectos.js" type="text/javascript"></script> 
        <script type="text/javascript" src="../../Scripts/ajaxPost.js"></script>        
</head>
<body class="inside" >
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
                    <button class="btn btn-info" onclick="BuscarProyectos()" type="button"><span class="glyphicon glyphicon-search"></span></button>
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
                        <a href="index.html">Inicio</a>
                    </li>
                    <li>
                        <a href="profileProject.html">Proyectos</a>
                    </li>
                    <li class="active">
                        <a href="projectInfo.html" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Información<span class="glyphicon glyphicon-menu-down"></span></a>
                         <ul class="dropdown-menu">
                          <li><a href="">Guías y manuales</a></li>
                          <li><a href="">Enlaces de interés</a></li>
                          <li><a href="">Videos Instructivos</a></li>
                          <li><a href="">Capacitaciones</a></li>
                         </ul>
                    </li>
                    <li>
                        <a href="espacioVirtual.html">Espacio virtual</a>
                    </li>
                    <li>
                        <a href="espacioVirtual.html">Usuario</a>
                    </li>
                     <li>
                        <a href="BuscardorProyectosAuditores.aspx" class="glyphicon glyphicon-search"></a>
                    </li>
                </ul>
                </div>
            </div>
            </div>
            <!-- /.navbar-collapse -->
    </nav>
</div>

 <div class="container">
    	<h1 class="text-center">Listado de proyectos</h1>
      <div class="input-group">
        <input id="txtPalabraClave" type="text" class="form-control" placeholder="Buscar Proyectos..."/>
        <span class="input-group-btn"><button class="btn btn-info" type="button" onclick="CargarProyectosAuditores()"><span class="glyphicon glyphicon-search"></span></button></span>
      </div>
      <div class="list-group">
      <div class="botonera text-center">
       <div class="wrap">
			<form action="" class="formulario">
			<div class="radio">
				<input type="radio" checked="checked" name="buscar" id="r_Proyectos">
				<label for="Proyectos">Proyectos</label>

                <input type="radio" name="buscar" id="r_Auditores">
				<label for="Auditores">Auditores</label>
			</div>
            </form>
      </div>
      </div>
      </div>
      <div id="datos" class="list-group uppText"></div>
      <nav aria-label="Page navigation">
              <ul class="pagination">
                <li>
                  <a href="#" aria-label="Previous">
                    <span aria-hidden="true">&laquo;</span>
                  </a>
                </li>
                <li><a href="#">1</a></li>
                <li><a href="#">2</a></li>
                <li><a href="#">3</a></li>
                <li><a href="#">4</a></li>
                <li><a href="#">5</a></li>
                <li>
                  <a href="#" aria-label="Next">
                    <span aria-hidden="true">&raquo;</span>
                  </a>
                </li>
              </ul>
            </nav>
</div>
 
<footer>
    <div class="container-fluid">
    	Todos los derechos Reservados
    </div>
</footer>

</body>
</html>
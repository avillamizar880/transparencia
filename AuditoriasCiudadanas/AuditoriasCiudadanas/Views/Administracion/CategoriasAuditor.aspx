<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategoriasAuditor.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Administracion.CategoriasAuditor" %>

<!DOCTYPE html>
<html lang="es">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>Categorías Auditor</title>
        <%-- Archivos CSS--%>
        <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
        <link href="../../Content/logo-nav.css" rel="stylesheet" />
        <link href="../../Content/screenView.css" rel="stylesheet" />
        <link href="../../Content/fileinput.css" rel="stylesheet" />
       
      <%-- Archivos JS--%>
        <script src="../../Scripts/jquery-1.12.4.min.js" type="text/javascript" ></script>
        <script src="../../Scripts/jquery-ui-1.12.1.js" type="text/javascript" ></script>
        <script src="../../Scripts/jquery.blockUI.js" type="text/javascript" ></script>
        <script src="../../Scripts/bootstrap.min.js"></script>
        <script src="../../Scripts/fileinput.js" type="text/javascript" ></script>
        <%--<script type="text/javascript" src="../../Scripts/principal.js"></script>--%>
        <%--<script type="text/javascript" src="../../Scripts/ajaxPost.js"></script>--%>
        <script src="../../Scripts/CategoriaAuditor.js" type="text/javascript"></script> 
      <%--  <script type="text/javascript">
            data = {};
            $("#guardarRegistro").on("click", function (e) {
                e.preventDefault(); // prevent de default action, which is to submit
                // save your value where you want
                data.select = $("#txtLimiteInferior").val();
                // or call the save function here
                // save();
                $(this).prev().click();
            });
        </script> --%>

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>

<body onload="CargarDatos()">
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
	</div>
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
<footer>
    <div class="container-fluid">
    	Todos los derechos Reservados
    </div>
</footer>

<%--VENTANA MODAL PARA AÑADIR FOTOGRAFÍA--%>
<div class="modal fade" id="ingresarActualizarRegistro" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            <h4 class="modal-title" id="myModalLabel">Agregar Imagen</h4>
          </div>
          <div class="modal-body">
            <label class="modal-title" hidden="hidden" id="idTipoAuditor">0</label><br />
            <label class="modal-title">Agregar Imagen</label><br />
            <%--<input id="input-702"  name="kartik-input-702[]" type="file" multiple=true class="file-loading">--%>
            <input id="imagenTipoAuditor" class="file-loading" type="file" >
            <div id="errorImagen" class="alert alert-danger alert-dismissible" hidden="hidden" >El nombre de la imagen no puede ser vacío.</div>
            <br/>
            <label class="modal-title">Categoría Auditor</label><br />
            <input id="txtNombre" type="text" placeholder="Ingrese el nombre de la categoría...." size="50" />
            <br />
            <div id="errorNombre" class="alert alert-danger alert-dismissible" hidden="hidden" >El nombre de la categoría no puede ser vacío.</div>
            <br/>
            <label class="modal-title">Límite inferior</label> <input id="txtLimiteInferior" type="number" value="0"/>
            <br />
            <div id="errorLimiteInferior" class="alert alert-danger alert-dismissible" hidden="hidden" >El límite inferior debe ser mayor a los existentes en las otras categorías.</div>
            <br/>
            <label class="modal-title">Límite superior</label> <input id="txtLimiteSuperior" type="number" value="1"/>
            <br />
            <div id="errorLimiteSuperior" class="alert alert-danger alert-dismissible" hidden="hidden" >El límite superior no puede ser menor al límite inferior.</div>
            <br/>
            <label class="modal-title">Descripción</label><br />
            <input id="txtDescripcion" type="text" placeholder="Ingrese la descripción de la categoría...." size="50"/>
            <br />
            <div id="errorDescripcion" class="alert alert-danger alert-dismissible" hidden="hidden" >El caracter * no está permitido. Por favor elimine este caracter de la casilla descripción.</div>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
            <button type="button" class="btn btn-primary" onclick=" GuardarRegistro()">Guardar</button>
            <%--CREAR FUNCIÓN PARA AGREGAR EL METODO ONSUBMIT PARA VALIDAR LOS INPUT--%>
          </div>
        </div>
      </div>
    </div>
</body>
</html>

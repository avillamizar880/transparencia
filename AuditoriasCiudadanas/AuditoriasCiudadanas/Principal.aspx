<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="AuditoriasCiudadanas.Principal" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="es"> 
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Auditorías Ciudadanas</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- Custom CSS -->
    <link href="Content/logo-nav.css" rel="stylesheet" type="text/css" />
    <link href="Content/screenView.css" rel="stylesheet" type="text/css" />
    <link href="Content/estilos_checkbox_sinradio.css" rel="stylesheet" type="text/css" />
    <link href="Content/fileinput.css" rel="stylesheet" type="text/css" />
    <link href="Content/bootstrap-datetimepicker.css" rel="stylesheet" />
    <link href="Content/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    <link href="Content/jquery-ui.min.css" rel="stylesheet" />
    <!-- Custom js -->
    <script src="Scripts/jquery-1.12.4.min.js" type="text/javascript"></script>
<%--    <script src="Scripts/jquery-ui-1.12.1.js" type="text/javascript"></script>--%>
    <script src="Scripts/jquery-ui-1.12.1.min.js"></script>
    <script src="Scripts/jquery.blockUI.js" type="text/javascript"></script>
    <script src="Scripts/jquery.smartmenus.min.js" type="text/javascript"></script>
    <script src="Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="Scripts/bootstrap3-typeahead.min.js" type="text/javascript" ></script>
    <script src="Scripts/bootbox.min.js"></script>
    <script src="Scripts/responsive-tabs.js" type="text/javascript"></script>
    <script src="Scripts/tinymce/tinymce.min.js" type="text/javascript"></script>
    <script src="Scripts/ajaxPost.js" type="text/javascript"></script>
    <script src="Scripts/Principal.js" type="text/javascript"></script>
    <script src="Scripts/BuscarProyectos.js" type="text/javascript"></script> 
    <script src="Scripts/PlanTrabajo.js" type="text/javascript"></script>
    <script src="Scripts/DetalleTarea.js" type="text/javascript"></script>
    <script src="Scripts/CategoriaAuditor.js" type="text/javascript"></script> 
    <script src="Scripts/EncuestaCaracterizacion.js" type="text/javascript"></script> 
    <script src="Scripts/fileinput.js" type="text/javascript"></script>
    <script src="Scripts/es.js"></script>
    <script src="Scripts/ProyectosFunciones.js" type="text/javascript"></script>
    <script src="Scripts/ProyectosAcciones.js" type="text/javascript"></script> 
    <script src="Scripts/GrupoAuditorCiudadano.js" type="text/javascript"></script>
    <script src="Scripts/EvaluarExperiencia.js" type="text/javascript"></script> 
    <script src="Scripts/ReporteHallazgo.js" type="text/javascript"></script> 
    <script src="Scripts/bootstrap-datetimepicker.js"></script>
    <script src="Scripts/bootstrap-datetimepicker.es.js"></script>
    <script src="Scripts/AutoevaluacionAC.js" type="text/javascript"></script> 
    <script src="Scripts/CategoriaAuditor.js" type="text/javascript"></script> 
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
                <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
                <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
            <![endif]-->
</head>
<body>
    <div class="container-fluid">
        <!-- Navigation -->
        <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
            <div class="container headBar">
                <div class="col-sm-9">
                    <!-- Brand and toggle get grouped for better mobile display -->
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                            <span class="sr-only">Desplegar</span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                         <a class="navbar-brand" href="https://www.dnp.gov.co" target="_blank">
                            <img src="Content/img/logo_link0.png" alt="Departamento Nacional de Planeacion" />
                        </a>
                        <a class="navbar-brand" href="#">
                            <img src="Content/img/logo.png" alt="Auditorías ciudadanas" />
                        </a>
                       <%-- <a class="navbar-brand" href="#">
                            <img src="Content/img/logo_gobCol.png" alt="Gobierno de Colombia" />
                        </a>--%>
                        <!-- SEARCH PROJECTS -->
                       <%-- <div class="input-group">
                            <input type="text" class="form-control" placeholder="Buscar Proyectos...">
                            <span class="input-group-btn">
                                <button class="btn btn-info" type="button"><span class="glyphicon glyphicon-search"></span></button>
                            </span>

                        </div>--%>
                    </div>
                </div>
                <div class="col-sm-3">
                    <div class="LogIn" menu="" nombre="" runat="server" id="btnSes">
                        <button id="btnLogIn" class="btn btn-primary" type="button" data-toggle="collapse" data-target="#collapseLogin" aria-expanded="false" aria-controls="collapseLogin">
                            INICIE SESIÓN
                        </button>
                        <br id="brLogIn" />
                        <a id="btnNewUsr"role="button" onclick="nuevoUsuario();">¿Nuevo usuario? Ingrese Aquí</a>
                         <button id="btnLogOut" class="btn btn-primary" type="button" data-toggle="collapse" data-target="" aria-expanded="false" aria-controls="collapseLogin" onclick="cerrarSesion();">
                            CERRAR SESIÓN
                        </button>
                        <br id="brLogOut" />
                    </div>
                    <!-- COLLAPSED logIn FORM-->
                    <div class="logHiddenForm">
                        <div class="collapse" id="collapseLogin">
                            <div class="logForm">
                                <form>
                                    <div class="form-group">
                                        <label for="user" class="hidden">Correo</label>
                                        <input type="text" class="form-control" id="userName" placeholder="Usuario">
                                    </div>
                                    <div class="form-group">

                                        <input type="password" class="form-control" id="pass" placeholder="Contraseña">
                                    </div>
                                    <div class="btn btn-info "><a role="button" onclick="validaLogin();">INGRESAR <span class="glyphicon glyphicon-log-in"></span></a></div>
                                    <div class="">
                                        <a onclick="olvidoClave();" role="button" class="small">Olvid&eacute; la contraseña</a>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <!-- Collect the nav links, forms, and other content for toggling -->
                <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                    <div class="container">
                        <ul class="nav navbar-nav" id="menuCiudadano">
                           <%-- <li>
                                <a role="button">Inicio</a>
                            </li>--%>
                            <li class="active">
                                <a role="button" onclick="cargaMenu('AccesoInformacion/BuscadorProyectosAuditores','dvPrincipal')">Proyectos</a>
                            </li>
                       <%--     <li>
                                <a href="projectInfo.html" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Información<span class="glyphicon glyphicon-menu-down"></span></a>
                                <ul class="dropdown-menu">
                                    <li><a href="">Guías y manuales</a></li>
                                    <li><a href="">Enlaces de interés</a></li>
                                    <li><a href="">Videos Instructivos</a></li>
                                    <li><a href="">Capacitaciones</a></li>
                                </ul>
                            </li>
                            <li>
                                <a href="#">Espacio virtual</a>
                            </li>--%>
                            <li id="menu-user">
                                 <a role="button" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false" id="usrName">Cuenta<span class="glyphicon glyphicon-menu-down"></span></a>
                                 <ul class="dropdown-menu">
                                    <li><a role="button" onclick="cambioClave();" id="cambiarClaveUsu">Cambiar Clave</a></li>
                                    <li><a role="button" onclick="CuentaUsu();" id="verCuentaUsu">Ver Cuenta</a></li>
                                    <li><a role="button" onclick="actualizaDatos();" id="btnactualizaDatos">Actualizar Datos</a></li>
                                </ul>
                            </li>
                            <li id="menu-admin"  >
                                 <a role="button" aria-haspopup="true" aria-expanded="false" onclick="cambioAdmin()">Administración</a>
                            </li>
                            <li  id="menu-tec" >
                                 <a role="button" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false" id="usrName">Técnico DNP<span class="glyphicon glyphicon-menu-down"></span></a>
                                 <ul class="dropdown-menu">
                                    <li><a role="button" onclick="cargaMenu('Audiencias/RegistrarFechaAud','dvPrincipal')">Registrar Audiencia</a></li>
                                    <li><a role="button" onclick="cargaMenu('Estadisticas/InfoEstadisticas','dvPrincipal')">Ver Estadísticas</a></li>
                                </ul>
                                
                            </li>                            
                        </ul>
                        <ul class="nav navbar-nav hideObj" id="menuAdmin">
                            <li >
                                <a href="projectInfo.html" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Administración<span class="glyphicon glyphicon-menu-down"></span></a>
                                 <ul class="dropdown-menu">
                                      <li class="active"><a role="button" onclick="cargaMenu('Administracion/CategoriasAuditor','dvPrincipal')">Categorías Auditores</a></li>
                                       <li><a role="button" onclick="cargaMenu('Audiencias/RegistrarFechaAud','dvPrincipal')">Registrar Audiencia</a></li>
                                      <li><a role="button" id="btncrearUsuariosPerfil" onclick="cargaMenu('Usuarios/crearUsuarios','dvPrincipal')">Crear Usuarios</a></li>
                                      
                                      <li><a role="button" id="btnGeneraEncuestas" onclick="cargaMenu('Valoracion/configuraEncuestas?opc=2','dvPrincipal')">Configuración Ayuda</a></li>
                                 </ul>
                            </li>
                           <li>
                                <a href="espacioVirtual.html" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Encuestas de Caracterización<span class="glyphicon glyphicon-menu-down"></span></a>
                                 <ul class="dropdown-menu">
                                  <li><a role="button" onclick="cargaMenu('Caracterizacion/AdminEncuestaCaractCorte','dvPrincipal')">Corte de Información</a></li>
                   <%--               <li><a role="button" onclick="cargaMenu('Caracterizacion/AdminEncuestaCaractGenerar','dvPrincipal')">Generar notificación</a></li>
                                  <li><a role="button" onclick="cargaMenu('Caracterizacion/AdminEncuestaCaractTerminar','dvPrincipal')">Terminar encuestas</a></li>--%>
                                 </ul>
                            </li>
<%--                              <li>
                                <a href="projectInfo.html" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Información<span class="glyphicon glyphicon-menu-down"></span></a>
                                 <ul class="dropdown-menu">
                                  <li><a role="button">Guías y manuales</a></li>
                                  <li><a role="button">Enlaces de interés</a></li>
                                  <li><a role="button">Videos Instructivos</a></li>
                                  <li><a role="button">Capacitaciones</a></li>
                                 </ul>
                            </li>--%>
                         <%--   <li>
                                <a role="button">Publicar</a>
                            </li>--%>
                           <%-- <li>
                                <a href="../Administracion/BuscadorProyectosAuditores.aspx" class="glyphicon glyphicon-search"></a>
                            </li>--%>
                            <li>
                                <a role="button" aria-haspopup="true" aria-expanded="false" onclick="cambioUser()">Principal</a>
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
    <div class="container" id="dvPrincipal" runat="server">

    </div>
    <div id="divDatos">
        <input type="hidden" id="hdOpc" value="" runat="server" />
        <input type="hidden" id="hdIdUsuario" value="" runat="server" />
    </div>
    <!-- /.container -->
    <!-- FOOTER -->
    <div class="entidades">
    	<div class="container">
        	
        	<a href="https://www.dnp.gov.co" target="_blank"><img src="Content/img/logo_link0.png"/></a>
            <a href="https://www.sgr.gov.co" target="_blank"><img src="Content/img/logo_link2.png"/></a>
            <a href="http://www.transparenciacolombia.org.co" target="_blank"><img src="Content/img/logo_link3.png"/></a>
            <a href="http://es.presidencia.gov.co" target="_blank"><img src="Content/img/logo_link1.png"/></a>
            <a href="#"><img src="Content/img/logo_link4.png"/></a>
    </div>
    </div>
    <footer>
        <div class="container-fluid">
            Todos los derechos Reservados
    
        </div>
    </footer>
    <div id='dialog' title=''></div>
    <script type="text/javascript">
        if ($(document).ready(function () {
            var opc = $("#hdOpc").val();
            if (opc == "") {
              cargaMenu('AccesoInformacion/BuscadorProyectosAuditores', 'dvPrincipal');
        } else {
             cargaMenu('Caracterizacion/EncuestaParte1', 'dvPrincipal');
        }
            
            validaSession();
        }));
</script>
    <iframe id="ifrmPDF" class="hide"> </iframe>
</body>
</html>

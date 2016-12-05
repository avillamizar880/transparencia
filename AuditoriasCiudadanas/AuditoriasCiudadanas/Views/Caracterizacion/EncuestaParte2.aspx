<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EncuestaParte2.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Caracterizacion.EncuestaParte2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Encuesta de Caracterización</title>

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
<body class="inside" onload="InicializarCajasTexto()">

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
                </ul>
                </div>
            </div>
            </div>
            <!-- /.navbar-collapse -->
    </nav>
</div>

<div class="container">
        <form id="form2" runat="server">
        <h1 class="text-center">Encuesta de Caracterización</h1>
        <div class="center-block w60">
     <div class="formSteps">
        	<div class="step"><span class="glyphicon glyphicon-edit"></span>Paso 1</div>
            <div class="step currentStep"><span class="glyphicon glyphicon-question-sign"></span>Paso 2</div>
            <div class="step"><span class="glyphicon glyphicon-user"></span>Paso 3</div>
            <div class="step"><span class="glyphicon glyphicon-equalizer"></span>Paso 4</div>
            <div class="step"><span class="glyphicon glyphicon-blackboard"></span>Paso 5</div>			
     </div>
     <div class="form-group">
        <label for="lbVinculacionActual">Por favor indique la(s) organización(es) o instancia(s) con la(s) que actualmente tiene vinculación:</label>
        <select id="selVinculacionActual" class="form-control" onchange="SeleccionarItem('VinculacionActual')">
            <option>Junta de Acción Comunal</option>
            <option>Consejo Territorial de Planeación</option>
            <option>Comité de Desarrollo y Control Social de los Servicios Públicos Domiciliarios</option>
            <option>Gobierno escolar</option>
            <option>Comité Consultivo del OCAD</option>
            <option>Consejo Municipal o Departamental de Participación Ciudadana</option>
            <option>Alianzas para la Prosperidad</option>
            <option>Actualmente me desempeño como funcionario público</option>
            <option>Ninguna</option>
            <option>Otra, ¿cuál?</option>
          </select>
          <%--revisar como hacer para que aparezca el cuadro y poder escribir en la opción de otra, cual?--%>
           <input id="txtVinculacionActual" type="text" class="form-control" onkeydown="CambioTexto('errorVinculacionActual')" hidden="hidden" />
           <div id="errorVinculacionActual" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor ingrese cual es la otra organización(es) o instancia(s) a la que esta vinculado. Este campo es requerido.</div>
     </div>
     <div class="form-group">
                <label for="lbMecanismosParticipacion">Por favor seleccione los mecanismos de participación ciudadana que ha promovido o en los que ha participado en los últimos tres años:</label>
                <select id="selMecanismosParticipacion" class="form-control" onchange="SeleccionarItem('MecanismosParticipacion')">
                    <option>Voto para elecciones presidenciales</option>
                    <option>Voto para elecciones departamentales</option>
                    <option>Voto para elecciones municipales</option>
                    <option>Voto para elecciones legislativas</option>
                    <option>Consulta popular</option>
                    <option>Cabildo abierto</option>
                    <option>Revocatoria del mandato</option>
                    <option>Referendo</option>
                    <option>Otra, ¿cuál?</option>
                </select>
                <input id="txtMecanismosParticipacion" type="text" class="form-control" required="required" onkeydown="CambioTexto('errorMecanismosParticipacion')" />
                <div id="errorMecanismosParticipacion" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor ingrese cual es el otro mecanismo de participación ciudadana que ha participado. Este campo es requerido.</div>
            </div>
            
       
     <div class="form-group">
        <label for="lblEspacioCiudadanoFuncionario">Por favor seleccione los espacios en los que ha participado como ciudadano o funcionario público durante los últimos tres años en su municipio:</label>
        <select id="selEspacioCiudadanoFuncionario" class="form-control" onchange="SeleccionarItem('EspacioCiudadanoFuncionario')">
            <option>Audiencia pública</option>
            <option>Foro ciudadano</option>
            <option>Mesas de diálogo</option>
            <option>Asambleas comunitarias</option>
            <option>Otra, ¿cuál?</option>
            <option>Ninguno</option>
        </select>
        <input id="txtEspacioCiudadanoFuncionario" type="text" class="form-control" onkeydown="CambioTexto('errorEspacioCiudadanoFuncionario')"/>
        <div id="errorEspacioCiudadanoFuncionario" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor ingrese cual es el otro espacio en el que ha participado como ciudadano o funcionario público. Este campo es requerido.</div>
     </div>   
     
     <div class="form-group">
        <label for="lblRecursosAlcaldia">¿La Alcaldía cuenta con recursos destinados para la promoción de la participación ciudadana en su territorio?</label>
        <select id="selRecursosAlcaldia" class="form-control">
            <option>Sí</option>
            <option>No</option>
            <option>No sé</option>
        </select>
     </div>
     
     <div class="form-group">
        <label for="lblAuditoriasVisibles">¿El DNP ha adelantado Auditorías Visibles en su municipio?</label>
        <select id="selAuditoriasVisibles" class="form-control">
            <option>Sí</option>
            <option>No</option>
            <option>No sé</option>
        </select>
     </div>
    </div>

    <div class="botonera text-center" >
        <div class="btn btn-default">
            <a>Volver al proyecto</a>
        </div>
        <div class="btn btn-primary" onclick="Siguiente('2')">Siguiente <span class="glyphicon glyphicon-chevron-right"></span>
        </div>
    </div>
    </form>
    </div>
    <!-- FOOTER -->
	<footer>
    <div class="container-fluid">
    	Todos los derechos Reservados
    
    </div>
    </footer>

</body>
</html>


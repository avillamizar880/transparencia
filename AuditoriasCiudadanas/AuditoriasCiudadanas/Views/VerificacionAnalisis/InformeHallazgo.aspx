<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InformeHallazgo.aspx.cs" Inherits="AuditoriasCiudadanas.Views.GrupoAuditor.InformeHallazgo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Hallazgos</title>
      <%-- Archivos CSS--%>
        <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
        <link href="../../Content/logo-nav.css" rel="stylesheet" />
        <link href="../../Content/screenView.css" rel="stylesheet" />
       
      <%-- Archivos JS--%>
        <script src="../../Scripts/jquery-1.12.4.min.js" type="text/javascript" ></script>
        <script src="../../Scripts/bootstrap.min.js"></script>
        <%--<script type="text/javascript" src="../../Scripts/principal.js"></script>--%>
       <%-- <script type="text/javascript" src="../../Scripts/ajaxPost.js"></script>--%>
        <%--<script src="../../Scripts/EncuestaCaracterizacion.js" type="text/javascript"></script> --%> 
    <%--  --%>
</head>
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
                <input type="text" class="form-control" placeholder="Buscar Proyectos...">
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
                    
                </ul>
                </div>
            </div>
            </div>
            <!-- /.navbar-collapse -->
    </nav>

</div>


    
    <h1  class="text-center">Informe de Hallazgos</h1>
    <div class="center-block w60">
        <div class="form-group">
            <h4 class="text-center">Para tener en cuenta:</h4>
            Los hallazgos son hechos o acciones que ponen en riesgo la ejecución de los proyectos, estos pueden presentarse en cualquier momento del proceso por los cual se deben tomar medidas preventivas.  Se diseñó el presente formato con el fin de generar una alertar al Sistema de Seguimiento, Monitoreo, Evaluación y Control del DNP y la Entidad Ejecutora del proyecto, los cuales deben contestar al ciudadano en al menos 30 días hábiles.  </p>
        </div>
        <div class="form-group">
                <h4 class="text-center">Haga un registro fotográfico o documental que respalde el hallazgo.</h4>
                Si es una fotografía: Muestre los detalles más relevantes del proyecto que generan posibles comentarios a resaltar.
                Nombre, lugar, fecha y descripción
                 <div class="botonera text-center">
                        <%--<div class="btn btn-default"><a href="">VOLVER AL PROYECTO</a></div>--%>
                        <div class="btn btn-primary"><a href="EncuestaCaractParte2.aspx">Cargue aquí la fotografía o documento <span class="glyphicon glyphicon-chevron-right"></span></a></div>
                 </div>
        </div>
        <div class="form-group">
            Previo a la redacción del hallazgo verifique la siguiente información:
             <ul>
                <li>La programación de actividades del proyecto y su estado de ejecución.</li>
                <li>Los contratos que están asociados al proyecto y que posiblemente se estén incumpliendo.</li>
                <li>El presupuesto del proyecto</li>
                <li>El número de beneficiarios que estarían siendo afectados por el riesgo del proyecto.</li>
             </ul>
             Conteste las siguientes preguntas para redactar el hallazgo:
             El hecho u acción riesgoso está relacionada con las siguientes conductas:
              <ol>
                <li>Riesgo que genera daño al patrimonio público</li>
                <li>Riesgos generados por actuación de funcionarios públicos</li>
                <li>Riesgo frentes a la ejecución correcta de los recursos </li>
                <li>Riesgo que perjudican la correcta ejecución de un contrato asociado al proyecto</li>
                <li>Otro, ¿Cuál?</li>
              </ol>
              ¿Desde cuándo se viene presentando el hecho riesgoso?
               <ol>
                    <li>El último mes</li>
                    <li>Durante dos meses consecutivos</li>
                    <li>Tres meses sin recibir ningún tipo de respuesta o resarcimiento del hecho</li>
                    <li>Cuatro meses por los cual el riesgo es casi inminente. </li>
               </ol>
               Señale en las siguientes opciones cuál está directamente relacionada con su hallazgo:
               <ol>
                    <li>Calidad de los materiales del proyecto</li>
                    <li>Cumplimiento del cronograma del proyecto</li>
                    <li>Cambios de presupuesto sin respaldo o información</li>
                    <li>Omisión de información o responsabilidades por parte de la entidad ejecutora o el interventor del proyecto</li>
                    <li>Cumplimiento en las metas </li>
                    <li>Otro, ¿Cuál?</li>
               </ol>

        </div>
        <div class="form-group">
            <h4 class="text-center">En el siguiente recuadro redacte de manera detallada porqué su hallazgo pone en riesgo la ejecución del proyecto o cuál sería la afectación para la comunidad (200 palabras) </h4>
            <input id="txtHallazgo" type="text" placeholder="Redacte su hallazgo aquí" class="form-control" />
        </div>
        <div class="form-group">
            <h4 class="text-center">Para tener en cuenta:</h4>
            En el caso que su hallazgo no tenga respuesta, esta no sea satisfactoria o permanezca el hecho riesgoso puede realizar una denuncia a la entidad competente. Si requiere asesoría y acompañamiento para su denuncia Transparencia por Colombia ha dispuesto la Aplicación DILO AQUÍ, para brindar acompañamiento y asistencia técnica a la ciudadanía que desea realizar denuncias.
        </div>
        <div class="botonera text-center">
            <div class="btn btn-primary">
            <a href="pagina.html">Enviar<span class="glyphicon glyphicon-chevron-right"></span></a>
        </div>
        </div>
    </div>
</body>
</html>

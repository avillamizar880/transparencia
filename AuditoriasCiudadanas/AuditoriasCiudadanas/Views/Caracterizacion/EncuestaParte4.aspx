<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EncuestaParte4.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Caracterizacion.EncuestaParte4" %>

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

<div class="container">
        <form id="form2" runat="server">
        <h1 class="text-center">Encuesta de Caracterización</h1>
        <div class="center-block w60">
     <div class="formSteps">
        	<div class="step currentStep"><span class="glyphicon glyphicon-edit"></span>Paso 1</div>
            <div class="step currentStep"><span class="glyphicon glyphicon-question-sign"></span>Paso 2</div>
            <div class="step currentStep"><span class="glyphicon glyphicon-user"></span>Paso 3</div>
            <div class="step"><span class="glyphicon glyphicon-equalizer"></span>Paso 4</div>
            <div class="step"><span class="glyphicon glyphicon-blackboard"></span>Paso 5</div>			
     </div>
     <div class="form-group">
            <label for="lblFrecuenciaDenunciasComunicacion">¿Con qué tanta frecuencia la comunidad o las organizaciones sociales de su municipio remiten hallazgos o denuncias a medios de comunicación nacionales?</label>
            <select id="selFrecuenciaDenunciasComunicacion" class="form-control">
                <option>Siempre</option>
                <option>Regularmente</option>
                <option>A veces</option>
                <option>Casi nunca</option>
                <option>Nunca</option>
            </select>
         </div>
     <div class="form-group">
                <label for="lblRadicaciónDerechoPeticion">Durante el año 2016, ¿usted ha radicado/presentado o ha tramitado una respuesta a al menos un derecho de petición donde se solicita el acceso a información específica o algún documento particular del municipio?</label>
                <select id="selRadicaciónDerechoPeticion" class="form-control">
                    <option>Sí</option>
                    <option>No</option>
                    <option>No sé</option>
                </select>
             </div>
     <div class="form-group">
                <label for="lblFacilidadAccesoInfo">Desde  su experiencia, por favor califique la facilidad con la que se puede acceder a la información pública del municipio para hacer seguimiento a la gestión o proyectos de las autoridades locales, de acuerdo con las siguientes opciones:</label>
                <select id="selFacilidadAccesoInfo" class="form-control">
                    <option>Es muy difícil acceder a la información pública del municipio. Generalmente los ciudadanos deben recurrir a derechos de petición para acceder a información</option>
                    <option>Es relativamente fácil acceder a la información pública del municipio. Generalmente se encuentra disponible o se entrega sin mayores obstáculos a la ciudadanía</option>
                    <option>Es fácil acceder a la información pública del municipio, pues se encuentra publicada en sitios web o documentos impresos de fácil acceso</option>
                </select>
             </div>
     <div class="form-group">
                <label for="lblEvaluacionesInternas">La organización civil o instancia de participación con la que actualmente tiene o ha tenido vinculación, ¿ha hecho evaluaciones o reflexiones internas sobre su propia gestión?</label>
                <select id="selEvaluacionesInternas" class="form-control">
                    <option>Sí</option>
                    <option>No</option>
                    <option>No sé</option>
                </select>
             </div>
     <div class="form-group">
            <label for="lblDifusionResultados">La organización civil o instancia de participación con la que actualmente tiene o ha tenido vinculación, ¿ha difundido los resultados de su labor con la comunidad en general?</label>
            <select id="selDifusionResultados" class="form-control">
                <option>Sí</option>
                <option>No</option>
                <option>No sé</option>
            </select>
         </div>
     <div class="form-group">
                <label for="lblCambiosGestion">¿La labor de control social de las organizaciones sociales o instancias de participación ha motivado algún cambio en la gestión o proyectos de las autoridades locales?</label>
                <select id="selCambiosGestion" class="form-control" onchange="SeleccionarItem('CambiosGestion')">
                    <option>Sí, ¿podrá indicar uno o dos ejemplos?</option>
                    <option>No</option>
                    <option>No sé</option>
                </select>
                <input id="txtCambiosGestion" type="text" class="form-control" onkeydown="CambioTexto('errorCambiosGestion')"/>
                <div id="errorCambiosGestion" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor indique uno o dos ejemplos. Este campo es requerido.</div>
             </div>
     <div class="form-group">
                <label for="lblFrecuenciaSeguimiento">Desde su experiencia, por favor califique la frecuencia con la que se hacen ejercicios de seguimiento a lo público o de control social sobre la gestión de las autoridades locales en su municipio:</label>
                <select id="selFrecuenciaSeguimiento" class="form-control">
                    <option>Nunca o rara vez se hacen ejercicios de control social en el municipio</option>
                    <option>Sólo cuando hay otras entidades o instancias nacionales o regionales acompañando el proceso (por ejemplo, el Departamento Nacional de Planeación, el CSIR, PNUD, entre otros.)</option>
                    <option>De forma permanente y sin la necesidad de otras entidades o instancias acompañantes (por ejemplo, el Departamento Nacional de Planeación, el CSIR, PNUD, entre otros.)</option>
                </select>
             </div>
  </div>
    <div class="botonera text-center" >
        <div class="btn btn-default">
            <a>Volver al proyecto</a>
        </div>
        <div class="btn btn-primary" onclick="Siguiente('4')">Siguiente <span class="glyphicon glyphicon-chevron-right"></span>
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
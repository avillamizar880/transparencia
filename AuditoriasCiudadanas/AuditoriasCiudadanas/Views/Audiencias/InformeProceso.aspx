<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InformeProceso.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Audiencias.InformeProceso" %>
<!-- Custom CSS -->
<link href="../../Content/bootstrap.min.css" rel="stylesheet" />
<link href="../../Content/logo-nav.css" rel="stylesheet" />
<link href="../../Content/screenView.css" rel="stylesheet" />
<link href="../../Content/bootstrap-datetimepicker.min.css" rel="stylesheet" />
<script src="../../Scripts/jquery-1.12.4.min.js"></script>
<script src="../../Scripts/bootstrap.min.js"></script>
<script src="../../Scripts/bootstrap-datetimepicker.js"></script>
<script src="../../Scripts/bootstrap-datetimepicker.es.js"></script>
<script src="../../Scripts/jquery.blockUI.js"></script>
<script src="../../Scripts/ajaxPost.js"></script>
<!DOCTYPE html>


<div class="container">
    <h1>Informe previo</h1>
     <div class="w60 center-block">
         <div class="form-group">
                         <h4 class="text-center">Para tener en cuenta:</h4>
            Durante la Audiencia de Seguimiento el Grupo Auditor Ciudadano deberá realizar su rendición de cuentas a la comunidad, en este sentido debe presentar cuál ha sido su gestión para hacer seguimiento al proyecto. 
Este formato incluye el cumplimiento del Plan de Trabajo del Grupo Auditor Ciudadano y los resultados del seguimiento al proyecto, por medio de la utilización de herramientas como: diarios de campo, visitas de campo, reuniones con actores, fotografías y entrevistas.
             <label for="txtTareasGrupo">¿Cuáles son las principales tareas del Plan de Trabajo realizadas que deben ser presentadas en la Audiencia de Seguimiento?</label>
             En el siguiente cuadro debe tener el plan de trabajo proyectado para la fase comprendida entre la Audiencia de inicio y la Audiencia de seguimiento, con el fin de reportar las tareas que planeó el Grupo Auditor Ciudadano y los resultados u observaciones en cumplimiento de las mismas. 
             <div id ="divTablaTareasGrupo"></div>

             <label for="txtActividadesProy">¿Cuál es el avance de cada una de las actividades del proyecto?</label>
             Haga una reflexión sobre las actividades del proyecto al cual está haciendo seguimiento, si estas se cumplieron por el contratista y de qué forma, comparando cronogramas, actividades y presupuesto.
             <div id ="divActividadesProy"></div>

            <label for="txtCompromisos">¿Se cumplieron los compromisos establecidos en la Audiencia de Inicio?</label>
             En el siguiente cuadro debe los compromisos establecidos en la Audiencia de inicio, los responsables indicados y las observaciones frente si se cumplieron a cabalidad dichos compromisos, desde la visión del Grupo Auditor. 
             <div id ="divCompromisos"></div>

            <label for="txtDudas">Observaciones o Dudas Generales</label>
             A partir del análisis realizado por el Grupo Auditor Ciudadano, especifique qué dudas deben ser resultas en la Audiencia de Seguimiento e indique a quien va dirigida la inquietud u observación.
             <div id ="divDudas"></div>

        </div>
     </div>
</div>


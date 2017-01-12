<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InformeProceso.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Audiencias.InformeProceso" %>
<!DOCTYPE html>

<div class="container">
 <input type="hidden" id="hfidproyecto" runat="server"/>
 <input type="hidden" id="hdIdUsuario" runat="server" />
 <input type="hidden" id="hdIdidtipoaud" runat="server" />
 <input type="hidden" id="hdidaud" runat="server" />
    <h1 class="text-center">Informe del Proceso Audiencia de Cierre</h1>
        <div class="panel panel-default">
              <div class="panel-heading">
                         <h4>Para tener en cuenta:</h4>
           <p> Durante la Audiencia de Seguimiento el Grupo Auditor Ciudadano deberá realizar su rendición de cuentas a la comunidad, en este sentido debe presentar cuál ha sido su gestión para hacer seguimiento al proyecto. 
Este formato incluye el cumplimiento del Plan de Trabajo del Grupo Auditor Ciudadano y los resultados del seguimiento al proyecto, por medio de la utilización de herramientas como: diarios de campo, visitas de campo, reuniones con actores, fotografías y entrevistas.
            </p>
                </div>
          </div>
        <form>
           <div class="panel panel-default">
            <div class="panel-heading"><h4>¿Cuáles son las principales tareas del Plan de Trabajo realizadas que deben ser presentadas en la Audiencia?</h4>
             <p>En el siguiente cuadro debe tener el plan de trabajo proyectado para la fase comprendida entre la Audiencia de inicio y la Audiencia de seguimiento, con el fin de reportar las tareas que planeó el Grupo Auditor Ciudadano y los resultados u observaciones en cumplimiento de las mismas. </p>
                </div>
             <div class="panel-body">
             <div id ="divTablaTareasGrupo">
                 </div>
             </div>
          </div>
           <div class="panel panel-default">
            <div class="panel-heading"><h4>¿Cuál es el avance de cada una de las actividades del proyecto?</h4>
             <p>Haga una reflexión sobre las actividades del proyecto al cual está haciendo seguimiento, si estas se cumplieron por el contratista y de qué forma, comparando cronogramas, actividades y presupuesto.
             </p>
             </div>
                 <div  class="panel-body">
                 <div id ="divActividadesProy">
                 </div>
                 </div>
          </div>
          <div class="panel panel-default">
            <div class="panel-heading"><h4>¿Se cumplieron los compromisos establecidos en la Audiencia de Inicio?</h4>
             <p>En el siguiente cuadro debe los compromisos establecidos en la Audiencia de inicio, los responsables indicados y las observaciones frente si se cumplieron a cabalidad dichos compromisos, desde la visión del Grupo Auditor. 
             </p>
               </div>

                <div id ="divCompromisos"  class="panel-body">
                 <div class="row">
			<!--LEFT CONTENT-->
        	<div class="col-sm-4">
            	<div class="form-group">
                  <label for="user">Cronograma Acta de inicio</label>
                  <input type="text" class="form-control" id="userName" placeholder="Titulo del compromiso" >
                 </div>
                 
            </div>
            <!--CENTER CONTENT-->
            <div class="col-sm-4">
            	<div class="form-group">
                   <label for="user">Responsable(s)</label>
                   <input type="text" class="form-control" id="userName" placeholder="Responsables" >
                   </div>
                </div>
            <!--RIGHT CONTENT-->
            <div class="col-sm-4">
            	<div class="form-group">
                   <label for="user">Observaciones / Cumplimiento</label>
                   <input type="text" class="form-control" id="userName" placeholder="Responsables" >
                   </div>
                </div>
         </div>
           <div class="btn btn-default"><span class="glyphicon glyphicon-plus"></span> Agregar Campos</div>

               </div>
          </div>
            <div class="panel panel-default">
            <div class="panel-heading"><h4>Observaciones o Dudas Generales</h4>
             <p>A partir del análisis realizado por el Grupo Auditor Ciudadano, especifique qué dudas deben ser resultas en la Audiencia de Seguimiento e indique a quien va dirigida la inquietud u observación.
             </p>
             </div>
             <div class="panel-body">
             <div id ="divDudas">
                 </div>
             </div>
          </div>
            <div class="well text-center">
         	<button class="btn btn-info"><span class="glyphicon glyphicon-save"></span>Guardar Informe</button>  
         </div>
                  
		</form>
</div>


<script type="text/javascript">
   if ($(document).ready(function () {
        $.getScript("../../Scripts/AudienciasFunciones.js", function () {
                $.getScript("../../Scripts/AudienciasAcciones.js", function () {
            });
        });
    }));
</script>
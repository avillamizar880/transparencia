<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InformeProcesCierre.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Audiencias.InformeProceso" %>
<!DOCTYPE html>

<div class="container">
 <input type="hidden" id="hfidproyecto" runat="server"/>
 <input type="hidden" id="hdIdUsuario" runat="server" />
 <input type="hidden" id="hdIdidtipoaud" runat="server" />
 <input type="hidden" id="hdIdGAC" runat="server" />
 <input type="hidden" id="hdidaud" runat="server" />
 <input type="hidden" id="hdestado" runat="server" />
    <div id="divInforme" runat="server"></div>
    <h1 class="text-center">Informe del proceso antes de la audiencia de Cierre</h1>
        <div class="panel panel-default">
              <div class="panel-heading">
                         <h4>Para tener en cuenta:</h4>
           <p> Este es el informe que condensa el análisis de las labores realizadas. Tomará como referencia la Valoración del proyecto y detallará su contenido a partir de los resultados de la verificación, análisis y reporte; de la valoración del proyecto previo al cierre y de la información de ejecución final del proyecto. Para resumir esta información se propone el siguiente formato. 
            </p>
                </div>
          </div>
        <form>
            <div id="divPreguntas">
           <div class="panel panel-default">
            <div class="panel-heading"><h4>I.	¿Cuáles son las principales tareas realizadas por el Grupo Auditor Ciudadano durante la ejecución del proyecto?</h4>
             <p>En el cuadro se podrán incluir las tareas más destacadas de la gestión del Grupo Auditor a partir de las tareas del plan de trabajo ejecutado; incluyendo los resultados u observaciones en cumplimiento de las mismas.  </p>
                </div>
             <div class="panel-body">
             <div id ="divTablaTareasGrupo"  runat="server">
                 </div>
             </div>
          </div>
           <div class="panel panel-default">
            <div class="panel-heading"><h4>II.	¿Cuál es el balance de la ejecución del proyecto?</h4>
             <p>Haga una reflexión sobre las actividades del proyecto, si se cumplieron los objetivos, metas, indicadores, actividades, cronograma y presupuesto, entre otros aspectos. Establecer el cumplimiento frente a lo previsto inicialmente para la ejecución del proyecto.
             </p>
             </div>
                 <div  class="panel-body">
                 <div id ="divActividadesProy"  runat="server">
                 </div>
                 </div>
          </div>
          <div class="panel panel-default">
            <div class="panel-heading"><h4>III.	¿Se cumplieron los compromisos establecidos en las Audiencias?</h4>
             <p>En el siguiente cuadro debe los compromisos establecidos en la Audiencia de seguimiento (y de inicio si existía algún compromiso pendiente por cumplir), los responsables indicados y las observaciones frente si se ejecutaron a cabalidad dichos compromisos, desde la visión del Grupo Auditor.
             </p>
               </div>

                <div id ="divCompromisos"  class="panel-body">
                 <div class="row">
			<!--LEFT CONTENT-->
        	<div class="col-sm-4">
            	<div class="form-group">
                  <label for="user">Compromiso Audiencia de Seguimiento</label>
<%--                  <input type="text" class="form-control compromiso" id="userName" placeholder="Titulo del compromiso" >--%>
                 </div>
                 
            </div>
            <!--CENTER CONTENT-->
            <div class="col-sm-4">
            	<div class="form-group">
                   <label for="user">Responsable(s)</label>
<%--                   <input type="text" class="form-control respcompromiso" id="userName" placeholder="Responsables" >--%>
                   </div>
                </div>
            <!--RIGHT CONTENT-->
            <div class="col-sm-4">
            	<div class="form-group">
                   <label for="user">Observaciones / Cumplimiento</label>
<%--                   <input type="text" class="form-control" id="userName" placeholder="Observaciones" >--%>
                   </div>
                </div>
         </div>
          <div id ="divtablacompobs"  runat="server"> </div>

           <div class="btn btn-default" id="btnAgregarObsCompromiso"  runat="server" ><span class="glyphicon glyphicon-plus"></span> Agregar Campos</div>

               </div>
          </div>
            <div class="panel panel-default">
            <div class="panel-heading"><h4>Presentación de los resultados de Encuesta de Valoración Del Proyecto previa al cierre:</h4>
             <p>A partir del análisis de los resultados del ejercicio de valoración del proyecto previo al cierre realizado con los integrantes del Grupo Auditor Ciudadano, beneficiarios y comunidad, se sintetizan y reportan las principales conclusiones.
             </p>
             </div>
             <div class="panel-body">
            <div class="row">
			<!--LEFT CONTENT-->
        	<div class="col-sm-8">
            	<div class="form-group">
                  <label for="user">Preguntas</label>
                 </div>
                 
            </div>
            <!--RIGHT CONTENT-->
            <div class="col-sm-4">
            	<div class="form-group">
                   <label for="user">Conclusiones</label>
                   </div>
                </div>
               </div>
             <div id ="divDudas" runat="server">
                 </div>
            <div class="btn btn-default" id="btnAgregarDudas"  runat="server" ><span class="glyphicon glyphicon-plus"></span> Agregar Campos</div>

             </div>
          </div>
            <div class="well text-center">
         	<div class="btn btn-info"  id="btnGuardarInfProceso"  runat="server" ><span class="glyphicon glyphicon-save"></span>Guardar Informe</div>  
<%--         	<button class="btn btn-info" id="btnGuardarInfProceso" ><span class="glyphicon glyphicon-save"></span>Guardar Informe</button>  --%>
         </div>
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
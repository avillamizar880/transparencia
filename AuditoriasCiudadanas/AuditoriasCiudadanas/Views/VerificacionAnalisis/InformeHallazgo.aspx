<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InformeHallazgo.aspx.cs" Inherits="AuditoriasCiudadanas.Views.GrupoAuditor.InformeHallazgo" %>
<div class="container">
    <input type="hidden" id="hfIdGrupoGac" value="16" runat="server"/>
    <input type="hidden" id="hfIdUsuario" value="1" runat="server"/>
   <%-- <div id="" class="btn btn-default mtB15">
       <a role="button" class="volver_listado" onclick="volverDetalleGestion();"><span class="glyphicon glyphicon-menu-left"></span>Volver al Detalle de Gestión</a>
    </div>--%>
    <h1  class="text-center">Informe de Hallazgos</h1>
    <div class="center-block w60">
        <div class="form-group">
            <h4 class="text-center">Para tener en cuenta:</h4>
            Los hallazgos son hechos o acciones que ponen en riesgo la ejecución de los proyectos, estos pueden presentarse en cualquier momento del proceso por los cual se deben tomar medidas preventivas.  Se diseñó el presente formato con el fin de generar una alerta al Sistema de Seguimiento, Monitoreo, Evaluación y Control del DNP y la Entidad Ejecutora del proyecto, los cuales deben contestar al ciudadano en al menos 30 días hábiles.  </p>
        </div>
        <div class="form-group">
                <h4 class="text-center">Haga un registro fotográfico o documental que respalde el hallazgo.</h4>
                Si es una fotografía: Muestre los detalles más relevantes del proyecto que generan posibles comentarios a resaltar.
                Nombre, lugar, fecha y descripción.<br />
                <label class="modal-title">Agregar Recurso</label>
                <input id="recursoMultimediaHallazgo" class="file-loading" type="file">' 
                <div id="errorRecursoMultimediaHallazgo" class="alert alert-danger alert-dismissible" hidden="hidden" >El nombre del recurso no puede ser vacío.</div>
        </div>
        <div class="form-group">
            Previo a la redacción del hallazgo verifique la siguiente información:
             <ul>
                <li>La programación de actividades del proyecto y su estado de ejecución.</li>
                <li>Los contratos que están asociados al proyecto y que posiblemente se estén incumpliendo.</li>
                <li>El presupuesto del proyecto</li>
                <li>El número de beneficiarios que estarían siendo afectados por el riesgo del proyecto.</li>
             </ul>
             A manera de guía, conteste las siguientes preguntas para redactar el hallazgo:
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
            <div id="errorHallazgo" class="alert alert-danger alert-dismissible" hidden="hidden" >El nombre del recurso no puede ser vacío.</div>
        </div>
        <div class="form-group">
            <h4 class="text-center">Para tener en cuenta:</h4>
            En el caso que su hallazgo no tenga respuesta, esta no sea satisfactoria o permanezca el hecho riesgoso puede realizar una denuncia a la entidad competente. Si requiere asesoría y acompañamiento para su denuncia Transparencia por Colombia ha dispuesto la Aplicación DILO AQUÍ, para brindar acompañamiento y asistencia técnica a la ciudadanía que desea realizar denuncias.
        </div>
        <div class="botonera text-center">
            <div class="btn btn-primary">
            <a href="#" onclick="guardarInformeHallazgo()">Enviar<span class="glyphicon glyphicon-chevron-right"></span></a>
        </div>
        </div>
    </div>
</div>
<script>
  ConsultarInformeHallazgo();     
</script>
<%--</body>
</html>--%>

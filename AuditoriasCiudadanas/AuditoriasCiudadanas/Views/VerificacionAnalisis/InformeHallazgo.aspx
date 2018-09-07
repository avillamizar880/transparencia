<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InformeHallazgo.aspx.cs" Inherits="AuditoriasCiudadanas.Views.GrupoAuditor.InformeHallazgo" %>
<div class="container">
    <input type="hidden" id="hfIdGrupoGac" value="" runat="server"/>
    <input type="hidden" id="hfIdUsuario" value="" runat="server"/>
    <input type="hidden" id="hfErroresFileUpload" value="" runat="server"/>
    <input type="hidden" id="hfTotalArchivosCargados" value="" runat="server"/>
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
                
            <div class="panel panel-default">
             <div class="panel-heading">
                <label class="modal-title" style="padding-bottom: 20px; padding-top: 20px;">Agregar Recurso (png/jpg/pdf)</label>

                <input id="recursoMultimediaHallazgo" type="file" accept=".pdf,.png,.jpg" multiple>
                <div id="errorRecursoMultimediaHallazgo" class="alert alert-danger alert-dismissible" hidden="hidden">El nombre del recurso no puede ser vacío.</div>
            </div>   
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
            <h4 class="text-center">En el siguiente recuadro redacte de manera detallada porqué su hallazgo pone en riesgo la ejecución del proyecto o cuál sería la afectación para la comunidad (200 palabras máximo) </h4>
            <textarea id="txtHallazgo" cols="10" rows="6" placeholder="Redacte su hallazgo aquí" class="form-control"></textarea>
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
    //ConsultarInformeHallazgo();     
    $("#hfErroresFileUpload").val("false");
    $("#recursoMultimediaHallazgo").fileinput({
        theme: 'fa',
        language: 'es',
        uploadUrl: "../../Views/VerificacionAnalisis/InformeHallazgo_ajax", // server upload action
        maxFileCount: 3,
        showCaption: false,
        overwriteInitial: false,
        maxFileSize: 1024,
        showUpload: false,
        allowedFileExtensions: ['jpg', 'png', 'pdf'],
        browseLabel: "Subir Evidencia (pdf/png/jpg)",
        showZoom: true,
        showRemove: true,
        showDrag: false,
        dropZoneEnabled: false,
        showPreview: true,
        validateInitialCount: true,
        uploadAsync: false,
        showCaption: true,

    }).on('fileremoved', function (event, id, index) {
        if ($("#hfErroresFileUpload").val() == "true") {
            bootbox.alert("Hemos detectado que al menos un archivo no cumple con las especificaciones requeridas. Por seguridad, se borrarán todas los archivos precargados por usted. Agradecemos corregir los errores para continuar", function () {
                $("#hfErroresFileUpload").val("false");
                $("#errorRecursoMultimediaHallazgo").html('');
                $("#errorRecursoMultimediaHallazgo").hide();
                $("#recursoMultimediaHallazgo").fileinput('clear');
                // $("#recursoMultimediaHallazgo").fileupload('destroy');
            });
            
        }
    }).on('filebatchpreupload', function (event, data, previewId, index, jqXHR) {
        var rutaImagen = $("#recursoMultimediaHallazgo").val().split("\\");
        data.form.append("hallazgo", $("#txtHallazgo").val());
        data.form.append("grupoGacId", $("#hfIdGrupoGac").val());
        data.form.append("idUsuario", $("#hfIdUsuario").val());
        data.form.append("rutaImagen", $("#hfIdUsuario").val() + '_' + rutaImagen[rutaImagen.length - 1]);
    }).on('filebatchuploaderror', function (event, data, msg) {
        $("#hfErroresFileUpload").val("true");
    }).on('filebatchuploadsuccess', function (event, data, id, index) {
        var respuesta = data.response;
        if (respuesta.Head.length > 0) {
            if (respuesta.Head[0].cod_error == "0") {
                bootbox.alert('El reporte se subió al sistema con éxito.\nSerá redirigido a la pantalla de gestión.', function () {
                    volver_listado_gestion();
                });
            } else {
                if (respuesta.Head[0].msg_error != "") {
                    bootbox.alert("Se presentó un error al guardar el hallazgo: " + respuesta.Head[0].msg_error);
                }
            }
        } else {
            bootbox.alert("Se presentó un error al guardar el hallazgo");

        }
    });

</script>


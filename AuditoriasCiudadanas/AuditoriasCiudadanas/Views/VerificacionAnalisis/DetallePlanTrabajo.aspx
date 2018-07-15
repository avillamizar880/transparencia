<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetallePlanTrabajo.aspx.cs" Inherits="AuditoriasCiudadanas.Views.VerificacionAnalisis.DetallePlanTrabajo" %>
<input type="hidden" id="hfidTarea" runat="server"/>
<input type="hidden" id="hfTitulo" runat="server"/>
<input type="hidden" id="hfFechaTarea" runat="server"/>
<input type="hidden" id="hfHoraTarea" runat="server"/>
<input type="hidden" id="hfPermisoModificarFormato" value="true" runat="server"/>

  <%--REGISTRO FOTOGRAFICO PARA SEGUIMIENTO DEL PROYECTO--%>
    <div class="container generalInfo" id="tareaRegistroFotograficoProyecto" hidden="hidden">
<div class="row">
        	<div class="headSection">
            	<div class="col-sm-12 headTit">
                    <span>TAREA</span>
                </div>
              <div class="col-sm-9">
                <h3>Registro fotográfico para el seguimiento del proyecto</h3>
                <div class="row">
                    <div id="fechaRegistroFotografico" class="col-sm-6"><span class="glyphicon glyphicon-calendar"></span>Fecha:&nbsp;05/07/2020 </div>
                   <div id="horaRegistroFotografico" class="col-sm-6"><span class="glyphicon glyphicon-time"></span> Hora:&nbsp; 00:00hrs </div>
               	</div>
                <div class="panel panel-default">
                    <div class="panel-heading">
                    <h4> Para tener en cuenta</h4>
                     <p>
                     El registro fotográfico será la herramienta para registrar visualmente el estado de avance, en cada una de las visitas programadas en el plan de trabajo del ciudadano. 
                     Cada fotografía debe tener la siguiente información:
                     </p>
                        <ul>
                            <li>Un objetivo o reflexión</li>
                            <li>El nombre de quien tomó la fotografía</li>
                            <li>La fecha</li>
                            <li>El lugar.</li>
                        </ul>
                        <p>
                        Recuerde que el tamaño de la fotografía es importante para que sea un buen insumo, por lo cual se sugiere que el tamaño de la foto no sea menor a 8 centímetros de ancho y 6 centímetro de alto.
                        </p>
                        </div>
                </div>

               </div>
                <div class="col-sm-3 userActions">
            	<div id="btnFinalizarRegistroFotografico" onclick="FinalizarTareaRegistroFotografico()" class="btn btn-default btn-lg"><span class="glyphicon glyphicon-ok"></span><span>Finalizar</span></div>
                <div id="btnEliminarRegistroFotografico" onclick="EliminarTareaRegistroFotografico()" class="btn btn-default  btn-lg"><span class="glyphicon glyphicon-trash"></span>Eliminar</div>
            </div>
            
              </div>
		</div>
        <div class="row">
            <div class="col-sm-9">
            	<div class="generalInfo">
                	<div class="tab-content">
                      <div id="tab3" >
                        <h4>Información y fotografía
                        <div id="btnAgregarRegistroFotografico" onclick="AgregarRegistroFotografico()" class="btn btn-info fr"><a href="#" data-toggle="modal" data-target="#myModalAgregarRegistro"><span class="glyphicon glyphicon-plus"></span> Agregar información y fotografía</a></div></h4>
                             <div class="col-sm-4">
                                 <div id="errorRecursosFotograficosTarea" class="alert alert-danger alert-dismissible" hidden="hidden" >Este campo no puede estar vacío.</div>
                                 <div id="lstRecursosFotograficosTarea" class="card"></div>
                             </div>
                       </div>
                     </div>
                  </div>
              </div>  
         </div>
     </div>

  <!--MODAL AGREGAR RECURSO FOTOGRAFICO-->
<div class="modal fade" id="myModalAgregarRegistro" tabindex="-1" role="dialog" aria-labelledby="myModalLabelRecursoTarea"></div>

<%--ACTAS DE REUNIONES--%>
<div class="container generalInfo" id="tareaActaReuniones" hidden="hidden">
    <div class="row">
        <div class="headSection">
             <div class="col-sm-12 headTit">
                <span>TAREA</span>
             </div>
             <div class="col-sm-9">
              <!--	<span class="glyphicon glyphicon-info-sign XLtext"></span>-->
                <h3>Actas reuniones</h3>
                <div class="row">
                    <div id="fechaTareaActaReuniones" class=" col-sm-6"><span class="glyphicon glyphicon-calendar"></span>Fecha:&nbsp;05/07/2020</div>
                    <div id="horaTareaActaReuniones" class=" col-sm-6"><span class="glyphicon glyphicon-time"></span> Hora:&nbsp; 00:00hrs </div>
               	</div>
                <div class="panel panel-default">
                    <div class="panel-heading">
                <h4>Para tener en cuenta</h4>
                <p>
                    Es importante que el Grupo Auditor Ciudadano tenga reuniones con el interventor de la obra, las autoridades municipales, y posibles apoyos técnicos como profesores universitarios. De cada reunión deben recogerse insumos por medio de actas sencillas. Las actas de reuniones también pueden elaborarse después de los encuentros internos del Grupo, con el fin de registrar el seguimiento de sus actividades y los eventuales ajustes al plan de trabajo.
                </p>
                    </div>
                </div>
             </div>
             <div class="col-sm-3 userActions">
            	<div id="btnFinalizarActaReunion" onclick="FinalizarDetalleTarea()" class="btn btn-default btn-lg"><span class="glyphicon glyphicon-ok"></span><span>Finalizar</span></div>
                <div id="btnEliminarActaReunion" onclick="EliminarDetalleTarea()" class="btn btn-default  btn-lg"><span class="glyphicon glyphicon-trash"></span>Eliminar</div>
            </div>
        </div>
    </div>
    <div class="row">
	    <div class="col-sm-9">
		    <div class="generalInfo">
			    <div class="tab-content">
				<!--CONTENT1 Descripción-->
				    <div id="ActasReuniones">
					    <h4>Temas a tratar <div id="btnTemas" class="btn btn-info fr"><a href="" data-toggle="modal" data-target="#myModalTemasReunion"><span class="glyphicon glyphicon-plus"></span> Agregar temas</a></div></h4>
						<p>Es importante reportar el por qué se realiza la reunión y cómo aporta esta al seguimiento del proyecto.</p>
						<div id="errortareaTemasReuniones" class="alert alert-danger alert-dismissible" hidden="hidden" >No se puede finalizar la tarea si no ha creado al menos un tema.</div>
                        <div class="well" id="tareaTemasReuniones">
						</div>
						<div class="wrap"></div>
					</div>
				    <div id="tab1">
					    <h4>Asistentes</h4>
						<p>Se adjunta fotografía o documento de la lista de asistencia. <a role="button" onclick="descargar_pdf();">Descargar formato aquí.</a> </p>
						<div id="errortareaAsistentes" class="alert alert-danger alert-dismissible" hidden="hidden" >No se puede finalizar la tarea si no se registra la asistencia.</div>
                        <div class="row" id="tareaAsistentes">
                            <input id="inpListadoAsistencia" class="file-loading" type="file" multiple>
                            <div id="EditarImagenesAsistencia" class="btn btn-info fr"><a href="#" onclick="GuardarImagenesListadoAsistencia()" ><span class="glyphicon glyphicon-plus"></span>Guardar Imagen</a></div>
                        </div>
						<div class="wrap"></div>
						    <!--Encabezado-->
				     </div>
                    <div id="tab2">
				        <h4>Compromisos derivados de la reunión <div id="btnCompromisos" onclick="AgregarCompromisos()" class="btn btn-info fr"><a href="#" data-toggle="modal" data-target="#myModalCompromisos"><span class="glyphicon glyphicon-plus"></span> Agregar compromisos</a></div></h4>
						<p>En este apartado se describen los compromisos que hayan resultado de la reunión. Si no surgen compromisos este apartado se puede omitir.</p>
						<!--Encabezado-->
						<div class="list-group-item">
						    <div class="col-sm-5">
							    <strong>Compromiso</strong>
							</div>
							<div class="col-sm-4">
							    <strong>Responsable(s)</strong>
							</div>
							<div class="col-sm-2">
							    <strong>Fecha de cumplimiento</strong>
							</div>
                            <div class="col-sm-1">
                                    <strong>Acción</strong>
                            </div>
						</div>
						<div class="list-group" id="tareaCompromisos">
						</div>
					 </div>
				</div>
			 </div>
		</div>
     </div>
</div>
<%--MODALES ACTAS REUNIONES--%>

 <!-- NUEVA Temas a tratar LISTADO DE TEMAS A TRATAR-->
    <div class="modal fade" id="myModalTemasReunion" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                                            <div class="modal-dialog" role="document">
                                                <div class="modal-content">
                                                <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                <h4 class="modal-title" id="myModalLabel">Agregar temas reunión</h4>
                                                </div>
                                                <div class="modal-body">
                                                <div class="form-group">
                                                <label for="TemasReuniones" class="control-label">Temas</label>    
                                                <div id="errorTemasReuniones" class="alert alert-danger alert-dismissible" hidden="hidden" >Este campo no puede estar vacío.</div>
                                                <div id="errorTemasReunionesAsteriscos" class="alert alert-danger alert-dismissible" hidden="hidden">Los temas no pueden contener el caracter *.</div>
                                                <textarea id="txtTemasReuniones" placeholder="Por favor enumere los temas tratados en la reunión... " class="form-control" rows="5" ></textarea>
                                                </div>
                                                 <div class="modal-footer">
                                                 <button id="btnCancelar" type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                                                 <button id="btnGuardar" onclick="GuardarTemasActaReunionTarea()" type="button" class="btn btn-primary">Guardar</button>
                                                 </div>
                                                 </div>
                                                 </div>
                                                 
    </div>
    </div>
 <!-- NUEVA Lista asistentes DOCUMENTO ESCANEADO O FOTOGRAFÍA -->
<div class="modal fade" id="myModalAsistentes" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"></div>
   <%-- <div class="modal fade" id="myModalAsistentes" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
       <div class="modal-dialog" role="document">
                                                <div class="modal-content">
                                                <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                <h4 class="modal-title" id="myModalLabel">Agregar listado asistentes</h4>
                                                </div>
                                                <div class="modal-body">
                                                <div class="form-group">
                                                <label for="lblAsistentes" class="control-label">Fotografía o documento digitalizado de la lista de asistentes</label>    
                                                <div id="errorAsistentes" class="alert alert-danger alert-dismissible" hidden="hidden" >Este campo no puede estar vacío.</div>
                                                <input id="inpListaAsistentes" class="file-loading" type="file">
                                                </div>
                                                 <div class="modal-footer">
                                                 <button id="btnCancelar" type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                                                 <button id="btnGuardar" onclick="GuardarAsistenciaActaReunion()" type="button" class="btn btn-primary">Guardar</button>
                                                 </div>
                                                 </div>
                                                 </div>
                                                 
    </div>
    <script type="text/javascript">
        $("#errorAsistentes").hide();
        $("#inpListaAsistentes").fileinput({
            uploadUrl: "../../Views/VerificacionAnalisis/DetallePlanTrabajoAsistencia_ajax", // server upload action
            showUpload: false,
            language:"es",
            maxFileCount: 1,
            showCaption: false,
            allowedFileExtensions: ['jpg', 'png', 'pdf'],
            maxFileCount: 1,
            browseLabel: "Subir Asistencia",
            showDrag: false,
            dropZoneEnabled: false,
        }).on('filepreupload', function (event, data, previewId, index, jqXHR) {
            var rutaImagen = $("#inpListaAsistentes").val().split("\\");
            data.form.append("idTarea", $("#hfidTarea").val());
            data.form.append("url", rutaImagen[rutaImagen.length - 1]);
        }).on('fileuploaded', function (event, data, id, index) {
            CargarInformacionActasReuniones();
            $("#myModalAsistentes").hidden = "hidden";
            $("#myModalAsistentes").modal('toggle');
        });
    </script>
    </div>--%>

<!--AGREGAR COMPROMISOS RESPONSABLES FECHA-->
     <div class="modal fade" id="myModalCompromisos" tabindex="-1" role="dialog" aria-labelledby="myModalLabelCompromisos">
    </div>


<%--DIARIO DE NOTAS--%>
  <div class="container generalInfo" id="tareaDiarioNotas" hidden="hidden">
    	<div class="row">
        	<div class="headSection">
            	<div class="col-sm-12 headTit">
                    <span>TAREA</span>
                </div>
                <div class="col-sm-9">
                    <h3>Diario de notas</h3>
                <div class="row">
                   <div id="fechaTareaDiarioNotas" class=" col-sm-6"><span class="glyphicon glyphicon-calendar"></span>Fecha:&nbsp;05/07/2020 </div>
                   <div id="horaTareaDiarioNotas"  class=" col-sm-6"><span class="glyphicon glyphicon-time"></span> Hora:&nbsp; 00:00hrs </div>
               	</div>
                <div class="panel panel-default">
                    <div class="panel-heading">
                    <h4> Para tener en cuenta</h4>
                     <p>El diario de notas es una herramienta de apoyo que los ciudadanos podrán emplear para realizar un seguimiento más detallado. Este permite plasmar de forma habitual los cambios y avances de la obra o del proyecto.</p>
                     </div>
                     </div>
               </div>
                <div class="col-sm-3 userActions">
            	    <div id="btnFinalizarDiarioNotas" onclick="FinalizarDiarioNotasTarea()" class="btn btn-default btn-lg"><span class="glyphicon glyphicon-ok"></span><span>Finalizar</span></div>
                    <div id="btnEliminarDiarioNotas" onclick="EliminarDiarioNotasTarea()" class="btn btn-default  btn-lg"><span class="glyphicon glyphicon-trash"></span>Eliminar</div>
                </div>
              </div>
		</div>
        <div class="row">
            <div class="col-sm-9">
            	<div class="generalInfo">
                	<div class="tab-content">
                    	<!--CONTENT1 Descripción-->
                        <div id="tab0">
                        <h4>Diario de notas <div id="btnAgregarNotas" onclick="AgregarNotas()" class="btn btn-info fr"><a href="#" data-toggle="modal" data-target="#myModalDiarioNotas"><span class="glyphicon glyphicon-plus"></span> Agregar notas</a></div></h4>
<%--                        	<div class="wrap"></div>--%>
                            <!--Encabezado-->
                            <div id="errordtgDiarioNotas" class="alert alert-danger alert-dismissible" hidden="hidden" >No se puede finalizar la tarea si no ha creado al menos una nota.</div>
                             <div class="list-group-item">
                                <div class="col-sm-5">
                                    <strong>Descripción de la observación</strong>
                                </div>
                                <div class="col-sm-4">
                                    <strong>Reflexión u opinión acerca de lo visto</strong>
                                </div>
                                <div class="col-sm-2">
                                    <strong>Fecha de la visita</strong>
                                </div>
                                 <div class="col-sm-1">
                                    <strong>Acción</strong>
                                </div>
                            </div>
                            <div class="list-group" id="dtgDiarioNotas">
                           </div>
                       </div>
                    </div>
                 </div> 
           </div>
     </div>
</div>

<%--MODALES DIARIO DE NOTAS--%>

 <!-- NUEVA DESCRIPCIÓN REFLEXION U OPINION Y FECHA DE CUMPLIMIENTO -->
    <div class="modal fade" id="myModalDiarioNotas" tabindex="-1" role="dialog" aria-labelledby="myModalLabelDiarioNotas">
    </div>

<%--VISITA DE CAMPO--%>
 <div class="container generalInfo" id="tareaVisitaCampo" hidden="hidden">
    	<div class="row">
        	<div class="headSection">
            	<div class="col-sm-12 headTit">
                    <span>TAREA</span>
                </div>
              <div class="col-sm-9">
              <!--	<span class="glyphicon glyphicon-info-sign XLtext"></span>-->
                <h3>Visita de campo</h3>
                <div class="row">
                    <div class=" col-sm-6" id="fechaVisitaCampo"><span class="glyphicon glyphicon-calendar"></span>Fecha:&nbsp;05/07/2020 </div>
                   <div class=" col-sm-6" id="horaVisitaCampo"><span class="glyphicon glyphicon-time"></span> Hora:&nbsp; 00:00hrs </div>
               	</div>
                <div class="panel panel-default">
                    <div class="panel-heading">
                    <h4> Para tener en cuenta</h4>
                     <p>Las visitas de campo deben ser programadas por el Grupo Auditor Ciudadano en su plan de trabajo, las cuales tendrán la frecuencia que el Grupo y la comunidad estimen necesarias. </p>
                     <p>Es importante que estas visitas no sean únicamente de la comunidad, por el contrario, dialogar con las autoridades locales, el interventor del proyecto y/o el contratista para que acompañen el ejercicio ciudadano, con el fin de que cada uno de estos actores puedan dar las primeras observaciones técnicas o legales que sirvan de insumo al Grupo Auditor Ciudadano.</p>
                   </div>
                   </div>
               </div>
                <div class="col-sm-3 userActions">
            	
            	<div id="btnFinalizarVisitaCampo" onclick="FinalizarVisitaCampoTarea()" class="btn btn-default btn-lg"><span class="glyphicon glyphicon-ok"></span><span>Finalizar</span></div>
                <div id="btnEliminarVisitaCampo" onclick="EliminarVisitaCampoTarea()" class="btn btn-default  btn-lg"><span class="glyphicon glyphicon-trash"></span>Eliminar</div>
            </div>
            
              </div>
		</div>
        <div class="row">
            <div class="col-sm-9">
            	<div class="generalInfo">
                	<div class="tab-content">
                    	<!--CONTENT1 Descripción-->
                        <div id="tab0">
                      <h4>Nombre y cargo de quien acompañó la visita de campo del Grupo Auditor Ciudadano <div id="btnAgregarCargoFuncionarioVisita" class="btn btn-info fr"><a href="#" data-toggle="modal" data-target="#myModalNombreCargo"><span class="glyphicon glyphicon-plus"></span> Agregar nombre(s) y cargo(s)</a></div></h4>
                          <p>El nombre y el cargo que desempeña la(s) persona(s) diferentes al Grupo Auditor Ciudadano que acompañó(aron) la visita de campo. Por ejemplo, un funcionario público de la entidad ejecutora, un representante de la empresa contratista, o el interventor del proyecto.
                          </p>
                          <div class="well">
                            <div id="errorFuncionarioAcompanaVisitaCampo" class="alert alert-danger alert-dismissible" hidden="hidden" >No se puede finalizar la tarea si no ha registrado al menos un acompañamiento de un funcionario público.</div>
                        	<div id="txtFuncionarioAcompanaVisitaCampo"  class="wrap"></div>
                            </div>
                      </div>
                      <div id="tab1">
                      <h4>Actividades <div id="btnAgregarActividadesVisitaCampo"  class="btn btn-info fr"><a href="#" data-toggle="modal" data-target="#myModalActividadesVisita"><span class="glyphicon glyphicon-plus"></span> Agregar actividades</a></div></h4>
                          <p>Proponga actividades que desea realizar para el seguimiento al proyecto en la visita de campo, por ejemplo:
                              <ol>
                                  <li>Revisión de actividades según el cronograma que presenta el aplicativo</li>
                                  <li>Revisión de calidad de materiales con el interventor </li>
                                  <li>Revisión del manejo y gestión de residuos sólidos</li>
                              </ol>
                          </p>
                          <div class="well">
                            <div id="errorActividadesVisitaCampo" class="alert alert-danger alert-dismissible" hidden="hidden" >No se puede finalizar la tarea si no ha registrado al menos una actividad de visita de campo.</div>
                        	<div id="txtActividadesVisitaCampo" class="wrap"></div>
                          </div> 
                      </div>
                      <div id="tab3" >
                        <h4>Observaciones y registro fotográfico <div id="btnAgregarObservacionesRegistroFotografico" onclick="AgregarRegistroFotograficoVisitaCampo()" class="btn btn-info fr"><a href="#" data-toggle="modal" data-target="#mymodalObservacionesFotos"><span class="glyphicon glyphicon-plus"></span> Agregar observaciones y registro fotográfico</a></div></h4>
                        <p>El registro fotográfico será la herramienta para registrar 
                            visualmente el estado de avance del proyecto, en las visitas programadas, 
                            cada fotografía debe tener un objetivo o representar el avance de una actividad particular, 
                            con el propósito de que quien la vea pueda entender la realidad de la ejecución del proyecto.
                        </p> 
                        <div class="list-group-item">
                                <div class="col-sm-6">
                                    <strong>Observaciones</strong>
                                </div>
                                <div class="col-sm-5">
                                    <strong>Registro fotográfico</strong>
                                </div>
                                <div class="col-sm-1">
                                    <strong>Acción</strong>
                                </div>
                            </div>
                            <div id="errordtgListadoRegistroFotograficoVisitaCampo" class="alert alert-danger alert-dismissible" hidden="hidden" >No se puede finalizar la tarea si no ha registrado al menos un registro fotográfico de la visita.</div>
                            <div id="dtgListadoRegistroFotograficoVisitaCampo" class="list-group-item">           
                            </div>
                      </div>
                            </div>
                        </div>
                      </div>
</div>




 

<%--MODAL VISITA DE CAMPO--%>
 <!-- NUEVA nombre cargo -->
    <div class="modal fade" id="myModalNombreCargo" tabindex="-1" role="dialog" aria-labelledby="myModalLabelFuncionarioAcompanaVisita">
      <div class="modal-dialog" role="document">
                                                <div class="modal-content">
                                                <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                <h4 class="modal-title" id="myModalLabelFuncionarioAcompanaVisita">Agregar nombre(s) y cargo(s)</h4>
                                                </div>
                                                <div class="modal-body">
                                                <div class="form-group">
                                                <label for="NombreVisita" class="control-label">Nombre(s) y cargo(s)</label>    
                                                <div id="errorFuncionarioAcompanaVisita" class="alert alert-danger alert-dismissible" hidden="hidden" >Este campo no puede estar vacío.</div>
                                                <div id="errorFuncionarioAcompanaVisitaAsterisco" class="alert alert-danger alert-dismissible" hidden="hidden">Los nombres y cargos no puede contener el caracter *.</div>
                                                <textarea id="txtFuncionarioAcompanaVisita" placeholder="Nombre, cargo" class="form-control" rows="5" ></textarea>            
                                                </div>
                                                <div class="modal-footer">
                                                <button id="btnCancelarFuncionarioAcompanaVisitaAsterisco" type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                                                <button id="btnGuardarFuncionarioAcompanaVisitaAsterisco" onclick="GuardarFuncionarioAcompanaVisitaTarea()" type="button" class="btn btn-primary">Guardar</button>
                                                </div>
                                                </div>
                                                </div>
        </div>
   </div>
 <!-- NUEVA Actividades -->
    <div class="modal fade" id="myModalActividadesVisita" tabindex="-1" role="dialog" aria-labelledby="myModalLabelActividades">
      <div class="modal-dialog" role="document">
                                                <div class="modal-content">
                                                <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                <h4 class="modal-title" id="myModalLabelActividades">Agregar actividades</h4>
                                                </div>
                                                <div class="modal-body">
                                                <div class="form-group">
                                                <label for="lblActividades" class="control-label">Actividades</label>    
                                                <div id="errorActividades" class="alert alert-danger alert-dismissible" hidden="hidden" >Este campo no puede estar vacío.</div>
                                                <div id="errorActividadesAsteriscos" class="alert alert-danger alert-dismissible" hidden="hidden">Las actividades no pueden contener el caracter *.</div>
                                                <textarea id="txtActividades" placeholder="Por ejemplo: Revisión de calidad de materiales con el interventor" class="form-control" rows="5" ></textarea>            
                                                </div>
                                                <div class="modal-footer">
                                                <button id="btnCancelarActividadesVisita" type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                                                <button id="btnGuardarActividadesVisita" onclick="GuardarActividadesVisitaCampoTarea()" type="button" class="btn btn-primary">Guardar</button>
                                                </div>
                                                </div>
                                                </div>
        </div>
   </div>
 <!-- NUEVA Observaciones y fotos -->
    <div class="modal fade" id="mymodalObservacionesFotos" tabindex="-1" role="dialog" aria-labelledby="myModalLabelObservacionesFotos">
   </div>
	 <div id="divPdfAsistencia">

	 </div>


<%--<script type="text/javascript" src="../../Scripts/DetalleTarea.js"></script>--%>
<script type="text/javascript">
    MostrarDetallePlanTrabajo();
</script>

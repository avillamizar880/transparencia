<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetallePlanTrabajo.aspx.cs" Inherits="AuditoriasCiudadanas.Views.VerificacionAnalisis.DetallePlanTrabajo" %>
<input type="hidden" id="hfidTarea" runat="server"/>
<input type="hidden" id="hfTitulo" runat="server"/>
<input type="hidden" id="hfFechaTarea" runat="server"/>
<input type="hidden" id="hfHoraTarea" runat="server"/>
<input type="hidden" id="hfPermisoModificarFormato" runat="server"/>
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
                <h4>Para tener en cuenta</h4>
                <p>
                    Es importante que el Grupo Auditor Ciudadano tenga reuniones con el interventor de la obra, las autoridades municipales, y posibles apoyos técnicos como profesores universitarios. De cada reunión deben recogerse insumos por medio de actas sencillas. Las actas de reuniones también pueden elaborarse después de los encuentros internos del Grupo, con el fin de registrar el seguimiento de sus actividades y los eventuales ajustes al plan de trabajo.
                </p>
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
						<div class="well" id="tareaTemasReuniones">
						    <p>
						    </p>
						</div>
						<div class="wrap"></div>
					</div>
				    <div id="tab1">
					    <h4>Asistentes <div id="btnAsistentes" class="btn btn-info fr"><a href="" data-toggle="modal" data-target="#myModalAsistentes"><span class="glyphicon glyphicon-plus"></span> Agregar listado asistencia</a></div></h4>
						<p>Se adjunta fotografía o documento de la lista de asistencia. <a href="">Descargar formato aquí.</a> </p>
						<div class="well" id="tareaAsistentes">
                            <input id="inpListadoAsistencia" class="file-loading" type="file">
						</div>
						<div class="wrap"></div>
						    <!--Encabezado-->
				     </div>
                    <div id="tab2">
				        <h4>Compromisos derivados de la reunión <div id="btnCompromisos" class="btn btn-info fr"><a href="" data-toggle="modal" data-target="#myModalCompromisos"><span class="glyphicon glyphicon-plus"></span> Agregar compromisos</a></div></h4>
						<p>En este apartado se describen los compromisos que hayan resultado de la reunión. Si no surgen compromisos este apartado se puede omitir.</p>
						<!--Encabezado-->
						<div class="list-group-item">
						    <div class="col-sm-5">
							    <strong>Compromiso</strong>
							</div>
							<div class="col-sm-5">
							    <strong>Responsable(s)</strong>
							</div>
							<div class="col-sm-2">
							    <strong>Fecha de cumplimiento</strong>
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
   <%-- <script type="text/javascript">
        ObtenerTemaActaReunion();
    </script>--%>
    </div>
 <!-- NUEVA Lista asistentes DOCUMENTO ESCANEADO O FOTOGRAFÍA -->
    <div class="modal fade" id="myModalAsistentes" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
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
    </div>

<!--AGREGAR COMPROMISOS RESPONSABLES FECHA-->
     <div class="modal fade" id="myModalCompromisos" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
       <div class="modal-dialog" role="document">
                                                <div class="modal-content">
                                                <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                <h4 class="modal-title" id="myModalLabel">Nuevo Compromiso</h4>
                                                </div>
                                                <div class="modal-body">
                                                <div class="form-group">
                                                <label for="lblcompromisos" class="control-label">Compromiso</label>    
                                                <div id="errorCompromisosActa" class="alert alert-danger alert-dismissible" hidden="hidden" >El compromiso no puede ser vacío.</div>
                                                <div id="errorCompromisosActaAsterisco" class="alert alert-danger alert-dismissible" hidden="hidden">La descripción del compromiso no puede contener el caracter *.</div>
                                                <textarea id="txtCompromiso" placeholder="Por favor describa el compromiso aquí... " class="form-control" rows="5" ></textarea>            
                                                <label for="lblResponsable" class="control-label">Responsables</label>    
                                                <div id="errorResponsable" class="alert alert-danger alert-dismissible" hidden="hidden" >El responsable no puede ser vacío.</div>
                                                <div id="errorResponsableAsterisco" class="alert alert-danger alert-dismissible" hidden="hidden">El nombre del responsable no puede contener el caracter *.</div>
                                                <textarea id="txtResponsable" placeholder="Por favor escriba los responsables aquí... " class="form-control" rows="5" ></textarea>
                                                <label for="fecha_posterior_2" class="control-label">Fecha de cumplimiento</label>
                                                <div class="input-group date form_date datetimepicker" data-date="" data-date-format="dd MM yyyy" data-link-field="fecha_posterior_2" data-link-format="yyyy-mm-dd">
                                                <input id="dtpFechaCumplimiento" class="form-control" size="16" type="text" value="" readonly>
                                                <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                                                <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                                                </div>
                                                <div id="errorFechaCumplimiento" class="alert alert-danger alert-dismissible" hidden="hidden" >La fecha no puede ser vacío.</div>
                                                <input type="hidden" id="fecha_posterior_2" value="" />
                                                </div>

                                                 <div class="modal-footer">
                                                 <button id="btnCancelar" type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                                                 <button id="btnGuardar" onclick="GuardarCompromisoTarea()" type="button" class="btn btn-primary">Guardar</button>
                                                 </div>
                                                 </div>
                                                 </div>
                                                 <script type="text/javascript"> 
			                                    $(".form_datetime").datetimepicker({
			                                            language: "es", 
			                                            weekStart: 1,
			                                            todayBtn: 1,
			                                            autoclose: 1,
			                                            todayHighlight: 1,
			                                            startView: 2,
			                                            forceParse: 0,
			                                            showMeridian: 1
			                                        });
			                                        $(".form_date").datetimepicker({
			                                            language: "es",
			                                            weekStart: 1,
			                                            todayBtn: 1,
			                                            autoclose: 1,
			                                            todayHighlight: 1,
			                                            startView: 2,
			                                            minView: 2,
			                                            forceParse: 0
			                                        });
			                                        $(".form_time").datetimepicker({
			                                            language: "es",
			                                            weekStart: 1,
			                                            todayBtn: 1,
			                                            autoclose: 1,
			                                            todayHighlight: 1,
			                                            startView: 1,
			                                            minView: 0,
			                                            maxView: 1,
			                                            forceParse: 0
			                                        });
			                                        var f = new Date();
			                                        $("#dtpFechaCumplimiento").val(f.getDate() + "/" + (f.getMonth() + 1) + "/" + f.getFullYear());
                                                   </script>
    </div>
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
                    <div class=" col-sm-6"><span class="glyphicon glyphicon-calendar"></span>Fecha:&nbsp;05/07/2020 en la que se realizo la visita.</div>
                   <div class=" col-sm-6"><span class="glyphicon glyphicon-time"></span> Hora:&nbsp; 00:00hrs </div>
               	</div>
                    <h4> Para tener en cuenta</h4>
                     <p>El diario de notas es una herramienta de apoyo que los ciudadanos podrán emplear para realizar un seguimiento más detallado. Este permite plasmar de forma habitual los cambios y avances de la obra o del proyecto.</p>
               </div>
                <div class="col-sm-3 userActions">
            	    <div id="btnFinalizar" onclick="FinalizarTarea()" class="btn btn-default btn-lg"><span class="glyphicon glyphicon-ok"></span><span>Finalizar</span></div>
                    <div id="btnEliminar" onclick="EliminarTarea()" class="btn btn-default  btn-lg"><span class="glyphicon glyphicon-trash"></span>Eliminar</div>
                </div>
              </div>
		</div>
        <div class="row">
            <div class="col-sm-9">
            	<div class="generalInfo">
                	<div class="tab-content">
                    	<!--CONTENT1 Descripción-->
                        <div id="tab0">
                      <h4>Diario de notas <div class="btn btn-info fr"><a href="" data-toggle="modal" data-target="#myModal"><span class="glyphicon glyphicon-plus"></span> Agregar notas</a></div></h4>
<%--                        	<div class="wrap"></div>--%>
                            <!--Encabezado-->
                             <div class="list-group-item">
                                <div class="col-sm-5">
                                    <strong>Descripción de la observación</strong>
                                </div>
                                <div class="col-sm-5">
                                    <strong>Reflexión u opinión acerca de lo visto</strong>
                                </div>
                                <div class="col-sm-2">
                                    <strong>Fecha de la visita</strong>
                                </div>
                            </div>
                            <div class="list-group">
                                <div class="list-group-item">
              	                    <div class="col-sm-5">
                                        <p class="list-group-item-text">Hoy la visita se realizó al lote donde se ha comenzado a construir la estructura del hospital. Se puede ver el material, como cemento, ladrillos, varillas de acero y alrededor de 20 trabajadores todos con implementos de protección. </p>
                                    </div>
                                    <div class="col-sm-5">
                                        <p class="list-group-item-text">La programación presentada por el contratista en la Audiencia de Inicio en la cual plantea el comienzo de la construcción de cimientos del hospital está al día y se evidencia de manera adecuada.   </p>
                                    </div>
                                    <div class="col-sm-2"><span class="glyphicon glyphicon-calendar"></span> <span>25/05/2017</span></div>
               	            </div>
                            <div class="list-group">
                                <div class="list-group-item">
              	                    <div class="col-sm-5">
                                        <p class="list-group-item-text">Hoy la visita se realizó al lote donde se ha comenzado a construir la estructura del hospital. Se puede ver el material, como cemento, ladrillos, varillas de acero y alrededor de 20 trabajadores todos con implementos de protección. </p>
                                    </div>
                                    <div class="col-sm-5">
                                        <p class="list-group-item-text">La programación presentada por el contratista en la Audiencia de Inicio en la cual plantea el comienzo de la construcción de cimientos del hospital está al día y se evidencia de manera adecuada.</p>
                                    </div>
                                    <div class="col-sm-2"><span class="glyphicon glyphicon-calendar"></span> <span>25/05/2017</span></div>
               	            </div>
                            <div class="list-group">
                                <div class="list-group-item">
              	                    <div class="col-sm-5">
                                        <p class="list-group-item-text">Hoy la visita se realizó al lote donde se ha comenzado a construir la estructura del hospital. Se puede ver el material, como cemento, ladrillos, varillas de acero y alrededor de 20 trabajadores todos con implementos de protección. </p>
                                    </div>
                                    <div class="col-sm-5">
                                        <p class="list-group-item-text">La programación presentada por el contratista en la Audiencia de Inicio en la cual plantea el comienzo de la construcción de cimientos del hospital está al día y se evidencia de manera adecuada.   </p>
                                    </div>
                                    <div class="col-sm-2"><span class="glyphicon glyphicon-calendar"></span> <span>25/05/2017</span></div>
               	                </div>          
                            </div>
                              </div>
                           </div>
                       </div>
                    </div>
                 </div> 
           </div>
     </div>
</div>

<%--MODALES DIARIO DE NOTAS--%>

 <!-- NUEVA DESCRIPCIÓN REFLEXION U OPINION Y FECHA DE CUMPLIMIENTO -->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
       <div class="modal-dialog" role="document">
                                                <div class="modal-content">
                                                <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                <h4 class="modal-title" id="myModalLabel">Nueva nota</h4>
                                                </div>
                                                <div class="modal-body">
                                                <div class="form-group">
                                                <label for="DescripcionNota" class="control-label">Descripción</label>    
                                                <div id="errorDescripcionNota" class="alert alert-danger alert-dismissible" hidden="hidden" >La descripción no puede ser vacía.</div>
                                                <div id="errorDescripcionAsteriscos" class="alert alert-danger alert-dismissible" hidden="hidden">El nombre de la descripción no puede contener el caracter *.</div>
                                                <textarea id="txtDescripcionNota" placeholder="Por ejemplo: Hoy la visita se realizó al lote donde se ha comenzado a construir la estructura del hospital. Se puede ver el material, como cemento, ladrillos, varillas de acero y alrededor de 20 trabajadores todos con implementos de protección. " class="form-control" rows="5" ></textarea>            
                                                <label for="OpinionNota" class="control-label">Reflexión u opinión</label>    
                                                <div id="errorOpinionNota" class="alert alert-danger alert-dismissible" hidden="hidden" >La descripción no puede ser vacía.</div>
                                                <div id="errorOpinionNotas" class="alert alert-danger alert-dismissible" hidden="hidden">El nombre de la descripción no puede contener el caracter *.</div>
                                                <textarea id="txtOpinion" placeholder="Por ejemplo: La programación presentada por el contratista en la Audiencia de Inicio en la cual plantea el comienzo de la construcción de cimientos del hospital está al día y se evidencia de manera adecuada.    " class="form-control" rows="5" ></textarea>
                                                <label for="fecha_posterior_2" class="control-label">Fecha</label>
                                                <div class="input-group date form_date datetimepicker" data-date="" data-date-format="dd MM yyyy" data-link-field="fecha_posterior_2" data-link-format="yyyy-mm-dd">
                                                <input id="dtpFechaDescripcion" class="form-control" size="16" type="text" value="" readonly>
                                                <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                                                <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                                                </div>
                                                <input type="hidden" id="fecha_posterior_2" value="" />
                                                </div>

                                                 <div class="modal-footer">
                                                 <button id="btnCancelar" type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                                                 <button id="btnGuardar" onclick="GuardarRegistroDescripcionTarea()" type="button" class="btn btn-primary">Guardar</button>
                                                 </div>
                                                 </div>
                                                 </div>
                                                 <script type="text/javascript"> 
			                                    $(".form_datetime").datetimepicker({
			                                            language: "es", 
			                                            weekStart: 1,
			                                            todayBtn: 1,
			                                            autoclose: 1,
			                                            todayHighlight: 1,
			                                            startView: 2,
			                                            forceParse: 0,
			                                            showMeridian: 1
			                                        });
			                                        $(".form_date").datetimepicker({
			                                            language: "es",
			                                            weekStart: 1,
			                                            todayBtn: 1,
			                                            autoclose: 1,
			                                            todayHighlight: 1,
			                                            startView: 2,
			                                            minView: 2,
			                                            forceParse: 0
			                                        });
			                                        $(".form_time").datetimepicker({
			                                            language: "es",
			                                            weekStart: 1,
			                                            todayBtn: 1,
			                                            autoclose: 1,
			                                            todayHighlight: 1,
			                                            startView: 1,
			                                            minView: 0,
			                                            maxView: 1,
			                                            forceParse: 0
			                                            });
                                                   </script>
    </div>
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
                    <div class=" col-sm-6"><span class="glyphicon glyphicon-calendar"></span>Fecha:&nbsp;05/07/2020 </div>
                   <div class=" col-sm-6"><span class="glyphicon glyphicon-time"></span> Hora:&nbsp; 00:00hrs </div>
               	</div>
                    <h4> Para tener en cuenta</h4>
                    
                     <p>Las visitas de campo deben ser programadas por el Grupo Auditor Ciudadano en su plan de trabajo, las cuales tendrán la frecuencia que el Grupo y la comunidad estimen necesarias. </p>
                            <p>Es importante que estas visitas no sean únicamente de la comunidad, por el contrario, dialogar con las autoridades locales, el interventor del proyecto y/o el contratista para que acompañen el ejercicio ciudadano, con el fin de que cada uno de estos actores puedan dar las primeras observaciones técnicas o legales que sirvan de insumo al Grupo Auditor Ciudadano.</p>
                   
               </div>
                <div class="col-sm-3 userActions">
            	
            	<div id="btnFinalizar" onclick="FinalizarTarea()" class="btn btn-default btn-lg"><span class="glyphicon glyphicon-ok"></span><span>Finalizar</span></div>
                <div id="btnEliminar" onclick="EliminarTarea()" class="btn btn-default  btn-lg"><span class="glyphicon glyphicon-trash"></span>Eliminar</div>
            </div>
            
              </div>
		</div>
        <div class="row">
            <div class="col-sm-9">
            	<div class="generalInfo">
                	<div class="tab-content">
                    	<!--CONTENT1 Descripción-->
                        <div id="tab0">
                      <h4>Nombre y cargo de quien acompañó la visita de campo del Grupo Auditor Ciudadano <div class="btn btn-info fr"><a href="" data-toggle="modal" data-target="#NombreCargo"><span class="glyphicon glyphicon-plus"></span> Agregar nombre(s) y cargo(s)</a></div></h4>
                          <p>El nombre y el cargo que desempeña la(s) persona(s) diferentes al Grupo Auditor Ciudadano que acompañó(aron) la visita de campo. Por ejemplo, un funcionario público de la entidad ejecutora, un representante de la empresa contratista, o el interventor del proyecto.
                          </p>
                          <div class="well">
                        	<div class="wrap"></div>
                            <!--DESC-->
                            <p>Pedro Gil, funcionario alcaldía</p>
                            </div>
                      </div>
                      <div id="tab1">
                      <h4>Actividades <div class="btn btn-info fr"><a href="" data-toggle="modal" data-target="#ActividadesDiario"><span class="glyphicon glyphicon-plus"></span> Agregar actividades</a></div></h4>
                          <p>Proponga actividades que desea realizar para el seguimiento al proyecto en la visita de campo, por ejemplo:
                              <ol>
                                  <li>Revisión de actividades según el cronograma que presenta el aplicativo</li>
                                  <li>Revisión de calidad de materiales con el interventor </li>
                                  <li>Revisión del manejo y gestión de residuos sólidos</li>
                              </ol>
                          </p>
                          <div class="well">
                        	<div class="wrap"></div>
                            <p>Actividades 1, actividades2</p>
                            </div> 
                      </div>
                      <div id="tab3" >
                        <h4>Observaciones y registro fotográfico <div class="btn btn-info fr"><a href="" data-toggle="modal" data-target="#ObservacionesFotos"><span class="glyphicon glyphicon-plus"></span> Agregar observaciones y registro fotográfico</a></div></h4>
                        <p>El registro fotográfico será la herramienta para registrar 
                            visualmente el estado de avance del proyecto, en las visitas programadas, 
                            cada fotografía debe tener un objetivo o representar el avance de una actividad particular, 
                            con el propósito de que quien la vea pueda entender la realidad de la ejecución del proyecto.
                        </p> 
                        <div class="list-group-item">
                                <div class="col-sm-6">
                                    <strong>Observaciones</strong>
                                </div>
                                <div class="col-sm-6">
                                    <strong>Registro fotográfico</strong>
                                </div>
                            </div>
                                   <div class="list-group-item">           
                            <div class="col-sm-6">
                            <p>Observación sobre la fotografía</p>
                            </div>
                             <div class="col-sm-6">
                                <div class="row">
                                <div class="card">
                                  <img class="card-img-top" src="img/defaultImg.gif" alt="Registro 1">
                                  <div class="card-block"></div>
                                  </div>
                                </div>
                        	</div>
                            </div>
                      </div>
                      </div>
                            </div>
                        </div>
                      </div>
</div>

<%--MODAL VISITA DE CAMPO--%>
 <!-- NUEVA nombre cargo -->
    <div class="modal fade" id="NombreCargo" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
      <div class="modal-dialog" role="document">
                                                <div class="modal-content">
                                                <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                <h4 class="modal-title" id="myModalLabel">Agregar nombre(s) y cargo(s)</h4>
                                                </div>
                                                <div class="modal-body">
                                                <div class="form-group">
                                                <label for="NombreVisita" class="control-label">Nombre(s) y cargo(s)</label>    
                                                <div id="errorNombreVisita" class="alert alert-danger alert-dismissible" hidden="hidden" >Este campo no puede estar vacío.</div>
                                                <div id="errorNombreVisitaAsteriscos" class="alert alert-danger alert-dismissible" hidden="hidden">Los nombres y cargos no puede contener el caracter *.</div>
                                                <textarea id="txtDescripcion" placeholder="Nombre, cargo" class="form-control" rows="5" ></textarea>            
                                                </div>
                                                <div class="modal-footer">
                                                <button id="btnCancelar" type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                                                <button id="btnGuardar" onclick="GuardarRegistroDescripcionTarea()" type="button" class="btn btn-primary">Guardar</button>
                                                </div>
                                                </div>
                                                </div>
        </div>
   </div>


 <!-- NUEVA Actividades -->
    <div class="modal fade" id="ActividadesDiario" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
      <div class="modal-dialog" role="document">
                                                <div class="modal-content">
                                                <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                <h4 class="modal-title" id="myModalLabel">Agregar actividades</h4>
                                                </div>
                                                <div class="modal-body">
                                                <div class="form-group">
                                                <label for="lblActividades" class="control-label">Actividades</label>    
                                                <div id="errorActividades" class="alert alert-danger alert-dismissible" hidden="hidden" >Este campo no puede estar vacío.</div>
                                                <div id="errorActividadesAsteriscos" class="alert alert-danger alert-dismissible" hidden="hidden">Las actividades no pueden contener el caracter *.</div>
                                                <textarea id="txtActividades" placeholder="Por ejemplo: Revisión de calidad de materiales con el interventor" class="form-control" rows="5" ></textarea>            
                                                </div>
                                                <div class="modal-footer">
                                                <button id="btnCancelar" type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                                                <button id="btnGuardar" onclick="GuardarRegistroDescripcionTarea()" type="button" class="btn btn-primary">Guardar</button>
                                                </div>
                                                </div>
                                                </div>
        </div>
   </div>

 <!-- NUEVA Observaciones y fotos -->
    <div class="modal fade" id="ObservacionesFotos" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
      <div class="modal-dialog" role="document">
                                                <div class="modal-content">
                                                <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                <h4 class="modal-title" id="myModalLabel">Agregar Observaciones y registro fotográfico</h4>
                                                </div>
                                                <div class="modal-body">
                                                <div class="form-group">
                                                <label for="ObservacionesFotos" class="control-label">Observaciones</label>    
                                                <div id="errorObservacionesFotos" class="alert alert-danger alert-dismissible" hidden="hidden" >Este campo no puede estar vacío.</div>
                                                <div id="errorObservacionesFotosAsteriscos" class="alert alert-danger alert-dismissible" hidden="hidden">Las observaciones no pueden contener el caracter *.</div>
                                                <textarea id="txtObservacionesFotos" placeholder="Por ejemplo: Revisión de calidad de materiales con el interventor" class="form-control" rows="5" ></textarea>            
                                                </div>
                                                <label class="modal-title">Agregar Recurso</label><br/>
                                                <input id="SubirFoto" class="file-loading" type="file">
                                                <div id="errorRecursoMultimediaTarea" class="alert alert-danger alert-dismissible" hidden="hidden" >El nombre del recurso no puede ser vacío.</div>
                                                <div class="modal-footer">
                                                <button id="btnCancelar" type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                                                <button id="btnGuardar" onclick="GuardarRegistroDescripcionTarea()" type="button" class="btn btn-primary">Guardar</button>
                                                </div>
                                                </div>
                                                </div>
        </div>
   </div>

   <%--REGISTRO FOTOGRAFICO PARA SEGUIMIENTO DEL PROYECTO--%>

     <div class="container generalInfo" id="tareaSeguimientoProyecto" hidden="hidden">
    	<div class="row">
        	<div class="headSection">
            	<div class="col-sm-12 headTit">
                    <span>TAREA</span>
                </div>
              <div class="col-sm-9">
              <!--	<span class="glyphicon glyphicon-info-sign XLtext"></span>-->
                <h3>Registro fotográfico para el seguimiento del proyecto</h3>
                <div class="row">
                    <div class=" col-sm-6"><span class="glyphicon glyphicon-calendar"></span>Fecha:&nbsp;05/07/2020 </div>
                   <div class=" col-sm-6"><span class="glyphicon glyphicon-time"></span> Hora:&nbsp; 00:00hrs </div>
               	</div>
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
                <div class="col-sm-3 userActions">
            	
            	<div id="btnFinalizar" onclick="FinalizarTarea()" class="btn btn-default btn-lg"><span class="glyphicon glyphicon-ok"></span><span>Finalizar</span></div>
                <div id="btnEliminar" onclick="EliminarTarea()" class="btn btn-default  btn-lg"><span class="glyphicon glyphicon-trash"></span>Eliminar</div>
            </div>
            
              </div>
		</div>
        <div class="row">
            <div class="col-sm-9">
            	<div class="generalInfo">
                	<div class="tab-content">
                      <div id="tab3" >
                        <h4>Información y fotografía <div class="btn btn-info fr"><a href="" data-toggle="modal" data-target="#AgregarRegistro"><span class="glyphicon glyphicon-plus"></span> Agregar información y fotografía</a></div></h4>
                       <div class="col-sm-6">
                                    <div class="card">
                                       <!-- <input id="imagenRecursosDetalleTarea_' + i.toString() + '" class="file-loading" multiple type="file">-->
                                        <img class="card-img-top" src="img/defaultImg.gif" alt="Registro 1">  
                                        <div class="card-block">
                                            <ul class="list-group">
                                            <li class="list-group-item"><p class="card-text">Descripción fotografía </p></li>
                                            <li class="list-group-item"><span class="glyphicon glyphicon-user"></span>&nbsp; Reportado por: Nombre fotografo</li>
                                            <li class="list-group-item"><span class="glyphicon glyphicon-map-marker"></span>&nbsp; Lugar: Villa olimpica</li>
                                            <li class="list-group-item"><span class="glyphicon glyphicon-calendar"></span>&nbsp; Fecha: </li>
                                            </ul>
                                        </div>
                                    </div>
                      </div>
                      </div>
                      </div>
                    </div>
                </div>  
            </div>
        </div>

  <!--MODAL AGREGAR RECURSO FOTOGRAFICO-->
<div class="modal fade" id="AgregarRegistro" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
  <div class="modal-dialog" role="document">
                                                   <div class="modal-content">
                                                   <div class="modal-header">
                                                   <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                   <h4 class="modal-title" id="myModalLabelRecursoTarea">Nueva Descripción</h4>
                                                   </div>
                                                   <div class="modal-body">
                                                   <div class="form-group">
                                                        <label class="modal-title">Agregar Recurso</label><br/>
                                                        <input id="recursoTarea" class="file-loading" type="file">
                                                        <div id="errorRecursoTareaAsterisco" class="alert alert-danger alert-dismissible" hidden="hidden" >El nombre del recurso no puede ser vacío.</div>
                                                        <label for="fecha_posterior_2" class="control-label">Fecha</label>
                                                        <div class="input-group date form_date datetimepicker" data-date="" data-date-format="dd MM yyyy" data-link-field="fecha_posterior_2" data-link-format="yyyy-mm-dd">
                                                            <input id="dtpFechaRecursoMultimedia" class="form-control" size="16" type="text" value="" readonly>
                                                            <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                                                            <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                                                        </div>
                                                        <input type="hidden" id="fecha_posterior_2" value="" />
                                                   </div>
                                                        <div id="errorFechaRecursoMultimedia" class="alert alert-danger alert-dismissible" hidden="hidden" >La fecha de la descripción no puede ser vacía.</div>
                                                        <textarea id="txtDescripcionRecursoMultimedia" placeholder="Describa el recurso que desea ingresar" class="form-control" rows="5" ></textarea>
                                                        <div id="errorDescripcionRecursoMultimedia" class="alert alert-danger alert-dismissible" hidden="hidden">El nombre de la descripción no puede ser vacío.</div>
                                                        <div id="errorDescripcionRecursoMultimediaAsterisco" class="alert alert-danger alert-dismissible" hidden="hidden">El nombre de la descripción no puede contener el caracter *.</div>
                                                         <input type="text" id="txtLugar" placeholder="Escriba el lugar donde fue tomada la fotografía..." class="form-control" rows="5" />
                                                        <div id="errorLugar" class="alert alert-danger alert-dismissible" hidden="hidden">El lugar no puede ser vacío.</div>
                                                        <div id="errorLugarAsterisco" class="alert alert-danger alert-dismissible" hidden="hidden">El lugar no puede contener el caracter *.</div>
                                                    </div>
                                                    <div class="modal-footer">
                                                    <button id="btnCancelar" type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                                                    <button id="btnGuardar" onclick="GuardarRegistroRecursoMultimediaTarea()" type="button" class="btn btn-primary">Guardar</button>
                                                    </div>
                                                    </div>
                                                    </div>
                                                    <script type="text/javascript">
                                                       $(".form_datetime").datetimepicker({
                                                           language: "es",
                                                           weekStart: 1,
                                                           todayBtn: 1,
                                                           autoclose: 1,
                                                           todayHighlight: 1,
                                                           startView: 2,
                                                           forceParse: 0,
                                                           showMeridian: 1
                                                       });
                                                       $(".form_date").datetimepicker({
                                                           language: "es",
                                                           weekStart: 1,
                                                           todayBtn: 1,
                                                           autoclose: 1,
                                                           todayHighlight: 1,
                                                           startView: 2,
                                                           minView: 2,
                                                           forceParse: 0
                                                       });
                                                       $(".form_time").datetimepicker({
                                                           language: "es",
                                                           weekStart: 1,
                                                           todayBtn: 1,
                                                           autoclose: 1,
                                                           todayHighlight: 1,
                                                           startView: 1,
                                                           minView: 0,
                                                           maxView: 1,
                                                           forceParse: 0
                                                           });
                                                      </script>

</div>

<%--<script type="text/javascript" src="../../Scripts/DetalleTarea.js"></script>--%>
<script type="text/javascript">
    MostrarDetallePlanTrabajo();
</script>

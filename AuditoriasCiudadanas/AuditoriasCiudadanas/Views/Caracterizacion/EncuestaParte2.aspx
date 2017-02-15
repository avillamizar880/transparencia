<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EncuestaParte2.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Caracterizacion.EncuestaParte2" %>
<div class="container">
        <%--<input type="hidden" id="hfmunicipio" runat="server"/>--%>
        <input type="hidden" id="hfUsuarioId" runat="server" value=""  />
        <form id="form2" runat="server">
        <h1 class="text-center">Encuesta de caracterización</h1>
        <div class="center-block w60">
     <div class="formSteps">
        	    <div class="step" data-toggle="tooltip" title="En este paso debe ingresar la información básica para ser registrado en nuestro sistema."><span class="glyphicon glyphicon-edit"></span>Paso 1</div>
                <div class="step currentStep" data-toggle="tooltip" title="Encontrará preguntas sobre las condiciones de participación que existen en su municipio."><span class="glyphicon glyphicon-question-sign"></span>Paso 2</div>
                <div class="step" data-toggle="tooltip" title="Responderá preguntas sobre los instrumentos y herramientas que utiliza en su ejercicio de participación, además de recolectar información sobre su experiencia en control social."><span class="glyphicon glyphicon-user"></span>Paso 3</div>
                <div class="step" data-toggle="tooltip" title="Terminación de la encuesta. Siga su recorrido por nuestro sistema."><span class="glyphicon glyphicon-blackboard"></span>Paso 4</div>		
     </div>
     <div class="form-group">
                <label for="lblMecanismosParticipacion">Por favor seleccione los mecanismos de participación ciudadana que ha promovido o en los que ha participado en los últimos tres años:</label>
                            <div class="checkbox">
                                <label class="form-check-label">
                                    <input type="checkbox" name="MecanismosParticipacion" class="form-check-input" id="chkPresidenciales" />
                                    <span>Voto para elecciones presidenciales</span>
                                </label>
                            </div>
                            <div class="checkbox">
                                <label class="form-check-label">
                                    <input type="checkbox" name="MecanismosParticipacion" class="form-check-input" id="chkDepartamento">
                                    <span>Voto para elecciones departamentales</span>
                                </label>
                            </div>
                            <div class="checkbox">
                                <label class="form-check-label">
                                    <input type="checkbox" name="MecanismosParticipacion" class="form-check-input" id="chkMunicipio">
                                    <span>Voto para elecciones municipales</span>
                                </label>
                            </div>
                            <div class="checkbox">
                                <label class="form-check-label">
                                    <input type="checkbox" name="MecanismosParticipacion" class="form-check-input" id="chkLegistativas">
                                    <span>Voto para elecciones legislativas</span>
                                </label>
                            </div>
                            <div class="checkbox">
                                <label class="form-check-label">
                                    <input type="checkbox" name="MecanismosParticipacion" class="form-check-input" id="chkConsultaPopular">
                                    <span>Consulta popular</span>
                                </label>
                            </div>
                            <div class="checkbox">
                                <label class="form-check-label">
                                    <input type="checkbox" name="MecanismosParticipacion" class="form-check-input" id="chkCabildoAbierto">
                                    <span>Cabildo abierto</span>
                                </label>
                            </div>
                            <div class="checkbox">
                                <label class="form-check-label">
                                    <input type="checkbox" name="MecanismosParticipacion" class="form-check-input" id="chkRevocatoria">
                                    <span>Revocatoria de mandato</span>
                                </label>
                            </div>
                            <div class="checkbox">
                                <label class="form-check-label">
                                    <input type="checkbox" name="MecanismosParticipacion" class="form-check-input" id="chkReferendo">
                                    <span>Referendo</span>
                                </label>
                            </div>
                            <div class="checkbox">
                                    <label class="form-check-label">
                                       <input type="checkbox" name="MecanismosParticipacionOtro" class="form-check-input" id="chkOtroMecanismo">
                                       <span>Otro, ¿cuál?</span>
                                    </label>
                                </div>
                            <input id="txtMecanismosParticipacion" type="text" class="form-control" required="required" onkeydown="CambioTexto('errorMecanismosParticipacion')" />
                            <div id="errorMecanismosParticipacion" class="alert alert-danger alert-dismissible" hidden="hidden" >
                                     Por favor ingrese cual es el otro mecanismo de participación ciudadana que ha participado. Este campo es requerido.
                                </div>
                       </div>
     <div class="form-group">
        <label for="lblRecursosAlcaldia">¿La Alcaldía cuenta con recursos destinados para la promoción de la participación ciudadana en su territorio?</label>
        <select id="selRecursosAlcaldia" class="form-control" onchange="CambioValorLista(this)">
            <option value="" disabled selected>Seleccione una opción</option>
            <option>Sí</option>
            <option>No</option>
            <option>No sé</option>
        </select>
        <div id="errorRecursosAlcaldia" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor ingrese si conoce o no si la alcaldía cuenta con recursos para la promoción de la participación ciudadana en su territorio. Este campo es requerido.</div>
     </div>
     <div class="form-group">
        <label for="lblAuditoriasVisibles">¿El DNP ha adelantado auditorías visibles en su municipio?</label>
        <select id="selAuditoriasVisibles" class="form-control" onchange="CambioValorLista(this)">
            <option value="" disabled selected>Seleccione una opción</option>
            <option>Sí</option>
            <option>No</option>
            <option>No sé</option>
        </select>
        <div id="errorAuditoriasVisibles" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor ingrese si conoce o no si el Departamento Nacional de Planeación (DNP) ha adelantado auditorías visibles en su municipio. Este campo es requerido.</div>
     </div>
     <div class="form-group">
        <label for="lbGestionAutoridades">Desde su perspectiva, por favor califique la gestión de las autoridades locales en el momento de promover el control ciudadano a la gestión pública o a proyectos específicos:</label>
        <select id="selGestionAutoridades" class="form-control" onchange="CambioValorLista(this)">
            <option value="" disabled selected>Seleccione una opción</option>
            <option title="Generalmente las autoridades locales no planean o toman acciones para promover el control social en el municipio.">Nula</option>
            <option title="Generalmente las autoridades locales obstaculizan el control social en el municipio o se tardan mucho en planear o tomar acciones para promoverlo.">Mala</option>
            <option title="Las autoridades locales planean acciones para promover el control social en el municipio, pero no siempre las cumplen.">Regular</option>
            <option title="Las autoridades locales planean y toman acciones para promover el control social en el municipio, pero las denuncias, demandas y exigencias ciudadanas no siempre se ven satisfechas.">Buena</option>
            <option title="Las autoridades locales planean y toman acciones para promover el control social en el municipio, y las denuncias, demandas y exigencias ciudadanas generalmente se ven satisfechas.">Excelente</option>
        </select>
        <div id="errorGestionAutoridades" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor califique la gestión de las autoridades locales en el momento de promover el control ciudadano a la gestión pública o a proyectos específicos. Este campo es requerido.</div>
     </div>
     <div class="form-group">
        <label for="lblPlanAccion">La organización civil o instancia de participación con la que actualmente tiene vinculación, ¿cuenta con un plan de acción para orientar su labor de control social?</label>
        <select id="selPlanAccion" class="form-control" onchange="CambioValorLista(this)">
            <option value="" disabled selected>Seleccione una opción</option>
            <option>Sí</option>
            <option>No</option>
<%--            <option>Actualmente me desempeño como funcionario público.</option>--%>
        </select>
        <div id="errorselPlanAccion" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor ingrese una opción a esta pregunta. Este campo es requerido.</div>
     </div>
      <div class="form-group">
                <label for="lblEstrategiaSeguimiento">Por favor seleccione las estrategias, mecanismos o instrumentos que utiliza la ciudadanía para hacer seguimiento a la gestión o a proyectos de las autoridades locales.</label>
                            <div class="checkbox">
                                <label class="form-check-label">
                                    <input type="checkbox" name="estrategiasCiudadania" class="form-check-input" id="chkReuniones">
                                    <span>Reuniones o espacios de encuentro con autoridades locales, contratistas, expertos técnicos, entre otros. </span>
                                </label>
                            </div>
                            <div class="checkbox">
                                <label class="form-check-label">
                                    <input type="checkbox" name="estrategiasCiudadania" class="form-check-input" id="chkRegistroFoto">
                                    <span>Registro fotográfico o de video sobre avances de proyectos o de la gestión de las autoridades locales</span>
                                </label>
                            </div>
                            <div class="checkbox">
                                <label class="form-check-label">
                                    <input type="checkbox" name="estrategiasCiudadania" class="form-check-input" id="chkRegistroEscrito">
                                    <span>Registro escrito sobre avances de proyectos o de la gestión de las autoridades locales</span>
                                </label>
                            </div>
                            <div class="checkbox">
                                <label class="form-check-label">
                                    <input type="checkbox" name="estrategiasCiudadania" class="form-check-input" id="chkRevisionDoc">
                                    <span>Revisión de documentos públicos relacionados con los proyectos o con la gestión de las autoridades locales</span>
                                </label>
                            </div>
                            <div class="checkbox">
                                <label class="form-check-label">
                                    <input type="checkbox" name="estrategiasCiudadania" class="form-check-input" id="chkVisitas">
                                    <span>Visitas al lugar de ejecución de proyectos específicos</span>
                                </label>
                            </div>
                            <div class="checkbox">
                                <label class="form-check-label">
                                    <input type="checkbox" name="estrategiasCiudadania" class="form-check-input" id="chkNingunaEstrategiaSeg">
                                    <span>Ninguno</span>
                                </label>
                            </div>
                                <div class="checkbox">
                                    <label class="form-check-label">
                                        <input type="checkbox" name="estrategiasCiudadaniaOtra" class="form-check-input" id="chkOtraEstrategia">
                                        <span>Otra, ¿cuál?</span>
                                    </label>
                                </div>
                                <input id="txtEstrategiaSeguimiento" type="text" class="form-control" required="required" onkeydown="CambioTexto('errorEstrategiaSeguimiento')"/>
                                <div id="errorEstrategiaSeguimiento" class="alert alert-danger alert-dismissible" hidden="hidden" >
                                    Por favor ingrese la estrategia para hacer seguimiento a la gestión o a proyectos. Este campo es requerido.
                                </div>
                          </div>  
    <div class="botonera text-center" >
        <div class="btn btn-primary" onclick="Atras('1')">Atrás <span class="glyphicon glyphicon-chevron-left"></span></div>
        <div class="btn btn-primary" onclick="Siguiente('3')">Siguiente <span class="glyphicon glyphicon-chevron-right"></span></div>
        <div class="btn btn-primary" onclick="Reenviar('../Views/AccesoInformacion/BuscadorProyectosAuditores','dvPrincipal')">Continuar después ...<span class="glyphicon"></span></div>
    </div>
    </div>
    </form>
    </div>
  
   
<script type="text/javascript">
    $(document).ready(function () {
        InicializarCajasTexto(2);
        $('[data-toggle="tooltip"]').tooltip();
    });
</script>
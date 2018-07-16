<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EncuestaParte3.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Caracterizacion.EncuestaParte3" %>
<div class="container">
        <input type="hidden" id="hfUsuarioId" runat="server"/>
        <form id="form2" runat="server">
        <h1 class="text-center">Encuesta de caracterización</h1>
        <div class="center-block w60">
     <div class="formSteps">
        	<div class="step" data-toggle="tooltip" title="En este paso debe ingresar la información básica para ser registrado en nuestro sistema."><span class="glyphicon glyphicon-edit"></span>Paso 1</div>
            <div class="step" data-toggle="tooltip" title="Encontrará preguntas sobre las condiciones de participación que existen en su municipio."><span class="glyphicon glyphicon-question-sign"></span>Paso 2</div>
            <div class="step currentStep" data-toggle="tooltip" title="Responderá preguntas sobre los instrumentos y herramientas que utiliza en su ejercicio de participación, además de recolectar información sobre su experiencia en control social."><span class="glyphicon glyphicon-user"></span>Paso 3</div>
            <div class="step" data-toggle="tooltip" title="Terminación de la encuesta. Siga su recorrido por nuestro sistema."><span class="glyphicon glyphicon-blackboard"></span>Paso 4</div>				
     </div>
     <div class="form-group">
                <label for="lblEstrategiaHallazgos">Por favor seleccione las estrategias, mecanismos o instrumentos que utiliza la ciudadanía para reportar los hallazgos que obtienen de su ejercicio de control social.</label>
              
                            <div class="checkbox">
                                <label class="form-check-label">
                                    <input type="checkbox" name="EstrategiaHallazgos" class="form-check-input" id="chkReunionesHallazgo">
                                    <span>Reuniones o espacios de encuentro con autoridades locales</span>
                                </label>
                            </div>
                            <div class="checkbox">
                                <label class="form-check-label">
                                    <input type="checkbox" name="EstrategiaHallazgos" class="form-check-input" id="chkPqrsTerritorial">
                                    <span>Uso del Sistema de Peticiones, Quejas y Reclamos de la entidad territorial</span>
                                </label>
                            </div>
                            <div class="checkbox">
                                <label class="form-check-label">
                                    <input type="checkbox" name="EstrategiaHallazgos" class="form-check-input" id="chkRegistroEscritoAvance">
                                    <span>Registro escrito sobre avances de proyectos o de la gestión de las autoridades locales</span>
                                </label>
                            </div>
                            <div class="checkbox">
                                <label class="form-check-label">
                                    <input type="checkbox" name="EstrategiaHallazgos" class="form-check-input" id="chkPresentacionInformes">
                                    <span>Presentación de informes, conceptos o quejas escritas a las autoridades locales o nacionales</span>
                                </label>
                            </div>
                            <div class="checkbox">
                                <label class="form-check-label">
                                    <input type="checkbox" name="EstrategiaHallazgos" class="form-check-input" id="chkFotoHallazgo">
                                    <span>Presentación de fotografías o videos con los hallazgos a autoridades locales o nacionales</span>
                                </label>
                            </div>
                            <div class="checkbox">
                                <label class="form-check-label">
                                    <input type="checkbox" name="EstrategiaHallazgos" class="form-check-input" id="chkPrensaHallazgo">
                                    <span>Presentación de hallazgos a medios de comunicación locales o nacionales</span>
                                </label>
                            </div>
                            <div class="checkbox">
                                <label class="form-check-label">
                                    <input type="checkbox" name="EstrategiaHallazgos" class="form-check-input" id="chkNingunHallazgo">
                                    <span>Ninguno</span>
                                </label>
                            </div>
                           
                                <div class="checkbox">
                                    <label class="form-check-label">
                                        <input type="checkbox" name="EstrategiaHallazgosOtro" class="form-check-input" id="chkOtroHallazgo">
                                        <span>Otro, ¿cuál?</span>
                                    </label>
                                </div>
                                <input id="txtEstrategiaHallazgos" type="text" class="form-control" onkeydown="CambioTexto('errorEstrategiaHallazgos')"/>
                        
                </div>



      <div class="form-group">
                <label for="lblCambiosGestion">¿La labor de control social de las organizaciones sociales o instancias de participación ha motivado algún cambio en la gestión o proyectos de las autoridades locales?</label>
                <select id="selCambiosGestion" class="form-control" onchange="SeleccionarItem('CambiosGestion')">
                    <option value="" disabled selected>Seleccione una opción</option>
                    <option>Sí, ¿podrá indicar uno o dos ejemplos?</option>
                    <option>No</option>
                    <option>No sé</option>
                </select>
                <input id="txtCambiosGestion" type="text" class="form-control" onkeydown="CambioTexto('errorCambiosGestion')"/>
                <div id="errorCambiosGestion" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor indique uno o dos ejemplos. Este campo es requerido.</div>
       </div>
       <div class="form-group">
                <label for="lblFrecuenciaSeguimiento">Desde su experiencia, por favor califique la frecuencia con la que se hacen ejercicios de seguimiento a lo público o de control social sobre la gestión de las autoridades locales en su municipio:</label>
                <select id="selFrecuenciaSeguimiento" class="form-control" onchange="CambioValorLista(this)">
                    <option value="" disabled selected>Seleccione una opción</option>
                    <option>Nunca o rara vez se hacen ejercicios de control social en el municipio</option>
                    <option title="Por ejemplo, el Departamento Nacional de Planeación, el CSIR, PNUD, entre otros.">Sólo cuando hay otras entidades o instancias nacionales o regionales acompañando el proceso.</option>
                    <option title="Por ejemplo, el Departamento Nacional de Planeación, el CSIR, PNUD, entre otros.">De forma permanente y sin la necesidad de otras entidades o instancias acompañantes</option>
                </select>
                <div id="errorselFrecuenciaSeguimiento" class="alert alert-danger alert-dismissible" hidden="hidden">Por favor, seleccione una respuesta a la pregunta. Este campo es requerido.</div>
             </div>
              <div class="form-group">
                <label for="lblRadicaciónDerechoPeticion">Durante el año anterior, ¿usted ha radicado/presentado o ha tramitado una respuesta a al menos un derecho de petición donde se solicita el acceso a información específica o algún documento particular del municipio?</label>
                <select id="selRadicaciónDerechoPeticion" class="form-control" onchange="CambioValorLista(this)">
                    <option value="" disabled selected>Seleccione una opción</option>
                    <option>Sí</option>
                    <option>No</option>
                    <option>No sé</option>
                </select>
                <div id="errorselRadicaciónDerechoPeticion" class="alert alert-danger alert-dismissible" hidden="hidden">Por favor, seleccione una respuesta a la pregunta. Este campo es requerido.</div>
             </div>
                 <div class="form-group">
                <label for="lblFacilidadAccesoInfo">Desde su experiencia, por favor califique la facilidad con la que se puede acceder a la información pública del municipio para hacer seguimiento a la gestión o proyectos de las autoridades locales.</label>
                <select id="selFacilidadAccesoInfo" class="form-control" onchange="CambioValorLista(this)">
                    <option value="" disabled selected>Seleccione una opción</option>
                    <option title="Generalmente los ciudadanos deben recurrir a derechos de petición para acceder a información">Es muy difícil acceder a la información pública del municipio.</option>
                    <option title="Generalmente se encuentra disponible o se entrega sin mayores obstáculos a la ciudadanía">Es relativamente fácil acceder a la información pública del municipio.</option>
                    <option title="Pues se encuentra publicada en sitios web o documentos impresos de fácil acceso">Es fácil acceder a la información pública del municipio.</option>
                </select>
                <div id="errorselFacilidadAccesoInfo" class="alert alert-danger alert-dismissible" hidden="hidden">Por favor, seleccione una respuesta a la pregunta. Este campo es requerido.</div>
             </div>
             <div class="form-group">
                <label for="lblPercepcionSeguridad">Desde su percepción, ¿Usted considera que en su municipio existen condiciones adecuadas de seguridad para realizar control social?</label>
                <select id="selPercepcionSeguridad" class="form-control" onchange="CambioValorLista(this)">
                    <option value="" disabled selected>Seleccione una opción</option>
                    <option>Sí</option>
                    <option>No</option>
                </select>
                <div id="errorselPercepcionSeguridad" class="alert alert-danger alert-dismissible" hidden="hidden">Por favor, seleccione una respuesta a la pregunta. Este campo es requerido.</div>
            </div>     
     </div>
    <div class="botonera text-center" >
        <div class="btn btn-primary" onclick="Atras('2')">Atrás <span class="glyphicon glyphicon-chevron-left"></span></div>
        <div class="btn btn-primary" onclick="Siguiente('4')">Siguiente <span class="glyphicon glyphicon-chevron-right"></span></div>
        <div class="btn btn-primary" onclick="Reenviar('../Views/AccesoInformacion/BuscadorProyectosAuditores','dvPrincipal')">Continuar después ...<span class="glyphicon"></span></div>
    </div>
    </form>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            InicializarCajasTexto(3);
            $('[data-toggle="tooltip"]').tooltip();
        });
    </script>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EncuestaParte3.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Caracterizacion.EncuestaParte3" %>
<div class="container">
       <%-- <input type="hidden" id="hfmunicipio" runat="server"/>--%>
        <input type="hidden" id="hfUsuarioId" runat="server"/>
        <form id="form2" runat="server">
        <h1 class="text-center">Encuesta de caracterización</h1>
        <div class="center-block w60">
     <div class="formSteps">
        	<div class="step"><span class="glyphicon glyphicon-edit"></span>Paso 1</div>
            <div class="step"><span class="glyphicon glyphicon-question-sign"></span>Paso 2</div>
            <div class="step currentStep"><span class="glyphicon glyphicon-user"></span>Paso 3</div>
            <%--<div class="step"><span class="glyphicon glyphicon-equalizer"></span>Paso 4</div>--%>
            <div class="step"><span class="glyphicon glyphicon-blackboard"></span>Paso 4</div>			
     </div>
     
    <%-- <div class="form-group">
        <label for="lblSeguimientoGestionPublica">Durante los últimos tres años, ¿la comunidad y/u organizaciones ciudadanas han hecho seguimiento a la gestión pública de la Alcaldía y/o de la Gobernación?</label>
        <select id="selSeguimientoGestionPublica" class="form-control">
            <option>Sí</option>
            <option>No</option>
            <option>No sé</option>
        </select>
     </div>    --%> 
     <%--<div class="form-group">
        <label for="lblSeguimientoProyectos">Durante los últimos tres años, ¿la comunidad y/u organizaciones ciudadanas han hecho seguimiento a proyectos específicos que se desarrollan o se han desarrollado en su municipio?</label>
        <select id="selSeguimientoProyectos" class="form-control">
            <option>Sí</option>
            <option>No</option>
            <option>No sé</option>
        </select>
     </div>--%>
    <%-- <div class="form-group">
        <label for="lblApoyoAlcaldía">¿Qué tipo de apoyos se ha brindado desde la Alcaldía para promover ejercicios de seguimiento ciudadano a la gestión pública?</label>
        <select id="selApoyoAlcaldía" class="form-control" onchange="SeleccionarItem('ApoyoAlcaldía')">
            <option>Préstamo de instalaciones para reuniones</option>
            <option>Materiales (papel, fotocopias, bolígrafos, entre otros.)</option>
            <option>Asignación directa de dinero</option>
            <option>Viáticos</option>
            <option>Capacitaciones</option>
            <option>Ninguno</option>
            <option>Otra, ¿cuál?</option>
        </select>
        <input id="txtApoyoAlcaldía" type="text" class="form-control" onkeydown="CambioTexto('errorApoyoAlcaldía')"/>
        <div id="errorApoyoAlcaldía" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor ingrese cual es el otro apoyo brindado desde la alcaldía para promover el seguimiento ciudadano a la gestión pública. Este campo es requerido.</div>
     </div>   --%>  
    <%-- <div class="form-group">
        <label for="lbRelacionAdminComunidad">Desde su perspectiva, por favor califique la relación que se da entre la administración municipal y la comunidad en el momento de hacer seguimiento ciudadano a la gestión pública o a proyectos específicos, de acuerdo con las siguiente opciones:</label>
        <select id="selRelacionAdminComunidad" class="form-control">
            <option>Nula. Generalmente no hay diálogo entre ambos porque no se hace seguimiento ciudadano a proyectos o a la gestión pública.</option>
            <option>Mala. Generalmente el diálogo entre ambos es conflictivo y no lleva a cambios importantes en la administración pública o en la organización y capacitación de la sociedad civil.</option>
            <option>Regular. A veces el diálogo se dificulta y otras veces se da de manera correcta. No siempre se logran cambios importantes en la administración pública o en la organización y capacitación de la sociedad civil.</option>
            <option>Buena. Generalmente el diálogo entre ambos es productivo y se logran cambios importantes en la administración pública o en la organización y capacitación de la sociedad civil.</option>
            <option>Excelente. Hay un diálogo permanente y productivo entre ambos y se logran cambios importantes en la administración pública o en la organización y formación de la sociedad civil.</option>
        </select>
     </div>--%>    
   <%--  <div class="form-group">
        <label for="lbGestionComunidad">Desde su perspectiva, por favor califique la gestión de la comunidad o de las organizaciones sociales en el momento de hacer control ciudadano a la gestión pública o a proyectos específicos, de acuerdo con las siguiente opciones:</label>
        <select id="selGestionComunidad" class="form-control">
            <option>Nula.Generalmente la comunidad no se organiza, no se vincula a instancias de participación, o no asiste a las audiencias o eventos y reuniones organizados por la Alcaldía o la Gobernación.</option>
            <option>Mala.La comunidad no se encuentra lo suficientemente organizada o hay conflictos entre los mismos ciudadanos que afectan un buen seguimiento a lo público. No se ponen de acuerdo en sus opiniones.</option>
            <option>Regular. La comunidad se encuentra organizada y generalmente no hay conflictos entre sus miembros, pero requiere mejores capacidades para hacer un seguimiento efectivo a lo público.</option>
            <option>Buena. La comunidad se encuentra organizada y generalmente no hay conflictos entre sus miembros. Tienen las capacidades y la formación suficiente para hacer un seguimiento efectivo a lo público.</option>
            <option>Excelente. La comunidad se encuentra organizada y rara vez hay conflictos entre sus miembros. Tienen las capacidades y la formación suficiente para hacer un seguimiento efectivo a lo público. Sus acciones han generado cambios importantes en la gestión pública.</option>
        </select>
     </div>--%>
 
     <div class="form-group">
        <label for="lblEstrategiaHallazgos">Por favor seleccione las estrategias, mecanismos o instrumentos que utiliza la ciudadanía para reportar los hallazgos que obtienen de su ejercicio de control social.</label>
        <select id="selEstrategiaHallazgos" class="form-control" onchange="SeleccionarItem('EstrategiaHallazgos')">
            <option>Reuniones o espacios de encuentro con autoridades locales. </option>
            <option>Uso del Sistema de Peticiones, Quejas y Reclamos de la entidad territorial.</option>
            <option>Registro escrito sobre avances de proyectos o de la gestión de las autoridades locales</option>
            <option>Presentación de informes, conceptos o quejas escritas a las autoridades locales o nacionales.</option>
            <option>Presentación de fotografías o videos con los hallazgos a autoridades locales o nacionales.</option>
            <option>Presentación de hallazgos a medios de comunicación locales o nacionales.</option>
            <option>Ninguno</option>
            <option>Otra, ¿cuál?</option>
        </select>
        <input id="txtEstrategiaHallazgos" type="text" class="form-control" onkeydown="CambioTexto('errorEstrategiaHallazgos')"/>
        <div id="errorEstrategiaHallazgos" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor ingrese la estrategia para reportar los hallazgos que obtienen de su ejercicio de control social. Este campo es requerido.</div>
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
              <div class="form-group">
                <label for="lblRadicaciónDerechoPeticion">Durante el año 2016, ¿usted ha radicado/presentado o ha tramitado una respuesta a al menos un derecho de petición donde se solicita el acceso a información específica o algún documento particular del municipio?</label>
                <select id="selRadicaciónDerechoPeticion" class="form-control">
                    <option>Sí</option>
                    <option>No</option>
                    <option>No sé</option>
                </select>
             </div>
                 <div class="form-group">
                <label for="lblFacilidadAccesoInfo">Desde su experiencia, por favor califique la facilidad con la que se puede acceder a la información pública del municipio para hacer seguimiento a la gestión o proyectos de las autoridades locales.</label>
                <select id="selFacilidadAccesoInfo" class="form-control">
                    <option>Es muy difícil acceder a la información pública del municipio. Generalmente los ciudadanos deben recurrir a derechos de petición para acceder a información</option>
                    <option>Es relativamente fácil acceder a la información pública del municipio. Generalmente se encuentra disponible o se entrega sin mayores obstáculos a la ciudadanía</option>
                    <option>Es fácil acceder a la información pública del municipio, pues se encuentra publicada en sitios web o documentos impresos de fácil acceso</option>
                </select>
             </div>
               <div class="form-group">
        <label for="lblPercepcionSeguridad">Desde su percepción, ¿Usted considera que en su municipio existen condiciones adecuadas de seguridad para realizar control social?</label>
        <select id="selPercepcionSeguridad" class="form-control">
            <option>Sí</option>
            <option>No</option>
        </select>
     </div>     
    <%-- <div class="form-group">
        <label for="lblFrecuenciaDenunciasControl">¿Con qué tanta frecuencia la comunidad o las organizaciones sociales de su municipio remiten hallazgos o denuncias a entidades de control externo? (por ejemplo, Procuraduría, Personería, Contraloría, Fiscalía).</label>
        <select id="selFrecuenciaDenunciasControl" class="form-control">
            <option>Siempre</option>
            <option>Regularmente</option>
            <option>A veces</option>
            <option>Casi nunca</option>
            <option>Nunca</option>
        </select>
     </div>--%>
    
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
        });
    </script>
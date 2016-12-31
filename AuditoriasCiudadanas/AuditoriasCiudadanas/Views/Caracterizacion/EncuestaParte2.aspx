<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EncuestaParte2.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Caracterizacion.EncuestaParte2" %>
<div class="container">
        <input type="hidden" id="hfmunicipio" runat="server"/>
        <input type="hidden" id="hfUsuarioId" runat="server"/>
        <form id="form2" runat="server">
        <h1 class="text-center">Encuesta de Caracterización</h1>
        <div class="center-block w60">
     <div class="formSteps">
        	<div class="step"><span class="glyphicon glyphicon-edit"></span>Paso 1</div>
            <div class="step currentStep"><span class="glyphicon glyphicon-question-sign"></span>Paso 2</div>
            <div class="step"><span class="glyphicon glyphicon-user"></span>Paso 3</div>
            <div class="step"><span class="glyphicon glyphicon-equalizer"></span>Paso 4</div>
            <div class="step"><span class="glyphicon glyphicon-blackboard"></span>Paso 5</div>			
     </div>
     <div class="form-group">
        <label for="lbVinculacionActual">Por favor indique la(s) organización(es) o instancia(s) con la(s) que actualmente tiene vinculación:</label>
        <select id="selVinculacionActual" class="form-control" onchange="SeleccionarItem('VinculacionActual')">
            <option>Junta de Acción Comunal</option>
            <option>Consejo Territorial de Planeación</option>
            <option>Comité de Desarrollo y Control Social de los Servicios Públicos Domiciliarios</option>
            <option>Gobierno escolar</option>
            <option>Comité Consultivo del OCAD</option>
            <option>Consejo Municipal o Departamental de Participación Ciudadana</option>
            <option>Alianzas para la Prosperidad</option>
            <option>Actualmente me desempeño como funcionario público</option>
            <option>Ninguna</option>
            <option>Otra, ¿cuál?</option>
          </select>
          <%--revisar como hacer para que aparezca el cuadro y poder escribir en la opción de otra, cual?--%>
           <input id="txtVinculacionActual" type="text" class="form-control" onkeydown="CambioTexto('errorVinculacionActual')" hidden="hidden" />
           <div id="errorVinculacionActual" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor ingrese cual es la otra organización(es) o instancia(s) a la que esta vinculado. Este campo es requerido.</div>
     </div>
     <div class="form-group">
                <label for="lbMecanismosParticipacion">Por favor seleccione los mecanismos de participación ciudadana que ha promovido o en los que ha participado en los últimos tres años:</label>
                <select id="selMecanismosParticipacion" class="form-control" onchange="SeleccionarItem('MecanismosParticipacion')">
                    <option>Voto para elecciones presidenciales</option>
                    <option>Voto para elecciones departamentales</option>
                    <option>Voto para elecciones municipales</option>
                    <option>Voto para elecciones legislativas</option>
                    <option>Consulta popular</option>
                    <option>Cabildo abierto</option>
                    <option>Revocatoria del mandato</option>
                    <option>Referendo</option>
                    <option>Otra, ¿cuál?</option>
                </select>
                <input id="txtMecanismosParticipacion" type="text" class="form-control" required="required" onkeydown="CambioTexto('errorMecanismosParticipacion')" />
                <div id="errorMecanismosParticipacion" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor ingrese cual es el otro mecanismo de participación ciudadana que ha participado. Este campo es requerido.</div>
            </div>
     <div class="form-group">
        <label for="lblEspacioCiudadanoFuncionario">Por favor seleccione los espacios en los que ha participado como ciudadano o funcionario público durante los últimos tres años en su municipio:</label>
        <select id="selEspacioCiudadanoFuncionario" class="form-control" onchange="SeleccionarItem('EspacioCiudadanoFuncionario')">
            <option>Audiencia pública</option>
            <option>Foro ciudadano</option>
            <option>Mesas de diálogo</option>
            <option>Asambleas comunitarias</option>
            <option>Otra, ¿cuál?</option>
            <option>Ninguno</option>
        </select>
        <input id="txtEspacioCiudadanoFuncionario" type="text" class="form-control" onkeydown="CambioTexto('errorEspacioCiudadanoFuncionario')"/>
        <div id="errorEspacioCiudadanoFuncionario" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor ingrese cual es el otro espacio en el que ha participado como ciudadano o funcionario público. Este campo es requerido.</div>
     </div>
     <div class="form-group">
        <label for="lblRecursosAlcaldia">¿La Alcaldía cuenta con recursos destinados para la promoción de la participación ciudadana en su territorio?</label>
        <select id="selRecursosAlcaldia" class="form-control">
            <option>Sí</option>
            <option>No</option>
            <option>No sé</option>
        </select>
     </div>
     <div class="form-group">
        <label for="lblAuditoriasVisibles">¿El DNP ha adelantado Auditorías Visibles en su municipio?</label>
        <select id="selAuditoriasVisibles" class="form-control">
            <option>Sí</option>
            <option>No</option>
            <option>No sé</option>
        </select>
     </div>
    <%-- Añadir dos más--%>
     <div class="form-group">
        <label for="lbParticipacionAnterior">Por favor indique la(s) organización(es) o instancia(s) con la(s) que en algún momento ha tenido vinculación:</label>
        <select id="selParticipacionAnterior" class="form-control" onchange="SeleccionarItem('ParticipacionAnterior')">
            <option>Junta de Acción Comunal</option>
            <option>Consejo Territorial de Planeación</option>
            <option>Comité de Desarrollo y Control Social de los Servicios Públicos Domiciliarios</option>
            <option>Gobierno escolar</option>
            <option>Comité Consultivo del OCAD</option>
            <option>Consejo Municipal o Departamental de Participación Ciudadana</option>
            <option>Alianzas para la Prosperidad</option>
            <option>Ninguna</option>
            <option>Otra, ¿cuál?</option>
          </select>
          <%--revisar como hacer para que aparezca el cuadro y poder escribir en la opción de otra, cual?--%>
           <input id="txtParticipacionAnterior" type="text" class="form-control" onkeydown="CambioTexto('errorParticipacionAnterior')" hidden="hidden" />
           <div id="errorParticipacionAnterior" class="alert alert-danger alert-dismissible" hidden="hidden" > Por favor ingrese cual es la otra organización(es) o instancia(s) a la cual ha estado vinculado. Este campo es requerido.</div>
     </div>
     <div class="form-group">
                <label for="lbCapacitacionesEntidades">¿Qué entidades o instancias han brindado capacitaciones sobre participación ciudadana o control social para ciudadanos en los últimos tres años?:</label>
                <select id="selCapacitacionesEntidades" class="form-control" onchange="SeleccionarItem('CapacitacionesEntidades')">
                    <option>Alcaldía</option>
                    <option>Personería</option>
                    <option>Comisión Regional Moralización</option>
                    <option>Red de apoyo a las Veedurías Ciudadanas</option>
                    <option>Organizaciones no gubernamentales</option>
                    <option>Ninguna</option>
                    <option>Otra, ¿cuál?</option>
                </select>
                <input id="txtCapacitacionesEntidades" type="text" class="form-control" required="required" onkeydown="CambioTexto('errorCapacitacionesEntidades')" />
                <div id="errorCapacitacionesEntidades" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor ingrese cual es la otra entidad que ha brindado capacitaciones sobre participación ciudadana. Este campo es requerido.</div>
            </div>
    </div>
    <div class="botonera text-center" >
        <div class="btn btn-primary" onclick="Atras('1')">Atrás <span class="glyphicon glyphicon-chevron-left"></span></div>
        <div class="btn btn-primary" onclick="Siguiente('2')">Siguiente <span class="glyphicon glyphicon-chevron-right"></span></div>
    </div>
    </form>
    </div>
<script type="text/javascript">
    $(document).ready(function () {
        InicializarCajasTexto();
    });

</script>
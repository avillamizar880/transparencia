<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EncuestaParte1.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Caracterizacion.EncuestaParte1" %>
<div class="container">
        <input type="hidden" id="hfUsuarioId" value="" runat="server"/>
    	<h1 class="text-center">Encuesta de caracterización</h1>
        <div class="center-block w60">
            <div class="formSteps">
                <div class="step currentStep" data-toggle="tooltip" title="En este paso debe ingresar la información básica para ser registrado en nuestro sistema."><span class="glyphicon glyphicon-edit"></span>Paso 1</div>
                <div class="step" data-toggle="tooltip" title="Encontrará preguntas sobre las condiciones de participación que existen en su municipio."><span class="glyphicon glyphicon-question-sign"></span>Paso 2</div>
                <div class="step" data-toggle="tooltip" title="Responderá preguntas sobre los instrumentos y herramientas que utiliza en su ejercicio de participación, además de recolectar información sobre su experiencia en control social."><span class="glyphicon glyphicon-user"></span>Paso 3</div>
                <div class="step" data-toggle="tooltip" title="Terminación de la encuesta. Siga su recorrido por nuestro sistema."><span class="glyphicon glyphicon-blackboard"></span>Paso 4</div>		
            </div>
             <div class="well">
                <p>La información que se diligencie en esta encuesta tiene fines estadísticos. Es decir, los datos individuales que usted brinde no se publicarán ni divulgarán en ningún medio.</p>
            </div>
            <form id="form1" runat="server">
                <div class="row">
                    <div class="col-sm-6">
                        <div class="form-group">
                             <label for="genero">Género</label>
                             <select class="form-control" id="genero" onchange="CambioValorLista(this)">
                                <option value="" disabled selected>Seleccione una opción</option>
                                <option>Masculino</option>
                                <option>Femenino</option>
                                <option>Otro</option>
                             </select>
                             <div id="errorGenero" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor ingrese su género. Este campo es requerido.</div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="form-group">
                            <label for="lblRangoEdad">Rango de edad:</label>
                            <select id="selRangoEdad" class="form-control" onchange="CambioValorLista(this)">
                               <option value="" disabled selected>Seleccione una opción</option>
                                <option>15 a 19</option>
                                <option>20 a 24</option>
                                <option>25 a 29</option>
                                <option>30 a 34</option>
                                <option>35 a 39</option>
                                <option>40 a 44</option>
                                <option>45 a 49</option>
                                <option>50 a 54</option>
                                <option>55 a 59</option>
                                <option>60 a 64</option>
                                <option>65 a 69</option>
                                <option>70 o más</option>
                            </select>
                            <div id="errorRangoEdad" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor ingrese un rango de edad. Este campo es requerido.</div>
                        </div>
                </div>
                    </div>
                <div class="form-group">
                        <label for="ocupacion">Ocupación</label>
                        <input type="text" class="form-control" id="ocupacion" required="required" placeholder="Ocupación" onkeydown="CambioTexto('errorOcupacion')"/>
                         <div id="errorOcupacion" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor ingrese su ocupación. Este campo es requerido.</div>
                    </div>
             
                <div class="form-group">
                        <label for="lblLugarResidencia">Actualmente usted reside en:</label>
                        <select id="selLugarResidencia" class="form-control" onchange="CambioValorLista(this)">
                            <option value="" disabled selected>Seleccione una opción</option>
                            <option>Cabecera municipal</option>
                            <option>Área rural del municipio</option>
                        </select>
                        <div id="errorLugarResidencia" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor ingrese su lugar de residencia. Este campo es requerido.</div>
                    </div>
                <div class="form-group">
                        <label for="lblComunidadPertenece">¿Pertenece a una comunidad étnica minoritaria? (afro, rom, palenquera, raizal, comunidad indígena)</label>
                        <select id="selComunidadPertenece" class="form-control" onchange="CambioValorLista(this)">
                            <option value="" disabled selected>Seleccione una opción</option>
                            <option>Sí</option>
                            <option>No</option>
                        </select>
                        <div id="errorComunidadPertenece" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor indique si pertenece o no a una comunidad étnica. Este campo es requerido.</div>
                    </div>
                <div class="form-group">
                        <label for="lblOrganizacionPertenece">¿Actualmente pertenece a alguna organización social o instancia de participación ciudadana?</label>
                        <select id="selOrganizacionPertenece" class="form-control" onchange="CambioValorLista(this)">
                            <option value="" disabled selected>Seleccione una opción</option>
                            <option>Sí</option>
                            <option>No</option>
                        </select>
                        <div id="errorOrganizacionPertenece" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor indique si pertenece o no a una organización social. Este campo es requerido.</div>
                    </div>
                <div class="botonera text-center">
                        <div class="btn btn-primary" onclick="Siguiente('2')">Siguiente </div>
                    </div>
            </form>
        </div>
    </div>
<script type="text/javascript">
    $(document).ready(function () {
        //ObtenerMunicipiosEncuestaCaracterizacion();
        ObtenerDatosEncuestaUsuario(1);
        $('[data-toggle="tooltip"]').tooltip();
    });
</script>




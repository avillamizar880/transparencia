function ObtenerMunicipios() {
    $("#error_municipio").hide();
    $.ajax({
        type: "POST", url: '../../Views/Caracterizacion/Encuesta_ajax', data: { Municipio: "Municipio" }, traditional: true,
        beforeSend: function () {
            waitblockUIParamEvaluarEncuestaCaracterizacion('Cargando datos municipios...');
        },
        success: function (result)
        {
            var dataSource = result.split("\n");
            $('#txtmunicipio').typeahead({ source: dataSource })
            unblockUI();
            ObtenerDatosEncuestaUsuario(1);
        }
    });
}
function ObtenerDatosEncuestaUsuario(pagina)
{
    switch (pagina)
    {
        case 1:
            $.ajax({
                type: "POST",
                url: '../../Views/Caracterizacion/Encuesta_ajax', data: { ObtenerDatosEncuestaUsuarioParte1: $("#hfUsuarioId").val()},
                traditional: true,
                cache: false,
                dataType: "json",
                beforeSend: function ()
                {
                    waitblockUIParamEvaluarEncuestaCaracterizacion('Cargando datos usuario encuesta parte 1...');
                },
                success: function (result) {
                    if (result != null && result != "") {
                        for (var i = 0; i < result.Head.length; i++)
                        {
                            $("#txtmunicipio").val(result.Head[i].Municipio);
                            $("#genero").val(result.Head[i].Genero);
                            $("#selRangoEdad").val(result.Head[i].RangoEdad);
                            $("#ocupacion").val(result.Head[i].Ocupacion);
                            $("#selCargoActual").val(result.Head[i].Cargo);
                            $("#selLugarResidencia").val(result.Head[i].LugarResidencia);
                            $("#selComunidadPertenece").val(result.Head[i].PerteneceMinoria);
                            $("#selOrganizacionPertenece").val(result.Head[i].PerteneceOrganizacionSocial);
                        }
                    }
                    unblockUI();
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("error");
                    alert(textStatus + ": " + XMLHttpRequest.responseText);
                    unblockUI();
                }
            });
            break;
        case 2:
            $.ajax({
                type: "POST",
                url: '../../Views/Caracterizacion/Encuesta_ajax', data: { ObtenerDatosEncuestaUsuarioParte2: $("#hfUsuarioId").val() + '*' + $("#hfmunicipio").val() },
                traditional: true,
                cache: false,
                dataType: "json",
                beforeSend: function () {
                    waitblockUIParamEvaluarEncuestaCaracterizacion('Cargando datos usuario encuesta parte 1...');
                },
                success: function (result)
                {
                    if (result != null && result != "")
                    {
                        for (var i = 0; i < result.Head.length; i++)
                        {
                            $("#txtVinculacionActual").hide();
                            $("#txtMecanismosParticipacion").hide();
                            $("#txtEspacioCiudadanoFuncionario").hide();
                            $("#txtParticipacionAnterior").hide();
                            $("#txtCapacitacionesEntidades").hide();
                            if (result.Head[i].ViculacionActual.toUpperCase() != "NULL")
                            {
                                switch (result.Head[i].ViculacionActual.toUpperCase())
                                {
                                    case "JUNTA DE ACCIÓN COMUNAL":
                                    case "CONSEJO TERRITORIAL DE PLANEACIÓN":
                                    case "COMITÉ DE DESARROLLO Y CONTROL SOCIAL DE LOS SERVICIOS PÚBLICOS DOMICILIARIOS":
                                    case "GOBIERNO ESCOLAR":
                                    case "COMITÉ CONSULTIVO DEL OCAD":
                                    case "CONSEJO MUNICIPAL O DEPARTAMENTAL DE PARTICIPACIÓN CIUDADANA":
                                    case "ALIANZAS PARA LA PROSPERIDAD":
                                    case "ACTUALMENTE ME DESEMPEÑO COMO FUNCIONARIO PÚBLICO":
                                    case "NINGUNA":
                                        $("#selVinculacionActual").val(result.Head[i].ViculacionActual);
                                        break;
                                    default:
                                        $("#selVinculacionActual").val('Otra, ¿cuál?');
                                        $("#txtVinculacionActual").val(result.Head[i].ViculacionActual);
                                        $("#txtVinculacionActual").show();
                                        break;

                                }
                            }
                            if (result.Head[i].MecanismoHaParticipado.toUpperCase() != "NULL")
                            {
                                switch (result.Head[i].MecanismoHaParticipado.toUpperCase())
                                {
                                    case "VOTO PARA ELECCIONES PRESIDENCIALES":
                                    case "VOTO PARA ELECCIONES DEPARTAMENTALES":
                                    case "VOTO PARA ELECCIONES MUNICIPALES":
                                    case "VOTO PARA ELECCIONES LEGISLATIVAS":
                                    case "CONSULTA POPULAR":
                                    case "CABILDO ABIERTO":
                                    case "REVOCATORIA DEL MANDATO":
                                    case "REFERENDO":
                                        $("#selMecanismosParticipacion").val(result.Head[i].MecanismoHaParticipado);
                                        break;
                                    default:
                                        $("#selMecanismosParticipacion").val('Otra, ¿cuál?');
                                        $("#txtMecanismosParticipacion").val(result.Head[i].MecanismoHaParticipado);
                                        $("#txtMecanismosParticipacion").show();
                                        break;
                                }
                            }
                            if (result.Head[i].EspaciosParticipadoCiudadano.toUpperCase() != "NULL")
                            {
                                switch (result.Head[i].EspaciosParticipadoCiudadano.toUpperCase())
                                {
                                    case "AUDIENCIA PÚBLICA":
                                    case "FORO CIUDADANO":
                                    case "MESAS DE DIÁLOGO":
                                    case "ASAMBLEAS COMUNITARIAS":
                                    case "NINGUNO":
                                        $("#selEspacioCiudadanoFuncionario").val(result.Head[i].EspaciosParticipadoCiudadano);
                                        break;
                                    default:
                                        $("#selEspacioCiudadanoFuncionario").val('Otra, ¿cuál?');
                                        $("#txtEspacioCiudadanoFuncionario").val(result.Head[i].EspaciosParticipadoCiudadano);
                                        $("#txtEspacioCiudadanoFuncionario").show();
                                        break;
                                }
                            }
                            if (result.Head[i].RecursosAlcaldia.toUpperCase() != "NULL") $("#selRecursosAlcaldia").val(result.Head[i].RecursosAlcaldia);
                            if (result.Head[i].AuditoriasVisiblesDNP.toUpperCase() != "NULL") $("#selAuditoriasVisibles").val(result.Head[i].AuditoriasVisiblesDNP);
                            if (result.Head[i].ParticipacionAnterior.toUpperCase() != "NULL")
                            {
                                switch (result.Head[i].ParticipacionAnterior.toUpperCase()) {
                                    case "JUNTA DE ACCIÓN COMUNAL":
                                    case "CONSEJO TERRITORIAL DE PLANEACIÓN":
                                    case "COMITÉ DE DESARROLLO Y CONTROL SOCIAL DE LOS SERVICIOS PÚBLICOS DOMICILIARIOS":
                                    case "GOBIERNO ESCOLAR":
                                    case "COMITÉ CONSULTIVO DEL OCAD":
                                    case "CONSEJO MUNICIPAL O DEPARTAMENTAL DE PARTICIPACIÓN CIUDADANA":
                                    case "ALIANZAS PARA LA PROSPERIDAD":
                                    case "NINGUNA":
                                        $("#selParticipacionAnterior").val(result.Head[i].ParticipacionAnterior);
                                        break;
                                    default:
                                        $("#selParticipacionAnterior").val('Otra, ¿cuál?');
                                        $("#txtParticipacionAnterior").val(result.Head[i].ParticipacionAnterior);
                                        $("#txtParticipacionAnterior").show();
                                        break;
                                }
                            }
                            if (result.Head[i].CapacitacionEntidades.toUpperCase() != "NULL") {
                                switch (result.Head[i].CapacitacionEntidades.toUpperCase()) {
                                    case "ALCALDÍA":
                                    case "PERSONERÍA":
                                    case "COMISIÓN REGIONAL MORALIZACIÓN":
                                    case "RED DE APOYO A LAS VEEDURÍAS CIUDADANAS":
                                    case "ORGANIZACIONES NO GUBERNAMENTALES":
                                    case "NINGUNA":
                                        $("#selCapacitacionesEntidades").val(result.Head[i].CapacitacionEntidades);
                                        break;
                                    default:
                                        $("#selCapacitacionesEntidades").val('Otra, ¿cuál?');
                                        $("#txtCapacitacionesEntidades").val(result.Head[i].CapacitacionEntidades);
                                        $("#txtCapacitacionesEntidades").show();
                                        break;
                                }
                            }
                            
                        }
                    }
                    unblockUI();
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("error");
                    alert(textStatus + ": " + XMLHttpRequest.responseText);
                    unblockUI();
                }
            });
            break;
    }
}
function Atras(pagina)
{
    switch (pagina)
    {
        case "1":
            cargaMenuParams('Caracterizacion/EncuestaParte1', 'dvPrincipal', $("#hfUsuarioId").val());
            break;
        case "2":
            cargaMenuParams('Caracterizacion/EncuestaParte2', 'dvPrincipal', $("#txtmunicipio").val() + '*' + $("#hfUsuarioId").val());
            break;
    }
}
function Siguiente(pagina)
{
    switch (pagina)
    {
        case "1":
            var guardarRegistro= ValidarCamposPagina(1);
            if (guardarRegistro == true)
            {
                $.ajax({
                    type: "POST", url: '../../Views/Caracterizacion/Encuesta_ajax', data: { ValidarNombreMunicipio: $("#txtmunicipio").val() + '*' + $("#departamento").val() + '*' + $("#selRangoEdad").val() + '*' + $("#ocupacion").val() + '*' + $("#selCargoActual").val() + '*' + $("#selLugarResidencia").val() + '*' + $("#selComunidadPertenece").val() + '*' + $("#selOrganizacionPertenece").val() }, traditional: true,
                    beforeSend: function () {
                        waitblockUIParamEvaluarEncuestaCaracterizacion('Validando nombre Municipio');
                    },
                    success: function (result) 
                    {
                        unblockUI();
                        if (result.toUpperCase() == 'TRUE')
                        {
                            $("#errorMunicipio").html('');
                            $("#errorMunicipio").hide();
                            GuardarEncuestaCaracterizacion(pagina);
                        }
                        else if (result.toUpperCase() == 'FALSE') {
                            $("#errorMunicipio").html('No existe el municipio ' + $("#txtmunicipio").val() + ' en la base de datos o se encuentra mal escrito. <br> Se recomienda usar el nombre del municipio que se muestra en la lista.');
                            $("#errorMunicipio").show();
                        }
                       
                    }
                });
            }
            break;
        case "2":
            var guardarRegistro = ValidarCamposPagina(2);
            if (guardarRegistro == true)
            {
                GuardarEncuestaCaracterizacion(pagina);
            }
            break;
        case "3":
            //Formulario EncuestaParte3.aspx
            var errorParticipacionAnterior = 'False';
            var errorCapacitacionesEntidades = 'False';
            var errorApoyoAlcaldía = 'False';
            var errorEstrategiaSeguimiento = 'False';
            var errorEstrategiaHallazgos = 'False';
            var errorCambiosGestion = 'False';
            //Formulario EncuestaParte3.aspx
            //Verificación casilla otra cual.           
            if ($("#selApoyoAlcaldía").val() == "Otra, ¿cuál?") {
                var caracteresEspeciales = $("#txtApoyoAlcaldía").val().split('*');
                if ($("#txtApoyoAlcaldía").val() == '') {
                    $("#errorApoyoAlcaldía").html('Por favor ingrese cual es el otro apoyo brindado desde la alcaldía para promover el seguimiento ciudadano a la gestión pública. Este campo es requerido.');
                    $("#errorApoyoAlcaldía").show();
                    errorApoyoAlcaldía = 'True';
                }
                else if (caracteresEspeciales.length > 1) {
                    $("#errorApoyoAlcaldía").html('El caracter * no está permitido. Por favor elimine este caracter de la casilla.');
                    $("#errorApoyoAlcaldía").show();
                    errorApoyoAlcaldía = 'True';
                }
                else {
                    $("#errorApoyoAlcaldía").html('');
                    $("#errorApoyoAlcaldía").hide();
                }
            }
            if ($("#selEstrategiaSeguimiento").val() == "Otra, ¿cuál?") {
                var caracteresEspeciales = $("#txtEstrategiaSeguimiento").val().split('*');
                if ($("#txtEstrategiaSeguimiento").val() == '') {
                    $("#errorEstrategiaSeguimiento").html('Por favor ingrese la estrategia para hacer seguimiento a la gestión o a proyectos. Este campo es requerido.');
                    $("#errorEstrategiaSeguimiento").show();
                    errorEstrategiaSeguimiento = 'True';
                }
                else if (caracteresEspeciales.length > 1) {
                    $("#errorEstrategiaSeguimiento").html('El caracter * no está permitido. Por favor elimine este caracter de la casilla.');
                    $("#errorEstrategiaSeguimiento").show();
                    errorEstrategiaSeguimiento = 'True';
                }
                else {
                    $("#errorEstrategiaSeguimiento").html('');
                    $("#errorEstrategiaSeguimiento").hide();
                }
            }
            if ($("#selEstrategiaHallazgos").val() == "Otra, ¿cuál?") {
                var caracteresEspeciales = $("#txtEstrategiaHallazgos").val().split('*');
                if ($("#txtEstrategiaHallazgos").val() == '') {
                    $("#errorEstrategiaHallazgos").html('Por favor ingrese la estrategia para reportar los hallazgos que obtienen de su ejercicio de control social. Este campo es requerido.');
                    $("#errorEstrategiaHallazgos").show();
                    errorEstrategiaHallazgos = 'True';
                }
                else if (caracteresEspeciales.length > 1) {
                    $("#errorEstrategiaHallazgos").html('El caracter * no está permitido. Por favor elimine este caracter de la casilla.');
                    $("#errorEstrategiaHallazgos").show();
                    errorEstrategiaHallazgos = 'True';
                }
                else {
                    $("#errorEstrategiaHallazgos").html('');
                    $("#errorEstrategiaHallazgos").hide();
                }
            }
            if ($("#selCambiosGestion").val() == "Sí, ¿podrá indicar uno o dos ejemplos?") {
                var caracteresEspeciales = $("#txtCambiosGestion").val().split('*');
                if ($("#txtCambiosGestion").val() == '') {
                    $("#errorCambiosGestion").html('Por favor indique uno o dos ejemplos. Este campo es requerido.');
                    $("#errorCambiosGestion").show();
                    errorCambiosGestion = 'True';
                }
                else if (caracteresEspeciales.length > 1) {
                    $("#errorCambiosGestion").html('El caracter * no está permitido. Por favor elimine este caracter de la casilla.');
                    $("#errorCambiosGestion").show();
                    errorCambiosGestion = 'True';
                }
                else {
                    $("#errorCambiosGestion").html('');
                    $("#errorCambiosGestion").hide();
                }
            }
            //Fin Verificación
            if (errorParticipacionAnterior == 'False' && errorCapacitacionesEntidades == 'False' && errorApoyoAlcaldía == 'False' && errorEstrategiaSeguimiento == 'False' && errorEstrategiaHallazgos == 'False' && errorCambiosGestion == 'False') {
                $.ajax({
                    type: "POST", url: '../../Views/Caracterizacion/Encuesta_ajax', data: { Guardar: $("#selVinculacionActual").val() + '*' + $("#txtVinculacionActual").val() + '*' + $("#selMecanismosParticipacion").val() + '*' + $("#txtMecanismosParticipacion").val() + '*' + $("#selEspacioCiudadanoFuncionario").val() + '*' + $("#txtEspacioCiudadanoFuncionario").val() + '*' + $("#selRecursosAlcaldia").val() + '*' + $("#selAuditoriasVisibles").val() }, traditional: true,
                    beforeSend: function () {
                        waitblockUIValidacion();
                    },
                    success: function (result) {
                        if (result == 'True') {
                            window.location = 'EncuestaParte4';
                        }
                        unblockUI();

                    }
                });
            }
            break;
    }
}
function GuardarEncuestaCaracterizacion(pagina)
{
    switch (pagina)
    {
        case "1":
            $.ajax({
                type: "POST", url: '../../Views/Caracterizacion/Encuesta_ajax', data: { GuardarPag1: $("#txtmunicipio").val() + '*' + $("#genero").val() + '*' + $("#selRangoEdad").val() + '*' + $("#ocupacion").val() + '*' + $("#selCargoActual").val() + '*' + $("#selLugarResidencia").val() + '*' + $("#selComunidadPertenece").val() + '*' + $("#selOrganizacionPertenece").val() + '*' + $("#hfUsuarioId").val() }, traditional: true,
                beforeSend: function () {
                    waitblockUIParamEvaluarEncuestaCaracterizacion('Guardando encuesta...');
                },
                success: function (result)
                {
                    unblockUI();
                    if (result == '<||>')
                        cargaMenuParams('Caracterizacion/EncuestaParte2', 'dvPrincipal', $("#txtmunicipio").val() + '*' + $("#hfUsuarioId").val());
                }
            });
            break;
        case "2":
            $.ajax({
                type: "POST", url: '../../Views/Caracterizacion/Encuesta_ajax', data: { Guardarpag2: $("#selVinculacionActual").val() + '*' + $("#txtVinculacionActual").val() + '*' + $("#selMecanismosParticipacion").val() + '*' + $("#txtMecanismosParticipacion").val() + '*' + $("#selEspacioCiudadanoFuncionario").val() + '*' + $("#txtEspacioCiudadanoFuncionario").val() + '*' + $("#selRecursosAlcaldia").val() + '*' + $("#selAuditoriasVisibles").val() + '*' + $("#selParticipacionAnterior").val() + '*' + $("#txtParticipacionAnterior").val() + '*' + $("#selCapacitacionesEntidades").val() + '*' + $("#txtCapacitacionesEntidades").val() + '*' + $("#hfUsuarioId").val() + '*' + $("#hfmunicipio").val() }, traditional: true,
                beforeSend: function ()
                {
                    waitblockUIParamEvaluarEncuestaCaracterizacion('Actualizando registro');
                },
                success: function (result)
                {
                    unblockUI();
                    if (result == '<||>')
                        cargaMenuParams('Caracterizacion/EncuestaParte3', 'dvPrincipal', $("#txtmunicipio").val() + '*' + $("#hfUsuarioId").val());
                }
            });
        break;
    }
   
}
function ValidarCamposPagina(pagina)
{
    switch (pagina)
    {
        case 1:
            $("#errorOcupacion").hide();
            $("#errorMunicipio").hide();
            if ($("#txtmunicipio").val() == '')
            {
                $("#errorMunicipio").show();
                return false;
            }
            var caracteresEspeciales = $("#ocupacion").val().split('*');
            if ($("#ocupacion").val() == '')
            {
                $("#errorOcupacion").html('Por favor ingrese su ocupación. Este campo es requerido.');
                $("#errorOcupacion").show();
                return false;
            }
            else if (caracteresEspeciales.length > 1)
            {
                $("#errorOcupacion").html('El caracter * no está permitido. Por favor elimine este caracter de la casilla ocupación.');
                $("#errorOcupacion").show();
                return false;
            }
            else
            {
                $("#errorOcupacion").html('');
                return true;
            }
            break;
        case 2:
            if ($("#selVinculacionActual").val() == "Otra, ¿cuál?") {
                var caracteresEspeciales = $("#txtVinculacionActual").val().split('*');
                if ($("#txtVinculacionActual").val() == '') {
                    $("#errorVinculacionActual").html('Por favor ingrese cual es la otra organización(es) o instancia(s) a la que esta vinculado. Este campo es requerido.');
                    $("#errorVinculacionActual").show();
                    return false;
                }
                else if (caracteresEspeciales.length > 1) {
                    $("#errorVinculacionActual").html('El caracter * no está permitido. Por favor elimine este caracter de la casilla.');
                    $("#errorVinculacionActual").show();
                    return false;
                }
                else {
                    $("#errorVinculacionActual").html('');
                    $("#errorVinculacionActual").hide();
                }
            }
            else $("#txtVinculacionActual").val('');
            if ($("#selMecanismosParticipacion").val() == "Otra, ¿cuál?") {
                var caracteresEspeciales = $("#txtMecanismosParticipacion").val().split('*');
                if ($("#txtMecanismosParticipacion").val() == '') {
                    $("#errorMecanismosParticipacion").html('Por favor ingrese cual es el otro mecanismo de participación ciudadana que ha participado. Este campo es requerido.');
                    $("#errorMecanismosParticipacion").show();
                    return false;
                }
                else if (caracteresEspeciales.length > 1) {
                    $("#errorMecanismosParticipacion").html('El caracter * no está permitido. Por favor elimine este caracter de la casilla.');
                    $("#errorMecanismosParticipacion").show();
                    return false;
                }
                else {
                    $("#errorMecanismosParticipacion").html('');
                    $("#errorMecanismosParticipacion").hide();
                }
            }
            else $("#txtMecanismosParticipacion").val('');
            if ($("#selEspacioCiudadanoFuncionario").val() == "Otra, ¿cuál?")
            {
                var caracteresEspeciales = $("#txtEspacioCiudadanoFuncionario").val().split('*');
                if ($("#txtEspacioCiudadanoFuncionario").val() == '')
                {
                    $("#errorEspacioCiudadanoFuncionario").html('Por favor ingrese cual es el otro espacio en el que ha participado como ciudadano o funcionario público. Este campo es requerido.');
                    $("#errorEspacioCiudadanoFuncionario").show();
                    return false;
                }
                else if (caracteresEspeciales.length > 1)
                {
                    $("#errorEspacioCiudadanoFuncionario").html('El caracter * no está permitido. Por favor elimine este caracter de la casilla.');
                    $("#errorEspacioCiudadanoFuncionario").show();
                    return false;
                }
                else
                {
                    $("#errorEspacioCiudadanoFuncionario").html('');
                    $("#errorEspacioCiudadanoFuncionario").hide();
                }
            }
            else $("#txtEspacioCiudadanoFuncionario").val('');
            //Agregado
            if ($("#selParticipacionAnterior").val() == "Otra, ¿cuál?")
            {
                var caracteresEspeciales = $("#txtParticipacionAnterior").val().split('*');
                if ($("#txtParticipacionAnterior").val() == '')
                {
                    $("#errorParticipacionAnterior").html('Por favor ingrese cual es la otra organización(es) o instancia(s) a la cual ha estado vinculado. Este campo es requerido.');
                    $("#errorParticipacionAnterior").show();
                    return false;
                }
                else if (caracteresEspeciales.length > 1)
                {
                    $("#errorParticipacionAnterior").html('El caracter * no está permitido. Por favor elimine este caracter de la casilla.');
                    $("#errorParticipacionAnterior").show();
                    return false;
                }
                else
                {
                    $("#errorParticipacionAnterior").html('');
                    $("#errorParticipacionAnterior").hide();
                }
            }
            else $("#txtParticipacionAnterior").val('');
            if ($("#selCapacitacionesEntidades").val() == "Otra, ¿cuál?")
            {
                var caracteresEspeciales = $("#txtCapacitacionesEntidades").val().split('*');
                if ($("#txtCapacitacionesEntidades").val() == '')
                {
                    $("#errorCapacitacionesEntidades").html('Por favor ingrese cual es la otra entidad que ha brindado capacitaciones sobre participación ciudadana. Este campo es requerido.');
                    $("#errorCapacitacionesEntidades").show();
                    return false;
                }
                else if (caracteresEspeciales.length > 1)
                {
                    $("#errorCapacitacionesEntidades").html('El caracter * no está permitido. Por favor elimine este caracter de la casilla.');
                    $("#errorCapacitacionesEntidades").show();
                    return false;
                }
                else
                {
                    $("#errorCapacitacionesEntidades").html('');
                    $("#errorCapacitacionesEntidades").hide();
                }
            }
            else $("#txtCapacitacionesEntidades").val('');
        break;
    }
    return true;
}
//Funciones para bloqueo/Desbloqueo de pantalla
function waitblockUIParamEvaluarEncuestaCaracterizacion(mensaje) { $.blockUI({ message: "<h2>" + mensaje + "</h2>" }); }
function blockUI() { $.blockUI(); }
function unblockUI() { $.unblockUI(); }
function CambioTexto(control)
{
    $("#" + control).hide();
}
function SeleccionarItem(control)
{
    if ($("#sel" + control).val() == "Otra, ¿cuál?") $("#txt" + control).show();
    else
    {
        $("#txt" + control).html('');
        $("#txt" + control).hide();
        $("#error" + control).hide();
        $("#error" + control).html('');
    }
}
function InicializarCajasTexto()
{
    $("#txtVinculacionActual").hide();
    $("#txtMecanismosParticipacion").hide();
    $("#txtEspacioCiudadanoFuncionario").hide();
    $("#txtParticipacionAnterior").hide();
    $("#txtCapacitacionesEntidades").hide();
    ObtenerDatosEncuestaUsuario(2);
}

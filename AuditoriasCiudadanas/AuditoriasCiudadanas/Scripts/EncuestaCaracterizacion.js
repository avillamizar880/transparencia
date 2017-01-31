//function ObtenerMunicipiosEncuestaCaracterizacion() {
//    $("#error_municipio").hide();
//    $.ajax({
//        type: "POST", url: '../../Views/Caracterizacion/Encuesta_ajax', data: { Municipio: "Municipio" }, traditional: true,
//        beforeSend: function () {
//            waitblockUIParamEvaluarEncuestaCaracterizacion('Cargando datos municipios...');
//        },
//        success: function (result)
//        {
//            var dataSource = result.split("\n");
//            $('#txtmunicipio').typeahead({ source: dataSource })
//            unblockUI();
//            ObtenerDatosEncuestaUsuario(1);
//        }
//    });
//}
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
                           // $("#txtmunicipio").val(result.Head[i].Municipio);
                            $("#genero").val(result.Head[i].Genero);
                            $("#selRangoEdad").val(result.Head[i].RangoEdad);
                            $("#ocupacion").val(result.Head[i].Ocupacion);
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
                //url: '../../Views/Caracterizacion/Encuesta_ajax', data: { ObtenerDatosEncuestaUsuarioParte2: $("#hfUsuarioId").val() + '*' + $("#hfmunicipio").val() },
                url: '../../Views/Caracterizacion/Encuesta_ajax', data: { ObtenerDatosEncuestaUsuarioParte2: $("#hfUsuarioId").val() },
                traditional: true,
                cache: false,
                dataType: "json",
                beforeSend: function () {
                    waitblockUIParamEvaluarEncuestaCaracterizacion('Cargando datos usuario encuesta parte 2...');
                },
                success: function (result)
                {
                    if (result != null && result != "")
                    {
                        for (var i = 0; i < result.Head.length; i++)
                        {
                            $("#txtMecanismosParticipacion").hide();
                            $("#txtEstrategiaSeguimiento").hide();
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
                            if (result.Head[i].RecursosAlcaldia.toUpperCase() != "NULL") $("#selRecursosAlcaldia").val(result.Head[i].RecursosAlcaldia);
                            if (result.Head[i].AuditoriasVisiblesDNP.toUpperCase() != "NULL") $("#selAuditoriasVisibles").val(result.Head[i].AuditoriasVisiblesDNP);
                            if (result.Head[i].GestionAutoridades.toUpperCase() != "NULL") $("#selGestionAutoridades").val(result.Head[i].GestionAutoridades);
                            if (result.Head[i].PlanAccion.toUpperCase() != "NULL") $("#selPlanAccion").val(result.Head[i].PlanAccion);
                            if (result.Head[i].EstrategiaSeguimiento.toUpperCase() != "NULL") {
                                switch (result.Head[i].EstrategiaSeguimiento.toUpperCase()) {
                                    case "REUNIONES O ESPACIOS DE ENCUENTRO CON AUTORIDADES LOCALES, CONTRATISTAS, EXPERTOS TÉCNICOS, ENTRE OTROS. ":
                                    case "REGISTRO FOTOGRÁFICO O DE VIDEO SOBRE AVANCES DE PROYECTOS O DE LA GESTIÓN DE LAS AUTORIDADES LOCALES":
                                    case "REGISTRO ESCRITO SOBRE AVANCES DE PROYECTOS O DE LA GESTIÓN DE LAS AUTORIDADES LOCALES":
                                    case "REVISIÓN DE DOCUMENTOS PÚBLICOS RELACIONADOS CON LOS PROYECTOS O CON LA GESTIÓN DE LAS AUTORIDADES LOCALES ":
                                    case "VISITAS AL LUGAR DE EJECUCIÓN DE PROYECTOS ESPECÍFICOS":
                                    case "NINGUNO":
                                        $("#selEstrategiaSeguimiento").val(result.Head[i].EstrategiaSeguimiento);
                                        break;
                                    default:
                                        $("#selEstrategiaSeguimiento").val('Otra, ¿cuál?');
                                        $("#txtEstrategiaSeguimiento").val(result.Head[i].EstrategiaSeguimiento);
                                        $("#txtEstrategiaSeguimiento").show();
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
        case 3:
            $.ajax({
                type: "POST",
                url: '../../Views/Caracterizacion/Encuesta_ajax', data: { ObtenerDatosEncuestaUsuarioParte3: $("#hfUsuarioId").val() },
                traditional: true,
                cache: false,
                dataType: "json",
                beforeSend: function () {
                    waitblockUIParamEvaluarEncuestaCaracterizacion('Cargando datos usuario encuesta parte 3...');
                },
                success: function (result) {
                    if (result != null && result != "") {
                        for (var i = 0; i < result.Head.length; i++) {
                            $("#txtEstrategiaHallazgos").hide();
                            if (result.Head[i].EstrategiaHallazgos.toUpperCase() != "NULL")
                            {
                                switch (result.Head[i].EstrategiaHallazgos.toUpperCase()) {
                                    case "REUNIONES O ESPACIOS DE ENCUENTRO CON AUTORIDADES LOCALES. ":
                                    case "USO DEL SISTEMA DE PETICIONES, QUEJAS Y RECLAMOS DE LA ENTIDAD TERRITORIAL.":
                                    case "REGISTRO ESCRITO SOBRE AVANCES DE PROYECTOS O DE LA GESTIÓN DE LAS AUTORIDADES LOCALES":
                                    case "PRESENTACIÓN DE INFORMES, CONCEPTOS O QUEJAS ESCRITAS A LAS AUTORIDADES LOCALES O NACIONALES.":
                                    case "PRESENTACIÓN DE FOTOGRAFÍAS O VIDEOS CON LOS HALLAZGOS A AUTORIDADES LOCALES O NACIONALES.":
                                    case "PRESENTACIÓN DE HALLAZGOS A MEDIOS DE COMUNICACIÓN LOCALES O NACIONALES.":
                                    case "NINGUNO":
                                        $("#selEstrategiaHallazgos").val(result.Head[i].EstrategiaHallazgos);
                                        break;
                                        //default:
                                    case "OTRA, ¿CUÁL?":
                                        $("#selEstrategiaHallazgos").val('Otra, ¿cuál?');
                                        $("#txtEstrategiaHallazgos").val(result.Head[i].EstrategiaHallazgos);
                                        $("#txtEstrategiaHallazgos").show();
                                        break;
                                }
                            }
                            //if (result.Head[i].FrecuenciaDenunciasControl.toUpperCase() != "NULL")
                            //    $("#selFrecuenciaDenunciasControl").val(result.Head[i].FrecuenciaDenunciasControl);
                            if (result.Head[i].CambiosGestion.toUpperCase() != "NULL") {
                                switch (result.Head[i].CambiosGestion.toUpperCase()) {
                                    case "NO":
                                    case "NO SÉ":
                                        $("#selCambiosGestion").val(result.Head[i].CambiosGestion);
                                        break;
                                    default:
                                        $("#selCambiosGestion").val('Sí, ¿podrá indicar uno o dos ejemplos?');
                                        $("#txtCambiosGestion").val(result.Head[i].CambiosGestion);
                                        $("#txtCambiosGestion").show();
                                        break;
                                }
                            }
                            if (result.Head[i].FrecuenciaSeguimiento.toUpperCase() != "NULL") $("#selFrecuenciaSeguimiento").val(result.Head[i].FrecuenciaSeguimiento);
                            if (result.Head[i].RadicacionDerechoPeticion.toUpperCase() != "NULL") $("#selRadicaciónDerechoPeticion").val(result.Head[i].RadicacionDerechoPeticion);
                            if (result.Head[i].FacilidadAccesoInfo.toUpperCase() != "NULL") $("#selFacilidadAccesoInfo").val(result.Head[i].FacilidadAccesoInfo);
                            if (result.Head[i].PercepcionSeguridad.toUpperCase() != "NULL") $("#selPercepcionSeguridad").val(result.Head[i].PercepcionSeguridad);
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
        case 4:
            $.ajax({
                type: "POST",
                url: '../../Views/Caracterizacion/Encuesta_ajax', data: { ObtenerDatosEncuestaUsuarioParte4: $("#hfUsuarioId").val() + '*' + $("#hfmunicipio").val() },
                traditional: true,
                cache: false,
                dataType: "json",
                beforeSend: function () {
                    waitblockUIParamEvaluarEncuestaCaracterizacion('Cargando datos usuario encuesta parte 4...');
                },
                success: function (result) {
                    if (result != null && result != "") {
                        for (var i = 0; i < result.Head.length; i++) {
                            $("#txtCambiosGestion").hide();
                            if (result.Head[i].FrecuenciaDenunciasComunicacion.toUpperCase() != "NULL")
                                $("#selFrecuenciaDenunciasComunicacion").val(result.Head[i].FrecuenciaDenunciasComunicacion);
                            if (result.Head[i].RadicacionDerechoPeticion.toUpperCase() != "NULL")
                                $("#selRadicaciónDerechoPeticion").val(result.Head[i].RadicacionDerechoPeticion);
                            if (result.Head[i].FacilidadAccesoInfo.toUpperCase() != "NULL")
                                $("#selFacilidadAccesoInfo").val(result.Head[i].FacilidadAccesoInfo);
                            if (result.Head[i].EvaluacionesInternas.toUpperCase() != "NULL")
                                $("#selEvaluacionesInternas").val(result.Head[i].EvaluacionesInternas);
                            if (result.Head[i].DifusionResultados.toUpperCase() != "NULL")
                                $("#selDifusionResultados").val(result.Head[i].DifusionResultados);
                            if (result.Head[i].CambiosGestion.toUpperCase() != "NULL")
                            {
                                switch (result.Head[i].CambiosGestion.toUpperCase())
                                {
                                    case "NO":
                                    case "NO SÉ":
                                        $("#selCambiosGestion").val(result.Head[i].CambiosGestion);
                                        break;
                                    default:
                                        $("#selCambiosGestion").val('Sí, ¿podrá indicar uno o dos ejemplos?');
                                        $("#txtCambiosGestion").val(result.Head[i].CambiosGestion);
                                        $("#txtCambiosGestion").show();
                                        break;
                                }
                             }
                            if (result.Head[i].FrecuenciaSeguimiento.toUpperCase() != "NULL")
                                $("#selFrecuenciaSeguimiento").val(result.Head[i].FrecuenciaSeguimiento);
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
            cargaMenuParams('Caracterizacion/EncuestaParte2', 'dvPrincipal', $("#hfmunicipio").val() + '*' + $("#hfUsuarioId").val());
        break;
    }
}
function Siguiente(pagina)
{
    switch (pagina)
    {
        case "2":
            var guardarRegistro= ValidarCamposPagina(1);
            if (guardarRegistro == true)
                GuardarEncuestaCaracterizacion(1);
            break;
        case "3":
            var guardarRegistro = ValidarCamposPagina(2);
            if (guardarRegistro == true)
                GuardarEncuestaCaracterizacion(2);
            break;
        case "4":
            var guardarRegistro = ValidarCamposPagina(3);
            if (guardarRegistro == true)
                GuardarEncuestaCaracterizacion(3);
            break;
        case "5":
            var guardarRegistro = ValidarCamposPagina(4);
            if (guardarRegistro == true)
                GuardarEncuestaCaracterizacion(4);
            break;
    }
}
function CambioValorLista(valor)
{
    switch (valor.id.toUpperCase())
    {
        case "GENERO":
            if ($("#genero").val() != null) $("#errorGenero").hide();
        break;
        case "SELRANGOEDAD":
            if ($("#selRangoEdad").val() != null) $("#errorRangoEdad").hide();
        break;
        case "SELLUGARRESIDENCIA":
            if ($("#selLugarResidencia").val() != null) $("#errorLugarResidencia").hide();
        break;
        case "SELCOMUNIDADPERTENECE":
            if ($("#selComunidadPertenece").val() != null) $("#errorComunidadPertenece").hide();
        break;
        case "SELORGANIZACIONPERTENECE":
            if ($("#selOrganizacionPertenece").val() != null) $("#errorOrganizacionPertenece").hide();
        break;
        case "SELAUDITORIASVISIBLES":
            if ($("#selAuditoriasVisibles").val() != null) $("#errorAuditoriasVisibles").hide();
        break;
        case "SELGESTIONAUTORIDADES":
            if ($("#selGestionAutoridades").val() != null) $("#errorGestionAutoridades").hide();
        break;
        case "SELPLANACCION":
            if ($("#selPlanAccion").val() != null) $("#errorselPlanAccion").hide();
        break;
        case "SELRECURSOSALCALDIA":
            if ($("#selRecursosAlcaldia").val() != null) $("#errorRecursosAlcaldia").hide();
        break;
        case "SELFRECUENCIASEGUIMIENTO":
            if ($("#selFrecuenciaSeguimiento").val() != null) $("#errorselFrecuenciaSeguimiento").hide();
        break;
        case "SELRADICACIÓNDERECHOPETICION":
            if ($("#selRadicaciónDerechoPeticion").val() != null) $("#errorselRadicaciónDerechoPeticion").hide();
        break;
        case "SELPERCEPCIONSEGURIDAD":
            if ($("#selPercepcionSeguridad").val() != null) $("#errorselPercepcionSeguridad").hide();
        break;
    }
}
function GuardarEncuestaCaracterizacion(pagina)
{
    switch (pagina)
    {
        case 1:
            $.ajax({
                //type: "POST", url: '../../Views/Caracterizacion/Encuesta_ajax', data: { GuardarPag1: $("#txtmunicipio").val() + '*' + $("#genero").val() + '*' + $("#selRangoEdad").val() + '*' + $("#ocupacion").val() + '*' + $("#selCargoActual").val() + '*' + $("#selLugarResidencia").val() + '*' + $("#selComunidadPertenece").val() + '*' + $("#selOrganizacionPertenece").val() + '*' + $("#hfUsuarioId").val() }, traditional: true,
                type: "POST", url: '../../Views/Caracterizacion/Encuesta_ajax', data: { GuardarPag1: $("#genero").val() + '*' + $("#selRangoEdad").val() + '*' + $("#ocupacion").val() + '*' + $("#selLugarResidencia").val() + '*' + $("#selComunidadPertenece").val() + '*' + $("#selOrganizacionPertenece").val() + '*' + $("#hfUsuarioId").val() }, traditional: true,
                beforeSend: function () {
                    waitblockUIParamEvaluarEncuestaCaracterizacion('Guardando encuesta...');
                },
                success: function (result)
                {
                    unblockUI();
                    if (result == '<||>')
                        //cargaMenuParams('Caracterizacion/EncuestaParte2', 'dvPrincipal', $("#txtmunicipio").val() + '*' + $("#hfUsuarioId").val());
                    cargaMenuParams('Caracterizacion/EncuestaParte2', 'dvPrincipal', $("#hfUsuarioId").val());
                }
            });
            break;
        case 2:
            $.ajax({
                //type: "POST", url: '../../Views/Caracterizacion/Encuesta_ajax', data: { Guardarpag2: $("#selVinculacionActual").val() + '*' + $("#txtVinculacionActual").val() + '*' + $("#selMecanismosParticipacion").val() + '*' + $("#txtMecanismosParticipacion").val() + '*' + $("#selEspacioCiudadanoFuncionario").val() + '*' + $("#txtEspacioCiudadanoFuncionario").val() + '*' + $("#selRecursosAlcaldia").val() + '*' + $("#selAuditoriasVisibles").val() + '*' + $("#selParticipacionAnterior").val() + '*' + $("#txtParticipacionAnterior").val() + '*' + $("#selCapacitacionesEntidades").val() + '*' + $("#txtCapacitacionesEntidades").val() + '*' + $("#hfUsuarioId").val() + '*' + $("#hfmunicipio").val() }, traditional: true,
                type: "POST", url: '../../Views/Caracterizacion/Encuesta_ajax', data: { Guardarpag2: $("#selMecanismosParticipacion").val() + '*' + $("#txtMecanismosParticipacion").val() + '*' + $("#selRecursosAlcaldia").val() + '*' + $("#selAuditoriasVisibles").val() + '*' + $("#selGestionAutoridades").val() + '*' + $("#selPlanAccion").val() + '*' + $("#selEstrategiaSeguimiento").val() + '*' + $("#txtEstrategiaSeguimiento").val() + '*' + $("#hfUsuarioId").val() }, traditional: true,
                beforeSend: function () {
                    waitblockUIParamEvaluarEncuestaCaracterizacion('Actualizando registro');
                },
                success: function (result) {
                    unblockUI();
                    if (result == '<||>')
                        cargaMenuParams('Caracterizacion/EncuestaParte3', 'dvPrincipal', $("#hfUsuarioId").val());
                }
            });
            break;
        case 3:
                $.ajax({
                    //type: "POST", url: '../../Views/Caracterizacion/Encuesta_ajax', data: { GuardarPag3: $("#selSeguimientoGestionPublica").val() + '*' + $("#selSeguimientoProyectos").val() + '*' + $("#selApoyoAlcaldía").val() + '*' + $("#txtApoyoAlcaldía").val() + '*' + $("#selRelacionAdminComunidad").val() + '*' + $("#selGestionComunidad").val() + '*' + $("#selGestionAutoridades").val() + '*' + $("#selPlanAccion").val() + '*' + $("#selEstrategiaSeguimiento").val() + '*' + $("#txtEstrategiaSeguimiento").val() + '*' + $("#selEstrategiaHallazgos").val() + '*' + $("#txtEstrategiaHallazgos").val() + '*' + $("#selFrecuenciaDenunciasControl").val() + '*' + $("#hfUsuarioId").val() + '*' + $("#hfmunicipio").val() }, traditional: true,
                    type: "POST", url: '../../Views/Caracterizacion/Encuesta_ajax', data: { GuardarPag3: $("#selEstrategiaHallazgos").val() + '*' + $("#txtEstrategiaHallazgos").val() + '*' + $("#selCambiosGestion").val() + '*' + $("#txtCambiosGestion").val() + '*' + $("#selFrecuenciaSeguimiento").val() + '*' + $("#selRadicaciónDerechoPeticion").val() + '*' + $("#selFacilidadAccesoInfo").val() + '*' + $("#selPercepcionSeguridad").val() + "*" + $("#hfUsuarioId").val() }, traditional: true,
                    beforeSend: function () {
                        waitblockUIParamEvaluarEncuestaCaracterizacion('Actualizando registro');
                    },
                    success: function (result)
                    {
                        unblockUI();
                        if (result == '<||>')
                            //cargaMenuParams('Caracterizacion/EncuestaParte4', 'dvPrincipal', $("#hfmunicipio").val() + '*' + $("#hfUsuarioId").val());
                            cargaMenuParams('Caracterizacion/EncuestaParte5', 'dvPrincipal', '');
                    }
                });
            break;
        //case 4:
        //    $.ajax({
        //        type: "POST", url: '../../Views/Caracterizacion/Encuesta_ajax', data: { GuardarPag4: $("#selFrecuenciaDenunciasComunicacion").val() + '*' + $("#selRadicaciónDerechoPeticion").val() + '*' + $("#selFacilidadAccesoInfo").val() + '*' + $("#selEvaluacionesInternas").val() + '*' + $("#selDifusionResultados").val() + '*' + $("#selCambiosGestion").val() + '*' + $("#txtCambiosGestion").val() + '*' + $("#selFrecuenciaSeguimiento").val() + '*' + $("#hfUsuarioId").val() + '*' + $("#hfmunicipio").val() }, traditional: true,
        //        beforeSend: function () {
        //            waitblockUIParamEvaluarEncuestaCaracterizacion('Actualizando registro');
        //        },
        //        success: function (result) {
        //            unblockUI();
        //            if (result == '<||>')
        //                cargaMenuParams('Caracterizacion/EncuestaParte5', 'dvPrincipal','');
        //        }
        //    });
        //    break;
    }
}
function ValidarCamposPagina(pagina)
{
    switch (pagina)
    {
        case 1:
            $("#errorOcupacion").hide();
            $("#errorGenero").hide();
            $("#errorRangoEdad").hide();
            $("#errorLugarResidencia").hide();
            $("#errorComunidadPertenece").hide();
            $("#errorOrganizacionPertenece").hide();
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
            else $("#errorOcupacion").html('');
            if ($("#genero").val() == null)
            {
                $("#errorGenero").show();
                return false;
            }
            if ($("#selRangoEdad").val() == null) {
                $("#errorRangoEdad").show();
                return false;
            }
            if ($("#selLugarResidencia").val() == null) {
                $("#errorLugarResidencia").show();
                return false;
            }
            if ($("#selComunidadPertenece").val() == null) {
                $("#errorComunidadPertenece").show();
                return false;
            }
            if ($("#selOrganizacionPertenece").val() == null) {
                $("#errorOrganizacionPertenece").show();
                return false;
            }
            return true;
            break;
        case 2:
                $("#errorMecanismosParticipacion").hide();
                $("#errorRecursosAlcaldia").hide();
                $("#errorEstrategiaSeguimiento").hide();
                $("#errorGestionAutoridades").hide();
                $("#errorAuditoriasVisibles").hide();
                $("#errorselPlanAccion").hide();
                $("#errorEstrategiaSeguimiento").hide();
                //Mecanismo de Participación
                if ($("#selMecanismosParticipacion").val() == null)
                {
                    $("#errorMecanismosParticipacion").html('Por favor seleccione un mecanismo de participación ciudadana. Este campo es requerido.');
                    $("#errorMecanismosParticipacion").show();
                    return false;
                }
                if ($("#selMecanismosParticipacion").val() == "Otra, ¿cuál?")
                {
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
                    else
                    {
                        $("#errorMecanismosParticipacion").html('');
                        $("#errorMecanismosParticipacion").hide();
                    }
                }
                else $("#txtMecanismosParticipacion").val('');
                //Recursos Alcaldía
                if ($("#selRecursosAlcaldia").val() == null)
                {
                   $("#errorRecursosAlcaldia").show();
                   return false;
                }
                //Estrategias Seguimiento
                if ($("#selEstrategiaSeguimiento").val() == null)
                {
                    $("#errorEstrategiaSeguimiento").html('Por favor seleccione las estrategias, mecanismos o instrumentos que utiliza la ciudadanía para hacer seguimiento a la gestión o a proyectos de las autoridades locales.Este campo es requerido.');
                    $("#errorEstrategiaSeguimiento").show();
                    return false;
                }
                if ($("#selEstrategiaSeguimiento").val() == "Otra, ¿cuál?")
                {
                    var caracteresEspeciales = $("#txtEstrategiaSeguimiento").val().split('*');
                    if ($("#txtEstrategiaSeguimiento").val() == '')
                    {
                        $("#errorEstrategiaSeguimiento").html('Por favor ingrese la estrategia para hacer seguimiento a la gestión o a proyectos. Este campo es requerido.');
                        $("#errorEstrategiaSeguimiento").show();
                        return false;
                    }
                    else if (caracteresEspeciales.length > 1)
                    {
                        $("#errorEstrategiaSeguimiento").html('El caracter * no está permitido. Por favor elimine este caracter de la casilla.');
                        $("#errorEstrategiaSeguimiento").show();
                        return false;
                    }
                    else
                    {
                        $("#errorEstrategiaSeguimiento").html('');
                        $("#errorEstrategiaSeguimiento").hide();
                    }
                }
                else $("#txtEstrategiaSeguimiento").val('');
                //Auditorias Visibles
                if ($("#selAuditoriasVisibles").val() == null)
                {
                    $("#errorAuditoriasVisibles").show();
                    return false;
                }
                //Gestión Autoridades
                if ($("#selGestionAutoridades").val() == null)
                {
                    $("#errorGestionAutoridades").show();
                    return false;
                }
                //Plan acción
                if ($("#selPlanAccion").val() == null)
                {
                    $("#errorselPlanAccion").show();
                    return false;
                }
            break;
        case 3:
            $("#errorEstrategiaHallazgos").hide();
            $("#errorCambiosGestion").hide();
            $("#errorselFrecuenciaSeguimiento").hide();
            $("#errorselRadicaciónDerechoPeticion").hide();
            $("#errorselFacilidadAccesoInfo").hide();
            $("#errorselPercepcionSeguridad").hide();
            //Estrategia Hallazgos
            if ($("#selEstrategiaHallazgos").val() == null) {
                $("#errorEstrategiaHallazgos").show();
                return false;
            }
            if ($("#selEstrategiaHallazgos").val() == "Otra, ¿cuál?") {
                var caracteresEspeciales = $("#txtEstrategiaHallazgos").val().split('*');
                if ($("#txtEstrategiaHallazgos").val() == '') {
                    $("#errorEstrategiaHallazgos").html('Por favor ingrese la estrategia para reportar los hallazgos que obtienen de su ejercicio de control social. Este campo es requerido.');
                    $("#errorEstrategiaHallazgos").show();
                    return false;
                }
                else if (caracteresEspeciales.length > 1) {
                    $("#errorEstrategiaHallazgos").html('El caracter * no está permitido. Por favor elimine este caracter de la casilla.');
                    $("#errorEstrategiaHallazgos").show();
                    return false;
                }
                else {
                    $("#errorEstrategiaHallazgos").html('');
                    $("#errorEstrategiaHallazgos").hide();
                }
            }
            //Cambios Gestión
            if ($("#selCambiosGestion").val() == null) {
                $("#errorCambiosGestion").html('Por favor indique una respuesta a la pregunta. Este campo es requerido.');
                $("#errorCambiosGestion").show();
                return false;
            }
            if ($("#selCambiosGestion").val() == "Sí, ¿podrá indicar uno o dos ejemplos?") {
                var caracteresEspeciales = $("#txtCambiosGestion").val().split('*');
                if ($("#txtCambiosGestion").val() == '') {
                    $("#errorCambiosGestion").html('Por favor indique uno o dos ejemplos. Este campo es requerido.');
                    $("#errorCambiosGestion").show();
                    return false;
                }
                else if (caracteresEspeciales.length > 1) {
                    $("#errorCambiosGestion").html('El caracter * no está permitido. Por favor elimine este caracter de la casilla.');
                    $("#errorCambiosGestion").show();
                    return false;
                }
                else {
                    $("#errorCambiosGestion").html('');
                    $("#errorCambiosGestion").hide();
                }
            }
            //Frecuencia Seguimiento
            if ($("#selFrecuenciaSeguimiento").val() == null) {
                $("#errorselFrecuenciaSeguimiento").show();
                return false;
            }
            //Radicación Derecho Petición
            if ($("#selRadicaciónDerechoPeticion").val() == null) {
                $("#errorselRadicaciónDerechoPeticion").show();
                return false;
            }
            //Facilidad Acceso Info
            if ($("#selFacilidadAccesoInfo").val() == null) {
                $("#errorselFacilidadAccesoInfo").show();
                return false;
            }
            //Percepción de Seguridad
            if ($("#selPercepcionSeguridad").val() == null) {
                $("#errorselPercepcionSeguridad").show();
                return false;
            }
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
    else if ($("#sel" + control).val() == "Sí, ¿podrá indicar uno o dos ejemplos?") $("#txt" + control).show();
    else if ($("#sel" + control).val() !=null)
    {
        $("#txt" + control).html('');
        $("#txt" + control).hide();
        $("#error" + control).hide();
        $("#error" + control).html('');
    }
}
function InicializarCajasTexto(pagina)
{
    switch (pagina)
    {
        case 2:
            $("#txtMecanismosParticipacion").hide();
            $("#txtEstrategiaSeguimiento").hide();
        break;
        case 3:
            $("#txtEstrategiaHallazgos").hide();
            $("#txtCambiosGestion").hide();
            break;
    }
    ObtenerDatosEncuestaUsuario(pagina);
}

function CargarDatosInicialReporte()
{
    var fechaActual = new Date();
    var fechaAtras = addMonths(new Date(), -6);
    var fechaFin = fechaActual.getDate() + '/' + (fechaActual.getMonth() + 1) + '/' + fechaActual.getFullYear();
    var fechaInicio = fechaAtras.getDate() + '/' + (fechaAtras.getMonth() + 1) + '/' + fechaAtras.getFullYear();
    $('#dtpFechaInicio').val(fechaInicio);
    $('#dtpFechaFin').val(fechaFin);
    ObtenerResultadosFechaCorte();
}

function addMonths(date, months) {
    date.setMonth(date.getMonth() + months);
    return date;
}

function ObtenerResultadosFechaCorte()
{
    $.ajax({
        type: "POST", 
        url: '../../Views/Caracterizacion/AdminEncuestaCaractGenerar_ajax', data: { ResultadoFechaCorte: $('#dtpFechaInicio').val() + "*" + $('#dtpFechaFin').val() },
        traditional: true,
        cache: false,
        dataType: "json",
        beforeSend: function () {
            waitblockUIParamEvaluarEncuestaCaracterizacion('Cargando datos cierre encuestas...');
        },
        success: function (result)
        {
            var datasource = '';
            if (result != null && result != "")
            {
                for (var i = 0; i < result.Head.length; i++)
                {
                    datasource = datasource +
                             '<div class="list-group-item uppText">'+
                             '<div class="col-sm-1"><a role="button" onclick="detalleEncuesta(\'' + result.Head[i].FechaInicio + '\',\'' + result.Head[i].FechaFin + '\');"><span class="glyphicon glyphicon-download-alt"></span></a></div>' +
                             '<div class="col-sm-8"><p class="list-group-item-text"><span class="label label-info">Respuesta(s) desde el ' + result.Head[i].FechaInicio + ' hasta ' + result.Head[i].FechaFin + '</span><br/><span>Encontramos en este documento la respuesta a la(s) encuesta(s) de caracterización realizada(s) durantes las fechas específicas.</span></p></div>' +
                             '<div class="col-sm-3"><span>'+ result.Head[i].Total+ '</span><br /><span>Encuestados</span></div>'+
                             '</div>';
                }
            }
            $("#datosFechaCorte").html(datasource);
            unblockUI();
        }
    });
}
function detalleEncuesta(fecha_ini, fecha_fin) {
    if ($('#ifrExcelEncuesta').length == 0) {
        $('#divOtros').append('<iframe id="ifrExcelEncuesta" name="ifrExcelEncuesta" width="0" height="0" style="width:0px;height:0px;float:right;"></iframe><form id="frmExpExcel" name="frmExpExcel" style="display:none;float:right;" target="ifrExcelEncuesta" method="POST" action="../Views/Caracterizacion/DetalleEncuesta_ajax"></form>');
    }
    $('#frmExpExcel').html('<input type="hidden" id="fecha_ini" name="fecha_ini" value="' + fecha_ini + '" /><input type="hidden" id="fecha_fin" name="fecha_fin" value="' + fecha_fin + '" />');
    $('#frmExpExcel').submit();
}
function Reenviar(vista,contenedor)
{
    ajaxPost(vista, '', contenedor, function (r) {

    }, function (r) {
        alert(r.responseText);
    });
}
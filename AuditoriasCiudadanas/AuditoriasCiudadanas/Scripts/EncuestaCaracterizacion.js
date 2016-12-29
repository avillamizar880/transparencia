function ObtenerMunicipios() {
    $("#error_municipio").hide();
    $.ajax({
        type: "POST", url: '../../Views/Caracterizacion/Encuesta_ajax', data: { Municipio: "Municipio" }, traditional: true,
        beforeSend: function () {
            waitblockUI();
        },
        success: function (result) {
            var dataSource = result.split("\n");
            $('#txtmunicipio').typeahead({ source: dataSource });
           unblockUI();
        }
    });
}
function Siguiente(pagina)
{
    switch (pagina)
    {
        case "1":
            var errorOcupacion = 'False';
            var caracteresEspeciales = $("#ocupacion").val().split('*');
            if ($("#ocupacion").val() == '')
            {
                $("#errorOcupacion").html('Por favor ingrese su ocupación. Este campo es requerido.');
                $("#errorOcupacion").show();
                errorOcupacion = 'True';
            }
            else if (caracteresEspeciales.length > 1)
            {
                $("#errorOcupacion").html('El caracter * no está permitido. Por favor elimine este caracter de la casilla ocupación.');
                $("#errorOcupacion").show();
                errorOcupacion = 'True';
            }
            else
            {
                $("#errorOcupacion").html('');
                $("#errorOcupacion").hide();
            }
            $.ajax({
                type: "POST", url: '../../Views/Caracterizacion/Encuesta_ajax', data: { ValidarNombreMunicipio: $("#txtmunicipio").val() + '*' + $("#departamento").val() + '*' + $("#selRangoEdad").val() + '*' + $("#ocupacion").val() + '*' + $("#selCargoActual").val() + '*' + $("#selLugarResidencia").val() + '*' + $("#selComunidadPertenece").val() + '*' + $("#selOrganizacionPertenece").val() }, traditional: true,
                beforeSend: function () {
                    waitblockUIValidacion();
                },
                success: function (result)
                {
                    if (result == 'True' && errorOcupacion == 'False')
                    {
                        $("#errorMunicipio").html('');
                        $("#errorMunicipio").hide();
                        window.location = 'EncuestaParte2';
                    }
                    else if (result == 'False')
                    {
                        $("#errorMunicipio").html('No existe el municipio ' + $("#txtmunicipio").val() + ' en la base de datos o se encuentra mal escrito. <br> Se recomienda usar el nombre del municipio que se muestra en la lista.');
                        $("#errorMunicipio").show();
                    }
                    unblockUI();
                   
                }
            });
            break;
        case "2":
            var errorVinculacionActual = 'False';
            var errorMecanismosParticipacion = 'False';
            var errorEspacioCiudadanoFuncionario = 'False';
            if ($("#selVinculacionActual").val() == "Otra, ¿cuál?") {
                var caracteresEspeciales = $("#txtVinculacionActual").val().split('*');
                if ($("#txtVinculacionActual").val() == '') {
                    $("#errorVinculacionActual").html('Por favor ingrese cual es la otra organización(es) o instancia(s) a la que esta vinculado. Este campo es requerido.');
                    $("#errorVinculacionActual").show();
                    errorVinculacionActual = 'True';
                }
                else if (caracteresEspeciales.length > 1) {
                    $("#errorVinculacionActual").html('El caracter * no está permitido. Por favor elimine este caracter de la casilla.');
                    $("#errorVinculacionActual").show();
                    errorVinculacionActual = 'True';
                }
                else {
                    $("#errorVinculacionActual").html('');
                    $("#errorVinculacionActual").hide();
                }
            }
            if ($("#selMecanismosParticipacion").val() == "Otra, ¿cuál?") {
                var caracteresEspeciales = $("#txtMecanismosParticipacion").val().split('*');
                if ($("#txtMecanismosParticipacion").val() == '') {
                    $("#errorMecanismosParticipacion").html('Por favor ingrese cual es el otro mecanismo de participación ciudadana que ha participado. Este campo es requerido.');
                    $("#errorMecanismosParticipacion").show();
                    errorMecanismosParticipacion = 'True';
                }
                else if (caracteresEspeciales.length > 1) {
                    $("#errorMecanismosParticipacion").html('El caracter * no está permitido. Por favor elimine este caracter de la casilla.');
                    $("#errorMecanismosParticipacion").show();
                    errorMecanismosParticipacion = 'True';
                }
                else {
                    $("#errorMecanismosParticipacion").html('');
                    $("#errorMecanismosParticipacion").hide();
                }
            }
            if ($("#selEspacioCiudadanoFuncionario").val() == "Otra, ¿cuál?") {
                var caracteresEspeciales = $("#txtEspacioCiudadanoFuncionario").val().split('*');
                if ($("#txtEspacioCiudadanoFuncionario").val() == '') {
                    $("#errorEspacioCiudadanoFuncionario").html('Por favor ingrese cual es el otro espacio en el que ha participado como ciudadano o funcionario público. Este campo es requerido.');
                    $("#errorEspacioCiudadanoFuncionario").show();
                    errorMecanismosParticipacion = 'True';
                }
                else if (caracteresEspeciales.length > 1) {
                    $("#errorEspacioCiudadanoFuncionario").html('El caracter * no está permitido. Por favor elimine este caracter de la casilla.');
                    $("#errorEspacioCiudadanoFuncionario").show();
                    errorMecanismosParticipacion = 'True';
                }
                else {
                    $("#errorEspacioCiudadanoFuncionario").html('');
                    $("#errorEspacioCiudadanoFuncionario").hide();
                }
            }
            if (errorVinculacionActual == 'False' && errorMecanismosParticipacion == 'False' && errorEspacioCiudadanoFuncionario=='False')
            {
                $.ajax({
                    type: "POST", url: '../../Views/Caracterizacion/Encuesta_ajax', data: { Guardar: $("#selVinculacionActual").val() + '*' + $("#txtVinculacionActual").val() + '*' + $("#selMecanismosParticipacion").val() + '*' + $("#txtMecanismosParticipacion").val() + '*' + $("#selEspacioCiudadanoFuncionario").val() + '*' + $("#txtEspacioCiudadanoFuncionario").val() + '*' + $("#selRecursosAlcaldia").val() + '*' + $("#selAuditoriasVisibles").val() }, traditional: true,
                    beforeSend: function () {
                        waitblockUIValidacion();
                    },
                    success: function (result) {
                        if (result == 'True') {
                            window.location = 'EncuestaParte3';
                        }
                        unblockUI();

                    }
                });
            }
            break;
    }
}
//Funciones para bloqueo/Desbloqueo de pantalla
function waitblockUI() { $.blockUI({ message: "<h2>Cargando datos municipios...</h2>" }); }
function waitblockUIValidacion() { $.blockUI({ message: "<h2>Validando información registrada...</h2>" }); }
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
}

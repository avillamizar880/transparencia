function InicializarCajasTextoEvaluarExperiencia()
{
    $("#txt_p1").hide();
    $("#txt_p2").hide();
    $("#txt_p3").hide();
}
function AsignarRespuesta(pregunta, valor)
{
    var resp = parseInt(valor);
    switch (pregunta)
    {
        case "p1":
            if (resp <= 3) $("#txt_p1").show();
            else
            {
                $("#txt_p1").hide();
                $("#txt_p1").val('');
            }
            $("#hfResPreg1").val(valor);
            break;
        case "p2":
            if (resp <= 3) $("#txt_p2").show();
            else
            {
                $("#txt_p2").hide();
                $("#txt_p2").val('');
            }
            $("#hfResPreg2").val(valor);
            break;
        case "p3":
            if (resp <= 3) $("#txt_p3").show();
            else
            {
                $("#txt_p3").hide();
                $("#txt_p3").val('');
            }
            $("#hfResPreg3").val(valor);
            break;
    }    
}
function SeleccionarItemExperiencia(control) {
    if ($("#sel" + control).val() == "Si, ¿Cuáles?") $("#txt" + control).show();
    else {
        $("#txt" + control).html('');
        $("#txt" + control).hide();
        $("#error" + control).hide();
        $("#error" + control).html('');
    }
}
function CambioTextoExperiencia(control) {
    $("#" + control).hide();
}
function GuardarExperiencia()
{
    var guardar = ValidarDatosExperiencia();
    if (guardar == true)
    {
        $.ajax({
            type: "POST", url: '../../Views/Audiencias/EvaluarExperiencia_ajax', data: { GuardarEvaluacionExperiencia: $("#selTemasTratados").val() + '*' + $("#txtTemasTratados").val() + '*' + $("#hfResPreg1").val() + '*' + $("#txt_p1").val() + '*' + $("#hfResPreg2").val() + '*' + $("#txt_p2").val() + '*' + $("#hfResPreg3").val() + '*' + $("#txt_p3").val() + '*' + $("#selEntidadEjecutora").val() + '*' + $("#selSupervisor").val() + '*' + $("#selInterventor").val() + '*' + $("#selContratista").val() + '*' + $("#txtDestacarAP").val() + '*' + $("#selAccionesMejora").val() + '*' + $("#txtAccionesMejora").val() + '*' + $("#hfidAudiencia").val() + '*' + $("#hfidUsuario").val() }, traditional: true,
            beforeSend: function () {
                waitblockUIParamEvaluarExperiencia('Guardando datos resultados Evaluación...');
            },
            success: function (result) {
                if (result == '<||>')
                {
                    bootbox.alert('Gracias por diligenciar la encuesta.\nEsta se almacenó satisfactoriamente.', function () {
                        //TO DO: Falta redireccionar a la vista que lo llamo o a un index
                        volver_listado_gestion();
                    });
                    
                }
                else
                {
                    var mensaje = 'La encuesta NO se almacenó satisfactoriamente';
                    if(result=='-7') mensaje= mensaje +'\nEl usuario no existe o no se ha registrado en el sistema.'
                    bootbox.alert(mensaje);
                }
                unblockUI();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                bootbox.alert("error");
                bootbox.alert(textStatus + ": " + XMLHttpRequest.responseText);
            }
        });
    }
    else
    {
        alert("Es necesario explicar porque su respuesta");
    }
}
function ValidarDatosExperiencia()
{
    $("#errResPreg1").hide();
    $("#errResPreg2").hide();
    $("#errResPreg3").hide();
    $("#errorTemasTratados").hide();
    $("#errorAccionesMejora").hide();
    $("#errResPreg1").html('Por favor seleccione una respuesta para esta pregunta');
    $("#errResPreg2").html('Por favor seleccione una respuesta para esta pregunta');
    $("#errResPreg3").html('Por favor seleccione una respuesta para esta pregunta');
    //Validamos si cada pregunta tiene una respuesta
    var descripcionPregunta1 = $("#txt_p1").val().split('*');
    var descripcionPregunta2 = $("#txt_p2").val().split('*');
    var descripcionPregunta3 = $("#txt_p3").val().split('*');
    var descripcionDestacarAP = $("#txtDestacarAP").val().split('*');
    var caracteresEspeciales = $("#txtTemasTratados").val().split('*');
    if ($("#txtTemasTratados").val() == '') {
        $("#errorTemasTratados").html('Por favor ingrese una respuesta. Este campo es requerido.');
        $("#errorTemasTratados").show();
        return false;
    }
    else if (caracteresEspeciales.length > 1) {
        $("#errorTemasTratados").html('El caracter * no está permitido. Por favor elimine este caracter de la casilla temas tratados.');
        $("#errorTemasTratados").show();
        return false;
    }
    if ($("#hfResPreg1").val() == "")//Si no hay respuesta seleccionada
    {
        $("#errResPreg1").show();
        return false;
    }
    else if (parseInt($("#hfResPreg1").val()) <= 3 && $("#txt_p1").val()=="")//Si el usuario seleccionó una respuesta menor a 3 y no hay explicación.
    {
        $("#errResPreg1").html('Por favor ingrese una justificación a este pregunta');
        $("#errResPreg1").show();
        return false;
    }
    else if (descripcionPregunta1.length > 1) //Existe el caracter * en la respuesta dada por el usuario
    {
        $("#errResPreg1").html('No se permiten el caracter * en la casilla observación de la pregunta 1');
        $("#errResPreg1").show();
        return false;
    }
    if ($("#hfResPreg2").val() == "") {
        $("#errResPreg2").show();
        return false;
    }
    else if (parseInt($("#hfResPreg2").val()) <= 3 && $("#txt_p2").val() == "") {
        $("#errResPreg2").html('Por favor ingrese una justificación a este pregunta');
        $("#errResPreg2").show();
        return false;
    }
    else if (descripcionPregunta2.length > 1) {
        $("#errResPreg2").html('No se permiten el caracter * en la casilla observación de la pregunta 2');
        $("#errResPreg2").show();
        return false;
    }
    if ($("#hfResPreg3").val() == "") {
        $("#errResPreg3").show();
        return false;
    }
    else if (parseInt($("#hfResPreg3").val()) <= 3 && $("#txt_p3").val() == "") {
        $("#errResPreg3").html('Por favor ingrese una justificación a este pregunta');
        $("#errResPreg3").show();
        return false;
    }
    else if (descripcionPregunta3.length > 1) {
        $("#errResPreg3").html('No se permiten el caracter * en la casilla observación de la pregunta 3');
        $("#errResPreg3").show();
        return false;
    }
    if ($("#selAccionesMejora").val() == "Si, ¿Cuáles?")
    {
        var caracteresEspeciales = $("#txtAccionesMejora").val().split('*');
        if ($("#txtAccionesMejora").val() == '') {
            $("#errorAccionesMejora").html('Por favor ingrese una respuesta. Este campo es requerido.');
            $("#errorAccionesMejora").show();
            return false;
        }
        else if (caracteresEspeciales.length > 1) {
            $("#errorAccionesMejora").html('El caracter * no está permitido. Por favor elimine este caracter de la casilla temas tratados.');
            $("#errorAccionesMejora").show();
            return false;
        }
    }
    if ($("#txtDestacarAP").val() == '') {
        $("#errorDestacarAP").html('Por favor ingrese una respuesta. Este campo es requerido.');
        $("#errorDestacarAP").show();
        return false;
    }
    else if (descripcionDestacarAP.length > 1) {
        $("#errorDestacarAP").html('El caracter * no está permitido. Por favor elimine este caracter de la casilla temas tratados.');
        $("#errorDestacarAP").show();
        return false;
    }
    return true;
}

function waitblockUIParamEvaluarExperiencia(mensaje) { $.blockUI({ message: "<h2>" + mensaje + "</h2>" }); }
function blockUI() { $.blockUI(); }
function unblockUI() { $.unblockUI(); }



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
        case "p4":
            if (resp <= 3) $("#txt_p4").show();
            else
            {
                $("#txt_p4").hide();
                $("#txt_p4").val('');
            }
            $("#hfResPreg4").val(valor);
            break;
    }    
}

function GuardarExperiencia()
{
    var guardar = ValidarDatosExperiencia();
    if (guardar == true)
    {
        $("#hfidAudiencia").val('1');
        $.ajax({
            type: "POST", url: '../../Views/Audiencias/EvaluarExperiencia_ajax', data: { GuardarEvaluacionExperiencia: $("#hfResPreg1").val() + '*' + $("#txt_p1").val() + '*' + $("#hfResPreg2").val() + '*' + $("#txt_p2").val() + '*' + $("#hfResPreg3").val() + '*' + $("#txt_p3").val() + '*' + $("#hfResPreg4").val() + '*' + $("#txt_p4").val() + '*' + $("#hfidAudiencia").val() + '*' + '1' }, traditional: true,
            beforeSend: function () {
                waitblockUIParamEvaluarExperiencia('Guardando datos resultados Evaluación...');
            },
            success: function (result) {
                if (result == '<||>') {
                    alert('La encuesta se almacenó satisfactoriamente');
                    //TO DO: Falta redireccionar a la vista que lo llamo o a un index
                }
                else
                {
                    alert('La encuesta NO se almacenó satisfactoriamente');
                }
                unblockUI();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("error");
                alert(textStatus + ": " + XMLHttpRequest.responseText);
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
    $("#errResPreg4").hide();
    $("#errResPreg1").html('Por favor seleccione una respuesta para esta pregunta');
    $("#errResPreg2").html('Por favor seleccione una respuesta para esta pregunta');
    $("#errResPreg3").html('Por favor seleccione una respuesta para esta pregunta');
    $("#errResPreg4").html('Por favor seleccione una respuesta para esta pregunta');
    //Validamos si cada pregunta tiene una respuesta
    var descripcionPregunta1 = $("#txt_p1").val().split('*');
    var descripcionPregunta2 = $("#txt_p2").val().split('*');
    var descripcionPregunta3 = $("#txt_p3").val().split('*');
    var descripcionPregunta4 = $("#txt_p4").val().split('*');
    if ($("#hfResPreg1").val() == "")
    {
        $("#errResPreg1").show();
        return false;
    }
    else if (parseInt($("#hfResPreg1").val()) < 3 && $("#txt_p1").val()=="")
    {
        $("#errResPreg1").html('Por favor ingrese una justificación a este pregunta');
        $("#errResPreg1").show();
        return false;
    }
    else if (descripcionPregunta1.length > 1)
    {
        $("#errResPreg1").html('No se permiten el caracter * en la casilla observación de la pregunta 1');
        $("#errResPreg1").show();
        return false;
    }

    if ($("#hfResPreg2").val() == "") {
        $("#errResPreg2").show();
        return false;
    }
    else if (parseInt($("#hfResPreg2").val()) < 3 && $("#txt_p2").val() == "") {
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
    else if (parseInt($("#hfResPreg3").val()) < 3 && $("#txt_p3").val() == "") {
        $("#errResPreg3").html('Por favor ingrese una justificación a este pregunta');
        $("#errResPreg3").show();
        return false;
    }
    else if (descripcionPregunta3.length > 1) {
        $("#errResPreg3").html('No se permiten el caracter * en la casilla observación de la pregunta 3');
        $("#errResPreg3").show();
        return false;
    }
    if ($("#hfResPreg4").val() == "") {
        $("#errResPreg4").show();
        return false;
    }
    else if (parseInt($("#hfResPreg4").val()) < 3 && $("#txt_p4").val() == "") {
        $("#errResPreg4").html('Por favor ingrese una justificación a este pregunta');
        $("#errResPreg4").show();
        return false;
    }
    else if (descripcionPregunta4.length > 1) {
        $("#errResPreg4").html('No se permiten el caracter * en la casilla observación de la pregunta 4');
        $("#errResPreg4").show();
        return false;
    }
   
    return true;
}

function waitblockUIParamEvaluarExperiencia(mensaje) { $.blockUI({ message: "<h2>" + mensaje + "</h2>" }); }
function blockUI() { $.blockUI(); }
function unblockUI() { $.unblockUI(); }



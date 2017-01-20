function InicializarCajasTextoAutoevaluacion()
{
    $("#txt_p1").hide();
    $("#txt_p2").hide();
    $("#txt_p3").hide();
    $("#txt_p4").hide();
    $("#txt_p5").hide();
    $("#txt_p6").hide();
    $("#txt_p7").hide();
    $("#txt_p8").hide();
    $("#txt_p9").hide();
    $("#txt_p10").hide();
    $("#txt_p11").hide();
  
}

function RespuestaAutoevaluacion(pregunta, valor) {
    var resp = parseInt(valor);
    switch (pregunta) {
        case "p1":
            if (resp <= 3) $("#txt_Acp1").show();
            else {
                $("#txt_Acp1").hide();
                $("#txt_Acp1").val('');
            }
            $("#AcResPreg1").val(valor);
            break;
        case "p2":
            if (resp <= 3) $("#txt_Acp2").show();
            else {
                $("#txt_Acp2").hide();
                $("#txt_Acp2").val('');
            }
            $("#AcResPreg2").val(valor);
            break;
        case "p3":
            if (resp <= 3) $("#txt_Acp3").show();
            else {
                $("#txt_Acp3").hide();
                $("#txt_Acp3").val('');
            }
            $("#AcResPreg3").val(valor);
            break;
        case "p4":
            if (resp <= 3) $("#txt_Acp4").show();
            else {
                $("#txt_Acp4").hide();
                $("#txt_Acp4").val('');
            }
            $("#AcResPreg4").val(valor);
            break;
        case "p5":
            if (resp <= 3) $("#txt_Acp5").show();
            else {
                $("#txt_Acp5").hide();
                $("#txt_Acp5").val('');
            }
            $("#AcResPreg5").val(valor);
            break;
        case "p6":
            if (resp <= 3) $("#txt_Acp6").show();
            else {
                $("#txt_Acp6").hide();
                $("#txt_Acp6").val('');
            }
            $("#AcResPreg6").val(valor);
            break;
        case "p7":
            if (resp <= 3) $("#txt_Acp7").show();
            else {
                $("#txt_Acp7").hide();
                $("#txt_Acp7").val('');
            }
            $("#AcResPreg7").val(valor);
            break;
        case "p8":
            if (resp <= 3) $("#txt_Acp8").show();
            else {
                $("#txt_Acp8").hide();
                $("#txt_Acp8").val('');
            }
            $("#AcResPreg8").val(valor);
            break;
        case "p9":
            if (resp <= 3) $("#txt_Acp9").show();
            else {
                $("#txt_Acp9").hide();
                $("#txt_Acp9").val('');
            }
            $("#AcResPreg9").val(valor);
            break;
        case "p10":
            if (resp <= 3) $("#txt_Acp10").show();
            else {
                $("#txt_Acp10").hide();
                $("#txt_Acp10").val('');
            }
            $("#AcResPreg10").val(valor);
            break;
        case "p11":
            if (resp <= 3) $("#txt_Acp11").show();
            else {
                $("#txt_Acp11").hide();
                $("#txt_Acp11").val('');
            }
            $("#AcResPreg11").val(valor);
            break;
    }
}

function CambioTextoAutoevaluacion(control) {
    $("#" + control).hide();
}


function GuardarAutoevaluacion() {
    var guardar = ValidarDatosAutoevaluacion();
    if (guardar == true) {
        //$("#AutoidAudiencia").val('1');
        $.ajax({
            type: "POST", url: '../../Views/Audiencias/AutoevaluacionAC_ajax', data: { GuardarAutoevaluacion: $("#AcResPreg1").val() + '*' + $("#txt_Acp1").val() + '*' + $("#AcResPreg2").val() + '*' + $("#txt_Acp2").val() + '*' + $("#AcResPreg3").val() + '*' + $("#txt_Acp3").val() + '*' + $("#AcResPreg4").val() + '*' + $("#txt_Acp4").val() + '*' + $("#AcResPreg5").val() + '*' + $("#txt_Acp5").val() + '*' + $("#AcResPreg6").val() + '*' + $("#txt_Acp6").val() + '*' + $("#AcResPreg7").val() + '*' + $("#txt_Acp7").val() + '*' + $("#AcResPreg8").val() + '*' + $("#txt_Acp8").val() + '*' + $("#AcResPreg9").val() + '*' + $("#txt_Acp9").val() + '*' + $("#AcResPreg10").val() + '*' + $("#txt_Acp10").val() + '*' + $("#AcResPreg11").val() + '*' + $("#txt_Acp11").val() + '*' + $("#selReunionGA").val() + '*' + $("#txtReunionGA").val() + '*' + $("#selLogroMetas").val() + '*' + $("#txtLogroMetas").val() + '*' + $("#AprendizajeAC").val() + '*' + $("#DificultadAC").val() + '*' + $("#txtSugerencias").val() + '*' + $("#hfidAudiencia").val() + '*' + $("#hfidUsuario").val() }, traditional: true,
            //type: "POST", url: '../../Views/Audiencias/AutoevaluacionAC_ajax', data: { GuardarAutoevaluacion: $("#AcResPreg1").val() + '*' + $("#AcResPreg2").val() + '*' + $("#AcResPreg3").val() + '*' + $("#AcResPreg4").val() + '*' + $("#AcResPreg5").val() + '*' + $("#AcResPreg6").val() + '*' + $("#AcResPreg7").val() + '*' + $("#txt_Acp7").val() + '*' + $("#AcResPreg8").val() + '*' + $("#txt_Acp8").val() + '*' + $("#AcResPreg9").val() + '*' + $("#AcResPreg10").val() + '*' + $("#AcResPreg11").val() + '*' + $("#AutoidAudiencia").val() + '*' + '1' }, traditional: true,
            beforeSend: function () {
                waitblockUIParamAutoevaluacion('Guardando datos resultados Autoevaluación...');
            },
            success: function (result) {
                if (result == '<||>') {
                    alert('La Autoevaluación se almacenó satisfactoriamente');
                    //TO DO: Falta redireccionar a la vista que lo llamo o a un index
                }
                else {
                    alert('La Autoevaluación NO se almacenó satisfactoriamente');
                }
                unblockUI();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("error");
                alert(textStatus + ": " + XMLHttpRequest.responseText);
            }
        });
    }
    else {
        alert("Es necesario explicar porque su respuesta");
    }
}
function ValidarDatosAutoevaluacion() {
    $("#errAcResPreg1").hide();
    $("#errAcResPreg2").hide();
    $("#errAcResPreg3").hide();
    $("#errAcResPreg4").hide();
    $("#errAcResPreg5").hide();
    $("#errAcResPreg6").hide();
    $("#errAcResPreg7").hide();
    $("#errAcResPreg8").hide();
    $("#errAcResPreg9").hide();
    $("#errAcResPreg10").hide();
    $("#errAcResPreg11").hide();
    

    $("#errAcResPreg1").html('Por favor seleccione una respuesta para esta pregunta');
    $("#errAcResPreg2").html('Por favor seleccione una respuesta para esta pregunta');
    $("#errAcResPreg3").html('Por favor seleccione una respuesta para esta pregunta');
    $("#errAcResPreg4").html('Por favor seleccione una respuesta para esta pregunta');
    $("#errAcResPreg5").html('Por favor seleccione una respuesta para esta pregunta');
    $("#errAcResPreg6").html('Por favor seleccione una respuesta para esta pregunta');
    $("#errAcResPreg7").html('Por favor seleccione una respuesta para esta pregunta');
    $("#errAcResPreg8").html('Por favor seleccione una respuesta para esta pregunta');
    $("#errAcResPreg9").html('Por favor seleccione una respuesta para esta pregunta');
    $("#errAcResPreg10").html('Por favor seleccione una respuesta para esta pregunta');
    $("#errAcResPreg11").html('Por favor seleccione una respuesta para esta pregunta');

    //Validamos si cada pregunta tiene una respuesta
    var descripcionPregunta1 = $("#txt_Acp1").val().split('*');
    var descripcionPregunta2 = $("#txt_Acp2").val().split('*');
    var descripcionPregunta3 = $("#txt_Acp3").val().split('*');
    var descripcionPregunta4 = $("#txt_Acp4").val().split('*');
    var descripcionPregunta5 = $("#txt_Acp5").val().split('*');
    var descripcionPregunta6 = $("#txt_Acp6").val().split('*');
    var descripcionPregunta7 = $("#txt_Acp7").val().split('*');
    var descripcionPregunta8 = $("#txt_Acp8").val().split('*');
    var descripcionPregunta9 = $("#txt_Acp9").val().split('*');
    var descripcionPregunta10 = $("#txt_Acp10").val().split('*');
    var descripcionPregunta11 = $("#txt_Acp11").val().split('*');
    var descripcionReunionGA = $("txtReunionGA").val().split('*');
    var descripcionLogroMetas = $("txtLogroMetas").val().split('*');
    var descripcionAprendizajeAC = $("txtAprendizajeAC").val().split('*');
    var descripcionDificultadAC = $("txtDificultadAC").val().split('*');
    var descripcionSugerencias = $("txtSugerencias").val().split('*');

    if ($("#txtReunionGA").val() == '') {
        $("#errorReunionGA").html('Por favor ingrese una respuesta. Este campo es requerido.');
        $("#errorReunionGA").show();
        return false;
    }
    else if (caracteresEspeciales.length > 1) {
        $("#errorReunionGA").html('El caracter * no está permitido. Por favor elimine este caracter de la casilla.');
        $("#errorReunionGA").show();
        return false;
    }

    if ($("#txtLogroMetas").val() == '') {
        $("#errorLogroMetas").html('Por favor ingrese una respuesta. Este campo es requerido.');
        $("#errorLogroMetas").show();
        return false;
    }
    else if (caracteresEspeciales.length > 1) {
        $("#errorLogroMetas").html('El caracter * no está permitido. Por favor elimine este caracter de la casilla.');
        $("#errorLogroMetas").show();
        return false;
    }

    if ($("#txtAprendizajeAC").val() == '') {
        $("#errorAprendizajeAC").html('Por favor ingrese una respuesta. Este campo es requerido.');
        $("#errorAprendizajeAC").show();
        return false;
    }
    else if (caracteresEspeciales.length > 1) {
        $("#errorAprendizajeAC").html('El caracter * no está permitido. Por favor elimine este caracter de la casilla.');
        $("#errorAprendizajeAC").show();
        return false;
    }
    
    if ($("#txtDificultadAC").val() == '') {
        $("#errorDificultadAC").html('Por favor ingrese una respuesta. Este campo es requerido.');
        $("#errorDificultadAC").show();
        return false;
    }
    else if (caracteresEspeciales.length > 1) {
        $("#errorDificultadAC").html('El caracter * no está permitido. Por favor elimine este caracter de la casilla.');
        $("#errorDificultadAC").show();
        return false;
    }

    if ($("#txtSugerencias").val() == '') {
        $("#errorSugerencias").html('Por favor ingrese una respuesta. Este campo es requerido.');
        $("#errorSugerencias").show();
        return false;
    }
    else if (caracteresEspeciales.length > 1) {
        $("#errorSugerencias").html('El caracter * no está permitido. Por favor elimine este caracter de la casilla.');
        $("#errorSugerencias").show();
        return false;
    }


    if ($("#AcResPreg1").val() == "") {
        $("#errAcResPreg1").show();
        return false;
    }
    else if (parseInt($("#AcResPreg1").val()) <= 3 && $("#txt_Acp1").val() == "") {
        $("#errAcResPreg1").html('Por favor ingrese una justificación a este pregunta');
        $("#errAcResPreg1").show();
        return false;
    }
    else if (descripcionPregunta1.length > 1) {
        $("#errAcResPreg1").html('No se permiten el caracter * en la casilla observación de la pregunta 1');
        $("#errAcResPreg1").show();
        return false;
    }

    if ($("#AcResPreg2").val() == "") {
        $("#errAcResPreg2").show();
        return false;
    }
    else if (parseInt($("#AcResPreg2").val()) <= 3 && $("#txt_Acp2").val() == "") {
        $("#errAcResPreg2").html('Por favor ingrese una justificación a este pregunta');
        $("#errAcResPreg2").show();
        return false;
    }
    else if (descripcionPregunta2.length > 1) {
        $("#errAcResPreg2").html('No se permiten el caracter * en la casilla observación de la pregunta 2');
        $("#errAcResPreg2").show();
        return false;
    }
    if ($("#AcResPreg3").val() == "") {
        $("#errAcResPreg3").show();
        return false;
    }
    else if (parseInt($("#AcResPreg3").val()) <= 3 && $("#txt_Acp3").val() == "") {
        $("#errAcResPreg3").html('Por favor ingrese una justificación a este pregunta');
        $("#errAcResPreg3").show();
        return false;
    }
    else if (descripcionPregunta3.length > 1) {
        $("#errAcResPreg3").html('No se permiten el caracter * en la casilla observación de la pregunta 3');
        $("#errAcResPreg3").show();
        return false;
    }
    if ($("#AcResPreg4").val() == "") {
        $("#errAcResPreg4").show();
        return false;
    }
    else if (parseInt($("#AcResPreg4").val()) <= 3 && $("#txt_Acp4").val() == "") {
        $("#errAcResPreg4").html('Por favor ingrese una justificación a este pregunta');
        $("#errAcResPreg4").show();
        return false;
    }
    else if (descripcionPregunta4.length > 1) {
        $("#errAcResPreg4").html('No se permiten el caracter * en la casilla observación de la pregunta 4');
        $("#errAcResPreg4").show();
        return false;
    }
    if ($("#AcResPreg5").val() == "") {
        $("#errAcResPreg5").show();
        return false;
    }
    else if (parseInt($("#AcResPreg5").val()) <= 3 && $("#txt_Acp5").val() == "") {
        $("#errAcResPreg5").html('Por favor ingrese una justificación a este pregunta');
        $("#errAcResPreg5").show();
        return false;
    }
    else if (descripcionPregunta5.length > 1) {
        $("#errAcResPreg5").html('No se permiten el caracter * en la casilla observación de la pregunta 5');
        $("#errAcResPreg5").show();
        return false;
    }
    if ($("#AcResPreg6").val() == "") {
        $("#errAcResPreg6").show();
        return false;
    }
    else if (parseInt($("#AcResPreg6").val()) <= 3 && $("#txt_Acp6").val() == "") {
        $("#errAcResPreg6").html('Por favor ingrese una justificación a este pregunta');
        $("#errAcResPreg6").show();
        return false;
    }
    else if (descripcionPregunta6.length > 1) {
        $("#errAcResPreg6").html('No se permiten el caracter * en la casilla observación de la pregunta 6');
        $("#errAcResPreg6").show();
        return false;
    }
    if ($("#AcResPreg7").val() == "") {
        $("#errAcResPreg7").show();
        return false;
    }
    else if (parseInt($("#AcResPreg7").val()) <= 3 && $("#txt_Acp7").val() == "") {
        $("#errAcResPreg7").html('Por favor ingrese una justificación a este pregunta');
        $("#errAcResPreg7").show();
        return false;
    }
    else if (descripcionPregunta7.length > 1) {
        $("#errAcResPreg7").html('No se permiten el caracter * en la casilla observación de la pregunta 7');
        $("#errAcResPreg7").show();
        return false;
    }
    if ($("#AcResPreg8").val() == "") {
        $("#errAcResPreg8").show();
        return false;
    }
    else if (parseInt($("#AcResPreg8").val()) <= 3 && $("#txt_Acp8").val() == "") {
        $("#errAcResPreg8").html('Por favor ingrese una justificación a este pregunta');
        $("#errAcResPreg8").show();
        return false;
    }
    else if (descripcionPregunta8.length > 1) {
        $("#errAcResPreg8").html('No se permiten el caracter * en la casilla observación de la pregunta 8');
        $("#errAcResPreg8").show();
        return false;
    }
    if ($("#AcResPreg9").val() == "") {
        $("#errAcResPreg9").show();
        return false;
    }
    else if (parseInt($("#AcResPreg9").val()) <= 3 && $("#txt_Acp9").val() == "") {
        $("#errAcResPreg9").html('Por favor ingrese una justificación a este pregunta');
        $("#errAcResPreg9").show();
        return false;
    }
    else if (descripcionPregunta9.length > 1) {
        $("#errAcResPreg9").html('No se permiten el caracter * en la casilla observación de la pregunta 9');
        $("#errAcResPreg9").show();
        return false;
    }
      if ($("#AcResPreg10").val() == "") {
        $("#errAcResPreg10").show();
        return false;
    }
    else if (parseInt($("#AcResPreg10").val()) <= 3 && $("#txt_Acp10").val() == "") {
        $("#errAcResPreg10").html('Por favor ingrese una justificación a este pregunta');
        $("#errAcResPreg10").show();
        return false;
    }
    else if (descripcionPregunta10.length > 1) {
        $("#errAcResPreg10").html('No se permiten el caracter * en la casilla observación de la pregunta 10');
        $("#errAcResPreg10").show();
        return false;
    }
      if ($("#AcResPreg11").val() == "") {
          $("#errAcResPreg11").show();
          return false;
      }
      else if (parseInt($("#AcResPreg11").val()) <= 3 && $("#txt_Acp11").val() == "") {
          $("#errAcResPreg11").html('Por favor ingrese una justificación a este pregunta');
          $("#errAcResPreg11").show();
          return false;
      }
      else if (descripcionPregunta11.length > 1) {
          $("#errAcResPreg11").html('No se permiten el caracter * en la casilla observación de la pregunta 11');
          $("#errAcResPreg11").show();
          return false;
      }
    return true;
}

function waitblockUIParamAutoevaluacion(mensaje) { $.blockUI({ message: "<h2>" + mensaje + "</h2>" }); }
function blockUI() { $.blockUI(); }
function unblockUI() { $.unblockUI(); }

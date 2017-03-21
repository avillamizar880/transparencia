$('.form_date').datetimepicker({
    language: 'es',
    weekStart: 1,
    todayBtn: 1,
    autoclose: 1,
    todayHighlight: 1,
    startView: 2,
    minView: 2,
    forceParse: 0
});

$("#btnAddPregunta").click(function () {
    $("#divContenedorPreguntas").slideDown(function () {
        limpiar_datos("all");
        inhabilitar_campos();
        var tipo_cuestionario = $('#ddlTipoCuestionario option:selected').val();
        if (tipo_cuestionario == "2") {
            $('#ddlTipoPregunta').val('4');
            $('#ddlTipoPregunta').attr("disabled", "disabled");
            $('#ddlTipoPregunta').change();
        }
        $("#divBtnCrearPregunta").show();
        $("#divBtnModificarPregunta").hide();


    });
});

$("#btnEditarCuestionario").click(function () {
    $("#divContenedorPreguntas").slideUp(function () {
        $('#ddlTipoCuestionario,#txtTitulo,#txtDescripcion').removeAttr("disabled");
        $("#divEditarCuestionario").hide();
        $("#divModificarCuestionario").show();
    });
});




$('#ddlTipoPregunta').bind('change', function () {
    limpiar_datos("all");
    inhabilitar_campos();
    var val_tipo = $('option:selected', $(this)).val();
    if (val_tipo == "1") {
        $('#divPregTexto').show();
        $('#help_ddlTipoPregunta_aux').html("La respuesta será abierta. Quien responda podrá escribir un texto corto");
    } else if (val_tipo == "2") {
        $('#divPregRadio').show();
        $('#help_ddlTipoPregunta_aux').html("El usuario tendrá varias opciones de respuesta, pero sólo podrá seleccionar una");
    } else if (val_tipo == "3") {
        $('#divPregCheckbox').show();
        $('#help_ddlTipoPregunta_aux').html("El usuario tendrá varias opciones de respuesta y podrá seleccionar una o varias");
    } else if (val_tipo == "4") {
        $('#divPregTextArea').show();
        $('#help_ddlTipoPregunta_aux').html("La respuesta será abierta y podrá escribir un párrafo hasta de 300 letras, si lo necesita");
    } else if (val_tipo == "5") {
        $('#divPregEscala').show();
        $('#help_ddlTipoPregunta_aux').html("La respuesta deberá seleccionarse en un rango entre 1 y 10");
    } else if (val_tipo == "6") {
        $('#divPregFecha').show();
        $('#help_ddlTipoPregunta_aux').html("La respuesta deberá ser una fecha, se le mostrará al usuario un calendario para seleccionar");
    } else if (val_tipo == "7") {
        $('#divPregTiempo').show();
        $('#help_ddlTipoPregunta_aux').html("La repuesta será en términos de horas y minutos, por ejemplo 02:30");
    } else {
        limpiar_datos("all");
    }
});

$('#ddlTipo_validacion_dato').bind('change', function () {
    //$('#ddlTextoLimite').val("");
    var val_old = $(this).val();
    inhabilitar_campos();
    $(this).removeAttr("disabled").val(val_old);
    var sel_valor = $('option:selected', $(this)).val();
    if (sel_valor != "") {
        $("#txtCampoEquivocado").removeAttr("disabled");
    } 
    if (sel_valor == "1") {
        //numero--habilita tipo limite
        $('#ddlTextoLimite').removeAttr("disabled");
    } else {
        //deshabilita tipo limite
        $('#ddlTextoLimite').val("").attr("disabled", "disabled");
    }
});

$('#chkValidaDatosTexto').bind('change', function () {
    inhabilitar_campos();
    if ($(this).is(':checked')) {
        //habilita tipo validacion
        $('#ddlTipo_validacion_dato').removeAttr("disabled");

    }else{
        //deshabilita tipo validacion
        $('#ddlTipo_validacion_dato').val('').attr("disabled", "disabled");
    }
});

$('#chkValidaDatosCheck').bind('change', function () {
    //$('#ddlCantidadCheckValida').val('');
    inhabilitar_campos();
    if ($(this).is(':checked')) {
        //habilita tipo validacion
        $('#ddlCantidadCheckValida').removeAttr("disabled");

    } else {
        //deshabilita tipo validacion
        $('#ddlCantidadCheckValida').val('').attr("disabled", "disabled");
    }
});

$('#ddlCantidadCheckValida').bind('change', function () {
    var val_old = $(this).val();
    inhabilitar_campos();
    $(this).removeAttr("disabled").val(val_old);
    var sel_valor = $('option:selected', $(this)).val();
    if (sel_valor != "") {
        $("#txtLimiteCheck").removeAttr("disabled");
        $("#txtCampoEquivocadoCheck").removeAttr("disabled");

    } else {

    }

});


$('#chkValidaDatosParrafo').bind('change', function () {
    //$('#ddlValidaLongitud').val('');
    inhabilitar_campos();
    
    if ($(this).is(':checked')) {
        //habilita tipo validacion
        $('#ddlValidaLongitud').removeAttr("disabled");

    } else {
        //deshabilita tipo validacion
        $('#ddlValidaLongitud').val('').attr("disabled", "disabled");
    }
});

$('#ddlValidaLongitud').bind('change', function () {
    //$('#ddlTextoLimite').val("");
    var val_old = $(this).val();
    inhabilitar_campos();
    $(this).removeAttr("disabled").val(val_old);
    var sel_valor = $('option:selected', $(this)).val();
    if (sel_valor != "") {
        $("#txtLimiteParrafo").removeAttr("disabled");
        $("#txtCampoEquivocadoParrafo").removeAttr("disabled");

    } else {

    }
   
});

$('#ddlEscalaInicial').bind('change', function () {
    var sel_valor = $('option:selected', $(this)).val();
    $("#spnEscalaInicial").html(sel_valor);
});

$('#ddlEscalaFinal').bind('change', function () {
    var sel_valor = $('option:selected', $(this)).val();
    $("#spnEscalaFinal").html(sel_valor);

});

$('#ddlTextoLimite').bind('change', function () {
    $("#txtLimiteValor").val("");
    $("#txtLimiteValor_final").val("");
    var sel_valor = $('option:selected', $(this)).val();
    if (sel_valor != "") {
        if (sel_valor == "11" || sel_valor == "12") {
            $('#txtLimiteValor').removeAttr("disabled");
            $('#txtLimiteValor_final').removeAttr("disabled");
            $("#divLimiteFinal").show();

        } else {
            $('#txtLimiteValor').removeAttr("disabled");
            $("#divLimiteFinal").hide();

        }
    } else {
        //deshabilita campo limite
        $("#txtLimiteValor").val("").attr("disabled", "disabled");
        $("#txtLimiteValor_final").val("").attr("disabled", "disabled");

        
    }
});

$('#chkTiempoDuracion').bind('change', function () {
    if ($(this).is(':checked')) {
        $("#textHoraDuracion").val("13:45:10");
    } else {
        $("#textHoraDuracion").val("13:45");
    }
});

$('#chkIncluirAnyo').bind('change', function () {
    if ($(this).is(':checked')) {
        $("#txtFechaEjemplo").val("2017-08-01");
    } else {
        $("#txtFechaEjemplo").val("08-01");
    }
});

$('#chkIncluirHora').bind('change', function () {
    if ($(this).is(':checked')) {
        $("#divHoraPregFecha").show();
    } else {
        $("#divHoraPregFecha").hide();
    }
});


$('#btnCrearCuestionario').bind('click', function () {
    var opc = "CREAR";
    var titulo = $("#txtTitulo").val();
    var descripcion = $("#txtDescripcion").val();
    var idTipoCuestionario = $('option:selected', $('#ddlTipoCuestionario')).val();
    var formulario = "1";
    var id_usuario = $("#hdIdUsuario").val();
    if (id_usuario == "") {
        bootbox.alert("Acción válida para usuarios registrados");
    } else {
        if (idTipoCuestionario == "0") {
                $("#error_ddlTipoCuestionario").show();
                formulario = "0";
            } else { $("#error_ddlTipoCuestionario").hide(); }
            if (titulo == "") {
                $("#error_txtTitulo").show();
                formulario = "0";
            } else { $("#error_txtTitulo").hide(); }
            if (descripcion == "") {
                $("#error_txtDescripcion").show();
                formulario = "0";
            } else { $("#error_txtTitulo").hide(); }
            if (formulario == "1") {
                $("#error_ddlTipoCuestionario").hide();
                $("#error_txtTitulo").hide();
                $("#error_txtDescripcion").hide();
                var params = {id_usuario:id_usuario,id_tipo:idTipoCuestionario,titulo: titulo, descripcion: descripcion, opc: opc };
                crearCuestionario(params);
            } else {
        
                bootbox.alert("Faltan datos obligatorios");                          
            }
    }

});

$("#btnModificarCuestionario").click(function () {
    var opc = "MODIF";
    var idCuestionario = $("#hdIdCuestionario").val();
    var titulo = $("#txtTitulo").val();
    var descripcion = $("#txtDescripcion").val();
    var idTipoCuestionario = $('option:selected', $('#ddlTipoCuestionario')).val();
    var formulario = "1";
    var id_usuario = $("#hdIdUsuario").val();
    if (id_usuario == "") {
        bootbox.alert("Acción válida para usuarios registrados");
    } else {
        if (idTipoCuestionario == "0") {
            $("#error_ddlTipoCuestionario").show();
            formulario = "0";
        } else { $("#error_ddlTipoCuestionario").hide(); }
        if (titulo == "") {
            $("#error_txtTitulo").show();
            formulario = "0";
        } else { $("#error_txtTitulo").hide(); }
        if (descripcion == "") {
            $("#error_txtDescripcion").show();
            formulario = "0";
        } else { $("#error_txtTitulo").hide(); }
        if (formulario == "1") {
            $("#error_ddlTipoCuestionario").hide();
            $("#error_txtTitulo").hide();
            $("#error_txtDescripcion").hide();
            var params = { id_usuario: id_usuario, id_cuestionario: idCuestionario, id_tipo: idTipoCuestionario, titulo: titulo, descripcion: descripcion, opc: opc };
            editarCuestionario(params);
        } else {

            bootbox.alert("Faltan datos obligatorios");
        }
    }
});

$("#btnCrearPregunta").bind('click', function () {
    var opc = "PREG";
    guardarPregunta(opc,"");
    

});

$("#btnAgregarRadio").bind('click', function () {
    //Unica respuesta
   agregaPregRadio();

});

$("#btnAgregarCheck").bind('click', function () {
    //Multiples respuestas
    agregaPregCheck();

});

$("#btnObtCuestionario").bind('click', function () {
    var id_cuestionario = $("#hdIdCuestionario").val();
    var params = { id_cuestionario: id_cuestionario, opcion: "EDITAR" };
    obtPreguntasCuestionario(params);

});

$("#divGenAyuda").bind('click', function () {
    var id_cuestionario = $("#hdIdCuestionario").val();
    var params = { id_cuestionario: id_cuestionario , opcion: "RESPONDER" };
    $("#divGeneralPag").slideUp(function () {
        $("#divListadoPreguntas").slideDown(function () {
            envioPreguntas_ini(params);
        });
    });
    

});

$("#btnModificarPregunta").bind('click', function () {
    var opc = "PREG_MODIF";
    var id_pregunta = $("#hdIdPregunta").val();
    guardarPregunta(opc,id_pregunta);

});
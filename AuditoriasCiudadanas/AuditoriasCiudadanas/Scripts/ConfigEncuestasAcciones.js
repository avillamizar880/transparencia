$("#btnAddPregunta").click(function () {
    $("#divContenedorPreguntas").slideDown(function () {
       
    });
});

$('#ddlTipoPregunta').bind('change', function () {
    var val_tipo = $('option:selected', $(this)).val();
    if (val_tipo == "1") {
        $(".well").hide();
        $('#divPregTexto').show();
    } else if (val_tipo == "2") {
        $(".well").hide();
        $('#divPregRadio').show();
    } else if (val_tipo == "3") {
        $(".well").hide();
        $('#divPregCheckbox').show();
    } else if (val_tipo == "4") {
        $(".well").hide();
        $('#divPregTextArea').show();
    } else if (val_tipo == "5") {
        $(".well").hide();
        $('#divPregEscala').show();
    } else if (val_tipo == "6") {
        $(".well").hide();
        $('#divPregFecha').show();
    } else if (val_tipo == "7") {
        $(".well").hide();
        $('#divPregTiempo').show();
    } else {
        $(".well").hide();
    }
});

$('#btnCrearCuestionario').bind('click', function () {
    var opc = "CREAR";
    var titulo = $("#txtTitulo").val();
    var descripcion = $("#txtDescripcion");
    var idTipoCuestionario = $('option:selected', $('#ddlTipoCuestionario')).val();
    var formulario = "1";
    if (idTipoCuestionario == "") {
        $("#error_ddlTipoCuestionario").show();
        formulario = "0";
    }
    if (titulo == "") {
        $("#error_txtTitulo").show();
        formulario = "0";
    }
    if (descripcion == "") {
        $("#error_txtDescripcion").show();
        formulario = "0";
    }
    if (formulario == "1") {
        $("#error_ddlTipoCuestionario").hide();
        $("#error_txtTitulo").hide();
        $("#error_txtDescripcion").hide();
        var params = { titulo: titulo, descripcion: descripcion,opc:opc};
        crearCuestionario(params);
    }
   

});
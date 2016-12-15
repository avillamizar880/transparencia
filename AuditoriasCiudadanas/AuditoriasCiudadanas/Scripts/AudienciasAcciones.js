//$('.aclugar').autocomplete({
//    source: function (request, response) {
//        var ac = $("#" + this.element.attr('id'));
//        var lstIdMunicipio = "";
//        $('.aclugar').each(function (ix, el) {
//            if (ac.attr("id") != $(el).attr("id") && $(el).next().val() != "") {
//                lstIdMunicipio += $(el).next().val() + ",";
//            }
//        });
//        if (lstIdMunicipio != "") {
//            lstIdMunicipio = lstIdMunicipio.substr(0, lstIdMunicipio.length - 1);
//        }
//        $.ajax({
//            url: "../../Views/General/listarMunicipiosDep",
//            dataType: "json",
//            data: {
//                nomb_municipio: request.term, lstIdMunicipio: lstIdMunicipio
//            },
//            type: "POST",
//            success: function (data) {
//                if (data == null) {
                    
//                    response([{ label: "[No se encontraron resultados con el criterio seleccionado]", value: "", "prueba": "" }]);
//                } else {
//                     response($.map(data.Head, function (item) {
//                        return {
//                            label: item.MUNICIPIO,
//                            value: item.ID
//                         }
//                    }));
//                }

//            },
//            error: function (e) {
//                alert("No se encontraron municipios con el término de búsqueda seleccionado.", function () { ac.removeClass("ui-autocomplete-loading").val("").next().val("").next().val(""); });
//            }
//        });
//    },
//    minLength: 3,
//    delay: 500,
//    select: function (event, ui) {
//        alert("select");
//        $(this).removeClass("ui-autocomplete-loading");
//        $(this).val(ui.item.label).next().val(ui.item.value);
//        return false;
//    },
//    open: function () {
//        alert("open");
//        $('.ui-autocomplete').css("width", $(this).width() + "px");
//        $(this).removeClass("ui-corner-all").addClass("ui-corner-top");
//    },
//    close: function () {
//        alert("close");
//        $(this).removeClass("ui-autocomplete-loading");
//        if ($(this).next().val() == "") {
//            $(this).val("");
//        }
//        $(this).removeClass("ui-corner-top").addClass("ui-corner-all");
//    }
//}).bind('blur onblur', function () {
//    alert("onblur");
//    if ($(this).val() == "") {
//        $(this).next().val("").next().val("");
//    }
//});


//$("#btnGuardarActa").click(function () {
//    //valida campos obligatorios,llama a funcion
//    var id_audiencia = $("#id_audiencia").val();
//    var tema = $("#txtTema").val();
//    var lugar= $("#txtLugar").val();
//    var fecha = $("#dtp_fecha_acta").val();
//    var id_usuario = $("#hfIdUsuario").val();
//    var params = { tema: tema, lugar: lugar, fecha: fecha,id_audiencia:id_audiencia ,id_usuario:id_usuario};
//    ajaxPost('../Views/Audiencias/ActaReuniones_ajax', params, null, function (r) {
//        var codigo_error = r.split("<||>")[0];
//        var mensaje = r.split("<||>")[1];
//        if (r.indexOf("<||>") != -1) {
//            if (codigo_error == '0') {
//                alert("Acta guardada exitosamente");
//            } else {
//                alert(mensaje);
//            }
//        }
//    }, function (r) {
//        alert(r.responseText);
//    });

//});

$("#btnDescargaFormato").click(function () {
    var loginform = $("#loginForm");
    loginform.submit();
    //ajaxPost('../../Views/Audiencias/DescargaFormato_ajax', null, null, function (r) {

    //}, function (r) {
    //    alert(r.responseText);
    //});

});

$("#btnRegObservaciones").click(function () {
    var id_audiencia=$("#id_audiencia").val();
    var txtInfoCompleta = $("#txtInfoCompleta").val();
    var txtInfoClara = $("#txtInfoClara").val();
    var txtComunidad = $("#txtComunidad").val() ;
    var txtDudas = $("#txtDudas").val();
    var fecha_posterior_1 = $("#fecha_posterior_1").val();
    var fecha_posterior_2 = $("#fecha_posterior_1").val();
    var params = {
        id_audiencia: id_audiencia,
        info_clara: txtInfoClara,
        info_completa: txtInfoCompleta,
        comunidad_benef: txtComunidad,
        dudas: txtDudas,
        fecha_posterior_1: fecha_posterior_1,
        fecha_posterior_2: fecha_posterior_2
    };
    registrarObsAudiencia(params);

});
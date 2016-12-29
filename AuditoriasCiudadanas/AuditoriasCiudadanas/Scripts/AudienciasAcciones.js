$("[id$=txtMunicipio]").autocomplete({
    source: function (request, response) {
       $.ajax({
            url: '../../Views/General/listarMunicipiosDep',
            cache: false,
            dataType: "json",
            data: {
                texto: request.term
            },
            type: "POST",
            success: function (data) {
                if (data == null) {
                    response([{ label: "[No se encontraron resultados con el criterio seleccionado]", value: ""}]);
                } else {
                    response($.map(data.Head, function (item) {
                        return {
                            label: item.municipio,
                            value: item.id,
                         }
                    }));
                }

            },
            error: function (response) {
                alert(response.responseText);
            },
            failure: function (response) {
                alert(response.responseText);
            }
        });
    },
    delay: 300,
    select: function (event, ui) {
        $(this).val(ui.item.label).next().val(ui.item.value);
        return false;
    }
}).bind('blur onblur', function () {
    if ($(this).val() == "") {
        $(this).next().val("");
    }
}).focus(function () {
    //$(this).autocomplete("search", $(this).val());
});;

var $input = $("#btnUploadImg");
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



$("#btnDescargaFormato").click(function () {
    var loginform = $("#loginForm");
    loginform.submit();
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

$("#btnRegCompromisos").click(function () {
    ////valida info, crea xml
    var xml_txt = "";
    var id_audiencia = $("#hdIdaudiencia").val();
    var id_usuario_cre = $("#hdIdUsuario").val();
    xml_txt += "<compromisos><id_audiencia>" + id_audiencia + "</id_audiencia><id_usuario_cre>" + id_usuario_cre + "</id_usuario_cre>";
    $('tbody>tr', $("#tb_compromisos")).each(function (i, e) {
        xml_txt += "<registro>";
        $('td>input', $(e)).each(function (ii, ee) {
            if ($(ee).attr("class").indexOf("compromiso") > -1) {
                xml_txt += "<descripcion>" + $(ee).val() + "</descripcion>";
            } else if ($(ee).attr("class").indexOf("responsable") > -1) {
                xml_txt += "<responsables>" + $(ee).val() + "</responsables>";
            } else {
                xml_txt += "<fecha_cumplimiento>" + $(ee).val() + "</fecha_cumplimiento>";
            };
        });
        xml_txt += "</registro>";
    });
    xml_txt += "</compromisos>";
    var params = { xml_info: xml_txt };
    registrarCompromisosAud(params);
});

$("#btnProponerFechaPrevias").click(function () {
    var id_proyecto = $("#hfidproyecto").val();
    var id_usuario = $("#hdIdUsuario").val();
    var fecha = $("#fecha_posterior_1").val();
    var msg_error = "";
    if (id_proyecto != "" && id_usuario != "") {
        if (fecha == "") {
            msg_error += "@fecha"
            bootbox.alert("Debe ingresar una fecha válida");
        }
    } else {
        if (id_proyecto == "") {
            msg_error+="@Bpin proyecto,"
        }
        if (id_usuario == "") {
            msg_error += "@Usuario no registrado"
        }
        //msg_error.trimEnd(',');
        bootbox.alert("Datos de enlace inválidos: " + msg_error);
    }
    if (msg_error == "") {
        var params = {
                codigo_bpin: id_proyecto,
                id_usuario: id_usuario,
                fecha: fecha
            };
            proponerFechaReuPrevias(params);
    }
    
});
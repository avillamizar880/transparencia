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

$('#btnObsInformePrevio').bind('click', function () {
    var cod_pin = $("#hfidproyecto").val();
    var id_usuario = $("#hdIdUsuario").val();
    var txtInfoCompleta = $("#txtInfoCompleta").val();
    var txtInfoClara = $("#txtInfoClara").val();
    var txtComunidad = $("#txtComunidad").val() ;
    var txtDudas = $("#txtDudas").val();
    var fecha_posterior_1 = $("#fecha_posterior_1").val();
    var fecha_posterior_2 = $("#fecha_posterior_1").val();
    var params = {
        cod_bpin: cod_pin,
        id_usuario:id_usuario,
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


//$("#txtMunicipio").autocomplete({
//    source: function (request, response) {
//        $.ajax({
//            url: '../../Views/General/listarMunicipiosDep',
//            cache: false,
//            dataType: "json",
//            data: {
//                texto: request.term
//            },
//            type: "POST",
//            success: function (data) {
//                if (data == null) {
//                    response([{ label: "[No se encontraron resultados con el criterio seleccionado]", value: "" }]);
//                } else {
//                    response($.map(data.Head, function (item) {
//                        return {
//                            label: item.municipio,
//                            value: item.id,
//                        }
//                    }));
//                }

//            },
//            error: function (response) {
//                alert(response.responseText);
//            },
//            failure: function (response) {
//                alert(response.responseText);
//            }
//        });
//    },
//    delay: 300,
//    select: function (event, ui) {
//        $(this).val(ui.item.label).next().val(ui.item.value);
//        return false;
//    }
//}).bind('blur onblur', function () {
//    if ($(this).val() == "") {
//        $(this).next().val("");
//    }
//});


$("#btnValoracionproyecto").click(function () {
    var codigoBPIN = $("#hfidproyecto").val();
    var idusuario = $("#hdIdUsuario").val();
    var ProyP1 = "";
    var ProyP2 = "";
    var ProyP3 = "";
    var ProyP3Cual = "";
    var ProyP4 = "";
    var ProyP5 = "";
    var AudP1 = "";
    var AudP2 = "";
    var AudP3GAC = "";
    var AudP3Int = "";
    var AudP3Sup = "";
    var AudP3Con = "";
    var AudP3Eje = "";
    var AudP3Ent = "";
    var AudP4GAC = "";
    var AudP4Int = "";
    var AudP4Sup = "";
    var AudP4Con = "";
    var AudP4Eje = "";
    var AudP4Ent = "";
    var AudP5 = "";
    var AudP6 = "";
    var GacP1 = "";
    var GacP2 = "";
    var GacP3 = "";

    var msg_error = "";

    if (codigoBPIN == "") {
        msg_error += "@Bpin proyecto,"
        bootbox.alert("Datos de enlace inválidos: " + msg_error);
    }
    else if (idusuario == "") {
        msg_error += "@Usuario no registrado"
        bootbox.alert("Datos de enlace inválidos: " + msg_error);
    }

    if ($("#PP1_op1").is(':checked')) { ProyP1 = "SI" }
    if ($("#PP1_op2").is(':checked')) { ProyP1 = "NO" }
    if ($("#PP2_op1").is(':checked')) { ProyP2 = "SI" }
    if ($("#PP2_op2").is(':checked')) { ProyP2 = "NO" }
    if ($("#PP3_op1").is(':checked')) { ProyP3 = "1" }
    if ($("#PP3_op2").is(':checked')) { ProyP3 = "2" }
    if ($("#PP3_op3").is(':checked')) { ProyP3 = "3" }
    if ($("#PP3_op4").is(':checked')) {
        ProyP3 = "4"
        Proyp3Cual = $("#PP3e_rop3").val();
        if (Proyp3Cual == "") {
            bootbox.alert("Debe ingresar una valor en la pregunta número 3");
            msg_error += "@validacion pregunta 3"
        }
    }
    if ($("#PP4_op1").is(':checked')) { ProyP4 = "SI" }
    if ($("#PP4_op2").is(':checked')) { ProyP4 = "NO" }
    if ($("#PP5_op1").is(':checked')) { ProyP5 = "SI" }
    if ($("#PP5_op2").is(':checked')) { ProyP5 = "NO" }
    if ($("#AP1_op1").is(':checked')) { AudP1 = "SI" }
    if ($("#AP1_op2").is(':checked')) { AudP1 = "NO" }
    if ($("#AP2_op1").is(':checked')) { AudP2 = "SI" }
    if ($("#AP2_op2").is(':checked')) { AudP2 = "NO" }
    if ($("#AP31_op1").is(':checked')) { AudP3GAC = "SI" }
    if ($("#AP31_op2").is(':checked')) { AudP3GAC = "NO" }
    if ($("#AP32_op1").is(':checked')) { AudP3Int = "SI" }
    if ($("#AP32_op2").is(':checked')) { AudP3Int = "NO" }
    if ($("#AP33_op1").is(':checked')) { AudP3Sup = "SI" }
    if ($("#AP33_op2").is(':checked')) { AudP3Sup = "NO" }
    if ($("#AP34_op1").is(':checked')) { AudP3Con = "SI" }
    if ($("#AP34_op2").is(':checked')) { AudP3Con = "NO" }
    if ($("#AP35_op1").is(':checked')) { AudP3Eje = "SI" }
    if ($("#AP35_op2").is(':checked')) { AudP3Eje = "NO" }
    if ($("#AP36_op1").is(':checked')) { AudP3Ent = "SI" }
    if ($("#AP36_op2").is(':checked')) { AudP3Ent = "NO" }
    if ($("#AP41_op1").is(':checked')) { AudP4GAC = "SI" }
    if ($("#AP41_op2").is(':checked')) { AudP4GAC = "NO" }
    if ($("#AP42_op1").is(':checked')) { AudP4Int = "SI" }
    if ($("#AP42_op2").is(':checked')) { AudP4Int = "NO" }
    if ($("#AP43_op1").is(':checked')) { AudP4Sup = "SI" }
    if ($("#AP43_op2").is(':checked')) { AudP4Sup = "NO" }
    if ($("#AP44_op1").is(':checked')) { AudP4Con = "SI" }
    if ($("#AP44_op2").is(':checked')) { AudP4Con = "NO" }
    if ($("#AP45_op1").is(':checked')) { AudP4Eje = "SI" }
    if ($("#AP45_op2").is(':checked')) { AudP4Eje = "NO" }
    if ($("#AP46_op1").is(':checked')) { AudP4Ent = "SI" }
    if ($("#AP46_op2").is(':checked')) { AudP4Ent = "NO" }
    if ($("#AP5_op1").is(':checked')) { AudP5 = "SI" }
    if ($("#AP5_op2").is(':checked')) { AudP5 = "NO" }
    if ($("#AP6_op1").is(':checked')) { AudP6 = "SI" }
    if ($("#AP6_op2").is(':checked')) { AudP6 = "NO" }
    if ($("#GP1_op1").is(':checked')) { GacP1 = "SI" }
    if ($("#GP1_op2").is(':checked')) { GacP1 = "NO" }
    if ($("#GP2_op1").is(':checked')) { GacP2 = "SI" }
    if ($("#GP2_op2").is(':checked')) { GacP2 = "NO" }
    if ($("#GP3_op1").is(':checked')) { GacP3 = "SI" }
    if ($("#GP3_op2").is(':checked')) { GacP3 = "NO" }

    if (msg_error == "") {

        var params = {
            codigoBPIN: codigoBPIN,
            idusuario: idusuario,
            ProyP1: ProyP1,
            ProyP2: ProyP2,
            ProyP3: ProyP3,
            ProyP3Cual: ProyP3Cual,
            ProyP4: ProyP4,
            ProyP5: ProyP5,
            AudP1: AudP1,
            AudP2: AudP2,
            AudP3GAC: AudP3GAC,
            AudP3Int: AudP3Int,
            AudP3Sup: AudP3Sup,
            AudP3Con: AudP3Con,
            AudP3Eje: AudP3Eje,
            AudP3Ent: AudP3Ent,
            AudP4GAC: AudP4GAC,
            AudP4Int: AudP4Int,
            AudP4Sup: AudP4Sup,
            AudP4Con: AudP4Con,
            AudP4Eje: AudP4Eje,
            AudP4Ent: AudP4Ent,
            AudP5: AudP5,
            AudP6: AudP6,
            GacP1: GacP1,
            GacP2: GacP2,
            GacP3: GacP3
        };

        ajaxPost('../../Views/Audiencias/ValoracionProyecto_ajax', params, null, function (r) {
            var codigo_error = r.split("<||>")[0];
            var mensaje = r.split("<||>")[1];
            if (r.indexOf("<||>") != -1) {
                if (codigo_error == '0') {
                    bootbox.alert("Registro guardado exitosamente");
                } else {
                    bootbox.alert(mensaje);
                }
            }
        }, function (r) {
            bootbox.alert(r.responseText);
        });
    }
});

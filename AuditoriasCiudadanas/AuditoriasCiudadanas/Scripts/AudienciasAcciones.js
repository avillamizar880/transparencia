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

//$(".form_datetime").datetimepicker({
//    language: "es",
//    weekStart: 1,
//    todayBtn: 1,
//    autoclose: 1,
//    todayHighlight: 1,
//    startView: 2,
//    forceParse: 0,
//    showMeridian: 1
//});

$("#btnDescargaFormato").bind('click', function () {
    genPdfPlantilla("../Views/Audiencias/DescargaFormato_ajax", "divPdfAsistencia", null);
});

$('#btnObsInformePrevio').bind('click', function () {
    var id_grupo = $("#hdIdGrupo").val();
    var cod_pin = $("#hfidproyecto").val();
    var id_usuario = $("#hdIdUsuario").val();
    var txtInfoFaltante = $("#txtInfoFaltante").val();
    var txtInfoClara = $("#txtInfoClara").val();
    var txtInfoCompleta = $("#txtInfoCompleta").val();
    var txtInfoClara = $("#txtInfoClara").val();
    var txtComunidad = $("#txtComunidad").val() ;
    var txtDudas = $("#txtDudas").val();
    var fecha_posterior_1 = $("#fecha_posterior_1").val();
    var fecha_posterior_2 = $("#fecha_posterior_2").val();
    //valida campos obligatorios
    var formularioOK = true;
    var camposReq = "";
    $(".alert-danger").hide();
    $('.required', $('#divDatosInforme')).each(function (i, e) {
        var id_txt = $(e).attr("for");
        if ($("#" + id_txt).val() == "" || $('#' + id_txt + ' option:selected').val() == "0") {
            camposReq += "[" + id_txt + "]";
            $("#error_" + id_txt).show();
            formularioOK = false;
        } else {
            $("#error_" + id_txt).hide();
        }
    });

    if (formularioOK == false) {
        if (camposReq != "") {
            bootbox.alert("Faltan campos obligatorios");
        }
    } else {
        //valida rango fechas
        if (!validafechaMayorQue(fecha_posterior_1, fecha_posterior_2)) {
            bootbox.alert("Fecha Aud. Cierre debe ser superior a Fecha Aud Seguimiento");
        } else {
              var params = {
            cod_bpin: cod_pin,
            id_usuario: id_usuario,
            info_faltante:txtInfoFaltante,
            info_clara: txtInfoClara,
            info_completa: txtInfoCompleta,
            comunidad_benef: txtComunidad,
            dudas: txtDudas,
            fecha_posterior_1: fecha_posterior_1,
            fecha_posterior_2: fecha_posterior_2,
            id_grupo:id_grupo
        };
            registrarObsAudiencia(params);
        }
    }

});

$('#btnAgregarCompromiso').bind('click', function () {
    var cantidad = $(".registro").length + 1;
    var divCompromisoNew = '<div class="row registro" id="divRegistro_' + cantidad + '"><div class="col-sm-11"><div class="row"><div class="col-sm-4"><div class="form-group">';
    divCompromisoNew += '<label for="compromiso_' + cantidad + '" class="required">Titulo del Compromiso</label>';
    divCompromisoNew += '<input type="text" class="form-control compromiso" id="compromiso_' + cantidad + '" placeholder="Titulo del compromiso">';
    divCompromisoNew += '</div></div><div class="col-sm-4"><div class="form-group">';
    divCompromisoNew += '<label for="responsable_' + cantidad +'" class="required">Responsables(s)</label>';
    divCompromisoNew += '<input type="text" class="form-control responsable" id="responsable_' + cantidad + '" placeholder="Responsables">';
    divCompromisoNew += '</div></div>';
    divCompromisoNew += '<div class="col-sm-4"><div class="form-group">';
    divCompromisoNew += '<label for="dtp_input_' + cantidad + '" class="control-label required">Fecha(s) de Cumplimiento</label>';
    divCompromisoNew += '<div class="input-group date form_date" data-date="" data-date-format="dd MM yyyy" data-link-field="dtp_input_' + cantidad + '" data-link-format="yyyy-mm-dd">';
    divCompromisoNew += '<input class="form-control" size="16" type="text" value="" readonly>';
    divCompromisoNew += '<span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>';
    divCompromisoNew += '<span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>';
    divCompromisoNew += '</div>';
    divCompromisoNew += '<input type="hidden" id="dtp_input_' + cantidad + '" value="" class="fecha" /><br />';
    divCompromisoNew += '</div>';
    divCompromisoNew += '</div>';
    divCompromisoNew += '</div></div>';
    divCompromisoNew += '<div class="col-sm-1"><a role="button" onclick="borrar_elem(\'divRegistro_' + cantidad + '\');" class="btn btn-default MT25" role="button"><span class="glyphicon glyphicon-trash"></span></a></div>';
    divCompromisoNew += '</div>';
    $("#divDetCompromisos").append(divCompromisoNew);
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

    $('.form_datetime').datetimepicker({
        language: 'es',
        weekStart: 1,
        todayBtn: 1,
        autoclose: 1,
        todayHighlight: 1,
        startView: 2,
        forceParse: 0,
        showMeridian: 1
    });
   
});

$('#btnAgregarTipoAsistente').bind('click', function () {
    var cantidad = $(".asistentes").length + 1;
    var divAsistentesNew = '<div class="asistencia row" id="divAsistencia_' +  cantidad + '">';
    divAsistentesNew +='<div class="col-sm-11">';
    divAsistentesNew += '<div class="row">';
    divAsistentesNew += '<div class="col-sm-4">';
    divAsistentesNew += '<div class="form-group">';
    divAsistentesNew += '<label for="ddlTipoAsistente" class="required">Tipo Asistente</label>';
    divAsistentesNew += '<select class="form-control tipo" id="ddlTipoAsistente_' + cantidad + '">';
    divAsistentesNew += '<option value="">[Seleccione un tipo de Asistente]</option>';
    divAsistentesNew += '<option value="1">Auditores Ciudadanos (GAC)</option>';
    divAsistentesNew += '<option value="2">Ejecutor el proyecto</option>';
    divAsistentesNew += '<option value="3">Personero Municipal</option>';
    divAsistentesNew += '<option value="4">Controlaría Municipal</option>';
    divAsistentesNew += '<option value="5">Organizaciones sociales</option>';
    divAsistentesNew += '<option value="6">Contratista</option>'; 
    divAsistentesNew += '<option value="7">Supervisor</option>';
    divAsistentesNew += '<option value="8">Interventor</option>';
    divAsistentesNew += '<option value="9">Beneficiarios</option>';
    divAsistentesNew += '<option value="10">otros</option>';
    divAsistentesNew += '</select></div></div>';
    divAsistentesNew += '<div class="col-sm-4">';
    divAsistentesNew += '<div class="form-group"><label for="compromiso_' + cantidad +'" class="required">Número Asistentes</label>';
    divAsistentesNew += '<input type="text" class="form-control cant" id="cantidad_' + cantidad + '" placeholder="Cantidad">';
    divAsistentesNew += '</div></div></div></div>';
    divAsistentesNew += '<div class="col-sm-1"><a role="button" onclick="borrar_elem(\'divAsistencia_' + cantidad + '\');" class="btn btn-default MT25" role="button"><span class="glyphicon glyphicon-trash"></span></a></div>';
    divAsistentesNew += '</div>';
    $("#divAsistente").append(divAsistentesNew);
    

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



$("#txtMunicipio").autocomplete({
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
                    response([{ label: "[No se encontraron resultados con el criterio seleccionado]", value: "" }]);
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
                //alert(response.responseText);
            },
            failure: function (response) {
                //alert(response.responseText);
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

    $(this).autocomplete("search", $(this).val());
});

$(".acProyecto").autocomplete({
    source: function (request, response) {
        $.ajax({
            url: '../../Views/Proyectos/listarProyectos',
            cache: false,
            dataType: "json",
            data: {
                texto: request.term
            },
            type: "POST",
            success: function (data) {
                if (data == null) {
                    response([{ label: "[No se encontraron resultados con el criterio seleccionado]", value: "" }]);
                } else {
                    response($.map(data.Head, function (item) {
                        return {
                            label: item.nom_proyecto,
                            value: item.id,
                        }
                    }));
                }
            },
            error: function (response) {
                //console.log(response);
            },
            failure: function (response) {
                //console.log(response);
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
    $(this).autocomplete("search", $(this).val());
});

$("#btnValoracionproyecto").click(function () {
    var codigoBPIN = $("#hfidproyecto").val();
    var idusuario = $("#hdIdUsuario").val();
    var ProyP1 = "";
    var ProyP2 = "";
    var ProyP3 = "";
    var ProyP3Op = "";
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
    var formularioOK = true;
    var msg_error = "";
    var camposReq = "";

    //oculta divs de errores
    $('.alert-danger', $("#div_Valoracion")).each(function (i, e) {
        $(e).hide();
    });

    if (codigoBPIN == "") {
        msg_error += "@Bpin proyecto,"
        bootbox.alert("Datos de enlace inválidos: " + msg_error);
        formularioOK = false;
    }
    else if (idusuario == "") {
        msg_error += "@Usuario no registrado"
        bootbox.alert("Datos de enlace inválidos: " + msg_error);
        formularioOK = false;
    }
    if (msg_error == "") {
        //valida obligatorios
            $('.requerido', $('#div_Valoracion')).each(function (i, e) {
            var id_grupo = $(e).attr("id");
            var nom_grupo = $(e).attr("nom_grupo");
            var cant_select = $('input[name=' + nom_grupo + ']:checked').length;
            if (cant_select == 0) {
                camposReq += "[" + nom_grupo + "]";
                formularioOK = false;
                $("#error_" + nom_grupo).show();
               
            } else {
                var modif_presupuesto=$('input[name=' + nom_grupo + ']:checked').attr("id");
                if (nom_grupo == "options3" && modif_presupuesto == "PP3_op1") {
                    var razones = $('input[name=' + 'options4' + ']:checked').length;
                    //si eligio si y no ha elegido porque razón
                    if (razones == 0) {
                        msg_error += "Debe seleccionar una de las razones para la modificación del presupuesto";
                        $("#error_options4").show();
                    }
                   
                }

                $("#error_" + id_grupo).hide();
            }
        });
    }

    if (formularioOK == false) {
        if (camposReq != "") {
            if (msg_error != "") {
                bootbox.alert(msg_error);
            } else {
                bootbox.alert("Faltan campos obligatorios");
            }

        } else {
            if (msg_error != "") {
                bootbox.alert(msg_error);
            }
        }

    } else {

        if ($("#PP1_op1").is(':checked')) { ProyP1 = "SI" }
        if ($("#PP1_op2").is(':checked')) { ProyP1 = "NO" }
        if ($("#PP2_op1").is(':checked')) { ProyP2 = "SI" }
        if ($("#PP2_op2").is(':checked')) { ProyP2 = "NO" }
        if ($("#PP3_op1").is(':checked')) { ProyP3 = "SI" }
        if ($("#PP3_op2").is(':checked')) { ProyP3 = "NO" }
        if ($("#PP3op_op1").is(':checked')) { ProyP3Op = "1" }
        if ($("#PP3op_op2").is(':checked')) { ProyP3Op = "2" }
        if ($("#PP3op_op3").is(':checked')) { ProyP3Op = "3" }
        if ($("#PP3op_op4").is(':checked')) {
            ProyP3Op = "4"
            Proyp3Cual = $("#PP3e_rop3").val();
            if (Proyp3Cual == "") {
                msg_error="Debe ingresar la razón por la cual se modificó el presupuesto";
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
                ProyP3Op: ProyP3Op,
                ProyP3Cual: Proyp3Cual,
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
                        volver_listado_gestion();
                    } else {
                        bootbox.alert(mensaje);
                    }
                }
            }, function (r) {
                bootbox.alert(r.responseText);
            });
        } else {
            bootbox.alert(msg_error);
        }
    }
});


$('#btnRegistrarFechaAud').bind('click', function () {
    var tipo_audiencia = $('#ddlTipoAudiencia option:selected').val();
    var cod_bpin = $("#hdIdProyecto").val();
    var id_municipio = $("#hdIdMunicipio").val();
    var direccion = $("#txtDireccion").val();
    var fecha = $("#dtp_fecha").val();
    var id_usuario = $("#hdIdUsuario").val();
    //valida campos obligatorios
    var formularioOK = true;
    var camposReq = "";
    $(".alert-danger").hide();
    $('.required', $('#divDatosAudiencia')).each(function (i, e) {
        var id_txt = $(e).attr("for");
        if ($("#" + id_txt).val() == "" || $('#' + id_txt + ' option:selected').val() == "0") {
            camposReq += "[" + id_txt + "]";
            $("#error_" + id_txt).show();
            formularioOK = false;
        } else {
            $("#error_" + id_txt).hide();
        }
    });
    if (formularioOK == false) {
        if (camposReq != "") {
            bootbox.alert("Faltan campos obligatorios");
        }
    } else {
        var params = { codigo_bpin: cod_bpin, tipo_audiencia: tipo_audiencia, id_municipio: id_municipio, direccion: direccion, fecha: fecha, id_usuario:id_usuario};
        insertarFechaAudiencia(params);
    }





});

$('#btnAgregarObsCompromiso').bind('click', function () {

    var k = $("#contadork").val();
    var compromisosobs = "<div class=\"row ObsCompromisos\">";
    compromisosobs += "<input type = \"hidden\"  class=\"form-control idCompromiso \" id=\"idcompromiso_input" + k + "\" value=\"\"/>";
    compromisosobs += "<div class=\"col-sm-4\">";
    compromisosobs += "<div class=\"form-group\">";
    compromisosobs += "<input type = \"text\" class=\"form-control Compromiso\" id=\"comprom_input" + k + "\" placeholder=\"Compromiso\" >";
    compromisosobs += "</div>";
    compromisosobs += "</div>";
    compromisosobs += "<div class=\"col-sm-4\">";
    compromisosobs += "<div class=\"form-group\">";
    compromisosobs += "<input type = \"text\" class=\"form-control ResponsableComp\" id=\"responcomp_input" + k + "\" placeholder=\"Responsable\" >";
    compromisosobs += "</div>";
    compromisosobs += "</div>";
    compromisosobs += "<div class=\"col-sm-4\">";
    compromisosobs += "<div class=\"form-group\">";
    compromisosobs += "<input type = \"text\" class=\"form-control ObsComprom\" id=\"obscomp_input" + k + "\" placeholder=\"Observaciones\" >";
    compromisosobs += "</div>";
    compromisosobs += "</div>";
    compromisosobs += "</div>";
    k++;
    $("#contadork").val(k);
    $("#divtablacompobs").append(compromisosobs);

});


$('#btnAgregarDudas').bind('click', function () {

    var d = $("#contadord").val();
    var dudas = "<div class=\"row ObsDudas\">";
    dudas += "<input type = \"hidden\" class=\"form-control idDuda\" id=\"idduda_input" + d + "\" value=\"\"/>";
    dudas += "<div class=\"col-sm-8\">";
    dudas += "<div class=\"form-group\">";
    dudas += "<input type = \"text\" class=\"form-control Duda\" id=\"duda_input" + d + "\" placeholder=\"Duda\" >";
    dudas += "</div>";
    dudas += "</div>";
    dudas += "<div class=\"col-sm-4\">";
    dudas += "<div class=\"form-group\">";
    dudas += "<input type = \"text\" class=\"form-control ResponsableD\" id=\"responduda_input" + d + "\" placeholder=\"Responsable\" >";
    dudas += "</div>";
    dudas += "</div>";
    dudas += "</div>";
    d++;
    $("#contadord").val(d);
    $("#divDudas").append(dudas);

});


$('#btnAgregarPreguntas').bind('click', function () {

    var d = $("#contadord").val();
    var dudas = "<div class=\"row ObsDudas\">";
    dudas += "<input type = \"hidden\" class=\"form-control idDuda\" id=\"idduda_input" + d + "\" value=\"\"/>";
    dudas += "<div class=\"col-sm-6\">";
    dudas += "<div class=\"form-group\">";
    dudas += "<input  type = \"textarea\" class=\"form-control Duda\" id=\"duda_input" + d + "\" placeholder=\"Sobre el Grupo Auditor Ciudadano\" >";
    dudas += "</div>";
    dudas += "</div>";
    dudas += "<div class=\"col-sm-6\">";
    dudas += "<div class=\"form-group\">";
    dudas += "<input type = \"textarea\" class=\"form-control ConclusionesD\" id=\"responduda_input" + d + "\" placeholder=\"Conclusiones\" >";
    dudas += "</div></div>";
    dudas += "</div>";
    d++;
    $("#contadord").val(d);
    $("#divDudas").append(dudas);

});

$("#btnGuardarInfProceso").bind('click', function () {
    ////valida info, crea xml
    var xml_txt = "";
    var xml_txt = "";
    var error = "";
    var guardar = "";
    var idInforme = $("#hdidinforme").val();
    var codigoBPIN = $("#hfidproyecto").val();
    var idUsuario = $("#hdIdUsuario").val();
    var idtipoaud = $("#hdIdidtipoaud").val();
    var idGac = $("#hdIdGAC").val();
    var idaud = $("#hdidaud").val();
    var valida_porcentaje = true;
    $("#error_obsTarea").hide();
    $("#error_obsTareaOblig").hide();
    var msg_error = "";

    xml_txt += "<informe><idInforme>" + idInforme + "</idInforme><idaud>" + idaud + "</idaud><idUsuario>" + idUsuario + "</idUsuario><codigoBPIN>" + codigoBPIN + "</codigoBPIN><idtipoaud>" + idtipoaud + "</idtipoaud><idGac>" + idGac + "</idGac>";
    $('.ObsTareas', $("#divPreguntas")).each(function (i, e) {
        var xml_temp = "";
        var bandera = 0;
        var valor_porcentaje="";
        xml_temp += "<tareas>";
        $('input', $(e)).each(function (ii, ee) {
            if ($(ee).attr("class").indexOf("idTarea") > -1) {
                xml_temp += "<idTarea>" + $(ee).val() + "</idTarea>";
            } else if ($(ee).attr("class").indexOf("PorcTarea") > -1) {
                valor_porcentaje=$(ee).val();
                if (valor_porcentaje!="") {
                    if (isNaN(valor_porcentaje) == false) {
                        var patron=/^\d+(\.\d{1,2})?$/;
                        if (!patron.test(valor_porcentaje)) {
                            valida_porcentaje = false;
                        }
                        else {
                            if ((parseFloat(valor_porcentaje) < 0) || (parseFloat(valor_porcentaje) >100)) {
                                valida_porcentaje = false;
                            }
                        }
                     } else {
                        valida_porcentaje = false;
                    }
                }
                xml_temp += "<PorcTarea>" + $(ee).val() + "</PorcTarea>";
            } else if ($(ee).attr("class").indexOf("obsTarea") > -1) {
                xml_temp += "<obsTarea>" + $(ee).val() + "</obsTarea>";
                if ($(ee).val() != "") {
                    bandera = 1;
                }
            };
        });
        xml_temp += "</tareas>";
        if (bandera == 1)
        {
            if (valor_porcentaje != "") {
                if (valida_porcentaje) {
                    xml_txt += xml_temp;
                    guardar = "si";
                } else {
                    error = "obsTarea";
                    $("#error_obsTarea").show();
                }
            } else {
                error = "obsTarea";
                $("#error_obsTareaOblig").show();
            }
            
            
        }
    });
    $('.ObsActividades', $("#divPreguntas")).each(function (i, e) {
        var xml_temp = "";
        var bandera = 0;
        xml_temp += "<actividades>";
        $('input', $(e)).each(function (ii, ee) {
            if ($(ee).attr("class").indexOf("idActividad") > -1) {
                xml_temp += "<idActividad>" + $(ee).val() + "</idActividad>";
            } else if ($(ee).attr("class").indexOf("obsActividad") > -1) {
                xml_temp += "<obsActividad>" + $(ee).val() + "</obsActividad>";
                if ($(ee).val() != "")
                {
                    bandera = 1;
                }
            };
        });
        xml_temp += "</actividades>";
        if (bandera == 1)
        {
            xml_txt += xml_temp;
            guardar = "si";
        }
    });
    $('.ObsCompromisos', $("#divPreguntas")).each(function (i, e) {
        var xml_temp = "";
        var bandera = 0;
        var comp = 0;
        xml_temp += "<compromisos>";
        $('input', $(e)).each(function (ii, ee) {
            if ($(ee).attr("class").indexOf("idCompromiso") > -1) {
                xml_temp += "<idCompromiso>" + $(ee).val() + "</idCompromiso>";
            } else if ($(ee).attr("class").indexOf("Compromiso") > -1) {
                xml_temp += "<Compromiso>" + $(ee).val() + "</Compromiso>";
                if ($(ee).val() != "") {
                    comp = 1;
                }
            } else if ($(ee).attr("class").indexOf("ResponsableComp") > -1) {
                xml_temp += "<ResponsableComp>" + $(ee).val() + "</ResponsableComp>";
                if ($(ee).val() != "") {
                    comp = 1;
                }
            } else if ($(ee).attr("class").indexOf("ObsComprom") > -1) {
                xml_temp += "<ObsComprom>" + $(ee).val() + "</ObsComprom>";
                if ($(ee).val() != "") {
                    bandera = 1;
                } else if (comp == 1) {
                    msg_error="No se puede guardar una observación de compromiso vacía";
                    error = "obscompromiso";
                    return;
                }
            };
        });
        xml_temp += "</compromisos>";
        if (bandera == 1) {
            if (comp == 1) {
                xml_txt += xml_temp;
                guardar = "si";
            } else {
                msg_error="No se puede guardar una línea de compromiso vacía";
                error = "obscompromiso";
                return;
            }
        }

    });

    if (idtipoaud==1)
    {
        $('.ObsDudas', $("#divPreguntas")).each(function (i, e) {
            var xml_temp = "";
            var bandera = 0;
            var duda = 0;
            xml_temp += "<dudas>";
            $('input', $(e)).each(function (ii, ee) {
                if ($(ee).attr("class").indexOf("idDuda") > -1) {
                    xml_temp += "<idDuda>" + $(ee).val() + "</idDuda>";
                } else if ($(ee).attr("class").indexOf("Duda") > -1) {
                    xml_temp += "<Duda>" + $(ee).val() + "</Duda>";
                    if ($(ee).val() != "") {
                        bandera = 1;
                    }
                } else if ($(ee).attr("class").indexOf("ResponsableD") > -1) {
                    xml_temp += "<ResponsableDuda>" + $(ee).val() + "</ResponsableDuda>";
                    if ($(ee).val() != "") {
                        duda = 1;
                    }
                } ;
            });
            xml_temp += "</dudas>";
            if (bandera == 1)
            {
                xml_txt += xml_temp;
                guardar = "si";
            } else if (duda == 1) {
                error = "ObsDuda";
                msg_error="No se puede guardar una línea de duda vacía";
                return;
            }

        });
    }
    else
    {
        $('.ObsDudas', $("#divPreguntas")).each(function (i, e) {
            var xml_temp = "";
            var bandera = 0;
            var duda = 0;
            xml_temp += "<dudas>";
            $('input', $(e)).each(function (ii, ee) {
                if ($(ee).attr("class").indexOf("idDuda") > -1) {
                    xml_temp += "<idDuda>" + $(ee).val() + "</idDuda>";
                } else if ($(ee).attr("class").indexOf("Duda") > -1) {
                    xml_temp += "<Duda>" + $(ee).val() + "</Duda>";
                    if ($(ee).val() != "") {
                        bandera = 1;
                    }
                } else if ($(ee).attr("class").indexOf("ConclusionesD") > -1) {
                    xml_temp += "<Conclusiones>" + $(ee).val() + "</Conclusiones>";
                    if ($(ee).val() != "") {
                        duda = 1;
                    }
                };
            });
            xml_temp += "</dudas>";
            if (bandera == 1) {
                xml_txt += xml_temp;
                guardar = "si";
            } else if (duda == 1) {
                error = "ObsDuda";
                msg_error="No se puede guardar una línea de preguntas vacía";
                return;
            }

        });
}
    xml_txt += "</informe>";
    if (error == "") {
        if (guardar == "si") {
            //alert(xml_txt);
            registrarInformeProc(xml_txt);
        }
        else {
            bootbox.alert("No se puede crear un registro de informe vacío");
        }
    } else {
        if (msg_error != "") {
            bootbox.alert("Revise las inconsistencias en registro de informe: " + msg_error);
        } else {
            bootbox.alert("Revise las inconsistencias en registro de informe");
        }
       

    }
});


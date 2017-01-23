$(".volver_listado").click(function () {
    var bpinProyecto = $("#hfidproyecto").val();
    var id_usuario = $("#hdIdUsuario").val();
    obtGACProyecto(bpinProyecto, id_usuario);
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
                bootbox.alert(response.responseText);
            },
            failure: function (response) {
                bootbox.alert(response.responseText);
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
});

$("#btnUnirseGAC").click(function () {
    var bpinProyecto = $("#hfidproyecto").val();
    var id_usuario = $("#hdIdUsuario").val();
    var idGrupo = "";   //grupo seleccionado
    //mensaje confirmacion
    if (id_usuario == "") {
        bootbox.alert({
            message: "Para crear un GAC, debe estar registrado en el sistema!",
            buttons: {
                ok: {
                    label: 'Registrarse'
                }
            },
            callback: function () {
                goObtMenu('/Views/Usuarios/registroCiudadano');
            }
        });
    } else {
        //revisar cuantos gac tiene el proyecto
        var params = { id_proyecto: bpinProyecto, id_usuario: id_usuario, opcion: "CANT" };
        ajaxPost('../Views/Proyectos/detalleGACProyecto_ajax', params, null, function (r) {
            var cantGrupos = r;
            var mensaje_usuario = "";
            if (cantGrupos == "0") {
                mensaje_usuario="¿Está seguro que desea crear un Grupo Auditor Ciudadano?"
            } else {
                mensaje_usuario = "<div class=\"well\" id=\"divPregRadio\"><div class=\"row\"><h4>¿Por qué desea crear otro Grupo Auditor Ciudadano?</h4></div><div class=\"form-group row\"><div class=\"col-sm-12\"><input name=\"options_motivo\" id=\"q_0\" value=\"A\" class=\"form-check-input\" type=\"radio\"><span>A. No conoce a quienes integran el que actualmente está creado</span></div></div><div class=\"form-group row\"><div class=\"col-sm-12\"><input name=\"options_motivo\" id=\"q_1\" value=\"B\" class=\"form-check-input\" type=\"radio\"><span>B. Usted hace parte de una organización y quieren consolidarse como GAC para realizar control social.</span></div></div><div class=\"form-group row\"><div class=\"col-sm-12\"><input name=\"options_motivo\" id=\"q_2\" value=\"C\" class=\"form-check-input\" type=\"radio\"><span>C. Otra ¿Cuál?</span></div></div><div class=\"form-group row\"><div class=\"col-sm-12\"><textarea rows=\"2\" id=\"txt_otro\" class=\"form-control\" placeholder=\"Escriba cual\"></textarea></div></div> <div id=\"error_divMotivo\" class=\"alert alert-danger alert-dismissible\" hidden=\"hidden\">Debe seleccionar un motivo</div></div>";
            }
            bootbox.confirm({
                title: "CREAR GAC",
                message: mensaje_usuario,
                buttons: {
                    confirm: {
                        label: 'Crear'
                    },
                    cancel: {
                        label: 'Cancelar'
                    }
                },
                callback: function (result) {
                    if (result == true) {
                    var formularioOk = true;
                    if (cantGrupos != "0") {
                        var optText = $('input[name=options_motivo]:checked').val();
                        var motivo = "";
                        if (optText == undefined || optText == "") {
                            $("#error_divMotivo").html("Debe seleccionar un motivo");
                            $("#error_divMotivo").show();
                            return false;
                        } else {
                            if (optText == "A") {
                                motivo = "No conoce a quienes integran el que actualmente está creado";
                            } else if (optText == "B") {
                                motivo = "Usted hace parte de una organización y quieren consolidarse como GAC para realizar control social";
                            } else if (optText == "C") {
                                motivo = $.trim($("#txt_otro").val());
                                if (motivo == "") {
                                    formularioOk = false;
                                    $("#error_divMotivo").html("Debe justificar su motivo");
                                    $("#error_divMotivo").show();
                                    return false;
                                }
                            }
                        }

                    }
                    if (formularioOk == true) {
                        if ($("#error_divMotivo").length > 0) {
                            $("#error_divMotivo").hide();
                        }
                               
                                ajaxPost('../Views/Usuarios/addGrupoAuditor_ajax', { bpin_proyecto: bpinProyecto, id_usuario: id_usuario, id_grupo: idGrupo, motivo: motivo }, null, function (r) {
                                    if (r.indexOf("<||>") != -1) {
                                        var cod_error = r.split("<||>")[0];
                                        var mensaje_error = r.split("<||>")[1];
                                        if (cod_error == '0') {
                                            //accion exitosa
                                            bootbox.alert("Grupo creado exitosamente", function () {
                                                //recargar grupos
                                                obtGACProyecto(bpinProyecto, id_usuario);
                                            });
                                        } else {
                                            bootbox.alert(mensaje_error);
                                        }
                                    }

                                }, function (e) {
                                    bootbox.alert(e.responseText);
                                });
                            }

                    }
                }
            });
           
        }, function (e) {
            bootbox.alert(e.responseText);
        });

    }



});

$("#btnSeguirProy").click(function () {
    seguirProyecto();
});

$("#btnAgregarDescInfoTecnica").click(function () {
    var formulario_ok = "1";
    var titulo = $("#txtTituloInfoTecnica").val();
    var texto = $("#txtDescInfoTecnica").val();
    var bpinProyecto = $("#hfidproyecto").val();
    var id_usuario = $("#hdIdUsuario").val();
    if (texto == "") {
        $("#error_txtDescInfoTecncia").show();
        formulario_ok = "0";
    }
    if (titulo == "") {
        formulario_ok = "0";
        $("#error_txtDescInfoTecnica").show();
    }
    if (formulario_ok=="1") {
        $("#error_txtDescInfoTecncia").hide();
        $("#error_txtDescInfoTecnica").hide();
        var params = { titulo: titulo, texto: texto, bpin_proyecto: bpinProyecto, id_usuario: id_usuario };
        addDescripcionTecnicaProy(params);
    } else {
        bootbox.alert("Revise campos obligatorios sin valor", function () {
        });
        
    }
 
});

//$("#btnGuardarNewInfoTecnica").click(function () {
//    var titulo = $("#txtNewTituloTecnica").val();
//    var texto = $("#txtNewDescTecnica").val();
//    $("#btnGuardarNewInfoTecnica").click(function () {
//        $("#btnNewImagenTecnica").fileinput("upload");
//    });

//});

$("#btnVolverListadoCalidad").click(function () {
    //accion volver a listado de publicaciones inf tecnica
});


$("#btnEditarContenidoCalidad").click(function () {
    //accion editar inf tecnica
});
$(".volver_listado").click(function () {
    var bpinProyecto = $("#hfidproyecto").val();
    var id_usuario = $("#hdIdUsuario").val();
    obtGACProyecto(bpinProyecto, id_usuario);
});

$('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
    var enlace = $(e.target).attr('id');
    var cantidad_grupos = $("#hdCantGrupos").val();
    var auditor_proy = $("#hdAuditorProy").val();
    var elem_activo = $('.nav-tabs .active').attr("id");
    if (enlace != undefined) {
        if (enlace == "enlaceGrupos") {
            //carga grupos auditores
            if (cantidad_grupos != "" && cantidad_grupos != "0" && cantidad_grupos != undefined) {
                if (auditor_proy != "1") {
                    $("#divTextoGrupos").show();
                } else {
                    $("#divTextoGrupos").hide();
                }
                
            } else {
                $("#divTextoGrupos").hide();
            }
            $("#divInformativo").hide();
            $("#divCrearGAC").show();
            var perfil = $("#hdperfil").val();
            var rol = $("#hdrol").val();
            if ((perfil != "2")||(rol==='3')) {
                $("#divTextoGrupos").hide();
                $("#divCrearGAC").hide();
            }
        } else {
            $("#divTextoGrupos").hide();
            $("#divInformativo").show();
            $("#divCrearGAC").hide();
        }
    }
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
    var mensaje = "";
    var usuario_login = $.cookie("id_usuario");
    //mensaje confirmacion
    if (id_usuario == "" || id_usuario == undefined) {
        if (usuario_login != "" && usuario_login != undefined) {
            mensaje = "Su sesión ha expirado. Ingrese nuevamente al aplicativo";
        } else {
            mensaje = "Para crear un GAC, debe iniciar sesión previamente";
        }
        bootbox.confirm({
            title: "CREAR GAC",
            message: mensaje,
            buttons: {
                confirm: {
                    label: 'Iniciar Sesión'
                },
                cancel: {
                    label: 'Cancelar'
                }
            },
            callback: function (result) {
                if (result == true) {
                    //goObtMenu('/Views/Usuarios/registroCiudadano');
                    $("#collapseLogin").collapse('show');
                }
            }
        });

    } else {
        //revisar cuantos gac tiene el proyecto
        var params = { id_proyecto: bpinProyecto, id_usuario: id_usuario, opcion: "CANT" };
        ajaxPost('../Views/Proyectos/detalleGACProyecto_ajax', params, null, function (r) {
            var cantGrupos = r;
            var mensaje_usuario = "";
            if (cantGrupos == "0") {
                mensaje_usuario = "¿Está seguro que desea crear un Grupo Auditor Ciudadano?"
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
                            confirmaCrearGac(false);
                        }
                    }
                    //, function() {

                    //}
                });
            } else {
                     
                $("#btnOpenModalCrearGac").trigger("click");
            }

           
        }, function (e) {
            bootbox.alert(e.responseText);
        });

    }



});

$("#btnSeguirProy").click(function () {
    var bpinProyecto = $("#hfidproyecto").val();
    seguirProyecto(bpinProyecto);
});

$("#btnAgregarDescInfoTecnica").click(function () {
    var formulario_ok = true;
    var titulo = $("#txtTituloInfoTecnica").val();
    var texto = $("#txtDescInfoTecnica").val();
    var bpinProyecto = $("#hfidproyecto").val();
    var id_usuario = $("#hdIdUsuario").val();
    //valida campos obligatorios
    var formularioOK = true;
    var camposReq = "";
    $(".alert-danger").hide();
    $('.required', $('#NewInformacionCalidad')).each(function (i, e) {
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
        var params = { titulo: titulo, texto: texto, bpin_proyecto: bpinProyecto, id_usuario: id_usuario };
        addDescripcionTecnicaProy(params);
    }
 
});




$("#btnVolverListadoCalidad").click(function () {
    //accion volver a listado de publicaciones inf tecnica
    $('#divDetalleFormCalidad').slideUp(function () {
        $('#divItemsCalidad').slideDown();
    });
});


$("#btnEditarContenidoCalidad").click(function () {
    //accion editar inf tecnica
    var id_info = $("#hd_infoTecnica").val();
        $('#divDetalleFormCalidad').slideUp('slow',function () {
        $("#divItemsCalidad").slideDown('slow', function () {
                $("#btnGuardarNewInfoTecnica").hide();
                $("#btnEditarNewInfoTecnica").show();
                $("#btnNuevoInforme").hide();
                $("#divInfoTecnicaDet").hide();
                $("#divInformacionCalidad").hide();
                $("#divInfoDescCalidad").hide();
                $("#btnNuevoInforme").trigger("click");
                ver_infoTecnicaEdit(id_info);
            });
    });
});

$('#btnNuevoInforme').bind('click', function () {
    asignar_valores_info("","", "", "", "new");
});
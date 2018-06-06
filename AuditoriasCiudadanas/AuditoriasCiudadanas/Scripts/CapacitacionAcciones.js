$('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
    var target = $(e.target).attr("href") // activated tab
    if (target == "#tab2") {
        //enlaces de interes
        var params = {
            pagina: "1",
            tipo: "3"
        };
        listar_enlaces_interes(params);
    } else if (target == "#tab1") {
        //guias y manuales
        var params = {
            pagina: "1",
            tipo: "1,2"
        };
        listar_enlaces_interes(params);

    } else if (target == "#tab3") {
        //videos institucionales
        var params = {
            pagina: "1",
            tipo: "4"
        };
        listar_enlaces_interes(params);

    }
});

$("#btnCrearEnlace").bind("click", function () {
    var enlace_url = $("#txtEnlace").val();
    var id_recurso = $("#hdIdRecurso").val();
    //validar campos obligatorios
    var formularioOK = true;
    var camposReq = "";
    $(".alert-danger").hide();
    $('.required', $('#divInfoEnlace')).each(function (i, e) {
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
        if (isUrl(enlace_url)) {
            if (id_recurso != "") {
                var params = {
                    tipo_recurso: "3",
                    opc: "MOD",
                    id_usuario: $("#hdIdUsuario").val(),
                    titulo: $("#txtTitulo").val(),
                    desc: $("#txtDescripcion").val(),
                    enlace_url: $("#txtEnlace").val(),
                    id_recurso:id_recurso
                };
                modif_enlace_interes(params);

            } else {
                var params = {
                        tipo_recurso: "3",
                        opc:"ADD",
                        id_usuario: $("#hdIdUsuario").val(),
                        titulo: $("#txtTitulo").val(),
                        desc: $("#txtDescripcion").val(),
                        enlace_url: $("#txtEnlace").val()
                    };
                    crear_enlace_interes(params);

            }

            } else {
                bootbox.alert("Formato de enlace incorrecto");

            }
    }
});

$("#btnCrearVideoIns").bind("click", function () {
    var enlace_url = $("#txtEnlace").val();
    var id_recurso = $("#hdIdRecurso").val();
    //validar campos obligatorios
    var formularioOK = true;
    var camposReq = "";
    $(".alert-danger").hide();
    $('.required', $('#divInfoEnlace')).each(function (i, e) {
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
        if (isUrl(enlace_url)) {
            if (id_recurso != "") {
                var params = {
                    tipo_recurso: "4",
                    opc: "MOD",
                    id_usuario: $("#hdIdUsuario").val(),
                    titulo: $("#txtTitulo").val(),
                    desc: $("#txtDescripcion").val(),
                    enlace_url: $("#txtEnlace").val(),
                    id_recurso: id_recurso
                };
                modif_videos_instructivos(params);

            } else {
                var params = {
                    tipo_recurso: "4",
                    opc: "ADD",
                    id_usuario: $("#hdIdUsuario").val(),
                    titulo: $("#txtTitulo").val(),
                    desc: $("#txtDescripcion").val(),
                    enlace_url: $("#txtEnlace").val()
                };
                crear_videos_institucionales(params);

            }
           
        } else {
            bootbox.alert("Formato de enlace incorrecto");

        }
    }
});

$("#btnNewEnlace").bind("click", function () {
    inicializarDatos("divInfoEnlace", function () {
        $("#hdIdRecurso").val("");
        cargaPlantillasAdmin("divContEnlaces", "divInfoEnlace");
    });

});

$("#btnNewVideoIns").bind("click", function () {
    inicializarDatos("divInfoEnlace", function () {
        $("#hdIdRecurso").val("");
        cargaPlantillasAdmin("divContVideos", "divInfoEnlace");
    });

});

// AND

$("#btnCrearTemaCapacitacion").bind("click", function () {
    //validar campos obligatorios
    var formularioOK = true;
    var camposReq = "";
    $(".alert-danger").hide();
    $('.required', $('#divInfoEnlace')).each(function (i, e) {
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
            var params = {
                opc: "ADD",
                id_usuario: $("#hdIdUsuario").val(),
                titulo: $("#txtTitulo").val(),
                desc: $("#txtDescripcion").val(),
            };
            crear_temacapacitacion(params);
        
    }
});

$("#btnCrearRecursoCapacitacion").bind("click", function () {
    //validar campos obligatorios
    var formularioOK = true;
    var camposReq = "";
    var modulo = $("#txtModulo").val();
    var tipo = $("#txtTipoRCap").val();

    $(".alert-danger").hide();
    $('.required', $('#crearRCap')).each(function (i, e) {
        var id_txt = $(e).attr("for");
        if ($("#" + id_txt).val() == "" || $('#' + id_txt + ' option:selected').val() == "") {
            camposReq += "[" + id_txt + "]";
            $("#error_" + id_txt).show();
            formularioOK = false;
        } else {
            $("#error_" + id_txt).hide();
        }
        if (modulo == parseInt(modulo)) { formularioOK = true; } else { formularioOK = false; }
        if (tipo == parseInt(tipo)) { formularioOK = true; } else { formularioOK = false; camposReq += "[" + txtTipoRCap + "]"; }
    });

    if (formularioOK == false) {
        if (camposReq != "") {
            bootbox.alert("Faltan campos obligatorios");
        }else{bootbox.alert("El campo módulo debe ser un número entero.")}
    } else {
        var tipo = $("#txtTipoRCap").val();
        if (tipo === "2")
        { 
            var rutaImagen = $("#btnNewAdjuntoRecurso").val().split("\\");
            if (rutaImagen == "") {
                bootbox.alert("Debe adjuntar un archivo .pdf");

            } else {

                $("#btnNewAdjuntoRecurso").fileinput("upload");
            }
        }
        else
        {
            var url = $("#txtURLRCap").val();
            if (url === "") {
                bootbox.alert("Faltan campos obligatorios");
            }else
            {
            var params = {
                opc: "ADD",
                id_usuario: $("#hdIdUsuario").val(),
                titulo: $("#txtTituloRCap").val(),
                modulo: $("#txtModulo").val(),
                tipo: $("#txtTipoRCap").val(),
                url: $("#txtURLRCap").val(),
                id_cap: $("#hdIdCap").val(),
            };
            crear_recursocapacitacion(params);
            }
        }
    }
});



$("#btnAñadirTCap").bind("click", function () {
    $("#datosTCap").hide();
    $("#crearTCap").show();
    $("#crearTCap").slideDown(function () {

    });
});


$("#btnAñadirRCap").bind("click", function () {
    $("#datosRCap").hide();
    $("#crearRCap").show();
    $("#crearRCap").slideDown(function () {

    });
});


$("#btnVolverTCap").bind("click", function () {
    volverTemasCap();
});


$("#btnVolverRCap").bind("click", function () {
    volverRecursosCap();
});


$("#btnEditarTemaCapacitacion").bind("click", function () {
    //validar campos obligatorios
    var formularioOK = true;
    var camposReq = "";
    $(".alert-danger").hide();
    $('.required', $('#divInfoEnlace')).each(function (i, e) {
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
        var params = {
            opc: "MOD",
            id_usuario: $("#hdIdUsuario").val(),
            id_cap: $("#hdIdCap").val(),
            titulo: $("#txtTitulo").val(),
            desc: $("#txtDescripcion").val(),
        };
        editar_temacapacitacion(params);

    }
});


$("#txtTipoRCap").bind("change", function () {
    var tipo = $("#txtTipoRCap").val();
    if ((tipo === "3") || (tipo === "5")) {
        $("#divUrl").show();
        $("#divPanel").hide();
    } else if ((tipo === "2")) {
        $("#divUrl").hide();
        $("#divPanel").show();
    }
    else
    {
        $("#divUrl").hide();
        $("#divPanel").hide();
    }

});
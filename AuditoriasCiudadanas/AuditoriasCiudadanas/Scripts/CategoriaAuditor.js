function CargarTiposAuditor() {
    $.ajax({
        type: "POST",
        url: '../../Views/Administracion/CategoriasAuditor_ajax', data: { CategoriasAuditor: "CategoriasAuditor" },
        traditional: true,
        cache: false,
        dataType: "json",
        beforeSend: function () {
            waitblockUIParam('Cargando datos tipos de auditor...');
        },
        success: function (result) {
            var datasource = '';
            if (result != null && result != "") {
                for (var i = 0; i < result.Head.length; i++) {
                    datasource = datasource +
                             '<div class="list-group-item">' +
                             '<div id="IdTipoAuditor" class="col-sm-1" hidden="hidden"><span><h3>' + result.Head[i].idTipoAuditor + '</h3></span></div>' +
                             '<div class="col-sm-3"><img id="rutaImagen" src="../../Images/CatAuditor/' + result.Head[i].imagen + '" width="40">' + '</img></div>' +
                             '<div class="col-sm-2"><p class="list-group-item-text"><a href="#">' + result.Head[i].nombre + '</a></p></div>' +
                             '<div id="limites" class="col-sm-2"><span><h4>' + result.Head[i].limiteInferior + '-' + result.Head[i].limiteSuperior + '</h4></span></div>' +
                             '<div class="col-sm-2">' + result.Head[i].descripcion + '</div>' +
                             '<div class="col-sm-2 opcionesList">' +
                             '<a href="#" onclick="EditarCategoriaAuditor(' + result.Head[i].idTipoAuditor + ',' + "'" + result.Head[i].nombre + "'" + ',' + result.Head[i].limiteInferior + ',' + result.Head[i].limiteSuperior + ',' + "'" + result.Head[i].descripcion + "'"
                             + ',' + "'" + result.Head[i].imagen + "'" + ')"><span class="glyphicon glyphicon-edit"></span><span>Editar</span></a>' +
                             '<a href="#" onclick="EliminarCategoriaAuditor(' + result.Head[i].idTipoAuditor + ',' +
                              "'" + result.Head[i].nombre + "'" + ')"><span class="glyphicon glyphicon-trash"></span><span>Borrar</span></a>' +
                             '</div>' +
                             '</div>';
                }
            }
            $("#datos").html(datasource);
            unblockUI();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("error");
            alert(textStatus + ": " + XMLHttpRequest.responseText);
            unblockUI();
        }

    });
}
function EditarCategoriaAuditor(idTipoAuditor, nombreCategoria, limiteInferior, limiteSuperior, descripcion, rutaImagen) {
    OcultarValidadores();
    if (rutaImagen != "") rutaImagen = "../../Images/CatAuditor/" + rutaImagen;
    AsignarValores(idTipoAuditor, nombreCategoria, limiteInferior, limiteSuperior, descripcion, rutaImagen, false);
    $("#myModalLabel").html("Editar Categoría Auditor");
    $("#ingresarActualizarRegistro").modal();
}
function OcultarValidadores() {
    $("#errorNombre").hide();
    $("#errorImagen").hide();
    $("#errorLimiteInferior").hide();
    $("#errorLimiteSuperior").hide();
    $("#errorDescripcion").hide();
}
function AsignarValores(idTipoAuditor, nombreCategoria, limiteInferior, limiteSuperior, descripcion, rutaImagen, esNuevo) {
    $("#ingresarActualizarRegistro").html
                                            (
                                                '<div class="modal-dialog" role="document">' +
                                                '<div class="modal-content">' +
                                                '<div class="modal-header">' +
                                                '<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>' +
                                                '<h4 class="modal-title" id="myModalLabel">Agregar Imagen</h4>' +
                                                '</div>' +
                                                '<div class="modal-body">' +
                                                '<label class="modal-title" hidden="hidden" id="idTipoAuditor">0</label><br />' +
                                                '<label class="modal-title">Agregar Imagen</label><br/>' +
                                                '<input id="imagenTipoAuditor" class="file-loading" type="file">' +
                                                '<div id="errorImagen" class="alert alert-danger alert-dismissible" hidden="hidden" >El nombre de la imagen no puede ser vacío.</div>' +
                                                '<br/>' +
                                                '<label class="modal-title">Categoría Auditor</label><br/>' +
                                                '<input id="txtNombre" type="text" placeholder="Ingrese el nombre de la categoría...." size="50" />' +
                                                 '<br/>' +
                                                 '<div id="errorNombre" class="alert alert-danger alert-dismissible" hidden="hidden" >El nombre de la categoría no puede ser vacío.</div>' +
                                                 '<br/>' +
                                                 '<label class="modal-title">Límite inferior</label> <input id="txtLimiteInferior" type="number" value="0"/>' +
                                                 '<br />' +
                                                 '<div id="errorLimiteInferior" class="alert alert-danger alert-dismissible" hidden="hidden" >El límite inferior debe ser mayor a los existentes en las otras categorías.</div>' +
                                                 '<br/>' +
                                                 '<label class="modal-title">Límite superior</label> <input id="txtLimiteSuperior" type="number" value="1"/>' +
                                                 '<br/>' +
                                                 '<div id="errorLimiteSuperior" class="alert alert-danger alert-dismissible" hidden="hidden" >El límite superior no puede ser menor al límite inferior.</div>' +
                                                 '<br/>' +
                                                 '<label class="modal-title">Descripción</label><br />' +
                                                 '<input id="txtDescripcion" type="text" placeholder="Ingrese la descripción de la categoría...." size="50"/>' +
                                                 '<br/>' +
                                                 '<div id="errorDescripcion" class="alert alert-danger alert-dismissible" hidden="hidden" >El caracter * no está permitido. Por favor elimine este caracter de la casilla descripción.</div>' +
                                                 '</div>' +
                                                 '<div class="modal-footer">' +
                                                 '<button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>' +
                                                 '<button type="button" class="btn btn-primary" onclick=" GuardarRegistro()">Guardar</button>' +
                                                 '</div>' +
                                                 '</div>' +
                                                 ' </div>'
                                            );
    if (esNuevo == true) {
        $("#imagenTipoAuditor").fileinput({
            uploadAsync: false,
            minFileCount: 1,
            maxFileCount: 1,
            showUpload: false,
            showPreview: true,
            showRemove: false, // hide remove button
            initialPreviewAsData: false // identify if you are sending preview data only and not the markup
        });
    }
    else {
        $("#txtNombre").val(nombreCategoria);
        $("#txtLimiteInferior").val(limiteInferior);
        $("#txtLimiteSuperior").val(limiteSuperior);
        $("#txtDescripcion").val(descripcion);
        $("#idTipoAuditor").val(idTipoAuditor);
        $("#imagenTipoAuditor").fileinput({
            uploadUrl: "../../Images/CatAuditor/", // server upload action
            uploadAsync: true,
            minFileCount: 1,
            maxFileCount: 5,
            overwriteInitial: true,
            browseLabel: "Cargar Imagen",
            mainClass: "input-group-lg",
            initialPreview: [rutaImagen],
            initialPreviewAsData: true, // identify if you are sending preview data only and not the raw markup
            initialPreviewFileType: 'image', // image is the default and can be overridden in config below
            uploadExtraData: {
                img_key: "1000",
                img_keywords: "happy, places",
            }
        });
    }
}
function EliminarCategoriaAuditor(idTipoAuditor, nombreCategoria) {
    if (confirm("Desea eliminar la categoría" + nombreCategoria)) {
        $.ajax({
            type: "POST", url: '../../Views/Administracion/CategoriasAuditor_ajax', data: { Eliminar: idTipoAuditor }, traditional: true,
            beforeSend: function () {
                waitblockUIParam('Eliminando datos...');
            },
            success: function (result) {
                if (result == 'True') {
                    CargarDatos();
                }
                unblockUI();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("error");
                alert(textStatus + ": " + XMLHttpRequest.responseText);
            }
        });
    }
}
function GuardarRegistro() {
    OcultarValidadores();
    var dataSource = $("#datos").html();
    var rutaImagen = $("#imagenTipoAuditor").val().split("\\");
    var limiteinferior = $("#txtLimiteInferior").val();
    var limitesuperior = $("#txtLimiteSuperior").val();
    //Revisar la función ajax para el envío de los datos.
    var descrip = $("#txtDescripcion").val();
    var nombre = $("#txtNombre").val();
    var idTipoAuditor = $("#idTipoAuditor").val();
    var idUsuario = 1;
    if (idTipoAuditor == '') idTipoAuditor = 0;
    var guardarRegistro = ValidarFormato(nombre, rutaImagen, limiteinferior, limitesuperior, idTipoAuditor, descrip);
    if (guardarRegistro == true) {
        $.ajax({
            type: "POST", url: '../../Views/Administracion/CategoriasAuditor_ajax', data: { Guardar: idTipoAuditor + '*' + nombre + '*' + descrip + '*' + idUsuario + '_' + rutaImagen[rutaImagen.length - 1] + '*' + limiteinferior + '*' + limitesuperior }, traditional: true,
            beforeSend: function () {
                waitblockUIParam('Guardando datos...');
            },
            success: function (result) {
                if (result == '<||>') {
                    //SubirImagen();
                    CargarDatos();
                    $("#ingresarActualizarRegistro").hidden = "hidden";
                    $("#ingresarActualizarRegistro").modal('toggle');
                }
                unblockUI();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("error");
                alert(textStatus + ": " + XMLHttpRequest.responseText);
            }
        });
    }

}
function ValidarFormato(nombre, rutaImagen, limiteinferior, limitesuperior, idTipoAuditor, descripcion) {
    var listaId = new Array();
    var listaIntervalos = new Array();
    var indiceRegistro = -1;
    var pruebaId = $("#datos div span h3").each(function (index) {
        var idCategoria = $(this).html();
        listaId[listaId.length] = idCategoria;
    });
    var pruebaFrec = $("#datos div span h4").each(function (index) {
        var filaPuntuacion = $(this).html();
        listaIntervalos[listaIntervalos.length] = filaPuntuacion;
    });
    if (idTipoAuditor != 0) {
        for (var i = 0; i < listaId.length; i++) {
            if (listaId[i] == idTipoAuditor) {
                indiceRegistro = i;
                i = listaId.length;
            }
        }
    }
    if (nombre == '') {
        $("#errorNombre").html('El nombre de la categoría no puede ser vacío.');
        $("#errorNombre").show();
        return false;
    }
    var nombreAsterisco = nombre.split('*');
    if (nombreAsterisco.length > 1) {
        $("#errorNombre").html('El caracter * no está permitido. Por favor elimine este caracter de la casilla nombre categoría.');
        $("#errorNombre").show();
        return false;
    }
    var descripcionAsterisco = descripcion.split('*');
    if (descripcionAsterisco.length > 1) {
        $("#errorDescripcion").html('El caracter * no está permitido. Por favor elimine este caracter de la casilla descripción.');
        $("#errorDescripcion").show();
        return false;
    }
    if (rutaImagen == '') {
        $("#errorImagen").show();
        return false;
    }
    if (limitesuperior < limiteinferior) {
        $("#errorLimiteSuperior").show();
        return false;
    }
    if (indiceRegistro == "-1") intervalo = '';
    else var intervalo = listaIntervalos[indiceRegistro];
    if (intervalo != limiteinferior + "-" + limitesuperior)//Significa que el usuario modificó los valores de los límites en un registro que está actualizando.
    {
        for (var j = 0; j < listaIntervalos.length; j++) {
            var intervaloBd = listaIntervalos[j].split('-');
            if (intervaloBd.length > 1)//Significa que el registro tiene los intervalor correctos
            {
                var limInferior = parseInt(intervaloBd[0]);
                var limSuperior = parseInt(intervaloBd[1]);
                if (limInferior < limiteinferior) {
                    if (limSuperior > limiteinferior) {
                        if (indiceRegistro != j)//Significa que no es el mismo registro que estoy editando. Valido que el superior
                        {
                            $("#errorLimiteInferior").html("El rango que intenta crear entra en conflicto con los rangos existentes. El problema se presenta con el rango " + listaIntervalos[j] + " el cual se encuentra en la fila " + (j + 1));
                            $("#errorLimiteInferior").show();
                            return false;
                        }
                    }
                }
                else if (limInferior == limiteinferior && indiceRegistro != j) {
                    $("#errorLimiteInferior").html("El rango que intenta crear entra en conflicto con los rangos existentes. El problema se presenta con el rango " + listaIntervalos[j] + " el cual se encuentra en la fila " + (j + 1));
                    $("#errorLimiteInferior").show();
                    return false;
                }
                else {
                    if (limSuperior > limitesuperior) {
                        $("#errorLimiteSuperior").html("El rango que intenta crear entra en conflicto con los rangos existentes. El problema se presenta con el rango " + listaIntervalos[j] + " el cual se encuentra en la fila " + (j + 1));
                        $("#errorLimiteSuperior").show();
                        return false;
                    }
                    else if (limSuperior > limitesuperior && indiceRegistro != j) {
                        $("#errorLimiteSuperior").html("El rango que intenta crear entra en conflicto con los rangos existentes. El problema se presenta con el rango " + listaIntervalos[j] + " el cual se encuentra en la fila " + (j + 1));
                        $("#errorLimiteSuperior").show();
                        return false;
                    }
                }
            }
        }
    }
    return true;
}
function AnadirRegistro() {
    OcultarValidadores();
    AsignarValores(0, '', 0, 1, '', '', true);
    $("#myModalLabel").html("Ingresar Categoría Auditor");
    $("#ingresarActualizarRegistro").modal();
}
function waitblockUIParam(mensaje) { $.blockUI({ message: "<h2>" + mensaje + "</h2>" }); }
function blockUI() { $.blockUI(); }
function unblockUI() { $.unblockUI(); }
function SubirImagen() {

    //var formData = new FormData();
    //$('#input-photos').on('filebatchpreupload', function (event, data, previewId, index) {
    //    var form = data.form, files = data.files, extra = data.extra,
    //        response = data.response, reader = data.reader;

    //    $.each(files, function (key, value) {
    //        if (value != null) {
    //            formData.append("Photos", value, value.name);
    //        }
    //    });
    //});
    $.ajax({
        type: "POST", url: '../../Views/Administracion/CategoriasAuditor_ajax', data: { SubirImagen: $("#imagenTipoAuditor").val() }, traditional: true,
        beforeSend: function () {
            waitblockUIParam('Subiendo imagen...');
        },
        success: function (result) {
            CargarDatos();
            $("#ingresarActualizarRegistro").hidden = "hidden";
            $("#ingresarActualizarRegistro").modal('toggle');
            unblockUI();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("error");
            alert(textStatus + ": " + XMLHttpRequest.responseText);
        }
    });
}
function CargarDatos()
{
    $.ajax({
        type: "POST",
        url: '../../Views/Administracion/CategoriasAuditor_ajax', data: { CategoriasAuditor: "CategoriasAuditor" },
        traditional: true,
        cache: false,
        dataType: "json",
        beforeSend: function () {
            waitblockUI();
        },
        success: function (result)
        {
            var datasource = '';
            if (result != null && result != "")
            {
                for (var i = 0; i < result.Head.length; i++)
                {
                    datasource = datasource +
                             '<div class="list-group-item">' +
                             '<div id="IdTipoAuditor" class="col-sm-5" hidden="hidden"><span><h3>' + result.Head[i].idTipoAuditor + '</h3></span></div>' +
                             '<div class="col-sm-5"><p class="list-group-item-text"><a id="rutaImagen" href="../Images/">' + result.Head[i].nombre + '</a></p></div>' +
                             '<div id="limites" class="col-sm-2"><span><h4>' + result.Head[i].limiteInferior + '-' + result.Head[i].limiteSuperior + '</h4></span></div>' +
                             '<div class="col-sm-2">' + result.Head[i].descripcion + '</div>' +
                             '<div class="col-sm-3 opcionesList">' +
                             '<a href="#" onclick="EditarCategoriaAuditor(' + result.Head[i].idTipoAuditor + ',' + "'" + result.Head[i].nombre + "'" + ',' + result.Head[i].limiteInferior + ',' + result.Head[i].limiteSuperior + ',' + "'" + result.Head[i].descripcion + "'" 
                             + ',' + "'" + result.Head[i].imagen + "'"+ ')"><span class="glyphicon glyphicon-edit"></span><span>Editar</span></a>' +
                             '<a href="#" onclick="EliminarCategoriaAuditor(' + result.Head[i].idTipoAuditor + ',' +
                              "'" + result.Head[i].nombre + "'" + ')"><span class="glyphicon glyphicon-trash"></span><span>Borrar</span></a>' +
                             '</div>' +
                             '</div>';
                }
            } 
            //var cabecera = '<div class="list-group-item">' +
            //       '<div class="col-sm-5 "hidden="hidden"> <p class="list-group-item-text">Id Tipo Auditor</p></div>' +
            //       '<div class="col-sm-5"><p class="list-group-item-text"><a href="">Auditor Ciudadano</a></p></div>' +
            //       '<div class="col-sm-2"><span class="glyphicon glyphicon-map-marker"></span><span>Puntuación</span></div>' +
            //       '<div class="col-sm-2"><span class="glyphicon glyphicon-user"></span> Descripción</div>' +
            //       '<div class="col-sm-3 opcionesList">' +
            //       '<a href="#"><span class="glyphicon glyphicon-edit"></span><span>Editar</span></a>' +
            //       '<a href="#"><span class="glyphicon glyphicon-trash"></span><span>Borrar</span></a>' +
            //       '</div>' +
            //       '</div>';
           
            $("#datos").html(datasource);
            unblockUI();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("error");
            alert(textStatus + ": " + XMLHttpRequest.responseText);
        }

    });
}
function EditarCategoriaAuditor(idTipoAuditor, nombreCategoria, limiteInferior, limiteSuperior, descripcion, rutaImagen)
{
    OcultarValidadores();
    AsignarValores(idTipoAuditor, nombreCategoria, limiteInferior, limiteSuperior, descripcion, rutaImagen);
    $("#ingresarActualizarRegistro").modal();
}
function OcultarValidadores()
{
    $("#errorNombre").hide();
    $("#errorImagen").hide();
    $("#errorLimiteInferior").hide();
    $("#errorLimiteSuperior").hide();
}
function AsignarValores(idTipoAuditor, nombreCategoria, limiteInferior, limiteSuperior, descripcion, rutaImagen)
{
    $("#txtNombre").val(nombreCategoria);
    $("#txtLimiteInferior").val(limiteInferior);
    $("#txtLimiteSuperior").val(limiteSuperior);
    $("#txtDescripcion").val(descripcion);
    $("#idTipoAuditor").val(idTipoAuditor);
    $("#imagenTipoAuditor").val(rutaImagen);
}
function EliminarCategoriaAuditor(idTipoAuditor, nombreCategoria)
{
    if (confirm("Desea eliminar la categoría " + nombreCategoria))
    {
        $.ajax({
            type: "POST", url: '../../Views/Administracion/CategoriasAuditor_ajax', data: { Eliminar: idTipoAuditor }, traditional: true,
            beforeSend: function () {
                waitblockUIEliminacion();
            },
            success: function (result) {
                if (result == 'True')
                {
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
function GuardarRegistro()
{
    OcultarValidadores();
    var dataSource = $("#datos").html();
    var rutaImagen = $("#imagenTipoAuditor").val().split("\\");
    var limiteinferior = $("#txtLimiteInferior").val();
    var limitesuperior= $("#txtLimiteSuperior").val();
    //Revisar la función ajax para en envío de los datos.
    var descrip = $("#txtDescripcion").val();
    var nombre = $("#txtNombre").val();
    var idTipoAuditor = $("#idTipoAuditor").val();
    if (idTipoAuditor == '') idTipoAuditor = 0;
    var guardarRegistro = ValidarFormato(nombre, rutaImagen, limiteinferior, limitesuperior,idTipoAuditor);
    if (guardarRegistro == true)
    {
        $.ajax({
            type: "POST", url: '../../Views/Administracion/CategoriasAuditor_ajax', data: { Guardar: idTipoAuditor + '*' + nombre + '*' + descrip + '*' + rutaImagen[rutaImagen.length - 1] + '*' + limiteinferior + '*' + limitesuperior }, traditional: true,
            beforeSend: function () {
                waitblockUIGuardar();
            },
            success: function (result) {
                if (result == '<||>') {
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
function ValidarFormato(nombre, rutaImagen, limiteinferior, limitesuperior, idTipoAuditor)
{
    var listaId = new Array();
    var listaIntervalos = new Array();
    var indiceRegistro = -1;
    var pruebaId = $("#datos div span h3").each(function (index) {
        var idCategoria = $(this).html();
        listaId[listaId.length]= idCategoria;
    });
    var pruebaFrec = $("#datos div span h4").each(function (index) {
        var filaPuntuacion = $(this).html();
        listaIntervalos[listaIntervalos.length]=filaPuntuacion;
    });
    if(idTipoAuditor!=0)
    {
        for (var i = 0; i < listaId.length; i++)
        {
            if (listaId[i] == idTipoAuditor)
            {
                indiceRegistro = i;
                i = listaId.length;
            }
        }
    }
    if (nombre == '') {
        $("#errorNombre").show();
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
function AnadirRegistro()
{
    OcultarValidadores();
    AsignarValores(0, '', 0, 1, '','','');
    $("#ingresarActualizarRegistro").modal();
}
function waitblockUI() { $.blockUI({ message: "<h2>Cargando datos tipos de auditor...</h2>" }); }
function waitblockUIEliminacion() { $.blockUI({ message: "<h2>Eliminando datos...</h2>" }); }
function waitblockUIGuardar() { $.blockUI({ message: "<h2>Guardar datos...</h2>" }); }
function blockUI() { $.blockUI(); }
function unblockUI() { $.unblockUI(); }
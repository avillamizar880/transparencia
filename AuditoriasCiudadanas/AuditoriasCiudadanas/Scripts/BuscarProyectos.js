


function CambiarEstado(nombreControl)
{
    alert(nombreControl);
}

function CargarProyectosAuditores()
{
    if ($("#r_Auditores").is(':checked'))
    {
        $.ajax({
            type: "POST",
            url: '../../Views/AccesoInformacion/BuscadorProyectosAuditores_ajax', data: { BuscarAuditoresPalabraClave: $("#txtPalabraClave").val() },
            traditional: true,
            cache: false,
            dataType: "json",
            beforeSend: function () {
                waitblockAuditoresUI();
            },
            success: function (result) {
                var datasource = '';
                if (result != null && result != "") {
                    for (var i = 0; i < result.Head.length; i++) {
                        datasource = datasource +
                                 '<div class="list-group-item">' +
                                 '<div class="col-sm-2" hidden="hidden"><p class="list-group-item-text"><a href="#">' + result.Head[i].IdUsuario + '</a></p></div>' +
                                 '<div class="col-sm-3"><span>' + result.Head[i].Nombre + '</span></div>' +
                                 '<div class="col-sm-3"><span></span><span>' + result.Head[i].TipoAuditor + '</span></div>' +
                                 '<div class="col-sm-2"><span class="glyphicon glyphicon-map-marker"></span><span></span></div>' +
                                 '<div class="col-sm-2"><img id="rutaImagen" src="../../Images/CatAuditor/' + result.Head[i].Imagen + '" width="40">' + '</img></div>' +
                                 '<div class="col-sm-2"><span></span>' + result.Head[i].LimiteInferior + "-" + result.Head[i].LimiteSuperior + '</div>' +
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
    else
    {
        //if ($("#r_Auditores").is(':checked')) {

        //}

        $.ajax({
            type: "POST",
            url: '../../Views/AccesoInformacion/BuscadorProyectosAuditores_ajax', data: { BuscarProyectosPalabraClave: $("#txtPalabraClave").val() },
            traditional: true,
            cache: false,
            dataType: "json",
            beforeSend: function () {
                waitblockUI();
            },
            success: function (result) {
                var datasource = '';
                if (result != null && result != "") {
                    for (var i = 0; i < result.Head.length; i++) {
                        datasource = datasource +
                                 '<div class="list-group-item">' +
                                 '<div class="col-sm-2" hidden="hidden"><p class="list-group-item-text">' + result.Head[i].CodigoBPIN + '</p></div>' +
                                 '<div class="col-sm-5"><span>' + result.Head[i].Objeto + '</span></div>' +
                                 '<div class="col-sm-2"><span class="glyphicon glyphicon-map-marker"></span><span>' + result.Head[i].Localizacion + '</span></div>' +
                                 '<div class="col-sm-2"><span class="glyphicon glyphicon-user"></span>' + result.Head[i].Ejecutor + '</div>' +
                                 '<div class="col-sm-3 opcionesList">' +
                                 '<a href="#"><span class="glyphicon glyphicon-pushpin"></span><span>Seguir</span></a>' +
                                 '<a href="#"><span><img src="../../Content/img/iconHand.png" /></span></a>' +
                                 '<a role="button" onclick="obtInfoProyecto(\'' + result.Head[i].CodigoBPIN + '\');"><span class="glyphicon glyphicon-info-sign"></n><span>Información</span></a>' +
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
    
}

function prueba(obj) {
    var codigo = $(obj).closest('.det_bpin').val();
    alert(codigo);
}

function waitblockUI() { $.blockUI({ message: "<h2>Cargando datos proyectos...</h2>" }); }
function waitblockAuditoresUI() { $.blockUI({ message: "<h2>Cargando datos auditores...</h2>" }); }
function blockUI() { $.blockUI(); }
function unblockUI() { $.unblockUI(); }
//function ActivarEstiloBoton() {
//    $("#OpcionesBusqueda").buttonset();
//}
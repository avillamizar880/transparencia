function CargarPlanesTrabajo() {
    $.ajax({
        type: "POST",
        url: '../../Views/VerificacionAnalisis/PlanTrabajo_ajax', data: { BuscarPlanesTrabajo: "BuscarPlanesTrabajo" },
        traditional: true,
        cache: false,
        dataType: "json",
        beforeSend: function () {
            waitblockUIParam('Cargando datos tareas...');
        },
        success: function (result) {
            var datasource = '';
            if (result != null && result != "")
            {
                for (var i = 0; i < result.Head.length; i++)
                {
                    datasource = datasource +
                             '<div class="list-group uppText">' +
                             '<div class="list-group-item">' +
                             '<div class="col-sm-3">' +
                             '<p class="list-group-item-text"><a href="plandetrabajo_auditor69.html"><span class="glyphicon glyphicon-copy"></span>'+ result.Head[i].nombre + '</a></p>' +
                             '</div>' +
                             '<div class="col-sm-2"><span class="glyphicon glyphicon-user"></span><span>'+result.Head[i].NombreUsuario + '</span></div>' +
                             '<div class="col-sm-2"><span class="glyphicon glyphicon-calendar"></span> <span>' + result.Head[i].fecha + '</span></div>' +
                             '<div class="col-sm-4">' +
                             '<p><span class="glyphicon glyphicon-comment"></span>Opinión sobre lo visto.</p>' +
                             ' </div>' +
                             '<div class="col-sm-1"><a href=""><span class="glyphicon glyphicon-calendar"></span> <span>Ver detalles</span></a></div>' +
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

            $("#datosPlanTrabajo").html(datasource);
            unblockUI();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("error");
            alert(textStatus + ": " + XMLHttpRequest.responseText);
            unblockUI();
        }

    });
}
function waitblockUIParam(mensaje) { $.blockUI({ message: "<h2>" + mensaje + "</h2>" }); }
function blockUI() { $.blockUI(); }
function unblockUI() { $.unblockUI(); }
//function waitblockUI() { $.blockUI({ message: "<h2>Cargando datos tareas...</h2>" }); }
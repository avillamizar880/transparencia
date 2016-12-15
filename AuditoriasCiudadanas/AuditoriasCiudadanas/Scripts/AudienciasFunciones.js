function crearAutocomplete(selector) {
    $(selector).keypress(function (event) {
    }).autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "Views/General/listarMunicipiosDep",
                dataType: "json",
                data: {
                    nombDiag: request.term,
                },
                type: "POST",
                success: function (data) {
                    if (data == null) {
                        response([{ label: "[No se encontraron resultados con el criterio seleccionado]", value: "", id_negocio: "" }]);
                    } else {
                        response($.map(data.Head, function (item) {
                            return {
                                label: item.MUNICIPIO,
                                value: item.ID
                             }
                        }));
                    }
                },
                error: function (e) {
                    jsycAlert("No se encontraron municipios con el término de búsqueda seleccionado.", function () { ac.removeClass("ui-autocomplete-loading").val("").next().val("").next().val(""); });
                }
            });
        },
        minLength: 3,
        delay: 500,
        select: function (event, ui) {
            $(this).removeClass("ui-autocomplete-loading");
            return false;
        },
        open: function () {
            $('.ui-autocomplete').css("width", $(this).width() + "px");
            $(this).removeClass("ui-corner-all").addClass("ui-corner-top");
        },
        close: function () {
            $(this).removeClass("ui-autocomplete-loading");
            if ($(this).next().val() == "") {
                $(this).val("");
            }
            $(this).removeClass("ui-corner-top").addClass("ui-corner-all");
        }
    }).bind('blur onblur', function () {
        if ($(this).val() == "") {
            $(this).next().val("").next().val("");
            
        }

    });
}

function registrarObsAudiencia(params) {
        ajaxPost('RegistrarObservaciones_ajax', params, null, function (r) {
            var codigo_error = r.split("<||>")[0];
            var mensaje = r.split("<||>")[1];
            if (r.indexOf("<||>") != -1) {
                if (codigo_error == '0') {
                    alert("Registro guardado exitosamente");
                } else {
                    alert(mensaje);
                }
            }
        }, function (r) {
            alert(r.responseText);
        });
}
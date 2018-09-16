function isUrl(s) {
    var regexp = /(ftp|http|https):\/\/(\w+:{0,1}\w*@)?(\S+)(:[0-9]+)?(\/|\/([\w#!:.?+=&%@!\-\/]))?/
    return regexp.test(s);
}

function modif_enlace_DNP(params) {
    $.ajax({
        url: "EnlacesDNP/guardarEnlaceDNP",
        dataType: "json",
        type: "POST",
        data: params,
        success: function (data) {
            if (data.Mensaje == "@OK") {
                bootbox.alert("Modificación realizada exitosamente", function () {
                    var x = JSON.parse($("#hdDllContent").val());
                    $.each(x, function (idx, obj) {
                        if (obj.id_enlace == $("#ddlTipoEnlace option:selected").val()) {
                            obj.enlace = params.enlace_url;
                        }
                    });
                    $("#hdDllContent").val(JSON.stringify(x));
                    $("#ddlTipoEnlace").val("0");
                    $("#txtURL").val("");
                    $("#txtURL").attr("placeholder", "");
                    
                });
            }
            else {
                bootbox.alert("Error guardando mensaje");
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus, errorThrown);
        }
    });

}
$("#btnCrearForo").bind("click", function () {
    $.ajax({
        url: "Comunicacion/addForo",
        dataType: "json",
        type: "POST",
        data: {
            dataTema: { tema :$("#txtTema").val()}
        },
        success: function (data) {
            debugger
            var prueba = data;
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(textStatus, errorThrown);
        }
    });
});
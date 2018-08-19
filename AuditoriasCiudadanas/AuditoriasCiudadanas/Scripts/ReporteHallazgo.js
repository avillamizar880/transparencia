function ValidarDatosInformeHallazgo()
{
    var archivosDisponiblesCarga = $("#recursoMultimediaHallazgo").val().split(',');
    $("#errorRecursoMultimediaHallazgo").hide();
    $("#errorHallazgo").hide();
    var mensajeAsterisco = $("#txtHallazgo").val().split('*');
   
    if (mensajeAsterisco.length > 1)
    {
        $("#errorHallazgo").html('No se permite el uso del caracter * en el nombre del hallazgo.');
        $("#errorHallazgo").show();
        return false;
    }
    if ($("#txtHallazgo").val() == '') {
        $("#errorHallazgo").html('Por favor ingrese una descripción del hallazgo.');
        $("#errorHallazgo").show();
        return false;
    }
    else {
        //cuenta palabras 200 maximo
        var cad_texto = $("#txtHallazgo").val();
        var contPalabras = PalabrasCaracteres(cad_texto);
        if (contPalabras > 200) {
            $("#errorHallazgo").html('La descripción del hallazgo no puede superar las 200 palabras.');
            $("#errorHallazgo").show();
            return false;
        }
    }
    if ($("#recursoMultimediaHallazgo").val() == '') {
        $("#errorRecursoMultimediaHallazgo").html('Por favor ingrese la evidencia (pdf o imagen) del hallazgo.');
        $("#errorRecursoMultimediaHallazgo").show();
        return false;
    }
    if ($("#hfErroresFileUpload").val() == "true")
    {
        $("#errorRecursoMultimediaHallazgo").html('Se presentaron errores al cargar el archivo.Por favor corríjalos antes de guardar el informe');
        $("#errorRecursoMultimediaHallazgo").show();
        return false;
    }
    return true;
}

function PalabrasCaracteres(cadena) {
    var res = cadena.split(/\b[\s,\.\-:;]*/);
    return res.length;
}

function guardarInformeHallazgo()
{
    var guardarDatos = ValidarDatosInformeHallazgo();
    if (guardarDatos == true) {
        $("#recursoMultimediaHallazgo").fileinput("upload");
    }
    else {
        bootbox.alert("Se presentaron inconsistencias al guardar este reporte.\nRevise los mensajes que aparecen en la pantalla.");
    }
}
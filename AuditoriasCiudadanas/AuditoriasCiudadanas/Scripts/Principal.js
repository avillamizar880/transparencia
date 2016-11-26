
///////////////funcion de pruebas
function datos(rowid) {
    var strPARAM = "rowid=" + rowid;
    var rutaASP = 'Views/PruebasConsulta.aspx';
    $.ajax({
        type: "POST", url: rutaASP, data: strPARAM, traditional: true,
        beforeSend: function () {
            waitblockUI();
        },
        success: function (result) {
            // respuesta ajax
            //$("#regSolRecla_" + rowid).html(result);
            // ---------
            alert(result);
            unblockUI();
        }
    });
}

///////////////////////// MENU///////////////////////////////

// SmartMenus init
$(function () {
    $('#main-menu').smartmenus({
        mainMenuSubOffsetX: -1,
        subMenusSubOffsetX: 10,
        subMenusSubOffsetY: 0
    });
});

// SmartMenus mobile menu toggle button
$(function () {
    var $mainMenuState = $('#main-menu-state');
    if ($mainMenuState.length) {
        // animate mobile menu
        $mainMenuState.change(function (e) {
            var $menu = $('#main-menu');
            if (this.checked) {
                $menu.hide().slideDown(250, function () { $menu.css('display', ''); });
            } else {
                $menu.show().slideUp(250, function () { $menu.css('display', ''); });
            }
        });
        // hide mobile menu beforeunload
        $(window).bind('beforeunload unload', function () {
            if ($mainMenuState[0].checked) {
                $mainMenuState[0].click();
            }
        });
    }
});



function cargaMenu(url, div) {
    var urlCompleta="Views/"+url
    ajaxPost(urlCompleta, '', div, '', '');

    //switch (codi_tra) {
    //    case 1:
    //        ajaxPost('capacitacion/capacitacion.aspx', '', 'divContenido', '', '');
    //        break;
    //    case 2:
    //        ajaxPost('capacitacion/estadistica.aspx', '', 'divContenido', '', '');
    //        break;
    //    case 3:
    //        ajaxPost('visita/visita.aspx', '', 'divContenido', '', '');
    //        break;
    //    case 4:
    //        ajaxPost('visita/concepto.aspx', '', 'divContenido', '', '');
    //        break;
    //    case 5:
    //        ajaxPost('visita/estadisticaActividad.aspx', '', 'divContenido', '', '');
    //        break;
    //    case 6:
    //        ajaxPost('visita/estadisticaVisita.aspx', '', 'divContenido', '', '');
    //        break;
    //    case 7:
    //        ajaxPost('correo/estadisticaCorreo.aspx', '', 'divContenido', '', '');
    //        break;
    //    default:
    //        alert("Codigo de opcion aún no implementado");
    //        location.href = "construccion.aspx";
    //        break;
    //}
}

////////////////////////////////////////////////

//Funciones para bloqueo/Desbloqueo de pantalla
function waitblockUI() { $.blockUI({ message: "<h2>Cargando...</h2>" }); }
function blockUI() { $.blockUI(); }
function unblockUI() { $.unblockUI(); }

//Funcion para instanciar el componente calendario a una caja de texto
function llamarCalendario(inputName, buttonName) {
    if ($("#" + inputName).length > 0) {
        Calendar.setup({
            trigger: buttonName,
            inputField: inputName,
            dateFormat: "%d/%m/%Y",
            onSelect: function () { this.hide() }
        });
    }
}
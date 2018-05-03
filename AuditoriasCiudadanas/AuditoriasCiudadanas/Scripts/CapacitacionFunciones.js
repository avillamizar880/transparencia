function crear_enlace_interes(params) {
        ajaxPost('../Views/Capacitacion/admin_enlaces_ajax', params, 'dvPrincipal', function (r) {
            if (r.indexOf("<||>") != -1) {
                var errRes = r.split("<||>")[0];
                var mensRes = r.split("<||>")[1];
                if (errRes == '0') {

                } else {
                    bootbox.alert(mensRes);
                }
            }
        }, function (r) {
            bootbox.alert(r.responseText);
        });

}
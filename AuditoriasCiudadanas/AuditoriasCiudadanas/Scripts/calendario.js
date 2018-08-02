function ObtInfoTareaCalendario(parametrosTarea) {
    var paramsTarea = parametrosTarea.split('*');
    var idTarea = paramsTarea[0];
    var tipoTarea = paramsTarea.length > 1 ? paramsTarea[1] : "";
    var fechaTarea = paramsTarea.length > 2 ? paramsTarea[2] : "";
    var idUsuarioResponsable = paramsTarea.length > 3 ? paramsTarea[3] : "";
    var idUsuario = paramsTarea.length > 4 ? paramsTarea[4] : "";
    ajaxPost('../../Views/VerificacionAnalisis/DetallePlanTrabajo', { DetallePlanTrabajo: idTarea + "*" + tipoTarea + '*' + fechaTarea + '*' + idUsuarioResponsable + '*' + idUsuario }, 'divDetalleTareaPlanTrabajoGrupo', function (r) {
        $("#divListadoAudit").slideUp(function () {
            $("#divDetallePlanTrabajo").slideUp(function () {
                $("#divDetalleTarea").slideDown(function () {
                    $("#divDetalleTareaPlanTrabajoGrupo").show();
                });
            });


        });
    }, function (e) {
        alert(e.responseText);
    });
}


function MostrarCalendario() {
    var id_usuario = $("#hdIdUsuario").val();
    //pedir usuario
    if (id_usuario == "" || id_usuario == undefined) {
        bootbox.alert({
            message: "Para ver el calendario del plan de trabajo de un GAC, debe estar registrado en el sistema!",
            buttons: {
                ok: {
                    label: 'Aceptar',
                }
            },
            callback: function () {
            }
        });
    }
    else {
        $("#divCalendarioPlanTrabajoGrupo").empty();
        $("#divCalendarioPlanTrabajoGrupo").html('<div id="wrap">' + '<div id="calendar"></div>' + '</div>');
        $.ajax(
                {
                    type: "POST",
                    url: '../../Views/VerificacionAnalisis/PlanTrabajo_ajax', data: { BuscarPlanesTrabajo: $("#hfcodigoBPIN").val() + '*' +  $("#hfidGac").val() + '*' + id_usuario },
                    traditional: true,
                    cache: false,
                    dataType: "json",
                    beforeSend: function () {
                        waitblockUIParamDetalleTarea('Cargando calendario...');
                    },
                    success: function (result) {
                        var eventosTareas = [];
                        for (var i = 0; i < result.Head.length; i++)
                        {
                            console.log(result);
                            var estilo = 'important';
                            if (result.Head[i].semaforo == 'green') estilo = 'sucess';
                            if (result.Head[i].semaforo == 'gris') estilo = 'info';
                            var fechaInicioTarea = result.Head[i].fecha;
                            var fechaEspCol = fechaInicioTarea.split('/');
                            if (fechaEspCol.length == 3)
                                fechaInicioTarea = fechaEspCol[2] + '-' + fechaEspCol[1] + '-' + fechaEspCol[0];
                            eventosTareas.push({
                                                id: result.Head[i].idTarea,
                                                title: result.Head[i].Nombre,
                                                start: fechaInicioTarea,
                                                allDay: true,
                                                className: estilo,
                                                url: result.Head[i].idTarea + '*' + result.Head[i].Nombre + '*' + result.Head[i].fecha + '*' + $("#hdIdUsuario").val() + '*' + $("#hdIdUsuario").val() + '*0'
                                //url: ObtInfoTarea(result.Head[i].idTarea + '*' + result.Head[i].Nombre + '*' + result.Head[i].fecha + '*' + result.Head[i].idUsuarioResponsable + '*' + result.Head[i].idUsuario +'*0'),
                                               });
                        }
                        //var detalleTarea = ObtInfoTarea();
                        var date = new Date();
                        var d = date.getDate();
                        var m = date.getMonth();
                        var y = date.getFullYear();
                        $('#external-events div.external-event').each(function () {

                            // create an Event Object (http://arshaw.com/fullcalendar/docs/event_data/Event_Object/)
                            // it doesn't need to have a start or end
                            var eventObject = {
                                title: $.trim($(this).text()) // use the element's text as the event title
                            };

                            // store the Event Object in the DOM element so we can get to it later
                            $(this).data('eventObject', eventObject);

                            // make the event draggable using jQuery UI
                            $(this).draggable({
                                zIndex: 999,
                                revert: true,      // will cause the event to go back to its
                                revertDuration: 0  //  original position after the drag
                            });

                        });
                        var calendar = $('#calendar').fullCalendar({
                            events: eventosTareas,
                            eventClick: function (calEvent, jsEvent, view) {

                                calEvent.url = 'www.google.com';
                                //Prueba(calEvent.url);
                                                                            //$(this).ObtInfoTarea('194*Actas reuniones*19/07/2018*166*144*0');
                                //alert('Event: ' + calEvent.url);
                               
                                                                            //alert('Coordinates: ' + jsEvent.pageX + ',' + jsEvent.pageY);
                                                                            //alert('View: ' + view.name);
                                                                            //// change the border color just for fun
                                                                            //$(this).css('border-color', 'red');

                                                                        },
                                                                        header: {
                                                                            left: 'title',
                                                                            center: 'agendaDay,agendaWeek,month',
                                                                            right: 'prev,next today'
                                                                        },
                                                                        editable: true,
                                                                        firstDay: 1, //  1(Monday) this can be changed to 0(Sunday) for the USA system
                                                                        selectable: true,
                                                                        defaultView: 'month',

                                                                        axisFormat: 'h:mm',
                                                                        columnFormat: {
                                                                            month: 'ddd',    // Mon
                                                                            week: 'ddd d', // Mon 7
                                                                            day: 'dddd M/d',  // Monday 9/7
                                                                            agendaDay: 'dddd d'
                                                                        },
                                                                        titleFormat: {
                                                                            month: 'MMMM yyyy', // September 2009
                                                                            week: "MMMM yyyy", // September 2009
                                                                            day: 'MMMM yyyy'                  // Tuesday, Sep 8, 2009
                                                                        },
                                                                        allDaySlot: false,
                                                                        selectHelper: true,
                                                                        select: function (start, end, allDay) {
                                                                            var title = prompt('Event Title:');
                                                                            if (title) {
                                                                                calendar.fullCalendar('renderEvent',
                                                                                    {
                                                                                        title: title,
                                                                                        start: start,
                                                                                        end: end,
                                                                                        allDay: allDay
                                                                                    },
                                                                                    true // make the event "stick"
                                                                                );
                                                                            }
                                                                            calendar.fullCalendar('unselect');
                                                                        },
                                                                        droppable: true, // this allows things to be dropped onto the calendar !!!
                                                                        drop: function (date, allDay) { // this function is called when something is dropped

                                                                            // retrieve the dropped element's stored Event Object
                                                                            var originalEventObject = $(this).data('eventObject');

                                                                            // we need to copy it, so that multiple events don't have a reference to the same object
                                                                            var copiedEventObject = $.extend({}, originalEventObject);

                                                                            // assign it the date that was reported
                                                                            copiedEventObject.start = date;
                                                                            copiedEventObject.allDay = allDay;

                                                                            // render the event on the calendar
                                                                            // the last `true` argument determines if the event "sticks" (http://arshaw.com/fullcalendar/docs/event_rendering/renderEvent/)
                                                                            $('#calendar').fullCalendar('renderEvent', copiedEventObject, true);
                                                                            // is the "remove after drop" checkbox checked?
                                                                            if ($('#drop-remove').is(':checked')) {
                                                                                // if so, remove the element from the "Draggable Events" list
                                                                                $(this).remove();
                                                                            }
                                                                        },
                                                                        
                                                                });
                        unblockUIDetalleTarea();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert("error");
                        alert(textStatus + ": " + XMLHttpRequest.responseText);
                        unblockUIDetalleTarea();
                    }
                });
    } 
}
function OcultarPlanTrabajo() {
    $("#divDetallePlanTrabajo").slideUp(function () {
        $("#divDetalleTareaPlanTrabajoGrupo").slideUp(function () {
            $("#divDetalleTarea").slideDown(function () {
                $("#divCalendarioPlanTrabajoGrupo").show();
                MostrarCalendario();
            });
        });
    });
}
function Prueba(parametrosTarea)
{
    ObtInfoTareaCalendario(parametrosTarea);
}


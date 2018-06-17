    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CapacitacionInicialFaseII.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Capacitacion.CapacitacionInicialFaseII" %>

<div class="container">
        <input type="hidden" id="hfmunicipio" runat="server"/>
        <input type="hidden" id="hfUsuarioId" runat="server"/>
        <form id="form2" runat="server">
        <h1 class="text-center">Capacitación inicial: ¿Cómo funciona el aplicativo?</h1>
        <div class="center-block w60">
        <div class="formSteps">
        	<div class="step"><span class="glyphicon glyphicon-ok"></span>Paso 1</div>
            <div class="step currentStep"><span class="glyphicon glyphicon-ok"></span>Paso 2</div>
            <div class="step"><span class="glyphicon glyphicon-edit"></span>Paso 3</div>
            <div class="step"><span class="glyphicon glyphicon-edit"></span>Paso 4</div>
        </div>
       <div id="player" class="well">
        </div>
        <br/>
        <p id="progressFaseII" hidden="hidden"></p>
        <div class="botonera text-center">
              <div class="btn btn-primary" onclick="siguiente()">SIGUIENTE<span class="glyphicon"></span></div>
        </div>
    </div>
    </form>
    </div>
<script>
    var tag = document.createElement('script');
    tag.src = "https://www.youtube.com/iframe_api";
    var firstScriptTag = document.getElementsByTagName('script')[0];
    firstScriptTag.parentNode.insertBefore(tag, firstScriptTag);
    var player;
    function onYouTubeIframeAPIReady() {
        ObtenerVideoUrlCapacitacionFaseII();
    }
    function ObtenerVideoUrlCapacitacionFaseII() {
        $.ajax(
        {
            type: "POST",
            url: '../../Views/Capacitacion/CapacitacionInicialFaseII_ajax', data: {},
            traditional: true,
            cache: false,
            dataType: "text",// "json",
            beforeSend: function () {
                waitblockUIParamDetalleTarea('Obteniendo video...');
            },
            success: function (result) {
                unblockUIDetalleTarea();
                player = new YT.Player('player', {
                    height: '360',
                    width: '640',
                    videoId: result,
                    events: {
                        'onReady': onPlayerReady,
                        'onStateChange': onPlayerStateChange
                    }
                });
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("error");
                alert(textStatus + ": " + XMLHttpRequest.responseText);
                unblockUIDetalleTarea();
            }
        });
    }
    function onPlayerReady(event) {
        event.target.playVideo();
    }
    function onPlayerStateChange(event) {
        if (event.data === YT.PlayerState.PLAYING) {
            setInterval(getProgress, 1000);
        }
    }
    function getProgress() {
        var progreso = Math.round(player.getCurrentTime() / player.getDuration() * 100);
        $("#progressFaseII").text(progreso);
    }
    function siguiente() {
        var porcEjecutadoVideo;
        if ($("#progressFaseII").text() == '') porcEjecutadoVideo = 0;
        else porcEjecutadoVideo = parseFloat($("#progressFaseII").text());
        if (porcEjecutadoVideo <= 90) {
            bootbox.alert('Usted no ha visualizado todo el contenido del video.\nPor favor reproduzca el video en su totalidad para poder continuar.');
        }
        else {
            Reenviar('../Views/Capacitacion/CapacitacionInicialFaseIII', 'dvPrincipal');
        }
    }
    $(document).ready(function () {
        onYouTubeIframeAPIReady();

    });

      
    </script>
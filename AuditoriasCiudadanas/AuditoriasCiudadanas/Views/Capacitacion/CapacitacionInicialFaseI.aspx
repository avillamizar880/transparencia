<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CapacitacionInicialFaseI.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Capacitacion.CapacitacionInicialFaseI" %>

<div class="container">
        <input type="hidden" id="hfmunicipio" runat="server"/>
        <input type="hidden" id="hfUsuarioId" runat="server"/>
        <form id="form2" runat="server">
        <h1 class="text-center">¿Qué es control social?</h1>
        <div class="center-block w60">
        <div class="formSteps">
        	<div class="step currentStep"><span class="glyphicon glyphicon-ok"></span>Paso 1</div>
            <div class="step"><span class="glyphicon glyphicon-edit"></span>Paso 2</div>
            <div class="step"><span class="glyphicon glyphicon-edit"></span>Paso 3</div>
            <div class="step"><span class="glyphicon glyphicon-edit"></span>Paso 4</div>
        </div>
        <div id="player" class="well">
        </div>
        <br />
        <p id="progress" hidden="hidden"></p>
        <div class="botonera text-center">
              <div class="btn btn-primary" onclick="siguiente()">SIGUIENTE<span class="glyphicon"></span></div>
        </div>
    </div>
    </form>
    </div>
 <script>
      // 2. This code loads the IFrame Player API code asynchronously.
      var tag = document.createElement('script');

      tag.src = "https://www.youtube.com/iframe_api";
      var firstScriptTag = document.getElementsByTagName('script')[0];
      firstScriptTag.parentNode.insertBefore(tag, firstScriptTag);

      // 3. This function creates an <iframe> (and YouTube player)
      //    after the API code downloads.
      var player;
      function onYouTubeIframeAPIReady() {
        ObtenerVideoUrlCapacitacion();
      }

      function ObtenerVideoUrlCapacitacion() {
          $.ajax(
          {
              type: "POST",
              url: '../../Views/Capacitacion/CapacitacionInicialFaseI_ajax', data: {},
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

      // 4. The API will call this function when the video player is ready.
      function onPlayerReady(event) {
        event.target.playVideo();
      }

      // 5. The API calls this function when the player's state changes.
      //    The function indicates that when playing a video (state=1),
      //    the player should play for six seconds and then stop.
      var done = false;
      function onPlayerStateChange(event) {
        if (event.data === YT.PlayerState.PLAYING) {
            setInterval(getProgress, 1000);
        }
      }

      function getProgress() {
          var progreso = Math.round(player.getCurrentTime() / player.getDuration() * 100);
          $("#progress").text(progreso);
      }
      function siguiente() {
          var porcEjecutadoVideo;
          if ($("#progress").text() == '') porcEjecutadoVideo = 0;
          else porcEjecutadoVideo = parseFloat($("#progress").text());
          if (porcEjecutadoVideo <= 90) {
              alert('Usted no ha visualizado todo el contenido del video.\nPor favor reproduzca el video en su totalidad para poder continuar.');
          }
          else {
              Reenviar('../Views/Capacitacion/CapacitacionInicialFaseII', 'dvPrincipal');
          }
      }
    </script>



<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActaReunionesPrevias.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Audiencias.ActaReuniones" %>
<link href="../../Content/bootstrap.min.css" rel="stylesheet" />
<link href="../../Content/logo-nav.css" rel="stylesheet">
<link href="../../Content/screenView.css" rel="stylesheet" type="text/css">
<link href="../../Content/jquery.fileupload.css" rel="stylesheet" />
<link href="../../Content/jquery.fileupload-ui.css" rel="stylesheet" />

    <link type="text/css" rel="stylesheet" href="../../FileUpload/css/style.css" />
    <link type="text/css" rel="stylesheet" href="../../FileUpload/css/jquery-ui-1.9.0.custom.css" />
    <link type="text/css" rel="stylesheet" href="../../FileUpload/css/jquery.fileupload-ui.css" />
    <link type="text/css" rel="stylesheet" href="../../FileUpload/css/jquery.ui.all.css" />
    <link type="text/css" rel="stylesheet" href="../../FileUpload/css/jquery-ui-1.8.21.custom.css" />
<script src="../../Scripts/jquery-1.12.4.min.js"></script>
<script src="../../Scripts/jquery-ui-1.12.1.min.js"></script>
<script src="../../Scripts/jquery-1.12.4.min.js"></script>
<script src="../../Scripts/jquery-migrate-1.4.1.min.js"></script>
<script  type="text/javascript" src="../../FileUpload/js/jQuery/1.8.13/jquery-ui.min.js"></script>
<script  type="text/javascript" src="../../FileUpload/js/jQuery/beta1/jquery.tmpl.min.js"></script>
<script  type="text/javascript" src="../../FileUpload/js/jquery.iframe-transport.js"></script>
<script  type="text/javascript" src="../../FileUpload/js/jquery.fileupload.js"></script>
<script  type="text/javascript" src="../../FileUpload/js/jquery.fileupload-ui.js"></script>
<script  type="text/javascript" src="../../FileUpload/js/application.js"></script> 

   <script type="text/javascript">

    $(document).ready(function () {
        $("#attach-files")
           .button()
           .click(function (e) {
               $("#dialog-message").dialog("open");
               e.preventDefault();
               return false;
           });
        // Trying to fix for Opera and Chrome
        UpdatejqFileName();
    });
</script>

<script type="text/javascript">

        function GetTxtFileName() {
            return $('#' + '<%= txtFileName.ClientID %>').val();
        }

        function SetTxtFileName(fileName) {
            document.getElementById('<%= txtFileName.ClientID %>').value = fileName;
            return false;

        }

        function AddTxtFileName(fileName) {
            var filesName = GetTxtFileName();
            filesName = $.trim(filesName + "|" + fileName);

            if (filesName.substring(0, 3).indexOf("|") > -1) {
                filesName = filesName.substring(filesName.substring(0, 3).indexOf("|") + 1, filesName.length);
            }

            //document.getElementById('<%= txtFileName.ClientID %>').value = filesName;
            $("#txtFileName").val(tempFilesName);

            AppendButton(fileName);

            return false;
        }

        function RemoveTxtFileName(filename) {
            var filesName = GetTxtFileName();
            var tempFilesName;

            if (filename.indexOf("cargue_archivos.ashx?f=") >= 0) {
                filename = filename.replace("cargue_archivos.ashx?f=", "");
            }

            tempFilesName = filesName.replace(filename, '');
            while (tempFilesName.indexOf(filename) > 0) {
                tempFilesName = tempFilesName.replace(filename, '');
            }

            //document.getElementById('<%= txtFileName.ClientID %>').value = tempFilesName;
            $("#txtFileName").val(tempFilesName);

            UpdatejqFileName();

            return false;

        }

        function UpdatejqFileName() {
            var tempFilesName = GetTxtFileName() + '';
            var tempFile;
            var i;

            $('div.jShowFilesLabel').remove();
            $('.dFileButton').remove();

            if (tempFilesName.length > 0) {

                while (tempFilesName.length > 0) {
                    i = tempFilesName.indexOf("|");
                    if (i == -1) { // Last File
                        tempFile = tempFilesName;
                        tempFilesName = '';
                    } else {
                        tempFile = tempFilesName.substring(0, i);
                        tempFilesName = tempFilesName.substring(i + 1);
                    }

                    if ($.trim(tempFile) !== "") {
                        AppendButton(tempFile);
                    }
                }
            }
        }

        function AppendButton(fileName) {
            alert("AppendButton");
            if (fileName.length > 40) {
                fileName = FixTooLong(fileName);
            }
            $('div.jShowFiles').append("<div class='dFileButton'><button class='jqFileName'>" + fileName + "</button><br></div>");
            $('.jqFileName')
                .button({
                    icons: { primary: 'ui-icon-disk' }
                })
                .click(function (e) {
                    e.preventDefault();
                    return false;
                });

            return false;

        }

        function FixTooLong(fileName) {
            alert("FixTooLong");
            var tempFile;
            tempFile = fileName;
            tempFile = tempFile.substring(0, 25) + "..." + tempFile.substring(tempFile.length - 15);
            return tempFile;
        }
</script>
<!-- /.container -->
    <!-- Page Content -->


    <div class="container">
      <input type="text" class="hidden" id="hfTipoAudiencia" runat="server" />
    <h1 id="hTitulo" runat="server" class="text-center">Acta de Reuniones previas</h1>
        <div style="float:left;" role="button"><a id="btnDescargaFormato">Descargar formato</a></div>
        <div class="w60 center-block">
            <div class="form-group">
                <label for="txtAsunto">Tema a tratar</label>
                <textarea class="form-control" rows="3" id="txtTema" runat="server"></textarea>
            </div>
            <div class="row">
                <div class="col-sm-6">
                    <div class="form-group">
                        <label for="txtLugar">Lugar</label>
                        <input type="text" class="form-control aclugar" id="txtLugar" runat="server">
                        <input type="hidden" id="hdIdMunicipio" runat="server" />
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="form-group">
                        <label for="dtp_fecha_acta" class="control-label">Fecha</label>
                        <div class="input-group date form_date" data-date="" data-date-format="dd MM yyyy" data-link-field="dtp_fecha_acta" data-link-format="yyyy-mm-dd">
                            <input class="form-control" size="16" type="text" value="" readonly>
                            <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                            <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                        </div>
                        <input type="hidden" id="dtp_fecha_acta" value="" /><br />
                    </div>
                </div>
            </div>


        <form id="fileupload" action="//jquery-file-upload.appspot.com/" method="POST" enctype="multipart/form-data">
        <!-- Redirect browsers with JavaScript disabled to the origin page -->
        <!-- The fileupload-buttonbar contains buttons to add/delete files and start/cancel the upload -->
        <div class="btn btn-info"><a href=""><span class="glyphicon glyphicon-camera"></span> SUBIR FOTO DE LA ASISTENCIA</a></div>
        <!-- The table listing the files available for upload/download -->
           <%-- <div class="btn btn-info">
            <span class="fileinput">
                <i class="glyphicon glyphicon-camera"></i>
                <span>SUBIR FOTO DE LA ASISTENCIA</span>
                <input type="file" name="files[]" multiple>
            </span>
                </div>--%>


        <table role="presentation" class="table table-striped"><tbody class="files"></tbody></table>
    </form>
            <script type="text/javascript">
                if ($(document).ready(function () {
                     $.getScript("../../Scripts/AudienciasFunciones.js", function () {
                             $.getScript("../../Scripts/AudienciasAcciones.js", function () {
                });
                });
                }));
</script>


             <div class="jShowFilesLabel"></div>
              <input type="hidden" id="txtFileName" runat="server" />
              <div id="dialog-message" title="Attach Files">
                  <script id="template-upload" type="text/x-jquery-tmpl">
                      <tr class="template-upload{{if error}} ui-state-error{{/if}}">
                          <td class="preview"></td>
                          <td class="name">${name}</td>
                          <td class="size">${sizef}</td>
                          {{if error}}
                         <td class="error" colspan="2">@Error:
                                {{if error === 'maxFileSize'}}File is too big
                                {{else error === 'minFileSize'}}File is too small
                                {{else error === 'acceptFileTypes'}}Filetype not allowed
                                {{else error === 'maxNumberOfFiles'}}Max number of files exceeded
                                {{else}}${error}
                                {{/if}}
                        </td>
                          {{else}}
                        <td class="progress"><div></div></td>
                    <td class="start"><button>Start</button></td>
                          {{/if}}
                        <td class="cancel">
                            <button class="btn btn-warning cancel">
                                <i class="glyphicon glyphicon-trash"></i>
                                <span>Cancelar</span>
                            </button>
                        </td>
                      </tr>
                  </script>
                    <script id="template-download" type="text/x-jquery-tmpl">
                        <tr class="template-download{{if _errorMSG}} ui-state-error{{/if}}">
                            {{if _errorMSG}}
                                <td></td>
                                <td class="name">${_name}</td>
                                <td class="size">${sizef}</td>
                                <td class="error" colspan="2">@Error:
                                    {{if _errorMSG === 1}}Archivo excede upload_max_filesize
                                    {{else _errorMSG === 2}}El archivo supera MAX_FILE_SIZE (directiva de formulario HTML)
                                    {{else _errorMSG === 3}}El archivo cargado parcialmente
                                    {{else _errorMSG === 4}}No se ha cargado ningún archivo
                                    {{else _errorMSG === 5}}Falta una carpeta temporal
                                    {{else _errorMSG === 6}}Error al escribir el archivo en el disco
                                    {{else _errorMSG === 7}}Archivo de carga detenido por extensión
                                    {{else _errorMSG === 'maxFileSize'}}El archivo es demasiado grande
                                    {{else _errorMSG === 'minFileSize'}}El archivo es demasiado pequeño
                                    {{else _errorMSG === 'acceptFileTypes'}}Tipo de archivo no permitido
                                    {{else _errorMSG === 'maxNumberOfFiles'}}Se ha superado el número máximo de archivos
                                    {{else _errorMSG === 'uploadedBytes'}}Bytes cargados exceden tamaño de archivo
                                    {{else _errorMSG === 'emptyResult'}}Resultado de carga vacío
                                    {{else}}${_errorMSG}. Archivo no cargado!
                                    {{/if}}
                                </td>
                                <td class="failupload">
                                    <button data-type="${delete_type}" data-url="${delete_url}">Cancelar Carga</button>
                                </td>                
                            {{else}}
                                <td class="preview">
                                    {{if Thumbnail_url}}
                                        <a href="${_url}" target="_blank"><img src="${Thumbnail_url}"></a>
                                    {{/if}}
                                </td>
                                <td class="name">
                                    <a href="${_url}"{{if thumbnail_url}} target="_blank"{{/if}}>${_name}</a>
                                </td>
                                <td class="size">${sizef}</td>
                                <td colspan="2"></td>
                                <td class="success">
                                    <p>Archivo Cargado</p>
                                </td>
                                <td class="delete">
                                    <button data-type="${delete_type}" data-url="${delete_url}">Remover Archivo</button>
                                </td>                
                            {{/if}}
                        </tr>
                    </script>
 
        </div>
            
          
        </div>
<div id="divPdf" class="hideObj">
<form id="loginForm" target="myFrame"  action="DescargaFormato_ajax" method="POST">
 <input type="submit">
</form>
<iframe name="myFrame" src="#">
</iframe>
</div>
<%-- <script type="text/javascript">

     $(document).ready(function () {
         $('#fileupload').fileupload({
             dataType: 'json',
             maxNumberOfFiles: 1,
             autoUpload: false,
             add: function (e, data) {
                 $("#btnGuardarActa").on("click", function () {
                     data.submit();
                 })
             }
         }).on('fileuploadsubmit', function (e, data) {
             console.log(data);
         });


     });
</script>--%>







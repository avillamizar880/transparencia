<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="actualizarDatos.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Usuarios.actualizarDatos" %>
   <!-- Page Content -->
    <div class="container">
    	<h1>Datos Registrados</h1>
        <div class="center-block w60" id="divInfoUsuario">
                <input type="hidden" id="hdIdUsuario" value="" runat="server" />
                <input type="hidden" id="hdCodMunicipio" value="" runat="server" />
                <div class="form-group"> 
                    <label for="txtNombre" class="required">Nombre Completo</label>
                    <input type="text" class="form-control" id="txtNombre" runat="server" />
                     <div id="error_txtNombre" class="alert alert-danger alert-dismissible" hidden="hidden">Nombre no puede ser vacío</div>
                     <div id="error_txtNombre_Formato" class="alert alert-danger alert-dismissible" hidden="hidden">Nombre con formato incorrecto, debe ser alfabético</div>
                </div>
                <div class="form-group">
                    <label for="txtEmail">Correo Electrónico</label>
                    <input type="text" class="form-control" id="txtEmail" runat="server" readonly />

                </div>
                <div class="form-group">
                    <label for="txtCelular">Número de Celular</label>
                    <input type="text" class="form-control" id="txtCelular" runat="server" />
                    <div id="error_txtCelular_Formato" class="alert alert-danger alert-dismissible" hidden="hidden">Número celular con formato no válido.</div>
                    </div>
                <div class="form-group">
                    <label for="txtEstado">Estado</label>
                    <input type="text" class="form-control" id="txtEstado" runat="server" readonly />
                </div>
                <div class="form-group">
                    <label for="ddlDepartamento" class="required">Departamento:</label>
                    <asp:dropdownlist id="ddlDepartamento" class="form-control" runat="server" datatextfield="nom_departamento" datavaluefield="id_dep" tooltip="--Departamento--">
                    </asp:dropdownlist>
                    <div id="error_ddlDepartamento" class="alert alert-danger alert-dismissible" hidden="hidden">Departamento no puede ser vacío</div>
                </div>
                <div class="form-group">
                  <label for="ddlMunicipio" class="required">Municipio:</label>
                    <asp:dropdownlist id="ddlMunicipio" class="form-control" runat="server" datatextfield="nom_municipio" datavaluefield="id_munic" tooltip="--Municipio--">
                    </asp:dropdownlist>
                    <div id="error_ddlMunicipio" class="alert alert-danger alert-dismissible" hidden="hidden">Municipio no puede ser vacío</div>
                </div>  
            <div class="botonera">
                <div class="btn btn-primary fr"><a id="btnActualizarDatos">Actualizar<span class="glyphicon glyphicon-chevron-right"></span></a></div>
            </div>
                          
        </div>
    </div>
<script type="text/javascript">
    function cargarMunic() {
        var id_departamento = $("#ddlDepartamento option:selected").val();
        $.ajax({
            url: "../Views/General/listarMunicipios",
            cache: false,
            method: "POST",
            data: { id_departamento: id_departamento },
            dataType: "json",

            success: function (data) {
                  if (data == null || data == "") {
                    response([{ label: "[No se encontraron resultados con el criterio seleccionado]", value: "", id_departamento: "" }]);
                } else {
                    var jsonData = eval(data);
                    $("#ddlMunicipio option[value!='0']").remove();
                    for (var i = 0; i < jsonData.Head.length; i++) {
                        $('#ddlMunicipio').append('<option divipola="' + jsonData.Head[i].idDivipola + '" value="' + jsonData.Head[i].id_munic + '">' + jsonData.Head[i].nom_municipio + '</option>');
                    }
                    if (id_departamento == "11") {
                        //si es bogotá, cargue municipio bogotá
                        $('#ddlMunicipio').val("001");
                    }

                    $('#ddlMunicipio').val($("#hdCodMunicipio").val());
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                bootbox.alert(textStatus + ": " + XMLHttpRequest.responseText);
            }
        });
    }

    if ($(document).ready(function () {
         $.getScript("../../Scripts/UsuariosFunciones.js", function () {
                 $.getScript("../../Scripts/UsuariosAcciones.js", function () {
        cargarMunic();



    });
    });
    }));
</script>

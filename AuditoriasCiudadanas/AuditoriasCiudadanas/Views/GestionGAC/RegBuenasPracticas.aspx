<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegBuenasPracticas.aspx.cs" Inherits="AuditoriasCiudadanas.Views.GestionGAC.RegBuenasPracticas" %>
    <div class="container" id="divInfoPracticas">
    <input type="hidden" id="hfIdGrupoGac" value="" runat="server"/>
    <input type="hidden" id="hdIdUsuario" value="" runat="server"/>
    <input type="hidden" id="hfIdProyecto" value="" runat="server" />
    <h1 class="text-center">POSTULAR EXPERIENCIA</h1>
    	<div class="w60 center-block">
            <div class="row">
                <div class="col-sm-12 singleChoise">
                    <div class="form-group required">
                        <label for="txtHecho">Hecho</label>
                        <span class="label label-default fr">150/500</span>
                        <textarea class="form-control" rows="4" id="txtHecho"></textarea>
                    </div>

                </div>
            </div>
            <div class="row">
                <div class="col-sm-12 singleChoise">
                    <div class="form-group required">
                        <label for="txtDescripcion">Descripción</label>
                        <span class="label label-default fr">150/500</span>
                        <textarea class="form-control" rows="10" id="txtDescripcion"></textarea>
                    </div>

                </div>
            </div>
        <!--BOTONERA-->
             <div class="botonera text-center">
              	<div class="btn btn-primary"><a role="button" onclick="guardarBuenaPractica();" id="btnPostularPractica"><span class="glyphicon glyphicon-ok-sign"></span>Postular</a></div>
             </div>
        </div>
        
        
    </div>

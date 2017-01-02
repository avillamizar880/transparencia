<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EncuestaParte5.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Caracterizacion.EncuestaParte5" %>
<div class="container">
        <input type="hidden" id="hfmunicipio" runat="server"/>
        <input type="hidden" id="hfUsuarioId" runat="server"/>
        <form id="form2" runat="server">
        <h1 class="text-center">Encuesta de Caracterización</h1>
        <div class="center-block w60">
     <div class="formSteps">
        	<div class="step"><span class="glyphicon glyphicon-edit"></span>Paso 1</div>
            <div class="step"><span class="glyphicon glyphicon-question-sign"></span>Paso 2</div>
            <div class="step"><span class="glyphicon glyphicon-user"></span>Paso 3</div>
            <div class="step"><span class="glyphicon glyphicon-equalizer"></span>Paso 4</div>
            <div class="step currentStep"><span class="glyphicon glyphicon-blackboard"></span>Paso 5</div>			
     </div>
     <div>Haz finalizado la encuesta.</div>
    </div>
    </form>
    </div>

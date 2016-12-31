<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EvaluarExperiencia.aspx.cs" Inherits="AuditoriasCiudadanas.Views.AudienciasPublicas.EvaluarExperiencia" %>

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Plan de trabajo</title>--%>
     <%-- Archivos CSS--%>
<%--        <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
        <link href="../../Content/logo-nav.css" rel="stylesheet" />
        <link href="../../Content/screenView.css" rel="stylesheet" />
        <link href="../../Content/bootstrap-datetimepicker.min.css" rel="stylesheet" type="text/css"/>
        <link href="../../Content/bootstrap-datetimepicker.css" rel="stylesheet" type="text/css"/>--%>
       
      <%-- Archivos JS--%>
<%--        <script src="../../Scripts/jquery-1.12.4.min.js" type="text/javascript" ></script>
        <script src="../../Scripts/jquery-ui-1.12.1.js" type="text/javascript" ></script>
        <script src="../../Scripts/jquery.blockUI.js" type="text/javascript" ></script>
        <script src="../../Scripts/bootstrap.min.js"></script>
        <script type="text/javascript" src="../../Scripts/bootstrap-datetimepicker.js" charset="UTF-8"></script>
        <script type="text/javascript" src="../../Scripts/bootstrap-datetimepicker.es.js" charset="UTF-8"></script>--%>

<%--         <script src="../../Scripts/EvaluarExperiencia.js" type="text/javascript"></script>  --%>
        <%--<script type="text/javascript" src="../../Scripts/ajaxPost.js"></script>--%>
       <%-- <script src="../../Scripts/PlanTrabajo.js" type="text/javascript"></script>  --%>
<%--</head>--%>




<%--<body class="inside">--%>



<div class="container">
    <h1 class="text-center">Evaluación de Experiencia</h1>
    
    	<div class="w60 center-block">
        <div class="well">
        <p> Califique de 1 a 5 su experiencia en la audiencia. Recuerde que 1: es Muy Malo  y 5: es Excelente</p></div>
    	<%--<form>--%>
            	<div class="row">
                <div class="col-sm-12 singleChoise">
                <input type="hidden" id="hfidAudiencia" runat="server" value=""/>
                <h4>¿Cree usted que la audiencia se desarrolló de manera organizada?</h4>
               <div class="btn-group" data-toggle="buttons">
                  <input type="hidden" id="hfResPreg1" runat="server" value=""/>
                  <label class="btn btn-default" onclick="AsignarRespuesta('p1', 1)">
                  <input type="radio" name="options" value="1"/> 1
                  </label>
                  <label  class="btn btn-default" onclick="AsignarRespuesta('p1', 2)">
                    <input type="radio" name="options" value="2"/> 2
                  </label>
                  <label class="btn btn-default" onclick="AsignarRespuesta('p1', 3)">
                    <input type="radio" name="options" value="3"/> 3
                  </label>
                  <label class="btn btn-default" onclick="AsignarRespuesta('p1', 4)">
                    <input type="radio" name="options" value="4"/> 4
                  </label>
                  <label class="btn btn-default" onclick="AsignarRespuesta('p1', 5)">
                    <input type="radio" name="options" value="5"/> 5
                  </label>
                </div>
                <textarea class="form-control" rows="3" id="txt_p1" style="display:none" placeholder="¿Porqué?"></textarea>
                <div id="errResPreg1" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor seleccione una respuesta para esta pregunta</div>
                </div>
                </div>
             	<div class="row">
                <div class="col-sm-12 singleChoise">
                <h4>¿Cómo evalúa los temas tratados en la audiencia?</h4>
               <div class="btn-group" data-toggle="buttons">
                  <input type="hidden" id="hfResPreg2" runat="server" value=""/>
                  <label class="btn btn-default" onclick="AsignarRespuesta('p2', 1)">
                    <input type="radio" name="options" value="1" /> 1
                  </label>
                  <label class="btn btn-default"  onclick="AsignarRespuesta('p2', 2)">
                    <input type="radio" name="options" value="2"/> 2
                  </label>
                  <label class="btn btn-default"  onclick="AsignarRespuesta('p2', 3)">
                    <input type="radio" name="options" value="3"/> 3
                  </label>
                  <label class="btn btn-default"  onclick="AsignarRespuesta('p2', 4)">
                    <input type="radio" name="options" value="4"/> 4
                  </label>
                  <label class="btn btn-default"  onclick="AsignarRespuesta('p2', 5)">
                    <input type="radio" name="options" value="5"/> 5
                  </label>
                </div>
               <textarea class="form-control" rows="3" id="txt_p2" style="display:none"  placeholder="¿Porqué?"></textarea>
               <div id="errResPreg2" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor seleccione una respuesta para esta pregunta</div>
                </div>
                </div>
                <div class="row">
                <div class="col-sm-12 singleChoise">
                <h4>¿Tuvo algun problema?</h4>
               <div class="btn-group" data-toggle="buttons">
                  <input type="hidden" id="hfResPreg3" runat="server" value=""/>
                  <label class="btn btn-default" onclick="AsignarRespuesta('p3', 1)">
                    <input type="radio" name="options" value="1" /> 1
                  </label>
                  <label class="btn btn-default" onclick="AsignarRespuesta('p3', 2)">
                    <input type="radio" name="options" value="2" /> 2
                  </label>
                  <label class="btn btn-default" onclick="AsignarRespuesta('p3', 3)">
                    <input type="radio" name="options" value="3" /> 3
                  </label>
                  <label class="btn btn-default" onclick="AsignarRespuesta('p3', 4)">
                    <input type="radio" name="options" value="4" /> 4
                  </label>
                  <label class="btn btn-default" onclick="AsignarRespuesta('p3', 5)">
                    <input type="radio" name="options" value="5" /> 5
                  </label>
                </div>
                <textarea class="form-control" rows="3" id="txt_p3" style="display:none"  placeholder="Descríbalo"></textarea>
                <div id="errResPreg3" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor seleccione una respuesta para esta pregunta</div>
                </div>
                </div>
             <div class="row">
                <div class="col-sm-12 singleChoise">
                <h4>¿Como considera su participación  en el control de la gestión pública?</h4>
               <div class="btn-group" data-toggle="buttons">
                  <input type="hidden" id="hfResPreg4" runat="server" value=""/>
                  <label class="btn btn-default" onclick="AsignarRespuesta('p4', 1)">
                    <input type="radio" name="options" value="1" /> 1
                  </label>
                  <label class="btn btn-default" onclick="AsignarRespuesta('p4', 2)">
                    <input type="radio" name="options" value="2" /> 2
                  </label>
                  <label class="btn btn-default" onclick="AsignarRespuesta('p4', 3)">
                    <input type="radio" name="options" value="3" /> 3
                  </label>
                  <label class="btn btn-default" onclick="AsignarRespuesta('p4', 4)">
                    <input type="radio" name="options" value="4" /> 4
                  </label>
                  <label class="btn btn-default" onclick="AsignarRespuesta('p4', 5)">
                    <input type="radio" name="options" value="5" /> 5
                  </label>
                </div>
                <textarea class="form-control" rows="3" id="txt_p4" style="display:none" placeholder="¿Porqué?"></textarea>
                <div id="errResPreg4" class="alert alert-danger alert-dismissible" hidden="hidden" >Por favor seleccione una respuesta para esta pregunta</div>
                </div>
                </div>
        <%--</form>--%>
        <!--BOTONERA-->
             <div class="botonera text-center">
              	<div class="btn btn-primary" onclick="GuardarExperiencia()"><a href=""><span class="glyphicon glyphicon-ok-sign"></span> EVALUAR</a></div>
             </div>
        </div>
        
        
    </div>

<%--</body>
</html>--%>
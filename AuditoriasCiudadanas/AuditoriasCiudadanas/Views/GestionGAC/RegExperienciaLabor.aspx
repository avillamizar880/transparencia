<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegExperienciaLabor.aspx.cs" Inherits="AuditoriasCiudadanas.Views.GestionGAC.RegExperienciaLabor" %>
    <div class="container">
    <h1 class="text-center">Registrar Experiencia</h1>
    
    	<div class="w60 center-block">
        
    	<form>
        	
            	<div class="row">
                <div class="col-sm-12 singleChoise">
                <div class="form-group required">
               	<label for="descTxt">Descripción</label>
                <span class="label label-default fr">0/300</span>
                <textarea class="form-control" rows="5" id="c1"></textarea>
                </div>
                <p>Adjunte achivos multimedia</p>
                    <div class="btn-group btn-group-justified" role="group" aria-label="...">
                      <div class="btn-group" role="group">
                        <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-volume-up"></span> Audio</button>
                      </div>
                      <div class="btn-group" role="group">
                        <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-camera"></span> Imagen</button>
                      </div>
                      <div class="btn-group" role="group">
                        <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-film"></span> Video</button>
                      </div>
                      <div class="btn-group" role="group">
                        <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-paperclip"></span> Documento</button>
                      </div>
                    </div>
                </div>
                </div>
             	
             
             
             
        
        </form>
        <!--BOTONERA-->
             <div class="botonera text-center">
              	<div class="btn btn-primary"><a href=""><span class="glyphicon glyphicon-ok-sign"></span>Guardar</a></div>
             </div>
        </div>
        
        
    </div>
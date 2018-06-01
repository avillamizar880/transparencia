<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PublicarNoticias.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Administracion.PublicarNoticias" %>

<%--<script type="text/javascript">
			$(document).ready(function() {
			    BuscarTotalNoticias();
			    $('[data-toggle="tooltip"]').tooltip();

			    $("#txtPalabraClaveNoticias").keypress(function (e) {
			        if (e.which == 13)
			        {
			            BuscarTotalNoticias();
			        }
			    });

			});
</script>--%>

<div class="container">
    	<h1 class="text-center">Noticias</h1>
        <div class="well text-center">
         	<div class="btn btn-info mb15"><span class="glyphicon glyphicon-plus"></span> Nueva Noticia</div>  
         </div>
        <div class="noticiasBox">
        	
          <div class="list-group">
            	<div class="list-group-item">
            
              	<div class="col-sm-3"><p class="list-group-item-text"><a href="">Titulo Noticia Titulo Noticia Titulo Noticia Titulo Noticia</a></p> </div>
                <div class="col-sm-1"><span>26/06/2018</span> </div>
                <div class="col-sm-5"><p>Maecenas sodales dignissim augue, vitae ornare mauris. Praesent vel dictum enim, eu consectetur orci. Vivamus commodo metus ut luctus placerat.</p></div>
                <div class="col-sm-3">
                <div class="btn-group btn-group-justified" role="group" aria-label="...">
                              
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-camera"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-film"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-paperclip"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-share-alt"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-edit"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-trash"></span></button>
                              </div>
                              
                            </div>
                </div>
               	</div>
                <div class="list-group-item">
            
              	<div class="col-sm-3"><p class="list-group-item-text"><a href="">Titulo Noticia Titulo Noticia Titulo Noticia Titulo Noticia</a></p> </div>
                <div class="col-sm-1"><span>26/06/2018</span> </div>
                <div class="col-sm-5"><p>Maecenas sodales dignissim augue, vitae ornare mauris. Praesent vel dictum enim, eu consectetur orci. Vivamus commodo metus ut luctus placerat.</p></div>
                <div class="col-sm-3">
                <div class="btn-group btn-group-justified" role="group" aria-label="...">
                              
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-camera"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-film"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-paperclip"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-share-alt"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-edit"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-trash"></span></button>
                              </div>
                              
                            </div>
                </div>
               	</div>
                <div class="list-group-item">
            
              	<div class="col-sm-3"><p class="list-group-item-text"><a href="">Titulo Noticia Titulo Noticia Titulo Noticia Titulo Noticia</a></p> </div>
                <div class="col-sm-1"><span>26/06/2018</span> </div>
                <div class="col-sm-5"><p>Maecenas sodales dignissim augue, vitae ornare mauris. Praesent vel dictum enim, eu consectetur orci. Vivamus commodo metus ut luctus placerat.</p></div>
                <div class="col-sm-3">
                <div class="btn-group btn-group-justified" role="group" aria-label="...">
                              
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-camera"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-film"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-paperclip"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-share-alt"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-edit"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-trash"></span></button>
                              </div>
                              
                            </div>
                </div>
               	</div>
                <div class="list-group-item">
            
              	<div class="col-sm-3"><p class="list-group-item-text"><a href="">Titulo Noticia Titulo Noticia Titulo Noticia Titulo Noticia</a></p> </div>
                <div class="col-sm-1"><span>26/06/2018</span> </div>
                <div class="col-sm-5"><p>Maecenas sodales dignissim augue, vitae ornare mauris. Praesent vel dictum enim, eu consectetur orci. Vivamus commodo metus ut luctus placerat.</p></div>
                <div class="col-sm-3">
                <div class="btn-group btn-group-justified" role="group" aria-label="...">
                              
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-camera"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-film"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-paperclip"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-share-alt"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-edit"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-trash"></span></button>
                              </div>
                              
                            </div>
                </div>
               	</div>
                <div class="list-group-item">
            
              	<div class="col-sm-3"><p class="list-group-item-text"><a href="">Titulo Noticia Titulo Noticia Titulo Noticia Titulo Noticia</a></p> </div>
                <div class="col-sm-1"><span>26/06/2018</span> </div>
                <div class="col-sm-5"><p>Maecenas sodales dignissim augue, vitae ornare mauris. Praesent vel dictum enim, eu consectetur orci. Vivamus commodo metus ut luctus placerat.</p></div>
                <div class="col-sm-3">
                <div class="btn-group btn-group-justified" role="group" aria-label="...">
                              
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-camera"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-film"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-paperclip"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-share-alt"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-edit"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-trash"></span></button>
                              </div>
                              
                            </div>
                </div>
               	</div>
                <div class="list-group-item">
            
              	<div class="col-sm-3"><p class="list-group-item-text"><a href="">Titulo Noticia Titulo Noticia Titulo Noticia Titulo Noticia</a></p> </div>
                <div class="col-sm-1"><span>26/06/2018</span> </div>
                <div class="col-sm-5"><p>Maecenas sodales dignissim augue, vitae ornare mauris. Praesent vel dictum enim, eu consectetur orci. Vivamus commodo metus ut luctus placerat.</p></div>
                <div class="col-sm-3">
                <div class="btn-group btn-group-justified" role="group" aria-label="...">
                              
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-camera"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-film"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-paperclip"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-share-alt"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-edit"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-trash"></span></button>
                              </div>
                              
                            </div>
                </div>
               	</div>
                <div class="list-group-item">
            
              	<div class="col-sm-3"><p class="list-group-item-text"><a href="">Titulo Noticia Titulo Noticia Titulo Noticia Titulo Noticia</a></p> </div>
                <div class="col-sm-1"><span>26/06/2018</span> </div>
                <div class="col-sm-5"><p>Maecenas sodales dignissim augue, vitae ornare mauris. Praesent vel dictum enim, eu consectetur orci. Vivamus commodo metus ut luctus placerat.</p></div>
                <div class="col-sm-3">
                <div class="btn-group btn-group-justified" role="group" aria-label="...">
                              
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-camera"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-film"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-paperclip"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-share-alt"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-edit"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-trash"></span></button>
                              </div>
                              
                            </div>
                </div>
               	</div>
                <div class="list-group-item">
            
              	<div class="col-sm-3"><p class="list-group-item-text"><a href="">Titulo Noticia Titulo Noticia Titulo Noticia Titulo Noticia</a></p> </div>
                <div class="col-sm-1"><span>26/06/2018</span> </div>
                <div class="col-sm-5"><p>Maecenas sodales dignissim augue, vitae ornare mauris. Praesent vel dictum enim, eu consectetur orci. Vivamus commodo metus ut luctus placerat.</p></div>
                <div class="col-sm-3">
                <div class="btn-group btn-group-justified" role="group" aria-label="...">
                              
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-camera"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-film"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-paperclip"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-share-alt"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-edit"></span></button>
                              </div>
                              <div class="btn-group" role="group">
                                <button type="button" class="btn btn-default"><span class="glyphicon glyphicon-trash"></span></button>
                              </div>
                              
                            </div>
                </div>
               	</div>
          </div>
          
           
           
         </div>
        
        <!--PAGINACIÓN-->
       <div class="col-md-12 text-center">
	           		<nav aria-label="Page navigation">
                      <ul class="pagination">
                        <li>
                          <a href="#" aria-label="Previous">
                            <span aria-hidden="true">&laquo;</span>
                          </a>
                        </li>
                        <li><a href="#">1</a></li>
                        <li><a href="#">2</a></li>
                        <li><a href="#">3</a></li>
                        <li><a href="#">4</a></li>
                        <li><a href="#">5</a></li>
                        <li>
                          <a href="#" aria-label="Next">
                            <span aria-hidden="true">&raquo;</span>
                          </a>
                        </li>
                      </ul>
                    </nav>
               </div>
         
         
       </div> <%--Fin div Container--%>
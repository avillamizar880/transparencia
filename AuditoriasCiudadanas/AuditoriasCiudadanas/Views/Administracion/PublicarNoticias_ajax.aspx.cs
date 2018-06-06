using System;
using System.Web.UI;

namespace AuditoriasCiudadanas.Views.Administracion
{
  public partial class PublicarNoticias_ajax : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      Controllers.PublicarNoticiasCampanasController datosNoticias = new Controllers.PublicarNoticiasCampanasController();
      if (Request.Form != null)
      {
        for (var i = 0; i < Request.Form.AllKeys.Length; i++)
          if (Request.Form.AllKeys[i] != null)
            switch (Request.Form.AllKeys[i].ToString().ToUpper())
            {
              case "BUSCARTOTALNOTICIASPUBLICADAS":
                Response.Write(datosNoticias.ObtenerTotalNoticiasPublicadas(Request.Form[i].ToString()));
                break;
              case "BUSCARNOTICIASPUBLICADASPALABRACLAVE":
                var parametrosConsulta = Request.Form[i].ToString().Split('*');
                if (parametrosConsulta.Length >= 3)
                {
                  var numPag = 1;
                  var tamanoPag = 20;
                  if (parametrosConsulta[1] != string.Empty && parametrosConsulta[2] != string.Empty && int.TryParse(parametrosConsulta[1], out numPag) && int.TryParse(parametrosConsulta[2], out tamanoPag)) Response.Write(datosNoticias.ObtenerNoticiasPublicadasXPalabraClave(parametrosConsulta[0], numPag, tamanoPag));
                  else Response.Write(datosNoticias.ObtenerNoticiasPublicadasXPalabraClave(parametrosConsulta[0], 1, 20));
                }
                else
                  Response.Write(datosNoticias.ObtenerNoticiasPublicadasXPalabraClave(Request.Form[i].ToString(), 1, 20));
                break;
              case "ELIMINARNOTICIA":
                var parametrosEliminar = Request.Form[i].ToString().Split('*');
                if (parametrosEliminar.Length >= 2)
                {
                  int idNoticiaEliminar = 0;
                  int idUsuarioElimina = 0;
                  int.TryParse(parametrosEliminar[0], out idNoticiaEliminar);
                  int.TryParse(parametrosEliminar[1], out idUsuarioElimina);
                  Response.Write(datosNoticias.EliminarNoticia(idNoticiaEliminar, idUsuarioElimina));
                }
                break;
              case "PUBLICARNOTICIA":
                var parametrosPublicar = Request.Form[i].ToString().Split('*');
                if (parametrosPublicar.Length >= 2)
                {
                  int idNoticiaPublicar = 0;
                  int idUsuarioPublica = 0;
                  int.TryParse(parametrosPublicar[0], out idNoticiaPublicar);
                  int.TryParse(parametrosPublicar[1], out idUsuarioPublica);
                  Response.Write(datosNoticias.PublicarNoticia(idNoticiaPublicar, idUsuarioPublica));
                }
                break;
              case "EDITARNOTICIA":
                Response.Write(datosNoticias.EditarNoticia(Request.Form[i].ToString()));
                break;
              case "GUARDARNOTICIA":
                Response.Write(datosNoticias.GuardarNoticia(Request.Form[i].ToString()));
                break;

            }
        }
    }
  }
} 
using System;

namespace AuditoriasCiudadanas.Views.Administracion
{
  public partial class Campanas_ajax : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      Controllers.PublicarNoticiasCampanasController datosCampanas = new Controllers.PublicarNoticiasCampanasController();
      if (Request.Form != null)
      {
        for (var i = 0; i < Request.Form.AllKeys.Length; i++)
          if (Request.Form.AllKeys[i] != null)
            switch (Request.Form.AllKeys[i].ToString().ToUpper())
            {
              case "BUSCARTOTALCAMPANASPUBLICADAS":
                Response.Write(datosCampanas.ObtenerTotalCampanasPublicadas(Request.Form[i].ToString()));
                break;
              case "BUSCARCAMPANASPUBLICADASPALABRACLAVE":
                var parametrosConsulta = Request.Form[i].ToString().Split('*');
                if (parametrosConsulta.Length >= 3)
                {
                  var numPag = 1;
                  var tamanoPag = 20;
                  if (parametrosConsulta[1] != string.Empty && parametrosConsulta[2] != string.Empty && int.TryParse(parametrosConsulta[1], out numPag) && int.TryParse(parametrosConsulta[2], out tamanoPag)) Response.Write(datosCampanas.ObtenerNoticiasPublicadasXPalabraClave(parametrosConsulta[0], numPag, tamanoPag));
                  else Response.Write(datosCampanas.ObtenerCampanasPublicadasXPalabraClave(parametrosConsulta[0], 1, 20));
                }
                else
                  Response.Write(datosCampanas.ObtenerCampanasPublicadasXPalabraClave(Request.Form[i].ToString(), 1, 20));
                break;
              case "ELIMINARCAMPANA":
                var parametrosEliminar = Request.Form[i].ToString().Split('*');
                if (parametrosEliminar.Length >= 2)
                {
                  int idNoticiaEliminar = 0;
                  int idUsuarioElimina = 0;
                  int.TryParse(parametrosEliminar[0], out idNoticiaEliminar);
                  int.TryParse(parametrosEliminar[1], out idUsuarioElimina);
                  Response.Write(datosCampanas.EliminarCampana(idNoticiaEliminar, idUsuarioElimina));
                }
                break;
              case "PUBLICARCAMPANA":
                var parametrosPublicar = Request.Form[i].ToString().Split('*');
                if (parametrosPublicar.Length >= 2)
                {
                  int idNoticiaPublicar = 0;
                  int idUsuarioPublica = 0;
                  int.TryParse(parametrosPublicar[0], out idNoticiaPublicar);
                  int.TryParse(parametrosPublicar[1], out idUsuarioPublica);
                  Response.Write(datosCampanas.PublicarCampana(idNoticiaPublicar, idUsuarioPublica));
                }
                break;
              case "EDITARCAMPANA":
                Response.Write(datosCampanas.EditarCampana(Request.Form[i].ToString()));
                break;
              case "GUARDARCAMPANA":
                Response.Write(datosCampanas.GuardarCampana(Request.Form[i].ToString()));
                break;

            }
      }
    }
  }
}
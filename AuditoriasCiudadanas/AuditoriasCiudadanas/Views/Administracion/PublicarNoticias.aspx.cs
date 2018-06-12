using System;

namespace AuditoriasCiudadanas.Views.Administracion
{
  public partial class PublicarNoticias : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (Session["idUsuario"] != null)
      {
        hdIdUsuario.Value = Session["idUsuario"].ToString();
        hfidUsuarioRecursoMulti.Value= Session["idUsuario"].ToString();
        hfidUsuarioRecursoMultiEditar.Value = Session["idUsuario"].ToString();
      }
    }
  }
}
using System;

namespace AuditoriasCiudadanas.Views.Administracion
{
  public partial class Campanas : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (Session["idUsuario"] != null) hdIdUsuario.Value = Session["idUsuario"].ToString();
    }
  }
}
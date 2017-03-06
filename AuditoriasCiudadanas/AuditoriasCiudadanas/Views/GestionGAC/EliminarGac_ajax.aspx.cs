using System;

namespace AuditoriasCiudadanas.Views.GestionGAC
{
  public partial class EliminarGac_ajax : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      Controllers.ProyectosController datos = new Controllers.ProyectosController();
      if (Request.Form != null)
        for (var i = 0; i < Request.Form.AllKeys.Length; i++)
          if (Request.Form.AllKeys[i] != null)
            switch (Request.Form.AllKeys[i].ToString().ToUpper())
            {
              case "ELIMINARGAC":
                Response.Write(datos.EliminarGrupoAuditor(Request.Form[i].ToString()));
                break;
            }
    }
  }
}
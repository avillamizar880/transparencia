using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Informacion
{
  public partial class verDetalleNoticia_ajax : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      Controllers.InformacionController datosNoticias = new Controllers.InformacionController();
      if (Request.Form != null)
      {
        for (var i = 0; i < Request.Form.AllKeys.Length; i++)
          if (Request.Form.AllKeys[i] != null)
            switch (Request.Form.AllKeys[i].ToString().ToUpper())
            {
              case "OBTENERDETALLENOTICIA":
                int idNoticia = 0;
                int.TryParse(Request.Form[i].ToString(), out idNoticia);
                Response.Write(datosNoticias.ObtenerDetalleNoticia(idNoticia));
                break;
            }
      }
    }
  }
}
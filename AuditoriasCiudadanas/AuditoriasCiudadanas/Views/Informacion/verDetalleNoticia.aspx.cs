using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Informacion
{
  public partial class verDetalleNoticia : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      Controllers.InformacionController datosPlanTrabajo = new Controllers.InformacionController();
      if (Request.Form != null)
      {
        for (var i = 0; i < Request.Form.AllKeys.Length; i++)
          if (Request.Form.AllKeys[i] != null)
            switch (Request.Form.AllKeys[i].ToString().ToUpper())
            {
              case "PARAMETROINICIO":
                hfIdDetalleNoticia.Value = Request.Form[i].ToString();
                break;
            }
      }
    }
  }
}
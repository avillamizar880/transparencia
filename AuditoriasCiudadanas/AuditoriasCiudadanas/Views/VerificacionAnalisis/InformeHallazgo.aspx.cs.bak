using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.GrupoAuditor
{
  public partial class InformeHallazgo : App_Code.PageSession { 
    protected void Page_Load(object sender, EventArgs e)
    {
      if (Request.Form != null)
      {
        for (var i = 0; i < Request.Form.AllKeys.Length; i++)
          if (Request.Form.AllKeys[i] != null)
            switch (Request.Form.AllKeys[i].ToString().ToUpper())
            {
              case "PARAMETROINICIO":
                int idGrupoGac = 0;
                hfIdGrupoGac.Value = int.TryParse(Request.Form[i].ToString(), out idGrupoGac)==true ? idGrupoGac.ToString():16.ToString();
                if (Session["idUsuario"] != null) hfIdUsuario.Value = Session["idUsuario"].ToString();
                break;
            }
      }
    }
  }
}
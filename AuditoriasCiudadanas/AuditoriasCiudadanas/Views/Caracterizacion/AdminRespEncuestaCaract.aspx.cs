using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Caracterizacion
{
  public partial class AdminRespEncuestaCaract : App_Code.PageSession
    {
      public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
      {
          //No obliga a a la página a tener un form incluido
      }
      
      protected void Page_Load(object sender, EventArgs e)
    {
        NameValueCollection pColl = Request.Params;
        string fechasCorte = "";
        if (pColl.AllKeys.Contains("fechasCorte"))
        {
            fechasCorte = Request.Params.GetValues("fechasCorte")[0].ToString();
        }        
        var fechasConsultar = fechasCorte.Split('*');
        if (fechasConsultar.Length >= 2)
        {
            hdFechaIni.Value = fechasConsultar[0].ToString();
            hdFechaFin.Value = fechasConsultar[1].ToString();
        }
        
    }
  }
}
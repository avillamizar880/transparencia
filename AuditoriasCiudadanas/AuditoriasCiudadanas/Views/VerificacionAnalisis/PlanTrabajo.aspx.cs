using System;

namespace AuditoriasCiudadanas.Views.VerificacionAnalisis
{
  public partial class PlanTrabajo : System.Web.UI.Page
  {
      public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
      {
          //No obliga a a la página a tener un form incluido
      }

      
    protected void Page_Load(object sender, EventArgs e)
    {
      Controllers.PlanTrabajoController datosPlanTrabajo = new Controllers.PlanTrabajoController();
      if (Request.Form != null)
      {
        for (var i = 0; i < Request.Form.AllKeys.Length; i++)
          if (Request.Form.AllKeys[i] != null)
            switch (Request.Form.AllKeys[i].ToString().ToUpper())
            {
              case "PARAMETROINICIO":
                var parametrosInicio = Request.Form[i].ToString().Split('*');
                hfcodigoBPIN.Value = parametrosInicio[0].ToString();
                hfidUsuario.Value = Session["idUsuario"]!=null?Session["idUsuario"].ToString():string.Empty;
                break;
            }
      }
    }
  }
}
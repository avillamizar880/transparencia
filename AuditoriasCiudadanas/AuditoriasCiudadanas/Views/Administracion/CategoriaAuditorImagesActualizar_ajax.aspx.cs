using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.IO;
using System.Configuration;
using System.Data;
using Newtonsoft.Json;

namespace AuditoriasCiudadanas.Views.Administracion
{
  public partial class CategoriaAuditorImagesActualizar_ajax : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      Controllers.AuditoriasController datos = new Controllers.AuditoriasController();
      if (Request.Form != null)
      {
        for (var i = 0; i < Request.Form.AllKeys.Length; i++)
          if (Request.Form.AllKeys[i] != null)
            switch (Request.Form.AllKeys[i].ToString().ToUpper())
            {
              case "ACTUALIZARREGISTROAUDITOR":
                Response.Write(datos.GuardarTipoAuditoria(Request.Form[i]));
                break;
            }
      }
    }
  }
}
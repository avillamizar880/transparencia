using System;
using System.Web.UI;

namespace AuditoriasCiudadanas.Views.Administracion
{
  public partial class CategoriasAuditor_ajax : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      Controllers.AuditoriasController datos = new Controllers.AuditoriasController();
      if (Request.Form != null)
        for (var i = 0; i < Request.Form.AllKeys.Length; i++)
          if (Request.Form.AllKeys[i] != null)
            switch (Request.Form.AllKeys[i].ToString().ToUpper())
            {
              case "CATEGORIASAUDITOR":
                Response.Write(datos.ObtenerCategoriasAuditor());
                break;
              case "GUARDAR":
                Response.Write(datos.GuardarTipoAuditoria(Request.Form[i].ToString()));
                break;
              case "SUBIRIMAGEN":
                Response.Write(datos.SubirImagen(Request.Form[i].ToString()));
                break;
              case "ELIMINAR":
                int idCategoriaAuditor = 0;
                int.TryParse(Request.Form[i].ToString(), out idCategoriaAuditor);
                Response.Write(datos.EliminarCategoriasAuditor(idCategoriaAuditor));
                break;
            }
    }
  }
}
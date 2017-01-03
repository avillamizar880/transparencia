using System;
using System.Configuration;
using System.IO;
using System.Web;
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
                var parametros = Request.Form[i].ToString().Split('*');
                string rutaImagen = string.Empty;
                int idCategoriaAuditor = 0;
                int.TryParse(parametros[0], out idCategoriaAuditor);
                if (parametros.Length > 1) rutaImagen = parametros[1];
                var rta = datos.EliminarCategoriasAuditor(idCategoriaAuditor);
                if (rta == true)
                {
                  #region Borramos el archivo en el servidor
                  string dirupload = ConfigurationManager.AppSettings["ruta_categoria_auditor"];
                  string Serverpath = HttpContext.Current.Server.MapPath("~/" + dirupload);
                  if (File.Exists(Serverpath + "\\" + rutaImagen)) File.Delete(Serverpath + "\\" + rutaImagen);
                  #endregion Borramos el archivo en el servidor
                }
                Response.Write(rta);
                break;
            }
    }
  }
}
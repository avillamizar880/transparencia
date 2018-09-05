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
  public partial class CategoriaAuditorImages_ajax : System.Web.UI.Page
    {
    protected void Page_Load(object sender, EventArgs e)
    {
      string idTipoAuditor =string.Empty;
      string nombre = string.Empty;
      string descrip = string.Empty;
      string idUsuario = string.Empty;
      string rutaImagen = string.Empty;
      string limiteinferior = string.Empty;
      string limitesuperior = string.Empty;
      string cod_error = string.Empty;
      string msg_error = string.Empty;
      string sal = string.Empty;
      try
      {
        if (HttpContext.Current.Request.HttpMethod == "POST")
        {
          NameValueCollection pColl = Request.Params;
          if (pColl.AllKeys.Contains("idTipoAuditor")) idTipoAuditor = Request.Params.GetValues("idTipoAuditor")[0].ToString()==string.Empty? "0": Request.Params.GetValues("idTipoAuditor")[0].ToString();
          if (pColl.AllKeys.Contains("nombre")) nombre = Request.Params.GetValues("nombre")[0].ToString();
          if (pColl.AllKeys.Contains("descrip")) descrip = Request.Params.GetValues("descrip")[0].ToString();
          if (pColl.AllKeys.Contains("idUsuario"))idUsuario = Request.Params.GetValues("idUsuario")[0].ToString();
          if (pColl.AllKeys.Contains("rutaImagen"))rutaImagen= DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + "_" + Request.Params.GetValues("rutaImagen")[0].ToString();
          if (pColl.AllKeys.Contains("limiteinferior")) limiteinferior = Request.Params.GetValues("limiteinferior")[0].ToString();
          if (pColl.AllKeys.Contains("limitesuperior")) limitesuperior = Request.Params.GetValues("limitesuperior")[0].ToString();
          string pathrefer = Request.UrlReferrer.ToString();
          string dirupload = ConfigurationManager.AppSettings["ruta_categoria_auditor"];
          string Serverpath = HttpContext.Current.Server.MapPath("~/" + dirupload);
          var postedFile = Request.Files[0];
          string file;
          if (HttpContext.Current.Request.Browser.Browser.ToUpper() == "IE")//Para versiones de IE inferiores a 11
          {
            string[] files = postedFile.FileName.Split(new char[] { '\\' });
            file = files[files.Length - 1];
          }
          else file = postedFile.FileName;// In case of other browsers
          if (!Directory.Exists(Serverpath))Directory.CreateDirectory(Serverpath);
          string fileDirectory = Serverpath;
          if (File.Exists(fileDirectory + "\\" + rutaImagen)) File.Delete(fileDirectory + "\\" + rutaImagen);
          fileDirectory = Serverpath + "\\" + rutaImagen;
          postedFile.SaveAs(fileDirectory);
          if (File.Exists(fileDirectory))
          {
            Response.AddHeader("Vary", "Accept");
            try
            {
              if (Request["HTTP_ACCEPT"].Contains("application/json"))Response.ContentType = "application/json";
              else Response.ContentType = "text/plain";
            }
            catch
            {
              Response.ContentType = "text/plain";
            }
            Controllers.AuditoriasController datos = new Controllers.AuditoriasController();
            sal=datos.GuardarTipoAuditoria(idTipoAuditor + '*' + nombre + '*' + descrip + '*' + rutaImagen + '*' + limiteinferior + '*' + limitesuperior);
            string[] separador = new string[] { "<||>" };
            var result = sal.Split(separador, StringSplitOptions.None);
            cod_error = result[0];
            msg_error = result[1];
          }
          else
          {
            sal = "-1<||>Error al subir archivo";
            cod_error = "-1";
            msg_error = "Error al subir al archivo";
          }
          DataTable dterrores = new DataTable();
          dterrores.Columns.Add("cod_error", typeof(string));
          dterrores.Columns.Add("msg_error", typeof(string));
          dterrores.Rows.Add(cod_error, msg_error);
          dterrores.TableName = "tabla";
          sal = "{\"Head\":" + JsonConvert.SerializeObject(dterrores) + "}";
          Response.Write(sal);
        }

      }
      catch (Exception exp)
      {
        Response.Write(exp.Message);
      }
    }
  }
}
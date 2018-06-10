using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace AuditoriasCiudadanas.Views.Administracion
{
  public partial class DetalleRecursoMultimedia_ajax : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      string idDetalleRecurso = string.Empty;
      string idRecurso = string.Empty;
      string rutaImagen = string.Empty;
      string idUsuario = string.Empty;
      string cod_error = string.Empty;
      string msg_error = string.Empty;
      string sal = string.Empty;
      try
      {
        if (HttpContext.Current.Request.HttpMethod == "POST")
        {
          if (Session["idUsuario"] == null) Response.Write("Usted no cuenta con permiso para subir la imagen");
          else
          {
            NameValueCollection pColl = Request.Params;
            if (pColl.AllKeys.Contains("idDetalleRecurso")) idDetalleRecurso = Request.Params.GetValues("idDetalleRecurso")[0].ToString();
            if (pColl.AllKeys.Contains("idRecurso")) idRecurso = Request.Params.GetValues("idRecurso")[0].ToString();
            if (pColl.AllKeys.Contains("rutaImagen"))
            {
              var elementos= Request.Params.GetValues("rutaImagen")[0].Split(new char[] { '\\' });
              rutaImagen = elementos[elementos.Length-1].ToString();
            }
            if (pColl.AllKeys.Contains("idUsuario")) idUsuario = Request.Params.GetValues("idUsuario")[0].ToString();
            string pathrefer = Request.UrlReferrer.ToString();
            string dirupload = ConfigurationManager.AppSettings["ruta_campanas_noticias"];
            string Serverpath = HttpContext.Current.Server.MapPath("~/" + dirupload);
            var postedFile = Request.Files[0];
            string file;
            if (HttpContext.Current.Request.Browser.Browser.ToUpper() == "IE")//Para versiones de IE inferiores a 11
            {
              string[] files = postedFile.FileName.Split(new char[] { '\\' });
              file = files[files.Length - 1];
            }
            else file = postedFile.FileName;// In case of other browsers
            if (!Directory.Exists(Serverpath)) Directory.CreateDirectory(Serverpath);
            string fileDirectory = Serverpath;
            if (File.Exists(fileDirectory + "\\" + rutaImagen)) File.Delete(fileDirectory + "\\" + idRecurso + "_" + rutaImagen);
            fileDirectory = Serverpath + "\\" + idRecurso +"_"+ rutaImagen;
            postedFile.SaveAs(fileDirectory);
            if (File.Exists(fileDirectory))
            {
              Response.AddHeader("Vary", "Accept");
              try
              {
                if (Request["HTTP_ACCEPT"].Contains("application/json")) Response.ContentType = "application/json";
                else Response.ContentType = "text/plain";
              }
              catch
              {
                Response.ContentType = "text/plain";
              }
              Controllers.PublicarNoticiasCampanasController datosCampanasNoticias = new Controllers.PublicarNoticiasCampanasController();
              sal = datosCampanasNoticias.GuardarDetalleRecursoMultimedia(idDetalleRecurso +'*' + idRecurso + '*' + idRecurso + "_" + rutaImagen + '*'+ idUsuario);
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
      }
      catch (Exception exp)
      {
        Response.Write(exp.Message);
      }

    }
  }
}
using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.IO;
using System.Configuration;
using System.Data;
using Newtonsoft.Json;

namespace AuditoriasCiudadanas.Views.VerificacionAnalisis
{
  public partial class DetallePlanTrabajoRecursoMultimedia_ajax : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      string fechaRecursoMultimedia = string.Empty;
      string descripcionRecursoMultimedia = string.Empty;
      string responsable = string.Empty;
      string lugar = string.Empty;
      string idUsuario = string.Empty;
      string rutaImagen = string.Empty;
      string idTarea = string.Empty;
      string idTipoAdjunto = "1";
      string cod_error = string.Empty;
      string msg_error = string.Empty;
      string sal = string.Empty;
      try
      {
        if (HttpContext.Current.Request.HttpMethod == "POST")
        {
          //Session["idUsuario"] = "4";
          if (Session["idUsuario"] == null) Response.Write("Usted no cuenta con permiso para subir la imagen");
          else
          {
            idUsuario = Session["idUsuario"].ToString();
            NameValueCollection pColl = Request.Params;
            if (pColl.AllKeys.Contains("idTarea")) idTarea = Request.Params.GetValues("idTarea")[0].ToString() == string.Empty ? "0" : Request.Params.GetValues("idTarea")[0].ToString();
            //if (pColl.AllKeys.Contains("idTipoAdjunto")) idTipoAdjunto = Request.Params.GetValues("idTipoAdjunto")[0].ToString() == string.Empty ? "0" : Request.Params.GetValues("idTipoAdjunto")[0].ToString();
            if (pColl.AllKeys.Contains("fecha")) fechaRecursoMultimedia = Request.Params.GetValues("fecha")[0].ToString() == string.Empty ? "0" : Request.Params.GetValues("FechaRecursoMultimedia")[0].ToString();
            if (pColl.AllKeys.Contains("DescripcionRecursoMultimedia")) descripcionRecursoMultimedia = Request.Params.GetValues("DescripcionRecursoMultimedia")[0].ToString();
            if (pColl.AllKeys.Contains("responsable")) responsable = Request.Params.GetValues("responsable")[0].ToString();
            if (pColl.AllKeys.Contains("lugar")) lugar = Request.Params.GetValues("lugar")[0].ToString();
            if (pColl.AllKeys.Contains("url"))
            {
              var rutaImagenCompleta = Request.Params.GetValues("url")[0].ToString().Split('\\');
              rutaImagen = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + "_" + idUsuario + "_" + rutaImagenCompleta[rutaImagenCompleta.Length-1];
            }
            string pathrefer = Request.UrlReferrer.ToString();
            string dirupload = ConfigurationManager.AppSettings["ruta_detalle_recurso_fotografico"];
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
            if (File.Exists(fileDirectory + "\\" + rutaImagen)) File.Delete(fileDirectory + "\\" + rutaImagen);
            fileDirectory = Serverpath + "\\" + rutaImagen;
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
              Controllers.PlanTrabajoController datosPlanTrabajo = new Controllers.PlanTrabajoController();
              sal = datosPlanTrabajo.GuardarRegistroMultimedia(idTarea + '*' + idTipoAdjunto + '*' + fechaRecursoMultimedia + '*' + rutaImagen + '*' + descripcionRecursoMultimedia + '*' + responsable + '*' + lugar + '*' + idUsuario);
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
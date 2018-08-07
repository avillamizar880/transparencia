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
  public partial class DetallePlanTrabajoBorrarAsistencia_ajax : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      string rutaImagen = string.Empty;
      string idUsuario = string.Empty;
      string cod_error = string.Empty;
      string msg_error = string.Empty;
      string sal = string.Empty;
      try
      {
        if (HttpContext.Current.Request.HttpMethod == "POST")
        {
          if (Session["idUsuario"] == null) Response.Write("Usted no cuenta con permiso para borrar la imagen");
          else
          {
            idUsuario = Session["idUsuario"].ToString();
            NameValueCollection pColl = Request.Params;
            if (pColl.AllKeys.Contains("key")) rutaImagen = Request.Params.GetValues("key")[0].ToString();
            //if (ObtenerCondicionEstadoTareaNombreUrl(rutaImagen))
            //{
              string pathrefer = Request.UrlReferrer.ToString();
              string dirupload = ConfigurationManager.AppSettings["ruta_detalle_acta_reunion"];
              string Serverpath = HttpContext.Current.Server.MapPath("~/" + dirupload);
              string fileDirectory = Serverpath;
              if (File.Exists(fileDirectory + "\\" + rutaImagen))
              {
                File.Delete(fileDirectory + "\\" + rutaImagen);
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
              }
              else
              {
                sal = "-1<||>Error al borrar el archivo. Se intenta borrar pero no es posible por restricción o acceso";
                cod_error = "-1";
                msg_error = "Error al borrar el archivo";
              }
              #region Borramos el registro en la bd
              Controllers.PlanTrabajoController datosPlanTrabajo = new Controllers.PlanTrabajoController();
              sal = datosPlanTrabajo.EliminarRegistroMultimediaxUrl(rutaImagen + '*' + idUsuario);
              string[] separador = new string[] { "<||>" };
              var result = sal.Split(separador, StringSplitOptions.None);
              cod_error = result[0];
              if (result.Length > 1) msg_error = result[1];
              #endregion Borramos el registro en la bd
              DataTable dterrores = new DataTable();
              dterrores.Columns.Add("cod_error", typeof(string));
              dterrores.Columns.Add("msg_error", typeof(string));
              dterrores.Rows.Add(cod_error, msg_error);
              dterrores.TableName = "tabla";
              sal = "{\"Head\":" + JsonConvert.SerializeObject(dterrores) + "}";
              Response.Write(sal);
            //}
            //else
            //{
            //  Response.Write("Usted no puede eliminar la imagen seleccionada porque la tarea está finalizada.");
            //}
          }
        }

      }
      catch (Exception exp)
      {
        Response.Write(exp.Message);
      }
    }

    private bool ObtenerCondicionEstadoTareaNombreUrl(string rutaImagen)
    {
      Controllers.PlanTrabajoController datosPlanTrabajo = new Controllers.PlanTrabajoController();
      return datosPlanTrabajo.ObtenerEstadoTareaXRegistroMultimedia (rutaImagen);
    }
  }
}
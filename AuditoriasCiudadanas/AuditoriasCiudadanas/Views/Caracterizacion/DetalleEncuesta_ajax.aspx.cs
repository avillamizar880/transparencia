using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Data;
using System.IO;

namespace AuditoriasCiudadanas.Views.Caracterizacion
{
    public partial class DetalleEncuesta_ajax : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //dicccionario campos-etiqueta
            Dictionary<string, string> dicPreguntas = new Dictionary<string, string>();
            dicPreguntas.Add("Nombre", "Nombre Ciudadano");
            dicPreguntas.Add("email", "Correo electrónico");
            dicPreguntas.Add("Fecha", "Fecha Aplicación");
            dicPreguntas.Add("Localizacion", "Municipio al que pertenece");
            dicPreguntas.Add("Genero", "Género");
            dicPreguntas.Add("RangoEdad", "Rango de Edad");
            dicPreguntas.Add("Ocupacion", "Ocupación");
            dicPreguntas.Add("LugarResidencia", "Actualmente usted reside en:");
            dicPreguntas.Add("PerteneceMinoria", "¿Pertenece a una comunidad étnica minoritaria?");
            dicPreguntas.Add("PerteneceOrganizacionSocial", "¿Actualmente pertenece a alguna organización social o instancia de participación ciudadana?");
            dicPreguntas.Add("MecanismoHaParticipado", "Mecanismos de participación ciudadana que ha promovido o en los que ha participado en los últimos tres años");
            dicPreguntas.Add("RecursosAlcaldia", "¿La Alcaldía cuenta con recursos destinados para la promoción de la participación ciudadana en su territorio?");
            dicPreguntas.Add("AuditoriasVisiblesDNP", "¿El DNP ha adelantado Auditorías Visibles en su municipio");
            dicPreguntas.Add("PlanAccion", "La organización civil o instancia de participación con la que actualmente tiene vinculación, ¿cuenta con un plan de acción para orientar su labor de control social?");
            dicPreguntas.Add("EstrategiaHallazgos", "Por favor seleccione las estrategias, mecanismos o instrumentos que utiliza la ciudadanía para reportar los hallazgos que obtienen de su ejercicio de control social");
            dicPreguntas.Add("GestionAutoridades", "Desde su perspectiva, por favor califique la gestión de las autoridades locales en el momento de promover el control ciudadano a la gestión pública o a proyectos específicos");
            dicPreguntas.Add("EstrategiaSeguimiento", "Por favor seleccione las estrategias, mecanismos o instrumentos que utiliza la ciudadanía para hacer seguimiento a la gestión o a proyectos de las autoridades locales");
            dicPreguntas.Add("RadicacionDerechoPeticion", "Durante el año 2016, ¿usted ha radicado/presentado o ha tramitado una respuesta a al menos un derecho de petición donde se solicita el acceso a información específica o algún documento particular del municipio?");
            dicPreguntas.Add("FacilidadAccesoInfo", "Desde su experiencia, por favor califique la facilidad con la que se puede acceder a la información pública del municipio para hacer seguimiento a la gestión o proyectos de las autoridades locales");
            dicPreguntas.Add("CambiosGestion", "¿La labor de control social de las organizaciones sociales o instancias de participación ha motivado algún cambio en la gestión o proyectos de las autoridades locales?");
            dicPreguntas.Add("FrecuenciaSeguimiento", "Desde su experiencia, por favor califique la frecuencia con la que se hacen ejercicios de seguimiento a lo público o de control social sobre la gestión de las autoridades locales en su municipio");
            dicPreguntas.Add("PercepcionSeguridad", "Desde su percepción, ¿Usted considera que en su municipio existen condiciones adecuadas de seguridad para realizar control social?");
      if (HttpContext.Current.Request.HttpMethod == "POST" || HttpContext.Current.Request.HttpMethod == "GET")
            {
                string fecha_ini = "";
                string fecha_fin = "";
                DateTime fecha_ini_aux = DateTime.Parse("01/01/2015");
                DateTime fecha_fin_aux = DateTime.Parse("31/12/2017"); ;

                NameValueCollection pColl = Request.Params;
                if (pColl.AllKeys.Contains("fecha_ini")) {
                    fecha_ini = Request.Params.GetValues("fecha_ini")[0].ToString();
                    if (!string.IsNullOrEmpty(fecha_ini)) { 
                       //convertir fecha
                        string[] separador = new string[] { "/" };
                        var result = fecha_ini.Split(separador, StringSplitOptions.None);
                        fecha_ini = result[0].PadLeft(2, '0') + "/" + result[1].PadLeft(2, '0') + "/" + result[2];
                        fecha_ini_aux = DateTime.Parse(fecha_ini);
                    }
                }
                if (pColl.AllKeys.Contains("fecha_fin"))  {
                    fecha_fin = Request.Params.GetValues("fecha_fin")[0].ToString();
                    if (!string.IsNullOrEmpty(fecha_fin))
                    {
                        //convertir fecha
                        string[] separador = new string[] { "/" };
                        var result = fecha_fin.Split(separador, StringSplitOptions.None);
                        fecha_fin = result[0].PadLeft(2, '0') + "/" + result[1].PadLeft(2, '0') + "/" + result[2];
                        fecha_fin_aux = DateTime.Parse(fecha_fin);
                    }
                }

                //generacion excel
                AuditoriasCiudadanas.Controllers.CaracterizacionController datos = new AuditoriasCiudadanas.Controllers.CaracterizacionController();
                DataTable dtInfo = new DataTable("encuestas");
                dtInfo=datos.obtDetalleEncuesta(fecha_ini_aux, fecha_fin_aux);
                if (dtInfo.Rows.Count > 0) { 
                      foreach (KeyValuePair<string, string> kvp in dicPreguntas){
                        dtInfo.Columns[kvp.Key].ColumnName = kvp.Value.ToString();
                    }
                    AuditoriasCiudadanas.Controllers.ExcelExport datosExcel = new AuditoriasCiudadanas.Controllers.ExcelExport();
                    List<int> col_delete=new List<int>(new int[]{ 0, 1, 2 });
                    MemoryStream me_datos=datosExcel.ExportExcelFromDataTable("", dtInfo,col_delete);
                    byte[] str = me_datos.ToArray();
                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + "detalle_encuesta_" + DateTime.Now.Ticks);
                    Response.Charset = "UTF-8";
                    Response.BinaryWrite(str);
                    Response.End();
                    Response.Flush();
                    Response.Clear();
                }else{
                    Response.Write("<script>alert('No existen datos para exportar');</script>");
                }
                
            }
        }
    }
}
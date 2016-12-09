using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Data;

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
              //campos a visualizar
              //,[IdUsuario]
              //,[IdDivipola]
              //,[Fecha]
              //,[Genero]
              //,[RangoEdad]
              //,[Ocupacion]
              //,[Cargo]
              //,[LugarResidencia]
              //,[PerteneceMinoria]
              //,[PerteneceOrganizacionSocial]
              //,[ViculacionActual]
              //,[MecanismoHaParticipado]
              //,[EspaciosParticipadoCiudadano]
              //,[RecursosAlcaldia]
              //,[AuditoriasVisiblesDNP]
            
            //dicccionario campos-etiqueta
            Dictionary<string, string> dicPreguntas = new Dictionary<string, string>();
            dicPreguntas.Add("fecha", "Fecha Aplicación");
            dicPreguntas.Add("municipio", "Municipio al que pertenece");
            dicPreguntas.Add("genero", "Género");
            dicPreguntas.Add("RangoEdad", "Rango de Edad");
            dicPreguntas.Add("Ocupacion", "Ocupación");
            dicPreguntas.Add("Cargo", "Actualmente se desempeña como:");
            dicPreguntas.Add("LugarResidencia", "Actualmente usted reside en:");
            dicPreguntas.Add("PerteneceMinoria", "¿Pertenece a una comunidad étnica minoritaria?");
            dicPreguntas.Add("PerteneceOrganizacionSocial", "¿Actualmente pertenece a alguna organización social o instancia de participación ciudadana?");
            dicPreguntas.Add("ViculacionActual", "Organización(es) o instancia(s) a la que está vinculado");
            dicPreguntas.Add("MecanismoHaParticipado", "Mecanismos de participación ciudadana que ha promovido o en los que ha participado en los últimos tres años");
            dicPreguntas.Add("EspaciosParticipadoCiudadano", "Espacios en los que ha participado como ciudadano o funcionario público durante los últimos tres años en su municipio");
            dicPreguntas.Add("RecursosAlcaldia", "¿La Alcaldía cuenta con recursos destinados para la promoción de la participación ciudadana en su territorio?");
            dicPreguntas.Add("AuditoriasVisiblesDNP", "¿El DNP ha adelantado Auditorías Visibles en su municipio");
            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                int id_corte = 0;
                string fecha_ini = "";
                string fecha_fin = "";
                DateTime fecha_ini_aux=DateTime.Now;
                DateTime fecha_fin_aux = DateTime.Now;

                NameValueCollection pColl = Request.Params;
                if (pColl.AllKeys.Contains("id_corte")) {
                    id_corte = Convert.ToInt16(Request.Params.GetValues("id_corte")[0].ToString());
                }
                if (pColl.AllKeys.Contains("fecha_ini")) {
                    fecha_ini = Request.Params.GetValues("fecha_ini")[0].ToString();
                    if (!string.IsNullOrEmpty(fecha_ini)) { 
                       //convertir fecha
                        fecha_ini_aux = DateTime.Parse(fecha_ini);
                    }
                }

                if (pColl.AllKeys.Contains("fecha_fin"))  {
                    fecha_fin = Request.Params.GetValues("fecha_fin")[0].ToString();
                    if (!string.IsNullOrEmpty(fecha_fin))
                    {
                        //convertir fecha
                        fecha_fin_aux = DateTime.Parse(fecha_fin);
                    }
                }

                //generacion excel
                AuditoriasCiudadanas.Controllers.CaracterizacionController datos = new AuditoriasCiudadanas.Controllers.CaracterizacionController();
                DataTable dtInfo = datos.obtDetalleEncuesta(id_corte, fecha_ini_aux, fecha_fin_aux);
                DataTable dt_aux = new DataTable("encuestas");
                DataTable dt_all = dtInfo.Copy();
                dt_aux = dtInfo.Clone();
                DataRow  fila = dt_aux.NewRow();
                
                foreach (KeyValuePair<string, string> kvp in dicPreguntas)
                {
                    //DataColumn columna = dt_aux.Columns.Add(kvp.Key, typeof(string));
                    fila[kvp.Key] = kvp.Value;
                }
                dt_aux.Rows.Add(fila);
                dt_all.Merge(dt_aux, true); 



                


                    


                //DataTable workTable = new DataTable("Customers");

                //DataColumn workCol = workTable.Columns.Add("CustID", typeof(Int32));
                //workCol.AllowDBNull = false;
                //workCol.Unique = true;

                //workTable.Columns.Add("CustLName", typeof(String));
                //workTable.Columns.Add("CustFName", typeof(String));
                //workTable.Columns.Add("Purchases", typeof(Double));


            }
        }
    }
}
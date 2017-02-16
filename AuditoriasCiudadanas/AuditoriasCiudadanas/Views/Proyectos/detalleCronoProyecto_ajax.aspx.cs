using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Proyectos
{
    public partial class detalleCronoProyecto_ajax : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string bpin_proyecto = "";
            string outTxt = "";
            string mes_ini = "";
            string mes_fin = "";
            string anyo_ini = "";
            string anyo_fin = "";
            DateTime fecha_ini=DateTime.Now;
            DateTime fecha_fin=DateTime.Now;
            NameValueCollection pColl = Request.Params;

            if (pColl.AllKeys.Contains("bpinProyecto"))
            {
                bpin_proyecto = Request.Params.GetValues("bpinProyecto")[0].ToString();
            }
            if (pColl.AllKeys.Contains("mes_ini"))
            {
                mes_ini = Request.Params.GetValues("mes_ini")[0].ToString();
            }
            if (pColl.AllKeys.Contains("mes_fin"))
            
            {
                mes_fin = Request.Params.GetValues("mes_fin")[0].ToString();
            }
            if (pColl.AllKeys.Contains("anyo_ini"))
            {
                anyo_ini = Request.Params.GetValues("anyo_ini")[0].ToString();
            }
            if (pColl.AllKeys.Contains("anyo_fin"))
            {
               anyo_fin = Request.Params.GetValues("anyo_fin")[0].ToString();
            }

            if (!string.IsNullOrEmpty(mes_ini) && !string.IsNullOrEmpty(mes_fin) && !string.IsNullOrEmpty(anyo_ini) && !string.IsNullOrEmpty(anyo_fin)) { 
                int dias = DateTime.DaysInMonth(Convert.ToInt16(anyo_fin), Convert.ToInt16(mes_fin));
                fecha_ini = DateTime.Parse("01/" + mes_ini.PadLeft(2,'0') + "/" + anyo_ini);
                fecha_fin = DateTime.Parse(dias.ToString() + "/" + mes_fin.PadLeft(2, '0') + "/" + anyo_fin);
            }
           
            AuditoriasCiudadanas.Controllers.ProyectosController datos = new AuditoriasCiudadanas.Controllers.ProyectosController();
            outTxt = datos.obtCronogramaProyecto(bpin_proyecto, fecha_ini, fecha_fin);
            Response.Write(outTxt);
        }
    }
}
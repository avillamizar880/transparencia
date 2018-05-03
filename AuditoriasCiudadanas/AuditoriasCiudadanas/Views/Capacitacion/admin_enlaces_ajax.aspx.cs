using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Capacitacion
{
	public partial class admin_enlaces_ajax : App_Code.PageSession
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            string id_usuario = "";
            string titulo = "";
            string descripcion = "";
            string enlace_url = "";
            string outTxt = "";
            string cod_error = "";
            string msg_error = "";
            


            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                NameValueCollection pColl = Request.Params;
                if (pColl.AllKeys.Contains("id_usuario"))
                {
                    id_usuario = Request.Params.GetValues("id_usuario")[0].ToString();
                }
                if (pColl.AllKeys.Contains("titulo"))
                {
                    titulo = Request.Params.GetValues("titulo")[0].ToString();
                }
                if (pColl.AllKeys.Contains("desc"))
                {
                    descripcion = Request.Params.GetValues("desc")[0].ToString();
                }
                if (pColl.AllKeys.Contains("enlace_url"))
                {
                    enlace_url = Request.Params.GetValues("enlace_url")[0].ToString();
                }



            }

        }
	}
}
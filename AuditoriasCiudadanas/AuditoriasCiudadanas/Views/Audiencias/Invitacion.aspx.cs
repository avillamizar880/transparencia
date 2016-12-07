using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Audiencias
{
    public partial class Invitacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.HttpMethod == "GET")
            {
                NameValueCollection pColl = Request.Params;
                if (pColl.AllKeys.Contains("tipo"))
                {
                    lbltipo.InnerHtml = Request.Params.GetValues("tipo")[0].ToString();
                    lbltipo1.InnerHtml = Request.Params.GetValues("tipo")[0].ToString();
                }
                if (pColl.AllKeys.Contains("fechacompromiso"))
                {
                    string[] fech = Request.Params.GetValues("fechacompromiso")[0].ToString().Split(' ')[0].Split('/');
                    DateTimeFormatInfo formatoFecha = CultureInfo.CurrentCulture.DateTimeFormat;
                    lblfechcompromiso.InnerHtml = fech[0]+ " de " + formatoFecha.GetMonthName(Convert.ToInt16( fech[1])) + " de " + fech[2];

                }
                if (pColl.AllKeys.Contains("fecha"))
                {

                    string[] fech = Request.Params.GetValues("fecha")[0].ToString().Split(' ')[0].Split('/');
                    DateTimeFormatInfo formatoFecha = CultureInfo.CurrentCulture.DateTimeFormat;
                    lblfecha.InnerHtml = fech[0] + " de " + formatoFecha.GetMonthName(Convert.ToInt16(fech[1])) + " de " + fech[2];
                    lblhora.InnerHtml = Request.Params.GetValues("fecha")[0].ToString().Split(' ')[1];
                }

                if (pColl.AllKeys.Contains("lugar"))
                {

                    lbllugar.InnerHtml = Request.Params.GetValues("lugar")[0].ToString();
                }

            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace AuditoriasCiudadanas.Views.Valoracion
{
    public partial class configuraEncuestas : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
            DataTable dt_tipos = new DataTable();
            AuditoriasCiudadanas.Controllers.VerificacionController datos = new AuditoriasCiudadanas.Controllers.VerificacionController();
            dt_tipos = datos.listarTipoCuestionario();
            addDll(ddlTipoCuestionario, dt_tipos);
           
            

        }
        protected void addDll(DropDownList ddl, DataTable dt)
        {
            if (!ddl.ToolTip.Equals(""))
            {
                if (dt.Rows.Count > 0)
                {
                    DataTable dt_aux = new DataTable();
                    dt_aux = dt.Clone();
                    dt_aux.Rows.Add("0", ddl.ToolTip);
                    foreach (DataRow fila in dt.Rows)
                    {
                        dt_aux.ImportRow(fila);
                    }
                    ddl.DataSource = dt_aux;
                    ddl.DataBind();
                }
                else
                {
                    List<ListItem> items = new List<ListItem>();
                    items.Add(new ListItem(ddl.ToolTip, "0"));
                    ddl.Items.AddRange(items.ToArray());
                }
            }
        }
    }
}
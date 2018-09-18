using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Administracion
{
    public partial class EnlacesDNP : App_Code.PageSession
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idUsuario"] != null)
            {
                hdIdUsuario.Value = Session["idUsuario"].ToString();
            }

            Controllers.EnlacesDNPController ControllerEnlacesDNP = new Controllers.EnlacesDNPController();
            List<DataTable> ListEnlacesDNP = ControllerEnlacesDNP.ObtenerEnlacesDNP();

            addDll(ddlTipoEnlace, ListEnlacesDNP[0]);

            ListEnlacesDNP[0].Columns.Remove("llave");
            ListEnlacesDNP[0].Columns.Remove("id_usuario");
            ListEnlacesDNP[0].Columns.Remove("fecha_modificacion");
            hdDllContent.Value = ConvertDataTabletoString(ListEnlacesDNP[0]);

        }

        protected void addDll(DropDownList ddl, DataTable dt)
        {
            if (!ddl.ToolTip.Equals(""))
            {
                List<ListItem> items = new List<ListItem>();
                if (dt.Rows.Count > 0)
                {
                    items.Add(new ListItem(ddl.ToolTip, "0"));
                    foreach (DataRow fila in dt.Rows)
                    {
                        items.Add(new ListItem(fila["descripcion"].ToString(), fila["id_enlace"].ToString()));
                    }


                }
                else
                {
                    items.Add(new ListItem(ddl.ToolTip, "0"));
                    //ddl.Items.AddRange(items.ToArray());
                }
                ddl.Items.AddRange(items.ToArray());
            }
        }

        public string ConvertDataTabletoString(DataTable dt)
        {
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            return JsonConvert.SerializeObject(rows);
        }
    }
}
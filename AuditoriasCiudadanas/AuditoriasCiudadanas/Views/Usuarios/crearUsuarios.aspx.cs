using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace AuditoriasCiudadanas.Views.Usuarios
{
    public partial class crearUsuarios : App_Code.PageSession
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //dataTable dt_roles = new DataTable();
            //AuditoriasCiudadanas.Controllers.GeneralController datos = new AuditoriasCiudadanas.Controllers.GeneralController();
            //dt_roles = datos.listaRoles(
            //addDll(ddlRol, dt_roles);
        }

        protected void addDll(DropDownList ddl, DataTable dt)
        {
            if (!ddl.ToolTip.Equals(""))
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
        }
    }
}
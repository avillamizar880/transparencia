using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Audiencias
{
    public partial class ValoracionProyecto_ajax : App_Code.PageSession
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            DataTable dataTable = new DataTable();

            dataTable.TableName = "ROW";
            dataTable.Columns.Add("codigoBPIN", Type.GetType("System.String"));
            dataTable.Columns.Add("idUsuario", Type.GetType("System.String"));
            dataTable.Columns.Add("ProyP1", Type.GetType("System.String"));
            dataTable.Columns.Add("ProyP2", Type.GetType("System.String"));
            dataTable.Columns.Add("ProyP3", Type.GetType("System.String"));
            dataTable.Columns.Add("ProyP3Op", Type.GetType("System.String"));
            dataTable.Columns.Add("ProyP3Cual", Type.GetType("System.String"));
            dataTable.Columns.Add("ProyP4", Type.GetType("System.String"));
            dataTable.Columns.Add("ProyP5", Type.GetType("System.String"));
            dataTable.Columns.Add("AudP1", Type.GetType("System.String"));
            dataTable.Columns.Add("AudP2", Type.GetType("System.String"));
            dataTable.Columns.Add("AudP3GAC", Type.GetType("System.String"));
            dataTable.Columns.Add("AudP3Int", Type.GetType("System.String"));
            dataTable.Columns.Add("AudP3Sup", Type.GetType("System.String"));
            dataTable.Columns.Add("AudP3Con", Type.GetType("System.String"));
            dataTable.Columns.Add("AudP3Eje", Type.GetType("System.String"));
            dataTable.Columns.Add("AudP3Ent", Type.GetType("System.String"));
            dataTable.Columns.Add("AudP4GAC", Type.GetType("System.String"));
            dataTable.Columns.Add("AudP4Int", Type.GetType("System.String"));
            dataTable.Columns.Add("AudP4Sup", Type.GetType("System.String"));
            dataTable.Columns.Add("AudP4Con", Type.GetType("System.String"));
            dataTable.Columns.Add("AudP4Eje", Type.GetType("System.String"));
            dataTable.Columns.Add("AudP4Ent", Type.GetType("System.String"));
            dataTable.Columns.Add("AudP5", Type.GetType("System.String"));
            dataTable.Columns.Add("AudP6", Type.GetType("System.String"));
            dataTable.Columns.Add("GacP1", Type.GetType("System.String"));
            dataTable.Columns.Add("GacP2", Type.GetType("System.String"));
            dataTable.Columns.Add("GacP3", Type.GetType("System.String"));

            DataRow dr = dataTable.NewRow();
            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                NameValueCollection pColl = Request.Params;
                dr["codigoBPIN"] = Request.Params.GetValues("codigoBPIN")[0].ToString();
                dr["idUsuario"] = Request.Params.GetValues("idusuario")[0].ToString();
                dr["ProyP1"] = Request.Params.GetValues("ProyP1")[0].ToString();
                dr["ProyP2"] = Request.Params.GetValues("ProyP2")[0].ToString();
                dr["ProyP3"] = Request.Params.GetValues("ProyP3")[0].ToString();
                dr["ProyP3Op"] = Request.Params.GetValues("ProyP3Op")[0].ToString();
                dr["ProyP3Cual"] = Request.Params.GetValues("ProyP3Cual")[0].ToString();
                dr["ProyP4"] = Request.Params.GetValues("ProyP4")[0].ToString();
                dr["ProyP5"] = Request.Params.GetValues("ProyP5")[0].ToString();
                dr["AudP1"] = Request.Params.GetValues("AudP1")[0].ToString();
                dr["AudP2"] = Request.Params.GetValues("AudP2")[0].ToString();
                dr["AudP3GAC"] = Request.Params.GetValues("AudP3GAC")[0].ToString();
                dr["AudP3Int"] = Request.Params.GetValues("AudP3Int")[0].ToString();
                dr["AudP3Sup"] = Request.Params.GetValues("AudP3Sup")[0].ToString();
                dr["AudP3Con"] = Request.Params.GetValues("AudP3Con")[0].ToString();
                dr["AudP3Eje"] = Request.Params.GetValues("AudP3Eje")[0].ToString();
                dr["AudP3Ent"] = Request.Params.GetValues("AudP3Ent")[0].ToString();
                dr["AudP4GAC"] = Request.Params.GetValues("AudP4GAC")[0].ToString();
                dr["AudP4Int"] = Request.Params.GetValues("AudP4Int")[0].ToString();
                dr["AudP4Sup"] = Request.Params.GetValues("AudP4Sup")[0].ToString();
                dr["AudP4Con"] = Request.Params.GetValues("AudP4Con")[0].ToString();
                dr["AudP4Eje"] = Request.Params.GetValues("AudP4Eje")[0].ToString();
                dr["AudP4Ent"] = Request.Params.GetValues("AudP4Ent")[0].ToString();
                dr["AudP5"] = Request.Params.GetValues("AudP5")[0].ToString();
                dr["AudP6"] = Request.Params.GetValues("AudP6")[0].ToString();
                dr["GacP1"] = Request.Params.GetValues("GacP1")[0].ToString();
                dr["GacP2"] = Request.Params.GetValues("GacP2")[0].ToString();
                dr["GacP3"] = Request.Params.GetValues("GacP3")[0].ToString();

            }
            dataTable.Rows.Add(dr);

            string outTxt = "";
            AuditoriasCiudadanas.Controllers.AudienciasController datos = new AuditoriasCiudadanas.Controllers.AudienciasController();
            outTxt = datos.insValoracionProyecto(dataTable);
            Response.Write(outTxt);
            Response.End();
        }
    }
}
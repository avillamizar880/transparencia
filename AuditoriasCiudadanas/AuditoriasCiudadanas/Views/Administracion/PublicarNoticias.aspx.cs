﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Administracion
{
  public partial class PublicarNoticias : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (Session["idUsuario"] != null) hdIdUsuario.Value = Session["idUsuario"].ToString();
    }
  }
}
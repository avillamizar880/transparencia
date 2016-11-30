<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="AuditoriasCiudadanas.Principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

            <script src="Scripts/jquery-1.10.2.min.js" type="text/javascript" ></script>
            <script src="Scripts/jquery.blockUI.js" type="text/javascript" ></script>
            <script src="Scripts/ajaxPost.js" type="text/javascript" ></script>
            <script src="Scripts/jquery.smartmenus.min.js" type="text/javascript" ></script>

            <script src="Scripts/tinymce/tinymce.min.js" type="text/javascript" ></script>

                <script src="Scripts/Principal.js" type="text/javascript" ></script>

            <link href="Content/bootstrap.min.css" rel="stylesheet">
            <link href="Content/sm-core-css.css" rel="stylesheet">
            <link href="Content/sm-simple.css" rel="stylesheet">
            <link href="Content/menu.css" rel="stylesheet">
</head>
<body>

   <nav class="main-nav" role="navigation">

  <!-- Mobile menu toggle button (hamburger/x icon) -->
  <input id="main-menu-state" type="checkbox" />
  <label class="main-menu-btn" for="main-menu-state">
    <span class="main-menu-btn-icon"></span> Toggle main menu visibility
  </label>

  <h2 class="nav-brand"><a href="#">TRANSPARENCIA</a></h2>

  <!-- Sample menu definition -->
  <ul id="main-menu" class="sm  sm-simple">
    <li><a onclick="alert('En construcción')" href="#">Home</a></li>
    <li><a onclick="cargaMenu('About.aspx', 'divCentral')" href="#">About</a>
    </li>
    <li><a onclick="cargaMenu('EnvioCorreo.aspx', 'divCentral')" href="#">EJEMPLOS</a></li>
    <li><a onclick="alert('En construcción')" href="#">Support</a>
      <ul>
        <li><a onclick="alert('En construcción')" href="#">Premium support</a></li>
        <li><a onclick="alert('En construcción')" href="#">Forums</a></li>
      </ul>
    </li>
    <li><a onclick="alert('En construcción')" href="#">Docs</a></li>
    <li><a href="#">Sub test</a>
      <ul>
        <li><a href="#">Dummy item</a></li>
        <li><a href="#">Dummy item</a></li>
        <li><a href="#" class="disabled">Disabled menu item</a></li>
        <li><a href="#">Dummy item</a></li>
        <li><a href="#">more...</a>
          <ul>
            <li><a href="#">A pretty long text to test the default subMenusMaxWidth:20em setting for the sub menus</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">more...</a>
              <ul>
                <li><a href="#">Dummy item</a></li>
                <li><a href="#" class="current">A 'current' class item</a></li>
                <li><a href="#">Dummy item</a></li>
                <li><a href="#">more...</a>
                  <ul>
                    <li><a href="#">subMenusMinWidth</a></li>
                    <li><a href="#">10em</a></li>
                    <li><a href="#">forced.</a></li>
                  </ul>
                </li>
                <li><a href="#">Dummy item</a></li>
                <li><a href="#">Dummy item</a></li>
              </ul>
            </li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">A pretty long text to test the default subMenusMaxWidth:20em setting for the sub menus</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">A pretty long text to test the default subMenusMaxWidth:20em setting for the sub menus</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">A pretty long text to test the default subMenusMaxWidth:20em setting for the sub menus</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">A pretty long text to test the default subMenusMaxWidth:20em setting for the sub menus</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">A pretty long text to test the default subMenusMaxWidth:20em setting for the sub menus</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
            <li><a href="#">Dummy item</a></li>
          </ul>
        </li>
      </ul>
    </li>
    <li><a href="http://www.smartmenus.org/contact/">Contact</a></li>
  </ul>
</nav>

<div id="divCentral" >

</div>
</body>
</html>

<%@ Page Title="" Language="C#" MasterPageFile="~/paginaMaestra/Site1.Master" AutoEventWireup="true" CodeBehind="Galeria.aspx.cs" Inherits="Minutero1.Paginas.CiberCocina.Galeria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        img {
            float:left;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ribbons" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="wp" runat="server">
    <div id="content">

<div class="row hidden-mobile">
	<div class="col-xs-12 col-sm-6 col-md-6 col-lg-6">
		<h1 class="page-title txt-color-blueDark">
			<i class="fa-fw fa fa-picture-o"></i> 
			Galería de Imágenes de Minuta</h1>
	</div>

	
</div>

<!-- row -->
<div class="row" id="elSuperBox">

	<!-- SuperBox -->
		
	<!-- /SuperBox -->
	
	<div class="superbox-show" style="height:300px; display: none"></div>
       
    </div>

	<!-- end row -->
   </div>
    <input type="hidden" id="idUsuario" value="<%=Session["idUsuario"] %>" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="jscripts" runat="server">
    <script type="text/javascript" src="../../js/Paginas/CiberCocina/galeria.js" ></script>
    <script type="text/javascript" src="../../js/plugin/superbox/superbox.min.js"></script>


</asp:Content>

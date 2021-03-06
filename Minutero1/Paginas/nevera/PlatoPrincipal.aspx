﻿<%@ Page Title="" Language="C#" MasterPageFile="~/paginaMaestra/Site1.Master" AutoEventWireup="true" CodeBehind="PlatoPrincipal.aspx.cs" Inherits="Minutero1.Paginas.nevera.PlatoPrincipal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ribbons" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="wp" runat="server">
 <div id="content">
   <div class="row">
				
						<article class="col-sm-12 col-md-12 col-lg-12">
				
							<div class="jarviswidget" id="wid-id-0" data-widget-colorbutton="false" data-widget-editbutton="false" data-widget-custombutton="false">
								<header>
									<span class="widget-icon"> <i class="fa fa-edit"></i> </span>
									<h2>Plato Principal</h2>
				
								</header>
				
								<div>
				
									<div class="jarviswidget-editbox">
										<!-- This area used as dropdown edit box -->
				
									</div>
									<div class="widget-body no-padding">
				
										<form class="smart-form">
											<header>
												Ingresar Plato
											</header>
				
											<fieldset>
                                                
                                                <div class="row">
													<section class="col col-4">
                                                        <label class="label">
                                                            Nombre plato
                                                        </label>
														<label class="input">
															<input type="text"  id="NombrePlato" placeholder="Nombre del plato">
                                                            <input type="hidden" id="idPlatoPrincipal" value="0" />
														</label>
													</section>
													<section class="col col-4">
                                                        <label class="label">
                                                            Descripción de plato
                                                        </label>
														<label class="input">
															<input type="text" id="descripcionPlato" placeholder="Descripción">
														</label>
													</section>
                                                    </div>
                                                <div class="row">
													<section class="col col-4">
                                                        <%
                                                            string cadenaClasesCOmida = "";
                                                            Modelo.TipoComida ListaDeTipos = new Modelo.TipoComida(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString);
                                                            List<Modelo.objTipoComida> MiListaTipoComidas = new List<Modelo.objTipoComida>();
                                                            MiListaTipoComidas = ListaDeTipos.getListaTipoComida(Session["RutEmpresa"].ToString());
                                                            foreach(Modelo.objTipoComida elTipoComida in MiListaTipoComidas )
                                                            {
                                                                cadenaClasesCOmida = cadenaClasesCOmida + "<option value='" + elTipoComida.id_tipoPlato + "'>" + elTipoComida.Descripcion.ToString() + "</option>";
                                                            }
                                                            
                                                            
                                                           %>
														<label class="label">
                                                            Clase de comida:
														</label>
                                                        <select class="select" id="tipoPlato">
                                                            <option disabled selected>Selecciona la clase del plato</option>
                                                             <%=cadenaClasesCOmida %>
                                                        </select>
                                                        
													</section>
                                                  </div>
											</fieldset>
				
				
											<footer>
												<button type="button" class="btn btn-primary" id="GuardaPlato">
													Guardar
												</button>
                                                <button type="button" class="btn btn-danger" id="Cancelar">Cancelar</button>
                                                         
												<button type="button" class="btn btn-default" onclick="window.history.back();">
													Atrás
												</button>
											</footer>
										</form>



                                        
				
									</div>

									<!-- end widget content -->
				
								</div>
                                
                       
								<!-- end widget div -->
				                <div class="row">
            
							<!-- Widget ID (each widget will need unique ID)-->
							<div class="jarviswidget jarviswidget-color-blueDark" id="Div1" data-widget-editbutton="false">
								<!-- widget options:
								usage: <div class="jarviswidget" id="wid-id-0" data-widget-editbutton="false">

								data-widget-colorbutton="false"
								data-widget-editbutton="false"
								data-widget-togglebutton="false"
								data-widget-deletebutton="false"
								data-widget-fullscreenbutton="false"
								data-widget-custombutton="false"
								data-widget-collapsed="true"
								data-widget-sortable="false"

								-->
								<header>
									<span class="widget-icon"> <i class="fa fa-table"></i> </span>
									<h2>Tabla de Comidas</h2>

								</header>

								<!-- widget div-->
								<div>

									<!-- widget edit box -->
									<div class="jarviswidget-editbox">
										<!-- This area used as dropdown edit box -->

									</div>
									<!-- end widget edit box -->

									<!-- widget content -->
									<div class="widget-body">
										<p>Plato Principal</p>
										 
										<div class="table-responsive">
										                                                                
											<table class="table table-bordered">
												<thead>
													<tr>
														<th>Nombre Plato</th>
														<th>Descripción</th>
                                                        <th>Tipo Plato</th>
													    <th>Acciones</th>
													</tr>
												</thead>
												<tbody>
                                                    <%
                                                        
                                                        Controlador.PlatoPrincipal PPrincipal = new Controlador.PlatoPrincipal(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString);
                                                        List<Modelo.objPlatoPrincipal> listaPlatosprincipales = new List<Modelo.objPlatoPrincipal>();
                                                        listaPlatosprincipales = PPrincipal.TraeListaPlatosPrincipales(Session["RutEmpresa"].ToString());
                                                        foreach(Modelo.objPlatoPrincipal elplatoPrincipal in listaPlatosprincipales)
                                                        {
                                                    %>   
                                                         <tr>
                                                         <td><%=elplatoPrincipal.Nombre_plato.ToString() %></td>
                                                         <td><%=elplatoPrincipal.descripcion.ToString() %></td>
                                                         <td><%=elplatoPrincipal.id_tipoComida.Descripcion %></td>
                                                         <td>
                                                             <button type="button" class="btn btn-warning" id="editar_<%=elplatoPrincipal.id_platoPrincipal%>" title="Editar" onclick="editar(<%=elplatoPrincipal.id_platoPrincipal%>,'<%=elplatoPrincipal.Nombre_plato %>','<%=elplatoPrincipal.descripcion%>',<%=elplatoPrincipal.id_tipoComida.id_tipoPlato%>)"><i class="fa fa-pencil"></i></button>
                                                             <button type="button" class="btn btn-danger" id="eliminar_<%=elplatoPrincipal.id_platoPrincipal%>" onclick="Elimina(<%=elplatoPrincipal.id_platoPrincipal%>)"><i class="fa fa-trash-o"></i></button>
                                                         </td>
                                                         
                                                         </tr>
                                                       
                                                        
                                                    
                                                    <% } %>
												</tbody>
                                                
											</table>
											
										</div>
									</div>
									
								</div>
							

							</div>
						
		
        </div>

    
    </div>
    </article>
    </div>
   
    </div>
   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="jscripts" runat="server">
    <script type="text/javascript" src="../../js/Paginas/nevera/PlatoPrincipal.js"></script>
</asp:Content>

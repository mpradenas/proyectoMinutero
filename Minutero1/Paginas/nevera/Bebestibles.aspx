<%@ Page Title="" Language="C#" MasterPageFile="~/paginaMaestra/Site1.Master" AutoEventWireup="true" CodeBehind="Bebestibles.aspx.cs" Inherits="Minutero1.Paginas.nevera.Bebestibles" %>
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
									<h2>Bebidas y bebestibles</h2>
				
								</header>
				
								<div>
				
									<div class="jarviswidget-editbox">
										<!-- This area used as dropdown edit box -->
				
									</div>
									<div class="widget-body no-padding">
				
										<form class="smart-form">
											<header>
												Ingresar Bebestible
											</header>
				
											<fieldset>
                                             
                                                <div class="row">
													<section class="col col-4">
                                                        <label class="label">
                                                            Nombre Bebestible
                                                        </label>
														<label class="input">
															<input type="text"  id="NombreBebestible" placeholder="Nombre del bebestible">
                                                            <input type="hidden" id="idBebestible" value="0" />
														</label>
													</section>
													<section class="col col-4">
                                                        <label class="label">
                                                            Descripción de bebestible
                                                        </label>
														<label class="input">
															<input type="text" id="descripcionBebestible" placeholder="Descripción">
														</label>
													</section>
                                                    </div>
                                                <div class="row">
													<section class="col col-4">
                                                        <%
                                                            string cadenaClasesBebida = "";
                                                            Modelo.tipo_bebida ListaDeTipos = new Modelo.tipo_bebida(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString);
                                                            List<Modelo.objTipo_bebida> MiListaTipoBebidas = new List<Modelo.objTipo_bebida>();
                                                            MiListaTipoBebidas = ListaDeTipos.getListaTipoBEbida(Session["RutEmpresa"].ToString());
                                                            foreach(Modelo.objTipo_bebida elTipoBebida in MiListaTipoBebidas )
                                                            {
                                                                cadenaClasesBebida = cadenaClasesBebida + "<option value='" + elTipoBebida.id_tipoBebida + "'>" +elTipoBebida.Descripcion.ToString() + "</option>";
                                                            }
                                                            
                                                            
                                                           %>
														<label class="label">
                                                            Clase de Bebestibles:
														</label>
                                                        <select class="select" id="tipoBebestible">
                                                            <option disabled selected>Selecciona el tipo de bebida</option>
                                                             <%=cadenaClasesBebida %>
                                                        </select>
                                                        
													</section>
                                                  </div>
											</fieldset>
				
				
											<footer>
												<button type="button" class="btn btn-primary" id="GuardaBebida">
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
									<h2>Tabla de Bebestibles</h2>

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
										<p>Bebestibles</p>
										 
										<div class="table-responsive">
										                                                                
											<table class="table table-bordered">
												<thead>
                                                    <tr>
                                                        <th colspan="4">Bebestibles</th>
                                                    </tr>
													<tr>
														<th>Nombre Bebestible</th>
														<th>Descripción</th>
                                                        <th>Tipo Bebestible</th>
													    <th>Acciones</th>
													</tr>
												</thead>
												<tbody>
                                                    <%
                                                        
                                                        Modelo.Bebestibles bebest = new Modelo.Bebestibles(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString);
                                                        List<Modelo.objBebestibles> listaBebestibles = new List<Modelo.objBebestibles>();
                                                        listaBebestibles =bebest.GetListBebestibles(Session["RutEmpresa"].ToString());
                                                        foreach (Modelo.objBebestibles elbebestible in listaBebestibles)
                                                        {
                                                    %>   
                                                         <tr>
                                                         <td><%=elbebestible.Nombre_bebida%></td>
                                                         <td><%=elbebestible.descripcion.ToString() %></td>
                                                         <td><%=elbebestible.id_tipo_bebida.Descripcion %></td>
                                                         <td>
                                                             <button type="button" class="btn btn-warning" id="editar_<%=elbebestible.id_bebestible%>" title="Editar" onclick="editar(<%=elbebestible.id_bebestible%>,'<%=elbebestible.Nombre_bebida %>','<%=elbebestible.descripcion%>',<%=elbebestible.id_tipo_bebida.id_tipoBebida %>"><i class="fa fa-pencil"></i></button>
                                                             <button type="button" class="btn btn-danger" id="eliminar_<%=elbebestible.id_bebestible%>" title="Eliminar" onclick="Elimina(<%=elbebestible.id_bebestible%>)"><i class="fa fa-trash-o"></i></button>
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
    <script type="text/javascript" src="../../js/Paginas/nevera/Bebestibles.js"></script>
</asp:Content>

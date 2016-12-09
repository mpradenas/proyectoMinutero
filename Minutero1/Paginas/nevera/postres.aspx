<%@ Page Title="" Language="C#" MasterPageFile="~/paginaMaestra/Site1.Master" AutoEventWireup="true" CodeBehind="postres.aspx.cs" Inherits="Minutero1.Paginas.nevera.postres" %>
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
									<h2>Postres</h2>
				
								</header>
				
								<div>
				
									<div class="jarviswidget-editbox">
										<!-- This area used as dropdown edit box -->
				
									</div>
									<div class="widget-body no-padding">
				
										<form class="smart-form">
											<header>
												Ingresar Postres
											</header>
				
											<fieldset>
                                                
                                                <div class="row">
													<section class="col col-4">
                                                        <label class="label">
                                                            Nombre postre
                                                        </label>
														<label class="input">
															<input type="text"  id="Nombrepostre" placeholder="Nombre del postre">
                                                            <input type="hidden" id="idPostre" value="0" />
														</label>
													</section>
													<section class="col col-4">
                                                        <label class="label">
                                                            Descripción de postre
                                                        </label>
														<label class="input">
															<input type="text" id="descripcionPostre" placeholder="Descripción">
														</label>
													</section>
                                                    </div>
                                               </fieldset>
				
				
											<footer>
												<button type="button" class="btn btn-primary" id="GuardaPostre">
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
									<h2>Tabla de Postres</h2>

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
														<th>Nombre Postre</th>
														<th>Descripción</th>
                                                        <th>Acciones</th>
													</tr>
												</thead>
												<tbody>
                                                    <%
                                                        
                                                        Modelo.Postres procPostres = new Modelo.Postres(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString);
                                                        List<Modelo.ObjPostres> listaPostres = new List<Modelo.ObjPostres>();
                                                        listaPostres = procPostres.GetListPostres(Session["rutEmpresa"].ToString());
                                                        foreach (Modelo.ObjPostres elpostre in listaPostres)
                                                        {
                                                    %>   
                                                         <tr>
                                                         <td><%=elpostre.Nombre_Postre.ToString().Trim() %></td>
                                                         <td><%=elpostre.Descripcion.ToString().Trim() %></td>
                                                         <td>
                                                             <button type="button" class="btn btn-warning" id="editar_<%=elpostre.Id_Postre%>" title="Editar" onclick="editar(<%=elpostre.Id_Postre%>,'<%=elpostre.Nombre_Postre %>','<%=elpostre.Descripcion%>')"><i class="fa fa-pencil"></i></button>
                                                             <button type="button" class="btn btn-danger" id="eliminar_<%=elpostre.Id_Postre%>" onclick="Elimina(<%=elpostre.Id_Postre%>)"><i class="fa fa-trash-o"></i></button>
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
    <script type="text/javascript" src="../../js/Paginas/nevera/Postres.js"></script>
</asp:Content>

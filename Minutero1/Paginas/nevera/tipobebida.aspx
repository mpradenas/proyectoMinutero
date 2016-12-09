<%@ Page Title="" Language="C#" MasterPageFile="~/paginaMaestra/Site1.Master" AutoEventWireup="true" CodeBehind="tipobebida.aspx.cs" Inherits="Minutero1.Paginas.nevera.tipobebida" %>
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
									<h2>Tipo Bebida</h2>
				
								</header>
				
								<div>
				
									<div class="jarviswidget-editbox">
										<!-- This area used as dropdown edit box -->
				
									</div>
									<div class="widget-body no-padding">
				
										<form class="smart-form">
											<header>
												Ingresar Tipo de Bebida
											</header>
				
											<fieldset>
                                             
                                                <div class="row">
													<section class="col col-4">
                                                        <label class="label">
                                                            Tipo Bebida
                                                        </label>
														<label class="input">
															<input type="text"  id="DescripcionTipoBebida" placeholder="Tipo Bebida">
                                                            <input type="hidden" id="idTipoBebida" value="0" />
														</label>
													</section>
													
                                                    </div>
                                            </fieldset>
				
				
											<footer>
												<button type="button" class="btn btn-primary" id="GuardaTipoBebida">
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
										<p>Tabla de Tipos de Bebida</p>
										 
										<div class="table-responsive">
										                                                                
											<table class="table table-bordered">
												<thead>
                                                    <tr>
                                                        <th colspan="4">Tipos de Bebida</th>
                                                    </tr>
													<tr>
														<th>Descripción</th>
                                                        <th>Acciones</th>
													</tr>
												</thead>
												<tbody>
                                                    <%
                                                        
                                                        Modelo.tipo_bebida TipBebida = new Modelo.tipo_bebida(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString);
                                                        List<Modelo.objTipo_bebida> listaDeTipoBebida = new List<Modelo.objTipo_bebida>();
                                                        listaDeTipoBebida = TipBebida.getListaTipoBEbida(Session["RutEmpresa"].ToString());
                                                        foreach (Modelo.objTipo_bebida elTipoBebida in listaDeTipoBebida)
                                                        {
                                                    %>   
                                                         <tr>
                                                         <td><%=elTipoBebida.Descripcion %></td>
                                                         <td>
                                                             <button type="button" class="btn btn-warning" id="editar_<%=elTipoBebida.id_tipoBebida%>" title="Editar" onclick="editar(<%=elTipoBebida.id_tipoBebida%>,'<%=elTipoBebida.Descripcion %>')"><i class="fa fa-pencil"></i></button>
                                                             <button type="button" class="btn btn-danger" id="eliminar_<%=elTipoBebida.id_tipoBebida%>" onclick="Elimina(<%=elTipoBebida.id_tipoBebida%>)"><i class="fa fa-trash-o"></i></button>
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
    <script type="text/javascript" src="../../js/Paginas/nevera/tipoBebida.js"></script>
</asp:Content>

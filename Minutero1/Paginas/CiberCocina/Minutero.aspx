<%@ Page Title="" Language="C#" MasterPageFile="~/paginaMaestra/Site1.Master" AutoEventWireup="true" CodeBehind="Minutero.aspx.cs" Inherits="Minutero1.Paginas.CiberCocina.Minutero" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ribbons" runat="server">
    <link href="../../js/plugin/fullcalendar/fullcalendar.print.css" type="text/css" rel="stylesheet"  media="print"/>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="wp" runat="server">
    <div id="content">

				<div class="row">
				
					<div class="col-sm-12 col-md-12 col-lg-3">
						<!-- new widget -->
						<div class="jarviswidget jarviswidget-color-blueDark">
							<header>
								<h2> Agregar eventos</h2>
							</header>
				
							<!-- widget div-->
							<div>
				
								<div class="widget-body">
									<!-- content goes here -->
				
									<form id="add-event-form">
										<fieldset>
				
											<div class="form-group">
												<label>Selecciona ícono según la importancia</label>
												<div class="btn-group btn-group-sm btn-group-justified" data-toggle="buttons">
													<label class="btn btn-default">
														<input type="radio" name="iconselect" id="icon-2" value="fa-cutlery">
														<i class="fa fa-cutlery text-muted"></i> </label>
													<label class="btn btn-default">
														<input type="radio" name="iconselect" id="icon-3" value="fa-glass">
														<i class="fa fa-glass text-muted"></i> </label>
                                                    <label class="btn btn-default active">
														<input type="radio" name="iconselect" id="icon-1" value="fa-spoon" checked>
														<i class="fa  fa-spoon text-muted"></i> </label>
												</div>
											</div>
				                            <div class="form-group">
												<label>selecciona plato principal</label>
												           <%
                                                        string platoPrinc = "";
                                                        Modelo.platoPrincipal procPlatoPrincipal = new Modelo.platoPrincipal(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString);
                                                        List<Modelo.objPlatoPrincipal> lalistaPlatoPrincipa = new List<Modelo.objPlatoPrincipal>();
                                                        lalistaPlatoPrincipa = procPlatoPrincipal.GetListPlatosPrincipales(Session["RutEmpresa"].ToString());
                                                        if (lalistaPlatoPrincipa != null) 
                                                        {
                                                            foreach(Modelo.objPlatoPrincipal elPLato in lalistaPlatoPrincipa)
                                                            {
                                                                platoPrinc=platoPrinc+"<option value='" + elPLato.id_platoPrincipal + "'>" + elPLato.Nombre_plato.Trim() +" "+elPLato.descripcion+"</option>";
                                                            }
                                                        }
                                    
                                    
                                    
                                                    %>
                                                    <select id="pPrincipal" class="select" onchange="ejec1()">
                                                        <option disabled selected>Selecciona plato principal</option>
                                                        <%=platoPrinc %>

                                                    </select>
                                                                  <!--  <p class="note">el largo máximo esta ajustado para 40 caractéres</p>-->
								                    </div>
                                                    <div class="form-group">
							                        <label>
                                                        selecciona plato acompañamiento
                                                   </label>
				                                     <%
                                                        string platoAcomp = "";
                                                        Modelo.platoAcompanamiento procPlatoAcomp = new Modelo.platoAcompanamiento(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString);
                                                        List<Modelo.objPlatoAcompanamiento> lalistaPlatoAcomp = new List<Modelo.objPlatoAcompanamiento>();
                                                        lalistaPlatoAcomp = procPlatoAcomp.GetListAcompanamientos(Session["RutEmpresa"].ToString());
                                                        if (lalistaPlatoPrincipa != null) 
                                                        {
                                                            foreach (Modelo.objPlatoAcompanamiento elPLato in lalistaPlatoAcomp)
                                                            {
                                                                platoAcomp=platoAcomp+"<option value='" + elPLato.id_platoAcomp + "'>" + elPLato.Nombre_platoAcomp.Trim() +" "+elPLato.descripcion+"</option>";
                                                            }
                                                        }
                                    
                                    
                                    
                                                    %>
                                
                                                    <select id="idPAcomp" class="select" onchange="ejec2()">
                                                        <option disabled selected>Selecciona plato Acompañmiento</option>
                                                        <%=platoAcomp %>

                                                    </select>
                                                                  <!--  <p class="note">el largo máximo esta ajustado para 40 caractéres</p>-->
								                    </div>
                                                   <div class="form-group">
								                    <label>selecciona Bebestible</label>
								                    <%
                                                        string bebidas = "";
                                                        Modelo.Bebestibles procBebestibles = new Modelo.Bebestibles(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString);
                                                        List<Modelo.objBebestibles> lalistaBEbestibles = new List<Modelo.objBebestibles>();
                                                        lalistaBEbestibles = procBebestibles.GetListBebestibles(Session["RutEmpresa"].ToString());
                                                        if (lalistaBEbestibles != null) 
                                                        {
                                                            foreach (Modelo.objBebestibles elbebestible in lalistaBEbestibles)
                                                            {
                                                                bebidas = bebidas + "<option value='" + elbebestible.id_bebestible + "'>" + elbebestible.Nombre_bebida.Trim() + " " + elbebestible.descripcion + "</option>";
                                                            }
                                                        }
                                    
                                    
                                    
                                                    %>
                                                    <label class="select">
                                                    <select id="idBebestibles" class="select" onchange="ejec3()">
                                                        <option disabled selected>Selecciona bebestible</option>
                                                        <%=bebidas %>

                                                    </select>
                                                        <i></i>
                                                    </label>
                                
                                                   </div>
                               
                                
                                            
                                            <div class="form-group">
								            
                                                <%
                                    
                                                      string Postres = "";
                                    
                                                      Modelo.Postres procPostres = new Modelo.Postres(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString);
                                    
                                                      List<Modelo.ObjPostres> lalistaPostres = new List<Modelo.ObjPostres>();
                                                      lalistaPostres = procPostres.GetListPostres(Session["RutEmpresa"].ToString());
                                                    
                                                      if (lalistaPostres != null) 
                                                    
                                                      {
                                                        
                                                          foreach (Modelo.ObjPostres elpostre in lalistaPostres)
                                                        
                                                          {
                                                          
                                                              Postres = Postres + "<option value='" + elpostre.Id_Postre + "'>" + elpostre.Nombre_Postre.Trim() + " " + elpostre.Descripcion.Trim() + "</option>";
                                                        
                                                          }
                                                    
                                                      }
                                    
                                    
                                    
            
                                                                          %>
                                
   
                                                                     <label>selecciona postre</label>
								
                                
                                   
                                                 <select id="idPostre" class="select" onchange="ejec4()">
                                
                                        
                                                     <option disabled="disabled" selected>Selecciona el postre que dese</option>
                                    
                                        
                                                     <%=Postres %>

                                
                                    
                                                 </select>
                                              <!--  <p class="note">el largo máximo esta ajustado para 40 caractéres</p>-->
								</div>
				
											<div class="form-group">
												<label>Selecciona el color de su eleccion</label>
												<div class="btn-group btn-group-justified btn-select-tick" data-toggle="buttons">
													<label class="btn bg-color-darken active">
														<input type="radio" name="priority" id="option1" value="bg-color-darken txt-color-white" checked>
														<i class="fa fa-check txt-color-white"></i> </label>
													<label class="btn bg-color-blue">
														<input type="radio" name="priority" id="option2" value="bg-color-blue txt-color-white">
														<i class="fa fa-check txt-color-white"></i> </label>
													<label class="btn bg-color-orange">
														<input type="radio" name="priority" id="option3" value="bg-color-orange txt-color-white">
														<i class="fa fa-check txt-color-white"></i> </label>
													<label class="btn bg-color-greenLight">
														<input type="radio" name="priority" id="option4" value="bg-color-greenLight txt-color-white">
														<i class="fa fa-check txt-color-white"></i> </label>
													<label class="btn bg-color-blueLight">
														<input type="radio" name="priority" id="option5" value="bg-color-blueLight txt-color-white">
														<i class="fa fa-check txt-color-white"></i> </label>
													<label class="btn bg-color-red">
														<input type="radio" name="priority" id="option6" value="bg-color-red txt-color-white">
														<i class="fa fa-check txt-color-white"></i> </label>
                                         
												</div>
											</div>
				
										</fieldset>
										<div class="form-actions">
											<div class="row">
												<div class="col-md-12">
													<button class="btn btn-default" type="button" id="add-event" >
														Agregar evento
													</button>
												</div>
											</div>
										</div>
									</form>
				
									<!--<fieldset>
				
											<div class="form-group">
												<label>Selecciona ícono según la importancia</label>
												<div class="btn-group btn-group-sm btn-group-justified" data-toggle="buttons">
													<label class="btn btn-default active">
														<input type="radio" name="iconselect" id="Radio1" value="fa-info" checked>
														<i class="fa fa-info text-muted"></i> </label>
													<label class="btn btn-default">
														<input type="radio" name="iconselect" id="Radio2" value="fa-warning">
														<i class="fa fa-warning text-muted"></i> </label>
													<label class="btn btn-default">
														<input type="radio" name="iconselect" id="Radio3" value="fa-check">
														<i class="fa fa-check text-muted"></i> </label>
													<label class="btn btn-default">
														<input type="radio" name="iconselect" id="Radio4" value="fa-user">
														<i class="fa fa-user text-muted"></i> </label>
													<label class="btn btn-default">
														<input type="radio" name="iconselect" id="Radio5" value="fa-lock">
														<i class="fa fa-lock text-muted"></i> </label>
													<label class="btn btn-default">
														<input type="radio" name="iconselect" id="Radio6" value="fa-clock-o">
														<i class="fa fa-clock-o text-muted"></i> </label>
												</div>
											</div>
				
											<!--<div class="form-group">
												<label>Título de </label>
												<input class="form-control"  id="title" name="title" maxlength="40" type="text" placeholder="Event Title">
											</div>-->
								
                                              <!--  <p class="note">el largo máximo esta ajustado para 40 caractéres</p>-->
											</div>
				                     
				
									<!-- end content -->
							</div>
							<!-- end widget div -->
						</div>
						<!-- end widget -->
				        <div class="row">

                            <section>
                                
                            </section>
				        </div>
						<div class="well well-sm" id="event-container">
							<form>
								<fieldset>
									<legend>
										Eventos arrastrables
									</legend>
									<ul id='external-events' class="list-unstyled">
	                					<!---<li>
											<span class="bg-color-darken txt-color-white" data-description="Currently busy" data-icon="fa-time">Office Meeting</span>
										</li>
										<li>
											<span class="bg-color-blue txt-color-white" data-description="No Description" data-icon="fa-pie">Lunch Break</span>
										</li>
										<li>
											<span class="bg-color-red txt-color-white" data-description="Urgent Tasks" data-icon="fa-alert">URGENT</span>
										</li>--->
									</ul>
									<div class="checkbox">
										<label>
											<input type="checkbox" id="drop-remove" class="checkbox style-0" checked="checked">
											<span>Quitar después de pegarlo en el calendario</span> </label>
					
									</div>
								</fieldset>
							</form>
				
						</div>
					</div>
					<div class="col-sm-12 col-md-12 col-lg-9" id="todoElCalendario">
				
						<!-- new widget -->
						<div class="jarviswidget jarviswidget-color-blueDark">
				
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
								<span class="widget-icon"> <i class="fa fa-calendar"></i> </span>
								<h2> Mi Minuta </h2>
								<div class="widget-toolbar">
									<!-- add: non-hidden - to disable auto hide -->
									<div class="btn-group">
										<button class="btn dropdown-toggle btn-xs btn-default" data-toggle="dropdown">
											Muestra <i class="fa fa-caret-down"></i>
										</button>
										<ul class="dropdown-menu js-status-update pull-right">
											<li>
												<a href="javascript:void(0);" id="mt">Mes</a>
											</li>
											<!--<li>
												<a href="javascript:void(0);" id="ag">Agenda</a>
											</li>-->
											<!--<li>
												<a href="javascript:void(0);" id="td">Hoy</a>
											</li>-->
										</ul>
									</div>
								</div>
							</header>
				
							<!-- widget div-->
							<div>
				
								<div class="widget-body no-padding">
									<!-- content goes here -->
									<div class="widget-body-toolbar">
				
										<div id="calendar-buttons">
				
											<div class="btn-group">
												<a href="javascript:void(0)" class="btn btn-default btn-xs" id="btn-prev"><i class="fa fa-chevron-left"></i></a>
												<a href="javascript:void(0)" class="btn btn-default btn-xs" id="btn-next"><i class="fa fa-chevron-right"></i></a>
											</div>
										</div>
									</div>
									<div id="calendar">

									</div>
				
									<!-- end content -->
                                    
								</div>
				
							</div>
							<!-- end widget div -->
						</div>
						<!-- end widget -->
				
					</div>
				
				</div>
				
				<!-- end row -->

			</div>
			<!-- END MAIN CONTENT -->
		    <form class="smart-form">
             
                <footer>
                    <button class="btn btn-primary" type="button" onclick="CrearImagen()">Guardar Calendario como imagen</button>
                    <input type="hidden" id="idUsuario" value="<%=Session["idUsuario"] %>" />

                </footer>
		    </form>
            <div id="miImagen">

			</div>			
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="jscripts" runat="server">
    <script type="text/javascript" src="../../js/Paginas/CiberCocina/Minutero.js"></script>
    <script type="text/javascript" src="../../js/libs/html2canvas.js"></script>
</asp:Content>

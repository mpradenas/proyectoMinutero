<%@ Page Title="" Language="C#" MasterPageFile="~/paginaMaestra/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Minutero1.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        
    
      body{
          background-color:#cacfd2;
          /*font-family: 'Shadows Into Light', cursive;*/
          font-size: 16px;
          margin:0;
          padding:0;
          text-align:left;
      }

     #textos1 h4 p, #textos2 p, #textos3 h4 {
         color:black;    
        
      }
     
      #entrada
      {
          float:left;
          background-color:antiquewhite;
          width:400px;
          height:auto;
          margin:auto;
          padding:inherit;
          border:double;
          border-color:transparent;
      }
        #instrucciones {
          float: left;
         
          width:500px;
          padding:10px,5px,10px,5px;
          margin:0;
          border:solid;
          border-color:transparent;
        }
        #carrusel {
          float:left;
          width:200%;
          height:auto;
          margin:auto;
           padding:10px,5px,10px,5px;
          border:solid;
          border-color:transparent;
        }
     #contenedor{	  	
         background-image:url(../img/ImagenPrincipal.jpg);
         background-repeat:no-repeat;
         width:1000px;
	
         margin:0 auto;

         overflow: hidden;
         text-align:center;
         height:auto;
         border-right: 1px solid #999;
         border-left: 1px solid #999;
         box-shadow:rgba(0,0,0,0.3) 0px 0px 10px 0px;

     }
        h1 {
            font-size:xx-large;
            font-family:'Comic Sans MS';

        }

        h1 , h2, span {
            text-align:center;
            color:white;
            
        }

        #hh {
            color:black;
        }
        #articulo1 header {
         width:960px;
         background-color:#4c4f53!important;
         color:#ecf0f1;
         text-align:justify;
         height:auto;
         /*font-family: 'Lobster', cursive;*/
        }

      
        
      </style>
  
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ribbons" runat="server">
  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="wp" runat="server">
    <div class="row">    
        <div id="contenedor">
         <article id="articulo1">
		<header>
           <h1>Bienvenido</h1>
         
          <h2><%=Session["usuario"] %></h2>
        
	    </header>
	    <section id="entrada">
             
            <h2 id="hh">Sobre Minutero</h2>
	 	
           <fieldset>
            <legend></legend>
           <p><img src="<%=ResolveClientUrl("~") %>img/imagenPrincipal.jpg" width="300" height="300" ></p>
        
            <p>
        	Básicamente ,el propósito de este sitio es simplificar<br />
        	la manera en la que actualmente se hacen las minutas en casinos.<br />
        	Comúnmente  se hace todo por al menos 3 preocesos cada mes<br />
        	,y esto quita tiempo valioso a cada empresa PYME.<br />
        	</p>
        
        	<p>
               Por esta razón, hemos creado esta pequeña, pero necesaria herramienta <br />
               para aquellos emprendedores de casinos que apenas comienzan , y que no gozan <br />
               de tiempo suficiente como escribir las minutas cada mes.  
        	</p>
           </fieldset>
        </section>
        
     </article>
     <article>
         
     </article>
    
     <article class="col-sm-12 col-md-12 col-lg-6" id="instrucciones">
				
							<!-- Widget ID (each widget will need unique ID)-->
							<div class="jarviswidget jarviswidget-color-darken" id="wid-id-0" data-widget-editbutton="false" data-widget-deletebutton="false">
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
									<span class="widget-icon"> <i class="fa fa-check"></i> </span>
									<h2>Instrucciones </h2>
				
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
				
										<div class="row">
											<form id="wizard-1" novalidate="novalidate">
												<div id="bootstrap-wizard-1" class="col-sm-12">
													<div class="form-bootstrapWizard">
														<ul class="bootstrapWizard form-wizard">
															<li class="active" data-target="#step1">
																<a href="#tab1" data-toggle="tab"> <span class="step">1</span> <span class="title">Pasos iniciales</span> </a>
															</li>
															<li data-target="#step2">
																<a href="#tab2" data-toggle="tab"> <span class="step">2</span> <span class="title">Guardar Datos</span> </a>
															</li>
															<li data-target="#step3">
																<a href="#tab3" data-toggle="tab"> <span class="step">3</span> <span class="title">Crear Minuta</span> </a>
															</li>
															<li data-target="#step4">
																<a href="#tab4" data-toggle="tab"> <span class="step">4</span> <span class="title">Descargar resultados</span> </a>
															</li>
                                                            
														</ul>
														<div class="clearfix"></div>
													</div>
													<div class="tab-content">
														<div class="tab-pane active" id="tab1">
															<br>
															<h3><strong>Paso 1 </strong> - Ingresar Tipos</h3>
				
															<div class="row">
				
																<div class="col-sm-12">
																	
                                                                    <section>
                                                                     <p>Ingresar "Tipos de bebestibles" y "Tipo de comida".<br />
                                                                      </p>    
																	</section>
				                                                    
																</div>
				
															</div>
				
														
														
				
														</div>
														<div class="tab-pane" id="tab2">
															<br>
															<h3><strong>Paso 2</strong> - Ingresar su menues</h3>
				
															<div class="row">
																<div class="col-sm-12">
																      <p>Luego de ya haber ingresado los tipos de comida y bebida,<br />
                                                                           puedes comenzar a agregar platos, bebidas o postres.
                                                                      </p>
                                                                </div>
																
															</div>
														</div>
														<div class="tab-pane" id="tab3">
															<br>
															<h3><strong>Paso 3</strong> - realizar minuta</h3>
														    
                                                            <div class="row">
																<div class="col-sm-12">
                                                                <section>
                                                                    <p>Este paso consta de una lista de acciones, que no necesariamente requieren un orden</p>
                                                                    <ul>
                                                                        <li>seleccionar plato principal,acompañamiento, bebestible y postre</li>
                                                                        <li>seleccionar aceptar</li>
                                                                        <li>arrastrar la elección al calendario de actividades</li>
                                                                        <li>Guardar Imagen Minuta</li>
                                                                        
                                                                    </ul>
                                                                </section>
                                                                </div>
                                                            </div>
														</div>
														<div class="tab-pane" id="tab4">
															<br>
															<h3><strong>Paso 4</strong> - Descargar imagen</h3>
															<br>
                                                            <div class="row">
                                                                <div class="col-sm-12">
                                                                    <section>
                                                                        <p>Una vez guardada la imagen, debes dirigirte a "Galería" y presionar en el ícono de descarga</p>
                                                                    
                                                                    </section>
                                                                </div>
                                                                <br>
                                                            
                                                            <h1 class="text-center text-success"><strong><i class="fa fa-check fa-lg"></i> Y eso es todo... ¡así de fácil!</strong></h1>
															<br>
															
                                                            </div>
                                                            
														</div>
                                                        
				
														
				
													</div>
												</div>
											</form>
										</div>
				
									</div>
									<!-- end widget content -->
				
								</div>
								<!-- end widget div -->
				
							</div>
							<!-- end widget -->
				
						</article>
                        <br />
                        <div class="row" id="carrusel">
				
						<h2 class="row-seperator-header"> </h2>
				
						<div class="col-sm-12">
				
							<div class="row">
				
								<div class="col-sm-12 col-md-12 col-lg-6">
				
									<!-- well -->
									<div class="well">
										<h3>Minutero</h3>
										<p>
											Tu mejor herramienta 

										</p>
										<div id="myCarousel-2" class="carousel slide">
											<ol class="carousel-indicators">
												<li data-target="#myCarousel-2" data-slide-to="0" class="active"></li>
												<li data-target="#myCarousel-2" data-slide-to="1" class=""></li>
												<li data-target="#myCarousel-2" data-slide-to="2" class=""></li>
											</ol>
											<div class="carousel-inner">
												<!-- Slide 1 -->
												<div class="item active">
													<img src="<%=ResolveClientUrl("~") %>img/cubiertos.jpg" alt="">
													<div class="carousel-caption caption-right" id="textos1">
														<h4>Minutero</h4>
														<p>
                                                            Lo que antes tardaba horas .....
														</p>
														<br>
													
													</div>
												</div>
												<!-- Slide 2 -->
												<div class="item">
													<img src="<%=ResolveClientUrl("~") %>img/ImagenPrincipal.jpg" alt="">
													<div class="carousel-caption caption-left"id="textos2">
														<p>
                                                            Hoy tardará sólo un par de minutos
														</p>
														<br>
														
													</div>
												</div>
												<!-- Slide 3 -->
												<div class="item">
													<img src="<%=ResolveClientUrl("~") %>img/chef.jpg" alt="">
													<div class="carousel-caption" id="textos3">
														
													</div>
												</div>
											</div>
											<a class="left carousel-control" href="#myCarousel-2" data-slide="prev"> <span class="glyphicon glyphicon-chevron-left"></span> </a>
											<a class="right carousel-control" href="#myCarousel-2" data-slide="next"> <span class="glyphicon glyphicon-chevron-right"></span> </a>
										</div>
				
									</div>
									<!-- end well-->
				
								</div>
                          </div>
    
      
	            </div>
        </div>
	</div>
   </div>	
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="jscripts" runat="server">
    <script type="text/javascript" src="js/default.js"></script>

</asp:Content>


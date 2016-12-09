<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Minutero1.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta charset="utf-8"/>
		<title>Minutero</title>
		<meta name="description" content=""/>
		<meta name="author" content=""/>
		<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no"/>
		
		<!-- #CSS Links -->
		<!-- Basic Styles -->
		<link rel="stylesheet" type="text/css" media="screen" href="<%=ResolveClientUrl("~")%>css/bootstrap.min.css"/>
		<link rel="stylesheet" type="text/css" media="screen" href="<%=ResolveClientUrl("~")%>css/font-awesome.min.css"/>

		<!-- SmartAdmin Styles : Please note (smartadmin-production.css) was created using LESS variables -->
		<link rel="stylesheet" type="text/css" media="screen" href="<%=ResolveClientUrl("~")%>css/smartadmin-production.min.css"/>
		<link rel="stylesheet" type="text/css" media="screen" href="<%=ResolveClientUrl("~")%>css/smartadmin-skins.min.css"/>

		<!-- SmartAdmin RTL Support is under construction
			 This RTL CSS will be released in version 1.5
		<link rel="stylesheet" type="text/css" media="screen" href="css/smartadmin-rtl.min.css"> -->

		<!-- We recommend you use "your_style.css" to override SmartAdmin
		     specific styles this will also ensure you retrain your customization with each SmartAdmin update.
		<link rel="stylesheet" type="text/css" media="screen" href="css/your_style.css"> -->

		<!-- Demo purpose only: goes with demo.js, you can delete this css when designing your own WebApp -->
		<link rel="stylesheet" type="text/css" media="screen" href="<%=ResolveClientUrl("~")%>css/demo.min.css"/>

		<!-- #FAVICONS -->
		<link rel="shortcut icon" href="<%=ResolveClientUrl("~")%>img/favicon/favicon.ico" type="image/x-icon"/>
		<link rel="icon" href="<%=ResolveClientUrl("~")%>img/favicon/favicon.ico" type="image/x-icon"/>

		<!-- #GOOGLE FONT -->
		<link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Open+Sans:400italic,700italic,300,400,700"/>

		<!-- #APP SCREEN / ICONS -->
		<!-- Specifying a Webpage Icon for Web Clip 
			 Ref: https://developer.apple.com/library/ios/documentation/AppleApplications/Reference/SafariWebContent/ConfiguringWebApplications/ConfiguringWebApplications.html -->
		<link rel="apple-touch-icon" href="<%=ResolveClientUrl("~")%>img/splash/sptouch-icon-iphone.png"/>
		<link rel="apple-touch-icon" sizes="76x76" href="<%=ResolveClientUrl("~")%>img/splash/touch-icon-ipad.png"/>
		<link rel="apple-touch-icon" sizes="120x120" href="<%=ResolveClientUrl("~")%>img/splash/touch-icon-iphone-retina.png"/>
		<link rel="apple-touch-icon" sizes="152x152" href="<%=ResolveClientUrl("~")%>img/splash/touch-icon-ipad-retina.png"/>
		
		<!-- iOS web-app metas : hides Safari UI Components and Changes Status Bar Appearance -->
		<meta name="apple-mobile-web-app-capable" content="yes"/>
		<meta name="apple-mobile-web-app-status-bar-style" content="black"/>
		
		<!-- Startup image for web apps -->
		<link rel="apple-touch-startup-image" href="<%=ResolveClientUrl("~")%>img/splash/ipad-landscape.png" media="screen and (min-device-width: 481px) and (max-device-width: 1024px) and (orientation:landscape)"/>
		<link rel="apple-touch-startup-image" href="<%=ResolveClientUrl("~")%>img/splash/ipad-portrait.png" media="screen and (min-device-width: 481px) and (max-device-width: 1024px) and (orientation:portrait)"/>
		<link rel="apple-touch-startup-image" href="<%=ResolveClientUrl("~")%>img/splash/iphone.png" media="screen and (max-device-width: 320px)"/>
        <style>
            #FotoCentral {
                height:150%;
                width:150%;
            }
          
        </style>
	</head>
	<body id="login">
		<!-- possible classes: minified, no-right-panel, fixed-ribbon, fixed-header, fixed-width-->
		<header id="header">
			<!--<span id="logo"></span>-->

			<div id="logo-group">
				<span id="logo"> <img src="<%=ResolveClientUrl("~")%>img/logo.png" alt=""/> </span>

				<!-- END AJAX-DROPDOWN -->
			</div>

			<span id="extr-page-header-space"> <span class="hidden-mobile">Ya estas registrado?</span> <a href="<%=ResolveClientUrl("~")%>Login.aspx" class="btn btn-danger">Ingresa</a> </span>

		</header>

		<div id="main" role="main">

			<!-- MAIN CONTENT -->
			<div id="content" class="container">

				<div class="row">
					<div class="col-xs-12 col-sm-12 col-md-7 col-lg-7 hidden-xs hidden-sm">
						<h1 class="txt-color-red login-header-big">Minutero</h1>
						<div class="hero">

							<img src="img/cubiertos.jpg" id="FotoCentral" alt="" class="pull-right display-image"/>
							
						</div>

						
						</div>
                        <div class="col-xs-12 col-sm-12 col-md-5 col-lg-5">
						<div class="well no-padding">

							<form action="php/demo-register.php" id="smart-form-register" class="smart-form client-form">
								<header>
									 Registrarse es gratis
								</header>

								<fieldset>
                                    <legend>Formulario de registro</legend>
									<section>
										<label class="input"> <i class="icon-append fa fa-user"></i>
											<input type="text" name="username" placeholder="Nombre Usuario"/>
											<b class="tooltip tooltip-bottom-right">Es para entrar al sitio</b> </label>
									</section>
                                    <section>
										<label class="input"> <i class="icon-append fa fa-user"></i>
											<input type="text" name="empresa" placeholder="Empresa"/>
											<b class="tooltip tooltip-bottom-right">Es necesario para el perfil de tu empresa</b> </label>
									</section>
                                    <section>
										<label class="input"> <i class="icon-append fa fa-user"></i>
											<input type="text" name="Rutempresa" placeholder="Rut Empresa"/>
											<b class="tooltip tooltip-bottom-right">Es necesario para completar datos de tu empresa</b> </label>
									</section>
									<section>
										<label class="input"> <i class="icon-append fa fa-envelope"></i>
											<input type="email" name="email" id="email" placeholder="Email address"/>
											<b class="tooltip tooltip-bottom-right">Se necesita para varificar tu cuenta</b> </label>
									</section>

									<section>
										<label class="input"> <i class="icon-append fa fa-lock"></i>
											<input type="password" name="password" placeholder="Password" id="password"/>
											<b class="tooltip tooltip-bottom-right">No olvides tu contraseña</b> </label>
									</section>

									<section>
										<label class="input"> <i class="icon-append fa fa-lock"></i>
											<input type="password" name="passwordConfirm" placeholder="Confirm password"/>
											<b class="tooltip tooltip-bottom-right">No olvides tu contraseña</b> </label>
									</section>
								</fieldset>

								<fieldset>
                                    <legend>Datos Personales</legend>
									<div class="row">
										<section class="col col-6">
											<label class="input">
												<input type="text" name="Nombre" id="nombre"placeholder="Primer Nombre"/>
											</label>
										</section>
										<section class="col col-6">
											<label class="input">
												<input type="text" name="Apellido" id="Apellido" placeholder="Apellidos"/>
											</label>
										</section>
                                      
									</div>
                                    <div class="row">
                                        <section class="col col-6">
										<label class="label">
                                            Tipo de usuario
                                        </label>
										<select class="select" id="TipoUsuario">
                                            <option disabled="disabled" selected="selected">Selecciona Tipo de cuenta</option>
										    <option value="0">Usuario</option>
                                            <option value="1">Administrador</option>
                                        </select>
                                        
									</section>

                                    </div>

									

									
								</fieldset>
								<footer>
									<button type="submit" class="btn btn-primary">
										Registrar
									</button>
								</footer>

								<div class="message">
									<i class="fa fa-check"></i>
									<p>
										Gracias por registrarte!
									</p>
								</div>
							</form>

						</div>
						
					</div>
				</div>
			</div>

		</div>

		<!-- Modal -->
	    <!--================================================== -->	

		<!-- PACE LOADER - turn this on if you want ajax loading to show (caution: uses lots of memory on iDevices)-->
		<script src="<%=ResolveClientUrl("~")%>js/plugin/pace/pace.min.js"></script>

	    <!-- Link to Google CDN's jQuery + jQueryUI; fall back to local -->
	    <script src="<%=ResolveClientUrl("~")%>//ajax.googleapis.com/ajax/libs/jquery/2.0.2/jquery.min.js"></script>
		<script> if (!window.jQuery) { document.write('<script src="<%=ResolveClientUrl("~")%>js/libs/jquery-2.0.2.min.js"><\/script>'); } </script>

	    <script src="//ajax.googleapis.com/ajax/libs/jqueryui/1.10.3/jquery-ui.min.js"></script>
		<script> if (!window.jQuery.ui) { document.write('<script src="<%=ResolveClientUrl("~")%>js/libs/jquery-ui-1.10.3.min.js"><\/script>'); } </script>

		<!-- JS TOUCH : include this plugin for mobile drag / drop touch events 		
		<script src="js/plugin/jquery-touch/jquery.ui.touch-punch.min.js"></script> -->

		<!-- BOOTSTRAP JS -->		
		<script src="<%=ResolveClientUrl("~")%>js/bootstrap/bootstrap.min.js"></script>

		<!-- JQUERY VALIDATE -->
		<script src="<%=ResolveClientUrl("~")%>js/plugin/jquery-validate/jquery.validate.min.js"></script>
		
		<!-- JQUERY MASKED INPUT -->
		<script src="<%=ResolveClientUrl("~")%>js/plugin/masked-input/jquery.maskedinput.min.js"></script>
		
		<!--[if IE 8]>
			
			<h1>Your browser is out of date, please update your browser by going to www.microsoft.com/download</h1>
			
		<![endif]-->

		<!-- MAIN APP JS FILE -->
		<script src="<%=ResolveClientUrl("~")%>js/app.min.js"></script>
        <script type="text/javascript" src="js/Registro.js"></script>
	</body>
</html>

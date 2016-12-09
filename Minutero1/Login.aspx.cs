using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Minutero1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.HttpMethod == "GET") 
            {
                
            }
            else if (HttpContext.Current.Request.HttpMethod == "POST") 
            {
                if (Request["action"] == "login") 
                {
                     
                    string Usuario = Request["usuario"].ToString();
                    string Contraseña=Request["clave"].ToString();
                   

                    Controlador.login loguear = new Controlador.login(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString);
                    try
                    {
                        Modelo.ObjUsuario confirm=loguear.abreLogin(Usuario,Contraseña);
                        if (confirm !=null)
                        {
                            if (confirm.TipoUsuario == 0)
                            {
                                Session.Timeout = 1440;
                                Session["RutEmpresa"] = confirm.RutEmpresa;
                                Session["idusuario"] = confirm.idUsuario;
                                Session["usuario"] = confirm.nickName;
                                Session["nombreusuario"] = confirm.Nombre;
                                Session["FechaActual"] = DateTime.Now.ToShortDateString();
                                Response.Write("//OK//Bienvenido :" + Session["nombreusuario"].ToString() + " //");
                        
                            }
                            else
                            {
                                Session.Timeout = 1440;
                                Session["RutEmpresa"] = confirm.RutEmpresa;
                                Session["idusuario"] = confirm.idUsuario;
                                Session["usuario"] = confirm.nickName;
                                Session["nombreusuario"] = confirm.Nombre;
                                Session["FechaActual"] = DateTime.Now.ToShortDateString();
                               
                                Response.Write("//OKAdmin//Bienvenido administrador:" + Session["nombreusuario"].ToString() + " //");
                             
                            }
                        }
                        else 
                        {
                            Response.Write("//NOK//No has podido iniciar sesión//");
                        }
                    }
                    catch (Exception ex)
                    {
                        
                        Response.Write("//NOK//Ha ocurrido un error al tratar de iniciar sesión."+ex.Message.ToString()+"//");
                    }
                    Response.End();

                }
            }
        }
    }
}
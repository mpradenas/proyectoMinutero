using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Minutero1
{
    public partial class administracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "Administración";
            if (HttpContext.Current.Request.HttpMethod == "POST") 
            {
                if (Request["action"] == "cambiaEstado")
                {
                    int idUsuario = int.Parse(Request["idUsuario"].ToString());
                    int NuevoEstado = int.Parse(Request["cambiarEstado"].ToString());
                    Controlador.Usuario processUsuario = new Controlador.Usuario(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString);
                    try
                    {
                        bool confirm = processUsuario.activaDesactiva(idUsuario, NuevoEstado);
                        if (confirm)
                        {
                            Response.Write("//OK//hecho exitosamente//");
                        }
                        else
                        {
                            Response.Write("//No se ha podido hacer el cambio exitosamente//");
                        }
                    }
                    catch (Exception ex)
                    {

                        Response.Write("//NOK//No se ha podido hacer el cambio exitosamente:" + ex.Message.ToString() + "//");
                    }
                }
                else if (Request["action"] == "cierraSesion")
                {
                    this.Session.Clear();
                    this.Session.Abandon();
                    Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                    
                }
                else if (Request["action"] == "eliminaUSuario")
                {
                    int idusuario = int.Parse(Request["idUsuario"].ToString());
                    Controlador.Usuario processUsuario = new Controlador.Usuario(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString);

                    try
                    {
                        bool confirm = processUsuario.eliminaUsuario(idusuario);
                        if (confirm)
                        {
                            Response.Write("//OK//Se ha eliminado el usuario seleccionado exitosamente.//");
                        }
                        else 
                        {
                            Response.Write("//NOK//No se ha podido eliminar el usuario.//");
                        }
                    }
                    catch (Exception ex)
                    {
                        
                           Response.Write("//NOK//Ha ocurrido un error al tratar de eliminar usuario:"+ex.Message.ToString()+"//");
                           
                    }
                }
            }
            
            
        }
    }
}
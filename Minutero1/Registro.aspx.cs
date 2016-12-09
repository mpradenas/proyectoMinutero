using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Minutero1
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "Registro";
            if(HttpContext.Current.Request.HttpMethod=="POST")
            {
                if (Request["action"] == "registra") 
                {
                    string nombre = Request["nombre"].ToString();
                    string nickname=Request["nickName"].ToString();
                    string contrasena=Request["contrasena"].ToString();
                    string email=Request["correo"].ToString();
                    string empresa=Request["empresa"].ToString();
                    string RutEmpresa = Request["rutempresa"].ToString();
                    int TipoUsuario=int.Parse(Request["tipoUsuario"].ToString());
                    //debes conseguir las funciones de validación wde rut para seguir en esto//;
                    Controlador.Registro regs = new Controlador.Registro(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString);
                    try
                    {
                        bool confirma = regs.RegistraUsuario(nickname,contrasena,nombre,email,empresa,RutEmpresa,TipoUsuario);
                        if (confirma)
                        {
                            Response.Write("//OK//");
                        }
                        else 
                        {
                            Response.Write("//NOK//");
                        }
                    }
                    catch(Exception ex)
                    {

                        Response.Write("//NOK// ha ocurrido algún error "+ex.Message.ToString()+"//");
                        Response.Close();
                    }
                    
                }
            }

        }
    }
}
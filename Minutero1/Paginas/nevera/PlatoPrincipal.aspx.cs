using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Minutero1.Paginas.nevera
{
    public partial class PlatoPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title="Plato Principal";
            if (HttpContext.Current.Request.HttpMethod == "POST") 
            {
                if (Request["action"] == "GuardarPlato") 
                {

                    int idPlatoPrincipal = int.Parse(Request["idPlato"].ToString());
                    string NombrePlato = Request["nombrePlato"].ToString();
                    string descripcion = Request["descripcion"].ToString();
                    int idTipoPlato = int.Parse(Request["tipoPlato"].ToString());
                    

                    Controlador.PlatoPrincipal ElPPrincipal = new Controlador.PlatoPrincipal(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString);
                    try
                    {
                        bool confirm = ElPPrincipal.GuardaPPrincipal(idPlatoPrincipal,NombrePlato,descripcion,idTipoPlato,Session["RutEmpresa"].ToString());
                        if (confirm)
                        {
                            Response.Write("//OK//Se ha guardado plato sin inconvenientes//");
                        }
                        else 
                        {
                            Response.Write("//NOK//No se ha podido guardar plato//");
                        }

                    }
                    catch (Exception ex)
                    {

                        Response.Write("//NOK//Ha ocurrido algún error al intentar guardar el dato:"+ex.Message.ToString()+"//");

                    }
                 
                }
                else if (Request["action"] == "EliminaPlato") 
                {
                    int idPlatoPrincipal = int.Parse(Request["idPlatoPrincipal"].ToString());
                    Controlador.PlatoPrincipal PPrincpal = new Controlador.PlatoPrincipal(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString);
                    try
                    {
                        bool confirm = PPrincpal.EliminaPPrincipal(idPlatoPrincipal);
                        if (confirm)
                        {
                         
                            Response.Write("//OK//Se ha eliminado sin inconvenientes//");
                        
                        }
                        else 
                        {
                            
                            Response.Write("//NOK//No se ha podido eliminar el plato principal//");

                        }
                    }
                    catch (Exception ex)
                    {

                        Response.Write("//NOK//ha ocurrido un error al intentar eliminar el plato:"+ex.Message.ToString()+"//");
                        
                    }
                }
                else if (Request["action"] == "ConsultaTipoComida") 
                {
                    Controlador.PlatoPrincipal procsPPrincipal = new Controlador.PlatoPrincipal(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString);
                    try
                    {
                        bool confirm = procsPPrincipal.existeDatos();
                        if (confirm)
                        {
                            Response.Write("//OK//");
                            Response.End();
                        }
                        else
                        {
                            Response.Write("//NOK//Antes de Ingresar datos a Plato Principal, debes ingresar datos en 'plato principal'.¿Deseas ser redireccionado a 'plato principal'?//");

                        }
                    }
                    catch (Exception ex)
                    {

                        Response.Write("//NOK2//Ha ocurrido algún error:" + ex.Message.ToString() + "//");
                        Response.End();
                    }
                }

            }
            else if (HttpContext.Current.Request.HttpMethod == "GET") 
            {
                
            }
        }
    }
}
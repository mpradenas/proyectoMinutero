using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Minutero1.Paginas.nevera
{
    public partial class Bebestibles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "Bebestibles";

            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                if (Request["action"] == "GuardarBebestible")
                {

                    int idBebestible = int.Parse(Request["idBebestible"].ToString());
                    string NombreBebestible = Request["nombreBebestible"].ToString();
                    string descripcion = Request["descripcion"].ToString();
                    int idTipoBebida = int.Parse(Request["tipoBebida"].ToString());
                
                    Controlador.Bebestibles ElBebest = new Controlador.Bebestibles(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString);
                    try
                    {
                        bool confirm = ElBebest.GuardaBebestibles(idBebestible, NombreBebestible, descripcion, idTipoBebida,Session["RutEmpresa"].ToString());
                        if (confirm)
                        {
                            Response.Write("//OK//Se ha guardado Bebestible sin inconvenientes//");
                        }
                        else
                        {
                            Response.Write("//NOK//No se ha podido guardar Bebestible//");
                        }

                    }
                    catch (Exception ex)
                    {

                        Response.Write("//NOK//Ha ocurrido algún error al intentar guardar el dato:" + ex.Message.ToString() + "//");

                    }

                }
                else if (Request["action"] == "EliminaBebestibles")
                {
                    int idBebestibles = int.Parse(Request["idBebestible"].ToString());
                    Controlador.Bebestibles Bebestib = new Controlador.Bebestibles(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString);
                    try
                    {
                        bool confirm = Bebestib.EliminaBebestible(idBebestibles);
                        if (confirm)
                        {

                            Response.Write("//OK//Se ha eliminado sin inconvenientes//");

                        }
                        else
                        {

                            Response.Write("//NOK//No se ha podido eliminar el bebestible//");

                        }
                    }
                    catch (Exception ex)
                    {

                        Response.Write("//NOK//ha ocurrido un error al intentar eliminar el bebestible:" + ex.Message.ToString() + "//");

                    }
                }
                else if (Request["action"] == "ConsultaTipoBebestible") 
                {
                    
                    Controlador.Bebestibles procsBebestibles = new Controlador.Bebestibles(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString);
                    try
                    {
                        bool confirm = procsBebestibles.ConsultaTipoBebestible();
                        if(confirm)
                        {
                            Response.Write("//OK//");
                            Response.End();
                        }
                        else 
                        {
                            Response.Write("//NOK//Antes de Ingresar datos a Bebestibles, debes ingresar datos en 'tipo bebida'.¿Deseas ser redireccionado a 'tipo bebida'?//");
                           
                        }
                    }
                    catch (Exception ex)
                    {

                        Response.Write("//NOK2//Ha ocurrido algún error:"+ex.Message.ToString()+"//");
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
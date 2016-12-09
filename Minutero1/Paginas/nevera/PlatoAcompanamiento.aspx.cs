using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Minutero1.Paginas.nevera
{
    public partial class PlatoAcompanamiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "Plato acompañamiento";

            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                if (Request["action"] == "GuardarPlato")
                {

                    int idPlatoAcomp = int.Parse(Request["idPlato"].ToString());
                    string NombrePlato = Request["nombrePlato"].ToString();
                    string descripcion = Request["descripcion"].ToString();
                    int idTipoPlato = int.Parse(Request["tipoPlato"].ToString());
                    Controlador.PlatoAcompanamiento ElPAcomp = new Controlador.PlatoAcompanamiento(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString);
                    try
                    {
                        bool confirm = ElPAcomp.GuardaPAcomp(idPlatoAcomp, NombrePlato, descripcion, idTipoPlato,Session["RutEmpresa"].ToString());
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

                        Response.Write("//NOK//Ha ocurrido algún error al intentar guardar el dato:" + ex.Message.ToString() + "//");

                    }

                }
                else if (Request["action"] == "EliminaPlato")
                {
                    int idPlatoAcomp = int.Parse(Request["idPlatoAcompanamiento"].ToString());
                    Controlador.PlatoAcompanamiento PAcomp = new Controlador.PlatoAcompanamiento(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString);
                    try
                    {
                        bool confirm = PAcomp.EliminaPAcomp(idPlatoAcomp);
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

                        Response.Write("//NOK//ha ocurrido un error al intentar eliminar el plato:" + ex.Message.ToString() + "//");

                    }
                }
                else if (Request["action"] == "ConsultaTipoComida") 
                {
                     Controlador.PlatoAcompanamiento procsPacomp = new Controlador.PlatoAcompanamiento(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString);
                    try
                    {
                        bool confirm = procsPacomp.existeDatos();
                        if(confirm)
                        {
                            Response.Write("//OK//");
                            Response.End();
                        }
                        else 
                        {
                            Response.Write("//NOK//Antes de Ingresar datos a Plato acompanamiento, debes ingresar datos en 'plato acompañamiento'.¿Deseas ser redireccionado a 'plato acompañamiento'?//");
                           
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
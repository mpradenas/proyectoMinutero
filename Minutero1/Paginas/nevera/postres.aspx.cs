using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Minutero1.Paginas.nevera
{
    public partial class postres : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "Postres";
            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                if (Request["action"] == "GuardaPostre")
                {

                    int idPostre = int.Parse(Request["idPostre"].ToString());
                    string NombrePostre = Request["nombrePostre"].ToString();
                    string descripcion = Request["descripcion"].ToString();
                    Controlador.Postres ProcPostres = new Controlador.Postres(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString);
                    try
                    {
                        bool confirm = ProcPostres.GuardaPostre(idPostre, NombrePostre, descripcion,Session["RutEmpresa"].ToString());
                        if (confirm)
                        {
                            Response.Write("//OK//Se ha guardado postre sin inconvenientes//");
                        }
                        else
                        {
                            Response.Write("//NOK//No se ha podido guardar postre//");
                        }

                    }
                    catch (Exception ex)
                    {

                        Response.Write("//NOK//Ha ocurrido algún error al intentar guardar el dato:" + ex.Message.ToString() + "//");

                    }

                }
                else if (Request["action"] == "EliminaPostre")
                {
                    int idPostre = int.Parse(Request["idPostre"].ToString());
                    Controlador.Postres ProcPostre = new Controlador.Postres(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString);
                    try
                    {
                        bool confirm = ProcPostre.EliminaPostres(idPostre);
                        if (confirm)
                        {

                            Response.Write("//OK//Se ha eliminado sin inconvenientes//");

                        }
                        else
                        {

                            Response.Write("//NOK//No se ha podido eliminar el postre//");

                        }
                    }
                    catch (Exception ex)
                    {

                        Response.Write("//NOK//ha ocurrido un error al intentar eliminar el postre:" + ex.Message.ToString() + "//");

                    }
                }

            }
            else if (HttpContext.Current.Request.HttpMethod == "GET")
            {

            }
        }
    }
}
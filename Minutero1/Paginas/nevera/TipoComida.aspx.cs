using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Minutero1.Paginas.nevera
{
    public partial class TipoComida : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "Tipo Comida";
            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                if (Request["action"] == "GuardarTipoComida")
                {

                    int idTipoComida = int.Parse(Request["idTipoComida"].ToString());
                    string descripcion = Request["descripcionTipoComida"].ToString();
                    Controlador.TipoComida procTipoComida = new Controlador.TipoComida(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString);
                    try
                    {
                        bool confirm = procTipoComida.guardaTipoComida(idTipoComida, descripcion,Session["RutEmpresa"].ToString());
                        if (confirm)
                        {
                            Response.Write("//OK//Se ha guardado el tipo de comida sin inconvenientes sin inconvenientes//");
                        }
                        else
                        {
                            Response.Write("//NOK//No se ha podido guardar el tipo de comida//");
                        }

                    }
                    catch (Exception ex)
                    {

                        Response.Write("//NOK//Ha ocurrido algún error al intentar guardar el dato:" + ex.Message.ToString() + "//");

                    }

                }
                else if (Request["action"] == "EliminaTipoComida")
                {
                    int idTipoComida = int.Parse(Request["idTipoComida"].ToString());
                    Controlador.TipoComida ProcTipoComida = new Controlador.TipoComida(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString);
                    try
                    {
                        bool confirm = ProcTipoComida.eliminarTipoComida(idTipoComida);
                        if (confirm)
                        {

                            Response.Write("//OK//Se ha eliminado sin inconvenientes//");

                        }
                        else
                        {

                            Response.Write("//NOK//No se ha podido eliminar el tipo de Comida//");

                        }
                    }
                    catch (Exception ex)
                    {

                        Response.Write("//NOK//ha ocurrido un error al intentar eliminar el tipo Bebida:" + ex.Message.ToString() + "//");

                    }
                }

            }
            else if (HttpContext.Current.Request.HttpMethod == "GET")
            {

            }
        }
    }
}
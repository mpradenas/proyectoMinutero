using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Minutero1.Paginas.nevera
{
    public partial class tipobebida : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                if (Request["action"] == "GuardarTipoBebida")
                {

                    int idTipoBebida = int.Parse(Request["idTipoBebida"].ToString());
                    string descripcion = Request["descripcionTipoBebida"].ToString();
                    Controlador.Tipo_bebida procTipoBebida = new Controlador.Tipo_bebida(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString);
                    try
                    {
                        bool confirm = procTipoBebida.GuardaTipoBebida(idTipoBebida, descripcion,Session["RutEmpresa"].ToString());
                        if (confirm)
                        {
                            Response.Write("//OK//Se ha guardado el tipo de bebida sin inconvenientes sin inconvenientes//");
                        }
                        else
                        {
                            Response.Write("//NOK//No se ha podido guardar el tipo de bebida//");
                        }

                    }
                    catch (Exception ex)
                    {

                        Response.Write("//NOK//Ha ocurrido algún error al intentar guardar el dato:" + ex.Message.ToString() + "//");

                    }

                }
                else if (Request["action"] == "EliminaTipoBebida")
                {
                    int idTipoBebida = int.Parse(Request["idTipoBebida"].ToString());
                    Controlador.Tipo_bebida ProcTipoBebida = new Controlador.Tipo_bebida(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString);
                    try
                    {
                        bool confirm = ProcTipoBebida.EliminaTipoBebida(idTipoBebida);
                        if (confirm)
                        {

                            Response.Write("//OK//Se ha eliminado sin inconvenientes//");

                        }
                        else
                        {

                            Response.Write("//NOK//No se ha podido eliminar el tipo de bebida//");

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
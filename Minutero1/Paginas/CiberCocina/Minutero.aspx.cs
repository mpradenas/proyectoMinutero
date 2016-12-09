using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;
using iTextSharp;

namespace Minutero1.Paginas.CiberCocina
{
    public partial class Minutero : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["action"] == "guardaImagen") 
            {
             
                int idUsuario=int.Parse(Request["IdUsuario"].ToString());
                byte[] miImagen =Convert.FromBase64String(Request["imagenCalendario"]);
                string Fecha=DateTime.Now.ToShortDateString();
                Controlador.ImagenesMinuta ProcsImagMinuta = new Controlador.ImagenesMinuta(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString);
                
                try
                {
                    bool confirm = ProcsImagMinuta.guardaImagenMinuta(0, idUsuario, Fecha, miImagen);
                    if (confirm)
                    {
                        Response.Write("//OK//Se ha guardado la minuta sin inconvenientes. Para revisarla, dirígeta \"Galería\".//");
                        Response.End();
                    }
                    else 
                    {
                        Response.Write("//NOK//No se ha podido guardar la imagen//");
                    }
                }
                catch (Exception ex)
                {

                    Response.Write("//NOK//Ha ocurrido algún inconveniente al tratar de guardar el archivo:" + ex.Message.ToString() + "//");
                }

            }

           
        }
    }
}
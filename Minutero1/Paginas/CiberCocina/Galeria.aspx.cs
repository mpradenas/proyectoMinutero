using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Minutero1.Paginas.CiberCocina
{
    public partial class Galeria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.HttpMethod == "GET") 
            {
                if (Request["action"] == "traeImagenes") 
                {
                    int idUsuario = int.Parse(Request["idUsuario"].ToString());
                    Modelo.ImagenesMinuta ProcsImagenesMinuta = new Modelo.ImagenesMinuta(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString);
                    List<Modelo.objImagenesMinuta> ListImagenesMinuta = new List<Modelo.objImagenesMinuta>();
                    ListImagenesMinuta = ProcsImagenesMinuta.getListImagenes(idUsuario);
                    try
                    {
                        if (ListImagenesMinuta != null) 
                        {
                            string cadenaDatos = "";
                            //<!-- SuperBox -->
	                        cadenaDatos="<div class=\"superbox col-sm-12\">";
		               
		            
	                        //<!-- /SuperBox -->


                            foreach (Modelo.objImagenesMinuta laImagen in ListImagenesMinuta)
                            {

                               


                                cadenaDatos = cadenaDatos + "<button type='button' class='btn btn-danger' onclick='eliminaImagen(" + laImagen.idImagenMinuta + ")'><i class='fa fa-trash-o'></i></button>";
                                cadenaDatos = cadenaDatos + "<a href='" + ResolveClientUrl("~") + "general/ImagenesMinutas.aspx?idimg=" + laImagen.idImagenMinuta + "' class='btn btn-warning' download><i class='fa fa-file-image-o'></i></a>";
                                cadenaDatos=cadenaDatos+"<div class=\"superbox-list\">";
                                cadenaDatos = cadenaDatos + "<img src='" + ResolveClientUrl("~") + "general/ImagenesMinutas.aspx?idimg=" + laImagen.idImagenMinuta + "' data-img='" + ResolveClientUrl("~") + "general/imagenesMinutas.aspx?idimg=" + laImagen.idImagenMinuta + "' title='" + laImagen.nombreImagen.ToString().Trim() + "' class='superbox-img' >";
                                cadenaDatos=cadenaDatos + "</div>";
                               
                               
                               
                            }

                           
                            cadenaDatos = cadenaDatos + "<div class=\"superbox-float\"></div>";
                            cadenaDatos = cadenaDatos + "</div>";
                            cadenaDatos=cadenaDatos+"<div class=\"superbox-show\" style=\"height:300px; display: none\"></div>";

                            cadenaDatos=cadenaDatos+" </div>";

                            Response.Write(cadenaDatos);

                        }
                    }
                    catch (Exception)
                    {
                        
                        throw;
                    }
                    Response.End();
                    //Response.ContentType = "image/png";
                    //Response.BinaryWrite 
                }
                else if (Request["action"] == "pdf") 
                {
                      
                
                }


            }
            else if (HttpContext.Current.Request.HttpMethod == "POST") 
            {
                if (Request["action"] == "eliminaImagen") 
                {
                    int idImagen = int.Parse(Request["idImagen"].ToString());

                    Controlador.ImagenesMinuta procsImagenesMinuta = new Controlador.ImagenesMinuta(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString);
                    try
                    {
                        bool confirm = procsImagenesMinuta.BorrarImagen(idImagen);
                        if (confirm)
                        {
                            Response.Write("//OK//Se ha eliminado la imagen sin inconvenientes//");
                            Response.End();
                        }
                        else 
                        {
                            Response.Write("//NOK//No se ha podido eliminar la imagen//");
                            Response.End();
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("//NOK// Ha ocurrido un error al tratar de eliminar la imagen:"+ex.Message.ToString()+"//");
                        Response.End();
                        
                    }
                }
            
            }
       }
   }
}

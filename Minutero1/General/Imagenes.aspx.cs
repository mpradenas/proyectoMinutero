using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Minutero1.General
{
    public partial class Imagenes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int idImg = int.Parse(Request["idimg"].ToString());
            Modelo.objImagenesPerfilUsuario imagen = new Modelo.ImagenesPerfilUsuario(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString).GetImagenPerfilUsuario(idImg);
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "image/png";
            Response.AddHeader("content-disposition", "attachment;filename=img.png");
            Response.BinaryWrite(imagen.imagenes);
            Response.Flush();
            Response.End();

        
        }
    }
}
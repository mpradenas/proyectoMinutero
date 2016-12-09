using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Minutero1.General
{
    public partial class ImagenesMinutas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int idImg = int.Parse(Request["idimg"].ToString());
            Modelo.objImagenesMinuta imagen = new Modelo.ImagenesMinuta(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString).GetImagenMinuta(idImg);

            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "image/png";
            Response.AddHeader("content-disposition", "attachment;filename=img.png");
            Response.BinaryWrite(imagen.imagen);
            Response.Flush();
            Response.End();

        }
    }
}
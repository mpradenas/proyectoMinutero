using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Minutero1.paginaMaestra
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"].ToString() == null || Session["usuario"].ToString() == "") 
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}
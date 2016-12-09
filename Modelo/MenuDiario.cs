using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Modelo
{
    public class objMenuDiario
    {
        public int id_Menu;
        public objPlatoPrincipal idP_Principal { get; set; }
        public objPlatoAcompanamiento idP_Acomp { get; set; }
        public objBebestibles id_Bebestible { get; set; }
        public string DetalleEmpresa { get; set; }
        public DateTime Fecha_menu { get; set; }
    }
    
    public class MenuDiario 
    {
        string cnn = null;

        public MenuDiario(string ConnectionString) 
        {
            cnn = ConnectionString;
        }

        public objMenuDiario GetMenuDiario(int Id_menu)
        {
            BaseDatos db = new BaseDatos(cnn);
            string sql = "SELECT ID_Menu,ID_PPrincipal; ID_PACOMP,ID_Bebestible,ID_DETALLE,FECHAMENU FROM Minutero.dbo.Menu WHERE id_Menu=" + Id_menu;
            SqlDataReader dr = db.LlenaReader(sql);
            objMenuDiario elMenuDiario = new objMenuDiario();
            platoPrincipal PPrinc = new platoPrincipal(cnn);
            platoAcompanamiento PAcomp = new platoAcompanamiento(cnn);
            Bebestibles bebest = new Bebestibles(cnn);
            if (dr.Read())
            {
                elMenuDiario.id_Menu = int.Parse(dr[0].ToString());
                elMenuDiario.idP_Principal = PPrinc.GetPlatoPrincipal(int.Parse(dr[1].ToString()));
                elMenuDiario.idP_Acomp = PAcomp.GetElAcompanamiento(int.Parse(dr[2].ToString()));
                elMenuDiario.id_Bebestible = bebest.getBebestible(int.Parse(dr[3].ToString()));
                elMenuDiario.DetalleEmpresa = dr[4].ToString();
                elMenuDiario.Fecha_menu = DateTime.Parse(dr[5].ToString());
            }
            else 
            {
                
                elMenuDiario = null;

            }
            dr.Close();
            dr.Dispose();
            db.Close();
            return elMenuDiario;
        }

        public bool SetMenuDiario(objMenuDiario elMenuDiario)
        {
            BaseDatos db = new BaseDatos(cnn);
            string sql = "SELECT ID_Menu,ID_PPrincipal, ID_PACOMP,ID_Bebestible,ID_DETALLE,FECHAMENU FROM Minutero.dbo.Menu WHERE id_Menu=" +elMenuDiario.id_Menu;
            SqlDataReader dr = db.LlenaReader(sql);
            platoPrincipal PPrinc = new platoPrincipal(cnn);
            platoAcompanamiento PAcomp = new platoAcompanamiento(cnn);
            Bebestibles bebest = new Bebestibles(cnn);
            try
            {
                if (dr.Read())
                {
                    sql = "UPDATE Minutero.dbo.Menu SET ID_PPrincipal=" + elMenuDiario.idP_Principal.id_platoPrincipal + ", ID_PACOMP=" + elMenuDiario.idP_Acomp+ ",";
                    sql = sql + " ID_Bebestible=" + elMenuDiario.id_Bebestible.id_bebestible + ", ID_DETALLE='" + elMenuDiario.DetalleEmpresa.ToString() + "',FECHAMENU='" + elMenuDiario.Fecha_menu.ToShortDateString() + "' WHERE ID_Menu=" + elMenuDiario.id_Menu;
                }
                else
                {
                    sql = "INSERT INTO Minutero.dbo.Menu(ID_PPrincipal, ID_PACOMP,ID_Bebestible,ID_DETALLE,FECHAMENU)VALUES(" + elMenuDiario.idP_Principal.id_platoPrincipal + "," + elMenuDiario.idP_Acomp.id_platoAcomp + "," + elMenuDiario.id_Bebestible.id_bebestible + ",'"+elMenuDiario.DetalleEmpresa.ToString()+"','"+elMenuDiario.Fecha_menu.ToShortDateString()+"')";
                }
                db.Ejecuta(sql);
            }
            catch
            {

                return false;
            }
            dr.Close();
            dr.Dispose();
            db.Close();
            return true;
        }

        public List<objMenuDiario> GetListMenues()
        {
            BaseDatos db = new BaseDatos(cnn);
            string sql = "SELECT ID_Menu,ID_PPrincipal; ID_PACOMP,ID_Bebestible,ID_DETALLE,FECHAMENU FROM Minutero.dbo.Menu ";
            SqlDataReader dr = db.LlenaReader(sql);
            platoPrincipal PPrinc = new platoPrincipal(cnn);
            platoAcompanamiento PAcomp = new platoAcompanamiento(cnn);
            Bebestibles bebest = new Bebestibles(cnn);
            List<objMenuDiario> ListaMenuesDiarios = new List<objMenuDiario>();
            try
            {
                while (dr.Read())
                {
                    objMenuDiario elMenuDiario = new objMenuDiario();
                    elMenuDiario.id_Menu = int.Parse(dr[0].ToString());
                    elMenuDiario.idP_Principal = PPrinc.GetPlatoPrincipal(int.Parse(dr[1].ToString()));
                    elMenuDiario.idP_Acomp = PAcomp.GetElAcompanamiento(int.Parse(dr[2].ToString()));
                    elMenuDiario.id_Bebestible = bebest.getBebestible(int.Parse(dr[3].ToString()));
                    elMenuDiario.DetalleEmpresa = dr[4].ToString();
                    elMenuDiario.Fecha_menu = DateTime.Parse(dr[5].ToString());
                    ListaMenuesDiarios.Add(elMenuDiario);
                }

            }
            catch
            {

                ListaMenuesDiarios = null;
            }

            dr.Close();
            dr.Dispose();
            db.Close();
            return ListaMenuesDiarios;
        }

        public bool DeleteMenuDiario(objMenuDiario ElMenuDiario)
        {
            BaseDatos db = new BaseDatos(cnn);
            try
            {
                string sql = "DELETE  FROM Minutero.dbo.Menu WHERE id_Menu=" +ElMenuDiario.id_Menu;
                db.Ejecuta(sql);
            }
            catch
            {

                return false;
            }
            db.Close();
            return true;
        }

        
    }
}

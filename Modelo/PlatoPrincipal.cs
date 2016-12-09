using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace Modelo
{
    public class objPlatoPrincipal
    {
        public int id_platoPrincipal { get; set; }
        public string Nombre_plato { get; set; }
        public string descripcion { get; set; }
        public objTipoComida id_tipoComida { get; set; }
        public string RutEmpresa { get; set; }
    }

    public class platoPrincipal 
    {
        string cnn = null;

        public platoPrincipal(string ConnectionString) 
        {
            cnn = ConnectionString;
        }
        
        public bool isThereAnyPlatoPrincipal()
        {
            BaseDatos db = new BaseDatos(cnn);
            string sql = "SELECT * FROM Minutero.dbo.Plato_Principal";
            SqlDataReader dr = db.LlenaReader(sql);
            if (dr.Read())
            {
                return true;
            }
            dr.Close();
            dr.Dispose();
            db.Close();
            return false;
        }
        public objPlatoPrincipal GetPlatoPrincipal(int id_platoPrincipal) 
        {
            BaseDatos db = new BaseDatos(cnn);
            string sql = "SELECT ID_PPrincipal,Nombre_plato,Descripcion,id_TipoComida,rutEmpresa FROM Minutero.dbo.Plato_Principal";
            sql = sql + " WHERE id_PPrincipal=" + id_platoPrincipal;
            SqlDataReader dr = db.LlenaReader(sql);
            objPlatoPrincipal ElPlatoPrincipal = new objPlatoPrincipal();
            TipoComida tipo_comid= new TipoComida(cnn);
            if (dr.Read())
            {
                ElPlatoPrincipal.id_platoPrincipal = int.Parse(dr[0].ToString());
                ElPlatoPrincipal.Nombre_plato = dr[1].ToString();
                ElPlatoPrincipal.descripcion = dr[2].ToString();
                ElPlatoPrincipal.id_tipoComida = tipo_comid.getTipoComida(int.Parse(dr[3].ToString()));
                ElPlatoPrincipal.RutEmpresa = dr[4].ToString();
            }
            else 
            {
                ElPlatoPrincipal = null;
            }
            dr.Close();
            dr.Dispose();
            db.Close();
            return ElPlatoPrincipal;
            
        }
        public objPlatoPrincipal GetPlatoPrincipal(string NombrePlato, string Descripcion,string rutEmpresa)
        {
            BaseDatos db = new BaseDatos(cnn);
            string sql = "SELECT ID_PPrincipal,Nombre_plato,Descripcion,id_TipoComida,rutEmpresa FROM Minutero.dbo.Plato_Principal";
            sql = sql + " WHERE Nombre_plato Like'%"+NombrePlato+"%' OR Descripcion LIKE '%"+Descripcion+"%' AND RutEmpresa='"+rutEmpresa+"'";
            SqlDataReader dr = db.LlenaReader(sql);
            objPlatoPrincipal ElPlatoPrincipal = new objPlatoPrincipal();
            TipoComida tipo_comid = new TipoComida(cnn);
            if (dr.Read())
            {
                ElPlatoPrincipal.id_platoPrincipal = int.Parse(dr[0].ToString());
                ElPlatoPrincipal.Nombre_plato = dr[1].ToString();
                ElPlatoPrincipal.descripcion = dr[2].ToString();
                ElPlatoPrincipal.id_tipoComida = tipo_comid.getTipoComida(int.Parse(dr[3].ToString()));
                ElPlatoPrincipal.RutEmpresa = dr[4].ToString();
            }
            else
            {
                ElPlatoPrincipal = null;
            }
            dr.Close();
            dr.Dispose();
            db.Close();
            return ElPlatoPrincipal;

        }
        public bool SetPlatoPrincipal(objPlatoPrincipal elPlatoPrincipal)
        {
            BaseDatos db = new BaseDatos(cnn);
            string sql = "SELECT ID_PPrincipal,Nombre_plato,Descripcion,id_TipoComida FROM Minutero.dbo.Plato_Principal WHERE ID_PPrincipal=" + elPlatoPrincipal.id_platoPrincipal;
            SqlDataReader dr = db.LlenaReader(sql);
            TipoComida TipComid = new TipoComida(cnn);
            try
            {
                if (dr.Read())
                {
                    sql = "UPDATE Minutero.dbo.Plato_Principal SET Nombre_plato='" + elPlatoPrincipal.Nombre_plato.ToString() + "', Descripcion='" + elPlatoPrincipal.descripcion.ToString() + "',";
                    sql = sql + " ID_TIPOCOMIDA=" + elPlatoPrincipal.id_tipoComida.id_tipoPlato + " WHERE ID_PPrincipal=" + elPlatoPrincipal.id_platoPrincipal;
                }
                else
                {
                    sql = "INSERT INTO Minutero.dbo.Plato_Principal(Nombre_plato,Descripcion,ID_TipoComida,rutEmpresa)VALUES('" + elPlatoPrincipal.Nombre_plato.ToString() + "','" +elPlatoPrincipal.descripcion.ToString() + "'," + elPlatoPrincipal.id_tipoComida.id_tipoPlato + ",'"+elPlatoPrincipal.RutEmpresa+"')";
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

        public List<objPlatoPrincipal> GetListPlatosPrincipales(string RutEmpresa)
        {
            BaseDatos db = new BaseDatos(cnn);
            string sql = "SELECT ID_PPrincipal,Nombre_plato,Descripcion,id_TipoComida,rutEmpresa FROM Minutero.dbo.Plato_Principal WHERE RutEmpresa='"+RutEmpresa+"'";
            SqlDataReader dr = db.LlenaReader(sql);
            TipoComida TipComid = new TipoComida(cnn);
            List<objPlatoPrincipal> ListaPlatosPrincipales = new List<objPlatoPrincipal>();
            try
            {
                while (dr.Read())
                {
                    objPlatoPrincipal elPlatoPrincipal = new objPlatoPrincipal();

                    elPlatoPrincipal.id_platoPrincipal = int.Parse(dr[0].ToString());
                    elPlatoPrincipal.Nombre_plato = dr[1].ToString();
                    elPlatoPrincipal.descripcion= dr[2].ToString();
                    elPlatoPrincipal.id_tipoComida = TipComid.getTipoComida(int.Parse(dr[3].ToString()));
                    elPlatoPrincipal.RutEmpresa = dr[4].ToString();
                    ListaPlatosPrincipales.Add(elPlatoPrincipal);
                }

            }
            catch
            {

                ListaPlatosPrincipales = null;
            }

            dr.Close();
            dr.Dispose();
            db.Close();
            return ListaPlatosPrincipales;
        }

        public bool DeletePPrincipal(objPlatoPrincipal elPlatoPrincipal)
        {
            BaseDatos db = new BaseDatos(cnn);
            try
            {
                string sql = "DELETE FRom Minutero.dbo.Plato_Principal WHERE ID_PPrincipal=" + elPlatoPrincipal.id_platoPrincipal;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace Modelo
{
    public class objTipo_bebida
    {
        public int id_tipoBebida { get; set; }
        public string Descripcion { get; set; }
        public string RutEmpresa { get; set; }
    }

    public class tipo_bebida 
    {
        string cnn = null;
        
        public tipo_bebida(string ConnectionString) 
        {
            cnn = ConnectionString;
        }

        public bool IsThereAnydata() 
        {
            BaseDatos db = new BaseDatos(cnn);
            string sql = "SELECT * FROM minutero.dbo.Tipo_bebida";
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
        public objTipo_bebida GetTipoBebida(int id_tipoBebida) 
        {
            BaseDatos db = new BaseDatos(cnn);
            string sql = "SELECT id_tipobebida,descripcion,rutEmpresa FROM minutero.dbo.Tipo_bebida WHERE id_tipoBebida =" + id_tipoBebida;
            SqlDataReader dr = db.LlenaReader(sql);
            objTipo_bebida ElTipoBebida = new objTipo_bebida();
            if (dr.Read())
            {
                ElTipoBebida.id_tipoBebida = int.Parse(dr[0].ToString());
                ElTipoBebida.Descripcion = dr[1].ToString();
                ElTipoBebida.RutEmpresa = dr[2].ToString();
            }
            else 
            {
                ElTipoBebida = null;
            }
            dr.Close();
            dr.Dispose();
            db.Close();
            return ElTipoBebida;
        }

        public bool setElTipoBebida(objTipo_bebida ElTipoBebida) 
        {
            BaseDatos db = new BaseDatos(cnn);
            string sql = "SELECT id_tipobebida,descripcion FROM minutero.dbo.Tipo_bebida WHERE id_tipoBebida =" + ElTipoBebida.id_tipoBebida;
            SqlDataReader dr = db.LlenaReader(sql);
            try
            {
                if (dr.Read())
                {
                    sql = "UPDATE Minutero.dbo.Tipo_bebida set Descripcion='" + ElTipoBebida.Descripcion + "' WHERE id_tipobebida="+ElTipoBebida.id_tipoBebida;
                }
                else 
                {
                    sql = "INSERT INTO Minutero.dbo.Tipo_bebida(Descripcion,rutEmpresa)VALUES('"+ElTipoBebida.Descripcion+"','"+ElTipoBebida.RutEmpresa+"')";
                }
                db.Ejecuta(sql);
            }
            catch (Exception)
            {

                return false;   
            }
            dr.Close();
            dr.Dispose();
            db.Close();

            return true;
        }

        public List<objTipo_bebida> getListaTipoBEbida(string rutEmpresa) 
        {
            BaseDatos db = new BaseDatos(cnn);
            string sql = "SELECT id_tipobebida,descripcion,rutEmpresa FROM minutero.dbo.Tipo_bebida WHERE rutEmpresa='"+rutEmpresa+"'";
            SqlDataReader dr = db.LlenaReader(sql);
            List<objTipo_bebida>LalistaTipoBebida=new List<objTipo_bebida>();
            try
            {
                while (dr.Read())
                {
                    objTipo_bebida ElTipoBebida = new objTipo_bebida();
                    ElTipoBebida.id_tipoBebida = int.Parse(dr[0].ToString());
                    ElTipoBebida.Descripcion = dr[1].ToString();
                    ElTipoBebida.RutEmpresa = dr[2].ToString();
                    LalistaTipoBebida.Add(ElTipoBebida);
                }
            }
            catch
            {
                
                LalistaTipoBebida=null;
            }

            dr.Close();
            dr.Dispose();
            db.Close();

            return LalistaTipoBebida;
        }

        public bool DeleteTipoBebida(objTipo_bebida elTipoBebida) 
        {
            BaseDatos db = new BaseDatos(cnn);
            try
            {
                string sql = "DELETE FROM Minutero.dbo.Tipo_bebida WHERE id_tipobebida="+elTipoBebida.id_tipoBebida;
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

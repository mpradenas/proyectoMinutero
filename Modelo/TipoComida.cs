using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Modelo
{
    public class objTipoComida
    {
      

        public int id_tipoPlato { get; set; }
        public string  Descripcion { get; set; }
        public string rutEmpresa { get; set; } 
    
    }

    public class TipoComida 
    {
        string cnn = null;

        public TipoComida(string ConnectionString) 
        {
            cnn = ConnectionString;
        }
       

       
        public objTipoComida getTipoComida(int id_tipoPlato) 
        {
            BaseDatos db = new BaseDatos(cnn);
            string sql = "SELECT Id_tipoComida,Descripcion,rutEmpresa FROM Minutero.dbo.Tipo_Comida WHERE ID_tipoComida=" + id_tipoPlato;
            SqlDataReader dr = db.LlenaReader(sql);
            objTipoComida elTipoComida = new objTipoComida();
            if (dr.Read())
            {
                elTipoComida.id_tipoPlato = int.Parse(dr[0].ToString());
                elTipoComida.Descripcion = dr[1].ToString();
                elTipoComida.rutEmpresa = dr[2].ToString();

            }
            else
            {
                elTipoComida = null;
            }
            dr.Close();
            dr.Dispose();
            db.Close();
            return elTipoComida;
        }

        public bool setElTipoComida(objTipoComida elTipoComida)
        {
            BaseDatos db = new BaseDatos(cnn);
            string sql = "SELECT Id_tipoComida,Descripcion,rutEmpresa FROM Minutero.dbo.Tipo_Comida WHERE ID_tipoComida=" +elTipoComida.id_tipoPlato;
            SqlDataReader dr = db.LlenaReader(sql);
    
            
            try
            {
                if (dr.Read())
                {
                    sql = "UPDATE Minutero.dbo.Tipo_Comida set Descripcion='" + elTipoComida.Descripcion + "' WHERE Id_tipoComida=" + elTipoComida.id_tipoPlato;
                }
                else
                {
                    sql = "INSERT INTO Minutero.dbo.Tipo_Comida(Descripcion,rutEmpresa)VALUES('" + elTipoComida.Descripcion + "','"+elTipoComida.rutEmpresa+"')";
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

        public List<objTipoComida> getListaTipoComida(string RutEmpresa) 
        {
            BaseDatos db = new BaseDatos(cnn);
            string sql = "SELECT Id_tipoComida,Descripcion FROM [Minutero].[dbo].[TIPO_COMIDA] WHERE RutEmpresa='"+RutEmpresa+"'";
            SqlDataReader dr = db.LlenaReader(sql);
            List<objTipoComida>LalistaTipoComida=new List<objTipoComida>();
            try
            {
                while (dr.Read())
                {
                    objTipoComida elTipoComida = new objTipoComida();

                    elTipoComida.id_tipoPlato = int.Parse(dr[0].ToString());
                    elTipoComida.Descripcion = dr[1].ToString();
                    LalistaTipoComida.Add(elTipoComida);
                }
            }
            catch
            {
                
                LalistaTipoComida=null;
            }

            dr.Close();
            dr.Dispose();
            db.Close();

            return LalistaTipoComida;
        }

        public bool DeleteTipoComida(objTipoComida elTipoComida)
        {
            BaseDatos db = new BaseDatos(cnn);
            try
            {
                string sql = "DELETE FROM Minutero.dbo.Tipo_Comida WHERE Id_tipoComida=" + elTipoComida.id_tipoPlato;
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

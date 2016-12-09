using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Modelo
{
    public class objBebestibles
    {
        public int id_bebestible { get; set; }
        public string Nombre_bebida { get; set; }
        public string descripcion { get; set; }
        public objTipo_bebida id_tipo_bebida { get; set; }
        public string RutEmpresa { get; set; }

    }

    public class Bebestibles 
    {
        string cnn = null;

        public Bebestibles(string ConnectionString) 
        {
            cnn = ConnectionString;
        }

        public objBebestibles getBebestible(int id_bebestible) 
        {
            BaseDatos db = new BaseDatos(cnn);
            string sql = "SELECT id_bebestible,Nombre_bebida,descripcion,id_Tipobebida,rutEmpresa FROM minutero.dbo.Bebestibles WHERE id_bebestible=" + id_bebestible;
            SqlDataReader dr = db.LlenaReader(sql);
            tipo_bebida tipBebid = new tipo_bebida(cnn);
            objBebestibles elBebestible = new objBebestibles();
            if (dr.Read())
            {
                elBebestible.id_bebestible = int.Parse(dr[0].ToString());
                elBebestible.Nombre_bebida = dr[1].ToString();
                elBebestible.descripcion = dr[2].ToString();
                elBebestible.id_tipo_bebida = tipBebid.GetTipoBebida(int.Parse(dr[3].ToString()));

            }
            else 
            {
                elBebestible = null;
            }
            dr.Close();
            dr.Dispose();
            db.Close();
            return elBebestible;
        }

        public bool SetBebestible(objBebestibles elbebestible)
        {
            BaseDatos db = new BaseDatos(cnn);
            string sql = "SELECT id_bebestible,Nombre_bebida,descripcion,id_Tipobebida FROM minutero.dbo.Bebestibles WHERE id_bebestible=" +elbebestible.id_bebestible;
            SqlDataReader dr = db.LlenaReader(sql);
            tipo_bebida tipBebid = new tipo_bebida(cnn);
            try
            {
                if (dr.Read())
                {
                    sql = "UPDATE minutero.dbo.Bebestibles SET Nombre_bebida='" + elbebestible.Nombre_bebida.ToString() + "', Descripcion='" + elbebestible.descripcion.ToString() + "',";
                    sql = sql + " id_Tipobebida=" + elbebestible.id_tipo_bebida.id_tipoBebida + " WHERE id_bebestible=" + elbebestible.id_bebestible;
                }
                else
                {
                    sql = "INSERT INTO minutero.dbo.Bebestibles(Nombre_bebida,Descripcion,id_Tipobebida,rutEmpresa)VALUES('" + elbebestible.Nombre_bebida.ToString() + "','" + elbebestible.descripcion.ToString() + "'," + elbebestible.id_tipo_bebida.id_tipoBebida + ",'"+elbebestible.RutEmpresa+"')";
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

        public List<objBebestibles> GetListBebestibles(string RutEmpresa)
        {
            BaseDatos db = new BaseDatos(cnn);
            string sql = "SELECT id_bebestible,Nombre_bebida,descripcion,id_Tipobebida,rutEmpresa FROM minutero.dbo.Bebestibles where RutEmpresa='"+RutEmpresa+"'";
            SqlDataReader dr = db.LlenaReader(sql);
            tipo_bebida tipBebid = new tipo_bebida(cnn);
            List<objBebestibles> ListaBebestibles = new List<objBebestibles>();
            try
            {
                while (dr.Read())
                {
                    objBebestibles elBebestible = new objBebestibles();
            
                    elBebestible.id_bebestible = int.Parse(dr[0].ToString());
                    elBebestible.Nombre_bebida = dr[1].ToString();
                    elBebestible.descripcion = dr[2].ToString();
                    elBebestible.id_tipo_bebida = tipBebid.GetTipoBebida(int.Parse(dr[3].ToString()));
                    elBebestible.RutEmpresa = dr[4].ToString();
                    ListaBebestibles.Add(elBebestible);
                }

            }
            catch
            {

                ListaBebestibles = null;
            }

            dr.Close();
            dr.Dispose();
            db.Close();
            return ListaBebestibles;
        }

        public bool DeleteBebestible(objBebestibles elbebestible)
        {
            BaseDatos db = new BaseDatos(cnn);
            try
            {
                string sql = "DELETE FRom minutero.dbo.Bebestibles WHERE id_bebestible=" +elbebestible.id_bebestible;
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

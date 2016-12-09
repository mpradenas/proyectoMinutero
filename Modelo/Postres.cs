using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace Modelo
{
    public class ObjPostres
    {
        public int Id_Postre { get; set;}
        public string Nombre_Postre { get; set; }
        public string Descripcion { get; set; }
        public string rutEmpresa { get; set; }


    }

    public class Postres {

        
        string cnn=null;

        public Postres(string ConnectionString) 
        {
            cnn = ConnectionString;
        }

        public ObjPostres getPostres(int Id_postres) 
        {
            BaseDatos db = new BaseDatos(cnn);
            string sql = "SELECT ID_POSTRE, NOMBRE_POSTRE,DESCRIPCION,rutEmpresa FROM MINUTERO.DBO.POSTRES WHERE ID_POSTRE=" + Id_postres;
            SqlDataReader dr=db.LlenaReader(sql);
            ObjPostres elPostre = new ObjPostres();
                
            if (dr.Read())
            {
                elPostre.Id_Postre = int.Parse(dr[0].ToString());
                elPostre.Nombre_Postre = dr[1].ToString();
                elPostre.Descripcion = dr[2].ToString();
                elPostre.rutEmpresa = dr[3].ToString();
            }
            else 
            {
                elPostre = null;
            }
            dr.Close();
            dr.Dispose();
            db.Close();
            return elPostre;
        }

        public bool SeTPostres(ObjPostres elPostre) 
        {
            BaseDatos db = new BaseDatos(cnn);
            string sql = "SELECT ID_POSTRE, NOMBRE_POSTRE,DESCRIPCION FROM MINUTERO.DBO.POSTRES WHERE ID_POSTRE=" + elPostre.Id_Postre;
            SqlDataReader dr = db.LlenaReader(sql);
            try
            {
                if (dr.Read())
                {
                    sql = "UPDATE MINUTERO.DBO.POSTRES SET NOMBRE_POSTRE='" + elPostre.Nombre_Postre + "', DESCRIPCION='" + elPostre.Descripcion.ToString() + "' WHERE ID_POSTRE=" + elPostre.Id_Postre;

                }
                else 
                {
                    sql = "INSERT INTO MINUTERO.DBO.POSTRES(NOMBRE_POSTRE,DESCRIPCION,rutEmpresa)VALUES('" + elPostre.Nombre_Postre.ToString() + "','" + elPostre.Descripcion + "','"+elPostre.rutEmpresa+"')";

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

        public List<ObjPostres> GetListPostres(string rutEmpresa) 
        {
            BaseDatos db = new BaseDatos(cnn);
            string sql = "SELECT ID_POSTRE,NOMBRE_POSTRE,DESCRIPCION,rutempresa FROM MINUTERO.DBO.POSTRES where RutEmpresa='"+rutEmpresa+"'";
            SqlDataReader dr = db.LlenaReader(sql);
            List<ObjPostres> LaListaDePostres = new List<ObjPostres>();
            try
            {
                while (dr.Read()) 
                {
                    ObjPostres ElPostre = new ObjPostres();
                    ElPostre.Id_Postre = int.Parse(dr[0].ToString());
                    ElPostre.Nombre_Postre = dr[1].ToString();
                    ElPostre.Descripcion = dr[2].ToString();
                    ElPostre.rutEmpresa = dr[3].ToString();
                    LaListaDePostres.Add(ElPostre);
                }
            }
            catch
            {

                LaListaDePostres = null;
            }
            dr.Close();
            dr.Dispose();
            db.Close();
            return LaListaDePostres;

        }

        public bool DeletePOSTRE(ObjPostres elPostre) 
        {
            BaseDatos db = new BaseDatos(cnn);
            
            try
            {
                string sql = "DELETE FROM MINUTERO.DBO.POSTRES WHERE ID_POSTRE="+elPostre.Id_Postre;
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

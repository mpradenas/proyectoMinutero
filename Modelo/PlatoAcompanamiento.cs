using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Modelo
{
    public class objPlatoAcompanamiento
    {
        public int id_platoAcomp { get; set; }
        public string Nombre_platoAcomp { get; set; }
        public string descripcion { get; set; }
        public objTipoComida id_Tipo_comida { get; set; }
        public string RutEmpresa { get; set; }
    }

    public class platoAcompanamiento 
    {
        string cnn = null;
        
        public platoAcompanamiento(string ConnectionString) 
        {
            cnn = ConnectionString;
        }
        public bool isThereAnyPlatoAcomp() 
        {
            BaseDatos db = new BaseDatos(cnn);
            string sql = "SELECT * FROM minutero.dbo.Plato_acompanamiento";
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
        public objPlatoAcompanamiento GetElAcompanamiento(int id_platoAcomp) 
        {
            BaseDatos db = new BaseDatos(cnn);
            string sql = "SELECT ID_PLATOACOMP,NOMBRE_ACOMP,DESCRIPCION,ID_TIPOCOMIDA,rutEmpresa FRom minutero.dbo.Plato_acompanamiento WHERE id_PLATOACOMP=" + id_platoAcomp;
            SqlDataReader dr = db.LlenaReader(sql);
            objPlatoAcompanamiento elPlatoAcomp = new objPlatoAcompanamiento();
            TipoComida TipComid = new TipoComida(cnn);
            if (dr.Read())
            {
                elPlatoAcomp.id_platoAcomp = int.Parse(dr[0].ToString());
                elPlatoAcomp.Nombre_platoAcomp = dr[1].ToString();
                elPlatoAcomp.descripcion = dr[2].ToString();
                elPlatoAcomp.id_Tipo_comida = TipComid.getTipoComida(int.Parse(dr[3].ToString()));
                elPlatoAcomp.RutEmpresa = dr[4].ToString();


            }
            else 
            {
                elPlatoAcomp = null;
            }
            dr.Close();
            dr.Dispose();
            db.Close();
            return elPlatoAcomp;
        }

        public bool SetPlatoAcompanamiento(objPlatoAcompanamiento elAcompanamiento) 
        {
            BaseDatos db = new BaseDatos(cnn);
            string sql = "SELECT ID_PLATOACOMP,NOMBRE_ACOMP,DESCRIPCION,ID_TIPOCOMIDA FRom minutero.dbo.Plato_acompanamiento WHERE id_PLATOACOMP=" +elAcompanamiento.id_platoAcomp;
            SqlDataReader dr = db.LlenaReader(sql);
            TipoComida TipComid = new TipoComida(cnn);
            try
            {
                if (dr.Read())
                {
                    sql = "UPDATE Minutero.dbo.Plato_acompanamiento SET Nombre_acomp='" + elAcompanamiento.Nombre_platoAcomp.ToString() + "', Descripcion='" + elAcompanamiento.descripcion.ToString() + "',";
                    sql = sql + " ID_TIPOCOMIDA=" + elAcompanamiento.id_Tipo_comida.id_tipoPlato + " WHERE ID_PLATOACOMP=" + elAcompanamiento.id_platoAcomp;
                }
                else 
                {
                    sql = "INSERT INTO Minutero.dbo.Plato_acompanamiento(Nombre_acomp,Descripcion,ID_TipoComida,rutEmpresa)VALUES('" + elAcompanamiento.Nombre_platoAcomp.ToString() + "','" + elAcompanamiento.descripcion.ToString() + "'," + elAcompanamiento.id_Tipo_comida.id_tipoPlato + ",'"+elAcompanamiento.RutEmpresa+"')";
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

        public List<objPlatoAcompanamiento> GetListAcompanamientos(string rutEmpresa) 
        {
            BaseDatos db = new BaseDatos(cnn);
            string sql = "SELECT ID_PLATOACOMP,NOMBRE_ACOMP,DESCRIPCION,ID_TIPOCOMIDA,rutEmpresa FRom minutero.dbo.Plato_acompanamiento WHere RutEmpresa='"+rutEmpresa+"'";
            SqlDataReader dr = db.LlenaReader(sql);
            TipoComida TipComid = new TipoComida(cnn);
            List<objPlatoAcompanamiento> ListaAcompanamientos = new List<objPlatoAcompanamiento>();
            try
            {
                while (dr.Read())
                {
                    objPlatoAcompanamiento elPlatoAcomp = new objPlatoAcompanamiento();

                    elPlatoAcomp.id_platoAcomp = int.Parse(dr[0].ToString());
                    elPlatoAcomp.Nombre_platoAcomp = dr[1].ToString();
                    elPlatoAcomp.descripcion = dr[2].ToString();
                    elPlatoAcomp.id_Tipo_comida = TipComid.getTipoComida(int.Parse(dr[3].ToString()));
                    elPlatoAcomp.RutEmpresa = dr[4].ToString();
                    ListaAcompanamientos.Add(elPlatoAcomp);
                }

            }
            catch 
            {

                ListaAcompanamientos = null;
            }
            
            dr.Close();
            dr.Dispose();
            db.Close();
            return ListaAcompanamientos;
        }

        public bool DeleteAcompanamiento(objPlatoAcompanamiento elAcompanamiento) 
        {
            BaseDatos db = new BaseDatos(cnn);
            try
            {
                string sql = "DELETE FRom minutero.dbo.Plato_acompanamiento WHERE id_PLATOACOMP=" +elAcompanamiento.id_platoAcomp;
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

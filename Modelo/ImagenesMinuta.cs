using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace Modelo
{
    public class objImagenesMinuta
    {
        public int idImagenMinuta { get; set; }
        public ObjUsuario idUsuario { get; set; }
        public string nombreImagen { get; set; }
        public byte[] imagen { get; set; }

    }

    public class ImagenesMinuta 
    {
        string cnn = null;

        public ImagenesMinuta(string ConnectionString) 
        {
            cnn = ConnectionString;
        }

        public objImagenesMinuta GetImagenMinuta(int idImagenMinuta) 
        {
            BaseDatos db = new BaseDatos(cnn);
            string sql = "Select id_imagenMinuta,id_usuario,Nombre_Imagen,Imagen From Minutero.dbo.Imagenes_minutas WHERE id_imagenMinuta=" + idImagenMinuta;
            Usuario procsUsuario = new Usuario(cnn);
            objImagenesMinuta laImagen = new objImagenesMinuta();
            
            SqlDataReader dr = db.LlenaReader(sql);
            if (dr.Read())
            {
                laImagen.idImagenMinuta = int.Parse(dr[0].ToString());
                laImagen.idUsuario = procsUsuario.getUsuario(int.Parse(dr[1].ToString()));
                laImagen.nombreImagen = dr[2].ToString();
                laImagen.imagen = (byte[])dr[3];
            }
            else 
            {
                laImagen = null;
            }
            dr.Close();
            dr.Dispose();
            db.Close();
            return laImagen;
        }

        public bool setImagenMinuta(objImagenesMinuta laImagen) 
        {
            BaseDatos db = new BaseDatos(cnn);
            string sql = "Select id_imagenMinuta,id_usuario,Nombre_Imagen,Imagen From Minutero.dbo.Imagenes_minutas WHERE id_imagenMinuta=" + laImagen.idImagenMinuta;
            Usuario procsUsuario = new Usuario(cnn);
           
            SqlDataReader dr = db.LlenaReader(sql);
            try
            {
                if (dr.Read())
                {
                    
                    sql = "UPDATE Minutero.dbo.Imagenes_minutas SET Nombre_imagen='" + laImagen.nombreImagen.ToString() + "' where id_imagenMinuta=" + laImagen.idImagenMinuta;
                    db.Ejecuta(sql);
                }
                else 
                {
                    sql = "Insert INTO Minutero.dbo.Imagenes_minutas(id_usuario,Nombre_Imagen,Imagen)VALUES(@id_usuario,@Nombre_imagen,@imagen)";
                    SqlParameter[] parametros = {
                    db.crearParametro("@id_usuario", laImagen.idUsuario.idUsuario, SqlDbType.Int),
                    db.crearParametro("@Nombre_imagen", laImagen.nombreImagen, SqlDbType.VarChar),
                    db.crearParametro("@imagen", laImagen.imagen, SqlDbType.Image)
                    };
                    db.Ejecuta(sql, parametros);
                
                }
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

        public List<objImagenesMinuta> getListImagenes(int idUsuario) 
        { 
            BaseDatos db = new BaseDatos(cnn);
            string sql = "Select id_imagenMinuta,id_usuario,Nombre_Imagen,Imagen From Minutero.dbo.Imagenes_minutas WHERE id_usuario=" +idUsuario;
            Usuario procsUsuario = new Usuario(cnn);
            List<objImagenesMinuta> listImagenes = new List<objImagenesMinuta>();
            SqlDataReader dr = db.LlenaReader(sql);
            try
            {
                 while (dr.Read()) 
                    {
                        objImagenesMinuta laImagen = new objImagenesMinuta();
                        laImagen.idImagenMinuta = int.Parse(dr[0].ToString());
                        laImagen.idUsuario = procsUsuario.getUsuario(int.Parse(dr[1].ToString()));
                        laImagen.nombreImagen = dr[2].ToString();
                        laImagen.imagen = (byte[])dr[3];
                        listImagenes.Add(laImagen);
            
                    }
            }
            catch (Exception)
            {

                listImagenes = null;
            }
            dr.Close();
            dr.Dispose();
            db.Close();
            return listImagenes;
        }

        public bool deleteImagenesMinuta(objImagenesMinuta laImagenMinuta) 
        {
            BaseDatos db = new BaseDatos(cnn);
            try
            {
                string sql = "DELETE FROM Minutero.dbo.Imagenes_minutas WHERE id_imagenMinuta=" + laImagenMinuta.idImagenMinuta;
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

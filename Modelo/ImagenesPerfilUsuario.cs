using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Modelo
{
    public class objImagenesPerfilUsuario 
    {
        public int id_ImagenesPerfil { get; set; }
        public ObjUsuario id_usuario { get; set; }
        public byte[] imagenes { get; set; }
    }
    public class ImagenesPerfilUsuario
    {
        string cnn = null;

        public ImagenesPerfilUsuario(string ConnectionString) 
        {
            cnn = ConnectionString;
        }

        public objImagenesPerfilUsuario GetImagenPerfilUsuario(int idImagenPerfil) 
        {
            BaseDatos db = new BaseDatos(cnn);


            string sql = "Select [ID_IMAGENESPERFIL],[ID_USUARIO],[IMAGENES] [Minutero].[dbo].[IMAGENES_PERFIL_USUARIO] WHERE [ID_IMAGENESPERFIL]=" + idImagenPerfil;
            Usuario procsUsuario = new Usuario(cnn);
            objImagenesPerfilUsuario laImagen = new objImagenesPerfilUsuario();
            
            SqlDataReader dr = db.LlenaReader(sql);
            if (dr.Read())
            {
                laImagen.id_ImagenesPerfil = int.Parse(dr[0].ToString());
                laImagen.id_usuario = procsUsuario.getUsuario(int.Parse(dr[1].ToString()));
                laImagen.imagenes = (byte[])dr[2];
                
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

        public bool setImagenPerfilUsuario(objImagenesPerfilUsuario laImagen) 
        {
            BaseDatos db = new BaseDatos(cnn);
            string sql = "Select [ID_IMAGENESPERFIL],[ID_USUARIO],[IMAGENES] [Minutero].[dbo].[IMAGENES_PERFIL_USUARIO] WHERE [ID_IMAGENESPERFIL]=" + laImagen;
            Usuario procsUsuario = new Usuario(cnn);
           
            SqlDataReader dr = db.LlenaReader(sql);
            try
            {
                if (dr.Read())
                {

                    sql = "UPDATE [Minutero].[dbo].[IMAGENES_PERFIL_USUARIO] SET [IMAGENES]='@imagenes' where id_imagenMinuta=@id_imagenPerfil";
                    SqlParameter[] parametros = {
                    db.crearParametro("@id_usuario", laImagen.id_usuario.idUsuario, SqlDbType.Int),
                    db.crearParametro("@iamgenes", laImagen.imagenes, SqlDbType.Image)
                    };
                    db.Ejecuta(sql,parametros);
                }
                else 
                {
                    sql = "Insert INTO [Minutero].[dbo].[IMAGENES_PERFIL_USUARIO]([ID_USUARIO],[IMAGENES])VALUES(@id_usuario,@imagenes)";
                    SqlParameter[] parametros = {
                    db.crearParametro("@id_usuario", laImagen.id_usuario.idUsuario, SqlDbType.Int),
                    db.crearParametro("@imagenes", laImagen.imagenes, SqlDbType.Image)
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

        public List<objImagenesPerfilUsuario> getListImagenes(int idUsuario) 
        { 
            BaseDatos db = new BaseDatos(cnn);
            string sql = "Select [ID_IMAGENESPERFIL],[ID_USUARIO],[IMAGENES] [Minutero].[dbo].[IMAGENES_PERFIL_USUARIO] WHERE [ID_IMAGENESPERFIL]=" + idUsuario;
            Usuario procsUsuario = new Usuario(cnn);
            List<objImagenesPerfilUsuario> listImagenes = new List<objImagenesPerfilUsuario>();
            SqlDataReader dr = db.LlenaReader(sql);
            try
            {
                 while (dr.Read()) 
                    {
                        objImagenesPerfilUsuario laImagen = new objImagenesPerfilUsuario();
                        laImagen.id_ImagenesPerfil = int.Parse(dr[0].ToString());
                        laImagen.id_usuario = procsUsuario.getUsuario(int.Parse(dr[1].ToString()));
                        laImagen.imagenes = (byte[])dr[2];
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

        public bool deleteImagenesPerfilUsuario(objImagenesPerfilUsuario laImagenPerfilUsuario) 
        {
            BaseDatos db = new BaseDatos(cnn);
            try
            {
                string sql = "DELETE FROM [Minutero].[dbo].[IMAGENES_PERFIL_USUARIO] WHERE [ID_IMAGENESPERFIL]=" + laImagenPerfilUsuario.id_ImagenesPerfil;
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

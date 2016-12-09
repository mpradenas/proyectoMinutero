using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Modelo
{
    public class ObjUsuario
    {
        public int idUsuario { get; set; }
        public string nickName { get; set; }
        public string empresa { get; set; }
        public string RutEmpresa { get; set; }
        public string Nombre { get; set; }
        public int TipoUsuario { get; set; }
        public int estado { get; set; }
    }
    public class Usuario
    {
        string cnn = null;
        public Usuario(string ConnectionString)
        {
            cnn = ConnectionString;
        }
        public ObjUsuario getUsuario(int idUsuario)
        {
            ObjUsuario elUsuario = new ObjUsuario();
            BaseDatos db = new BaseDatos(cnn);
            string sql = "SELECT Usuario.id_usuario,Nick_Name,Detalle_UsuarioEmpresa.Nombre,Empresa,Rut_Empresa,TipoUsuario,estado_usuario FROM Minutero.dbo.Usuario INNER JOIN Minutero.dbo.Detalle_UsuarioEmpresa ON Usuario.id_Usuario=Detalle_UsuarioEmpresa.id_Usuario WHERE Usuario.id_usuario=" + idUsuario;
            SqlDataReader dr = db.LlenaReader(sql);
            if (dr.Read())
            {

                elUsuario.idUsuario = int.Parse(dr[0].ToString());
                elUsuario.nickName = dr[1].ToString();
                elUsuario.Nombre = dr[2].ToString();
                elUsuario.empresa = dr[3].ToString();
                elUsuario.RutEmpresa = dr[4].ToString();
                db.Close();
                return elUsuario;
            }
            else
            {
                elUsuario = null;
                db.Close();
                return elUsuario;
            }
        } 
        public ObjUsuario ValidaUsuario(string Usuario, string Password)
        {
            ObjUsuario elUsuario = new ObjUsuario();
            BaseDatos db = new BaseDatos(cnn);
            string sql = "SELECT Usuario.id_usuario,Nick_Name,Detalle_UsuarioEmpresa.Nombre,Empresa,Rut_Empresa,TipoUsuario,estado_usuario FROM Minutero.dbo.Usuario INNER JOIN Minutero.dbo.Detalle_UsuarioEmpresa ON Usuario.id_Usuario=Detalle_UsuarioEmpresa.id_Usuario WHERE Usuario.Email='" + Usuario + "' AND Contrasena='" + Password + "'"; 
            SqlDataReader dr = db.LlenaReader(sql);
            if (dr.Read())
            {
              
                elUsuario.idUsuario = int.Parse(dr[0].ToString());
                elUsuario.nickName = dr[1].ToString();
                elUsuario.Nombre = dr[2].ToString();
                elUsuario.empresa = dr[3].ToString();
                elUsuario.RutEmpresa = dr[4].ToString();
                elUsuario.TipoUsuario = int.Parse(dr[5].ToString());
                db.Close();
                return elUsuario;
            }
            else
            {
                elUsuario = null;
                db.Close();
                return elUsuario;
            }
        }

        public bool registraUsuario(string nombre, string nickname, string contrasena, string correo, string empresa , string rutEmpresa,int tipoUsuario) 
        {
            BaseDatos db = new BaseDatos(cnn);

            string sql = "SELECT USUARIO.ID_USUARIO,NICK_NAME,CONTRASENA,TipoUsuario,estado_usuario FROM Minutero.dbo.USUARIO INNER JOIN Minutero.dbo.DETALLE_USUARIOEMPRESA";
            sql =sql+ " ON USUARIO.id_Usuario=DETALLE_USUARIOEMPRESA.id_Usuario  WHERE USUARIO.nick_Name='"+nickname+"'";
            SqlDataReader dr = db.LlenaReader(sql);
            try
            {
                if (dr.Read())
                {
                    return false;
                }
                else
                {
                    sql = "INSERT INTO MINUTERO.DBO.USUARIO(NICK_NAME,CONTRASENA,Email,TipoUsuario,estado_usuario)VALUES('" + nickname + "','" + contrasena + "','" + correo + "'," + tipoUsuario + ","+1+")";
                    db.Ejecuta(sql);

                    sql = "SELECT IDENT_CURRENT ('MINUTERO.DBO.USUARIO')";
                    SqlDataReader dr2 = db.LlenaReader(sql);
                    if (dr2.Read())
                    {
                        sql = "INSERT INTO MINUTERO.DBO.DETALLE_USUARIOEMPRESA(id_usuario,NOMBRE, EMPRESA, RUT_EMPRESA)VALUES('" + int.Parse(dr2[0].ToString()) + "','" + nombre + "','" + empresa + "','" + rutEmpresa + "')";
                        db.Ejecuta(sql);
                    }

                    dr2.Close();
                }
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
        public bool ChangeStateUser(ObjUsuario elUsuario)
        {
            BaseDatos db = new BaseDatos(cnn);

            string sql = "SELECT ID_USUARIO,NICK_NAME,CONTRASENA,TipoUsuario,estado_usuario FROM Minutero.dbo.USUARIO WHERE id_usuario=" + elUsuario.idUsuario;
            SqlDataReader dr = db.LlenaReader(sql);
            try
            {
                if (dr.Read())
                {
                    sql = "Update Minutero.dbo.usuario set estado_usuario="+ elUsuario.estado+" where id_usuario="+elUsuario.idUsuario;
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
        public List<ObjUsuario> getListUsuarios() 
        {
            BaseDatos db = new BaseDatos(cnn);
            string sql = "SELECT Usuario.id_usuario,Nick_Name,Detalle_UsuarioEmpresa.Nombre,Empresa,Rut_Empresa,TipoUsuario,estado_usuario FROM Minutero.dbo.Usuario INNER JOIN Minutero.dbo.Detalle_UsuarioEmpresa ON Usuario.id_Usuario=Detalle_UsuarioEmpresa.id_Usuario";
            SqlDataReader dr = db.LlenaReader(sql);
            List<ObjUsuario> LaListaUsuarios = new List<ObjUsuario>();
            try
            {
                 while (dr.Read())
                {
                    ObjUsuario elUsuario = new ObjUsuario();
                    elUsuario.idUsuario = int.Parse(dr[0].ToString());
                    elUsuario.nickName = dr[1].ToString();
                    elUsuario.Nombre = dr[2].ToString();
                    elUsuario.empresa = dr[3].ToString();
                    elUsuario.RutEmpresa = dr[4].ToString();
                    elUsuario.TipoUsuario=int.Parse(dr[5].ToString());
                    elUsuario.estado=int.Parse(dr[6].ToString());
                    LaListaUsuarios.Add(elUsuario);
                }
            }
            catch
            {

                LaListaUsuarios = null;
            }
            dr.Close();
            dr.Dispose();
            db.Close();
            return LaListaUsuarios;
            
        }

        public bool deleteUsuario(ObjUsuario elusuario) 
        {
            BaseDatos db = new BaseDatos(cnn);
            try
            {
                string sql = "delete from Minutero.dbo.Bebestibles where rutEmpresa='" + elusuario.RutEmpresa + "'";
                db.Ejecuta(sql);
                sql = "delete from Minutero.dbo.Imagenes_minutas where id_Usuario=" + elusuario.idUsuario;
                db.Ejecuta(sql);
                sql = "delete from Minutero.dbo.Plato_acompanamiento where rutEmpresa='" + elusuario.RutEmpresa + "'";
                db.Ejecuta(sql);
                sql="delete from Minutero.dbo.Plato_principal where rutEmpresa='"+elusuario.RutEmpresa+"'";
                db.Ejecuta(sql);
                sql="delete from Minutero.dbo.Postres where rutEmpresa='"+elusuario.RutEmpresa+"'";
                db.Ejecuta(sql);
                sql="delete from Minutero.dbo.Tipo_Bebida where rutEmpresa='"+elusuario.RutEmpresa+"'";
                db.Ejecuta(sql);
                sql = "delete from Minutero.dbo.Tipo_Comida where rutEmpresa='" + elusuario.RutEmpresa + "'";
                db.Ejecuta(sql);
                sql = "delete from Minutero.dbo.Detalle_usuarioempresa where id_usuario=" + elusuario.idUsuario;
                db.Ejecuta(sql);
                sql = "delete from Minutero.dbo.usuario where id_usuario=" + elusuario.idUsuario;
                db.Ejecuta(sql);
                return true;
               

            }
            catch (Exception)
            {
                return false;
            }
            db.Close();
          
        }
       

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;



namespace Modelo
{
    public class BaseDatos
    {
        private string cnn = null;
        SqlConnection conDataBase = default(SqlConnection);
        List<SqlConnection> cnList = new List<SqlConnection>();
        List<SqlDataReader> drList = new List<SqlDataReader>();
        /// <summary>
        /// Inicia clase solo con servidor, usuario y password, se conecta por defecto a BaseExistencia
        /// </summary>
        /// <param name="Servidor">Instancia SQL</param>
        /// <param name="Usuario">Usuario SQL</param>
        /// <param name="Password">Password Usuario SQL</param>
        public BaseDatos(string Servidor, string Usuario, string Password)
        {
            cnn = "Data Source=" + Servidor + ";Initial Catalog=BaseExistencia;User ID=" + Usuario + ";Password=" + Password + ";";
        }
        /// <summary>
        /// Inicia clase solo con servidor, usuario, password y base de datos
        /// </summary>
        /// <param name="Servidor">Instancia SQL</param>
        /// <param name="Usuario">Usuario SQL</param>
        /// <param name="Password">Password Usuario SQL</param>
        /// <param name="Base">Base de datos (Dafault=BaseExistencia)</param>
        public BaseDatos(string Servidor, string Usuario, string Password, string Base)
        {
            cnn = "Data Source=" + Servidor + ";Initial Catalog=" + Base + ";User ID=" + Usuario + ";Password=" + Password + ";";
        }
        /// <summary>
        /// Inicia clase con string de conexión
        /// </summary>
        /// <param name="ConnectionString">String de Conexión</param>
        public BaseDatos(string ConnectionString)
        {
            cnn = ConnectionString;
        }
        /// <summary>
        /// Cierra conexiones
        /// </summary>
        public void Close()
        {
            foreach (SqlDataReader dr in drList)
            {
                try
                {
                    dr.Dispose();
                    dr.Close();
                }
                catch { }
            }
            foreach (SqlConnection cn in cnList)
            {
                try
                {
                    cn.Close();
                }
                catch { }
            }

        }
        /// <summary>
        /// Genera SqlConnection
        /// </summary>
        /// <returns>Retorna SqlConnection </returns>
        public SqlConnection ConexionDB()
        {
            conDataBase = new SqlConnection(cnn);
            conDataBase.Open();
            cnList.Add(conDataBase);
            return (conDataBase);
        }

        /// <summary>
        /// Llena DataReader a partir de query SQL
        /// </summary>
        /// <param name="sql">Query SQL</param>
        /// <param name="arr">Parametros SQL</param>
        /// <returns> Retorna DataReader a partir de query SQL</returns>
        public SqlDataReader LlenaReader(string sql, SqlParameter[] arr)
        {
            // try
            // {
            SqlConnection con = default(SqlConnection);
            con = ConexionDB();
            SqlCommand command = new SqlCommand(sql, con);
            command.CommandTimeout = 100000;
            command.CommandType = CommandType.Text;
            for (int i = 0; i <= arr.Length; i++)
            {
                command.Parameters.Add(arr[i]);
            }
            SqlDataReader reader = command.ExecuteReader();
            command.Dispose();
            drList.Add(reader);
            return reader;
            //}
            //catch (Exception ex)
            //{
            //    return null;
            //}
            /*  EJEMPLO DE USO
                * string SQL = null;
                * SQL = "select username from users where idusers=" + idusers;
                * SqlDataReader dr = default(SqlDataReader);
                * dr = LlenaReader(SQL);
                * if (dr.Read) {
                *      return dr(0).ToString().Trim();
                * } else {
                *      return "";
                * }
                * while (dr.Read) {
                *      response.write(dr("username").ToString().Trim());
                * } 
                * */
        }
        /// <summary>
        /// Llena DataReader a partir de query SQL
        /// </summary>
        /// <param name="sql">Query SQL</param>
        /// <returns> Retorna DataReader a partir de query SQL</returns>
        public SqlDataReader LlenaReader(string sql)
        {
            // try
            // {
            SqlConnection con = default(SqlConnection);
            con = ConexionDB();
            SqlCommand command = new SqlCommand(sql, con);
            command.CommandTimeout = 100000;
            SqlDataReader reader = command.ExecuteReader();
            command.Dispose();
            drList.Add(reader);
            return reader;
            //}
            //catch (Exception ex)
            //{
            //    return null;
            //}
            /*  EJEMPLO DE USO
                * string SQL = null;
                * SQL = "select username from users where idusers=" + idusers;
                * SqlDataReader dr = default(SqlDataReader);
                * dr = LlenaReader(SQL);
                * if (dr.Read) {
                *      return dr(0).ToString().Trim();
                * } else {
                *      return "";
                * }
                * while (dr.Read) {
                *      response.write(dr("username").ToString().Trim());
                * } 
                * */
        }

        /// <summary>
        /// Ejecuta Query SQL
        /// </summary>
        /// <param name="sql">Query SQL</param>
        /// <returns>Cantidad de registros afectados</returns>
        public double Ejecuta(string sql)
        {
            SqlConnection con = default(SqlConnection);
            int i = 0;
            con = ConexionDB();
            SqlCommand command = new SqlCommand(sql, con);
            command.CommandTimeout = 100000;
            double cantret = command.ExecuteNonQuery();
            try
            {
                //con.Close();
                //con.Dispose();
                command.Dispose();
                SqlConnection.ClearPool(con);
            }
            catch
            {
                return -1;
            }
            return cantret;
        }
        /// <summary>
        /// Ejecuta Query SQL Con parametros
        /// </summary>
        /// <param name="sql">Query SQL</param>
        /// <param name="parametros">Array de Parametros</param>
        /// <returns></returns>
        public double Ejecuta(string sql, SqlParameter[] parametros)
        {
            SqlConnection con = default(SqlConnection);
            int i = 0;
            con = ConexionDB();
            SqlCommand command = new SqlCommand(sql, con);
            command.CommandTimeout = 100000;
            for (i = 0; i < parametros.Length; i++)
            {
                command.Parameters.Add(parametros[i]);
            }
            double cantret = command.ExecuteNonQuery();
            try
            {
                con.Close();
                con.Dispose();
                command.Dispose();
                SqlConnection.ClearPool(con);
            }
            catch
            {
                return -1;
            }
            return cantret;
            //  EJEMPLO COMO INSERTAR!
            //String Sql = "";
            //Sql = "insert into LibroVenta ( RutEmpresa,idUsers,Rut,tipodocto,nrodocto,fechadocto,fechavencimiento,neto,exento,iva,otrosimp,total,nulo,electronica) values( ";
            //Sql = Sql + "" + double.Parse(Session("rutempresa")) + "," + double.Parse(Session("idusuario")) + ",@Rut,@tipodocto,@nrodocto,@fechadocto,@fechavencimiento,@neto,@exento,@iva,@otrosimp,@total,0,@electronica)";
            //SqlParameter[] arrParams = {
            //    BaseDatos.crearParametro("@Rut", rut, System.Data.SqlDbType.Int),
            //    BaseDatos.crearParametro("@tipodocto", tipodocto, System.Data.SqlDbType.Int),
            //    BaseDatos.crearParametro("@nrodocto", nrodocto, System.Data.SqlDbType.BigInt),
            //    BaseDatos.crearParametro("@fechadocto", fecha, System.Data.SqlDbType.DateTime),
            //    BaseDatos.crearParametro("@fechavencimiento", fecha, System.Data.SqlDbType.DateTime),
            //    BaseDatos.crearParametro("@neto", total, System.Data.SqlDbType.BigInt),
            //    BaseDatos.crearParametro("@exento", 0, System.Data.SqlDbType.BigInt),
            //    BaseDatos.crearParametro("@iva", 0, System.Data.SqlDbType.BigInt),
            //    BaseDatos.crearParametro("@otrosimp", 0, System.Data.SqlDbType.BigInt),
            //    BaseDatos.crearParametro("@electronica", electronica, System.Data.SqlDbType.BigInt),
            //    BaseDatos.crearParametro("@total", total, System.Data.SqlDbType.BigInt)
            //};
            //try
            //{
            //    if (BaseDatos.Ejecuta(System.Data.Sql, arrParams) > 0)
            //    {
            //        Sql = "select ident_current('LibroVenta') as idLibro ";
            //        dr = BaseDatos.LlenaReader(System.Data.Sql);
            //        if (dr.Read)
            //        {
            //            idLibro = double.Parse(dr(0).ToString());
            //        }
            //        else
            //        {
            //            Response.Write("/NOK//No se logro ingresar documento 1.1//");
            //            Response.End();
            //        }
            //    }
            //    else
            //    {
            //        Response.Write("//NOK//No se logro ingresar documento 1.0//");
            //        Response.End();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Response.Write("//NOK//" + ex.Message() + " 1.2//");
            //    Response.End();
            //}

        }


        /// <summary>
        /// Ejecuta Query SQL
        /// </summary>
        /// <param name="sql">Query SQL</param>
        /// <returns>Retorna booleano</returns>
        public Boolean EjecutaSql(string sql)
        {
            SqlConnection con = default(SqlConnection);
            int i = 0;
            con = ConexionDB();
            SqlCommand command = new SqlCommand(sql, con);
            command.CommandTimeout = 100000;
            double cantret = command.ExecuteNonQuery();
            try
            {
                con.Close();
                con.Dispose();
                command.Dispose();
                SqlConnection.ClearPool(con);
            }
            catch
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Crea parametros SQL
        /// </summary>
        /// <param name="clave">Nombre Parametro</param>
        /// <param name="valor">Valor Parametro</param>
        /// <param name="tipoDato">Tipo de dato SQL</param>
        /// <returns>Retorna Parametro SQL</returns>
        public SqlParameter crearParametro(string clave, string valor, SqlDbType tipoDato)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = clave;
            parameter.SqlDbType = tipoDato;
            parameter.Value = valor;
            return parameter;
        }
        public SqlParameter crearParametro(string clave, byte[] valor, SqlDbType tipoDato)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = clave;
            parameter.SqlDbType = tipoDato;
            parameter.Value = valor;
            return parameter;
        }
        public SqlParameter crearParametro(string clave, int valor, SqlDbType tipoDato)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = clave;
            parameter.SqlDbType = tipoDato;
            parameter.Value = valor;
            return parameter;
        }
        
    }
}

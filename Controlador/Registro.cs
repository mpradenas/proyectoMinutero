using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
namespace Controlador
{
    public class Registro
    {
        string cnn = null;
        public Registro(string ConnectionString) 
        {
            cnn = ConnectionString;
        }

        public bool RegistraUsuario(string nickName,string contrasena, string nombre,string correo, string empresa, string rutempresa,int tipoUsuario) 
        {
            Modelo.Usuario registra = new Modelo.Usuario(cnn);
            return registra.registraUsuario(nombre,nickName,contrasena,correo,empresa,rutempresa,tipoUsuario);
        }
    }
}

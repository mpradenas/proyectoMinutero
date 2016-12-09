using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
namespace Controlador
{
    public class login
    {
        string cnn = null;

        public login(string ConnectionString) 
        {
            cnn = ConnectionString;
        }

        public Modelo.ObjUsuario abreLogin(string username , string password) 
        {
            Modelo.Usuario loguear = new Modelo.Usuario(cnn);

            return loguear.ValidaUsuario(username,password);
           
        }

        // esta clase interactúa con el modelo que se llama usuario , debido a que todas las funciones correspondientes al uso de consultas sql login y registro están relacionadas por este modelo//

    }

   
}

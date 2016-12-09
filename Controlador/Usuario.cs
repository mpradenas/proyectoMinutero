using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controlador
{
    public class Usuario
    {
        string cnn = null;
        public Usuario(string ConnectionString) 
        {
            cnn = ConnectionString;
        }

        public Modelo.ObjUsuario traeObjeto(int idUsuario) 
        {
            Modelo.Usuario procs = new Modelo.Usuario(cnn);
            return procs.getUsuario(idUsuario);
        }

        public bool activaDesactiva(int idusuario,int estado) 
        {
            Modelo.ObjUsuario elusuario = new Modelo.ObjUsuario();
            Modelo.Usuario processUsuario = new Modelo.Usuario(cnn);
            elusuario = processUsuario.getUsuario(idusuario);
            elusuario.estado = estado;
            return processUsuario.ChangeStateUser(elusuario);
        }

        public bool eliminaUsuario(int idusuario)
        {
            Modelo.ObjUsuario elusuario = new Modelo.ObjUsuario();
            Modelo.Usuario processUsuario = new Modelo.Usuario(cnn);
            elusuario = processUsuario.getUsuario(idusuario);
            return processUsuario.deleteUsuario(elusuario);
        }
    }
}

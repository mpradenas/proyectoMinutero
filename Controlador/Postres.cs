using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Controlador
{
    
    public class Postres
    {
        string cnn = null;
        public Postres(string ConnectionString)
        { 
            cnn = ConnectionString; 
        }
        public Modelo.ObjPostres traeObjeto(int id_Postres)
        {

            Modelo.Postres procsPostres = new Modelo.Postres(cnn);
            Modelo.ObjPostres elPostre = procsPostres.getPostres(id_Postres);
            Modelo.ObjPostres elObjeto = new Modelo.ObjPostres();

            if (elPostre != null)
            {
                elObjeto.Id_Postre = elPostre.Id_Postre;
                elObjeto.Nombre_Postre = elPostre.Nombre_Postre;
                elObjeto.Descripcion = elPostre.Descripcion;
            }
            else
            {
                elObjeto = null;
            }
            return elObjeto;
        }

        public List<Modelo.ObjPostres> TraeListaPlatosPrincipales(string rutEmpresa)
        {

            List<Modelo.ObjPostres> laLista = new List<Modelo.ObjPostres>();
            Modelo.Postres procPostres = new Modelo.Postres(cnn);
            laLista = procPostres.GetListPostres(rutEmpresa);
            List<Modelo.ObjPostres> laLista0 = new List<Modelo.ObjPostres>();
            if (laLista0 != null)
            {
                foreach (Modelo.ObjPostres dato in laLista)
                {
                    Modelo.ObjPostres elObjeto = new Modelo.ObjPostres();
                    elObjeto.Id_Postre = dato.Id_Postre;
                    elObjeto.Nombre_Postre = dato.Nombre_Postre;
                    elObjeto.Descripcion = dato.Descripcion;
                    laLista0.Add(elObjeto);
                }
            }
            else
            {
                laLista0 = null;
            }
            return laLista0;
        }

        public bool GuardaPostre(int id_postre, string Nombre_postre, string Descripcion,string rutEmpresa)
        {
            
            Modelo.ObjPostres elPostre = new Modelo.ObjPostres();
            Modelo.Postres ProcsPostres = new Modelo.Postres(cnn);
            elPostre = ProcsPostres.getPostres(id_postre);
            if (elPostre != null) 
            {
               return ModificaPostres(id_postre,Nombre_postre,Descripcion,rutEmpresa);
            }
            elPostre = new Modelo.ObjPostres();
            elPostre.Id_Postre = id_postre;
            elPostre.Nombre_Postre = Nombre_postre;
            elPostre.Descripcion = Descripcion;
            elPostre.rutEmpresa = rutEmpresa;
            return ProcsPostres.SeTPostres(elPostre);
        }
        public bool ModificaPostres(int id_postre, string Nombre_postre, string Descripcion,string rutEmpresa) 
        {
            Modelo.ObjPostres elPostre = new Modelo.ObjPostres();
            Modelo.Postres ProcsPostres = new Modelo.Postres(cnn);
            elPostre.Id_Postre = id_postre;
            elPostre.Nombre_Postre = Nombre_postre;
            elPostre.Descripcion = Descripcion;
            return ProcsPostres.SeTPostres(elPostre);
        
        }

        public bool EliminaPostres(int id_postre)
        {
            Modelo.ObjPostres elPostre = new Modelo.ObjPostres();
            Modelo.Postres ProcsPostres = new Modelo.Postres(cnn);
            elPostre = ProcsPostres.getPostres(id_postre);
            return ProcsPostres.DeletePOSTRE(elPostre);
  
        }
    }
}

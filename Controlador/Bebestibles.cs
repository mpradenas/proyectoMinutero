using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controlador
{

   
    public class Bebestibles
    {
        string cnn = null;

        public Bebestibles(string ConnectionString) 
        {
            cnn = ConnectionString;
        }

        public bool ConsultaTipoBebestible() 
        {
            Tipo_bebida procsTipoBebida = new Tipo_bebida(cnn);
            return procsTipoBebida.existeDatos();
        }

        public Modelo.objBebestibles traeObjeto(int idBebestible)
        {

            Modelo.Bebestibles procsBebestible = new Modelo.Bebestibles(cnn);
            Modelo.objBebestibles elBebestible = procsBebestible.getBebestible(idBebestible);
            return elBebestible;
        }

        public bool GuardaBebestibles(int id_Bebestible, string Nombre_Bebestible, string Descripcion, int id_TipoBebida,string rutempresa) 
        {
            Modelo.objBebestibles Elbbestible = new Modelo.objBebestibles();
            Modelo.Bebestibles Bebest = new Modelo.Bebestibles(cnn);
            Modelo.tipo_bebida TipBebest = new Modelo.tipo_bebida(cnn);
            Elbbestible = Bebest.getBebestible(id_Bebestible);
            if (Elbbestible != null) 
            {
                return modificaBebestible(id_Bebestible,Nombre_Bebestible,Descripcion,id_TipoBebida);

            }
            Elbbestible = new Modelo.objBebestibles();
            Elbbestible.id_bebestible = id_Bebestible;
            Elbbestible.Nombre_bebida = Nombre_Bebestible;
            Elbbestible.descripcion = Descripcion;
            Elbbestible.id_tipo_bebida = TipBebest.GetTipoBebida(id_TipoBebida);
            Elbbestible.RutEmpresa = rutempresa;
            return Bebest.SetBebestible(Elbbestible);
        }

        public bool modificaBebestible(int id_Bebestible, string Nombre_Bebestible, string Descripcion, int id_TipoBebida)
        {
            Modelo.objBebestibles Elbbestible = new Modelo.objBebestibles();
            Modelo.Bebestibles Bebest = new Modelo.Bebestibles(cnn);
            Modelo.tipo_bebida TipBebest = new Modelo.tipo_bebida(cnn);
            Elbbestible.id_bebestible = id_Bebestible;
            Elbbestible.Nombre_bebida = Nombre_Bebestible;
            Elbbestible.descripcion = Descripcion;
            Elbbestible.id_tipo_bebida = TipBebest.GetTipoBebida(id_TipoBebida);
            return Bebest.SetBebestible(Elbbestible);
        
        }
        
        public List<Modelo.objBebestibles> TraeListaBebestibles(string rutEmpresa)
        {

            Modelo.Bebestibles procBebestibles = new Modelo.Bebestibles(cnn);
            List<Modelo.objBebestibles> laLista0 = new List<Modelo.objBebestibles>();
            laLista0 = procBebestibles.GetListBebestibles(rutEmpresa);
            return laLista0;
        }
        public bool EliminaBebestible(int id_Bebestible) 
        {
            Modelo.objBebestibles Elbbestible = new Modelo.objBebestibles();
            Modelo.Bebestibles Bebest = new Modelo.Bebestibles(cnn);

            Elbbestible = Bebest.getBebestible(id_Bebestible);
            return Bebest.DeleteBebestible(Elbbestible);

        }
    }
}

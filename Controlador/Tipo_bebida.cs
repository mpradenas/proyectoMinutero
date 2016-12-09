using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controlador
{
    

      
    
    public class Tipo_bebida
    {
        string cnn = null;

        public Tipo_bebida(string ConnectionString) 
        {
            cnn = ConnectionString;
        }

        public bool existeDatos()
        {
              Modelo.tipo_bebida procsTipoBebida= new Modelo.tipo_bebida(cnn);
              return procsTipoBebida.IsThereAnydata();   
        }
        public Modelo.objTipo_bebida traeObjeto(int id_TipoBebida)
        {

            Modelo.tipo_bebida procsTipoBebida = new Modelo.tipo_bebida(cnn);
            Modelo.objTipo_bebida elTipo_bebida = procsTipoBebida.GetTipoBebida(id_TipoBebida);
            Modelo.objTipo_bebida elObjeto = new Modelo.objTipo_bebida();

            if (elTipo_bebida != null)
            {
                elObjeto.id_tipoBebida = elTipo_bebida.id_tipoBebida;
                elObjeto.Descripcion = elTipo_bebida.Descripcion;
            }
            else
            {
                elObjeto = null;
            }
            return elObjeto;
        }

        public List<Modelo.objTipo_bebida> TraeListaTipoBebida(string rutEmpresa)
        {

            List<Modelo.objTipo_bebida> laLista = new List<Modelo.objTipo_bebida>();
            Modelo.tipo_bebida procTipoBebida = new Modelo.tipo_bebida(cnn);
            laLista = procTipoBebida.getListaTipoBEbida(rutEmpresa);
            List<Modelo.objTipo_bebida> laLista0 = new List<Modelo.objTipo_bebida>();
            if (laLista0 != null)
            {
                foreach (Modelo.objTipo_bebida dato in laLista)
                {
                    Modelo.objTipo_bebida elObjeto = new Modelo.objTipo_bebida();
                    elObjeto.id_tipoBebida = dato.id_tipoBebida;
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
        public bool GuardaTipoBebida(int id_tipo_bebida,string descripcion,string RutEmpresa)
        {
            Modelo.tipo_bebida TipoBebida=new Modelo.tipo_bebida(cnn);
            Modelo.objTipo_bebida elTipoBebida=new Modelo.objTipo_bebida();

            elTipoBebida=TipoBebida.GetTipoBebida(id_tipo_bebida);
            if(elTipoBebida !=null)
            {
                ModificaTipoBebida(id_tipo_bebida,descripcion);
            }
            elTipoBebida = new Modelo.objTipo_bebida();
            elTipoBebida.id_tipoBebida=id_tipo_bebida;
            elTipoBebida.Descripcion=descripcion;
            elTipoBebida.RutEmpresa = RutEmpresa;

            return TipoBebida.setElTipoBebida(elTipoBebida);
        }

        public bool ModificaTipoBebida(int id_tipo_bebida, string descripcion) 
        {
            Modelo.tipo_bebida TipoBebida = new Modelo.tipo_bebida(cnn);
            Modelo.objTipo_bebida elTipoBebida = new Modelo.objTipo_bebida();
            elTipoBebida.id_tipoBebida = id_tipo_bebida;
            elTipoBebida.Descripcion = descripcion;

            return TipoBebida.setElTipoBebida(elTipoBebida);
     
        }
        public bool EliminaTipoBebida(int id_tipo_bebida) 
        {
            Modelo.tipo_bebida TipoBebida = new Modelo.tipo_bebida(cnn);
            Modelo.objTipo_bebida elTipoBebida = new Modelo.objTipo_bebida();

            elTipoBebida = TipoBebida.GetTipoBebida(id_tipo_bebida);
            return TipoBebida.DeleteTipoBebida(elTipoBebida);
        }

    }
}

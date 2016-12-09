using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controlador
{
   
    public class TipoComida
    {
        string cnn = null;
        
        
        public TipoComida(string ConnectionString) 
        {
            cnn = ConnectionString;
        }
        public Modelo.objTipoComida traeObjeto(int id_TipoComida)
        {

            Modelo.TipoComida procsTipoComida = new Modelo.TipoComida(cnn);
            Modelo.objTipoComida elTipo_comida = procsTipoComida.getTipoComida(id_TipoComida);
            Modelo.objTipoComida elObjeto = new Modelo.objTipoComida();

            if (elTipo_comida != null)
            {
                elObjeto.id_tipoPlato = elTipo_comida.id_tipoPlato;
                elObjeto.Descripcion = elTipo_comida.Descripcion;
            }
            else
            {
                elObjeto = null;
            }
            return elObjeto;
        }

        public List<Modelo.objTipoComida> TraeListaTipoComida(string RutEmpresa)
        {

            List<Modelo.objTipoComida> laLista = new List<Modelo.objTipoComida>();
            Modelo.TipoComida procTipoComida = new Modelo.TipoComida(cnn);
            laLista = procTipoComida.getListaTipoComida(RutEmpresa);
            List<Modelo.objTipoComida> laLista0 = new List<Modelo.objTipoComida>();
            if (laLista0 != null)
            {
                foreach (Modelo.objTipoComida dato in laLista)
                {
                    Modelo.objTipoComida elObjeto = new Modelo.objTipoComida();
                    elObjeto.id_tipoPlato = dato.id_tipoPlato;
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
        public bool guardaTipoComida(int id_tipoComida, string descripcion,string RutEmpresa) 
        {
            Modelo.objTipoComida ElTipoComida = new Modelo.objTipoComida();
            Modelo.TipoComida TipoComida = new Modelo.TipoComida(cnn);
            ElTipoComida = TipoComida.getTipoComida(id_tipoComida);
            if (ElTipoComida != null) 
            {
                modificaTipoComida(id_tipoComida,descripcion,RutEmpresa);
            }
            ElTipoComida = new Modelo.objTipoComida();
            ElTipoComida.id_tipoPlato = id_tipoComida;
            ElTipoComida.Descripcion = descripcion;
            ElTipoComida.rutEmpresa = RutEmpresa;

            return TipoComida.setElTipoComida(ElTipoComida);
            
        }

        public bool modificaTipoComida(int id_tipoComida, string descripcion,string RutEmpresa) 
        {
            Modelo.objTipoComida ElTipoComida = new Modelo.objTipoComida();
            Modelo.TipoComida TipoComida = new Modelo.TipoComida(cnn);
            ElTipoComida.id_tipoPlato = id_tipoComida;
            ElTipoComida.Descripcion = descripcion;
            ElTipoComida.rutEmpresa = RutEmpresa;

            return TipoComida.setElTipoComida(ElTipoComida);
            
            
        }

        public bool eliminarTipoComida(int id_TipoComida) 
        {
            Modelo.objTipoComida ElTipoComida = new Modelo.objTipoComida();
            Modelo.TipoComida TipoComida = new Modelo.TipoComida(cnn);
            ElTipoComida = TipoComida.getTipoComida(id_TipoComida);
            return TipoComida.DeleteTipoComida(ElTipoComida);
        }
    }
}

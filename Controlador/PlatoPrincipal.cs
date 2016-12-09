using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controlador
{
    public class objPlatoPrincipal
    {
        string cnn = null;

        public int id_platoPrincipal { get; set; }
        public string Nombre_plato { get; set; }
        public string descripcion { get; set; }
        public Modelo.objTipoComida id_tipoComida { get; set; }

        public objPlatoPrincipal(string ConnectionString) 
        {
            cnn = ConnectionString;        
        }
        public objPlatoPrincipal()
        { }

        public bool CreaObjeto()
        {
            Modelo.objPlatoPrincipal elObjeto = new Modelo.objPlatoPrincipal();
            try
            {
                elObjeto.id_platoPrincipal = this.id_platoPrincipal;
                elObjeto.Nombre_plato = this.Nombre_plato;
                elObjeto.descripcion = this.descripcion;
                elObjeto.id_tipoComida = this.id_tipoComida;

            }
            catch
            {
                return false;
            }

            return true;
        }

        public objPlatoPrincipal traeObjeto(int id_platoPrincipal)
        {

            Modelo.platoPrincipal procsPlatoPrincipal = new Modelo.platoPrincipal(cnn);
            Modelo.objPlatoPrincipal elPlatoPrincipal = procsPlatoPrincipal.GetPlatoPrincipal(id_platoPrincipal);
            objPlatoPrincipal elObjeto = new objPlatoPrincipal();

            if (elPlatoPrincipal != null)
            {
                elObjeto.id_platoPrincipal = elPlatoPrincipal.id_platoPrincipal;
                elObjeto.Nombre_plato = elPlatoPrincipal.Nombre_plato;
                elObjeto.descripcion = elPlatoPrincipal.descripcion;
                elObjeto.id_tipoComida = elPlatoPrincipal.id_tipoComida;

            }
            else
            {
                elObjeto = null;
            }
            return elObjeto;
        }

        
    }
    public class PlatoPrincipal
    {
        string cnn = null;

        public PlatoPrincipal(string ConnectionString) 
        {
            cnn = ConnectionString;
        }
        public bool existeDatos()
        {
            Modelo.platoPrincipal procPPrincipal = new Modelo.platoPrincipal(cnn);
            return procPPrincipal.isThereAnyPlatoPrincipal();
        }
        public bool GuardaPPrincipal(int id_PPrincipal, string Nombre_PPrincpal, string Descripcion, int id_TipoComida,string RutEmpresa) 
        {
            Modelo.objPlatoPrincipal ElPlatoPrincipal = new Modelo.objPlatoPrincipal();
            Modelo.platoPrincipal PPrinc= new Modelo.platoPrincipal(cnn);
            Modelo.TipoComida TipComida = new Modelo.TipoComida(cnn);
            ElPlatoPrincipal = PPrinc.GetPlatoPrincipal(id_PPrincipal);
            if (ElPlatoPrincipal != null) 
            {
                return modificaPPrincipal( id_PPrincipal, Nombre_PPrincpal, Descripcion, id_TipoComida,RutEmpresa);

            }
            ElPlatoPrincipal = new Modelo.objPlatoPrincipal();
            ElPlatoPrincipal.id_platoPrincipal=id_PPrincipal;
            ElPlatoPrincipal.Nombre_plato=Nombre_PPrincpal;
            ElPlatoPrincipal.descripcion = Descripcion;
            ElPlatoPrincipal.id_tipoComida = TipComida.getTipoComida(id_TipoComida);
            ElPlatoPrincipal.RutEmpresa = RutEmpresa;
            return PPrinc.SetPlatoPrincipal(ElPlatoPrincipal);
        }

        public bool modificaPPrincipal(int id_PPrincipal, string Nombre_PPrincpal, string Descripcion, int id_TipoComida,string rutEmpresa)
        {
            Modelo.objPlatoPrincipal ElPlatoPrincipal = new Modelo.objPlatoPrincipal();
            Modelo.platoPrincipal PPrinc= new Modelo.platoPrincipal(cnn);
            Modelo.TipoComida TipComida = new Modelo.TipoComida(cnn);
            
            ElPlatoPrincipal.id_platoPrincipal=id_PPrincipal;
            ElPlatoPrincipal.Nombre_plato=Nombre_PPrincpal;
            ElPlatoPrincipal.descripcion = Descripcion;
            ElPlatoPrincipal.id_tipoComida = TipComida.getTipoComida(id_TipoComida);
            return PPrinc.SetPlatoPrincipal(ElPlatoPrincipal);
        
        }

        public bool EliminaPPrincipal(int id_PPrincipal) 
        {
            Modelo.objPlatoPrincipal ElPlatoPrincipal = new Modelo.objPlatoPrincipal();
            Modelo.platoPrincipal PPrinc = new Modelo.platoPrincipal(cnn);

            ElPlatoPrincipal = PPrinc.GetPlatoPrincipal(id_PPrincipal);

            return PPrinc.DeletePPrincipal(ElPlatoPrincipal);

        }
        public List<Modelo.objPlatoPrincipal> TraeListaPlatosPrincipales(string rutEmpresa)
        {

            List<Modelo.objPlatoPrincipal> laLista = new List<Modelo.objPlatoPrincipal>();
            Modelo.platoPrincipal procPlatoPrincipal = new Modelo.platoPrincipal(cnn);
            laLista = procPlatoPrincipal.GetListPlatosPrincipales(rutEmpresa);
            List<Modelo.objPlatoPrincipal> laLista0 = new List<Modelo.objPlatoPrincipal>();
            if (laLista0 != null)
            {
                foreach (Modelo.objPlatoPrincipal dato in laLista)
                {
                    Modelo.objPlatoPrincipal elObjeto = new Modelo.objPlatoPrincipal();
                    elObjeto.id_platoPrincipal = dato.id_platoPrincipal;
                    elObjeto.Nombre_plato = dato.Nombre_plato;
                    elObjeto.descripcion = dato.descripcion;
                    elObjeto.id_tipoComida = dato.id_tipoComida;
                    laLista0.Add(elObjeto);
                }
            }
            else
            {
                laLista0 = null;
            }
            return laLista0;
        }

    }
}

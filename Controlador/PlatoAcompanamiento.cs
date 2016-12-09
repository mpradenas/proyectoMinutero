using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controlador
{
   
        
    public class PlatoAcompanamiento
    {
        string cnn = null;

        public PlatoAcompanamiento(string ConnectionString) 
        {
            cnn = ConnectionString;
        }

        public bool existeDatos() 
        {
            Modelo.platoAcompanamiento procPAcomp = new Modelo.platoAcompanamiento(cnn);
            return procPAcomp.isThereAnyPlatoAcomp();
        }
        public Modelo.objPlatoAcompanamiento traeObjeto(int id_platoAcompanamiento)
        {

            Modelo.platoAcompanamiento procsPlatoAcomp = new Modelo.platoAcompanamiento(cnn);
            Modelo.objPlatoAcompanamiento elPlatoAcomp = procsPlatoAcomp.GetElAcompanamiento(id_platoAcompanamiento);
            Modelo.objPlatoAcompanamiento  elObjeto = new Modelo.objPlatoAcompanamiento();

            if (elPlatoAcomp != null)
            {
                elObjeto.id_platoAcomp = elPlatoAcomp.id_platoAcomp;
                elObjeto.Nombre_platoAcomp = elPlatoAcomp.Nombre_platoAcomp;
                elObjeto.descripcion = elPlatoAcomp.descripcion;
                elObjeto.id_Tipo_comida = elPlatoAcomp.id_Tipo_comida;

            }
            else
            {
                elObjeto = null;
            }
            return elObjeto;
        }

        public List<Modelo.objPlatoAcompanamiento> TraeListaPlatosAcomps(string rutEmpresa)
        {

            List<Modelo.objPlatoAcompanamiento> laLista = new List<Modelo.objPlatoAcompanamiento>();
            Modelo.platoAcompanamiento procPlatoAcomp = new Modelo.platoAcompanamiento(cnn);
            laLista = procPlatoAcomp.GetListAcompanamientos(rutEmpresa);
            List<Modelo.objPlatoAcompanamiento> laLista0 = new List<Modelo.objPlatoAcompanamiento>();
            if (laLista0 != null)
            {
                foreach (Modelo.objPlatoAcompanamiento dato in laLista)
                {
                    Modelo.objPlatoAcompanamiento elObjeto = new Modelo.objPlatoAcompanamiento();
                    elObjeto.id_platoAcomp = dato.id_platoAcomp;
                    elObjeto.Nombre_platoAcomp = dato.Nombre_platoAcomp;
                    elObjeto.descripcion = dato.descripcion;
                    elObjeto.id_Tipo_comida = dato.id_Tipo_comida;
                    laLista0.Add(elObjeto);
                }
            }
            else
            {
                laLista0 = null;
            }
            return laLista0;
        }
        public bool GuardaPAcomp(int id_PAcompanamiento, string Nombre_Pacompanamiento, string Descripcion, int id_TipoComida,string rutEmpresa) 
        {
            Modelo.objPlatoAcompanamiento ElPlatoAcomp = new Modelo.objPlatoAcompanamiento();
            Modelo.platoAcompanamiento Pacomp = new Modelo.platoAcompanamiento(cnn);
            Modelo.TipoComida TipComida = new Modelo.TipoComida(cnn);
            ElPlatoAcomp = Pacomp.GetElAcompanamiento(id_PAcompanamiento);
            if (ElPlatoAcomp != null) 
            {
                return modificaPAcompanamiento(id_PAcompanamiento, Nombre_Pacompanamiento, Descripcion, id_TipoComida,rutEmpresa);

            }
            ElPlatoAcomp = new Modelo.objPlatoAcompanamiento();
            ElPlatoAcomp.id_platoAcomp = id_PAcompanamiento;
            ElPlatoAcomp.Nombre_platoAcomp=Nombre_Pacompanamiento;
            ElPlatoAcomp.descripcion = Descripcion;
            ElPlatoAcomp.id_Tipo_comida= TipComida.getTipoComida(id_TipoComida);
            ElPlatoAcomp.RutEmpresa = rutEmpresa;
            return Pacomp.SetPlatoAcompanamiento(ElPlatoAcomp);
        }

        public bool modificaPAcompanamiento(int id_PAcompanamiento, string Nombre_Pacompanamiento, string Descripcion, int id_TipoComida,string rutEmpresa)
        {
            Modelo.objPlatoAcompanamiento ElPlatoAcomp = new Modelo.objPlatoAcompanamiento();
            Modelo.platoAcompanamiento Pacomp = new Modelo.platoAcompanamiento(cnn);
            Modelo.TipoComida TipComida = new Modelo.TipoComida(cnn);

            ElPlatoAcomp.id_platoAcomp = id_PAcompanamiento;
            ElPlatoAcomp.Nombre_platoAcomp = Nombre_Pacompanamiento;
            ElPlatoAcomp.descripcion = Descripcion;
            ElPlatoAcomp.id_Tipo_comida = TipComida.getTipoComida(id_TipoComida);
            ElPlatoAcomp.RutEmpresa = rutEmpresa;
            return Pacomp.SetPlatoAcompanamiento(ElPlatoAcomp);
        
        }

        public bool EliminaPAcomp(int id_PAcomp) 
        {
            Modelo.objPlatoAcompanamiento ElPlatoAcomp = new Modelo.objPlatoAcompanamiento();
            Modelo.platoAcompanamiento Pacomp = new Modelo.platoAcompanamiento(cnn);

            ElPlatoAcomp = Pacomp.GetElAcompanamiento(id_PAcomp);
            return Pacomp.DeleteAcompanamiento(ElPlatoAcomp);

        }
    }
}

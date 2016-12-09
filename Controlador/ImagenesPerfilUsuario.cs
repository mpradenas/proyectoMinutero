using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controlador
{
    
    
    public class ImagenesPerfilUsuario
    {
        string cnn = null;
        
        public ImagenesPerfilUsuario(string ConnectionString)
        {
           cnn= ConnectionString;
        }

        public Modelo.objImagenesPerfilUsuario traeObjeto(int idImagenPerfilUsuario)
        {
            Modelo.ImagenesPerfilUsuario procs = new Modelo.ImagenesPerfilUsuario(cnn);
            return procs.GetImagenPerfilUsuario(idImagenPerfilUsuario);
        }

        public bool guardaImagenMinuta(int idImagenMinuta, int id_usuario, string NombreImagen, byte[] imagen)
        {
            Modelo.ImagenesMinuta procsImagsMinutas = new Modelo.ImagenesMinuta(cnn);
            Modelo.objImagenesMinuta elObjeto = new Modelo.objImagenesMinuta();
            Usuario procsUsuario = new Usuario(cnn);
            elObjeto = procsImagsMinutas.GetImagenMinuta(idImagenMinuta);
            if (elObjeto != null)
            {
                return ModificaDatosImagen(idImagenMinuta, id_usuario, NombreImagen, imagen);
            }
            elObjeto = new Modelo.objImagenesMinuta();
            elObjeto.idImagenMinuta = idImagenMinuta;
            elObjeto.idUsuario = procsUsuario.traeObjeto(id_usuario);
            elObjeto.nombreImagen = NombreImagen;
            elObjeto.imagen = imagen;

            return procsImagsMinutas.setImagenMinuta(elObjeto);


        }

        public bool ModificaDatosImagen(int idImagenMinuta, int id_usuario, string NombreImagen, byte[] imagen)
        {
            Modelo.ImagenesMinuta procsImagsMinutas = new Modelo.ImagenesMinuta(cnn);
            Modelo.objImagenesMinuta elObjeto = new Modelo.objImagenesMinuta();
            Usuario procsUsuario = new Usuario(cnn);
            elObjeto = new Modelo.objImagenesMinuta();
            elObjeto.idImagenMinuta = idImagenMinuta;
            elObjeto.idUsuario = procsUsuario.traeObjeto(id_usuario);
            elObjeto.nombreImagen = NombreImagen;
            elObjeto.imagen = imagen;
            return procsImagsMinutas.setImagenMinuta(elObjeto);


        }

        public List<Modelo.objImagenesMinuta> traeListaImagenes(int idUsuario)
        {
            Modelo.ImagenesMinuta procsImagsMinutas = new Modelo.ImagenesMinuta(cnn);

            return procsImagsMinutas.getListImagenes(idUsuario);
        }

        public bool BorrarImagen(int idIagenMinuta)
        {
            Modelo.objImagenesPerfilUsuario elObjeto = traeObjeto(idIagenMinuta);
            Modelo.ImagenesPerfilUsuario procsImgPerfUsuario = new Modelo.ImagenesPerfilUsuario(cnn);
            return procsImgPerfUsuario.deleteImagenesPerfilUsuario(elObjeto);
        }


    }
}

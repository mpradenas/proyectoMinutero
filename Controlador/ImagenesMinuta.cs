using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controlador
{

    
    public class ImagenesMinuta
    {
        string cnn = null;
        
        public ImagenesMinuta(string ConnectionStrings) 
        {
            cnn = ConnectionStrings;
        }


       public Modelo.objImagenesMinuta traeObjeto(int idImagenMinuta)
       {
           Modelo.ImagenesMinuta procs = new Modelo.ImagenesMinuta(cnn);
           return procs.GetImagenMinuta(idImagenMinuta);
       }

       public bool guardaImagenMinuta(int idImagenMinuta, int id_usuario,string NombreImagen, byte[] imagen)
       {
           Modelo.ImagenesMinuta procsImagsMinutas = new Modelo.ImagenesMinuta(cnn);
           Modelo.objImagenesMinuta elObjeto = new Modelo.objImagenesMinuta();
           Usuario procsUsuario= new Usuario(cnn);
           elObjeto=procsImagsMinutas.GetImagenMinuta(idImagenMinuta);
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
           Modelo.objImagenesMinuta elObjeto=traeObjeto(idIagenMinuta);
           Modelo.ImagenesMinuta procsImgMins = new Modelo.ImagenesMinuta(cnn);
           return procsImgMins.deleteImagenesMinuta(elObjeto);
       }

   

    }

    
}

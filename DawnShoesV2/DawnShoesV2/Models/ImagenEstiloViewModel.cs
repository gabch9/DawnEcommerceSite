using Back_End.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DawnShoesV2.Models
{
    public class ImagenEstiloViewModel
    {
        public static ImagenEstiloViewModel ConvertToImagenEstiloVM(ImagenEstiloDM imagenEstiloDM)
        {
            ImagenEstiloViewModel imagenEstiloViewModel = new ImagenEstiloViewModel();

            imagenEstiloViewModel.EsPrincipal = imagenEstiloDM.EsPrincipal;
            imagenEstiloViewModel.EstiloDMId = imagenEstiloDM.EstiloDMId;
            imagenEstiloViewModel.ImagenEstiloDMId = imagenEstiloDM.ImagenEstiloDMId;
            imagenEstiloViewModel.Path = imagenEstiloDM.Path;

            return imagenEstiloViewModel;
        }

        public static List<ImagenEstiloViewModel> ConvertDMListToListaImagenEstiloVMList(List<ImagenEstiloDM> imagenEstiloDMs)
        {
            List<ImagenEstiloViewModel> listaImagenEstilo = new List<ImagenEstiloViewModel>();

            foreach (var obj in imagenEstiloDMs)
            {
                listaImagenEstilo.Add(ConvertToImagenEstiloVM(obj));
            }

            return listaImagenEstilo;
        }

        //Id de la foto
        [Key]
        public int ImagenEstiloDMId { get; set; }

        //Id del estilo
        public int EstiloDMId { get; set; }

        //Ruta para la imagen donde se va a guardar
        public string Path { get; set; }

        //Booleano para saber si la foto es la principal
        public bool EsPrincipal { get; set; }
    }
}
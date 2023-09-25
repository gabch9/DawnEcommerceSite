using Back_End.DAL.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DawnShoesV2.Models
{
    public class GeneroViewModel
    {
        //Mapear de DMList a VMList
        public static List<GeneroViewModel> ConvertDMListToGeneroVMList(IEnumerable<GeneroDM> listaGenero)
        {
            List<GeneroViewModel> listaGeneroViewModel = new List<GeneroViewModel>();

            foreach (var generoDM in listaGenero)
            {
                GeneroViewModel generoVM = new GeneroViewModel();

                generoVM.GeneroDMId = generoDM.GeneroDMId;
                generoVM.Descripcion = generoDM.Descripcion;

                listaGeneroViewModel.Add(generoVM);
            }

            return listaGeneroViewModel;
        }

        //Mapear de VM a DM
        public static GeneroDM ConvertToGeneroDM(GeneroViewModel generoVM)
        {
            //Objeto que se va a retornar
            GeneroDM generoDM = new GeneroDM();

            generoDM.Descripcion = generoVM.Descripcion;

            return generoDM;
        }

        [Key]
        //ID para el genero
        public int GeneroDMId { get; set; }

        [Required]
        //descripcion del genero. Se pueden agregar o modificar en caso de que se quiera agregar unisex u otros
        public string Descripcion { get; set; }
    }
}
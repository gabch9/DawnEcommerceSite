using Back_End.DAL.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DawnShoesV2.Models
{
    public class ColorViewModel
    {
        //Mapear de DMList a VMList
        public static List<ColorViewModel> ConvertDMListToColorVMList(IEnumerable<ColorDM> listaColores)
        {
            List<ColorViewModel> listaColorViewModel = new List<ColorViewModel>();

            foreach (var colorDM in listaColores)
            {                
                listaColorViewModel.Add(ConvertToColorVM(colorDM));
            }

            return listaColorViewModel;
        }

        //Mapear de VM a DM
        public static ColorDM ConvertToColorDM(ColorViewModel colorVM)
        {
            //Objeto que se va a retornar
            ColorDM colorDM = new ColorDM();

            colorDM.Descripcion = colorVM.Descripcion;

            return colorDM;
        }

        //Mapear de DM a VM
        public static ColorViewModel ConvertToColorVM(ColorDM colorDM)
        {
            //Objeto que se va a retornar
            ColorViewModel colorVM = new ColorViewModel();

            colorVM.ColorDMId = colorDM.ColorDMId;
            colorVM.Descripcion = colorDM.Descripcion;

            return colorVM;
        }

        //ID para el color
        [Key]
        public int ColorDMId { get; set; }

        //descripcion del color en si, si es cafe crema, oscuro, etc.
        public string Descripcion { get; set; }

        //Lista para cargar los colores y devolverlos al view de lista
        public IEnumerable<ColorViewModel> ListaColores { set; get; }
    }
}
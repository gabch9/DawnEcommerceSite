using Back_End.DAL.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DawnShoesV2.Models
{
    public class EdadViewModel
    {
        //Mapear de DMList a VMList
        public static List<EdadViewModel> ConvertDMListToEdadVMList(IEnumerable<EdadDM> listaEdades)
        {
            List<EdadViewModel> listaEdadViewModel = new List<EdadViewModel>();

            foreach (var edadDM in listaEdades)
            {
                EdadViewModel edadVM = new EdadViewModel();

                edadVM.EdadDMId = edadDM.EdadDMId;
                edadVM.Descripcion = edadDM.Descripcion;

                listaEdadViewModel.Add(edadVM);
            }

            return listaEdadViewModel;
        }

        //Mapear de DM a VM
        public static EdadViewModel ConvertToEdadVM(EdadDM edadDM)
        {
            //Objeto que se va a retornar
            EdadViewModel edadVM = new EdadViewModel();

            edadVM.Descripcion = edadDM.Descripcion;

            return edadVM;
        }

        [Key]
        //ID para la edad
        public int EdadDMId { get; set; }

        //descripcion de la edad. Aqui se pone niño, adulto, etc.
        public string Descripcion { get; set; }
    }
}
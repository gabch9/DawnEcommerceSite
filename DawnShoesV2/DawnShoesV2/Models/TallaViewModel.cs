using Back_End.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DawnShoesV2.Models
{
    public class TallaViewModel
    {
        public static List<TallaViewModel> ConvertDMListToTallaVMList(IEnumerable<TallaDM> listaTallas)
        {
            List<TallaViewModel> listaTallaViewModel = new List<TallaViewModel>();

            foreach (var tallaDM in listaTallas)
            {
                listaTallaViewModel.Add(ConvertToTallaVM(tallaDM));
            }

            return listaTallaViewModel;
        }

        //Mapear de VM a DM
        public static TallaDM ConvertToTallaDM(TallaViewModel tallaVM)
        {
            //Objeto que se va a retornar
            TallaDM tallaDM = new TallaDM();
            tallaDM.NumeroTalla = tallaVM.NumeroTalla;

            return tallaDM;
        }

        //Mapear de DM a VM
        public static TallaViewModel ConvertToTallaVM(TallaDM tallaDM)
        {
            //Objeto que se va a retornar
            TallaViewModel tallaVM = new TallaViewModel();
            tallaVM.TallaDMId = tallaDM.TallaDMId;
            tallaVM.NumeroTalla = tallaDM.NumeroTalla;

            return tallaVM;
        }

        [Key]
        //Id de la talla, se va a utilizar en en la seleccion de los dropdown menus
        public int TallaDMId { get; set; }

        //Numero que se va a desplegar como talla en los zapatos
        public int NumeroTalla { get; set; }
    }
}
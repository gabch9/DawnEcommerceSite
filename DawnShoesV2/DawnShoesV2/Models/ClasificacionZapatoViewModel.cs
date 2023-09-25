using Back_End.DAL.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DawnShoesV2.Models
{
    public class ClasificacionZapatoViewModel
    {
        //Mapear de DMList a VMList
        public static List<ClasificacionZapatoViewModel> ConvertDMListToColorVMList(IEnumerable<ClasificacionZapatoDM> listaColores)
        {
            List<ClasificacionZapatoViewModel> listaClasificacionZapatoViewModel = new List<ClasificacionZapatoViewModel>();

            foreach (var clasificacionZapatoDM in listaColores)
            {
                ClasificacionZapatoViewModel clasificacionZapatoVM = new ClasificacionZapatoViewModel();

                clasificacionZapatoVM.ClasificacionZapatoDMId = clasificacionZapatoDM.ClasificacionZapatoDMId;
                clasificacionZapatoVM.Descripcion = clasificacionZapatoDM.Descripcion;
                clasificacionZapatoVM.PesoEstimadoG = clasificacionZapatoDM.PesoEstimadoG;

                listaClasificacionZapatoViewModel.Add(clasificacionZapatoVM);
            }

            return listaClasificacionZapatoViewModel;
        }

        //Mapear de DM a VM
        public static ClasificacionZapatoViewModel ConvertToColorVM(ClasificacionZapatoDM clasificacionZapatoDM)
        {
            //Objeto que se va a retornar
            ClasificacionZapatoViewModel clasificacionZapatoVM = new ClasificacionZapatoViewModel();

            clasificacionZapatoVM.ClasificacionZapatoDMId = clasificacionZapatoDM.ClasificacionZapatoDMId;
            clasificacionZapatoVM.Descripcion = clasificacionZapatoDM.Descripcion;

            return clasificacionZapatoVM;
        }

        [Key]
        //Id para el estilo
        public int ClasificacionZapatoDMId { get; set; }

        //Descripcion fisico del estilo, si lleva trenzas, botones, etc.
        public string Descripcion { get; set; }

        //Peso en gramos que puede pesar el estilo en general. Se aplica al estilo en si ya que todos los zapatos de ese estilo van a tener 
        //un peso similar
        [Required]
        public int? PesoEstimadoG { get; set; }
    }
}
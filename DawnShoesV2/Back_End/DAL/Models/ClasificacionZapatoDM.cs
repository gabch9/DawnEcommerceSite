using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_End.DAL.Models
{
    public class ClasificacionZapatoDM
    {
        //Id para el estilo
        public int ClasificacionZapatoDMId { get; set; }

        //Descripcion fisico del estilo, si lleva trenzas, botones, etc.
        public string Descripcion { get; set; }

        //Peso en gramos que puede pesar el estilo en general. Se aplica al estilo en si ya que todos los zapatos de ese estilo van a tener 
        //un peso similar
        public Nullable<int> PesoEstimadoG { get; set; }
    }
}

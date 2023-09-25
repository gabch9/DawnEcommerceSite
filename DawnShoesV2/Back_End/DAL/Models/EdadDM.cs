using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_End.DAL.Models
{
    public class EdadDM
    {
        //ID para la edad
        public int EdadDMId { get; set; }

        //descripcion de la edad. Aqui se pone niño, adulto, etc.
        public string Descripcion { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_End.DAL.Models
{
    public class ColorDM
    {
        //ID para el color
        public int ColorDMId { get; set; }

        //descripcion del color en si, si es cafe crema, oscuro, etc.
        public string Descripcion { get; set; }
    }
}

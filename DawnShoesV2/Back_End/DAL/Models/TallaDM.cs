using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_End.DAL.Models
{
    //Clase que va a ser la responsable de contener las tallas de los zapatos, por ejemplo 37,38,39, ...
    public class TallaDM
    {
        //Id de la talla, se va a utilizar en en la seleccion de los dropdown menus
        public int TallaDMId { get; set; }

        //Numero que se va a desplegar como talla en los zapatos
        public int NumeroTalla { get; set; }
    }
}

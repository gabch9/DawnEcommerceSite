using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_End.DAL.Models
{
    //Los objetos de esta clase van a ser agrupados por tallas y por estilo. Van a hacer referencia a un estilo de zapato que va a contener
    //toda la informacion necesaria, van a tener un ID para ser agregados a los carritos de compras
    //en unidades o como identificador en los dropdowns. Esta clase tambien va a almacenar las tallas que le pertenecen a un estilo
    public class EstiloDMTallaDM
    {
        //El ID que se menciono que va a identificar la serie de zapatos
        public int EstiloDMTallaDMId { get; set; }

        //Cantidad disponible de zapatos que hay en la serie
        public int CantidadDisponible { get; set; }

        //La medida en cm para que alguien pueda hacer la medida para ver si la talla de este estilo le queda
        public int MedidaCM { get; set; }

        //La referencia al estilo para saber a cual pertenece la serie y obtener informacion sobre el estilo
        public int EstiloDMId { get; set; }

        //Talla
        public int TallaDMId { get; set; }

        //Virtual variables para referencias a los foreign key
        public virtual EstiloDM EstiloDM { get; set; }
        public virtual TallaDM TallaDM { get; set; }
    }
}

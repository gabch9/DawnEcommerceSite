using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_End.DAL.Models
{
    //Esta clase va a contener los datos del estilo del zapato, va a guardar los IDs seleccionados en los dropdowns, ganancia, 
    //precio compra, etc. No se pone la talla aqui ya que pueden haber varias del mismo estilo, la cantidad tampoco porque con un
    //count deberia salir
    public class EstiloDM
    {
        //identificador para el zapato
        public Nullable<int> EstiloDMId { get; set; }

        //ids para guardar el valor de los zapatos: genero al que pertenece el estilo (Hombre, mujer), edad (Niño, Adulto) 
        //color principal (Negro, cafre ...), tipo de estilo (Plataforma, burro ...)
        public Nullable<int> GeneroDMId { get; set; }
        public Nullable<int> ColorDMId { get; set; }
        public Nullable<int> ClasificacionZapatoDMId { get; set; }
        public Nullable<int> EdadDMId { get; set; }

        //descripcion fisica del zapato
        public string Descripcion { get; set; }

        //precio con la que se compro el zapato
        public decimal PrecioCompra { get; set; }

        //preico a la que se va a vender el zapato, cambia dependiendo de cuanta ganancia se quiere
        public decimal PrecioVenta { get; set; }

        //el impuesto de venta que va a tener el zapato
        public decimal ImpuestoVenta { get; set; }

        //Ganancia despues de la venta. Se calcula el precio de venta y compra junto a los impuestos para saber 
        //cuanto se va a ganar por cada par
        public decimal Ganancia { get; set; }

        public decimal ImpuestoCompra { get; set; }

        public int PorcentajeUtilidad { get; set; }
        public decimal PrecioTotalCompra { get; set; }
        public decimal PrecioTotalVenta { get; set; }

        public Nullable<int> Descuento { get; set; }

        //Virtual variables para referencias a los foreign key
        public virtual GeneroDM GeneroDM { get; set; }
        public virtual ColorDM ColorDM { get; set; }
        public virtual ClasificacionZapatoDM ClasificacionZapatoDM { get; set; }
        public virtual EdadDM EdadDM { get; set; }

        //Collection para el many to many relationship
        public virtual ICollection<EstiloDMTallaDM> EstiloDMTallaDM { get; set; }

        //Collecion para las fotos del estilo
        public virtual ICollection<ImagenEstiloDM> ImagenEstiloDM { get; set; }
    }
}

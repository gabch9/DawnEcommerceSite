using Back_End.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DawnShoesV2.Models
{

    /**//// <summary>
    /// ViewModel que se va a utilizar en el formulario de la creacion y edicion de los estilos de los zapatos.
    /// Contiene listas para cargar valores en los dropdown menus y variables para guardar los datos seleccionados
    /// </summary>
    public class EstiloCUViewModel
    {
        ///////////////Convertir de domain class a VM
        public static EstiloCUViewModel ConvertToEstiloVM(EstiloDM estiloDM)
        {
            EstiloCUViewModel estiloVM = new EstiloCUViewModel();

            estiloVM.ColorDMId = (int)estiloDM.ColorDMId;
            estiloVM.ClasificacionZapatoDMId = (int)estiloDM.ClasificacionZapatoDMId;
            estiloVM.Descripcion = estiloDM.Descripcion;
            estiloVM.Descuento = estiloDM.Descuento;
            estiloVM.EdadDMId = (int)estiloDM.EdadDMId;
            estiloVM.Ganancia = estiloDM.Ganancia;
            estiloVM.GeneroDMId = (int)estiloDM.GeneroDMId;
            estiloVM.ImpuestoCompra = estiloDM.ImpuestoCompra;
            estiloVM.ImpuestoVenta = estiloDM.ImpuestoVenta;
            estiloVM.PorcentajeUtilidad = estiloDM.PorcentajeUtilidad;
            estiloVM.PrecioCompra = estiloDM.PrecioCompra;
            estiloVM.PrecioTotalCompra = estiloDM.PrecioTotalCompra;
            estiloVM.PrecioTotalVenta = estiloDM.PrecioTotalVenta;
            estiloVM.PrecioVenta = estiloDM.PrecioVenta;

            return estiloVM;
        }

        ///////////////Convertir el viewmodel a domain class
        public static EstiloDM ConvertToEstiloDM(EstiloCUViewModel estiloVM)
        {
            EstiloDM estiloDM = new EstiloDM();

            estiloDM.ColorDMId = estiloVM.ColorDMId;
            estiloDM.ClasificacionZapatoDMId = estiloVM.ClasificacionZapatoDMId;
            estiloDM.Descripcion = estiloVM.Descripcion;
            estiloDM.Descuento = estiloVM.Descuento;
            estiloDM.EdadDMId = estiloVM.EdadDMId;
            estiloDM.Ganancia = estiloVM.Ganancia;
            estiloDM.GeneroDMId = estiloVM.GeneroDMId;
            estiloDM.ImpuestoCompra = estiloVM.ImpuestoCompra;
            estiloDM.ImpuestoVenta = estiloVM.ImpuestoVenta;
            estiloDM.PorcentajeUtilidad = estiloVM.PorcentajeUtilidad;
            estiloDM.PrecioCompra = estiloVM.PrecioCompra;
            estiloDM.PrecioTotalCompra = estiloVM.PrecioTotalCompra;
            estiloDM.PrecioTotalVenta = estiloVM.PrecioTotalVenta;
            estiloDM.PrecioVenta = estiloVM.PrecioVenta;

            return estiloDM;
        }

        [Key]
        public int EstiloDMId { get; set; }

        //Ids para guardar los valores seleccionados en los dropdowns
        [Required]
        [DisplayName("Genero")]
        public int GeneroDMId { get; set; }

        [Required]
        [DisplayName("Color")]
        public int ColorDMId { get; set; }

        [Required]
        [DisplayName("Clasificacion")]
        public int ClasificacionZapatoDMId { get; set; }

        [Required]
        [DisplayName("Edad")]
        public int EdadDMId { get; set; }

        [Required]
        //descripcion fisica del zapato
        public string Descripcion { get; set; }

        //precio con la que se compro el zapato
        [Required]
        [DisplayName("Precio de compra")]
        public decimal PrecioCompra { get; set; }

        //preico a la que se va a vender el zapato, cambia dependiendo de cuanta ganancia se quiere
        [Required]
        [DisplayName("Precio de venta")]
        public decimal PrecioVenta { get; set; }

        //el impuesto de venta que va a tener el zapato
        [Required]
        [DisplayName("Impuesto de venta")]
        public decimal ImpuestoVenta { get; set; }

        //Ganancia despues de la venta. Se calcula el precio de venta y compra junto a los impuestos para saber 
        //cuanto se va a ganar por cada par
        [Required]
        public decimal Ganancia { get; set; }

        [Required]
        [DisplayName("Impuesto de compra")]
        public decimal ImpuestoCompra { get; set; }

        [Required]
        [DisplayName("Porcentaje de utilidad")]
        public int PorcentajeUtilidad { get; set; }

        [Required]
        [DisplayName("Precio total de la compra")]
        public decimal PrecioTotalCompra { get; set; }

        [Required]
        [DisplayName("Precio total de la venta")]
        public decimal PrecioTotalVenta { get; set; }

        [DisplayName("Descuento")]
        public Nullable<int> Descuento { get; set; }

        //Listas para cargar los combo-box del formulario creando el estilo. Lo que se escoja se va a guardar en los IDs
        //al principio de la clase

        public IEnumerable<GeneroViewModel> listaGeneros { get; set; }

        public IEnumerable<EdadViewModel> listaEdad { get; set; }

        public IEnumerable<ColorViewModel> listaColores { get; set; }

        public IEnumerable<ClasificacionZapatoViewModel> listaClasificacionZapatos { get; set; }
    }

    //Modelo que se va a utilizar para ser desplegado en la tabla de los zapatos en la pagina principal de estilos del admin
    public class ListaEstiloViewModel
    {
        //Mapear de DMList a VMList
        public static List<ListaEstiloViewModel> ConvertDMListToListaEstiloVMList(List<EstiloDM> estiloDMs)
        {
            List<ListaEstiloViewModel> listaEstiloViewModel = new List<ListaEstiloViewModel>();

            foreach (var estiloDM in estiloDMs)
            {
                ListaEstiloViewModel estiloViewModel = new ListaEstiloViewModel();

                estiloViewModel.Color = estiloDM.ColorDM.Descripcion;
                estiloViewModel.Descripcion = estiloDM.Descripcion;
                estiloViewModel.Descuento = estiloDM.Descuento;
                estiloViewModel.EstiloDMId = estiloDM.EstiloDMId;
                estiloViewModel.Ganancia = estiloDM.Ganancia;
                estiloViewModel.PrecioTotalVenta = estiloDM.PrecioTotalVenta;

                listaEstiloViewModel.Add(estiloViewModel);
            }

            return listaEstiloViewModel;
        }

        [Key]
        public int? EstiloDMId { get; set; }

        public string Descripcion { get; set; }

        [DisplayName("Descuento")]
        public int? Descuento { get; set; }

        public string Color { get; set; }

        [DisplayName("Precio total de la venta")]
        public decimal PrecioTotalVenta { get; set; }

        public decimal Ganancia { get; set; }

        public int Existencia { get; set; }
    }

    public class PagCatalogoEstiloViewModel
    {

    }
        
    public class EstilosTallasViewModel
    {
        //Metodo para devolver la lista de las tallas disponibles de un estilo en VM
        public static List<EstilosTallasViewModel> ConvertDMListToEstilosTallasVMList(List<EstiloDMTallaDM> listaEstiloDMTallaDM)
        {
            List<EstilosTallasViewModel> listaEstilosTallasVM = new List<EstilosTallasViewModel>();
            foreach (var estiloDMTallaDM in listaEstiloDMTallaDM)
            {
                listaEstilosTallasVM.Add(ConvertToEstilosTallasViewModel(estiloDMTallaDM));
            }

            return listaEstilosTallasVM;
        }

        public static EstilosTallasViewModel ConvertToEstilosTallasViewModel(EstiloDMTallaDM estiloDMTallaDM)
        {
            EstilosTallasViewModel estilosTallasViewModel = new EstilosTallasViewModel();

            estilosTallasViewModel.NumeroTalla = estiloDMTallaDM.TallaDM.NumeroTalla;
            estilosTallasViewModel.CantidadDisponible = estiloDMTallaDM.CantidadDisponible;
            estilosTallasViewModel.EstiloDMId = estiloDMTallaDM.EstiloDMId;
            estilosTallasViewModel.EstiloDMTallaDMId = estiloDMTallaDM.EstiloDMTallaDMId;
            estilosTallasViewModel.MedidaCM = estiloDMTallaDM.MedidaCM;
            estilosTallasViewModel.TallaDMId = estiloDMTallaDM.TallaDMId;

            return estilosTallasViewModel;
        }

        //El ID que se menciono que va a identificar la serie de zapatos
        public int EstiloDMTallaDMId { get; set; }

        [Required]
        [DisplayName("Cantidad disponible")]
        //Cantidad disponible de zapatos que hay en la serie
        public int CantidadDisponible { get; set; }

        [Required]
        [DisplayName("Medida en CM")]
        //La medida en cm para que alguien pueda hacer la medida para ver si la talla de este estilo le queda
        public int MedidaCM { get; set; }

        //La referencia al estilo para saber a cual pertenece la serie y obtener informacion sobre el estilo
        public int EstiloDMId { get; set; }

        //Talla de la serie
        public int TallaDMId { get; set; }

        [Required]
        [DisplayName("Numero de talla")]
        //Numero de la talla
        public int NumeroTalla { get; set; }
    }

    public class PagDetallesEstiloAdmViewModel
    {

        public static PagDetallesEstiloAdmViewModel ConvertToPagDetallesEstiloViewModel(EstiloDM estiloDM)
        {
            PagDetallesEstiloAdmViewModel pagDetallesEstiloVM = new PagDetallesEstiloAdmViewModel();

            pagDetallesEstiloVM.Clasificacion = estiloDM.ClasificacionZapatoDM.Descripcion;
            pagDetallesEstiloVM.Color = estiloDM.ColorDM.Descripcion;
            pagDetallesEstiloVM.Descripcion = estiloDM.Descripcion;
            pagDetallesEstiloVM.Descuento = estiloDM.Descuento;
            pagDetallesEstiloVM.Edad = estiloDM.EdadDM.Descripcion;
            pagDetallesEstiloVM.EstiloDMId = (int)estiloDM.EstiloDMId;
            pagDetallesEstiloVM.Ganancia = estiloDM.Ganancia;
            pagDetallesEstiloVM.Genero = estiloDM.GeneroDM.Descripcion;
            pagDetallesEstiloVM.ImpuestoCompra = estiloDM.ImpuestoCompra;
            pagDetallesEstiloVM.ImpuestoVenta = estiloDM.ImpuestoVenta;
            pagDetallesEstiloVM.PorcentajeUtilidad = estiloDM.PorcentajeUtilidad;
            pagDetallesEstiloVM.PrecioCompra = estiloDM.PrecioCompra;
            pagDetallesEstiloVM.PrecioVenta = estiloDM.PrecioVenta;
            pagDetallesEstiloVM.PrecioTotalCompra = estiloDM.PrecioTotalCompra;
            pagDetallesEstiloVM.PrecioTotalVenta = estiloDM.PrecioTotalVenta;

            return pagDetallesEstiloVM;
        }

        [Key]
        public int EstiloDMId { get; set; }

        [Required]
        //descripcion fisica del zapato
        public string Descripcion { get; set; }

        //precio con la que se compro el zapato
        [Required]
        [DisplayName("Precio de compra")]
        public decimal PrecioCompra { get; set; }

        //preico a la que se va a vender el zapato, cambia dependiendo de cuanta ganancia se quiere
        [Required]
        [DisplayName("Precio de venta")]
        public decimal PrecioVenta { get; set; }

        //el impuesto de venta que va a tener el zapato
        [Required]
        [DisplayName("Impuesto de venta")]
        public decimal ImpuestoVenta { get; set; }

        //Ganancia despues de la venta. Se calcula el precio de venta y compra junto a los impuestos para saber 
        //cuanto se va a ganar por cada par
        [Required]
        public decimal Ganancia { get; set; }

        [Required]
        [DisplayName("Impuesto de compra")]
        public decimal ImpuestoCompra { get; set; }

        [Required]
        [DisplayName("Porcentaje de utilidad")]
        public int PorcentajeUtilidad { get; set; }

        [Required]
        [DisplayName("Precio total de la compra")]
        public decimal PrecioTotalCompra { get; set; }

        [Required]
        [DisplayName("Precio total de la venta")]
        public decimal PrecioTotalVenta { get; set; }

        [DisplayName("Descuento")]
        public Nullable<int> Descuento { get; set; }

        [Required]
        //Color
        public string Color { get; set; }

        [Required]
        //Hombre, mujer, unisex
        public string Genero { get; set; }

        [Required]
        //Niño, adulto, adulto mayor
        public string Edad { get; set; }

        [Required]
        //Clasificacion del estilo, burro, plano, plataforma media, etc.
        public string Clasificacion { get; set; }

        //Lista de las tallas para desplegar en la tabla
        public IEnumerable<EstilosTallasViewModel> ListaEstilosTallas { get; set; }

        //Lista de las imagenes del estilo
        public IEnumerable<ImagenEstiloViewModel> ListaImagenEstilo { get; set; }

        //Lista de tallas para cargar en el dropdown
        public IEnumerable<TallaViewModel> ListaTalla { get; set; }

        //Variable para guardar el blob que se hace con croppie
        public string Blob { get; set; }

        //Variable para poder usar html helper en la pagina razor
        public EstilosTallasViewModel EstilosTallasViewModel { get; set; }
    }
}
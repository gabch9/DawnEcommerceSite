using Back_End.DAL.Models;
using Back_End.Services.EstiloServices;
using DawnShoesV2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DawnShoesV2.Controllers.AdminControllers
{
    public class AdminEstiloController : Controller
    {
        MantenimientoCatalogoService catalogoService = new MantenimientoCatalogoService();

        // GET: AdminEstilo
        public ActionResult PagListaEstilosAdm()
        {
            return View();
        }

        public ActionResult PagDetallesEstiloAdm(int? estiloDMId, string message)
        {
            //Aqui se evalua el string para saber si se esta entrando a la pag despues de crear un estilo o desde la tabla.
            //Si viene lleno significa que se creo un estilo y se ocupa desplegar un mensaje
            if (!string.IsNullOrEmpty(message))
            {                
                ViewBag.message = message;
            }

            if (estiloDMId == null)
            {
                return RedirectToAction("PagListaEstilosAdm");
            }

            return View(ArmarPagDetallesEstiloViewModel((int)estiloDMId));
        }

        public ActionResult PagEditarEstiloAdm(int estiloDMId)
        {

            return View();
        }

        public ActionResult PagCreacionEstiloAdm()
        {
            var estiloVM = LoadDropDowns();

            if (estiloVM != null)
            {
                return View(estiloVM);
            }
            else
            {
                return RedirectToAction("PagListaEstilosAdm");
            }
            
        }

        ///////////////Convertir un solo domain class a details viewmodel
        
        public PagDetallesEstiloAdmViewModel ArmarPagDetallesEstiloViewModel(int id)
        {
            //Variable que va a almacenar los datos del objeto DM en el mapeo
            PagDetallesEstiloAdmViewModel pagDetallesEstiloVM = new PagDetallesEstiloAdmViewModel();

            //Variable para guardar datos de BD
            EstiloDM estiloDM;

            //se obtienen los datos de la BD. Try and catch en caso de errores
            try
            {
                estiloDM = catalogoService.UoW.EstiloRepository.GetEstiloWJoinedInfo(id);
            }
            catch (ArgumentNullException)
            {
                return null;
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error a la hora de obtener los detalles del estilos");
            }
            
            //Se llama metodo de mapeo en el modelo
            pagDetallesEstiloVM = PagDetallesEstiloAdmViewModel.ConvertToPagDetallesEstiloViewModel(estiloDM);

            //Lista de tallas generals
            pagDetallesEstiloVM.ListaTalla = TallaViewModel.ConvertDMListToTallaVMList(catalogoService.UoW.TallaRepository.GetAll());

            //Lista de las tallas que tiene el estilo
            pagDetallesEstiloVM.ListaEstilosTallas = 
            EstilosTallasViewModel.ConvertDMListToEstilosTallasVMList(catalogoService.GetTallasEstilo((int)estiloDM.EstiloDMId).ToList());

            //Lista de imagenes
            pagDetallesEstiloVM.ListaImagenEstilo = ImagenEstiloViewModel.ConvertDMListToListaImagenEstiloVMList(catalogoService.UoW.ImagenEstiloRepository.GetTodasFotosEstilo((int)estiloDM.EstiloDMId).ToList());

            return pagDetallesEstiloVM;
        }

        //Metodo para cargar listas que se van a usar para cargar todos los dropdowns de la creacion de estilos
        public EstiloCUViewModel LoadDropDowns()
        {
            EstiloCUViewModel estiloVM = new EstiloCUViewModel();

            //Try and catch en caso de que una de las listas venga vacias. Si viene vacia retorna null para que
            //el controller de la pagina de creacion o cualquier otra no se despliegue
            try
            {
                //Se mandan a traer todos los datos
                var listaClasificacionZapato = catalogoService.GetListaClasificaciones();
                var listaColores = catalogoService.GetListaColores();
                var listaEdades = catalogoService.GetListaEdades();
                var listaGeneros = catalogoService.GetListaGeneros();

                //Se convierten en VMs
                estiloVM.listaGeneros = GeneroViewModel.ConvertDMListToGeneroVMList(listaGeneros);
                estiloVM.listaEdad = EdadViewModel.ConvertDMListToEdadVMList(listaEdades);
                estiloVM.listaColores = ColorViewModel.ConvertDMListToColorVMList(listaColores);
                estiloVM.listaClasificacionZapatos = ClasificacionZapatoViewModel.ConvertDMListToColorVMList(listaClasificacionZapato);

                return estiloVM;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
            
        }

        //Ocupa admin protection
        //Funcion para devolverle datos al dataTable de los zapatos
        public JsonResult JsonArmarEstilosInfo()
        {
            //Se mandan a traer las listas de las existencias y la joined de los estilos para desplegar
            //Informacion
            List<EstiloDM> estiloDMs;

            //Existencias
            List<EstiloDMTallaDM> estiloDMTallaDMs;

            //Lista del viewmodel para convertir en json. Se hace el cast para evitar complejidad de los ciclos
            IEnumerable<ListaEstiloViewModel> listaEstiloViewModels = null;
            try
            {
                //Se mandan a traer las listas de las existencias y la joined de los estilos para desplegar
                //Informacion
                estiloDMs = catalogoService.UoW.EstiloRepository.GetAllEstilosWJoinedInfo().ToList();

                //Lista del viewmodel para convertir en json. Se hace el cast para evitar complejidad de los ciclos
                listaEstiloViewModels = ListaEstiloViewModel.ConvertDMListToListaEstiloVMList(estiloDMs);

                //Existencias
                estiloDMTallaDMs = catalogoService.GetListaExistencias().ToList();              

                //Agregar las existencias a la talla respectiva
                for (int i = 0; i < estiloDMTallaDMs.Count(); i++)
                {
                    listaEstiloViewModels.ElementAt(i).Existencia = estiloDMTallaDMs.ElementAt(i).CantidadDisponible;
                }
            }
            //En caso de que haya un error obteniendo las existencias
            catch (InvalidOperationException)
            {                
                return null;
            }
            //No se encontraron datos para devolver en alguna de las listas. Si no hay estilos no van a haber existencias pero si pueden haber estilos sin existencias 
            catch (ArgumentNullException)
            {
                if (listaEstiloViewModels != null)
                {
                    return Json(listaEstiloViewModels, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new EmptyResult(), JsonRequestBehavior.AllowGet);
                }
                
            }
            catch (Exception e)
            {
                return null;
            }

            return Json(listaEstiloViewModels, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Metodo para guardar la talla de un estilo. Cuando termina se devuelve un objeto VM en JSON 
        /// </summary>
        /// <param name="estiloDMId"></param>
        /// <param name="medidaCM"></param>
        /// <param name="cantidadDisponible"></param>
        /// <param name="tallaDMId"></param>
        /// <param name="numeroTalla"></param>
        /// <returns>JSON</returns>
        public JsonResult GuardarEstiloTalla(int estiloDMId, int medidaCM, int cantidadDisponible, int tallaDMId, int numeroTalla)
        {
            EstiloDMTallaDM estiloDMTallaDM = new EstiloDMTallaDM();

            estiloDMTallaDM.TallaDMId = tallaDMId;
            estiloDMTallaDM.EstiloDMId = estiloDMId;
            estiloDMTallaDM.MedidaCM = medidaCM;
            estiloDMTallaDM.CantidadDisponible = cantidadDisponible;

            //Se guarda la talla y se obtiene el id de la talla
            int estiloDMTallaDMId = catalogoService.AgregarEstiloTallaUnicaId(estiloDMTallaDM);

            //Se mapea la talla a VM
            EstilosTallasViewModel estilosTallasViewModel = EstilosTallasViewModel.ConvertToEstilosTallasViewModel(estiloDMTallaDM);

            //se asigna el ID que se guardo antes
            estilosTallasViewModel.EstiloDMTallaDMId = estiloDMTallaDMId;

            //Se agrega el numero de talla de antes
            estilosTallasViewModel.NumeroTalla = numeroTalla;

            //Se retorna el objeto en JSON
            return Json(estilosTallasViewModel, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Metodo para ser contactado con ajax. Contacta al service para remover el metodo
        /// </summary>
        /// <param name="estiloDMId"></param>
        /// <returns>JSON</returns>
        public JsonResult BorrarEstilo(int estiloDMId)
        {
            try
            {
                var estiloBorrado = catalogoService.UoW.EstiloRepository.GetById(estiloDMId);
                catalogoService.UoW.EstiloRepository.Remove(estiloBorrado);

                catalogoService.UoW.Complete();

                return Json("Estilo elimiado exitosamente", JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return null;
            }
        }  

        /// <summary>
        /// Metodo para borrar la imagen fisica en una carpeta con un path especifico
        /// </summary>
        /// <returns>Bool</returns>
        ///
        public bool BorrarImagen(int id)
        {
            try
            {
                //Se usa el ID de la imagen para obtener la imagen en si. Cuando se encuentra se agarra el path del obj
                var filePath = Server.MapPath(catalogoService.BorrarImagen(id));

                if (filePath == null)
                {
                    return false;
                }

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath); 
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Metodo para borrar la imagen fisica en una carpeta con un path especifico
        /// </summary>
        /// <returns>JSON</returns>
        ///
        public JsonResult GuardarImagen(int estiloDMId, string blob)
        {
            try
            {
                int? id = catalogoService.UoW.ImagenEstiloRepository.GetLastImagenID(estiloDMId);

                string path;

                if (id == null)
                {
                    path = "/Content/Imagenes/estilo" + estiloDMId + "-imagen1.jpg";
                }
                else
                {
                    id = id + 1;
                    path = "/Content/Imagenes/estilo" + estiloDMId + "-imagen" + id +".jpg";
                }

                //Se genera el path de la imagen
                

                //Se guarda primero los datos en BD. Si todo sale bien el objeto que se devuelve se convierte en json
                //para generar una imagen en la galeria
                var imagen = catalogoService.GuardarImagenYObtenerObjeto(estiloDMId, path);

                //Si no hubieron errores se empieza a guardar la imagen fisica. Si da true todo salio bien entonces
                //se devuelve el objeto para que el frontend lo convierta en json
                if (ExportToImage(path, blob))
                {
                    //Se guarda primero el path de la imagen
                    return Json(imagen, JsonRequestBehavior.AllowGet); ;
                }
                else
                {
                    return null;
                }               
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Metodo para guardar la imagen fisica en una carpeta con un nombre especifico
        /// </summary>
        /// <returns>Void</returns>
        /// 
        protected bool ExportToImage(string path, string blob)
        {            
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string base64 = blob.Split(',')[1];
                byte[] bytes = Convert.FromBase64String(base64.Split(',')[0]);
                using (FileStream stream = new FileStream(Server.MapPath("~" + path), FileMode.Create))
                {
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Flush();
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        //POST methods

        [HttpPost]
        public ActionResult CrearEstilo(EstiloCUViewModel estilo)
        {
            //Cuando se guarda el objeto EF actualiza el objeto con el ID, se retorna y se asigna a la variable
            var returnedID = catalogoService.AgregarEstiloUnicoId(EstiloCUViewModel.ConvertToEstiloDM(estilo));

            //message se utiliza para cargar el toast despues de que se crea el estilo. Cuando llegue a la pag de detalles ahi se va a crear un viewbag
            return RedirectToAction("PagDetallesEstiloAdm", new { estiloDMId = returnedID, message = "creado" });
        }
    }
}
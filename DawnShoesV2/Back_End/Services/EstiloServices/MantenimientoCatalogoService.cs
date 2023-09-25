using Back_End.DAL.Models;
using Back_End.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_End.Services.EstiloServices
{
    public class MantenimientoCatalogoService
    {
        public UnitOfWork UoW;

        public MantenimientoCatalogoService()
        {
            UoW = new UnitOfWork(new DawnShoesModel());
        }

        //Este metodo cuando agrega el objeto y guarda los cambios carga el objeto original con el id
        public int AgregarEstiloUnicoId(EstiloDM estiloDM)
        {
            UoW.EstiloRepository.Add(estiloDM);
            UoW.Complete();

            return (int)estiloDM.EstiloDMId;
        }

        //Este metodo cuando agrega el objeto y guarda los cambios carga el objeto original con el id
        public int AgregarEstiloTallaUnicaId(EstiloDMTallaDM estiloDMTallaDM)
        {
            UoW.EstiloDMTallaDM.Add(estiloDMTallaDM);
            UoW.Complete();

            return estiloDMTallaDM.EstiloDMTallaDMId;
        }

        /// <summary>
        /// Consigue una lista de los estilos con la existencia que tiene cada uno en total
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EstiloDMTallaDM> GetListaExistencias()
        {
            //Lista para almacenar todas las tallas disponibles
            IEnumerable<EstiloDMTallaDM> listaSeries;
            try
            {
                //Lista para almacenar todas las tallas disponibles
                listaSeries = UoW.EstiloDMTallaDM.GetAll();
            }
            catch (Exception)
            {
                throw new Exception("Error a la hora de revisar las existencias");
            }

            if (listaSeries.Count() == 0)
            {
                return null;
            }

            //Lista que va a ir almacenando la lista de los estilos con su existencia
            List<EstiloDMTallaDM> listaEstilosTallas = new List<EstiloDMTallaDM>();

            //Objeto que va a guardar los datos
            EstiloDMTallaDM serieZapatoDM = new EstiloDMTallaDM();

            //variable para guardar las existencias durante el foreach
            int existencia = 0;

            //Se guarda el primer ID para que se hagan las comparasiones. Se asgina el valor aqui
            //para el primer loop que va a hacer la lista
            int idEstilo = listaSeries.ElementAt(0).EstiloDMId;


            foreach (var obj in listaSeries.OrderBy(a => a.EstiloDMId))
            {
                //Variable local para ir guardando el ID que se esta comparando por cada loop
                int idEstiloSeries = obj.EstiloDMId;

                //Si el ID es diferente significa que se termino de contar todas las tallas del estilo y se ocupa guardar
                if (idEstilo != idEstiloSeries)
                {
                    //Se guardan los datos
                    serieZapatoDM.EstiloDMId = idEstilo;
                    serieZapatoDM.CantidadDisponible = existencia;

                    //Se resetean variables o se cambian a un nuevo valor
                    existencia = 0;
                    idEstilo = idEstiloSeries;

                    //Se agrega a la lista
                    listaEstilosTallas.Add(serieZapatoDM);
                }
                else
                {
                    //Se suman las existencias
                    existencia = existencia + obj.CantidadDisponible;
                }

            }

            //If que sirve para verificar si el ultimo elemento de la listaDM fue agregado a la nueva lista
            if (existencia != 0)
            {
                listaEstilosTallas.Add(listaSeries.ElementAt(listaEstilosTallas.Count));
            }

            return listaEstilosTallas;
        }

        //Metodo para obtener la lista de tallas de un estilo en especifico
        public IEnumerable<EstiloDMTallaDM> GetTallasEstilo(int id)
        {
            try
            {
                return UoW.EstiloDMTallaDM.GetEstilosTallasWJoinedInfo(id);
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException();
            }
            catch (Exception err)
            {
                throw err;
            }

        }

        public ColorDM GuardarColorYObtenerObjeto(ColorDM colorDM)
        {
            if (colorDM.ColorDMId != 0)
            {
                //Si es diferente a 0 se actualiza           
                UoW.ColorRepository.Update(colorDM);
            }
            else
            {
                UoW.ColorRepository.Add(colorDM);
            }
            //Se guardan los cambios
            UoW.Complete();
            //Se retorna el mismo objeto. Si se creo se EF le asigna un ID y actualiza el obj, sino ya lo va a tener asignado
            return colorDM;
        }

        /// <summary>
        /// Metodo para guardar la imagen, al final del proceso reenvia un objeto nuevo para ser utilizado otra vez
        /// </summary>
        /// <returns>ImagenEstiloDM</returns>
        /// 
        public ImagenEstiloDM GuardarImagenYObtenerObjeto(int estiloDMId, string path)
        {
            try
            {
                //Se forma el objeto para guardar. Por defecto no son destacadas
                ImagenEstiloDM imagenEstiloDM = new ImagenEstiloDM();
                imagenEstiloDM.EsPrincipal = false;
                imagenEstiloDM.EstiloDMId = estiloDMId;
                imagenEstiloDM.Path = path;

                //Se va a fijar si el estilo ya tiene una imagen principal. Si no la tiene la setea como principal
                if (UoW.ImagenEstiloRepository.GetImagenPrincipal(estiloDMId) == null)
                {
                    imagenEstiloDM.EsPrincipal = true;
                }

                //Se agrega y se guardan los cambios
                UoW.ImagenEstiloRepository.Add(imagenEstiloDM);
                UoW.Complete();

                return imagenEstiloDM;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Metodo para remover todos los datos de una imagen en BD. Retorna el path de la imagen para removerla
        /// </summary>
        /// <returns>String</returns>
        /// 
        public string BorrarImagen(int imagenEstiloDMId)
        {
            try
            {
                //Se obtiene el objeto
                var imagen = UoW.ImagenEstiloRepository.GetById(imagenEstiloDMId);

                //se guarda el path
                string path = imagen.Path;
                //Se borra y se guardan los cambios
                UoW.ImagenEstiloRepository.Remove(imagen);
                UoW.Complete();

                return path;
            }
            catch (Exception)
            {
                return null;
            }
        }

        //Metodos para obtener IEnumerables para cargar los dropdowns

        public IEnumerable<ColorDM> GetListaColores()
        {
            try
            {
                return UoW.ColorRepository.GetAll();
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException();
            }
            catch (Exception err)
            {
                throw err;
            }
            
        }

        public IEnumerable<TallaDM> GetListaTallas()
        {
            try
            {
                return UoW.TallaRepository.GetAll();
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException();
            }
            catch (Exception err)
            {
                throw err;
            }

        }

        public IEnumerable<GeneroDM> GetListaGeneros()
        {
            try
            {
                return UoW.GeneroRepository.GetAll();
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException();
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public IEnumerable<EdadDM> GetListaEdades()
        {
            try
            {
                return UoW.EdadRepository.GetAll();
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException();
            }
            catch (Exception err)
            {
                throw err;
            }        
        }

        public IEnumerable<ClasificacionZapatoDM> GetListaClasificaciones()
        {
            try
            {
                return UoW.ClasificacionZapatoRepository.GetAll();
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException();
            }
            catch (Exception err)
            {
                throw err;
            }
        }

    }
}

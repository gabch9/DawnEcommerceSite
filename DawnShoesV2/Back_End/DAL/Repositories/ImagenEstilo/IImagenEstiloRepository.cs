using Back_End.DAL.Models;
using Back_End.DAL.Repositories.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_End.DAL.Repositories.ImagenEstilo
{
    public interface IImagenEstiloRepository : IGenericInterface<ImagenEstiloDM>
    {
        //Obtiene una lista de todas las imagenes de un estilo en especifico
        IEnumerable<ImagenEstiloDM> GetTodasFotosEstilo(int estiloDMId);

        //Obtiene imagen principa de un estilo
        ImagenEstiloDM GetImagenPrincipal(int estiloDMId);

        //Obtiene el ultimo ID de un estilo
        int? GetLastImagenID(int estiloDMId);
    }
}

using Back_End.DAL.Models;
using Back_End.DAL.Repositories.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Back_End.DAL.Repositories.ImagenEstilo
{
    public class ImagenEstiloRepositoryImpl : GenericInterfaceImpl<ImagenEstiloDM>, IImagenEstiloRepository
    {
        public ImagenEstiloRepositoryImpl(DawnShoesModel context) : base(context)
        {

        }

        public ImagenEstiloDM GetImagenPrincipal(int estiloDMId)
        {
            //Query que busca entre la imagen la principal de un estilo en especifico
            Expression<Func<ImagenEstiloDM, bool>> query =(x => x.EstiloDMId == estiloDMId && x.EsPrincipal == true);
            return Find(query).FirstOrDefault();
        }

        public int? GetLastImagenID(int estiloDMId)
        {
            try
            {
                return GetAll().Max(x => x.ImagenEstiloDMId);
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public IEnumerable<ImagenEstiloDM> GetTodasFotosEstilo(int estiloDMId)
        {
            return GetAll().Where(x => x.EstiloDMId == estiloDMId);
        }
    }
}
